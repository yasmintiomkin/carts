using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public List<Ball> ballTypes;

    public List<GameObject> balls = new List<GameObject>();
    public Transform spawnPoint;
    public int maxConcurrentBallsInArena = 10;

    public int weightSpawnBallBlue  = 2;
    public int weightSpawnBallRed   = 1;
    public int weightSpawnBallGreen = 5;

    private float percentBlue;
    private float percentGreen;

    private Vector3 spawnVec;

    [SerializeField]
    private int force = 100;

    private bool shouldSpawn = true;

    
    void Start()
    {
        int totalWeight = weightSpawnBallBlue + weightSpawnBallGreen + weightSpawnBallRed;
        percentBlue = weightSpawnBallBlue / totalWeight;
        percentGreen = weightSpawnBallGreen / totalWeight;

        spawnVec = spawnPoint.transform.position;
        float startIn = 2;
        float every = 2;
        InvokeRepeating("SpawnBall", startIn, every);
    }

    void SpawnBall()
    {
        if (balls.Count() >= maxConcurrentBallsInArena || !shouldSpawn)
        {
            return;
        }

        // decide on next ball type to spawn by weight
        int numBlue = GetNumBallsByType(Ball.BallType.blue);
        int numGreen = GetNumBallsByType(Ball.BallType.green);
        int totalBalls = balls.Count();

        Ball.BallType ballTypeToSpawn = Ball.BallType.red;
        if (totalBalls == 0 || numBlue / totalBalls < percentBlue)
        {
            ballTypeToSpawn = Ball.BallType.blue;
        }
        else if (numGreen / totalBalls < percentGreen)
        {
            ballTypeToSpawn = Ball.BallType.green;
        }
        Debug.Log(ballTypeToSpawn);

        // spawn ball
        GameObject ballGameObjectToSpawn = GetBallByType(ballTypeToSpawn);
        if (ballGameObjectToSpawn != null)
        {
            GameObject ballToSpawn = Instantiate(ballGameObjectToSpawn, spawnVec, Quaternion.identity) as GameObject;
            ballToSpawn.GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Acceleration);
        }
    }

    private int GetNumBallsByType(Ball.BallType ballType)
    {
        return 0;
        //balls.Where(ball => ball.ballType == Ball.BallType.blue).Count();
    }

    private GameObject GetBallByType(Ball.BallType ballType)
    {
        //for (int i = 0; i < ballTypes.Count(); i++)
        //{
        //    if (ballTypes[i].GetComponent<Ball>().ballType == ballType)
        //    {
        //        return ballTypes[i];
        //    }
        //}
        //return null;
        IEnumerable res = ballTypes.Where(ball => ball.ballType == ballType);

        Ball val = ballTypes.Where(ball => ball.ballType == ballType).First();
        return val.gameObject;
    }


    public void BallDestroyedNotification(GameObject ballToDestroy)
    {
        shouldSpawn = false; // don't spawn while chaning array

       // List<GameObject> newList = balls.Where(ball => ball == ballToDestroy).ToList<GameObject?>
        //authorsList.Where(x => x.FirstName != "Bob").ToList();

        shouldSpawn = true;
    }
   
}
