using UnityEngine;
using Zenject;

public class WandBurster : MonoBehaviour
{
	[SerializeField] private KeyCode _burstKeyCode = KeyCode.Mouse1;

	[Inject] private WandPresenter _wandPresenter;

	private void Update()
	{
		if (Input.GetKeyDown(_burstKeyCode))
			_wandPresenter.ActiveWand.Burst();
	}
}