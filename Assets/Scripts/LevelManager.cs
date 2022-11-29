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
        if (timeRemaining > 0 && resetMusic == false)
        {
            timeRemaining -= Time.deltaTime;
            QuemarBombon();
            if (timeRemaining < timeBeforeDeath/2 && faster == false)
            {
                faster = true;
                player.Faster();
                music.IncreasePitch(1);
            }
        }
        if(timeRemaining <= 0 && player)
        {
            player.Die();
        }
    }

    void QuemarBombon()
    {
        Color gris = new Color(0.245f, 0.245f, 0.245f, 1);
        playerSprite.color = Color.Lerp(gris, Color.white, timeRemaining/timeBeforeDeath);
    }
    public void RestartLevel()
    {
        music.ResetValues();
        transition.CambiarEscena(SceneManager.GetActiveScene().buildIndex);
    }
    public void LevelComplete()
    {
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
    }
}
