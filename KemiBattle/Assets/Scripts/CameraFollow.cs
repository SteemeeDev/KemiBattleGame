using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Transform followPos;

    // Update is called once per frame
    void Update()
    {
        if (followPos == null) return;
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, followPos.position.x, 5f * Time.deltaTime), Mathf.Lerp(transform.position.y, followPos.position.y, 5f * Time.deltaTime), -10);
    }
}
