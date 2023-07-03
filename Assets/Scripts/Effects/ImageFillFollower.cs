using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFillFollower : MonoBehaviour
{
	[SerializeField] private Image _image;

	private RectTransform _selfRectTransform;

	private void Awake()
	{
		_selfRectTransform = (RectTransform) transform;
	}

	public void UpdatePosition()
	{
		gameObject.SetActive(_image.fillAmount > 0);
		var width = _image.rectTransform.rect.width;
		var positionX = width * _image.fillAmount;
		var position = _selfRectTransform.anchoredPosition;
		position.x = positionX;
		
		_selfRectTransform.anchoredPosition = position;
	}
}
