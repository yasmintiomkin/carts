using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float score = 0;
    private bool shouldSpawnPowerUp = true;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreAm;
    [SerializeField] BallSpawner ballSpawner;
    [SerializeField] TextMeshProUGUI finalScoreWin;
    [SerializeField] TextMeshProUGUI finalScoreLose;

    [SerializeField] AudioSource lowScoreSound;
    [SerializeField] AudioSource highScoreSound;
    [SerializeField] AudioSource mediumScoreSound;



    void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(score >= 200 && shouldSpawnPowerUp)
        {
            ballSpawner.SpawnPowerUp();
            shouldSpawnPowerUp = false;
        }

        finalScoreWin.text = score.ToString();
        finalScoreLose.text = score.ToString();

    }

    public void AddPoint(float scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = $"Points: {score.ToString("N0")}";
        scoreAm.text = $"+ {scoreAmount.ToString("N0")}";

        if(scoreAmount == 25)
        {
            lowScoreSound.Play();
        }
        else if (scoreAmount > 25 && scoreAmount < 100)
        {
            mediumScoreSound.Play();
        }
        else if (scoreAmount >= 100)
        {
            highScoreSound.Play();
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("PhysicsPlayground");
        Time.timeScale = 1;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        Time.timeScale = 1;
    }
}
