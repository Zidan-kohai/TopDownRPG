using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Variables : MonoBehaviour
{
    public List<List<GameObject>> Maps = new List<List<GameObject>>();
    WhoseTurn currenTurn = WhoseTurn.player;
    enum WhoseTurn
    {
        player,
        AI
    }

    private void Start()
    {
        for(int i = 0; i < Maps.Count; i++)
        {
            for(int j = 0; j < Maps[i].Count; j++)
            {
                Debug.Log("i:" + i + " j:" + j + " :" + Maps[i][j].transform.position);
            }
        }
    }
}
