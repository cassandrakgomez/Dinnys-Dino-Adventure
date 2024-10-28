using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{    

    [Header("Creature Settings")]
    [SerializeField] bool isDead = false;
    [SerializeField] string creatureName = "Dinny";

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
        //transform.localPosition += movement * 12 * Time.deltaTime;
        rb.velocity = movement * 12;
    }
}
