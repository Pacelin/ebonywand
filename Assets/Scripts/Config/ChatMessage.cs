using UnityEngine;

[CreateAssetMenu]
public class ChatMessage : ScriptableObject
{
	public Sprite AuthorIcon => _authorIcon;
	public string MessageText => _messageText;

	[SerializeField] private Sprite _authorIcon;
	[TextArea(3, 10)] [SerializeField] private string _messageText;
}