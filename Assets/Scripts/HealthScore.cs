using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HealthText;
    [SerializeField] Creature playerDino;

    void Update()
    {
      HealthText.text = "Health: " + playerDino.GetHealth().ToString();
    }
}
