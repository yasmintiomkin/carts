using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject endGame;
    [SerializeField] AudioSource gameOverSound;

    public void Dead()
    {
        endGame.SetActive(true);
        Time.timeScale = 0;
        gameOverSound.Play();
    }
}
