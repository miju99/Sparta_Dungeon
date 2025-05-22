using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public Image[] inventorySlots = new Image[4];
    private GameObject[] items = new GameObject[4];

    private void Start()
    {
        inventory.SetActive(false);

        for(int i = 0; i < inventorySlots.Length; i++)
        {
            ClearSlot(i); //�κ��丮 �ʱ�ȭ
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }

        //1. ���콺 ���ʹ�ư���� Ŭ���ϸ� ������ ȹ��
            /*
             
             */

        //2. �κ��丮���� ���콺 ���ʹ�ư���� Ŭ���ϸ� ���
        //3. �κ��丮�� ���� ��ܺ��� ���� -> ���� �ϴ� -> ���� �ϴ� ������ ����
        //4. �κ��丮 ��� ������ �������.
        //5. �κ��丮�� ��� ���� ���̻� ȹ���� �� ����.  
    }

    
    public void AddItem()
    {
        
    }

    void ClearSlot(int slotIndex)
    {
        inventorySlots[slotIndex].sprite = null;
    }
}
