using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    

    public GameObject hellspawnPrefab;
    public GameObject inventory;
    
    public List<GameObject> units;
    public List<Item> items;

    public Text HSone;
    public Text HStwo;
    public Text HSthree;

    public Unit oldHS;
    public Unit first;
    public Unit second;
    public Unit third;

    public int position;
    


    public void addUnit(GameObject hellspawn)
    {
        
        GameObject newHellspawn = Instantiate(hellspawnPrefab, inventory.transform, false);

        oldHS = hellspawn.GetComponent<Unit>();

        newHellspawn.GetComponent<Unit>().unitName = oldHS.unitName;
        newHellspawn.GetComponent<Unit>().unitLevel = oldHS.unitLevel;
        newHellspawn.GetComponent<Unit>().xp = oldHS.xp;
        newHellspawn.GetComponent<Unit>().unitSprite = oldHS.unitSprite;
        newHellspawn.GetComponent<Unit>().baseDamage = oldHS.baseDamage;
        newHellspawn.GetComponent<Unit>().damage = oldHS.damage;
        newHellspawn.GetComponent<Unit>().armor = oldHS.armor;
        newHellspawn.GetComponent<Unit>().baseHP = oldHS.baseHP;
        newHellspawn.GetComponent<Unit>().HP = oldHS.HP;
        newHellspawn.GetComponent<Unit>().baseMana = oldHS.baseMana;
        newHellspawn.GetComponent<Unit>().mana = oldHS.mana;
        newHellspawn.GetComponent<Unit>().manaChargeRate = oldHS.manaChargeRate;
        newHellspawn.GetComponent<Unit>().currentHP = oldHS.currentHP;
        newHellspawn.GetComponent<Unit>().moveOneSet = oldHS.moveOneSet;
        newHellspawn.GetComponent<Unit>().moveTwoSet = oldHS.moveTwoSet;
        newHellspawn.GetComponent<Unit>().moveThreeSet = oldHS.moveThreeSet;

        newHellspawn.GetComponent<Unit>().setValues();
        newHellspawn.GetComponent<Unit>().resetValues();


        units.Add(newHellspawn);

        //position = units.BinarySearch(hellspawn);
        //displayHellspawns();
    }

    public void addItem(Item item)
    {
        items.Add(item);
    }

    public void displayHellspawns()
    {
        


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
