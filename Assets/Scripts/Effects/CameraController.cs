using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour 
{
	public CameraPoint CurrentPoint { get; private set; }

	[SerializeField] private Camera _camera;
	[SerializeField] private float _cameraZ;
	[SerializeField] private Image _fadeImage;

	[SerializeField] private AnimationCurve _fadeCurve;
	[SerializeField] private AnimationCurve _transferCurve;
	[SerializeField] private float _transferTime;

	[SerializeField] private CameraPoint _firstPoint;

	private bool _isAnimating;

	private void Start()
	{
		_camera.transform.position = GetPointPosition(_firstPoint);
		CurrentPoint = _firstPoint;
	}

	public void Transfer(CameraPoint point)
	{
		if (_isAnimating) return;
		StartCoroutine(Transfering(point));
	}

	private IEnumerator Transfering(CameraPoint point)
	{
		_isAnimating = true;
		var from = GetPointPosition(CurrentPoint);
		var to = GetPointPosition(point);
		
		for (float t = 0; t < _transferTime; t += Time.deltaTime)
		{
			var delta = t / _transferTime;
			var pos = Vector3.Lerp(from, to, _transferCurve.Evaluate(delta));

			_camera.transform.position = pos;
			_fadeImage.color = Color.Lerp(Color.clear, Color.black, _fadeCurve.Evaluate(delta));
			
			yield return null;
		}

		_camera.transform.position = to;
		_fadeImage.color = Color.clear;
		CurrentPoint = point;

		_isAnimating = false;
	}

	private Vector3 GetPointPosition(CameraPoint point)
	{
		var pointPos = point.Position;
		return new Vector3(pointPos.x, pointPos.y, _cameraZ);
	}
}
