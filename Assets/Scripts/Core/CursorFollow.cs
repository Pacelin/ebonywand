using UnityEngine;
using Zenject;

public class CursorFollow : MonoBehaviour
{
	[Inject] private Camera _mainCamera;

	private void Update()
	{
		var mouse = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
		transform.position = new Vector3(mouse.x, mouse.y, 0);
	}
}
