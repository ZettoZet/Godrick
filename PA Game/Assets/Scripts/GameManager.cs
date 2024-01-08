using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI countdownText;*/

    public float countdown = 5f;
    public static GameManager instance;

    public bool isGameActive;

    /*public Button restartButton;*/
    // Start is called before the first frame update
    public void StartGame()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        isGameActive = true;
        StartCoroutine(Timer());


        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive == true)
        {
            Countdown();
        }
    }

    public void GameOver()
    {
        /*gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);*/
        isGameActive = false;

    }

    public void Countdown()
    {
        if(countdown > 0)
        {
            countdown -= 1 * Time.deltaTime;
            /*countdownText.text = "Time: " + Mathf.RoundToInt(countdown);*/
        }
        else
        {
            isGameActive = false;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(countdown);

        if (isGameActive)
        {
            GameOver();
        }
    }
}
