
using UnityEngine;

public class DialogueDebugCheck : MonoBehaviour
{

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Hello Hell!");
        }
                
        
    }
}
