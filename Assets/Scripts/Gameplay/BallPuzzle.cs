using System.Collections;
using UnityEngine;
using Zenject;

public class BallPuzzle : MonoBehaviour
{	
	[SerializeField] private float _delay;
	[Space]
	[SerializeField] private LabDoor _disableDoor;
	[SerializeField] private CameraPoint _nextLocation;
	[Space]
	[SerializeField] private ChatMessage[] _messages;

	[Inject] private Chat _chat;
	[Inject] private CameraController _cameraController;

	public void Complete() => StartCoroutine(Completing());

	private IEnumerator Completing()
	{
		_disableDoor.Disable();
		yield return new WaitForSeconds(_delay);

		_cameraController.Transfer(_nextLocation);

		yield return new WaitForSeconds(1);
		_chat.AddMessages(_messages);
	}
}