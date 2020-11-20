using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCharger : MonoBehaviour
{

    public BattleSystem BS;

    private float chargeRate = 0.8f;

    

    private void Start()
    {
        BS.playerUnitOneMana = 0;
        //BS.playerUnitTwoMana = 0;
        //BS.playerUnitThreeMana = 0;
        BS.enemyUnitOneMana = 0;
        //BS.enemyUnitTwoMana = 0;
        //BS.enemyUnitThreeMana = 0;
    }
    private void Update()
    {
        if (BS.state == BattleState.NULL)
        {
            BS.playerUnitOneMana += (BS.playerUnitOne.manaChargeRate * chargeRate * Time.deltaTime);
            //BS.playerUnitTwoMana += (chargeRate * Time.deltaTime);
            //BS.playerUnitThreeMana += (chargeRate * Time.deltaTime);
            BS.enemyUnitOneMana += (BS.enemyUnitOne.manaChargeRate * chargeRate * Time.deltaTime);
            //BS.enemyUnitTwoMana += (chargeRate * Time.deltaTime);
            //BS.enemyUnitThreeMana += (chargeRate * Time.deltaTime);

            if (BS.playerUnitOneMana >= 100)
            {
                BS.activeUnit = BS.playerUnitOne;
                BS.defendingUnit = BS.enemyUnitOne;
                BS.state = BattleState.PLAYERTURN;

            }
            if (BS.enemyUnitOneMana >= 100)
            {
                BS.activeUnit = BS.enemyUnitOne;
                BS.defendingUnit = BS.playerUnitOne;
                BS.state = BattleState.ENEMYTURN;
                BS.enemyOneTurn = true;
            }
        }
        
    }
}
