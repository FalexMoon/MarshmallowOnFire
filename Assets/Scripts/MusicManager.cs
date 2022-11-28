using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] Musica;
    AudioSource aud;
    int indexMusica;
    float inicialPitch;
    float inicialVolume;
    bool reset;

    void Start()
    {
        aud = GetComponent<AudioSource>();
        inicialPitch = aud.pitch;
        inicialVolume = aud.volume;
    }
    private void PlayMusic()
    {
        int i = Random.Range(0, Musica.Length);
        while (indexMusica == i)
        {
            i = Random.Range(0, Musica.Length);
        }
        indexMusica = i;
        aud.clip = Musica[indexMusica];
        aud.Play();

    }
    void Update()
    {
        if (aud.isPlaying == false)
        {
            PlayMusic();
        }

        if(reset == true)
        {
           /* if (aud.pitch > inicialPitch)
            {
                if (aud.volume > 0)
                {
                    aud.volume -= Time.deltaTime/2;
                }
                else
                {
                    aud.pitch = inicialPitch;
                }
            }else if(aud.pitch == inicialPitch && aud.volume <= 0)
            {
                print("AAAA");
                aud.volume += Time.deltaTime/2;
                if(aud.volume >= inicialVolume)
                {
                    aud.volume = inicialVolume;
                    reset = false;
                }
            }
            if(aud.volume == inicialVolume && aud.pitch == inicialPitch)
            {
                reset = false;
            }*/
        }
    }

    public void IncreasePitch(float increaseValue)
    {
        aud.pitch += increaseValue;
    }
    public void IncreaseVolume(float increaseValue)
    {
        aud.volume += increaseValue;
    }

    public void ResetValues()
    {
        reset = true;
    }
}
