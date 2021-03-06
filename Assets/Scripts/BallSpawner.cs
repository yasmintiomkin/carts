﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    private struct WeightBallType
    {
        public int weight;
        public Ball.BallType ballType;

        public WeightBallType(int weight, Ball.BallType ballType) : this()
        {
            this.weight = weight;
            this.ballType = ballType;
        }
    }

    public List<Ball> ballTypes;

    public List<GameObject> balls = new List<GameObject>();
    public Transform spawnPoint;
    public int maxConcurrentBallsInArena = 10;
    public int maxBallsToSpawn = 20;
    private int totalSpawned = 0;

    public int weightSpawnBallBlue  = 2;
    public int weightSpawnBallRed   = 1;
    public int weightSpawnBallGreen = 5;
    private int totalWeight;
    private List<WeightBallType> weights = new List<WeightBallType>();
    private List<Ball.BallType> typesStack = new List<Ball.BallType>();

    private Vector3 spawnVec;

    [SerializeField]
    private int force = 100;
    public GameObject powerUpPrefab;

    private bool shouldSpawn = true;

    
    void Start()
    {
        PrepareWeightsOnStart();

        spawnVec = spawnPoint.transform.position;
        float startIn = 2;
        float every = 2;
        InvokeRepeating("SpawnBall", startIn, every);
    }

    void Update()
    {

    }

    void SpawnBall()
    {
        if (!shouldSpawn)
        {
            return;
        }

        if (totalSpawned >= maxBallsToSpawn)
        {
            return;
        }

        int totalBalls = balls.Count;

        if (totalBalls >= maxConcurrentBallsInArena)
        {
            return;
        }

        //Debug.Log("total balls: " + totalBalls + ", totalSpawned" + totalSpawned);

        Ball.BallType ballTypeToSpawn = NextBallType();
        //Debug.Log("creating " + ballTypeToSpawn);

        // spawn ball
        GameObject ballGameObjectToSpawn = GetBallPFByType(ballTypeToSpawn);
        if (ballGameObjectToSpawn != null)
        {
            GameObject spawnedBall = Instantiate(ballGameObjectToSpawn, spawnVec, Quaternion.identity) as GameObject;
            spawnedBall.GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Acceleration);
            balls.Add(spawnedBall);
            totalSpawned++;
        }
    }

    private void PrepareWeightsOnStart()
    {
        totalWeight = weightSpawnBallBlue + weightSpawnBallGreen + weightSpawnBallRed;
        weights.Add(new WeightBallType(weightSpawnBallBlue, Ball.BallType.blue));
        weights.Add(new WeightBallType(weightSpawnBallGreen, Ball.BallType.green));
        weights.Add(new WeightBallType(weightSpawnBallRed, Ball.BallType.red));

        // sort so largest weight is first
        //weights.OrderByDescending(w => w.weight).ToList();
        //weights.Sort((w1, w2) => w1.weight.CompareTo(w2.weight));
        //Debug.Log(weights);
    }

    private void NewBallTypesStack()
    {
        typesStack = new List<Ball.BallType>();

        foreach (WeightBallType wbt in weights)
        {
            for (int i = 0; i < wbt.weight; i++)
            {
                typesStack.Add(wbt.ballType);
            }
        }
    }

    private Ball.BallType NextBallType()
    {
        if (typesStack.Count() == 0)
        {
            NewBallTypesStack();
        }

        // generate next ball type randomly by weight
        Random.InitState(System.DateTime.Now.Millisecond); // make randow seem more random
        int randomIndex = Random.Range(0, typesStack.Count());

        Ball.BallType ballType = typesStack[randomIndex];
        typesStack.RemoveAt(randomIndex);

        return ballType;
    }
    //private Ball.BallType NextBallType()
    //{
    //    // generate next ball type randomly by weight
    //    Random.seed = System.DateTime.Now.Millisecond; // make randow seem more random
    //    int randomWeight = Random.Range(1, totalWeight+1); // returns 1-total
    //    int currentWeight = 0;

    //    foreach (WeightBallType wbt in weights)
    //    {
    //        currentWeight += wbt.weight;

    //        if (randomWeight <= currentWeight)
    //        {
    //            return wbt.ballType;
    //        }
    //    }
        
    //    return Ball.BallType.green; // we should not get here
    //}

    //private int GetNumBallsByType(Ball.BallType ballType)
    //{
    //    int val = balls.Where(ball => ball.GetComponent<Ball>().ballType == ballType).Count();
    //    Debug.Log("total " + ballType + ":" + val);
    //    return val;
    //}

    private GameObject GetBallPFByType(Ball.BallType ballType)
    {
        Ball val = ballTypes.Where(ball => ball.ballType == ballType).First();
        return val.gameObject;
    }


    public void BallDestroyedNotification(GameObject ballToDestroy)
    {
        shouldSpawn = false; // don't spawn while changing array

        List<GameObject> newList = balls.Where(ball => ball != ballToDestroy).ToList();
        balls = newList;

        shouldSpawn = true;
    }
   
    public void SpawnPowerUp()
    {
        GameObject powerUP = Instantiate(powerUpPrefab, spawnVec, Quaternion.identity) as GameObject;
        powerUP.GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Acceleration);
    }
}
