using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody rig;
    private AudioSource audioSource;

    void Awake()
    {
        // Retrive the rigidbody and audiosource components.
        rig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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

    void OnTriggerEnter(Collider other)
    {
        // If player collides with enemy the scene will be reloaded.
        if(other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        // Adds to player score if collides with coin.
        else if(other.CompareTag("Coin"))
        {
            // TODO: add score
            // Plays audio clip of coin.
            audioSource.Play();

            // Removes coin from scene.
            Destroy(other.gameObject);
        }
    }
}

