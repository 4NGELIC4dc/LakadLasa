using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded = true;

    private int moveDirection = 0;
    private Animator anim;

    public AudioClip walkSFX;
    public AudioClip jumpSFX;

    private AudioSource walkAudioSource;
    private AudioSource sfxAudioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        // Add and set up 2 separate AudioSources
        walkAudioSource = gameObject.AddComponent<AudioSource>();
        sfxAudioSource = gameObject.AddComponent<AudioSource>();

        walkAudioSource.loop = true;
        walkAudioSource.playOnAwake = false;
        sfxAudioSource.playOnAwake = false;
    }

    void Update()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        if (moveDirection == -1)
            sr.flipX = true;
        else if (moveDirection == 1)
            sr.flipX = false;

        anim.SetFloat("Speed", Mathf.Abs(moveDirection));

        // Play walking sound responsively
        if (isGrounded && Mathf.Abs(moveDirection) > 0)
        {
            if (!walkAudioSource.isPlaying)
            {
                walkAudioSource.clip = walkSFX;
                walkAudioSource.Play();
            }
        }
        else
        {
            walkAudioSource.Stop();
        }
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

            // Stop walk sound and play jump SFX immediately
            walkAudioSource.Stop();
            sfxAudioSource.PlayOneShot(jumpSFX);
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
