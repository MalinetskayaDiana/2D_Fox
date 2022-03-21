using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControler : MonoBehaviour
{
    public CircleCollider2D stand;
    public BoxCollider2D crouch;

    PlayerMovement player;
    void Start()
    {
        player = GetComponent<PlayerMovement>();

        stand.enabled = true;
        crouch.enabled = true;
    }

    void Update()
    {
        if (player.isGround == false)
        {
            stand.enabled = true;
            crouch.enabled = true;
        }
        else
        {
            if (player.crouch == true)
            {
                stand.enabled = true;
                crouch.enabled = false;
            }
            else
            {
                stand.enabled = true;
                crouch.enabled = true;
            }
        }
    }
}
