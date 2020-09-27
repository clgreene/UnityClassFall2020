using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inventoryUI.activeSelf == true)
        {
            Debug.Log("KeyPressed");
            inventoryUI.SetActive(false);
        }

        else if (Input.GetKeyDown(KeyCode.F) && inventoryUI.activeSelf == false)
        {
            Debug.Log("KeyPressed");
            inventoryUI.SetActive(true);
        }
    }
}
