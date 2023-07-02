using UnityEngine;

public class ChargeEffects : MonoBehaviour
{
	[SerializeField] private GameObject _plusEffects;
	[SerializeField] private GameObject _minusEffects;

	public void SetEffects(PowerType powerType) =>
		SetEffects(powerType == PowerType.Plus, powerType == PowerType.Minus);

	private void SetEffects(bool plus, bool minus)
	{
		_plusEffects.SetActive(plus);
		_minusEffects.SetActive(minus);
	}
}