using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class EndGame : MonoBehaviour
{

	[SerializeField] private Image _fadeImage;
	[SerializeField] private float _fadeDuration;
	[SerializeField] private float _blackDuration;
	[Space]
	[SerializeField] private ChatMessage[] _lastMessages;
	[Space]
	[SerializeField] private int _titresSceneBuildIndex;

	[Inject] private Chat _chat;

	public void StartEndGame() => StartCoroutine(Ending());

	private IEnumerator Ending()
	{
		_chat.AddMessages(_lastMessages);

		yield return new WaitWhile(() => _chat.HaveMessages);
		yield return new WaitForSeconds(2);
		yield return Fade();

		SceneManager.LoadScene(_titresSceneBuildIndex, LoadSceneMode.Single);
	}

	private IEnumerator Fade()
	{
		for (float t = 0; t < _fadeDuration; t += Time.deltaTime)
		{
			_fadeImage.color = Color.Lerp(Color.clear, Color.black, t / _fadeDuration);
			yield return null;
		}
		yield return new WaitForSeconds(_blackDuration);
	}
}
