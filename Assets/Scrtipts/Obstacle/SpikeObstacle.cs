using UnityEngine;

public class SpikeObstacle : MonoBehaviour
{
    public int damage = 1;
    public float timer = 0f;
    public float actionNumber = 1f;

    private void OnCollisionStay(Collision collision)
    {
        if (Time.time - timer >= actionNumber)
        {
            timer = Time.time;

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
