using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public float moveSpeed = 6f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded = true;

    private int moveDirection = 0;
    private Animator anim;

    public AudioClip walkSFX;
    public AudioClip jumpSFX;
    public AudioClip pickSFX;

    private AudioSource walkAudioSource;
    [HideInInspector] public AudioSource sfxAudioSource; 

    public List<string> correctIngredients = new List<string>();
    public List<string> collectedCorrectIngredients = new List<string>();
    public List<string> collectedWrongIngredients = new List<string>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

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

    public void CollectIngredient(Ingredient ingredient)
    {
        if (ingredient.isCorrectIngredient)
        {
            collectedCorrectIngredients.Add(ingredient.name);
        }
        else
        {
            collectedWrongIngredients.Add(ingredient.name);
        }
    }

    public bool HasWon()
    {
        if (collectedWrongIngredients.Count > 0)
            return false;

        foreach (var correct in correctIngredients)
        {
            if (!collectedCorrectIngredients.Contains(correct))
                return false;
        }

        return true;
    }
}
