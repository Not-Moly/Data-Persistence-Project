using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public string username;
    public string bestScoreUser = "";
    public int bestScorePoints;
    public TextMeshProUGUI BestScoreText;
    private void Awake()
    {
#if UNITY_EDITOR
        Debug.Log(Application.persistentDataPath);
#endif
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start() {
        if(LoadBestScore()){
            BestScoreText.text = BestScoreText.text + ": "+bestScoreUser+": "+bestScorePoints.ToString();
        }else{
            BestScoreText.text = "No Best Score Yet";
        }
    }
    public void ChangeBestScore()
    {

    }
    [System.Serializable]
    class SaveData
    {
        public string user;
        public int score;
    }
    public void SaveBestScore(string name, int points)
    {
        SaveData data = new SaveData();
        data.user = name;
        data.score = points;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public bool LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";


        if (File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScoreUser = data.user;
            bestScorePoints = data.score;
            return true;
        }
        return false;
    }
}
