using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    [Header("Wander Settings")]
    public float areaSize = 5f;       
    public float speed = 1.5f;        
    public float waitTime = 1f;       

    private Vector3 targetPosition;
    private float waitTimer;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.LookAt(targetPosition);

        // Check if reached target
        if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                PickNewTarget();
                waitTimer = 0;
            }
        }
    }

    void PickNewTarget()
    {
        float randomX = Random.Range(-areaSize, areaSize);
        float randomZ = Random.Range(-areaSize, areaSize);

        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }
}
