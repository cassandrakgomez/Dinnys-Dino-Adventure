using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creature : MonoBehaviour
{    

    [Header("Creature Settings")]
    [SerializeField] bool isDead = false;
    [SerializeField] string creatureName = "Dinny";
    [SerializeField] int health = 3;

    [Header("Jump Settings")]
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    [Header("Audio Settings")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    [SerializeField] bool isGrounded = true;

    SpriteRenderer sr;
    Rigidbody2D rb;

    private ShardProgressBar shardProgressBar;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        shardProgressBar = FindObjectOfType<ShardProgressBar>();
    }

    void Update()
    {
         isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void Move(Vector3 movement)
    {
        transform.localPosition += movement * 12 * Time.deltaTime;
        
        FlipSprite(movement.x);

    }

    public void Jump()
    {
    // Ensure the player is grounded before jumping
    if (isGrounded)
    {
        // Clear any existing vertical velocity
        rb.velocity = new Vector2(rb.velocity.x, 0f);

        // Apply the jump force
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // Log the jump for debugging
        Debug.Log($"Jumping! Force: {jumpForce}, Current Velocity: {rb.velocity}");
    }
    else
    {
        Debug.Log("Cannot jump - not grounded!");
    }
    }

    private void FlipSprite(float moveDirection)
    {
        if (moveDirection > 0)
        {
            sr.flipX = true;
        }
        if (moveDirection < 0)
        {
            sr.flipX = false;
        }
    }

    public void TakeDamage(int damage)
    {
        // Check if shield is active
        if (shardProgressBar != null && shardProgressBar.HasShield())
        {
            Debug.Log("Shield Active! No Damage Taken!");
            return;
        }
        // Take damage if not shielded
        health -= damage; 
        Debug.Log($"You've Taken Damage! Health: {health}");
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food") && health < 3) 
        {
            health++;
            audioSource.PlayOneShot(audioClip);
            //Debug.Log($"You've eaten food! Health: {health}");
        }
    }

    public int GetHealth()
    {
        return health;
    }


    public void Die()
    {
        isDead = true;
        //Debug.Log("Creature Died");

        DeathMenu deathMenu = FindObjectOfType<DeathMenu>();
        if (deathMenu != null)
        {
            deathMenu.TriggerGameOver();
        }
        Destroy(gameObject);
        
    }
    
}
