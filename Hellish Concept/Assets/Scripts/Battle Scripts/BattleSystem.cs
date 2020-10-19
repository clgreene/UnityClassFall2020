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
    public GameObject playerBattleStationOne;
    public GameObject playerBattleStationTwo;
    public GameObject playerBattleStationThree;

    public GameObject enemyBattleStationOne;
    public GameObject enemyBattleStationTwo;
    public GameObject enemyBattleStationThree;

    //establishing the Unit variables for each monster on the field
    Unit playerUnitOne;
    Unit playerUnitTwo;
    Unit playerUnitThree;
    Unit enemyUnitOne;
    Unit enemyUnitTwo;
    Unit enemyUnitThree;

    //Establish speed check variables for all units
    public float playerUnitOneMana;
    public float playerUnitTwoMana;
    public float playerUnitThreeMana;
    public float enemyUnitOneMana;
    public float enemyUnitTwoMana;
    public float enemyUnitThreeMana;



    //establishing the dialogue text variable
    public Text dialogueText;

    //calling BattleHud Script for each monster on the field
    public BattleHud playerHudOne;
    public BattleHud playerHudTwo;
    public BattleHud playerHudThree;
    public BattleHud enemyHudOne;
    public BattleHud enemyHudTwo;
    public BattleHud enemyHudThree;

    //setting variable for our battlestate enum.
    public BattleState state;



    //Start the SetupBattle Coroutine that will set up all our variables and sprites for our battle.
    void Start()
    {
        state = BattleState.START;
        StartCoroutine (SetupBattle());
        
    }

    private void Update()
    {
        if (state != BattleState.WON || state != BattleState.LOST)
            {
                playerUnitOne.mana ++;
                playerUnitTwo.mana++;
                playerUnitThree.mana++;
                enemyUnitOne.mana++;
                enemyUnitTwo.mana++;
                enemyUnitThree.mana++;
            }
    }

    IEnumerator SetupBattle()
    {
        //setting all speed checkers to 0
        //IN THE FUTURE CREATE  A START MANA VARIABLE IN THE UNIT SCRIPT AND ADD IT TO THIS STARTING SPEED VARIABLE
        playerUnitOneMana = 0;
        playerUnitTwoMana = 0;
        playerUnitThreeMana = 0;
        enemyUnitOneMana = 0;
        enemyUnitTwoMana = 0;
        enemyUnitThreeMana = 0;

        //placing hellspawn prefab on hellspawn location
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStationOne.transform);
        playerUnitOne = playerGO.GetComponent<Unit>();

        //placing enemy prefab on enemy location
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStationOne.transform);
        enemyUnitOne = enemyGO.GetComponent<Unit>();

        //Displaying Opening dialogue text for battle
        dialogueText.text = "A " + enemyUnitOne.unitName + " attacks!";

        //running the SetHUD functions of the battleHud script.
        playerHudOne.SetHUD(playerUnitOne);
        enemyHudOne.SetHUD(enemyUnitOne);

        //wait two seconds
        yield return new WaitForSeconds(2f);

        //change dialogue text
        dialogueText.text = "Kill it with fire!";

        //change battle state and start next function
        state = BattleState.NULL;
        BattleNull();
    }

    void BattleNull()
    {
        while (state == BattleState.NULL)
        {
            playerUnitOneMana += (1 * Time.deltaTime);
            if (playerUnitOneMana >= playerUnitOne.baseMana)
            {
                state = BattleState.PLAYERTURN;
                PlayerOneTurn();
            }

            enemyUnitOneMana += (1 * Time.deltaTime);
            if (enemyUnitOneMana >= enemyUnitOne.baseMana)
            {
                state = BattleState.ENEMYTURN;
                EnemyOneTurn();
            }





        }
    }


    void PlayerOneTurn()
    {

        dialogueText.text = "it's your turn.";
    }

    void EnemyOneTurn()
    {

        dialogueText.text = "It's now the enemies turn.";
    }

    IEnumerator PlayerAttack()
    {
        enemyUnitOne.currentHP -= playerUnitOne.damage;
        yield return new WaitForSeconds(2f);

        if (enemyUnitOne.currentHP <= 0)
        {
            dialogueText.text = "you win";
            Destroy(enemyBattleStationOne);
            state = BattleState.WON;
        }

        else
        {
            state = BattleState.ENEMYTURN;
            EnemyOneTurn();
        }
    }




    //The Following is the GUI functions for the player HUD, allowing for buttons to appear and function.
    public void OnAttackButton()
    {

        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

}
