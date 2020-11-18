using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    public GameObject hellspawnPrefab;
    public GameObject inventory;
    
    public List<GameObject> units;
    public List<Item> items;

    public Text HSone;
    public Text HStwo;
    public Text HSthree;

    public Unit newHS;
    public Unit oldHS;
    public Unit first;
    public Unit second;
    public Unit third;

    public int position;
    


    public void addUnit(GameObject hellspawn)
    {
        
        GameObject newHellspawn = Instantiate(hellspawnPrefab, inventory.transform, false);

        oldHS = hellspawn.GetComponent<Unit>();
        
        //oldHS.exportValues();

        //newHellspawn.GetComponent<Unit>().importValues();


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
