using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueContinue : MonoBehaviour
{

    public BoolData dialogue;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            dialogue.value = false;
            gameObject.SetActive(false);
        }
    }
}
