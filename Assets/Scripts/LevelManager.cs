using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int CurrentLevel { get; set; }
    public int HighestLevel { get; private set; }

    public int Main = 1;
    public int Final;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        CurrentLevel = Main;
        SceneManager.LoadScene(CurrentLevel);
    }

    public void LoadNextLevel()
    {
        if (CurrentLevel == Final)
        {
            LoadMain();
        }
        else
        {
            CurrentLevel += 1;

            if (CurrentLevel > HighestLevel)
            {
                HighestLevel = CurrentLevel;
            }
            SceneManager.LoadScene(CurrentLevel);
        }
    }

    public void LoadMain()
    {
        CurrentLevel = Main;
        SceneManager.LoadScene(CurrentLevel);
    }

    public void LoadLevel(int levelIdx)
    {
        CurrentLevel = levelIdx;
        SceneManager.LoadScene(CurrentLevel);
    }
}
