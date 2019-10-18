using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashUI : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private Image dashCooldownUI;

    // Update is called once per frame
    void Update()
    {
        UpdateDashUI();
    }

    /// <summary>
    /// Updates the dash UI to visualize the dash's cooldown
    /// </summary>
    private void UpdateDashUI()
    {
        dashCooldownUI.fillAmount = playerMovement.dashCooldownTimer / playerMovement.dashCooldown;
    }
}
