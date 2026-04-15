using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    [SerializeField] private float gameTime;
    //private float sliderCurrentFillAmount;
    [Header("Score Components")]
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;
    [SerializeField] private TextMeshProUGUI highScoreGUUI;
    [SerializeField] private TextMeshProUGUI pupUpGameOverScore; 
    private int _highScore;
    private int playerScore;

    [Header("Game Over Components")]
    [SerializeField] private GameObject gameOverScreen;

    [Header("Audio components")]
    [SerializeField] private AudioSource gameplayAudioSource;
    [SerializeField] private AudioClip introAudio;
    [SerializeField] private AudioClip mainGameAudio;
    [SerializeField] private AudioClip gameOverAudio;


    public enum GameStates
    {
        Wating,
        Playing,
        GameOver
    }

    public static GameStates currentGameStatus;

    private void Awake()
    {
        currentGameStatus = GameStates.Wating;

        //Using PlayersPrefs
        //if(PlayerPrefs.HasKey("HighScore"))
        //{
        //    highScoreGUUI.text = PlayerPrefs.GetInt("HighScore").ToString();
        //}

    }


    // Update is called once per frame
    void Update()
    {
        if(currentGameStatus == GameStates.Playing)
        {
            AdjustTimer();
            AdjustScore();
        }
    }

    private void AdjustTimer()
    {
        timerImage.fillAmount -= Time.deltaTime/gameTime;

        if (timerImage.fillAmount <= 0)
        {
            gameOver();
        }

    }


    private void AdjustScore()
    {
        textMeshProUGUI.text = playerScore.ToString();
    }

    public void UpdatePlayerScore(int asteroidHitPoints)
    {
        //Como este metodo es llamado por ortras clases tenemos que poner una condicion 
        if(currentGameStatus == GameStates.Playing) { 
            playerScore += asteroidHitPoints; 
        }
    }

    public void startGame()
    {
        currentGameStatus=GameStates.Playing;

        //gameplayAudioSource.clip = mainGameAudio;
        //gameplayAudioSource.Play();
        PlayeGameAudio(mainGameAudio, true);
    }
    private void gameOver()
    {
        currentGameStatus = GameStates.GameOver; 

        //gameplayAudioSource.clip = gameOverAudio;
        //gameplayAudioSource.loop = false;
        //gameplayAudioSource.Play();
        PlayeGameAudio(gameOverAudio, false);
        gameOverScreen.SetActive(true);

        pupUpGameOverScore.text = playerScore.ToString();   

        if(playerScore > _highScore)
        {
            highScoreGUUI.text = playerScore.ToString(); 
            _highScore = playerScore;
        }

        //Using PlayersPrefs
        //if(playerScore > PlayerPrefs.GetInt("HighScore"))
        //{
        //    PlayerPrefs.SetInt("HighScore", playerScore);
        //    highScoreGUUI.text = PlayerPrefs.GetInt("HighScore").ToString() ;
        //}
    }

    public void resetGame()
    {
        currentGameStatus = GameStates.Wating;

        //gameplayAudioSource.clip = introAudio;
        //gameplayAudioSource.loop = true;
        //gameplayAudioSource.Play();
        PlayeGameAudio(introAudio, true);

        playerScore = 0;
        textMeshProUGUI.text = "0";
        timerImage.fillAmount = 1f;
        timerImage.fillAmount = 1f; 
    }

    private void PlayeGameAudio(AudioClip clip, bool loop)
    {
        gameplayAudioSource.clip=clip;
        gameplayAudioSource.loop = loop;
        gameplayAudioSource.Play();
    }

}
