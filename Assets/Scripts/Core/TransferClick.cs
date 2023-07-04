using UnityEngine;
using UnityEngine.Events;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class TransferClick : MonoBehaviour
{
	[SerializeField] private CameraPoint _transferPoint;
	
	public UnityEvent OnTransfer;

	[Inject] private CameraController _cameraController;
	
	private void OnMouseUpAsButton()
	{
		OnTransfer.Invoke();
		_cameraController.Transfer(_transferPoint);
	}
}
