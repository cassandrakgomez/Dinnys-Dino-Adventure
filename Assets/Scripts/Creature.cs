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
    [SerializeField] float jumpForce = 5f;

    SpriteRenderer sr;
    Rigidbody2D rb;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        //Debug.Log("Creature Start");
    }

    void Update()
    {
         
    }

    public void Move(Vector3 movement)
    {
        transform.localPosition += movement * 12 * Time.deltaTime;
        
        FlipSprite(movement.x);

    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
            Debug.Log($"You've eaten food! Health: {health}");
        }
    }

    public int GetHealth()
    {
        return health;
    }


    public void Die()
    {
        isDead = true;
        Debug.Log("Creature Died");
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
    }
    
}
