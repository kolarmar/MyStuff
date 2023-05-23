using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watergirl : MonoBehaviour, IControlable
{
    private new Rigidbody2D rigidbody;
    private bool grounded;
    public float moveSpeed;
    public float jumpStrength;

    private KeyCode moveLeftBind;
    private KeyCode moveRightBind;
    private KeyCode jumpBind;

    private KeyCode pressedButton;
    private KeyCode pressedJump;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        moveLeftBind = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLeftBlue"));
        moveRightBind = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRightBlue"));
        jumpBind = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpBlue"));
    }

    private void Update()
    {
        if (Input.GetKey(moveLeftBind))
        {
            pressedButton = moveLeftBind;
        }
        else if (Input.GetKey(moveRightBind))
        {
            pressedButton = moveRightBind;
        }
        else
        {
            pressedButton = KeyCode.None;
        }

        if (Input.GetKey(jumpBind))
        {
            pressedJump = jumpBind;
        }
        else
        {
            pressedJump = KeyCode.None;
        }
    }

    private void FixedUpdate()
    {
        if (pressedButton == moveLeftBind)
        {
            MoveLeft();
        }

        if (pressedButton == moveRightBind)
        {
            MoveRight();
        }

        if (pressedJump ==  jumpBind && grounded)
        {
            Jump();
        }
    }

    public void MoveLeft()
    {
        rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
    }

    public void MoveRight()
    {
        rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
    }

    public void Jump()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpStrength);
        grounded = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            grounded = true;
        }
    }
}
