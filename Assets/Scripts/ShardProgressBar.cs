using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShardProgressBar : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HealthText;

    [Header("UI Elements")]
    [SerializeField] Transform ShieldBar;
    [SerializeField] List<GameObject> hideableBarObjects;

    [Header("Shard Collection")]
    [SerializeField] int requiredShards = 5;  // Number of shards needed
    private int currentShards = 0;  // Starting value of shards

    [Header("Shield Settings")]
    [SerializeField] GameObject Dinny; 
    [SerializeField] Sprite DinnyShielded;
    [SerializeField] Sprite DinnySprite;
    [SerializeField] float shieldDuration = 5f;

    private bool sheildActive = false; 
    private SpriteRenderer sr;

    void Start()
    {
        sr = Dinny.GetComponent<SpriteRenderer>();
        UpdateShardProgress(); 
    }

    public void CollectShard()
    {
        if (currentShards < requiredShards)
        {
            currentShards++;  // Increase shard count
            Debug.Log("Current Shards: "+ currentShards);
            UpdateShardProgress();  // Update progress bar

            if(currentShards >= requiredShards)  
            {
                ActivateShield();
            }
        }
    }

    void UpdateShardProgress()
    {
        float progress = (float)currentShards / requiredShards;
        SetReloadProgress(progress);  // Adjust the shield bar 

        bool barActive = currentShards > 0; 
        foreach (GameObject obj in hideableBarObjects)
        {
            obj.SetActive(barActive);
        }
    }

    private void SetReloadProgress(float progress)
    {
        //Debug.Log("Progress: " + progress);  
        ShieldBar.localScale = new Vector3(progress, ShieldBar.localScale.y, 1);
    }

    void ActivateShield()
    {
        sheildActive = true; 
        sr.sprite = DinnyShielded; 
        StartCoroutine(ShieldTimer());
    }

    IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(shieldDuration);
        sheildActive = false; 
        sr.sprite = DinnySprite; 

        // Reset shard progress
        currentShards = 0;
        UpdateShardProgress();
    }

    //Method to check if the player has a shield for later use
    public bool HasShield()
    {
        return sheildActive; 
    }

}

