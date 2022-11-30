using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float vel;
    bool dirR = true;

    public Transform groundChecker;
    public Transform wallChecker;
    public LayerMask wallMask;
    bool isCollidingWall;
    bool isCollidingGround;

    Rigidbody2D rb;
    Animator anim;
    AudioSource aud;
    float audVolume;
    public AudioClip tss;
    public AudioClip fireball;

    bool running = true;
    public ParticleSystem fire;
    ParticleSystem fire2;
    public GameObject dieEffect;
    public GameObject dieEffectTostado;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        audVolume = aud.volume;
    }

    private void Update()
    {
        isCollidingWall = Physics2D.OverlapCircle(wallChecker.transform.position, 0.05f, wallMask);
        isCollidingGround = Physics2D.OverlapCircle(groundChecker.transform.position, 0.05f, wallMask);
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
        if (running && isCollidingGround && aud.volume != audVolume)
        {
            aud.volume = audVolume;

        }else if(!isCollidingGround || !running)
        {
            if (audVolume != 0)
            {
                aud.volume = 0;
            }
        }
    }

    public void Aguita()
    {
        fire.Stop();
        if (fire2)
            fire2.Stop();
        AudioSource audFire = fire.GetComponent<AudioSource>();
        audFire.loop = false;
        audFire.clip = tss;
        audFire.Play();
        running = false;
        anim.SetBool("Idle", true);
    }

    public void Die()
    {
        LevelManager lvl = FindObjectOfType<LevelManager>();
        if (lvl.timeRemaining < lvl.timeBeforeDeath / 2)
        {
            GameObject effect = Instantiate(dieEffectTostado, transform.position, Quaternion.identity);
            Destroy(effect, 2);
        }
        else
        {
            GameObject effect = Instantiate(dieEffect,transform.position,Quaternion.identity);
            Destroy(effect, 2);
        }
        ParticleSystem[] effectos = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem p in effectos)
        {
            p.gameObject.transform.parent = null;
            p.Stop();
            Destroy(p.gameObject, 2);
        }
        Destroy(gameObject);
        FindObjectOfType<LevelManager>().RestartLevel();
    }

    public void Faster()
    {
        fire2 = Instantiate(fire.gameObject, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        fire2.gameObject.transform.parent = transform;
        fire2.Play();
        AudioSource fireBall = new GameObject("fireballEffect").AddComponent<AudioSource>().GetComponent<AudioSource>();
        fireBall.clip = fireball;
        fireBall.volume = 0.5f;
        fireBall.Play();
        Destroy(fireBall.gameObject, 2);

    }
    public void Mute(bool mute)
    {
        if (mute)
        {
            aud.Pause();
        }
        else
        {
            aud.Play();
        }
    }
}
