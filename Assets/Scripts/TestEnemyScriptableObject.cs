using UnityEngine;

[CreateAssetMenu(fileName = "TestEnemyScriptableObject", menuName = "ScriptableObjects/TestEnemy")]
public class TestEnemyScriptableObject : ScriptableObject
{
    public int MaxHitPoint{get; private set;} = 50;
    public float speed {get; private set;} = 5f;
}
