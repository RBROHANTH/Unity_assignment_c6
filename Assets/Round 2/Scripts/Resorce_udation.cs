using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Resorce_udation : MonoBehaviour
{
    public TextMeshProUGUI energy_text;
    public TextMeshProUGUI mineral_text;
    public JSON_Data_allocator json_Data_Allocator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateResources(string troopType)
    {
        switch (troopType)
        {
            case "labor":
                energy_text.text = (int.Parse(energy_text.text) - json_Data_Allocator.jsonData.cost.labor.energy).ToString();
                mineral_text.text = (int.Parse(mineral_text.text) - json_Data_Allocator.jsonData.cost.labor.mineral).ToString();
                break;
            case "technician":
                energy_text.text = (int.Parse(energy_text.text) - json_Data_Allocator.jsonData.cost.technician.energy).ToString();
                mineral_text.text = (int.Parse(mineral_text.text) - json_Data_Allocator.jsonData.cost.technician.mineral).ToString();
                break;
            case "researcher":
                 energy_text.text = (int.Parse(energy_text.text) - json_Data_Allocator.jsonData.cost.researcher.energy).ToString();
                mineral_text.text = (int.Parse(mineral_text.text) - json_Data_Allocator.jsonData.cost.researcher.mineral).ToString();
                break;
            case "expert":
                energy_text.text = (int.Parse(energy_text.text) - json_Data_Allocator.jsonData.cost.expert.energy).ToString();
                mineral_text.text = (int.Parse(mineral_text.text) - json_Data_Allocator.jsonData.cost.expert.mineral).ToString();
                break;
            default:
                Debug.LogWarning("Unknown troop type: " + troopType);
                break;
        }
    }
}
