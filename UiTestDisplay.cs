using System;
using Assets.Sources.Ui.ForUiTest;
using SSJJBase.Logger;
using UnityEngine;
using UnityEngine.UI;

public class UiTestDisplay : MonoBehaviour
{
	private LoggerAdapter _logger;

	public Text _text;

	private string _playRecord;

	private int _delay = 50;

	private void Awake()
	{
		string commandLine = Environment.CommandLine;
		_logger = new LoggerAdapter(typeof(UiTestDisplay));
		NetRecordManager.Init(_logger, commandLine, ref _playRecord);
	}

	private void Start()
	{
	}

	private void Update()
	{
		if (!NetRecordManager.Open)
		{
			return;
		}
		if (NetRecordManager.Playing)
		{
			if (Input.GetKeyDown(KeyCode.F11))
			{
				NetRecordManager.Pause = !NetRecordManager.Pause;
			}
			if (Input.GetKeyDown(KeyCode.F9))
			{
				NetRecordManager.TimeSync = !NetRecordManager.TimeSync;
			}
			if (Input.GetKeyDown(KeyCode.F12))
			{
				int speedScaleIndex = NetRecordManager.SpeedScaleIndex;
				speedScaleIndex++;
				if (speedScaleIndex == NetRecordManager.SpeedScaleArray.Length)
				{
					speedScaleIndex = 0;
				}
				NetRecordManager.SpeedScaleIndex = speedScaleIndex;
				NetRecordManager.SpeedScale = NetRecordManager.SpeedScaleArray[speedScaleIndex];
			}
			if (NetRecordManager.Pause && Input.GetKeyDown(KeyCode.F8))
			{
				NetRecordManager.Step++;
			}
			_text.text = $"[F7重播，F8暂停时单步执行，F9跳过待机帧，F11暂停] Frame Index : {NetRecordManager.Index} / {NetRecordManager.TotalFrame}";
		}
		else
		{
			_text.text = "";
			if (_delay-- == 0 && !string.IsNullOrEmpty(_playRecord))
			{
				NetRecordManager.Read(_playRecord);
				NetRecordManager.Start(autoInput: true, finishQuit: true, timeSync: true);
			}
			if (Input.GetKeyDown(KeyCode.F10))
			{
				NetRecordManager.Save();
			}
		}
	}
}
