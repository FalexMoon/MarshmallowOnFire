using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject waterEffect;
    public GameObject yeiEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject effect = Instantiate(waterEffect, collision.transform.position - new Vector3(0, 0.5f), Quaternion.Euler(new Vector3(0,0,45)));
            Player player = collision.GetComponent<Player>();
            player.Aguita();
            Destroy(effect, 1);
            StartCoroutine(Yei(collision.gameObject));
        }
    }

    IEnumerator Yei(GameObject player)
    {
        yield return new WaitForSeconds(0.5f);
        GameObject yei1 = Instantiate(yeiEffect, player.transform.position + new Vector3(0, 0.25f), Quaternion.Euler(new Vector3(0, 0, 45)));
        GameObject yei2 = Instantiate(yeiEffect, player.transform.position + new Vector3(-0.5f, 0.25f), Quaternion.Euler(new Vector3(0, 0, 45)));
        GameObject yei3 = Instantiate(yeiEffect, player.transform.position + new Vector3(0.5f, 0.25f), Quaternion.Euler(new Vector3(0, 0, 45)));
        Destroy(yei1, 1);
        Destroy(yei2, 1);
        Destroy(yei3, 1);
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.LevelComplete();
    }
}
