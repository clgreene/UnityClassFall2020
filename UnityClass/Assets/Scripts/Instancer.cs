using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancer : MonoBehaviour
{
    public GameObject prefab;
    

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        var location = transform.position;

        //if (Input.GetMouseButtonDown(int button))
        //{
        //    Instantiate(prefab, location, Quaternion.identity);
        //}
    }
}
