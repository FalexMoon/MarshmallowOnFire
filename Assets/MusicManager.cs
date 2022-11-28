using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] Musica;
    AudioSource aud;
    int indexMusica;

    void Start()
    {
        aud = GetComponent<AudioSource>();
    }
    private void PlayMusic()
    {
        int i = Random.Range(0, Musica.Length + 1);
        while (indexMusica == i)
        {
            i = Random.Range(0, Musica.Length + 1);
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
    }
}
