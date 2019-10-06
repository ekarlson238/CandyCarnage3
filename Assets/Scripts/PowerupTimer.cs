using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupTimer : MonoBehaviour
{
    [SerializeField]
    private Image powerUpTimer;

    private float amount;

    // Start is called before the first frame update
    void Start()
    {
        powerUpTimer.GetComponent<Image>();

        amount = 1;
    }

    private void Update()
    {
        if(Input.anyKey)
        {
            amount -= amount * Time.deltaTime;
        }

        powerUpTimer.fillAmount = amount;
    }

}
