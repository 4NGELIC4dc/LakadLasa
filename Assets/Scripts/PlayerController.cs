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

    // SFX
    public AudioClip walkSFX;
    public AudioClip jumpSFX;
    public AudioClip pickSFX;

    private AudioSource walkAudioSource; // For continuous walking sfx
    [HideInInspector] public AudioSource sfxAudioSource; // For one-shot of jump/pick sfx

    // Collecting wrong or correct ingredients
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

        // Set SFX volumes from GameSettingsManager
        walkAudioSource.volume = GameSettingsManager.Instance.sfxVolume;
        sfxAudioSource.volume = GameSettingsManager.Instance.sfxVolume;
    }

    void Update()
    {
        // Moves player horizontally
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        // Flip sprite direction
        if (moveDirection == -1)
            sr.flipX = true;
        else if (moveDirection == 1)
            sr.flipX = false;

        // Set animation speed based on movement
        anim.SetFloat("Speed", Mathf.Abs(moveDirection));

        // Handle walking sfx
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
    // Called movement buttons
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
            sfxAudioSource.PlayOneShot(jumpSFX, GameSettingsManager.Instance.sfxVolume);
        }
    }

    // Player colliders with objects
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
        }
    }

    // Player colliders for ingredient collection
    public void CollectIngredient(Ingredient ingredient)
    {
        if (ingredient.isCorrectIngredient)
        {
            if (!collectedCorrectIngredients.Contains(ingredient.ingredientID))
                collectedCorrectIngredients.Add(ingredient.ingredientID);
        }
        else
        {
            if (!collectedWrongIngredients.Contains(ingredient.ingredientID))
                collectedWrongIngredients.Add(ingredient.ingredientID);
        }
    }

    // Check if player collected all correct ingredients
    public bool HasWon()
    {
        if (collectedWrongIngredients.Count > 0) // Fail if wrong ingredients collected
            return false;

        foreach (var correct in correctIngredients)
        {
            if (!collectedCorrectIngredients.Contains(correct))
                return false;
        }

        return true;
    }
}