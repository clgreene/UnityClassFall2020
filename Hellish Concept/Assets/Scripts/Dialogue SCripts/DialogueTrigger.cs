using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
	public UnityEvent TriggerStayEvent, TriggerEnterEvent, TriggerExitEvent;

	private void OnTriggerStay(Collider other)
	{
		TriggerStayEvent.Invoke();
		TriggerEnterEvent.Invoke();
	}

	private void OnTriggerExit(Collider other)
	{
		TriggerExitEvent.Invoke();
	}


}
