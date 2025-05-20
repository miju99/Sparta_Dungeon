using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Player : MonoBehaviour
{

    //플레이어 이동 (WASD)
    //플레이어 점프 (Space)
    //Input System, Rigidbody ForceMode

    public float moveSpeed = 10f; //움직임 속도

    private Rigidbody rb; //Rigidbody 컴포넌트를 스크립트에서 사용하기 위해 저장

    public bool isGround = false; //점프 시 바닥에서만 가능하게

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 force = Vector3.zero; //초기화

        if (Input.GetKey(KeyCode.A)) //왼쪽으로 이동
        {
            force += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S)) //뒤로 이동
        {
            force += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D)) //오른쪽으로 이동
        {
            force += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W)) //앞으로 이동
        {
            force += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.Space) && isGround) //점프 키 입력 및 그라운드 true
        {
            rb.AddForce(0, moveSpeed, 0, ForceMode.Impulse); //점프
            isGround = false; //그라운드 바꿔주기 = 무한 점프 방지
            //Debug.Log("점프");
        }
        if (force != Vector3.zero) //값이 있다면 (키가 눌려지고 있으면)
        {
            force = force.normalized * moveSpeed; //속도 주기 (유지)
            rb.velocity = new Vector3(force.x, rb.velocity.y, force.z); //속도 적용
        }
        else
        {
            rb.velocity = Vector3.zero; //멈춤
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //태그를 비교해 땅과 충돌중인지 판단
        {
            isGround = true;
            //Debug.Log("충돌");
        }
    }
}
