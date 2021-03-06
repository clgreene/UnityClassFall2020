﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class StringListData : ScriptableObject
{

    public List<string> dialogueList;
    public List<string> speakerList;

    public ButtonManager buttonManager;

    public string buttonOneString;
    public string buttonTwoString;

    public int branchOne;
    public int branchTwo;
    public IntData branchInt;
    public IntData dialogueInt;

    public string finishButtonString;


    public void SetButtons()
    {
        buttonManager = FindObjectOfType<ButtonManager>();
        buttonManager.SetButtons(branchOne, branchTwo, buttonOneString, buttonTwoString, branchInt, dialogueInt);

    }

    public void SetFinalButtons()
    {
        buttonManager = FindObjectOfType<ButtonManager>();
        buttonManager.SetFinalButtons(finishButtonString);
        //setting buttons that define the end of a conversation, or move on to the next conversation.
    }


}
