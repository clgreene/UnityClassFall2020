using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HellSpawnPickkup : MonoBehaviour
{

    
    public Text text;
    public string info;
    public BoolData hellspawn;
    public BoolData hellspawnSecond;
    public BoolData hellspawnThird;

    public IntData dial;
    public int nextDial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.text = info;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            dial.value = nextDial;
            if (hellspawnSecond.value == false && hellspawnThird.value == false) 
            {
                hellspawn.value = true;
                text.text = "You obtained a Hellspawn.";
            }

            else text.text = "You already chose one, don't be greedy!";
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
