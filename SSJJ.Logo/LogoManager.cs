using UnityEngine;
using UnityEngine.SceneManagement;

namespace SSJJ.Logo;

public class LogoManager : MonoBehaviour
{
	private float _alpha;

	private float _speed = 1f;

	private CanvasGroup canvas;

	private void Start()
	{
		canvas = base.gameObject.GetComponent<CanvasGroup>();
	}

	private void Update()
	{
		if (!(canvas == null))
		{
			_alpha += _speed * Time.deltaTime;
			canvas.alpha = _alpha;
			if (_alpha >= 2f)
			{
				_alpha = 1f;
				_speed = -1f;
			}
			if (_alpha <= -0.5f)
			{
				SceneManager.LoadSceneAsync("Lobby");
				canvas = null;
			}
		}
	}
}
