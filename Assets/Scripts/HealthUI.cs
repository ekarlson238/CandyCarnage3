using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth playerHealth;

    [SerializeField]
    private Image healthBar;

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    /// <summary>
    /// Updates the player health bar UI to display health (as a bar)
    /// </summary>
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = playerHealth.health / playerHealth.maxHealth;
    }
}
