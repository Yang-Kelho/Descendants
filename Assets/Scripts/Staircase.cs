using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Staircase : MonoBehaviour
{
    [SerializeField] string _nextLevelName;
    private Enemy[] _enemies;

    void Start()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if all enemies in level are dead, go to next scene
        if (collision.CompareTag("Player") && AllEnemiesDefeated())
        {
            NextLevel();
        }
    }

    private bool AllEnemiesDefeated()
    {
        foreach (var enemy in _enemies)
        {

            if (enemy != null)
            {
                return false;
            }
        }
        return true;
    }
    private void NextLevel()
    {
        SceneManager.LoadScene(_nextLevelName);
    }
}
