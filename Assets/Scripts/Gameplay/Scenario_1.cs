using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Scenario_1 : MonoBehaviour
{
	[SerializeField] private ChatMessage[] _hiMessages;

	[Inject] private Chat _chat;

	public IEnumerator Start()
	{
		yield return new WaitForSeconds(1);
		_chat.AddMessages(_hiMessages);
	}

}