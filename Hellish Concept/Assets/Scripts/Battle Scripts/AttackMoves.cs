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
        BS.activeUnit.mana -= 40;
        int damage = BS.activeUnit.damage;
        BS.defendingUnit.HP -= (damage * 40);
        BS.dialogueText.text = BS.activeUnit.unitName + " Used Bite!";
        yield return new WaitForSeconds(2f);
    }
    
    
}
