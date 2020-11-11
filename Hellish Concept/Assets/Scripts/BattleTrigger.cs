using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTrigger : MonoBehaviour
{

    public Text actionText;

    public SceneSwitcher SS;

    public BoolData shovel;

    public int scene;

    // Start is called before the first frame update
    void Start()
    {
        actionText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player") && shovel.value == true) actionText.text = "DIG?";

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && other.gameObject.CompareTag("Player") && shovel.value == true)
        {
            SS.SwitchScene(scene);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        actionText.text = "";
    }
}
