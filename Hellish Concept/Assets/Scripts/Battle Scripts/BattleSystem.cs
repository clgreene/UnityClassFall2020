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

    public GameObject enemyDeath;


    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine (SetupBattle());
        
    }

    IEnumerator SetupBattle()
    {
        //placing hellspawn prefab on hellspawn location
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        //placing enemy prefab on enemy location
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();


        dialogueText.text = "A " + enemyUnit.unitName + " attacks!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        dialogueText.text = "Kill it with fire!";

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {

        dialogueText.text = "it's your turn.";
    }

    void EnemyTurn()
    {

        dialogueText.text = "It's now the enemies turn.";
    }

    IEnumerator PlayerAttack()
    {
        enemyUnit.currentHP -= playerUnit.damage;
        yield return new WaitForSeconds(2f);

        if (enemyUnit.currentHP <= 0)
        {
            dialogueText.text = "you win";
            Destroy(enemyDeath);
            state = BattleState.WON;
        }
        else
        {
            state = BattleState.ENEMYTURN;
            EnemyTurn();
        }
    }

    public void OnAttackButton()
    {

        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

}
