using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
    public GameObject obstacle;
    public float speed;
    public float jumpHeight;
    public float runMultiplier;
    public float floorHeight;
    public bool isGrounded = true;
    public bool gravity = true;
    public bool level1Completed = false;
    public bool level2Completed = false;
    public bool level3Completed = false;

    public GameObject bullet;
    private Transform bulletSpawn;
    public float shootRate = 5f;
    public float bulletSpeed = 500f;
    public float bulletLifetime = 0.5f;
    public float switchRate = 1f;

    private float timeToShoot = 0f;
    private float timeToSwitch = 0f;
    private Rigidbody rb;
    private Vector3 spawnLocation;
    private Scene activeScene;

    void Start ()
    {
        DontDestroyOnLoad (gameObject);
        rb = GetComponent<Rigidbody>();
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

            // respawn
            if (transform.position.y <= -10f || transform.position.y >= 20f)
            {
                //if spawn location is on floor, gravity is down
                if (spawnLocation.y == 0.75f || spawnLocation.y == 15.75)
                {
                    Physics.gravity = new Vector3 (0, -9.8f, 0);
                    GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().gravity = true;
                }
                //if spawn location is on ceiling, gravity is up
                else
                {
                    Physics.gravity = new Vector3 (0, 9.8f, 0);
                    GameObject.FindWithTag ("MainCamera").GetComponent<CameraController> ().gravity = false;
                }
                transform.position = spawnLocation;
                obstacle.gameObject.GetComponent<ObstacleController> ().resetPos ();
                obstacle.SetActive (false);
            }

            // shooting
            if (level1Completed && Input.GetKey (KeyCode.Return) && Time.time >= timeToShoot)
            {
                timeToShoot = Time.time + 1f / shootRate;
                Shoot ();
            }

            //switching gravity
            if (level2Completed && Input.GetKey (KeyCode.E) && Time.time >= timeToSwitch) 
            {
                timeToSwitch = Time.time + 1f / switchRate;
                SwitchGravity ();
            }
        }
    }

    void OnCollisionStay(Collision other)
    {
        if ((other.gameObject.CompareTag ("Ground") || other.gameObject.CompareTag ("Moving Platform"))
            && !isGrounded && Time.time >= timeToSwitch)
            isGrounded = true;

        if (other.gameObject.CompareTag ("Moving Platform"))
            transform.parent.SetParent (other.transform);

        if (other.gameObject.name == "dude lookout" && obstacle.activeSelf == false) 
            obstacle.SetActive (true);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Checkpoint") 
        {
            spawnLocation = other.transform.position;
            if (gravity)
                spawnLocation.y += 0.75f;
            else
                spawnLocation.y -= 0.75f;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Moving Platform") || other.gameObject.CompareTag("dude lookout"))
            transform.parent.SetParent (null);
    }

    void Shoot ()
    {
        bulletSpawn = GameObject.FindGameObjectWithTag ("Bullet Spawn").transform;
        var _bullet = (GameObject)Instantiate (
            bullet,
            bulletSpawn.transform,
            false);
        _bullet.transform.position = bulletSpawn.transform.position;
        _bullet.GetComponent<Rigidbody> ().velocity = _bullet.transform.forward * bulletSpeed;
        Destroy (_bullet, bulletLifetime);
    }

    void SwitchGravity()
    {
        Physics.gravity = -Physics.gravity;
        gravity = !gravity;
        jumpHeight = -jumpHeight;
        isGrounded = false;
    }
}
