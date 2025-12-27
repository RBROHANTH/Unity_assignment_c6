using UnityEngine;
using System.Collections;
public class Player_Movement : MonoBehaviour
{
    public float moveSpeed;
    public Game_Manager gameManager;
    
    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        
        if (movement.magnitude > 0)
        {
            transform.Translate(movement.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            gameManager.IncreaseScore(1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Player hit by enemy!");
            Debug.Log("Final Score: " + gameManager.Score);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            gameManager.IncreaseScore(1);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Player hit by enemy!");
            Debug.Log("Final Score: " + gameManager.Score);
        }
    }

}
