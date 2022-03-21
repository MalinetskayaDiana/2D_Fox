using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed = 1f;
    public Transform startPos;
    Vector3 nextPos;
    [Header("Sound Settings")]
    public AudioSource Walk;
    void Start()
    {
        nextPos = startPos.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        Walk.Play();

        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
            transform.localScale = new Vector2(-1, 1);
        }

        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
            transform.localScale = new Vector2(1, 1);
        }
    }
}
