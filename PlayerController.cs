using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody rig;

    void Awake()
    {
        // Retrive the rigidbody componet.
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
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

        
        
        transform.forward = facingDir;
        
    }
}

