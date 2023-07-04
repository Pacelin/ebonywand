using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Collider2D))]
public class Robot : MonoBehaviour
{
	public UnityEvent OnActivate;

	[SerializeField] private Sprite _openSprite;
	[SerializeField] private Sprite _closeSprite;
	[Space]
	[SerializeField] private Light2D _eyeLight;
	[SerializeField] private float _eyeFadeTime;
	[SerializeField] private float _eyeIntensity;

	[Inject] private WandPresenter _presenter;

	private SpriteRenderer _selfSpriteRenderer;
	private bool _handleWands;

	private void Awake()
	{
		_selfSpriteRenderer = GetComponent<SpriteRenderer>();
		_selfSpriteRenderer.sprite = _closeSprite;
		_handleWands = false;
	}

	public void Open()
	{
		_handleWands = true;
		_selfSpriteRenderer.sprite = _openSprite;
	}

	private void OnMouseUpAsButton()
	{
		if (!_handleWands) return;

		_presenter.gameObject.SetActive(false);
		_handleWands = false;
		_selfSpriteRenderer.sprite = _closeSprite;
		Cursor.visible = true;

		StartCoroutine(Eyes());
	}

	private IEnumerator Eyes()
	{
		for (var t = 0f; t < _eyeFadeTime; t += Time.deltaTime)
		{
			_eyeLight.intensity = Mathf.Lerp(0, _eyeIntensity, t / _eyeFadeTime);
			yield return null;
		}
		OnActivate?.Invoke();
	}
}
