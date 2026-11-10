using System.Collections.Generic;
using UnityEngine;

namespace GS
{
    [CreateAssetMenu(fileName = "WaveData", menuName = "Scriptable Objects/WaveData")]
    public class WaveData : ScriptableObject
    {
        [SerializeField] private List<GameObject> _prefabToSpawn;
        [SerializeField] private float _spawnDelay;

        public List<GameObject> PrefabToSpawn => _prefabToSpawn;
        public float SpawnDelay => _spawnDelay;
    }
}