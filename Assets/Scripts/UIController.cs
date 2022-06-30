using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] Button playButton, settingsButton,backButton;
    [SerializeField] Toggle vfxCheckbox, musicCheckbox;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource clickSound;
    // Start is called before the first frame update
    void Start()
    {
        SetSoundValues();
        backgroundMusic.Play();
        playButton.enabled = true;
        settingsButton.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        ClickSound();
        playButton.enabled = false;
        settingsButton.enabled = false;
    }
    public void SettingsButton()
    {
        ClickSound();
        // Animation screen move to left
        LeanTween.moveLocal(screen, new Vector3(-1920f, 0f, 0f), 2.5f).setDelay(.05f).setEase(LeanTweenType.easeInOutCubic);

        // Disable buttons
        playButton.enabled = false;
        settingsButton.enabled = false;

        // Enable buttons
        backButton.enabled = true;
        vfxCheckbox.enabled = true;
        musicCheckbox.enabled = true;
    }
    public void BackButton()
    {
        ClickSound();
        // Animation screen move to right
        LeanTween.moveLocal(screen, new Vector3(0f, 0f, 0f), 2.5f).setDelay(.05f).setEase(LeanTweenType.easeInOutCubic);

        // Disable buttons
        backButton.enabled = false;
        vfxCheckbox.enabled = false;
        musicCheckbox.enabled = false;

        // Enable buttons
        playButton.enabled = true;
        settingsButton.enabled = true;
    }
    public void PlayBackgroundMusic()
    {
        if (musicCheckbox.isOn)
        {
            PlayerPrefs.SetString("Music", "isOn");
            backgroundMusic.volume = 0.1f;
        }
        else
        {
            PlayerPrefs.SetString("Music", "isOff");
            backgroundMusic.volume = 0f;
        }
    }
    void ClickSound()
    {
        if (vfxCheckbox.isOn)
        {
            PlayerPrefs.SetString("SFX", "isOn");
            clickSound.Play();
        }
        else
        {
            PlayerPrefs.SetString("SFX", "isOff");
        }
    }
    void SetSoundValues()
    {
        if (PlayerPrefs.GetString("Music") == "isOff")
        {
            musicCheckbox.isOn = false;
        }
        else
        {
            musicCheckbox.isOn = true;
        }
        if (PlayerPrefs.GetString("SFX") == "isOff")
        {
            vfxCheckbox.isOn = false;
        }
        else
        {
            vfxCheckbox.isOn = true;
        }
    }
}