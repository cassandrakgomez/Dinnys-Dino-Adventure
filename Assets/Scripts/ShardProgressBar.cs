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

    void Start()
    {
        UpdateShardProgress(); 
    }

    public void CollectShard()
    {
        if (currentShards < requiredShards)  // Increment only if not yet full
        {
            Debug.Log("Current Shards: "+ currentShards);
            currentShards++;  // Increase shard count
            UpdateShardProgress();  // Update progress bar
        }
    }

    void UpdateShardProgress()
    {
        float progress = (float)currentShards / requiredShards;
        SetReloadProgress(progress);  // Adjust the shield bar 

        // Show/hide bar objects based on shard count
        bool barActive = currentShards > 0; 
        foreach (GameObject obj in hideableBarObjects)
        {
            obj.SetActive(barActive);
        }
    }

    private void SetReloadProgress(float progress)
    {
        Debug.Log("Progress: " + progress);  // Log the progress value for debugging
        ShieldBar.localScale = new Vector3(progress, ShieldBar.localScale.y, 1);
    }
}

