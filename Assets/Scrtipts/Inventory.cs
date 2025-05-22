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
            ClearSlot(i); //인벤토리 초기화
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

        //1. 마우스 왼쪽버튼으로 클릭하면 아이템 획득
            /*
             
             */

        //2. 인벤토리에서 마우스 왼쪽버튼으로 클릭하면 사용
        //3. 인벤토리는 좌측 상단부터 우측 -> 좌측 하단 -> 우측 하단 순으로 차고
        //4. 인벤토리 사용 순서는 상관없음.
        //5. 인벤토리가 모두 차면 더이상 획득할 수 없음.  
    }

    
    public void AddItem()
    {
        
    }

    void ClearSlot(int slotIndex)
    {
        inventorySlots[slotIndex].sprite = null;
    }
}
