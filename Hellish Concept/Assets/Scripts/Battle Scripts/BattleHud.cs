using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{

    public Text nameText;
    public Slider health;
    public Slider mana;
    public Button moveOne;
    public Text moveOneText;
    public Button moveTwo;
    public Button moveThree;

    public BattleSystem BS;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        moveOne.onClick.AddListener(() => unit.moveOne());
        moveOneText.text = unit.moveOneSet;
        health.maxValue = unit.HP;
        SetHP(unit);
        
        //mana.maxValue = 100;
        //mana.value = BS.playerUnitOneMana;
        //levelText.text = "lvl" + unit.unitLevel;
        //hpSlider.maxValue = unit.maxHP;
        //hpSlider.value = unit.currentHP;
    }

    public void SetEnemyHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        unit.setValues();
        unit.currentHP = unit.HP;
        health.maxValue = unit.HP;
        SetHP(unit);
    }

    public void SetHP(Unit unit)
    {

        health.value = unit.currentHP;
    }

    public void closeHUD()
    {

        moveOne.onClick.RemoveAllListeners();
    }

}
