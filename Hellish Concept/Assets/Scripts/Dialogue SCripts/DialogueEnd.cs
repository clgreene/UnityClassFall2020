using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEnd : MonoBehaviour
{

    public BoolData dialogue;
    public float timer = 1;
    
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            gameObject.SetActive(false);
            dialogue.value = false;
        }
    }
}
