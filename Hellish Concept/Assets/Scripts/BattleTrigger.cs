﻿using System.Collections;
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

    public GameObject battleUI;
    public BattleSystem BS;

    public GameObject battleEnemy;

    public int xp;

    // Start is called before the first frame update
    void Start()
    {
        actionText.text = "";
        BS.mainCam = cam1;
        BS.battleCam = cam2;
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
        if (Input.GetKeyDown(KeyCode.F) && other.gameObject.CompareTag("Player") && shovel.value == true && !battleUI.activeSelf)
        {
            cam1.enabled = false;
            cam2.enabled = true;
            battleUI.SetActive(true);
            battleEnemy.GetComponent<Unit>().xp = xp;
            BS.enemyPrefab = battleEnemy;
            BS.StartBattle();
            BS.cantMove.value = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        actionText.text = "";
    }
}
