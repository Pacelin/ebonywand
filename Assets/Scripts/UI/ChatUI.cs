using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ChatUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private TMP_Text _messageTextUI;
	[SerializeField] private Image _messageAuthorImageUI;
	[SerializeField] private Button _openChatButton;
	[SerializeField] private KeyCode _closeChatKeyCode = KeyCode.Mouse0;

	[Header("Animations")]
	[SerializeField] private Animator _animator;
	[SerializeField] private string _openTriggerName;
	[SerializeField] private string _closeTriggerName;
	[SerializeField] private string _newMessageTriggerName;

	[Inject] private Chat _chat;

	private bool _opened;
	private bool _isShowing;

	private void OnEnable()
	{
		_chat.OnNewMessage += Chat_OnNewMessage;
		_openChatButton.onClick.AddListener(Open);
	}
	private void OnDisable()
	{
		_chat.OnNewMessage -= Chat_OnNewMessage;
		_openChatButton.onClick.RemoveListener(Open);
	}

	private void Update()
	{
		if (_opened && Input.GetKeyDown(_closeChatKeyCode))
			Close();
	}

	public void Open()
	{
		if (_isShowing || !_chat.HaveMessages) return;
		StartCoroutine(ShowMessages());
	}

	public void Close()
	{
		_opened = false;
		_animator.SetTrigger(_closeTriggerName);
	}

	private IEnumerator ShowMessages()
	{
		_isShowing = true;
		while (_chat.HaveMessages)
		{
			var message = _chat.PopMessage();
			_messageTextUI.text = message.MessageText;
			_messageAuthorImageUI.sprite = message.AuthorIcon;

			_animator.SetTrigger(_openTriggerName);
			_opened = true;

			yield return new WaitWhile(() => _opened);
			yield return new WaitForSeconds(0.3f);
		}
		_isShowing = false;
	}

	private void Chat_OnNewMessage(ChatMessage message)
	{
		if (_opened) return;
		_animator.SetTrigger(_newMessageTriggerName);
	}
}
