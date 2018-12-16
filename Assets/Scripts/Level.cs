using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public LevelManager LevelManager { get; private set; }
    public int Idx;

    private void Start()
    {
        LevelManager = FindObjectOfType<LevelManager>();
        if (LevelManager == null)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void CompleteLevel()
    {
        LevelManager.LoadNextLevel();
    }
}
