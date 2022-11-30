using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Transition transition;
    ScratchTiles scratch;

    public float timeBeforeDeath;
    public float timeRemaining;
    Player player;
    SpriteRenderer playerSprite;
    MusicManager music;
    bool resetMusic;
    bool faster;
    bool countDown = true;

    private void Start()
    {
        transition = FindObjectOfType<Transition>();
        scratch = FindObjectOfType<ScratchTiles>();
        player = FindObjectOfType<Player>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        music = FindObjectOfType<MusicManager>();
        timeRemaining = timeBeforeDeath;
    }


    private void Update()
    {
        if (timeRemaining > 0 && resetMusic == false && countDown)
        {
            timeRemaining -= Time.deltaTime;
            QuemarBombon();
            if (timeRemaining < timeBeforeDeath/2 && faster == false)
            {
                faster = true;
                player.Faster();
                StartCoroutine(wait());
            }
        }
        if(timeRemaining <= 0 && player)
        {
            player.Die();
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);
        if (countDown)
        {
            music.IncreasePitch(1);
        }
    }

    void QuemarBombon()
    {
        Color gris = new Color(0.245f, 0.245f, 0.245f, 1);
        playerSprite.color = Color.Lerp(gris, Color.white, timeRemaining/timeBeforeDeath);
    }
    public void RestartLevel()
    {
        countDown = false;
        music.ResetValues();
        transition.CambiarEscena(SceneManager.GetActiveScene().buildIndex);
    }
    public void LevelComplete()
    {
        countDown = false;
        music.ResetValues();
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
        player.Mute(isPaused);
    }
}
