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
    BUFF, //HP 증가
    NONE, //아무것도 없음
    DEBUFF, //속도 저하
    SLEEP //낮 -> 밤, HP 회복
}