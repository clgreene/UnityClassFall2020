using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageToPlayer : MonoBehaviour
{
    public IntData playerHealth;
    public float waitTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame


        private IEnumerator OnTriggerEnter(Collider other)
        {
            playerHealth.value = playerHealth.value - 20;
            GetComponent<Collider>().enabled = false;
            yield return new WaitForSeconds(waitTime);
        }
}
