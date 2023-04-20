using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public enum BarStyles
    {
        Percentage,
        OverMax
    }

    public TextMeshProUGUI healthText;
    public Image healthBar;

    public HealthSystem healthSystem;

    public string ValueName;

    public BarStyles BarStyle;

    private void Start()
    {
        UpdateHealthBar();
    }


    public void UpdateHealthBar()
    {
        switch (BarStyle)
        {
            case BarStyles.Percentage:
                PercentageDisplay(healthSystem.Health);
                break;
            case BarStyles.OverMax:
                OverMaxDisplay(healthSystem.Health);
                break;
            default:
                break;
        }
    }

    public void PercentageDisplay(float CurrentHealth)
    {
        float HealthCut = CurrentHealth / (float)healthSystem.MaxHealth.FullValue;
        Debug.Log(HealthCut);
        float HealthPercentage = HealthCut * 100;
        Debug.Log(HealthPercentage);
        healthText.text = ValueName + ": " + (int)HealthPercentage + "%";
        healthBar.fillAmount = HealthCut;
    }

    public void OverMaxDisplay(float CurrentHealth)
    {
        float HealthCut = CurrentHealth / (float)healthSystem.MaxHealth.FullValue;
        Debug.Log(HealthCut);
        float HealthPercentage = HealthCut * 100;
        Debug.Log(HealthPercentage);
        healthText.text = ValueName + ": " + (int)CurrentHealth + " / " + (int)healthSystem.MaxHealth.FullValue;
        healthBar.fillAmount = HealthCut;
    }
}