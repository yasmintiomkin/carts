using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    [SerializeField] Text scoreText;

    public void AddPoint(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = $"Points: {score.ToString("N0")}";
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
