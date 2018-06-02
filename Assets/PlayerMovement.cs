using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float horizontal, vertical;
    Rigidbody rigid;
    public float speed = 1f;
    public bool secondPlayer = false;
    public PlayerAnimator anim;
    public bool gamepadControls;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        if(secondPlayer)
        {
            FindObjectOfType<CameraFollow>().target2 = transform;
        }
        else
        {
            FindObjectOfType<CameraFollow>().target1 = transform;
        }
    }

    void Update()
    {
        if (secondPlayer)
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal2")) >= 0.1f)
            {
                horizontal = Input.GetAxis("Horizontal2");
            }
            else
            {
                horizontal = 0;
            }
            if (Mathf.Abs(Input.GetAxis("Vertical2")) >= 0.1f)
            {
                vertical = Input.GetAxis("Vertical2");
            }
            else
            {
                vertical = 0;
            }
        }
        else
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal")) >= 0.1f)
            {
                horizontal = Input.GetAxis("Horizontal");
            }
            else
            {
                horizontal = 0;
            }
            if (Mathf.Abs(Input.GetAxis("Vertical")) >= 0.1f)
            {
                vertical = Input.GetAxis("Vertical");
            }
            else
            {
                vertical = 0;
            }
        }
        if(gamepadControls)
        {
            vertical = -vertical;
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 || vertical != 0)
        {
            rigid.MovePosition(transform.position + Vector3.right * speed * horizontal + Vector3.forward * speed * vertical);
            anim.Run(Vector3.right * horizontal + Vector3.forward * vertical);
        }
        else
        {
            anim.Idle();
        }

    }
}
