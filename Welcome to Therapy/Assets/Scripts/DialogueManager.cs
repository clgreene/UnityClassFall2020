using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DialogueManager : MonoBehaviour
{

    public UnityEvent SetStringEvent, GetEvent, SetTextEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetStringEvent.Invoke();
        GetEvent.Invoke();
        SetTextEvent.Invoke();
    }
}
