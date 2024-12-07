using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private int damage = 1; // Amount of damage this enemy does
    [SerializeField] float speed = 5; // Speed of the enemy
    [SerializeField] float range = 5; // Range of the enemy
    [SerializeField] bool pos_check;

    private Vector2 startPos;
    private Vector2 targetPos;
    SpriteRenderer sr;

     void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
     
     void Start(){
        startPos = transform.position;
        if(pos_check){
                targetPos = new Vector2(startPos.x + range, startPos.y);   
            }
        else{
                targetPos = new Vector2(startPos.x - range, startPos.y);
            }
        //targetPos = new Vector2(startPos.x - range, startPos.y);
    }

    void FixedUpdate(){
        EvilMovement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Creature>().TakeDamage(damage);
        }
    }

    public void EvilMovement(){
        Vector2 currentLoc = transform.position;
        transform.position = Vector2.MoveTowards(currentLoc, targetPos, speed * Time.deltaTime);
        if (Vector2.Distance(currentLoc, targetPos) < 0.1f){

            if(pos_check){
                targetPos = new Vector2(startPos.x + range, startPos.y);
            }
            else{
                targetPos = new Vector2(startPos.x - range, startPos.y);
            }

            pos_check = !pos_check;
            sr.flipX = !sr.flipX;
        }
    }
}
