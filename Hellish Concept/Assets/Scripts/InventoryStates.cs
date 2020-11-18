using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum invState { Main, Hellspawn, Item, Closed }

public class InventoryStates : MonoBehaviour
{

    public invState state;
       
    public GameObject main;
    public GameObject hell;
    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        state = invState.Closed;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case invState.Main:
                main.SetActive(true);
                hell.SetActive(false);
                item.SetActive(false);
                break;

            case invState.Hellspawn:
                main.SetActive(false);
                hell.SetActive(true);
                item.SetActive(false);
                break;

            case invState.Item:
                main.SetActive(false);
                hell.SetActive(false);
                item.SetActive(true);
                break;

            case invState.Closed:
                main.SetActive(false);
                hell.SetActive(false);
                item.SetActive(false);
                break;
        }
    }
}
