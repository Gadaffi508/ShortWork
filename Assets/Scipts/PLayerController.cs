using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    public float jumpPower = 150;
    public float movespeed;
    private float jumpCounter;

    private bool isJumping;
    bool facingRight = true;
    public float jumpTime;
    public float jumpMultiplier;
    Vector2 vecGravity;
    public float fallMultiplier;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D playerRB;
    private Animator playeranimator;
    public Transform FirePoint;
    public GameObject bulletprefabs;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playeranimator=GetComponent<Animator>();
    }
    void Update()
    {
        HorizontalMove();

        if (playerRB.velocity.x < 0 && facingRight)
        {
            Flipface();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            Flipface();
        }

        jump();
    }
    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * movespeed, playerRB.velocity.y);
        playeranimator.SetFloat("speed", Mathf.Abs(playerRB.velocity.x));
    }
    void Flipface()
    {
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0);
    }
    void jump()
    {
        //size = 0.6002366,0.06029633
        //offset = 0.01473856,-0.01521719

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
        }
        if (playerRB.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;

            if (t > .5f)
            {
                currentJumpM = jumpMultiplier * (1 - t);
            }

            playerRB.velocity -= vecGravity * currentJumpM * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = false;
            jumpCounter = 0;
            if (playerRB.velocity.y > 0)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y * 0.6f);
            }
        }
        if (playerRB.velocity.y < 0)
        {
            playerRB.velocity -= vecGravity * fallMultiplier * Time.deltaTime;

        }
    }
    void Speed()
    {
        movespeed = 4;
    }
}
