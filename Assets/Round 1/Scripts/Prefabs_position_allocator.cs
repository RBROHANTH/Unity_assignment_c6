using UnityEngine;
using TMPro;

public class Prefabs_position_allocator : MonoBehaviour
{
 public GameObject Ground;
 JSON_Data_parser.JsonData jsonData;
 public TextAsset givenJSONFile;
 public TextMeshProUGUI LevelNameText;
 public TextMeshProUGUI Timer;
  public TextMeshProUGUI GoalScore;
  public GameObject player;
  public GameObject coinPrefab;
  public GameObject enemyPrefab;
  public Game_Manager gameManager;
    void Start()
    {
        jsonData = JsonUtility.FromJson<JSON_Data_parser.JsonData>(givenJSONFile.text);
        InitializingEnemies();
        ApplyScale();
        ApplyPlayerStart();
        InitializingCoins();
        gameManager.GoalScore = jsonData.goalScore;
        LevelNameText.text = jsonData.levelName;
        Timer.text = "Time: " + jsonData.timerSeconds.ToString() + "s";
        GoalScore.text = "Goal: " + jsonData.goalScore.ToString();
    }
    void ApplyScale()
    {
        
        Ground.transform.localScale = new Vector3(
            jsonData.ground.width,
            1,
            jsonData.ground.length
        );
        Ground.transform.position = new Vector3(0,-2,0);  
        Debug.Log("Ground scaled to: " + Ground.transform.localScale);
    }
    void ApplyPlayerStart()
    {
        player.transform.position = new Vector3(
            jsonData.playerStart.x,
            jsonData.playerStart.y,
            jsonData.playerStart.z
        );
        player.GetComponent<Player_Movement>().moveSpeed = 1f;
        Debug.Log("Player positioned at: " + player.transform.position);
    }
    void InitializingCoins()
    {
        foreach (var coin in jsonData.coins)
        {
            Instantiate(coinPrefab, new Vector3(coin.x, 1, coin.z), Quaternion.identity);
        }
    }
    void InitializingEnemies()
    {
        foreach (var enemy in jsonData.enemies)
        {
            GameObject enemyInstance = Instantiate(enemyPrefab, new Vector3(enemy.x, 1, enemy.z), Quaternion.identity);
            enemyInstance.GetComponent<Enemy_Movement>().setValues(
                enemy.speed,
                new Vector3[] {
                    new Vector3(enemy.patrol[0].x, enemy.patrol[0].y, enemy.patrol[0].z),
                    new Vector3(enemy.patrol[1].x, enemy.patrol[1].y, enemy.patrol[1].z)
                }
            );
            Debug.Log("got the Enemy prefab and set its values");
        }
    }

}