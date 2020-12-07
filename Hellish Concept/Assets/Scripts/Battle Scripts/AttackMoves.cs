using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoves : MonoBehaviour
{

    public int damage;
    public int health;
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

        yield return new WaitForSeconds(3f);

        lastAttack = "Bite";
        StartCoroutine(BS.checkDamage());
        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;

        
    }

    IEnumerator LickWounds()
    {

        if (BS.state == BattleState.PLAYERTURN) BS.playerUnitOneMana -= 30;
        if (BS.state == BattleState.ENEMYTURN) BS.enemyUnitOneMana -= 30;

        health = BS.activeUnit.HP / 5;
        BS.activeUnit.currentHP += health;
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        if (BS.activeUnit.currentHP > BS.activeUnit.HP) BS.activeUnit.currentHP = BS.activeUnit.HP;
        BS.dialogueText.text = BS.activeUnit.unitName + " Licked it's wounds and recovered " + health + " hitpoints";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(3f);

        lastAttack = "LickWounds";
        StartCoroutine(BS.checkDamage());
        BS.checkWin();
        BS.state = BattleState.NULL;


    }

    IEnumerator Smash()
    {

        if (BS.state == BattleState.PLAYERTURN) BS.playerUnitOneMana -= 70;
        if (BS.state == BattleState.ENEMYTURN) BS.enemyUnitOneMana -= 70;

        damage = (BS.activeUnit.damage * 90) / 100;
        BS.defendingUnit.currentHP -= ((damage * 40) / 100);
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " Used Smash and dealt " + damage + " damage!";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(3f);

        lastAttack = "Smash";
        StartCoroutine(BS.checkDamage());
        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;

    }

    IEnumerator Regrowth()
    {

        if (BS.state == BattleState.PLAYERTURN) BS.playerUnitOneMana -= 15;
        if (BS.state == BattleState.ENEMYTURN) BS.enemyUnitOneMana -= 15;

        health = BS.activeUnit.HP / 6;
        BS.activeUnit.currentHP += health;
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        if (BS.activeUnit.currentHP > BS.activeUnit.HP) BS.activeUnit.currentHP = BS.activeUnit.HP;
        BS.dialogueText.text = BS.activeUnit.unitName + " regrew itself and recovered " + health + " hitpoints";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(3f);

        lastAttack = "Regrowth";
        StartCoroutine(BS.checkDamage());
        BS.checkWin();
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

            yield return new WaitForSeconds(3f);
            StartCoroutine(BS.checkDamage());
            BS.checkWin();
            BS.state = BattleState.NULL;
        }

        else BS.dialogueText.text = BS.activeUnit.unitName + " can't growl twice in a row!";
    }


    IEnumerator Possess()
    {
        if (BS.state == BattleState.PLAYERTURN)
        {
            BS.playerUnitOneMana -= 30;

        }
        if (BS.state == BattleState.ENEMYTURN)
        {
            BS.enemyUnitOneMana -= 30;

        }

        int damage = (BS.activeUnit.damage * 50) / 100;
        BS.defendingUnit.currentHP -= damage;
        BS.activeUnit.currentHP -= (damage / 4);
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " Possessed it's enemy and dealt " + damage + " damage and " + (damage / 4) + " to itself.";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(3f);

        lastAttack = "Possess";
        StartCoroutine(BS.checkDamage());
        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;

    }

    IEnumerator Haunt()
    {
        if (BS.state == BattleState.PLAYERTURN)
        {
            BS.playerUnitOneMana -= 30;
            BS.overTimeCounterEnemy = 3;
            BS.damageOverTimeEnemy = ((BS.activeUnit.damage * 20) / 100);
            BS.dotAttackEnemy = "Haunt";

        }
        if (BS.state == BattleState.ENEMYTURN)
        {
            BS.enemyUnitOneMana -= 30;
            BS.overTimeCounterPlayer = 3;
            BS.damageOverTimePlayer = ((BS.activeUnit.damage * 20) / 100);
            BS.dotAttackPlayer = "Haunt";
        }

        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " haunts it's enemy...";
        yield return new WaitForSeconds(3f);
        StartCoroutine(BS.checkDamage());
        yield return new WaitForSeconds(3f);
        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;

    }


    IEnumerator SuckBlood()
    {
        if (BS.state == BattleState.PLAYERTURN)
        {
            BS.playerUnitOneMana -= 25;

        }
        if (BS.state == BattleState.ENEMYTURN)
        {
            BS.enemyUnitOneMana -= 25;

        }

        int damage = (BS.activeUnit.damage * 20) / 100;
        BS.defendingUnit.currentHP -= damage;
        BS.activeUnit.currentHP += (damage / 2);
        if (BS.activeUnit.currentHP > BS.activeUnit.HP) BS.activeUnit.currentHP = BS.activeUnit.HP;
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " sucks blood for " + damage + " damage and gains " + (damage / 2) + " health.";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(3f);

        lastAttack = "SuckBlood";
        StartCoroutine(BS.checkDamage());
        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;

    }


    IEnumerator VenomousBite()
    {
        if (BS.state == BattleState.PLAYERTURN)
        {
            BS.playerUnitOneMana -= 25;
            BS.overTimeCounterEnemy = 5;
            BS.damageOverTimeEnemy = ((BS.activeUnit.damage * 15) / 100);
            BS.dotAttackEnemy = "Venom";

        }
        if (BS.state == BattleState.ENEMYTURN)
        {
            BS.enemyUnitOneMana -= 25;
            BS.overTimeCounterPlayer = 5;
            BS.damageOverTimePlayer = ((BS.activeUnit.damage * 15) / 100);
            BS.dotAttackPlayer = "Venom";
        }

        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " poisons it's enemy.";
        yield return new WaitForSeconds(3f);
        StartCoroutine(BS.checkDamage());
        yield return new WaitForSeconds(3f);
        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;
    }

    IEnumerator Stab()
    {


        if (BS.state == BattleState.PLAYERTURN) BS.playerUnitOneMana -= 30;
        if (BS.state == BattleState.ENEMYTURN) BS.enemyUnitOneMana -= 30;


        int damage = (BS.activeUnit.damage * 25) / 100;
        BS.defendingUnit.currentHP -= damage;
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " Stabbed it's foe and dealt " + damage + " damage!";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(3f);

        lastAttack = "Stab";
        StartCoroutine(BS.checkDamage());
        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;

    }

    IEnumerator RepeatedJab()
    {


        if (BS.state == BattleState.PLAYERTURN) BS.playerUnitOneMana -= 5;
        if (BS.state == BattleState.ENEMYTURN) BS.enemyUnitOneMana -= 5;



        int damage = (BS.activeUnit.damage * 10) / 100;
        BS.defendingUnit.currentHP -= damage;
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " Jabs quickly doing " + damage + " damage!";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(2f);

        lastAttack = "repeatedJab";
        StartCoroutine(BS.checkDamage());
        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;

    }

    IEnumerator BreathFire()
    {


        if (BS.state == BattleState.PLAYERTURN) BS.playerUnitOneMana -= 40;
        if (BS.state == BattleState.ENEMYTURN) BS.enemyUnitOneMana -= 40;

        if (BS.state == BattleState.PLAYERTURN)
        {
            BS.playerUnitOneMana -= 50;
            BS.overTimeCounterEnemy = 3;
            BS.damageOverTimeEnemy = ((BS.activeUnit.damage * 15) / 100);
            BS.dotAttackEnemy = "Burn";

        }
        if (BS.state == BattleState.ENEMYTURN)
        {
            BS.enemyUnitOneMana -= 50;
            BS.overTimeCounterPlayer = 3;
            BS.damageOverTimePlayer = ((BS.activeUnit.damage * 15) / 100);
            BS.dotAttackPlayer = "Burn";
        }

        int damage = (BS.activeUnit.damage * 60) / 100;
        BS.defendingUnit.currentHP -= damage;
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " Breaths fire and burns it's foe, dealing " + damage + " damage!";
        BS.playerMoves.SetActive(false);

        yield return new WaitForSeconds(2f);

        lastAttack = "BreathFire";
        StartCoroutine(BS.checkDamage());
        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;
    }








    //The following routines are all the AI logic for enemy battles


        IEnumerator Wyvern()
    {
        yield return new WaitForSeconds(0f);

        if (BS.enemyTurnNumber == 1)
        {
            StartCoroutine(BreathFire());
        }

        else StartCoroutine(Bite());

    }

            
    IEnumerator Gorgon()
    {
        yield return new WaitForSeconds(0f);

        StartCoroutine(RepeatedJab());
    }

    IEnumerator GiantSpider()
    {

        yield return new WaitForSeconds(0f);

        if (BS.enemyTurnNumber == 1)
        {
            StartCoroutine(VenomousBite());

        }

        else StartCoroutine(Stab());


    }

    IEnumerator Skeletal()
    {
        BS.dialogueText.text = "Working?";

        yield return new WaitForSeconds(0f);

        if (BS.activeUnit.currentHP <= 10 && lastAttack != "Regrowth")
        {
            StartCoroutine(Regrowth());
        }

        else StartCoroutine(Bite());
    }

    IEnumerator Ogre()
    {
        yield return new WaitForSeconds(0f);

        StartCoroutine(Smash());
    }

    IEnumerator Leech()
    {
        yield return new WaitForSeconds(0f);

        StartCoroutine(SuckBlood());
    }

}
