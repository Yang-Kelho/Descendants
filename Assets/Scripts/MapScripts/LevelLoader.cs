using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    GameObject panel_main;
    GameObject panel_start;
    public void StartGame()
    {
        // call panel_start:
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
