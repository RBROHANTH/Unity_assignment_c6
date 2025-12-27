using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class APIExample : MonoBehaviour
{
    public string apiUrl = "https://jsonplaceholder.typicode.com/todos/1";
    
    [System.Serializable]
    public class TodoItem
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;
    }
    
    IEnumerator Start()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        string json = request.downloadHandler.text;
        
        // Deserialize JSON to TodoItem object
        TodoItem todo = JsonUtility.FromJson<TodoItem>(json);
        
        // Access individual fields
        Debug.Log($"User ID: {todo.userId}");
        Debug.Log($"ID: {todo.id}");
        Debug.Log($"Title: {todo.title}");
        Debug.Log($"Completed: {todo.completed}");
    }
}
