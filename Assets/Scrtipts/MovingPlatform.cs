using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float time = 0f;

    public GameObject FinishTargetPosition;
    public GameObject StartTargetPosition;
    private Vector3 targetPosition;

    private void Start()
    {
       targetPosition = FinishTargetPosition.transform.position;
    }
    private void Update()
    {
        time += Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 1f * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            targetPosition =
                (targetPosition == FinishTargetPosition.transform.position)
                ? StartTargetPosition.transform.position
                : FinishTargetPosition.transform.position;
        }
    }
}
