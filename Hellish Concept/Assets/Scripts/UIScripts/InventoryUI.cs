using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inventoryUI.activeSelf == true)
        {
            inventoryUI.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.E) && inventoryUI.activeSelf == false)
        {
            inventoryUI.SetActive(true);
        }
    }
}
