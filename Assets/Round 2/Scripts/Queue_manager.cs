
using UnityEngine;
using TMPro;
public class Queue_manager : MonoBehaviour{
    // Returns the next available slot index (0-based), or -1 if full
    public int GetNextAvailableSlotIndex()
    {
        if (currentcapacity < maxcapacity)
            return currentcapacity;
        else
            return -1;
    }
    public int maxcapacity = 5;
    public int currentcapacity = 0;
    public TextMeshProUGUI capacity_text;
    // Call this when a slot is vacated to allow reuse
    public void Dequeue()
    {
        if (currentcapacity > 0)
        {
            currentcapacity--;
            capacity_text.text = currentcapacity.ToString() + "/" + maxcapacity.ToString();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enqueue()
    {
        if (currentcapacity < maxcapacity)
        {
            currentcapacity++;
            Debug.Log("Enqueued! Current Capacity: " + currentcapacity);
            capacity_text.text = currentcapacity.ToString()+"/"+ maxcapacity.ToString();
        }
        else
        {
            Debug.Log("Queue is full! Cannot enqueue.");
        }
    }

}