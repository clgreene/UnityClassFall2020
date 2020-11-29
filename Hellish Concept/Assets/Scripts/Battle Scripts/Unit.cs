using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Unit : MonoBehaviour
{

    public string unitName;
    public int unitLevel;
    public int xp;
    public int xpAwarded;
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

    public BattleSystem BS;

    public void Start()
    {
        BS = FindObjectOfType<BattleSystem>();
        attacks = FindObjectOfType<AttackMoves>();
    }

    public void moveOne() 
    {
        if (BS.state != BattleState.PLAYERTURN || BS.state != BattleState.ENEMYTURN) 
        {
            BS.dialogueText.text = "Your Hellspawn isn't ready to attack!";

        } 
        
        attacks.StartCoroutine(moveOneSet);
    }

    public void moveTwo()
    {
        if (BS.state != BattleState.PLAYERTURN || BS.state != BattleState.ENEMYTURN)
        {
            BS.dialogueText.text = "Your Hellspawn isn't ready to attack!";

        }

        attacks.StartCoroutine(moveTwoSet);
    }

    public void moveThree()
    {
        if (BS.state != BattleState.PLAYERTURN || BS.state != BattleState.ENEMYTURN)
        {
            BS.dialogueText.text = "Your Hellspawn isn't ready to attack!";

        }

        attacks.StartCoroutine(moveThreeSet);
    }

    private int[] xpLevels = new int[] 
        { 
            5, 10, 15, 20, 27, 34, 41, 50, 59, 68, 80, 92, 105, 120, 140, 165, 195, 230
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
        currentHP += baseHP + (unitLevel * 2);
        damage = baseDamage + (unitLevel * 2);
        xpAwarded = unitLevel;

    }

    public void resetValues()
    {
        currentHP = HP;
    }

}
