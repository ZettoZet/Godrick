using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIHandler : MonoBehaviour
{
            

    bool isgameactive;
    public void GoToGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        //Application.Quit();
        EditorApplication.ExitPlaymode();
    }
}
