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
