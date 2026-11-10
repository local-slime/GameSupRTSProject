using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData", menuName ="ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    #region SERIALIZE
    [Header("Infos")]
    [SerializeField] private string _enemyName;
    [SerializeField, TextArea(1, 5)] private string _enemyDescription;

    [Header("Health")]
    [SerializeField] private int _initialHealthPoint;

    [Header("Movement")]
    [SerializeField]
    [Tooltip("Base speed when moving, must be a positive value")]
    [Min(0)]
    private float _speed;
    [SerializeField]
    [Tooltip("Distance to waypoint to change next way point"), Range(0, 5)]
    private float _distanceToStop;
    #endregion

    public int InitialHealthPoint => _initialHealthPoint;
    public float Speed => _speed;
    public float DistanceToStop => _distanceToStop;
}
