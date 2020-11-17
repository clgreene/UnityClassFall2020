using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HellSpawnPickkup : MonoBehaviour
{

    
    public Text text;
    public string info;
    public Unit hellspawn;
    

    public Inventory inv;

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
            
            if (dial.value == 1) 
            {
                inv.addUnit(hellspawn);
                dial.value = 2;
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

}
