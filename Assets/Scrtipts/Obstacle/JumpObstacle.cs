using UnityEngine;

public class JumpObstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) //플레이어 태그와 충돌하면
        {
            Rigidbody playerRB = collision.gameObject.GetComponent<Rigidbody>(); //충돌한 오브젝트(플레이어)의 컴포넌트를 가져옴
            if (playerRB != null)
            {
                //playerRB.AddForce(Vector3.up * 20, ForceMode.Impulse); //점프!
                Vector3 pace = playerRB.velocity;
                pace.y = 20f; //측면에서 충돌 시 값이 달라지게 되어서 그 값 무시하고 점프값만 입력!
                playerRB.velocity = pace;
            }
        }
    }
}
