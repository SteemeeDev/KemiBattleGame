using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KolbeAttack : Attack
{
    public Vector3 throwDir;
    public float expireTime;

    public override IEnumerator attack(float delay)
    {
        Debug.Log("Weird attack!");

        float elapsed = 0;

        while (elapsed < expireTime)
        {
            elapsed += Time.deltaTime;

            transform.position += throwDir * Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
