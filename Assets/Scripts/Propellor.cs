using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class Propellor : MonoBehaviour
{
    private ContactPoint[] allContacts;
    [SerializeField]
    private int pushForce = 1000;
    private int contactIndex;

    private Vector3 firstContact;
   
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 200f) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        firstContact = collision.GetContact(0).point - collision.transform.position;
        collision.rigidbody.AddForce(firstContact.normalized * pushForce, ForceMode.Acceleration);
    }

}
