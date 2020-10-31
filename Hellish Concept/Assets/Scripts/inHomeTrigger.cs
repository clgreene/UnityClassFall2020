using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inHomeTrigger : MonoBehaviour
{
    public GameObject home;
    
    // Start is called before the first frame update
    void Start()
    {
        home.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                        
            home.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            home.SetActive(true);
        }
    }
}
