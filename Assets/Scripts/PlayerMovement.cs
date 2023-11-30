using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody2D rigidBody;
    Vector2 movemnt;

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        movemnt.x = Input.GetAxisRaw("Horizontal");
        movemnt.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movemnt * movementSpeed * Time.fixedDeltaTime);
    }
}
