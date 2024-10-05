using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text scoreText;
    public int score;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreAdd(int _score) {
        score += _score;
        scoreText.text = score.ToString();
    }
}
