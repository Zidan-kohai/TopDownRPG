using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapGenerate : MonoBehaviour
{
    [SerializeField] Vector3Int startPosition;
    [SerializeField] private Vector2Int mapSize;
    [SerializeField] private GameObject ground;
    public Variables variables;
    public Map[] maps;
    private void Awake()
    {
        GetPosition();
        for (int i = 0; i < mapSize.x; i++)
        {
            variables.Maps.Add(new List<GameObject>());
            for (int j = 0; j < mapSize.y; j++)
            {
                if (!SpawnOtherMap(ref i, ref j))
                {
                    variables.Maps[i].Add(Instantiate(ground, startPosition + new Vector3Int(i, -j, 0), ground.transform.rotation));
                }
            }
        }
    }

    private bool SpawnOtherMap(ref int PositionX, ref int PositionY)
    {
        for (int x = 0; x < maps.Length; x++)
        {
            for (int y = 0; y < maps[x].AmountOfMap; y++)
            {
                if (maps[x].PointToSpawn[y].x == PositionX && maps[x].PointToSpawn[y].y == PositionY)
                {
                    variables.Maps[PositionX].Add(Instantiate(maps[x].MinMap, startPosition + new Vector3Int(PositionX, -PositionY, 0), maps[x].MinMap.transform.rotation));
                    return true;
                }
            }
        }
        return false;
    }
    private void GetPosition()
    {
        List<Vector2Int> takingPositon = new List<Vector2Int>();
        for(int i = 0; i < maps.Length; i++)
        {
            maps[i].AmountOfMap = UnityEngine.Random.Range(maps[i].Min, maps[i].Max + 1);
            bool isPositionFree;
            for (int x = 0; x < maps[i].AmountOfMap; x++)
            {
                do
                {
                    isPositionFree = true;
                    Vector2Int SpawnPosition = new Vector2Int(UnityEngine.Random.Range(0, mapSize.x), UnityEngine.Random.Range(0, mapSize.y));

                    for (int j = 0; j < takingPositon.Count; j++)
                    {
                        if (takingPositon[j] == SpawnPosition)
                        {
                            isPositionFree = false;
                            break;
                        }
                    }

                    if (isPositionFree)
                    {
                        takingPositon.Add(SpawnPosition);
                        maps[i].PointToSpawn.Add(SpawnPosition);
                    }
                } while (!isPositionFree);
            }

        }
    }
}

[Serializable]
public class Map
{
    public GameObject MinMap;
    public int Min;
    public int Max;
    public int AmountOfMap;
    [HideInInspector]
    public List<Vector2Int> PointToSpawn = new List<Vector2Int>();
}