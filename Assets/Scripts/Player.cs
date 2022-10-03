using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float vel;
    bool dirR = true;

    public Transform wallChecker;
    public LayerMask wallMask;
    bool isCollidingWall;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isCollidingWall = Physics2D.OverlapCircle(wallChecker.transform.position, 0.1f, wallMask);
        if (isCollidingWall)
        {
            dirR = !dirR;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            vel = vel * -1;
        }
        rb.velocity = new Vector2(vel, rb.velocity.y);
    }
}
