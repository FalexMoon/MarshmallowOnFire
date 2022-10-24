using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject waterEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject effect = Instantiate(waterEffect, collision.transform.position - new Vector3(0, 0.5f), Quaternion.Euler(new Vector3(0,0,45)));
            Player player = collision.GetComponent<Player>();
            player.fire.Stop();
            player.running = false;
            Destroy(effect, 1);
        }
    }
}
