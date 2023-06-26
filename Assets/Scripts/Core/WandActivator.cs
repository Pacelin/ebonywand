using UnityEngine;
using UnityEngine.UIElements;

public class WandActivator : MonoBehaviour
{
	public bool IsActive { get; private set; }
	
	[SerializeField] private Vector3 _defaultRotation;
	[SerializeField] private Vector3 _activeRotation;

	private void Awake()
	{
		transform.rotation = Quaternion.Euler(_defaultRotation);
		IsActive = false;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown((int) MouseButton.LeftMouse))
		{
			transform.rotation = Quaternion.Euler(_activeRotation);
			IsActive = true;
		}

		else if (Input.GetMouseButtonUp((int) MouseButton.LeftMouse))
		{
			transform.rotation = Quaternion.Euler(_defaultRotation);
			IsActive = false;
		}
	}
}