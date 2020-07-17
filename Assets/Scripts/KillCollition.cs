using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCollition : MonoBehaviour
{
    [SerializeField] Player player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Player")
        {
            player.Dead();
        }

    }
}
