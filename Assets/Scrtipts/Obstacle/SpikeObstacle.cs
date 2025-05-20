using UnityEngine;

public class SpikeObstacle : MonoBehaviour
{

    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if(player != null)
            {
                player.TakeDamage(damage);
                Debug.Log("데미지 들어가는 중");
            }
        }
    }
}
