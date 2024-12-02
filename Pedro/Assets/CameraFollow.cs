using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, playerPos.position.x, 5f * Time.deltaTime), Mathf.Lerp(transform.position.y, playerPos.position.y, 5f * Time.deltaTime), -10);
    }
}
