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

    private void UpdateDashUI()
    {
        dashCooldownUI.fillAmount = playerMovement.dashCooldownTimer / playerMovement.dashCooldown;
    }
}
