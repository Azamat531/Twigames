using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayUIController : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private int numberOfAddToScore=1;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource clickSound;
    // Start is called before the first frame update
    void Start()
    {
        SetScore();
        SetSoundValues();
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore()
    {
        score += numberOfAddToScore;
        SetScore();
    }
    void SetScore()
    {
        scoreText.text = "Coins: " + score;
    }
    void SetSoundValues()
    {
        if (PlayerPrefs.GetString("Music") == "isOff")
        {
            backgroundMusic.volume = 0f;
        }
        else
        {
            backgroundMusic.volume = 0.1f;
        }
    }
    public void PlayClickSound()
    {
        if (PlayerPrefs.GetString("SFX") != "isOff")
        {
            clickSound.Play();
        }
    }
}
