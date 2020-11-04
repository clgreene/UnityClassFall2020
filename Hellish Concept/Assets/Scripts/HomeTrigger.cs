using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTrigger : MonoBehaviour
{

    public GameObject obj;
    public Color oldColor;
    public Color newColor;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            oldColor = obj.GetComponent<Renderer>().material.color;
            newColor = new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a - 0.8f);
            obj.GetComponent<Renderer>().material.color = newColor;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            obj.GetComponent<Renderer>().material.color = oldColor;
        }
    }

}
