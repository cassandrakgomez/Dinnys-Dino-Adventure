using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PercentageSlider : MonoBehaviour
{
    [SerializeField] Slider ourslider;
    [SerializeField] TextMeshProUGUI percentageText;

    public void SetPercentage(){
        percentageText.text = (ourslider.value * 100).ToString("F0")+ "%"; 
    }
}
