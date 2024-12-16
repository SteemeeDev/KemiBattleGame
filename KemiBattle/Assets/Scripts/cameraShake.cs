using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    Vector3 originalPos;

    public bool shake = false;

    [SerializeField] float shakeMagnitude;
    [SerializeField] float shakeLength;

    Transform followPos;

    private void Awake()
    {
        followPos = GetComponent<CameraFollow>().followPos;
    }


    private void Update()
    {
        if (shake)
        {
            StartCoroutine(shakeCamera(shakeLength, shakeMagnitude));
            shake = false;
        }
    }

    IEnumerator shakeCamera(float duration, float magnitude)
    {
        float elapsed = 0;
        float t = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            t = Mathf.Clamp01(duration / elapsed);
            float a = 1f / t;
            transform.position = new Vector3(Random.Range(-magnitude * a, magnitude * a) + transform.position.x, Random.Range(-magnitude * a, magnitude * a) + transform.position.y, -10);
            yield return null; 
        }
    }
}
