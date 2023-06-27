using UnityEngine;

public class ChargeEffects : MonoBehaviour
{
	private PowerType _currentChargeEffects = PowerType.No;

	public void SetEffects(PowerType powerType)
	{
		if (powerType == _currentChargeEffects) return;

		if (powerType == PowerType.No) DisableEffects();
		else if (powerType == PowerType.Plus) EnablePlus();
		else if (powerType == PowerType.Minus) EnableMinus();
	}

	private void DisableEffects()
	{

	}

	private void EnablePlus()
	{

	}

	private void EnableMinus()
	{

	}
}