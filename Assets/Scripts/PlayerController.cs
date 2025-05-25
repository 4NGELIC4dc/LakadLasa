using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded = true;

    private int moveDirection = 0;
    private Animator anim; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (moveDirection == -1)
            sr.flipX = true;
        else if (moveDirection == 1)
            sr.flipX = false;

        anim.SetFloat("Speed", Mathf.Abs(moveDirection));
    }


    public void MoveLeft()
    {
        moveDirection = -1;
    }

    public void MoveRight()
    {
        moveDirection = 1;
    }

    public void StopMoving()
    {
        moveDirection = 0;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }
}
