using UnityEngine;
using TMPro;
using System.Collections;

public class Interaction : MonoBehaviour
{
    private UnityEngine.Camera mCamera;

    [Header("Info")]
    public string displayName;
    public string descrption;

    public GameObject Explanation;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemDescribeText;

    public static GameObject selectObject;

    private void Start()
    {
        Explanation.SetActive(false);

        mCamera = GetComponentInChildren<UnityEngine.Camera>();

        if(mCamera == null)
        {
            Debug.LogError("카메라 Null");
        }
    }
    private void Update()
    {
        if (mCamera == null)
        {
            return;
        }

        Ray ray = mCamera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Object")) //태그가 오브젝트인 오브젝트들만
            {
                Debug.Log("충돌 " + hit.collider.name);

                //UI 표시
                Item item = hit.collider.GetComponent<Item>();
                if (item != null && item.ItemData != null)
                {
                    Debug.Log("아이템 이름 : " + item.ItemData.itemName);

                    itemNameText.text = item.ItemData.itemName;
                    itemDescribeText.text = item.ItemData.explanation;
                    Explanation.SetActive(true);

                    if (Input.GetMouseButton(0))
                    {
                        selectObject = hit.collider.gameObject;
                        Debug.Log(selectObject.name);

                        Player player = GetComponent<Player>();

                        if (item.ItemData.type == ItemType.BUFF)
                        {
                            if(player != null)
                            {
                                player.hp += 2;
                                if(player.hp > player.maxHp)
                                {
                                    player.hp = player.maxHp;
                                }

                                player.UpdateHpBar();
                                Debug.Log("HP 회복");

                                Destroy(selectObject);
                                selectObject = null;
                            }
                        }
                        if(item.ItemData.type == ItemType.DEBUFF)
                        {
                            DebuffPotion(5, 3f);
                            Debug.Log("Speed 감소");

                            Destroy(selectObject);
                            selectObject = null;
                        }
                    }
                }
            }
            else if (!hit.collider.CompareTag("Object"))
            {
                Explanation.SetActive(false);
            }
        }
        else
        {
            Explanation.SetActive(false);
        }
    }

    private void DebuffPotion(float power, float minute)
    {
        StartCoroutine(DebuffMoveSpeed(power, minute));
    }
    private IEnumerator DebuffMoveSpeed(float power, float minute)
    {
        Player player = GetComponent<Player>();
        float originSpeed = player.moveSpeed;

        player.moveSpeed -= power;
        Debug.Log("디버프 속도 : " + player.moveSpeed);
        yield return new WaitForSeconds(minute);
        player.moveSpeed = originSpeed;
        Debug.Log("기존 속도 : " + player.moveSpeed);
    }
}
