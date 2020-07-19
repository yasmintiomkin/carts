using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameObject[] ballsInScene;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        ballsInScene = GameObject.FindGameObjectsWithTag("Ball");
    //        foreach(GameObject ball in ballsInScene)
    //        {
    //            ball.GetComponent<Ball>().PowerOn();
    //            Debug.Log("Powerup on");
    //        }
    //        Destroy(gameObject);
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ballsInScene = GameObject.FindGameObjectsWithTag("Ball");
            foreach (GameObject ball in ballsInScene)
            {
                ball.GetComponent<Ball>().PowerOn();
                Debug.Log("Powerup on");
            }
            Destroy(gameObject);
        }
    }
}
