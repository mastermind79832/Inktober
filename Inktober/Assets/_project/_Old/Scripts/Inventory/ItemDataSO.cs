using UnityEngine;

public enum ItemName
{
    Journal,
    Backpack,
    Brush,
}

[CreateAssetMenu(fileName = "ItemDataSO", menuName = "Scriptable Objects/ItemDataSO")]

public class ItemDataSO : ScriptableObject
{
    public ItemName ItemName;
    public string Description;
    public Sprite Sprite;
}
