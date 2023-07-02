using System.Collections;
using UnityEngine;
using Zenject;

public class ChatTest : MonoBehaviour
{
	[SerializeField] private ChatMessage[] _messages;
	[Inject] private Chat _chat;

	private IEnumerator Start()
	{
		yield return new WaitForSeconds(3);
		_chat.AddMessages(_messages);
	}
}