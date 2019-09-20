using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField]
    private GameObject arrowPrefab;

    [SerializeField]
    private float arrowSpawnDistance = 2;

    [SerializeField][Tooltip("Lower = faster")]
    private float timeBetweenShots = 1;

    private float timeSinceShot;

    private void Start()
    {
        timeSinceShot = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        MouseRotate();
        Shoot();
    }

    /// <summary>
    /// Rotates the player to face the mouse
    /// </summary>
    private void MouseRotate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            Vector3 lookPos = hit.point;
            lookPos.y = transform.position.y;
            transform.LookAt(lookPos);
        }
    }

    private void Shoot()
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
            Instantiate(arrowPrefab, spawnPos, playerRotation);
            timeSinceShot = 0;
        }
    }
}
