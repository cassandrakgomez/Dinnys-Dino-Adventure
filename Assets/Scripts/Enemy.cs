using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private int damage = 1; // Amount of damage this enemy does
    [SerializeField] float speed = 5; // Speed of the enemy
    [SerializeField] float range = 5; // Range of the enemy

    private Vector2 startPos;
    private Vector2 targetPos;
    private Vector2 subPos;
    private bool pos_check;


     void Start(){
        startPos = transform.position;
        targetPos = new Vector2(startPos.x - range, startPos.y);
        pos_check = true;
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
        }
    }
}
