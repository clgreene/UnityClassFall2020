using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatGymLeader : MonoBehaviour
{

    public Text dialogue;
    public BoolData levelWin;

    IEnumerator behaviour()
    {

        levelWin.value = true;
        dialogue.text = "You've beat me... Fine, here's the key to escape Limbo...";
        yield return new WaitForSeconds(1f);



    }

    // Start is called before the first frame update
    void Start()
    {
        levelWin.value = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
