using System;
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
        if (LevelManager)
        {
            LevelManager.LoadNextLevel();
        }
    }

    public void SkipToLevel(int idx)
    {
        if (LevelManager)
        {
            LevelManager.LoadLevel(idx);
        }
    }

    public void SkipToLevel(string idx)
    {
        int newIdx;
        if(Int32.TryParse(idx, out newIdx))
        {
            SkipToLevel(newIdx);
        }
    }
}
