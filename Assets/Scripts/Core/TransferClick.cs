using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class TransferClick : MonoBehaviour
{
	[SerializeField] private CameraPoint _transferPoint;

	[Inject] private CameraController _cameraController;
	
	private void OnMouseUpAsButton()
	{
		_cameraController.Transfer(_transferPoint);
	}
}
