using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCont : MonoBehaviour
{ 
    
    public GameObject dialogueCont;

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameObject.SetActive(false);
            dialogueCont.SetActive(true);
        }
    }
}
