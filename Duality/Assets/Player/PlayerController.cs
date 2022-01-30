using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    //Movement
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float moveInput = 0;
    private bool facingRight = true;

    //Jumping
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    private bool isGrounded = false;

    //Dashing
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    [SerializeField] private float afterDashSpeed;
    private float dashTimer = 0;
    private bool isDashing = false;
    private bool isDashFinished = false;

    //Attacking
    [SerializeField] private float attackTime;
    [SerializeField] private Transform enemyCheck;
    [SerializeField] private float enemyCheckRadius;
    [SerializeField] private LayerMask whatIsEnemy;
    private float attackTimer = 0;
    private bool enemyFound = false;
    private bool isAttacking = false;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Jumping
        if (isGrounded == true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.up * jumpForce;
                isGrounded = false;
            }
        }

        //Dashing
        if (isDashing)
        {
            dashTimer += Time.deltaTime;
            if (dashTimer >= dashTime)
            {
                isDashing = false;
                isDashFinished = true;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            isDashing = true;
            dashTimer = 0;
        }

        if (moveInput == 0 || rb.velocity.x == 0)
        {
            isDashFinished = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
            isDashFinished = false;
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
            isDashFinished = false;
        }

        if (isDashing)
        {
            if (facingRight)
            {
                rb.velocity += new Vector2(dashSpeed, 0);
            }
            else
            {
                rb.velocity += new Vector2(-dashSpeed, 0);
            }
        }
        else if (isDashFinished)
        {
            if (facingRight)
            {
                rb.velocity += new Vector2(afterDashSpeed, 0);
            }
            else
            {
                rb.velocity += new Vector2(-afterDashSpeed, 0);
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}