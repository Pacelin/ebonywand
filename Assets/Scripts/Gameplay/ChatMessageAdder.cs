using System.Collections;
using UnityEngine;
using Zenject;

public class ChatMessageAdder : MonoBehaviour
{
	[SerializeField] private ChatMessage[] _messages;

	[Inject] private Chat _chat;

	public void ApplyAdding(float delay) =>
		StartCoroutine(Adding(delay));

	private IEnumerator Adding(float delay)
	{
		yield return new WaitForSeconds(delay);
		_chat.AddMessages(_messages);
	}
}