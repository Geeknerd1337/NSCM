using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "AI/Enemy")]
public class EnemyStats : ScriptableObject
{
    public float moveSpeed;
    public float searchRadius;
    public Vector2 fireCooldown;
    public Vector2 stoppingDistance;
}
