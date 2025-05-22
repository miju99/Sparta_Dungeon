using TreeEditor;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //플레이어 이동 (WASD)
    //플레이어 점프 (Space)
    //Input System, Rigidbody ForceMode

    public float moveSpeed; //움직임 속도
    public float jumpPower; //점프 속도

    public int hp; //플레이어 체력
    public int maxHp;
    public Image hpBar; //플레이어 체력 이미지 (Bar)

    public float st;
    public int maxSt;
    public Image stBar;

    private Rigidbody rb; //Rigidbody 컴포넌트를 스크립트에서 사용하기 위해 저장

    public bool isGround = false; //점프 시 바닥에서만 가능하게
    public bool isJump = false; //점프 오브젝트와 충돌 시 점프하도록

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        hp = maxHp;
        UpdateHpBar();

        st = maxSt;
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

        if (st >= 2 && Input.GetKey(KeyCode.Space) && isGround) //점프 키 입력 및 그라운드 true
        {
            FindObjectOfType<Sound>().PlaySFX("DM-CGS-41");
            //force += Vector3.up * jumpPower; //점프
            rb.AddForce(0, jumpPower, 0, ForceMode.Impulse);
            isGround = false; //그라운드 바꿔주기 = 무한 점프 방지
                              //Debug.Log("점프");
            UpdateSTBar(2);
        }
        if (st >= 5f && isJump)
        {
            rb.AddForce(Vector3.up * 20, ForceMode.Impulse); //크게 점프!
            isJump = false;
            UpdateSTBar(5);
        }

        if (force != Vector3.zero || !isGround) //값이 있다면 (키가 눌려지고 있으면)
        {
            force = force.normalized * moveSpeed; //속도 주기 (유지)
            rb.velocity = new Vector3(force.x, rb.velocity.y, force.z); //속도 적용
        }
        else
        {
            rb.velocity = Vector3.zero; //멈춤
        }
        if (st < maxSt)
        {
            st += Time.deltaTime * 0.5f;
            st = Mathf.Clamp(st, 0, maxSt);
            stBar.fillAmount = (float)st / maxSt;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //태그를 비교해 땅과 충돌중인지 판단
        {
            isGround = true;
            //Debug.Log("충돌");
        }

        if (collision.gameObject.CompareTag("JumpObstacle"))
        {
            foreach (ContactPoint contactPoint in collision.contacts) //충돌 위치(contactPoint) 순회
            {
                if (Vector3.Dot(contactPoint.normal, Vector3.up) > 0.5f) //충돌 위치가 위쪽이라면
                {
                    isJump = true;
                    break;
                }
            }
        }

        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            /*foreach (ContactPoint contact in collision.contacts)
            {
                if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f)
                {*/
            transform.SetParent(null);
        }
    }

    public void TakeDamage(int damage) //데미지를 입으면
    {
        hp -= damage; //피를 깎고
        Debug.Log(damage);

        if (hp < 0)
        {
            hp = 0;
            Debug.Log("체력 0");
        }
        UpdateHpBar(); //체력바 반영
    }

    public void UpdateHpBar() //체력바 변동
    {
        if (hpBar != null)
        {
            hpBar.fillAmount = (float)hp / maxHp; //체력바를 깎음.
        }
    }

    public void UpdateSTBar(int power)
    {
        if (stBar != null)
        {
            st -= power;
            st = Mathf.Clamp(st, 0, maxSt);
            stBar.fillAmount = (float)st / maxSt;
        }
    }
}
