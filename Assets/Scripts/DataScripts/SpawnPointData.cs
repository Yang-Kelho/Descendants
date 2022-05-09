using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnPointData", menuName = "SpawnPointData")]
public class SpawnPointData : ScriptableObject
{
    public int[,] ScoreMap;
    public int[,] TypeMap;
}
