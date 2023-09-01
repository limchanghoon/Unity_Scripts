using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Bricks : MonoBehaviour
{
    Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    public void MakeDot(Vector3 _pos)
    {
        Vector3Int cellPosition = tilemap.WorldToCell(_pos);

        tilemap.SetTile(cellPosition, null);
    }
}
