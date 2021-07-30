using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    class HighScore {
        public string playerName;
        public int score;
    }

    public TMP_InputField nameInput;
    public static GameManager instance;
    public int score;
    public string bestPlayerName;
    public string playerName;
    string saveFile;
    
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        saveFile = Application.persistentDataPath + "/savefile.json";
        LoadState();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        playerName = nameInput.text;
        SceneManager.LoadScene("main");
    }

    public void QuitApplication() {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public string BestScoreText() {
        return "Best Score : " + bestPlayerName + " : " + score;
    }

    void SaveState() {
        HighScore highScore = new HighScore();
        highScore.playerName = bestPlayerName;
        highScore.score = score;
        
        string data = JsonUtility.ToJson(highScore);
        File.WriteAllText(saveFile, data);
    }

    void LoadState() {
        if (File.Exists(saveFile)) {
            string json = File.ReadAllText(saveFile);
            HighScore highScore = JsonUtility.FromJson<HighScore>(json);
            bestPlayerName = highScore.playerName;
            score = highScore.score;
        }
    }

    void OnDestroy() {
        Debug.Log("Save State");
        SaveState();
    }
}
