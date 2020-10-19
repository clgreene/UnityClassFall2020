using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class Unit : ScriptableObject
{

    public string unitName;
    public int unitLevel;
    public int xp;
    public Sprite unitSprite;
    public int unitType;

    public int baseDamage;
    public int damage;
    public int armor;
    public int baseHP;
    public int HP;
    public int baseMana;
    public int mana;

    public int currentHP;

    public Move moveOne;
    public Move moveTwo;
    public Move moveThree;

    public void typeOneMonster()
    {
        
    }

    public void typeTwoMonster()
    {

    }

}
