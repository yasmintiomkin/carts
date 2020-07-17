using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            gameManager.AddPoint(score);
            Debug.Log("Enter");
        }
        
        if (gameManager == null)
        {
            return;
        }
    }
}
