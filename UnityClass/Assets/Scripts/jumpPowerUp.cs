using System.Collections;
using UnityEngine;

public class jumpPowerUp : MonoBehaviour
{
    public IntData playerJumpCount, powerUpCount, normalJumpCount;
    public float waitTime = 4f;

    private void Start()
    {
        playerJumpCount.value = normalJumpCount.value;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    playerJumpCount.value = powerUpCount.value;
    //}

    private IEnumerator OnTriggerEnter(Collider other)
    {
        playerJumpCount.value = powerUpCount.value;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(waitTime);
        playerJumpCount.value = normalJumpCount.value;
        gameObject.SetActive(false);
    }

}
