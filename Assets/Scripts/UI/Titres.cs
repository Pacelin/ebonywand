using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class Titres : MonoBehaviour
{
	[SerializeField] private float _titresTime;
	[SerializeField] private float _minY;
	[SerializeField] private float _maxY;
	[SerializeField] private float _delay;
	[SerializeField] private float _exitDelay;

	private RectTransform _selfRectTransform;

	private IEnumerator Start()
	{
		_selfRectTransform = GetComponent<RectTransform>();
		var pos = _selfRectTransform.anchoredPosition;		

		yield return new WaitForSeconds(_delay);
		for (float t = 0; t < _titresTime; t += Time.deltaTime)
		{
			pos.y = Mathf.Lerp(_minY, _maxY, t / _titresTime);
			_selfRectTransform.anchoredPosition = pos;
			yield return null;
		}
		
		yield return new WaitForSeconds(_exitDelay);
		Application.Quit();
	}
}
