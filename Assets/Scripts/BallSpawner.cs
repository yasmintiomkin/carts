using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject[] ball;
    public Transform spawnPoint;
    private Vector3 spawnVec;

    private int currBall = 0;
    [SerializeField]
    private int force = 100;

    void Start()
    {
        spawnVec = spawnPoint.transform.position;
        StartCoroutine(Spawn());
    }

    void Update()
    {

    }

    IEnumerator Spawn()
    {
        for(int i =0; i<10; i++)
        {
            var ballToSpawn = Instantiate(ball[currBall], spawnVec, Quaternion.identity) as GameObject;
            ballToSpawn.GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Acceleration);
            if(currBall < 3)
            {
                currBall++;
            }
            else
            {
                currBall = 0;
            }
            Debug.Log(currBall);
            Debug.Log(ball.Length);
            yield return new WaitForSeconds(4);
        }
        

    }
}
