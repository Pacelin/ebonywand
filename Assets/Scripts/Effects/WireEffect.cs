using PathCreation;
using System;
using System.Collections;
using UnityEngine;

public class WireEffect : MonoBehaviour
{
	public event Action OnEffectStarted;
	public event Action OnEffectEnded;

	[SerializeField] private Transform _powerFollower;
	[SerializeField] private PathCreator _wirePath;
	[SerializeField] private float _powerSpeed;

	[SerializeField] private float _effectDistance;

	private float _currentDistance;

	public void StartEffect()
	{
		StartCoroutine(Effect());
	}

	private IEnumerator Effect()
	{
		_powerFollower.gameObject.SetActive(true);
		OnEffectStarted?.Invoke();

		for (_currentDistance = 0f; _currentDistance < _effectDistance; _currentDistance += Time.deltaTime * _powerSpeed)
		{
			_powerFollower.position = _wirePath.path.GetPointAtDistance(_currentDistance, EndOfPathInstruction.Loop);
			yield return null;
		}

		OnEffectEnded?.Invoke();
		_powerFollower.gameObject.SetActive(false);
	}
}