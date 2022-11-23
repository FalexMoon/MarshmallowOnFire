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
    Animator anim;

    bool running = true;
    public ParticleSystem fire;
    public GameObject dieEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        if (running)
        {
            rb.velocity = new Vector2(vel, rb.velocity.y);
        }
    }

    public void Aguita()
    {
        fire.Stop();
        running = false;
        anim.SetBool("Idle", true);
    }

    public void Die()
    {
        GameObject effect = Instantiate(dieEffect,transform.position,Quaternion.identity);
        Destroy(effect, 2);
        Destroy(gameObject);
        FindObjectOfType<LevelManager>().RestartLevel();
    }
}
