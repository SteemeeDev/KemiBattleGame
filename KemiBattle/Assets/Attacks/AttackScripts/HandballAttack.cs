using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HandballAttack : Attack
{
    [SerializeField] Vector3 throwDir;
    [SerializeField] float speed;
    [SerializeField] int reflections;


    Vector2 predictDir;
    Vector2 nextPos;
    cameraShake camShake;

    public override void Awake()
    {
        camShake = FindAnyObjectByType<cameraShake>();
        base.Awake();
    }

    public override IEnumerator attack(float delay)
    {

        CalculateTrajectory();

        yield return new WaitForSeconds(delay);

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            while (Vector2.Distance(transform.position, lineRenderer.GetPosition(i)) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, lineRenderer.GetPosition(i), speed * Time.deltaTime);
                yield return null;
            }
            camShake.shake = true;

        }

        Destroy(gameObject);
    }
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask groundRaycastLayer;
    RaycastHit2D hit;
    Vector3 currentPos;


    void CalculateTrajectory()
    {
        Debug.Log(transform.position);
        currentPos = transform.position;
        predictDir = throwDir.normalized;

        lineRenderer.positionCount = reflections;

        Debug.Log("Calculating trajectory!");
        lineRenderer.SetPosition(0, currentPos);

        for (int i = 1; i < reflections; i++)
        {
            hit = Physics2D.Raycast(currentPos, predictDir, Mathf.Infinity, groundRaycastLayer);
            if (hit)
            {
                Debug.Log("Hit something!");
                predictDir = Vector3.Reflect(predictDir, hit.normal);
                currentPos = hit.point + hit.normal * 0.00001f;
                
                Debug.Log(predictDir);
            }
            lineRenderer.SetPosition(i, hit.point);

        }
    }
}

