using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAPI;

public class PlayerMovement : NetworkedBehaviour
{
    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    public bool movedForward;

    CharacterController cc;
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
        if (!isLocalPlayer)
        {
            cam.enabled = false;
        } else
        {
            cc = GetComponent<CharacterController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            MovePlayer();
        }
    }
    void MovePlayer()
    {
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //move = Vector3.ClampMagnitude(move, 1f);
        //move = transform.TransformDirection(move);
        //cc.SimpleMove(move * 5f);
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            movedForward = true;
        }
        else
        {
            movedForward = false;
        }
        if (movedForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
    }
}
