using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    public string playerName;
    public string highScorePlayerName;
    public int highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        LoadPlayerData();
        
    }

    public void SetPlayerName(string playerName)
    {
        this.playerName = playerName;
        Debug.Log(this.playerName);
    }

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highScore;
    }

    public void SetHighscore(int points)
    {
        highScorePlayerName = playerName;
        highScore = points;
    }
    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.highScorePlayerName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        Debug.Log("save data: " + json);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("load data: " + json);
            highScorePlayerName = data.highScorePlayerName;
            highScore = data.highScore;
        }
    }
}
