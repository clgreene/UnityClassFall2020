using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
	public UnityEvent TriggerStayEvent, TriggerEnterEvent, TriggerExitEvent, TriggerSetEvent;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			TriggerSetEvent.Invoke();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			TriggerStayEvent.Invoke();
			TriggerEnterEvent.Invoke();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Player")) TriggerExitEvent.Invoke();
	}


}
