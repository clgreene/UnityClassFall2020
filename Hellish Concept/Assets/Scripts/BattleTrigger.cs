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

    public string text;

    public Camera cam1, cam2;
    public GameObject dialogue;
    public GameObject battleUI;
    public BattleSystem BS;

    public BoolData cantMove;

    public GameObject battleEnemy;

    // Start is called before the first frame update
    void Start()
    {
        actionText.text = "";
        cam1.enabled = true;
        cam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player") && shovel.value == true) actionText.text = text;

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F) && other.gameObject.CompareTag("Player") && shovel.value == true)
        {
            cam1.enabled = false;
            cam2.enabled = true;
            dialogue.SetActive(false);
            battleUI.SetActive(true);
            BS.enemyPrefab = battleEnemy;
            BS.StartBattle();
            cantMove.value = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        actionText.text = "";
    }
}
