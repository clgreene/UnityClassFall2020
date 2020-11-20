using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{

    public string unitName;
    public int unitLevel;
    public int xp;
    public Sprite unitSprite;


    public int baseDamage;
    public int damage;
    public int armor;
    public int baseHP;
    public int HP;
    public int baseMana;
    public int mana;
    public int manaChargeRate;

    public int currentHP;

    public string moveOneSet;
    public string moveTwoSet;
    public string moveThreeSet;

    public MonoBehaviour attacks;

    public void moveOne() 
    {
        attacks.StartCoroutine(moveOneSet);
    }

    public void moveTwo()
    {

    }

    public void moveThree()
    {

    }

    private int[] xpLevels = new int[] 
        { 
            5, 10, 15, 20, 27, 34, 41, 50, 59, 68, 80, 92, 105, 120
        };


    public void checkLevel()
    {
        for (int i = 0; i < 50; i++)
        {
            if (xp < xpLevels[i])
            {
                unitLevel = i+1;
                setValues();
                break;
            }
        }
    }

    public void setValues()
    {
        HP = baseHP + (unitLevel * 2);
        damage = baseDamage + unitLevel;

    }

    public void resetValues()
    {
        currentHP = HP;
    }

    public void attackOne()
    {

    }


    public void typeOneMonster()
    {
        
    }

    public void typeTwoMonster()
    {

    }

}
