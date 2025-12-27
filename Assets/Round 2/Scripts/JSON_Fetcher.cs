using UnityEngine;

public class JSON_Fetcher : MonoBehaviour
{
    public JSON_Data_allocator json_Data_Allocator;
   
    [System.Serializable]
    public class Resources {
        public int energy;
        public int food;
        public int minerals;
    }

    [System.Serializable]
    public class Personel {
        public int labor;
        public int technician;
        public int researcher;
        public int expert;
    }

    [System.Serializable]
    public class Training {
        public int capacity;
        public Personel personel;
    }

    [System.Serializable]
    public class CostDetail {
        public int energy;
        public int mineral;
        public int time;
    }

    [System.Serializable]
    public class Cost {
        public CostDetail labor;
        public CostDetail technician;
        public CostDetail researcher;
        public CostDetail expert;
    }

    [System.Serializable]
    public class RootObject {
        public Resources resources;
        public Training training;
        public Cost cost;
    }

    public class JSONReader {
        public static RootObject ReadJSONFromString(string json)
        {
            return JsonUtility.FromJson<RootObject>(json);
        }
        public static RootObject ReadJSONFromURL(string url)
        {
            using (var www = new UnityEngine.Networking.UnityWebRequest(url))
            {
                www.downloadHandler = new UnityEngine.Networking.DownloadHandlerBuffer();
                var asyncOp = www.SendWebRequest();
                while (!asyncOp.isDone) { }
                if (www.result == UnityEngine.Networking.UnityWebRequest.Result.Success)
                {
                    return ReadJSONFromString(www.downloadHandler.text);
                }
                else
                {
                    Debug.LogError("Failed to fetch JSON: " + www.error);
                    return null;
                }
            }
        }
    }
    public string jsonURL = "https://deepsim-assignment.free.beeceptor.com/training";
    public RootObject jsonData;
    public string jsonString;
    void Start()
    {
        jsonData = JSONReader.ReadJSONFromURL(jsonURL);
        jsonString = JsonUtility.ToJson(jsonData, true);
        Debug.Log(JsonUtility.ToJson(jsonData));
        Debug.Log(jsonString);
        Debug.Log("Energy Resource: " + jsonData.resources.energy);
        json_Data_Allocator.Data_Allocator(jsonData);
    }

    
    void Update()
    {
        
    }
}
