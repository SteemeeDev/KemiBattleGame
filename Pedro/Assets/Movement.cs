using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    Vector2 velocity;
    bool grounded;

    public float speed = 7;


    // Update is called once per frame
    void Update()
    {
        velocity.y = Input.GetAxisRaw("Vertical") * speed;
        velocity.x = Input.GetAxisRaw("Horizontal") * speed;

        rigidBody.velocity = velocity;
    }
}
