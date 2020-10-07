using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{

    public Text nameText;
    public Slider hpSlider;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        //levelText.text = "lvl" + unit.unitLevel;
        //hpSlider.maxValue = unit.maxHP;
        //hpSlider.value = unit.currentHP;
    }

    public void SetHP(int hp)
    {

        //hpSlider.value = hp;
    }

}
