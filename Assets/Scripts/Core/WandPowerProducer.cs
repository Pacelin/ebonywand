using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class WandPowerProducer : MonoBehaviour
{
	[Inject] private WandActivator _cursor;
	[Inject] private WandPresenter _presenter;

	private Vector3 _previousPosition;

	private void OnMouseEnter()
	{
		_previousPosition = _presenter.transform.position;
	}

	private void OnMouseOver()
	{
		var currentPosition = _presenter.transform.position;
		if (_cursor.IsActive)
		{
			var distance = Vector3.Distance(currentPosition, _previousPosition);
			_presenter.Wand.ProducePower(distance);
		}
		_previousPosition = currentPosition;
	}
}