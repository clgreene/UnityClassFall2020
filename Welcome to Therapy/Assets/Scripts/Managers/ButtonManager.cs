using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //variables for dialogue options
    public Button optionOne;
    public Text buttonOneText;
    public Button optionTwo;
    public Text buttonTwoText;

    //variables for final button
    public Button finishSession;
    public Text finishSessionText;


    public GameObject buttons;
    public GameObject finalButtons;

    // Start is called before the first frame update
    void Start()
    {
        buttons.SetActive(false);
    }

    public void SetButtons(int branchOne, int branchTwo, string buttonOneString, string buttonTwoString, IntData branchInt, IntData dialogueInt)
    {
        optionOne.onClick.AddListener(() => branchOff(branchOne, branchInt, dialogueInt));
        buttonOneText.text = buttonOneString;
        optionTwo.onClick.AddListener(() => branchOff(branchTwo, branchInt, dialogueInt));
        buttonTwoText.text = buttonTwoString;
    }

    public void branchOff(int branch, IntData branchInt, IntData dialogueInt)
    {
        branchInt.value = branch;
        dialogueInt.value = 0;
        buttons.SetActive(false);
    }

    public void SetFinalButtons(string finishSessionString)
    {
        finishSession.onClick.AddListener(() => finishTheSession());
        finishSessionText.text = finishSessionString;
    }

    public void finishTheSession()
    {
        //patientInt = next patient
        //if patient is last patient, change scene to apartment
        //dialogue int = 0
        //finalbuttons.SetActive(false)
    }

}
