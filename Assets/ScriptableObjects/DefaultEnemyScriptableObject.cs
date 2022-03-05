using UnityEngine;

[CreateAssetMenu(fileName = "DefaultEnemyScriptableObject", menuName = "ScriptableObjects/DefaultEnemy")]
public class DefaultEnemyScriptableObject : ScriptableObject
{
    public int maxHitPoint = 50;
    public float movementSpeed = 5f;
}
