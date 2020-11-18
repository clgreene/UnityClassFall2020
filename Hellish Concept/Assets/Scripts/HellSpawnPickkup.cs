using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HellSpawnPickkup : MonoBehaviour
{

    
    public Text text;
    public string info;
    public Unit hellspawn;

    public int count;

    public Inventory inv;

    public IntData dial;
    public int nextDial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.text = info;
            count = inv.units.Count;
            Debug.Log(count);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            
            if (count == 0) 
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
