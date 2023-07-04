using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class BallPlace : MonoBehaviour
{
	public UnityEvent OnTrigger;
	[SerializeField] private string _ballTag;
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!collision.CompareTag(_ballTag)) return;
	}
}
