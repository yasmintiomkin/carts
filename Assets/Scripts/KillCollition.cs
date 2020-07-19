using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollition : MonoBehaviour
{
    [SerializeField] Player player;
    public BallSpawner ballSpawner;
    public static int destroyedBalls = 0;
    public int ballsInGame;
    public GameObject endGame;

    [SerializeField] AudioSource winSound;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            ballSpawner.BallDestroyedNotification(other.gameObject);
            Destroy(other.gameObject);
            destroyedBalls++;
            if(destroyedBalls == ballsInGame)
            {
                endGame.SetActive(true);
                Time.timeScale = 0;
                winSound.Play();
            }

        }

        if (other.gameObject.tag == "Player")
        {
            player.Dead();
        }

    }
}
