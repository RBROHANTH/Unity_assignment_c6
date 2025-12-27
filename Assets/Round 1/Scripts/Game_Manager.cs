using UnityEngine;
using TMPro;
public class Game_Manager : MonoBehaviour
{
    public int Score;
    public int GoalScore;
    public TextMeshProUGUI ScoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + Score.ToString();
        if (Score >= GoalScore)
        {
            Debug.Log("Level Complete!");
        }
        
    }
    public void IncreaseScore(int amount)
    {
        Score += amount;
        Debug.Log("Score: " + Score);
    }
}
