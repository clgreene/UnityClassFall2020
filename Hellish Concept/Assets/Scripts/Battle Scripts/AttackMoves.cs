using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoves : MonoBehaviour
{

    public int damage;
    public int HP;
    public BattleSystem BS;

    // Start is called before the first frame update
    void Start()
    {
        BS = FindObjectOfType<BattleSystem>();
    }



    IEnumerator Bite()
    {

        
        if (BS.state == BattleState.PLAYERTURN) BS.playerUnitOneMana -= 40;
        if (BS.state == BattleState.ENEMYTURN) BS.enemyUnitOneMana -= 40;


        int damage = (BS.activeUnit.damage * 40) / 100;
        BS.defendingUnit.currentHP -= ((damage * 40) / 100);
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " Used Bite and dealt " + damage + " damage!";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(2f);

        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;



        
        
    }

    IEnumerator LickWounds()
    {

        if (BS.state == BattleState.PLAYERTURN) BS.playerUnitOneMana -= 30;
        if (BS.state == BattleState.ENEMYTURN) BS.enemyUnitOneMana -= 30;

        int health = BS.activeUnit.HP / 5;
        BS.activeUnit.currentHP += health;
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        if (BS.activeUnit.currentHP > BS.activeUnit.HP) BS.activeUnit.currentHP = BS.activeUnit.HP;
        BS.dialogueText.text = BS.activeUnit.unitName + " Licked it's wounds and recovered " + health + " hitpoints";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(2f);

        BS.state = BattleState.NULL;


    }

    IEnumerator Smash()
    {

        if (BS.state == BattleState.PLAYERTURN) BS.playerUnitOneMana -= 70;
        if (BS.state == BattleState.ENEMYTURN) BS.enemyUnitOneMana -= 70;

        int damage = (BS.activeUnit.damage * 90) / 100;
        BS.defendingUnit.currentHP -= ((damage * 40) / 100);
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " Used Smash and dealt " + damage + " damage!";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(2f);

        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;

    }

    IEnumerator SkeletalAI()
    {


        yield return new WaitForSeconds(2f);

    }


    
    
}
