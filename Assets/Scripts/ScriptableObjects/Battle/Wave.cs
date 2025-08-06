using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWave", menuName = "Battle/NewWave")]
public class Wave : ScriptableObject
{
    public struct Enemy
    {
        public GameObject EnemyObject;
        public Vector3 Position;
    }

    public List<Enemy> Enemies = new();
}

