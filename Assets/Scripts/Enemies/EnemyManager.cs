using System.Collections;
using UnityEngine;

namespace GS
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private WaypointPath[] _path;
        [SerializeField] private GameObject _prefabEnemy;
        [SerializeField] private WaveData _waveData;

        private WaitForSeconds _waitForSeconds;

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_waveData.SpawnDelay);
            StartCoroutine(SpawnEnemiesCoroutine());
        }

        private IEnumerator SpawnEnemiesCoroutine()
        {
            for (int i = 0, l = _waveData.PrefabToSpawn.Count; i < l; i++)
            {
                GameObject instanceEnemy = Instantiate(_waveData.PrefabToSpawn[i], Vector3.zero, Quaternion.identity);
                Enemy enemy = instanceEnemy.GetComponent<Enemy>();

                // Set random path
                int randomIndex = Random.Range(0, _path.Length);
                enemy.SetPath(_path[randomIndex]);
                yield return _waitForSeconds;
            }
            _waitForSeconds = null;
        }
    }
}
