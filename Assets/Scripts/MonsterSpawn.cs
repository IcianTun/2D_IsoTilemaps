using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MonsterSpawn : MonoBehaviour
{
    public GameObject MonsterPrefab;

    public GameObject monsterSpawned;

    private Tilemap tilemap;
    private TilemapRenderer tilemapRenderer;

    public List<Vector3> availablePlaces;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemapRenderer.enabled = false;
        availablePlaces = new List<Vector3>();

        for (int n = tilemap.cellBounds.xMin; n < tilemap.cellBounds.xMax; n++)
        {
            for (int p = tilemap.cellBounds.yMin; p < tilemap.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = (new Vector3Int(n, p, (int)tilemap.transform.position.y));
                Vector3 place = tilemap.CellToWorld(localPlace);
                if (tilemap.HasTile(localPlace))
                {
                    availablePlaces.Add(place);
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(monsterSpawned == null)
        {
            SpawnMonster();
        }
        
    }

    void SpawnMonster()
    {
        Vector3 spawnPos = availablePlaces[Random.Range(0, availablePlaces.Count)];
        monsterSpawned = Instantiate(MonsterPrefab, spawnPos + new Vector3(0,0.25f,0), Quaternion.identity);
    }
}
