using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaCharger : MonoBehaviour
{

    public BattleSystem BS;

    private float chargeRate = 0.8f;
    public Slider enemyMana;
    public Slider playerMana;

    

    private void Start()
    {
        BS.playerUnitOneMana = 0;
        playerMana.maxValue = 100;
        //BS.playerUnitTwoMana = 0;
        //BS.playerUnitThreeMana = 0;
        BS.enemyUnitOneMana = 0;
        enemyMana.maxValue = 100;
        //BS.enemyUnitTwoMana = 0;
        //BS.enemyUnitThreeMana = 0;
    }
    private void Update()
    {
        if (BS.state == BattleState.NULL)
        {
            BS.playerUnitOneMana += (BS.playerUnitOne.manaChargeRate * chargeRate * Time.deltaTime);
            playerMana.value = BS.playerUnitOneMana;
            //BS.playerUnitTwoMana += (chargeRate * Time.deltaTime);
            //BS.playerUnitThreeMana += (chargeRate * Time.deltaTime);
            BS.enemyUnitOneMana += (BS.enemyUnitOne.manaChargeRate * chargeRate * Time.deltaTime);
            enemyMana.value = BS.enemyUnitOneMana;
            //BS.enemyUnitTwoMana += (chargeRate * Time.deltaTime);
            //BS.enemyUnitThreeMana += (chargeRate * Time.deltaTime);

            if (BS.playerUnitOneMana >= 100)
            {
                BS.activeUnit = BS.playerUnitOne;
                BS.defendingUnit = BS.enemyUnitOne;
                BS.dialogueText.text = "It's your turn.";
                BS.playerMoves.SetActive(true);
                BS.state = BattleState.PLAYERTURN;

            }
            if (BS.enemyUnitOneMana >= 100)
            {
                BS.activeUnit = BS.enemyUnitOne;
                BS.defendingUnit = BS.playerUnitOne;
                BS.state = BattleState.ENEMYTURN;
                BS.activeUnit.AI();
            }
        }
        
    }
}
