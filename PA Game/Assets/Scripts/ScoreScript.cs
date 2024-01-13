using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript instance;
    public int score;
    public TextMeshProUGUI scoreText;


    private void Awake()
    {
        instance = this;
        
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        //Debug.Log("Score : " + score);
        //LoadScore();
    }

    public void AddScore()
    {
        score += 10;
        SaveScore();
    }

    public void LoadScore()
    {
       score = PlayerPrefs.GetInt("Score", 0);
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
    }
}
