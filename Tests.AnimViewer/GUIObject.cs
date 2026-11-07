using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Tests.AnimViewer;

public class GUIObject : IDropDown, ITitle, IControlButton
{
	private GameObject _go;

	private Dropdown _dropDown;

	private Button _pauseButton;

	private Button _resumeButton;

	private Button _restartButton;

	private Button _stopButton;

	public void InitButton(UnityAction pauseAction, UnityAction resumeAction, UnityAction restartAction, UnityAction stopAction)
	{
		_pauseButton = _go.transform.Find("Pause").GetComponent<Button>();
		_pauseButton.onClick.AddListener(pauseAction);
		_pauseButton.onClick.AddListener(PauseHelper);
		_resumeButton = _go.transform.Find("Resume").GetComponent<Button>();
		_resumeButton.gameObject.SetActive(value: false);
		_resumeButton.onClick.AddListener(resumeAction);
		_resumeButton.onClick.AddListener(ResumeHelper);
		_restartButton = _go.transform.Find("Restart").GetComponent<Button>();
		_restartButton.onClick.AddListener(restartAction);
		_restartButton.onClick.AddListener(ResumeHelper);
		_stopButton = _go.transform.Find("Stop").GetComponent<Button>();
		_stopButton.onClick.AddListener(stopAction);
		_stopButton.onClick.AddListener(ResumeHelper);
	}

	private void PauseHelper()
	{
		_pauseButton.gameObject.SetActive(value: false);
		_resumeButton.gameObject.SetActive(value: true);
	}

	private void ResumeHelper()
	{
		_pauseButton.gameObject.SetActive(value: true);
		_resumeButton.gameObject.SetActive(value: false);
	}

	public void InitTitle(GameObject go, string name, int offset)
	{
		_go = go;
		go.transform.localPosition = new Vector3(go.transform.localPosition.x + 50f, offset);
		go.transform.Find("Title").GetComponent<Text>().text = name;
	}

	public bool InitDropDown(List<string> animList)
	{
		_dropDown = _go.GetComponent<Dropdown>();
		if (_dropDown == null)
		{
			return false;
		}
		try
		{
			_dropDown.AddOptions(animList);
		}
		catch
		{
			return false;
		}
		return true;
	}

	public string GetStateName()
	{
		return _dropDown.captionText.text;
	}
}
