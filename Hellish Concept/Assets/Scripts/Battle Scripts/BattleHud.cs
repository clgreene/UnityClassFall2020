using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{

    public Text nameText;
    public Text levelText;
    public Slider health;
    public Slider mana;
    public Button moveOne;
    public Text moveOneText;
    public Button moveTwo;
    public Text moveTwoText;
    public Button moveThree;
    public Text moveThreeText;

    public BattleSystem BS;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        levelText.text = "LVL: " + unit.unitLevel;
        moveOne.onClick.AddListener(() => unit.moveOne());
        moveOneText.text = unit.moveOneSet;
        moveTwo.onClick.AddListener(() => unit.moveTwo());
        moveTwoText.text = unit.moveTwoSet;
        moveThree.onClick.AddListener(() => unit.moveThree());
        moveThreeText.text = unit.moveThreeSet;
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
        levelText.text = "LVL: " + unit.unitLevel;
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
        moveTwo.onClick.RemoveAllListeners();
        moveThree.onClick.RemoveAllListeners();
    }

}
