using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugMainPlay : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 300, 50), "1. Basic level"))
        {
            SceneManager.LoadScene("TestGame");
        }
    }
}
