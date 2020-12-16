using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitLevelScript : MonoBehaviour
{


    public BoolData beatLeader;
    public Text dialogue;


    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && beatLeader.value == false)
        {
            dialogue.text = "The portal to the next circle of Hell seems locked...";
        }

        if (other.gameObject.CompareTag("Player") && beatLeader.value == true)
        {

            dialogue.text = "...F...";

            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(2);
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
