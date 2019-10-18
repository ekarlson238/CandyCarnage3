using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHeightToPlayer : MonoBehaviour
{
    [SerializeField]
    private Rigidbody player;
    
    void Start()
    {
        //sets the position to the player's position
        this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
    }
}
