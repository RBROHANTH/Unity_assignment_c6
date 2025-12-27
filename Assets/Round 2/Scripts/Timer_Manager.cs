using UnityEngine;
using TMPro;
using System.Collections;

public class Timer_Manager : MonoBehaviour
{
    public TextMeshProUGUI[] timerText;
    public slot_manager slot_Manager;
    public JSON_Data_allocator jSON_Data_Allocator;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void Timerduration_setter(string troopType, int slotIndex)
    {
        Debug.Log($"[Timerduration_setter] troopType: {troopType}, slotIndex: {slotIndex}, timerTextName: {(timerText != null && slotIndex >= 0 && slotIndex < timerText.Length ? timerText[slotIndex].name : "OUT_OF_BOUNDS")}");
        
        float duration = 0f;
        switch (troopType.ToLower())
        {
            case "labor":
                duration = jSON_Data_Allocator.jsonData.cost.labor.time;
                break;
            case "technician":
                duration = jSON_Data_Allocator.jsonData.cost.technician.time;
                break;
            case "researcher":
                duration = jSON_Data_Allocator.jsonData.cost.researcher.time;
                break;
            case "expert":
                duration = jSON_Data_Allocator.jsonData.cost.expert.time;
                break;
            default:
                Debug.LogError("Invalid troop type: " + troopType);
                break;
        }
        
        timerText[slotIndex].text = duration.ToString("F0") + "s";
        // Pass troopType directly to the coroutine
        StartCoroutine(StartTimer(slotIndex, duration, troopType));
    }
    
    private IEnumerator StartTimer(int slotIndex, float duration, string troopType)
    {
        float remainingTime = duration;
        while (remainingTime > 0)
        {
            timerText[slotIndex].text = remainingTime.ToString("F0") + "s";
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }
        
        timerText[slotIndex].text = "0s";
        Debug.Log($"[StartTimer] Timer completed for slot {slotIndex}, troopType: {troopType}");
        slot_Manager.disable_corresponding_image(slotIndex, troopType);
    }
}

// using UnityEngine;
// using TMPro;
// using System.Collections;
// public class Timer_Manager : MonoBehaviour
// {
//     // Remove global timerDuration; use per-slot duration instead
//     public TextMeshProUGUI[] timerText;
//     public slot_manager slot_Manager;
//     public JSON_Data_allocator jSON_Data_Allocator;
//     string trooptype;
//    void Start()
//     {
        
//     }

//     void Update()
//     {
        
//     }
//     public void Timerduration_setter(string troopType, int slotIndex)
//     {
//         this.trooptype = troopType;
//         Debug.Log($"[Timerduration_setter] troopType: {troopType}, slotIndex: {slotIndex}, timerTextName: {(timerText != null && slotIndex >= 0 && slotIndex < timerText.Length ? timerText[slotIndex].name : "OUT_OF_BOUNDS")}");
//         float duration = 0f;
//         switch (troopType.ToLower())
//         {
//             case "labor":
//                 duration = jSON_Data_Allocator.jsonData.cost.labor.time;
//                 break;
//             case "technician":
//                 duration = jSON_Data_Allocator.jsonData.cost.technician.time;
//                 break;
//             case "researcher":
//                 duration = jSON_Data_Allocator.jsonData.cost.researcher.time;
//                 break;
//             case "expert":
//                 duration = jSON_Data_Allocator.jsonData.cost.expert.time;
//                 break;
//             default:
//                 Debug.LogError("Invalid troop type: " + troopType);
//                 break;
//         }
//         timerText[slotIndex].text = duration.ToString("F0") + "s";
//         StartCoroutine(StartTimer(slotIndex, duration));
//     }
//     private IEnumerator StartTimer(int slotIndex, float duration)
//     {
//         float remainingTime = duration;
//         while (remainingTime > 0)
//         {
//             timerText[slotIndex].text = remainingTime.ToString("F0") + "s";
//             yield return new WaitForSeconds(1f);
//             remainingTime--;
//         }
//         timerText[slotIndex].text = "0s";
//         slot_Manager.disable_corresponding_image(slotIndex,trooptype);
//     }
// }
