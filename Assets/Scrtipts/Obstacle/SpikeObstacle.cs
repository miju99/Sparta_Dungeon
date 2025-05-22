using UnityEngine;

public class SpikeObstacle : MonoBehaviour
{
    public int damage = 1;
    public float timer = 0f;
    public float actionNumber = 1f; //데미지 주는 간격

    private void OnCollisionStay(Collision collision)
    {
        if (Time.time - timer >= actionNumber) //마지막 타격시간을 뺀 값이 간격보다 크면(실행되야 할 간격을 넘었을 때)
        {
            timer = Time.time; //초기화

            if (collision.gameObject.CompareTag("Player"))
            {
                Player player = collision.gameObject.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                    Debug.Log("데미지 들어가는 중");
                }
            }
        }
    }
}
