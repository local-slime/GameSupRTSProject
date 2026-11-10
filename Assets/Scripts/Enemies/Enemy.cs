using UnityEngine;
using UnityEngine.UI;

namespace GS
{
    [RequireComponent(typeof(WayPointFollower))]
    public class Enemy : MonoBehaviour
    {
        #region SerializeFields
        [SerializeField] private EnemyData _enemyData;
        [SerializeField] private Image _healthBarImage;
        #endregion

        // Health
        private int _currentHealthPoint = 0;

        private WayPointFollower _wayPointFollower;

        private void Awake()
        {
            _currentHealthPoint = _enemyData.InitialHealthPoint;
            _wayPointFollower = GetComponent<WayPointFollower>();
            _wayPointFollower.SetEnemyData(_enemyData);

            UpdateHealthBarUI();
        }

        private void Update()
        {

        }

        public void SetPath(WaypointPath waypointPath)
        {
            _wayPointFollower.SetPath(waypointPath);
        }

        public virtual void TakeDamage(int damage)
        {
            _currentHealthPoint -= damage;

            UpdateHealthBarUI();

            if (_currentHealthPoint <= 0)
            {
                Die();
            }
        }

        private void UpdateHealthBarUI()
        {
            _healthBarImage.fillAmount = _currentHealthPoint / (float)_enemyData.InitialHealthPoint;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
