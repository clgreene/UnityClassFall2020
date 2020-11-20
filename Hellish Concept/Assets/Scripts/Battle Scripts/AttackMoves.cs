using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMoves : MonoBehaviour
{

    public Unit unit;
    public int damage;
    public BattleSystem BS;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    IEnumerator Bite()
    {
        
        Debug.Log("HELLO!");
        BS = FindObjectOfType<BattleSystem>();

        if (BS.state != BattleState.PLAYERTURN)
        {
            BS.dialogueText.text = "Your Hellspawn isn't ready to attack!";
            yield return new WaitForSeconds(0f);
        }

        else
        {
            BS.playerUnitOneMana -= 40;
            int damage = BS.activeUnit.damage;
            BS.enemyUnitOne.HP -= (damage * 40);
            BS.dialogueText.text = BS.activeUnit.unitName + " Used Bite!";
            BS.state = BattleState.NULL;
            yield return new WaitForSeconds(2f);
        }
        
        
    }


    
    
}
