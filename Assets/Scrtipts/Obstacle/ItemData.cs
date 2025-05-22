using UnityEngine;

[CreateAssetMenu(menuName = "New Item")]

public class ItemData : ScriptableObject
{
    public string itemName;
    public string explanation;
    public GameObject dropPrefab;
    public Sprite icon;
    public ItemType type;
}
public enum ItemType
{
    BUFF,
    NONE,
    DEBUFF,
    SLEEP
}