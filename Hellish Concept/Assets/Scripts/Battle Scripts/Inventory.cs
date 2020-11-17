using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Unit> units;
    public List<Item> items;
    


    public void addUnit(Unit hellspawn)
    {
        units.Add(hellspawn);
    }

    public void addItem(Item item)
    {
        items.Add(item);
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
