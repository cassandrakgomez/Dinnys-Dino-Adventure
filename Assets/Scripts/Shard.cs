using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shard : MonoBehaviour
{
    [SerializeField] ShardProgressBar shardProgress; 
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Shard collected!");
            shardProgress.CollectShard();
            Destroy(gameObject);
        }
    }
}
