using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveUpdate : MonoBehaviour
{

    public Text objectiveText;
    public StringListOperator objectives;
    public IntData dialogue;


    // Start is called before the first frame update
    void Start()
    {
        dialogue.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        objectiveText.text = objectives.currentList.stringList[dialogue.value];
    }
}
