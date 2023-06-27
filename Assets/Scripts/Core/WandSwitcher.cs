using UnityEngine;
using Zenject;

public class WandSwitcher : MonoBehaviour
{
	[SerializeField] private KeyCode _switchKey = KeyCode.Q;

	[Inject] private WandPresenter _wandPresenter;

	private void Update()
	{
		if (Input.GetKeyDown(_switchKey))
			_wandPresenter.SwitchWand();
	}
}