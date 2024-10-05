using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public bool isGameOver = false;

    [SerializeField]
    private TextMeshProUGUI textGoal;
    public int goal;

    [SerializeField]
    private GameObject btnRetry;

    [SerializeField]
    private Color green;

    [SerializeField]
    private Color red;

    public Text highScoreText;
    public int highScore;
    public Image gameOverImage;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        textGoal.SetText(goal.ToString());
        // highScoreText = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseGoal() {
        goal -= 1;
        textGoal.SetText(goal.ToString());
        
        UIManager.instance.ScoreAdd(10);

        if(goal <= 0) {
            SetGameOver(true);
        }
    }

    public void SetGameOver(bool success) {
        if (isGameOver == false) {
            isGameOver = true;
            Camera.main.backgroundColor = success ? green : red;
            Invoke("ShowRetryButton", 1f);
        }
    }

    public void ShowRetryButton() {
        btnRetry.SetActive(true);
    }

    public void Retry() {
        SceneManager.LoadScene("SampleScene");
    }
}
