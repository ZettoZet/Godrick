using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        //Application.Quit();
        EditorApplication.ExitPlaymode();
    }
}
