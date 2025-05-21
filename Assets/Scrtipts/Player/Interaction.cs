using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            Debug.LogError("ī�޶� Null");
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
            if (hit.collider.CompareTag("Object")) //�±װ� ������Ʈ �� ������Ʈ�鸸
            {
                Debug.Log("�浹 " + hit.collider.name);

                //UI ǥ��
                Item item = hit.collider.GetComponent<Item>();
                if (item != null && item.ItemData != null)
                {
                    Debug.Log("������ �̸� : " + item.ItemData.itemName);

                    itemNameText.text = item.ItemData.itemName;
                    itemDescribeText.text = item.ItemData.explanation;
                    Explanation.SetActive(true);

                    if (Input.GetMouseButton(0))
                    {
                        selectObject = hit.collider.gameObject;
                        Debug.Log(selectObject.name);
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
}
