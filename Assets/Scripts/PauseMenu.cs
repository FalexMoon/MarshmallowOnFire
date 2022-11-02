using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUi;

    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Pause(bool pause)
    {
       StartCoroutine(ChangePause(pause));
    }
    /*
    public void Resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }*/

    public IEnumerator ChangePause(bool pause)
    {
        pauseMenuUi.SetActive(true);
        isPaused = pause;
        anim.SetBool("IsPaused", isPaused);
        if (pause)
        {
            yield return new WaitForSeconds(0.15f);
            Time.timeScale = pause ? 0f : 1f;
        }
        else
        {
            Time.timeScale = pause ? 0f : 1f;
            yield return new WaitForSeconds(0.5f);
            pauseMenuUi.SetActive(false);
        }
        
    }
}
