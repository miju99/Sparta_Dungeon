using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "New Item")]

public class ItemData : ScriptableObject
{
    public string itemName;
    public string explanation;
    public GameObject dropPrefab;
    public Sprite icon;
}