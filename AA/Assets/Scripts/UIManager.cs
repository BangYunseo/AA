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
        score = 0;
        scoreText.text = score.ToString();
        highscore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreAdd(int _score) {
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
