using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    SphereCollider sphereCollider;
    float bouncinessOrig;
    float dynamicFrictionOrig;
    float massOrig;
    Rigidbody rb;

    public float powerUpBouncinessScale = 2;
    public float powerUpDynamicFrictionScale = 2;
    public float powerUpMass = 2;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        bouncinessOrig = sphereCollider.material.bounciness;
        dynamicFrictionOrig = sphereCollider.material.dynamicFriction;
        massOrig = rb.mass;
    }

    void Update()
    {
        
    }

    public void PowerUp(bool on)
    {
        if (on)
        {
            sphereCollider.material.bounciness = bouncinessOrig * powerUpBouncinessScale;
            sphereCollider.material.dynamicFriction = dynamicFrictionOrig * powerUpDynamicFrictionScale;
            rb.mass = massOrig / powerUpMass;
        }
        else
        {
            sphereCollider.material.bounciness = bouncinessOrig;
            sphereCollider.material.dynamicFriction = dynamicFrictionOrig;
            rb.mass = massOrig;
        }
    }

}
