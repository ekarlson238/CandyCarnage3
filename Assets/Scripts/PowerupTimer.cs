using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupTimer : MonoBehaviour
{
    [Tooltip("Place the image component you are looking for in here.")]
    [SerializeField]
    private Image powerUpTimer;

    //I was going to try and do the math in advance here, so the designers can input whatever number of seconds they'd like.
    //[SerializeField]
    //[Tooltip("The time in seconds you want the power up to last.")]
    private float timeInSeconds;

    private float amount;


    // Start is called before the first frame update
    void Start()
    {
        //Gets the image component.
        powerUpTimer.GetComponent<Image>();

        //The amount of the fill.
        amount = 1f;

        ///The time in seconds, taken down to the thousanth place.
        ///The math got weird, still trying to work it out.
        timeInSeconds = 0.005f;
    }

    private void Update()
    {
        ///The amount of fill is reduced by the time in seconds. 
        amount -= timeInSeconds;

        ///If the amount is less than or equal to zero, the amount is set to 0.
        if (amount <= 0)
            amount = 0;

        ///The power up fill amount = the amount number, constantly reducing in update.
        powerUpTimer.fillAmount = amount;

        Debug.Log("Amount = " + amount);
    }

}
