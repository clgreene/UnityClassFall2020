using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This Script is a basic Pokemon or Final Fantasy style Turn Based battlesystem script, progressing through battle phases and actions. This script is moderately heavy, needing several other scripts and objects to function.
//This script utilizes assets of scriptable objects, prefabs, and other scripts.
//


//Battlesystem first sets up the battlefield, then everyones mana begins to count up. Attacks are activated once the Units Mana is higher than their moves requirement. 


//creating a BattleState enumerator to track what battle phase we are in so we can determine what player functions are possible.
public enum BattleState { START, PLAYERTURN, ENEMYTURN, NULL, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    //calling the hellspawn object and the enemy hellspawn object
    //PLAYERPREFAB NEEDS TO CHANGE FROM CALLING FROM THE PREFAB LIST TO CALLING FROM THE PLAYERS INVENTORY!!!
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    //calling the positions the hellspawn and enemy should go
    //NEED TO FIGURE OUT HOW TO GET RID OF POSITIONS THAT DON'T HAVE HELLSPAWNS
    public GameObject playerBattleStationOne;
    //public GameObject playerBattleStationTwo;
    //public GameObject playerBattleStationThree;

    public GameObject enemyBattleStationOne;
    //public GameObject enemyBattleStationTwo;
    //public GameObject enemyBattleStationThree;

    //establishing the Unit variables for each monster on the field
    public Unit playerUnitOne;
    //public Unit playerUnitTwo;
    //public Unit playerUnitThree;
    public Unit enemyUnitOne;
    //public Unit enemyUnitTwo;
    //public Unit enemyUnitThree;

    //Establish speed check variables for all units
    public float playerUnitOneMana;
    //public float playerUnitTwoMana;
    //public float playerUnitThreeMana;
    public float enemyUnitOneMana;
    //public float enemyUnitTwoMana;
    //public float enemyUnitThreeMana;



    //establishing the dialogue text variable
    public Text dialogueText;

    //calling BattleHud Script for each monster on the field
    public BattleHud playerHudOne;
    //public BattleHud playerHudTwo;
    //public BattleHud playerHudThree;
    public BattleHud enemyHudOne;
    //public BattleHud enemyHudTwo;
    //public BattleHud enemyHudThree;

    //setting variable for our battlestate enum.
    public BattleState state;

    public Inventory inv;

    public Unit activeUnit;
    public Unit defendingUnit;

    public bool playerOneTurn;
    public bool enemyOneTurn;



    //Start the SetupBattle Coroutine that will set up all our variables and sprites for our battle.
    public void StartBattle()
    {

        state = BattleState.START;
        playerPrefab = inv.units[0];
        enemyPrefab.GetComponent<Unit>().checkLevel();
        playerOneTurn = false;
        enemyOneTurn = false;
        StartCoroutine (SetupBattle());
        
    }

    

    IEnumerator SetupBattle()
    {
        //setting all speed checkers to 0
        //IN THE FUTURE CREATE  A START MANA VARIABLE IN THE UNIT SCRIPT AND ADD IT TO THIS STARTING SPEED VARIABLE
        playerUnitOneMana = 0;
        //playerUnitTwoMana = 0;
        //playerUnitThreeMana = 0;
        enemyUnitOneMana = 0;
        //enemyUnitTwoMana = 0;
        //enemyUnitThreeMana = 0;

        //placing hellspawn prefab on hellspawn location
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStationOne.transform);
        playerUnitOne = playerGO.GetComponent<Unit>();

        //placing enemy prefab on enemy location
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStationOne.transform);
        enemyUnitOne = enemyGO.GetComponent<Unit>();

        //Displaying Opening dialogue text for battle
        //dialogueText.text = "A " + enemyUnitOne.unitName + " attacks!";

        //running the SetHUD functions of the battleHud script.
        //playerHudOne.SetHUD(playerUnitOne);
        //enemyHudOne.SetHUD(enemyUnitOne);

        //wait two seconds
        yield return new WaitForSeconds(0f);

        //change dialogue text
        //dialogueText.text = "Kill it with fire!";


        StartCoroutine(SetupHUD());
        //change battle state and start next function
        state = BattleState.NULL;
        
    }

    IEnumerator SetupHUD()
    {
        playerHudOne.SetHUD(playerUnitOne);
        enemyHudOne.SetHUD(enemyUnitOne);
        dialogueText.text = "A " + enemyUnitOne.unitName + "Is attacking!";
        yield return new WaitForSeconds(0f);
    }

     





    //The Following is the GUI functions for the player HUD, allowing for buttons to appear and function.
    public void MoveOneButton()
    {

        if (state != BattleState.PLAYERTURN)
            return;

        playerUnitOne.moveOne();
        state = BattleState.NULL;
        
    }

}
