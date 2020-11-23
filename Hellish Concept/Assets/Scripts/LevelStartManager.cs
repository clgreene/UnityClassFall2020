using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartManager : MonoBehaviour
{

    public BoolData cantMove;
    public BoolData shovel;

    public IntData BaalDialogue;

    public GameObject battleUI;

    // Start is called before the first frame update
    void Start()
    {
        cantMove.value = false;
        shovel.value = false;
        BaalDialogue.value = 1;
        battleUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
