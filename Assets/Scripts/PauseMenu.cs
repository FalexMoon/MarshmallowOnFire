using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUi;

    Animator anim;
    LevelManager levelManager;
    private void Start()
    {
        anim = GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void Pause(bool pause)
    {
       StartCoroutine(ChangePause(pause));
    }

    public IEnumerator ChangePause(bool pause)
    {
        pauseMenuUi.SetActive(true);
        isPaused = pause;
        anim.SetBool("IsPaused", isPaused);
        if (pause)
        {
            yield return new WaitForSeconds(0.15f);
            Time.timeScale = pause ? 0f : 1f;
            levelManager.PauseLevel(pause);
        }
        else
        {
            Time.timeScale = pause ? 0f : 1f;
            yield return new WaitForSeconds(0.5f);
            pauseMenuUi.SetActive(false);
            levelManager.PauseLevel(pause);
        }
        
    }
}
