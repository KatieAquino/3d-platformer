using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody rig;

    void Awake()
    {
        // Retrive the rigidbody componet.
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        if(Input.GetButtonDown("Jump"))
        {
            TryJump();
        }
    }

    void Move()
    {
        // Retrieving inputs.
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // Move player model according to inputs.
        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;
        dir.y = rig.velocity.y;

        rig.velocity = dir;

        // Rotate player model according to inputs.
        Vector3 facingDir = new Vector3(xInput, 0, zInput);

        if(facingDir.magnitude > 0)
        {
            transform.forward = facingDir;
        }
    }

    void TryJump()
    {
        // Prevents model from jumping above a certain limit.
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, 0.7f))
        {
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

