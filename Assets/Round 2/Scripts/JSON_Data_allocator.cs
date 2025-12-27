using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.ShaderGraph.Serialization;
public class JSON_Data_allocator : MonoBehaviour
{
    public  TextMeshProUGUI energy_text;
    public  TextMeshProUGUI food_text;  
    public  TextMeshProUGUI mineral_text;
    public TextMeshProUGUI labor_text;
    public TextMeshProUGUI technician_text;
    public TextMeshProUGUI researcher_text;
    public TextMeshProUGUI expert_text;
    public TextMeshProUGUI training_capacity_text;
    public TextMeshProUGUI Total_units_text;
    public TextMeshProUGUI labor_cost_energy_text;
    public TextMeshProUGUI labor_cost_mineral_text;
    public TextMeshProUGUI technician_cost_energy_text;
    public TextMeshProUGUI technician_cost_mineral_text;
    public TextMeshProUGUI researcher_cost_energy_text;
    public TextMeshProUGUI researcher_cost_mineral_text;
    public TextMeshProUGUI expert_cost_energy_text;
    public TextMeshProUGUI expert_cost_mineral_text;
    public JSON_Fetcher.RootObject jsonData;
    void Start()
    {
      
    }
    void Update()
    {
        
    }
    public void Data_Allocator(JSON_Fetcher.RootObject jsonData)
    {
        this.jsonData = jsonData;
        energy_text.text = jsonData.resources.energy.ToString();
        food_text.text = jsonData.resources.food.ToString();
        mineral_text.text = jsonData.resources.minerals.ToString();
        labor_text.text = jsonData.training.personel.labor.ToString();
        technician_text.text = jsonData.training.personel.technician.ToString();
        researcher_text.text = jsonData.training.personel.researcher.ToString();
        expert_text.text = jsonData.training.personel.expert.ToString();
        training_capacity_text.text = jsonData.training.capacity.ToString();
        int total_units = jsonData.training.personel.labor + jsonData.training.personel.technician + jsonData.training.personel.researcher + jsonData.training.personel.expert;
        Total_units_text.text = total_units.ToString();
        labor_cost_energy_text.text = jsonData.cost.labor.energy.ToString();
        labor_cost_mineral_text.text = jsonData.cost.labor.mineral.ToString();
        technician_cost_energy_text.text = jsonData.cost.technician.energy.ToString();
        technician_cost_mineral_text.text = jsonData.cost.technician.mineral.ToString();
        researcher_cost_energy_text.text = jsonData.cost.researcher.energy.ToString();
        researcher_cost_mineral_text.text = jsonData.cost.researcher.mineral.ToString();
        expert_cost_energy_text.text = jsonData.cost.expert.energy.ToString();
        expert_cost_mineral_text.text = jsonData.cost.expert.mineral.ToString();

    }
}
