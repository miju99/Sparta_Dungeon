using UnityEngine;

public class JumpObstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) //�÷��̾� �±׿� �浹�ϸ�
        {
            Rigidbody playerRB = collision.gameObject.GetComponent<Rigidbody>(); //�浹�� ������Ʈ(�÷��̾�)�� ������Ʈ�� ������
            if (playerRB != null)
            {
                //playerRB.AddForce(Vector3.up * 20, ForceMode.Impulse); //����!
                Vector3 pace = playerRB.velocity;
                pace.y = 20f; //���鿡�� �浹 �� ���� �޶����� �Ǿ �� �� �����ϰ� �������� �Է�!
                playerRB.velocity = pace;
            }
        }
    }
}
