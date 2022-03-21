using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBonus : MonoBehaviour
{
    public float collisionBonus = 0.5f;
    public string collisionTag;

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        Health health = collision.gameObject.GetComponent<Health>();
        health.GetHealth(collisionBonus);
        Destroy(gameObject);
    }
}
