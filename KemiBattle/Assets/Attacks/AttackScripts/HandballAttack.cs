using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using UnityEngine;

public class HandballAttack : Attack
{
    [SerializeField] Vector3 throwDir;
    [SerializeField] float speed;
    [SerializeField] int reflections;
    [SerializeField] Transform handBall;


    Vector2 predictDir;
    Vector2 lastPredictDir;
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

        lineRenderer.enabled = false;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            while (Vector2.Distance(handBall.position, lineRenderer.GetPosition(i)) > 0.01f)
            {
                handBall.position = Vector3.MoveTowards(handBall.position, lineRenderer.GetPosition(i), speed * Time.deltaTime);
                yield return null;
            }
            camShake.shake = true;

        }
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            while (Vector2.Distance(handBall.position, lineRenderer.GetPosition(i)) > 0.01f)
            {
                handBall.position = Vector3.MoveTowards(handBall.position, lineRenderer.GetPosition(i), speed * Time.deltaTime);
                yield return null;
            }
            camShake.shake = true;

        }

        handBall.GetComponent<CircleCollider2D>().enabled = false;
        handBall.GetComponent<TrailRenderer>().enabled = false;

        float elapsed = 0;
        while (elapsed < 0.5)
        {
            elapsed += Time.deltaTime;
            float t = (0.5f - elapsed) / 0.5f;
            Debug.Log(t*255);
            handBall.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, t);
            handBall.position += new Vector3(lastPredictDir.x, lastPredictDir.y, 0)*Time.deltaTime*6;
            yield return null;  
        }


        Destroy(gameObject);
    }
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LayerMask groundRaycastLayer;
    RaycastHit2D hit;
    Vector3 currentPos;


    void CalculateTrajectory()
    {
       // Debug.Log(transform.position);
        currentPos = handBall.position;
        predictDir = throwDir.normalized;

        lineRenderer.positionCount = reflections;

      //  Debug.Log("Calculating trajectory!");
        lineRenderer.SetPosition(0, currentPos);

        for (int i = 1; i < reflections; i++)
        {
            hit = Physics2D.Raycast(currentPos, predictDir, Mathf.Infinity, groundRaycastLayer);
            if (hit)
            {
              //  Debug.Log("Hit something!");
                predictDir = Vector3.Reflect(predictDir, hit.normal);
                currentPos = hit.point + hit.normal * 0.00001f;
                
                //Debug.Log(predictDir);
            }
            lineRenderer.SetPosition(i, hit.point);
            if (i == reflections - 1) continue;
            lastPredictDir = predictDir;
        }
    }

}

