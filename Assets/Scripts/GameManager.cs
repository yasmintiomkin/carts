using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float score = 0;
    private bool shouldSpawnPowerUp = true;

    [SerializeField] Text scoreText;
    [SerializeField] BallSpawner ballSpawner;

    private void Update()
    {
        if(score >= 750 && shouldSpawnPowerUp)
        {
            ballSpawner.SpawnPowerUp();
            shouldSpawnPowerUp = false;
        }
    }

    public void AddPoint(float scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = $"SCORE: {score.ToString("N0")}";
        Debug.Log(score);

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("PhysicsPlayground");
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
