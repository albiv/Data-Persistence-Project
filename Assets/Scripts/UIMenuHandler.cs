using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class UIMenuHandler : MonoBehaviour
{
    public void StartNew()
    {
        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

    public void HandleInputName(string input)
    {
        Debug.Log("input: " + input);
        MainManager.instance.SetPlayerName(input);
    }
}
