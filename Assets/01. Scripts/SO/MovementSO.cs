using UnityEngine;

[CreateAssetMenu(menuName = "SO/MovementSO")]
public class MovementSO : ScriptableObject
{
    [Range(0, 100f)] public float inAccel;
    [Range(0, 100f)] public float deAccel;
    [Range(0f, 100f)] public float maxSpeed;
    public float jumpSpeed = 10f;
}
