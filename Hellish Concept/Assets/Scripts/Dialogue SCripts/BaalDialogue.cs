using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaalDialogue : MonoBehaviour
{
    public BoolData dialogue;
    public GameObject ballDialogue;


    public void OnTriggerStay(Collider other)
    {
        
        if (Input.GetKeyDown(KeyCode.F) && dialogue.value == false)
        {
            
            ballDialogue.SetActive(true);
            dialogue.value = true;
            

        }


    }
}
