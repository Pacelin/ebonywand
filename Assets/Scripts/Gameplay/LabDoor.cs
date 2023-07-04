using UnityEngine;

public class LabDoor : MonoBehaviour
{
	[SerializeField] private Indicator _indicator;
	[SerializeField] private Collider2D _transferCollider;
	[SerializeField] private bool _activeOnAwake;

	private void Start()
	{
		if (_activeOnAwake) Enable();
		else Disable();
	}

	public void Enable()
	{
		_indicator.Enable();
		_transferCollider.enabled = true;
	}

	public void Disable()
	{
		_indicator.Disable();
		_transferCollider.enabled = false;
	}
}