using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    private float speed;
    private Vector3[] patrolPoints;
    private int currentPatrolIndex = 0;

    void Start()
    {
        
    }
    void Update()
    {
        // Debug.Log("speed: " + speed+"from Update");
        if (patrolPoints == null || patrolPoints.Length == 0)
            return;
        
        // Keep the enemy's current Y position
        float currentY = transform.position.y;
        Vector3 target = new Vector3(patrolPoints[currentPatrolIndex].x, currentY, patrolPoints[currentPatrolIndex].z);
        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target) < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    
    }
    public void setValues(float speed, Vector3[] patrolPoints)
    {
        this.speed = speed;
        this.patrolPoints = patrolPoints;
        Debug.Log("Enemy speed: " + this.speed + " from setValues");   
    }
}
