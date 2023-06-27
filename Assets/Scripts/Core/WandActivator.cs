using UnityEngine;
using UnityEngine.Events;

public class WandActivator : MonoBehaviour
{
	public bool IsActive { get; private set; }
	
	[Header("Input")]
	[SerializeField] private KeyCode _activateKeyCode = KeyCode.Mouse0;

	[Header("Settings")]
	[SerializeField] private Vector3 _defaultRotation;
	[SerializeField] private Vector3 _activeRotation;

	[Header("Events")]
	public UnityEvent OnActivate = new UnityEvent();
	public UnityEvent OnDeactivate = new UnityEvent();

	private void Awake()
	{
		transform.rotation = Quaternion.Euler(_defaultRotation);
		IsActive = false;
	}

	private void Update()
	{
        if (Input.GetKeyDown(_activateKeyCode))
        {
			transform.rotation = Quaternion.Euler(_activeRotation);
			IsActive = true;
			OnActivate.Invoke();
        }
		else if (Input.GetKeyUp(_activateKeyCode))
		{
			transform.rotation = Quaternion.Euler(_defaultRotation);
			IsActive = false;
			OnDeactivate.Invoke();
		}
	}
}