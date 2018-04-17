using UnityEngine;
using System.Collections;

// attach script to main camera
public class CameraController : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;
    private Quaternion normalGravity, reverseGravity;
    private int gravity;
    private float yOffset;

    void Start ()
    {
        player = GameObject.FindWithTag ("Player");
        offset = transform.position - player.transform.position;
        gravity = 1;
        yOffset = offset.y;

        //get necessary rotations
        normalGravity = transform.rotation;
        transform.Rotate (-30, 0, 0);
        reverseGravity = transform.rotation;
        transform.Rotate (30, 0, 0);
    }

    void Update()
    {
        //if reversed gravity, rotate and move camera until in position
        if (gravity == -1)
        {
            if (transform.rotation != reverseGravity)
                transform.Rotate (-Time.deltaTime * 15, 0, 0);
            if (offset.y > -yOffset)
                offset.y = offset.y - Time.deltaTime * 5;
        }
        //if regular gravity, rotate and move camera until in position
        else
        {
            if (transform.rotation != normalGravity)
                transform.Rotate (Time.deltaTime * 15, 0, 0);
            if (offset.y < yOffset)
                offset.y = offset.y + Time.deltaTime * 5;
        }

        //reverse gravity
        if (Input.GetKeyDown (KeyCode.E) && player.GetComponent<PlayerController> ().level2Completed)
            gravity = -gravity;
    }

    void LateUpdate ()
    {
        //follow around player
        transform.position = player.transform.position + offset;
    }
}