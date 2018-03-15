using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
    public float speed;
    public float jumpHeight;
    public float runMultiplier;
    public float floorHeight;
    public bool isGrounded;
    public GameObject obstacle;
    public bool level1Completed;

    private Rigidbody rb;
    private Vector3 spawnLocation;
    private Scene activeScene;

    void Start ()
    {
        DontDestroyOnLoad (gameObject);
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        spawnLocation = new Vector3 (0f, 0.75f, 0f);
        activeScene = SceneManager.GetActiveScene ();
    }

    void FixedUpdate()
    {
        if (activeScene.name != "Character Creation")
        {
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");

            float moveSpeed = speed;
            if (Input.GetKey (KeyCode.LeftShift))
                moveSpeed = moveSpeed * runMultiplier;

            rb.AddForce (new Vector3 (moveHorizontal * moveSpeed, 0, moveVertical * moveSpeed));

            if (Input.GetKey (KeyCode.Space) && isGrounded)
            {
                rb.AddForce (Vector3.up * jumpHeight);
                isGrounded = false;
            }

            if (transform.position.y <= -20f)
            {
                transform.position = spawnLocation;
                obstacle.SetActive (false);
            }
        }
    }

    void OnCollisionStay(Collision other)
    {
        if ((other.gameObject.CompareTag ("Ground") || other.gameObject.CompareTag ("Moving Platform")) && !isGrounded)
            isGrounded = true;

        if (other.gameObject.CompareTag ("Moving Platform"))
            transform.parent.SetParent (other.transform);

        if (other.gameObject.name == "dude lookout" && obstacle.activeSelf == false) 
            obstacle.SetActive (true);

        if (other.gameObject.name == "Checkpoint") 
        {
            spawnLocation = other.transform.position;
            spawnLocation.y += 0.75f;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Moving Platform") || other.gameObject.CompareTag("dude lookout"))
            transform.parent.SetParent (null);
    }
}
