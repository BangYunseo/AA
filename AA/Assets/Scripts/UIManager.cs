using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI scoreText;
    public int score;
    public TextMeshProUGUI highScoreText;
    public int highscore;
    public Image gameOverImage;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "SampleScene")
        {
            scoreText = GameObject.Find("scoreText")?.GetComponent<TextMeshProUGUI>();
            scoreText.gameObject.SetActive(true);
        }
        else
        {
            scoreText = null;
        }

        score = 0;
        highscore = PlayerPrefs.GetInt("HighScore", 0);

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
}



    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreAdd(int _score) {
        if(scoreText == null)
        {
            return;
        }

        score += _score;
        scoreText.text = score.ToString();
    }

    public void GameOver(){
        gameOverImage.gameObject.SetActive(true);
        if(score > highscore){
            PlayerPrefs.SetInt("HighScore", score);
            highscore = score;
        }
        highScoreText.text = highscore.ToString();
    }

    public void ReturnTitle(){
        SceneManager.LoadScene("GameStartScene");

        Destroy(UIManager.instance.gameObject);
        Destroy(GameManager.instance.gameObject);
    }
}
