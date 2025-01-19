using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer SFX;
    public AudioMixer Music;
    public AudioSource ClickSound;
    public RectTransform BarMusic;
    public RectTransform BarSFX;

    void Start(){
        SFX.GetFloat("SFXVolume", out float currentVolume);
        Vector2 sizeDelta = BarSFX.sizeDelta; 
        sizeDelta.x =Mathf.Clamp01(Mathf.InverseLerp(-20f, 0f, currentVolume))*100f; 
        BarSFX.sizeDelta = sizeDelta;
        SFX.GetFloat("SFXVolume", out float currentVolume2);
        Vector2 sizeDelta2 = BarSFX.sizeDelta; 
        sizeDelta2.x =Mathf.Clamp01(Mathf.InverseLerp(-20f, 0f, currentVolume2))*100f;
        BarSFX.sizeDelta = sizeDelta2;
    }
    public void SetSFXVolume(float linearVolume)
    {
        if (linearVolume <= 0f)
            SFX.SetFloat("SFXVolume", -80f);
        else
            SFX.SetFloat("SFXVolume", Mathf.Lerp(-20f, 0f, linearVolume));
    }

    public void SFXPlus()
    {
        SFX.GetFloat("SFXVolume", out float currentVolume);
        SetSFXVolume(Mathf.Clamp01(Mathf.InverseLerp(-20f, 0f, currentVolume) + 0.1f));
        Vector2 sizeDelta = BarSFX.sizeDelta; 
        sizeDelta.x =Mathf.Clamp01(Mathf.InverseLerp(-20f, 0f, currentVolume) + 0.1f)*100f; 
        BarSFX.sizeDelta = sizeDelta;
        ClickSound.Play();
    }

    public void SFXMinus()
    {
        SFX.GetFloat("SFXVolume", out float currentVolume);
        SetSFXVolume(Mathf.Clamp01(Mathf.InverseLerp(-20f, 0f, currentVolume) - 0.1f));
        Vector2 sizeDelta = BarSFX.sizeDelta; 
        sizeDelta.x =Mathf.Clamp01(Mathf.InverseLerp(-20f, 0f, currentVolume) - 0.1f)*100f;
        BarSFX.sizeDelta = sizeDelta;
        ClickSound.Play();
    }

    public void SetMusicVolume(float linearVolume)
    {
        if (linearVolume <= 0f)
            Music.SetFloat("MusicVolume", -80);
        else
            Music.SetFloat("MusicVolume", Mathf.Lerp(-20f, 0f, linearVolume));
    }

    public void MusicPlus()
    {
        Music.GetFloat("MusicVolume", out float currentVolume);
        SetMusicVolume(Mathf.Clamp01(Mathf.InverseLerp(-20f, 0f, currentVolume) + 0.1f));
        Vector2 sizeDelta = BarMusic.sizeDelta; 
        sizeDelta.x =Mathf.Clamp01(Mathf.InverseLerp(-20f, 0f, currentVolume) + 0.1f)*100f;
        BarMusic.sizeDelta = sizeDelta;
        ClickSound.Play();
    }

    public void MusicMinus()
    {
        Music.GetFloat("MusicVolume", out float currentVolume);
        SetMusicVolume(Mathf.Clamp01(Mathf.InverseLerp(-20f, 0f, currentVolume) - 0.1f));
        Vector2 sizeDelta = BarMusic.sizeDelta; 
        sizeDelta.x =Mathf.Clamp01(Mathf.InverseLerp(-20f, 0f, currentVolume) - 0.1f)*100f;
        BarMusic.sizeDelta = sizeDelta;
        ClickSound.Play();
    }
}