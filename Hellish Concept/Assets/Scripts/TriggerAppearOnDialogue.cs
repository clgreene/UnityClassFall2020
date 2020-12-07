using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerAppearOnDialogue : MonoBehaviour
{

    public string dialogueTriggerText;
    public Text dialogueText;
    public GameObject Trigger;


    void Start()
    {
        Trigger.SetActive(false);
    }

    void update()
    {
        if (dialogueText.text == dialogueTriggerText) Trigger.SetActive(true);

        else Trigger.SetActive(false);
    }
    // Start is called before the first frame update


}
