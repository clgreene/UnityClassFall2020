using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    public InventoryStates invStates;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (invStates.state == invState.Closed) invStates.state = invState.Main;
            else invStates.state = invState.Closed;
        }

    }

    public void seeHellspawns()
    {
        invStates.state = invState.Hellspawn;
    }

    public void seeItems()
    {
        invStates.state = invState.Item;
    }

    public void back()
    {
        invStates.state = invState.Main;
    }
}