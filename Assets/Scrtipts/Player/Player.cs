using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //�÷��̾� �̵� (WASD)
    //�÷��̾� ���� (Space)
    //Input System, Rigidbody ForceMode

    public float moveSpeed = 10f; //������ �ӵ�
    public float jumpPower = 5f; //���� �ӵ�

    public int hp = 10; //�÷��̾� ü��
    public int maxHp = 10;
    public Image hpBar; //�÷��̾� ü�� �̹��� (Bar)

    private Rigidbody rb; //Rigidbody ������Ʈ�� ��ũ��Ʈ���� ����ϱ� ���� ����

    public bool isGround = false; //���� �� �ٴڿ����� �����ϰ�

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        hp = maxHp;
        UpdateHpBar();
    }

    private void FixedUpdate()
    {
        Vector3 force = Vector3.zero; //�ʱ�ȭ

        if (Input.GetKey(KeyCode.A)) //�������� �̵�
        {
            force += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S)) //�ڷ� �̵�
        {
            force += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D)) //���������� �̵�
        {
            force += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W)) //������ �̵�
        {
            force += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.Space) && isGround) //���� Ű �Է� �� �׶��� true
        {
            //force += Vector3.up * jumpPower; //����
            rb.AddForce(0, moveSpeed, 0, ForceMode.Impulse);
            isGround = false; //�׶��� �ٲ��ֱ� = ���� ���� ����
            //Debug.Log("����");
        }
        if (force != Vector3.zero || !isGround) //���� �ִٸ� (Ű�� �������� ������)
        {
            force = force.normalized * moveSpeed; //�ӵ� �ֱ� (����)
            rb.velocity = new Vector3(force.x, rb.velocity.y, force.z); //�ӵ� ����
        }
        else
        {
            rb.velocity = Vector3.zero; //����
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //�±׸� ���� ���� �浹������ �Ǵ�
        {
            isGround = true;
            //Debug.Log("�浹");
        }
    }

    public void TakeDamage(int damage) //�������� ������
    {
        hp -= damage; //�Ǹ� ���
        Debug.Log(damage);

        if(hp < 0)
        {
            hp = 0;
            Debug.Log("ü�� 0");
        }
        UpdateHpBar(); //ü�¹� �ݿ�
    }

    public void UpdateHpBar() //ü�¹� ����
    {
        if(hpBar != null)
        {
            hpBar.fillAmount = (float)hp / maxHp; //ü�¹ٸ� ����.
        }
    }
}
