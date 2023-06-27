using Assets.Scripts.Effects;
using UnityEngine;
using Zenject;

public class WandSwitcher : MonoBehaviour
{
	[SerializeField] private KeyCode _switchKey = KeyCode.Q;
	[SerializeField] private PowerEffects _ebonyPowerEffects;
	[SerializeField] private PowerEffects _glassPowerEffects;

	[Inject] private WandPresenter _wandPresenter;

	private void Update()
	{
		if (Input.GetKeyDown(_switchKey))
		{
			_wandPresenter.SwitchWand();
			if (_wandPresenter.ActiveWand.Data.PowerType == PowerType.Minus)
			{
				_ebonyPowerEffects.gameObject.SetActive(true);
				_glassPowerEffects.gameObject.SetActive(false);
			}
			else
			{
				_glassPowerEffects.gameObject.SetActive(true);
				_ebonyPowerEffects.gameObject.SetActive(false);
			}
		}
	}
}