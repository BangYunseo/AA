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
    public int goal;

    [SerializeField]
    private TextMeshProUGUI textGoal;

    [SerializeField]
    private GameObject btnRetry;

    [SerializeField]
    private Color green;

    [SerializeField]
    private Color red;
    [SerializeField]
    private GameObject gameOverUI;
    public int score = 0;

    public Text highScoreText;
    public int highScore;
    public Image gameOverImage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(btnRetry != null)
        {
            btnRetry.GetComponent<Button>().onClick.AddListener(Retry);
        }

        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
        textGoal.SetText(goal.ToString());
        // highScoreText = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 맞춰야 할 핀의 개수 감소
    public void DecreaseGoal() {
        goal -= 1;
        textGoal.SetText(goal.ToString());
        
        UIManager.instance.ScoreAdd(10);

        if(goal <= 0) {
            SetGameOver(true);
        }
    }

    public void SetGameOver(bool success) {
        if (!isGameOver)
        {
            isGameOver = true;
            Camera.main.backgroundColor = success ? green : red;

            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
                Debug.Log("UI 활성화 완료");
            
            if (gameOverUI.GetComponent<Canvas>() == null)
                {
                Debug.LogError("gameOverUI에는 Canvas 컴포넌트가 없어요!");
            }
        }
        else
        {
            Debug.LogError("gameOverUI가 null이에요 ㅠㅠ");
        }
    }
}
    public void ShowRetryButton() {
        if (btnRetry != null) {
            btnRetry.SetActive(true);
        }
    }

    // 재도전
    public void Retry()
    {
        goal = 20;
        textGoal.SetText(goal.ToString());
        isGameOver = false;
        gameOverUI.SetActive(false);
        Camera.main.backgroundColor = Color.white;

        score = 0;
    }
}
