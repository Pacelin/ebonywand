using System;
using System.Collections.Generic;
using UnityEngine;

public class Chat
{
	public event Action<ChatMessage> OnNewMessage;

	public bool HaveMessages { get; private set; }

	private Queue<ChatMessage> _messages;

	public Chat()
	{
		_messages = new Queue<ChatMessage>();
		HaveMessages = false;
	}

	public void AddMessage(ChatMessage message)
	{
		_messages.Enqueue(message);
		HaveMessages = true;
		OnNewMessage?.Invoke(message);
	}
	public void AddMessages(ChatMessage[] messages)
	{
		foreach (ChatMessage message in messages) 
			AddMessage(message);
	}

	public ChatMessage PopMessage()
	{
		if (!HaveMessages)
			throw new Exception("No Messages");

		HaveMessages = _messages.Count > 1;

		return _messages.Dequeue();
	}
}
