using UnityEngine;

namespace GS
{
    public class WayPointFollower : MonoBehaviour
    {
        private const int FIRST_WAYPOINT_INDEX = 0;

        private EnemyData _enemyData;
        [SerializeField] private WaypointPath _waypointPath;

        // Waypoints
        private int _nextWayPointIndex;
        private int _waypointCount;

        private void Start()
        {
            // Set position at path start
            WayPoint firstWayPoint = _waypointPath.GetWayPoint(FIRST_WAYPOINT_INDEX);
            transform.position = firstWayPoint.transform.position;

            // Setup data
            _nextWayPointIndex = FIRST_WAYPOINT_INDEX + 1;
            _waypointCount = _waypointPath.GetWaypointCount();
        }

        public void SetEnemyData(EnemyData enemyData) => _enemyData = enemyData;

        private void Update()
        {
            Vector3 nextWaypointPosition = _waypointPath.GetWayPoint(_nextWayPointIndex).transform.position;

            MoveAtNextWayPoint(nextWaypointPosition);

            if (IsAtWaypoint(nextWaypointPosition))
            {
                _nextWayPointIndex++;
            }

            // If path is over
            if (_nextWayPointIndex >= _waypointCount)
            {
                Destroy(this.gameObject);
            }
        }

        private void MoveAtNextWayPoint(Vector3 nextWaypointPosition)
        {
            Vector3 direction = nextWaypointPosition - transform.position;
            Vector3 normalizedDirection = direction.normalized;
            transform.position += normalizedDirection * (_enemyData.Speed * Time.deltaTime);
        }

        private bool IsAtWaypoint(Vector3 nextWaypointPosition)
        {
            Vector2 selfPosition = new Vector2(transform.position.x, transform.position.z);
            Vector2 wayPointPosition = new Vector2(nextWaypointPosition.x, nextWaypointPosition.z);

            return Vector2.Distance(selfPosition, wayPointPosition) < _enemyData.DistanceToStop;
        }

        public void SetPath(WaypointPath waypointPath)
        {
            _waypointPath = waypointPath;
        }
    }
}
