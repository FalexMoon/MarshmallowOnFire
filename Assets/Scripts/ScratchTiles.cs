using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ScratchTiles : MonoBehaviour
{
    Vector3 placePos;
    public Tilemap mapa;
    public Grid grid;
    public RuleTile tile;
    public int tilesPorUnidad = 1;

    public GameObject dirtEffect;

    public bool canScratch = true;

    public AudioClip sound;
    List<AudioSource> audios = new List<AudioSource>();

    private void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            audios.Add(new GameObject("FX " + i).AddComponent<AudioSource>().GetComponent<AudioSource>());
            audios[i].transform.parent = transform;
            audios[i].clip = sound;
            audios[i].volume = 0.5f;
            audios[i].playOnAwake = false;
        }
    }

    void Update()
    {
        if (canScratch)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                placePos = RoundToNearestHalf(worldPosition);
                Vector3Int finalPos = grid.WorldToCell(placePos);
                if (!mapa.HasTile(finalPos))
                {
                    mapa.SetTile(finalPos, tile);
                }

            }
            else if (Input.GetMouseButton(1))
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                placePos = RoundToNearestHalf(worldPosition);
                Vector3Int finalPos = grid.WorldToCell(placePos);
                if (mapa.HasTile(finalPos))
                {
                    GameObject effect = Instantiate(dirtEffect, placePos, Quaternion.identity);
                    Destroy(effect, 1);
                    foreach(AudioSource aud in audios){
                        if (!aud.isPlaying)
                        {
                            aud.Play();
                            break;
                        }
                    }
                    mapa.SetTile(finalPos, null);
                }
            }
        }
    }

    public Vector3 RoundToNearestHalf(Vector3 a)
    {
        Vector3 roundedPos = new Vector3();
        roundedPos.x = Mathf.Round(a.x * 2f * tilesPorUnidad) * (0.5f/tilesPorUnidad);
        roundedPos.y = Mathf.Round(a.y * 2f * tilesPorUnidad) * (0.5f/tilesPorUnidad);
        roundedPos = roundedPos * tilesPorUnidad;
        return roundedPos;
    }
}
