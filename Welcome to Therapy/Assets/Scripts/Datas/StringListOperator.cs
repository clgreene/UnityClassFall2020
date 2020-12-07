using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class StringListOperator : ScriptableObject
{

    public IntData dialogue;
    public IntData dialogueBranch;
    public StringListData currentList;
    public StringListData currentSpeaker;
    public List<StringListData> stringLists;

    public string dialogueString;
    public string speakerString;
    

    public void SetStringList()
    {
        currentList = stringLists[dialogueBranch.value];

    }

    public void GetNextstring()
    {
        if (Input.GetKeyDown(KeyCode.F) && dialogue.value < currentList.dialogueList.Count - 1)
        {
            dialogue.value += 1;
        }
        dialogueString = currentList.dialogueList[dialogue.value];
        speakerString = currentList.speakerList[dialogue.value];

    }

    public void SetDialToValue(Text dial)
    {
        dial.text = dialogueString;

    }
    public void SetSpeakerToValue(Text speaker)
    {
        speaker.text = speakerString;

        if (dialogue.value == currentList.dialogueList.Count - 1)
        {
            currentList.SetButtons();

        }

    }

    public void EnableButtons(GameObject buttons)
    {
        if (dialogue.value == currentList.dialogueList.Count - 1)
        {
            buttons.SetActive(true);

        }
    }

}
