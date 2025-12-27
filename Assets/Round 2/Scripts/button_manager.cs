using System.Collections;
using System.Threading;
using UnityEngine;

public class button_manager : MonoBehaviour
{
    public Queue_manager queue_Manager;
    public slot_manager slot_Manager;
    public Timer_Manager timer_Manager;
    public Resorce_udation resorce_Udation;
    public enum TroopType
    {
        Labor,
        Technician,
        Researcher,
        Expert
    }
    public TroopType troopType;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void OnMouseDown()
    {
        Debug.Log(troopType.ToString() + " button clicked.");
        int slotIndex = queue_Manager.GetNextAvailableSlotIndex();
        if (slotIndex == -1)
        {
            Debug.LogWarning("No available slot to enqueue!");
            return;
        }
        queue_Manager.Enqueue();
        slot_Manager.ennable_corresponding_image(troopType.ToString().ToUpper(), slotIndex);
        timer_Manager.Timerduration_setter(troopType.ToString(), slotIndex);
        resorce_Udation.UpdateResources(troopType.ToString().ToLower());
    }
}
