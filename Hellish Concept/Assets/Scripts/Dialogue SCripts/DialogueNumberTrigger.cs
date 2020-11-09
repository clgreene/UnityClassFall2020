using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNumberTrigger : MonoBehaviour
{

    public IntData dialogue;
    public StringListData currentList;
    public StringListData listOne;
    public StringListData listTwo;
    public StringListData listThree;
    public StringListData listFour;
    public StringListData listFive;
    public StringListData listSix;
    public StringListData listSeven;
    public StringListData listEight;
    public StringListData listNine;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (dialogue.value)
            {
                case 1:
                    currentList = listOne;
                    break;
                case 2:
                    currentList = listTwo;
                    Debug.Log("HEY");
                    break;
                case 3:
                    currentList = listThree;
                    break;
                case 4:
                    currentList = listFour;
                    break;
                case 5:
                    currentList = listFive;
                    break;
            }
        }
    }

}
