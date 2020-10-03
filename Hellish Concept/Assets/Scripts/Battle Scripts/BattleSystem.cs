using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    //calling the hellspawn object and the enemy hellspawn object
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    //calling the positions the hellspawn and enemy should go
    public Transform playerBattleStation;
    public Transform enemyBattleStation;


    unit playerUnit;
    unit enemyUnit;

    public Text dialogueText;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        //placing hellspawn prefab on hellspawn location
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<unit>();

        //placing enemy prefab on enemy location
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<unit>();


        dialogueText.text = "A " + enemyUnit.unitName + "attacks!";
    }

}
