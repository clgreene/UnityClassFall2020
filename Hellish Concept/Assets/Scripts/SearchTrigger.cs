using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchTrigger : MonoBehaviour
{

    public Text text;
    public bool shov;
    public BoolData shovel;

    public IntData dial;
    public IntData objDial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.text = "Search";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            if (shov == true && shovel.value == false)
            {
                shovel.value = true;
                text.text = "You found a shovel";
                dial.value = 3;
                objDial.value = 4;
            }

            else text.text = "You didn't find anything";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.text = "";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
