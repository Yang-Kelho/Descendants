using UnityEngine;

[CreateAssetMenu(fileName = "GridSizeScriptableObject", menuName = "GameSettings/GridSize")]
public class GridSizeScriptableObject : ScriptableObject
{
    public int mapWidth;
    public int mapHeight;
}
