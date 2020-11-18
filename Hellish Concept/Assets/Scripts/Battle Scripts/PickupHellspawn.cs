using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHellspawn : MonoBehaviour
{

    public Inventory inv;

    private void OnTriggerEnter(Collider other)
    {
        inv.addUnit(gameObject);
        Object.Destroy(gameObject);

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
