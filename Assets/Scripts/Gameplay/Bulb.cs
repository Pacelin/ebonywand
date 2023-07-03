using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bulb : MonoBehaviour
{
	public event Action OnEnable;
	public event Action OnDisable;
	public bool Enabled { get; private set; }

	[SerializeField] private Light2D _light;
	[SerializeField] private float _intensity;
	[SerializeField] private float _fadeInTime;
	[SerializeField] private float _fadeOutTime;
	[SerializeField] private bool _enabledOnAwake;

	private void Awake()
	{
		_light.intensity = _enabledOnAwake ? _intensity : 0;
		Enabled = _enabledOnAwake;
	}

	public void Switch(float delay)
	{
		if (Enabled) Disable(delay);
		else Enable(delay);
	}

	public void Enable(float delay)
	{
		if (Enabled) return;
		Enabled = true;
		OnEnable?.Invoke();
		StartCoroutine(Fade(_light, 0, _intensity, _fadeInTime, delay));
	}

	public void DisableWithoutNotify(float delay)
	{
		if (!Enabled) return;
		Enabled = false;
		StartCoroutine(Fade(_light, _intensity, 0, _fadeOutTime, delay));
	}

	public void Disable(float delay)
	{
		if (!Enabled) return;
		Enabled = false;
		OnDisable?.Invoke();
		StartCoroutine(Fade(_light, _intensity, 0, _fadeOutTime, delay));
	}

	private static IEnumerator Fade(Light2D light, float intensityFrom, float intensityTo, float fadeTime, float delay = 0)
	{
		yield return new WaitForSeconds(delay);
		for (float t = 0; t < fadeTime; t += Time.deltaTime)
		{
			light.intensity = Mathf.Lerp(intensityFrom, intensityTo, t / fadeTime);
			yield return null;
		}
		light.intensity = intensityTo;
	}
}