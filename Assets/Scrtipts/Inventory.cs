using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public Image inventortySlot1;
    public Image inventortySlot2;
    public Image inventortySlot3;
    public Image inventortySlot4;

    private bool itemSelect = false; //슬롯 중복 방지

    private void Start()
    {
        inventory.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.I))
        {
            inventory.SetActive(true);
        }
        if (itemSelect = false && Interaction.selectObject != null)
        {
            Item item = Interaction.selectObject.GetComponent<Item>();

            if (item != null && item.ItemData != null)
            {
                inventortySlot1.sprite = item.ItemData.icon;
                inventortySlot1.enabled = true;
                Debug.Log("일단 확인");

                itemSelect = true;
            }
        }

        else
        {
            inventory.SetActive(false);
        }
    }
}
