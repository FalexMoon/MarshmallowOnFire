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

    void Update()
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
                GameObject effect = Instantiate(dirtEffect,placePos,Quaternion.identity);
                Destroy(effect, 1);
                mapa.SetTile(finalPos, null);
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
