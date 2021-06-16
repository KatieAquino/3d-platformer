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
        // Prevents model from jumping above a certain limit by checking that 
        // model is on the ground.
        Ray ray1 = new Ray(transform.position + new Vector3(0.5f, 0, 0.5f), Vector3.down);
        Ray ray2 = new Ray(transform.position + new Vector3(-0.5f, 0, 0.5f), Vector3.down);
        Ray ray3 = new Ray(transform.position + new Vector3(0.5f, 0, -0.5f), Vector3.down);
        Ray ray4 = new Ray(transform.position + new Vector3(-0.5f, 0, -0.5f), Vector3.down);

        bool cast1 = Physics.Raycast(ray1, 0.7f);
        bool cast2 = Physics.Raycast(ray2, 0.7f);
        bool cast3 = Physics.Raycast(ray3, 0.7f);
        bool cast4 = Physics.Raycast(ray4, 0.7f);

        if(cast1 || cast2 || cast3 || cast4)
        {
            // Adds force to jump to move upward.
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

