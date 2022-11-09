using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Transition transition;
    ScratchTiles scratch;
    public int nextLevelIndex;
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
        transition.CambiarEscena(nextLevelIndex);
    }
    public void PauseLevel(bool isPaused)
    {
        scratch.canScratch = !isPaused;
    }
}
