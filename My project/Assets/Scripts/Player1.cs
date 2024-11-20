using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 15f;
    [SerializeField] bool isJump;
    [SerializeField] bool inFloor;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    Animator animPlayer;

    private void Awake()
    {
        animPlayer = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inFloor = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
        Debug.DrawLine(transform.position, groundCheck.position, Color.blue);

        animPlayer.SetBool("Jump", !inFloor);

        if (Input.GetButtonDown("Jump") && inFloor)
        {
            isJump = true;
        }
        Attack();
    }

    private void FixedUpdate()
    {
        Move();
        JumpPlayer();
       
    }


    void Move()
    {
        float xMove = Input.GetAxis("Horizontal");
        rbPlayer.velocity = new Vector2(xMove * speed, rbPlayer.velocity.y);

        animPlayer.SetFloat("Speed", Mathf.Abs(xMove));

        if (xMove > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if (xMove < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }


    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animPlayer.SetBool("Attack", true);
            rbPlayer.velocity = Vector2.zero;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            animPlayer.SetBool("Attack", false);
        }

    }

    void JumpPlayer()
    {
        if (isJump)
        {

            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, jumpForce);
            isJump = false;
        }
    }
}
