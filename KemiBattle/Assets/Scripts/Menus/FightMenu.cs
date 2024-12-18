using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMenu : MonoBehaviour
{
    [SerializeField] CameraFollow camFollow;
    [SerializeField] Transform defaultCamPos;
    [SerializeField] Transform targetCamPos;
    [SerializeField] Transform playerTransform;
    [SerializeField, Range(0,1)] float followAmount;


    private void OnEnable()
    {
        camFollow.followPos = targetCamPos;
    }

    private void Update()
    {
        targetCamPos.position = Vector3.Lerp(defaultCamPos.position, playerTransform.position, followAmount);
    }

}
