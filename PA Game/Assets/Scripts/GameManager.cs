using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI countdownText;*/

    public float countdown = 60f;
    public static GameManager instance;

    public bool isGameActive;

    /*public Button restartButton;*/
    // Start is called before the first frame update
    public void Start()
    {
        isGameActive = false;

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        


        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            Invoke("GameActive",0f);
            Countdown();
            //StartCoroutine(Timer());
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
        if(countdown <= 0)
        {
            Invoke("GameInActive", 0f);
            ChangeScene();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    /*IEnumerator Timer()
    {
        yield return new WaitForSeconds(countdown);

        if (isGameActive)
        {
            GameOver();
        }
    }*/

    public void ChangeScene()
    {
        if (!isGameActive && SceneManager.GetActiveScene().name == "Game")
        {
            SceneManager.LoadScene(0);
            countdown = 60f;
        }
    }

    void GameActive()
    {
        isGameActive=true;
    }

    void GameInActive()
    {
        isGameActive = false;
    }
}
