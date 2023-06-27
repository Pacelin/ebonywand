using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Collider2D))]
public class WandPowerProducer : MonoBehaviour
{
	public static event Action OnStartProduce;
	public static event Action<float> OnProduce;
	public static event Action OnStopProduce;

	[Inject] private WandActivator _activator;
	[Inject] private WandPresenter _presenter;

	private Vector3 _previousPosition;
	private bool _isProduce;

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
			if (!_isProduce)
			{
				_isProduce = true;
				OnStartProduce?.Invoke();
			}
			OnProduce?.Invoke(distance);
		}
		else if (_isProduce)
		{
			_isProduce = false;
			OnStopProduce?.Invoke();
		}
		_previousPosition = currentPosition;
	}

	private void OnMouseExit()
	{
		if (_isProduce)
		{
			_isProduce = false;
			OnStopProduce?.Invoke();
		}
	}
}