using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    public int score, highScore;
    public TextMeshProUGUI scoreText, highScoreText;


    private void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        loadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
        //Debug.Log("Score : " + score);
        //LoadScore();

    }

    public void AddScore()
    {
        score += 10;
        if (score > highScore)
        {
            highScore = score;
        }
        SaveScore();
    }

    public void loadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }
}
