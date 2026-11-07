using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Tests.AnimViewer;

public class OverviewUIObject : IControlButton, IPlaySpeed
{
	private GameObject _overView;

	private Button _resumeButton;

	private Button _pauseButton;

	private Button _restartButton;

	private Button _stopButton;

	private Slider _speedSlider;

	public OverviewUIObject(GameObject go)
	{
		_overView = go;
	}

	public void InitButton(UnityAction pauseAction, UnityAction resumeAction, UnityAction restartAction, UnityAction stopAction)
	{
		_pauseButton = _overView.transform.Find("Pause").GetComponent<Button>();
		_pauseButton.onClick.AddListener(pauseAction);
		_resumeButton = _overView.transform.Find("Resume").GetComponent<Button>();
		_resumeButton.onClick.AddListener(resumeAction);
		_restartButton = _overView.transform.Find("Restart").GetComponent<Button>();
		_restartButton.onClick.AddListener(restartAction);
		_stopButton = _overView.transform.Find("Stop").GetComponent<Button>();
		_stopButton.onClick.AddListener(stopAction);
	}

	public void InitSlider()
	{
		_speedSlider = _overView.transform.Find("PlaySpeed").GetComponent<Slider>();
	}

	public float GetSpeed()
	{
		return _speedSlider.value;
	}
}
