using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDrift : MonoBehaviour
{

    public float movement;
    public int drag;
    void Update()
    {
        
        transform.Translate(0, Mathf.Cos(Time.time - drag) * movement, 0);
        //transform.Translate(0, Mathf.Pow(-1, Time.time) * movement, 0);
    }
}
