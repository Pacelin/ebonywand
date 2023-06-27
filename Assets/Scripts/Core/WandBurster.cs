using UnityEngine;
using Zenject;

public class WandBurster : MonoBehaviour
{
	[SerializeField] private KeyCode _burstKeyCode = KeyCode.Mouse1;
	[SerializeField] private float _chargeDistance;

	[Inject] private WandPresenter _wandPresenter;

	private void OnEnable() =>
		_wandPresenter.OnWandBurst.AddListener(Charge);
	private void OnDisable() =>
		_wandPresenter.OnWandBurst.RemoveListener(Charge);

	private void Update()
	{
		if (Input.GetKeyDown(_burstKeyCode))
			_wandPresenter.ActiveWand.Burst();
	}

	private void Charge()
	{
		var point = _wandPresenter.transform.position;
		var colliders = Physics2D.OverlapCircleAll(point, _chargeDistance);

		foreach (var collider in colliders)
			if (collider.TryGetComponent<ChargableObject>(out var chargableObject))
				chargableObject.Charge(_wandPresenter.ActiveWand.Data.PowerType);
	}
}