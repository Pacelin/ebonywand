using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupSwitcherUI : MonoBehaviour
{
	[SerializeField] private float _fadeInTime;
	[SerializeField] private float _fadeOutTime;
	[SerializeField] private bool _enableOnAwake;
	private CanvasGroup _canvasGroup;

	private bool _visible;

	private void Awake()
	{
		_canvasGroup = GetComponent<CanvasGroup>();

		_canvasGroup.alpha = _enableOnAwake ? 1 : 0;
		_canvasGroup.blocksRaycasts = _enableOnAwake;
		_canvasGroup.interactable = _enableOnAwake;

		_visible = _enableOnAwake;
	}

	public void Switch()
	{
		if (_visible) StartCoroutine(SwitchOff());
		else StartCoroutine(SwitchOn());
	}

	private void Update()
	{
		if (_visible && Input.GetKeyDown(KeyCode.Mouse0))
			StartCoroutine(SwitchOff());
	}

	private IEnumerator SwitchOn()
	{
		yield return Fade(_canvasGroup, 0, 1, _fadeInTime);
		_visible = true;
		_canvasGroup.interactable = false;
		_canvasGroup.blocksRaycasts = false;
	}

	private IEnumerator SwitchOff()
	{
		_visible = false;
		yield return Fade(_canvasGroup, 1, 0, _fadeOutTime);
		_canvasGroup.interactable = false;
		_canvasGroup.blocksRaycasts = false;
	}

	public static IEnumerator Fade(CanvasGroup group, float alphaFrom, float alphaTo, float fadeTime)
	{
		for (float t = 0; t < fadeTime; t += Time.deltaTime)
		{
			group.alpha = Mathf.Lerp(alphaFrom, alphaTo, t / fadeTime);
			yield return null;
		}
		group.alpha = alphaTo;
	}
}