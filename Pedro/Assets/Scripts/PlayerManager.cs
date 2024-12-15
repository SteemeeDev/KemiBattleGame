using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health = 20;


    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("player died!");
            Destroy(gameObject);
        }
    }
}
