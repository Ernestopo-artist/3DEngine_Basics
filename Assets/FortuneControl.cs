using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortuneControl : MonoBehaviour
{
    public float Speed = 5f;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var movement = movementInput * Speed * Time.fixedDeltaTime;
        if (movement.y < 0f)
            movement.y *= 0.9f;
        movement.x *= 0.95f;
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(movement.x, 0f, movement.y, ForceMode.VelocityChange);
        var animator = GetComponent<Animator>();
        animator.SetFloat("Forward", rigidBody.velocity.x);
        animator.SetFloat("Y", rigidBody.velocity.z);
        //Debug.Log(movement);
    }
}
