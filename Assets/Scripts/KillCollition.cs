using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollition : MonoBehaviour
{
    [SerializeField] Player player;
    public BallSpawner ballSpawner;
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            ballSpawner.BallDestroyedNotification(other.gameObject);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            player.Dead();
        }

    }
}
