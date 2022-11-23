using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Transition transition;
    ScratchTiles scratch;
    private void Start()
    {
        transition = FindObjectOfType<Transition>();
        scratch = FindObjectOfType<ScratchTiles>();
    }

    public void RestartLevel()
    {
        transition.CambiarEscena(SceneManager.GetActiveScene().buildIndex);
    }
    public void LevelComplete()
    {
        if (SceneManager.GetActiveScene().buildIndex+1 < SceneManager.sceneCountInBuildSettings)
        {
            transition.CambiarEscena(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            transition.CambiarEscena(0);
        }
        
    }
    public void ChangeScene(int sceneIndex)
    {
        transition.CambiarEscena(sceneIndex);
    }
    public void PauseLevel(bool isPaused)
    {
        scratch.canScratch = !isPaused;
    }
}
