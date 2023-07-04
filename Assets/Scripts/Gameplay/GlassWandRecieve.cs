using System.Collections;
using UnityEngine;
using Zenject;

public class GlassWandRecieve : MonoBehaviour
{
	[SerializeField] private WandSwitcher _wandSwitcher;
	[Space]
	[SerializeField] private CameraPoint _nextLocation;
	[Space]
	[SerializeField] private Animator _animator;
	[SerializeField] private string _animationTrigger;
	[Space]
	[SerializeField] private ChatMessage[] _messages;
	[Space]
	[SerializeField] private LabDoor _disableDoor;
	[SerializeField] private LabDoor _enableDoor;

	[Inject] private CameraController _cameraController;
	[Inject] private Chat _chat;

	public void EnableWand(float delay) => StartCoroutine(Enabling(delay));

	private IEnumerator Enabling(float delay)
	{
		_disableDoor.Disable();
		_enableDoor.Enable();
		yield return new WaitForSeconds(delay);

		_animator.SetTrigger(_animationTrigger);
		yield return new WaitForSeconds(1.5f);
		
		_wandSwitcher.EnableGlassWand();
		_cameraController.Transfer(_nextLocation);
		yield return new WaitForSeconds(1f);
		_chat.AddMessages(_messages);
	}
}
