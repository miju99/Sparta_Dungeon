using UnityEngine;

public class JumpObstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRB = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRB != null)
            {
                playerRB.AddForce(Vector3.up * 20, ForceMode.Impulse);
            }
        }
    }
}
