using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoves : MonoBehaviour
{

    public int damage;
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


        int damage = BS.activeUnit.damage;
        BS.defendingUnit.currentHP -= ((damage * 40) / 100);
        BS.enemyHudOne.SetHP(BS.enemyUnitOne);
        BS.playerHudOne.SetHP(BS.playerUnitOne);
        BS.dialogueText.text = BS.activeUnit.unitName + " Used Bite!";
        yield return new WaitForSeconds(2f);
        BS.checkWin();
        if (BS.state == BattleState.WON) BS.StartCoroutine("youWin"); // start function for win state
        else if (BS.state == BattleState.LOST) BS.StartCoroutine("youLose"); // start function for loss state
        else BS.state = BattleState.NULL;
        BS.playerMoves.SetActive(false);


        
        
    }


    
    
}
