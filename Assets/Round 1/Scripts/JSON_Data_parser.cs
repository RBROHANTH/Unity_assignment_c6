using UnityEngine;

public class JSON_Data_parser : MonoBehaviour
{
    public TextAsset givenJSONFile;

    [System.Serializable]
    public class JsonData
    {
        public string levelName;
        public int timerSeconds;
        public int goalScore;
        public Position playerStart;
        public Coin[] coins;
        public Enemy[] enemies;
        public Ground ground;
    }

    [System.Serializable]
    public class Position
    {
        public float x;
        public float y;
        public float z;
    }

    [System.Serializable]
    public class Coin
    {
        public float x;
        public float z;
    }

    [System.Serializable]
    public class Enemy
    {
        public float x;
        public float z;
        public float speed;
        public Position[] patrol;
    }

    [System.Serializable]
    public class Ground
    {
        public float width;
        public float length;
    }
}
