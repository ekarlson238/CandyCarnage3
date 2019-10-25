using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAttack : MonoBehaviour
{
    [SerializeField]
    private float damagePerSecond;
    [SerializeField]
    private float dotTime;

    public static float waterDamagePerSecond;
    public static float waterDotTime;

    private ParticleSystem part;

    void Awake()
    {
        part = GetComponent<ParticleSystem>();

        waterDamagePerSecond = damagePerSecond;
        waterDotTime = dotTime;
    }

    /// <summary>
    /// checks if the thing being collided with is tagged as an enemy
    /// if they are tagged as an enemy, check if they have a WaterDamageOverTime component
    /// if they dont, add one
    /// if they do, reset the DOT's timer
    /// </summary>
    /// <param name="other">What the particle system is colliding with</param>
    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<WaterDamageOverTime>() == null)
                other.AddComponent<WaterDamageOverTime>();
            else
                other.GetComponent<WaterDamageOverTime>().AddDot();
        }
    }
}
