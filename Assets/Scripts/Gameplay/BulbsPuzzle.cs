using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BulbsPuzzle : MonoBehaviour 
{
	public UnityEvent OnSolve = new UnityEvent();

	[SerializeField] private Bulb[] _bulbs;
	[SerializeField] private Indicator[] _indicators;
	[SerializeField] private float _solutionDelay;
	[Header("Solutions")]
	[SerializeField] private BulbsPuzzleSolution[] _solutions;

	private int _currentSolution = 0;

	private void OnEnable()
	{
		foreach (var bulb in _bulbs)
		{
			bulb.OnEnable += CheckSolution;
			bulb.OnDisable += CheckSolution;
		}
	}
	private void OnDisable()
	{
		foreach (var bulb in _bulbs)
		{
			bulb.OnEnable -= CheckSolution;
			bulb.OnDisable -= CheckSolution;
		}
	}

	private void CheckSolution()
	{
		for (int i = 0; i < _bulbs.Length; i++)
			if (_bulbs[i].Enabled != _solutions[_currentSolution].BulbsActives[i])
				return;
		StartCoroutine(DelayedSolve());
	}

	private IEnumerator DelayedSolve()
	{
		yield return new WaitForSeconds(_solutionDelay);
		
		_indicators[_currentSolution].Enable();
		_currentSolution++;

		foreach (var bulb in _bulbs)
			bulb.DisableWithoutNotify(0);

		if (_currentSolution >= _indicators.Length)
		{
			OnSolve.Invoke();
			this.enabled = false;
		}
	}
}

[System.Serializable]
public class BulbsPuzzleSolution
{
	public bool[] BulbsActives;
}