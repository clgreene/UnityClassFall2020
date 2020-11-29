using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoves : MonoBehaviour
{

    public int damage;
    public int HP;
    public BattleSystem BS;
    public string lastAttack;

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
        BS.defendingUnit.currentHP -= damage;
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " Used Bite and dealt " + damage + " damage!";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(2f);

        lastAttack = "Bite";
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

        lastAttack = "LickWounds";
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

        lastAttack = "Smash";
        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;

    }

    IEnumerator Regrowth()
    {

        if (BS.state == BattleState.PLAYERTURN) BS.playerUnitOneMana -= 15;
        if (BS.state == BattleState.ENEMYTURN) BS.enemyUnitOneMana -= 15;

        int health = BS.activeUnit.HP / 6;
        BS.activeUnit.currentHP += health;
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        if (BS.activeUnit.currentHP > BS.activeUnit.HP) BS.activeUnit.currentHP = BS.activeUnit.HP;
        BS.dialogueText.text = BS.activeUnit.unitName + " regrew itself and recovered " + health + " hitpoints";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(2f);

        lastAttack = "Regrowth";
        BS.state = BattleState.NULL;

    }

    IEnumerator Growl()
    {
        if (lastAttack != "Growl")
        {
            if (BS.state == BattleState.PLAYERTURN)
            {
                BS.playerUnitOneMana -= 10;
                BS.enemyUnitOneMana -= 20;

            }
            if (BS.state == BattleState.ENEMYTURN)
            {
                BS.enemyUnitOneMana -= 10;
                BS.playerUnitOneMana -= 20;
            }

            BS.activeUnit.damage -= 1;
            BS.dialogueText.text = BS.activeUnit.unitName + "Growls, it's opponent staggers. " + BS.activeUnit.unitName + " attack decreases.";

            yield return new WaitForSeconds(2f);

            BS.state = BattleState.NULL;
        }

        else BS.dialogueText.text = BS.activeUnit.unitName + " can't growl twice in a row!";
    }

    IEnumerator SkeletalAI()
    {
        if (BS.defendingUnit.currentHP <= 10 && lastAttack != "Regrowth")
        {
            Regrowth();

        }

        else Bite();


        yield return new WaitForSeconds(2f);

    }


    
    
}
