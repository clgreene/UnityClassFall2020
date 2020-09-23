using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickup : MonoBehaviour
{

    public IntData healthInt;

    private void OnTriggerEnter(Collider other)
    {
        healthInt.value += 50;
        gameObject.SetActive(false);

    }
}
