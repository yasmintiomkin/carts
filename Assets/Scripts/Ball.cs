using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    SphereCollider sphereCollider;
    float bouncinessOrig;
    float dynamicFrictionOrig;

    public float powerUpBouncinessScale = 2;
    public float powerUpDynamicFrictionScale = 2;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        bouncinessOrig = sphereCollider.material.bounciness;
        dynamicFrictionOrig = sphereCollider.material.dynamicFriction;
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
        }
        else
        {
            sphereCollider.material.bounciness = bouncinessOrig;
            sphereCollider.material.dynamicFriction = dynamicFrictionOrig;
        }
    }

}
