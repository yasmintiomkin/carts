using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject endGame;
    public void Dead()
    {
        endGame.SetActive(true);
    }
}
