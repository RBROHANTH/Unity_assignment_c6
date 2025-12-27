using UnityEngine;

public class slot_manager : MonoBehaviour{
    public Queue_manager queue_Manager;

    public slot_status[] slot_Status;
    public GameObject[] slots;

    void Start()
    {
        slot_Status = GetComponentsInChildren<slot_status>();
        Vaccateslot();
    }

    void Update()
    {
        
    }
    public int GetAvailableSlotIndex()
    {
        for (int i = 0; i < slot_Status.Length; i++)
        {
            if (!slot_Status[i].isOccupied)
            {
                return i; // Return the index of the first available slot
            }
        }
        return -1; // Return -1 if no slots are available
    }
    public void OccupySlot(int index)
    {
        if (index >= 0 && index < slot_Status.Length && !slot_Status[index].isOccupied)
        {
            slot_Status[index].isOccupied = true;
        }
    
    }
    public void ennable_corresponding_image(string tagname,int index)
    {
      Transform child = GetChildWithTag(slots[index].transform, tagname);
      if (child != null)
      {
        child.gameObject.SetActive(true);
        OccupySlot(index);
      }
        Transform child1 = GetChildWithTag(slots[index].transform, "ring");   
        if (child1 != null)
        {
            child1.gameObject.SetActive(false);
        }
    }
public void disable_corresponding_image(int index,string troopType)
    {
            Transform child = GetChildWithTag(slots[index].transform, troopType.ToUpper());
            if (child != null)
            {
                child.gameObject.SetActive(false);
                slot_Status[index].isOccupied = false;
                if (queue_Manager != null)
                {
                        queue_Manager.Dequeue();
                }
            }
            Transform child1 = GetChildWithTag(slots[index].transform, "ring");   
            if (child1 != null)
            {   
                    child1.gameObject.SetActive(true);
            }
    }
public void Vaccateslot()
    {
        for (int j = 0; j < slots.Length; j++)
        {
        Transform child = GetChildWithTag(slots[j].transform, "ring");
        if (child != null)
        {
            child.gameObject.SetActive(true);
        }
        }
    }
    Transform GetChildWithTag(Transform parent, string tag)
{
    foreach (Transform child in parent)
    {
        if (child.CompareTag(tag))
            return child;
    }
    return null;

}
}