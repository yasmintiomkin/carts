using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
}
