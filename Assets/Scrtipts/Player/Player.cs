using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //�÷��̾� �̵� (WASD)
    //�÷��̾� ���� (Space)
    //Input System, Rigidbody ForceMode

    public float moveSpeed ; //������ �ӵ�
    public float jumpPower; //���� �ӵ�

    public int hp; //�÷��̾� ü��
    public int maxHp;
    public Image hpBar; //�÷��̾� ü�� �̹��� (Bar)

    private Rigidbody rb; //Rigidbody ������Ʈ�� ��ũ��Ʈ���� ����ϱ� ���� ����

    public bool isGround = false; //���� �� �ٴڿ����� �����ϰ�
    public bool isJump = false; //���� ������Ʈ�� �浹 �� �����ϵ���

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
            rb.AddForce(0, jumpPower, 0, ForceMode.Impulse);
            isGround = false; //�׶��� �ٲ��ֱ� = ���� ���� ����
            //Debug.Log("����");
        }
        if (isJump)
        {
            rb.AddForce(Vector3.up * 20, ForceMode.Impulse); //ũ�� ����!
            isJump = false;
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

        if (collision.gameObject.CompareTag("JumpObstacle"))
        {
            foreach (ContactPoint contactPoint in collision.contacts) //�浹 ��ġ(contactPoint) ��ȸ
            {
                if (Vector3.Dot(contactPoint.normal, Vector3.up) > 0.5f) //�浹 ��ġ�� �����̶��
                {
                    isJump = true;
                    break;
                }
            }
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
