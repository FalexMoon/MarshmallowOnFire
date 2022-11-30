using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    Slider volumeSlider;
    void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat("Volumen", 1f);
        AudioListener.volume = volumeSlider.value;
    }

    public void ChangeVolume()
    {
        PlayerPrefs.SetFloat("Volumen", volumeSlider.value);
        AudioListener.volume = volumeSlider.value;

    }
}
