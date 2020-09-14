using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class applyForce : MonoBehaviour
{

    private Rigidbody rBody;
    public float force = 300f;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        var forceDirection = new Vector3(0, 0, force);
        rBody.AddRelativeForce(forceDirection);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
