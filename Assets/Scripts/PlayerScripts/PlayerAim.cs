using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField]
    private LayerMask aimLayerMask;

    [SerializeField]
    private GameObject arrowPrefab;

    private ParticleSystem water;

    [SerializeField][Tooltip("How far in front of the player the prefab spawns (can't be too close")]
    private float arrowSpawnDistance = 2;

    [SerializeField][Tooltip("Lower = faster")]
    private float timeBetweenShots = 1;
    
    private AudioSource shotSFX;

    private float timeSinceShot;

    // Start is called before the first frame update
    private void Start()
    {
        water = GetComponentInChildren<ParticleSystem>();

        shotSFX = GetComponent<AudioSource>();

        timeSinceShot = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        MouseRotate();
        //ShootArrow();
        ShootWater();
    }

    /// <summary>
    /// Rotates the player to face the mouse
    /// The mouse must be above something to work; if there are no objects under the mouse, the player wont move.
    /// </summary>
    private void MouseRotate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100, aimLayerMask))
        {
            Vector3 lookPos = hit.point;
            lookPos.y = transform.position.y;
            transform.LookAt(lookPos);
        }
    }

    /// <summary>
    /// shots out the prefab if the fire button is down and hasnt shot since timeBetweenShots
    /// </summary>
    private void ShootArrow()
    {
        Vector3 playerPos = transform.position;
        Vector3 playerDirection = transform.forward;
        Quaternion playerRotation = transform.rotation;
        
        Vector3 spawnPos = playerPos + playerDirection * arrowSpawnDistance;

        if (timeSinceShot <= timeBetweenShots)
        {
            timeSinceShot += Time.deltaTime;
        }

        if (Input.GetButton("Fire1") && timeSinceShot >= timeBetweenShots)
        {
            if (shotSFX != null)
                shotSFX.Play();

            Instantiate(arrowPrefab, spawnPos, playerRotation);
            timeSinceShot = 0;
        }
    }

    private void ShootWater()
    {
        if (Input.GetButton("Fire1"))
        {
            water.Emit(20);
        }
    }
}
