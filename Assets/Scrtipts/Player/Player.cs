using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Player : MonoBehaviour
{

    //�÷��̾� �̵� (WASD)
    //�÷��̾� ���� (Space)
    //Input System, Rigidbody ForceMode

    public float moveSpeed = 10f; //������ �ӵ�

    private Rigidbody rb; //Rigidbody ������Ʈ�� ��ũ��Ʈ���� ����ϱ� ���� ����

    public bool isGround = false; //���� �� �ٴڿ����� �����ϰ�

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
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
            rb.AddForce(0, moveSpeed, 0, ForceMode.Impulse); //����
            isGround = false; //�׶��� �ٲ��ֱ� = ���� ���� ����
            //Debug.Log("����");
        }
        if (force != Vector3.zero) //���� �ִٸ� (Ű�� �������� ������)
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
}
