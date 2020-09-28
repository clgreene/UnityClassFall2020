using UnityEngine;

public class TutorialDialogue : MonoBehaviour
{

    public GameObject tutorialOne;
    public BoolData dialogue;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorialOne.SetActive(true);
            dialogue.value = true;
            
            gameObject.SetActive(false);
        }
    }
}
