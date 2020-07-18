﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] GameManager gameManager;
    [SerializeField] Text textOnGates;

    private float scoreMulti = 0;

    private void Start()
    {
        textOnGates.text = score.ToString();
        SetTextColor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            if (other.gameObject.name == "BallBlue")
            {
                scoreMulti = 1.5f;
            }
            else if (other.gameObject.name == "BallRed")
            {
                scoreMulti = 2f;
            }
            else
            {
                scoreMulti = 1;
            }
            gameManager.AddPoint(score*scoreMulti);

        }
        
        if (gameManager == null)
        {
            return;
        }
    }
    void SetTextColor()
    {
        if (score <= 100)
        {
            textOnGates.color = Color.red;
        }
        else if(score >100 && score <= 250)
        {
            textOnGates.color = Color.blue;
        }
        else if(score >250 && score <= 450)
        {
            textOnGates.color = Color.green;
        }
        else if (score > 450)
        {
            textOnGates.color = Color.Lerp(Color.yellow, Color.cyan, 1f);
        }
    }
}
