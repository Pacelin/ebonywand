using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class WandPowerProducer : MonoBehaviour
{
	[Inject] private WandActivator _activator;
	[Inject] private WandPresenter _presenter;

	private Vector3 _previousPosition;

	private void OnMouseEnter()
	{
		_previousPosition = _presenter.transform.position;
	}

	private void OnMouseOver()
	{
		var currentPosition = _presenter.transform.position;
		if (_activator.IsActive)
		{
			var distance = Vector3.Distance(currentPosition, _previousPosition);
			_presenter.ActiveWand.ProducePower(distance);
		}
		_previousPosition = currentPosition;
	}
}