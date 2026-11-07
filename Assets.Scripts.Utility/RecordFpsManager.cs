using System;
using System.IO;
using Assets.Sources.Utils;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Scripts.Utility;

public class RecordFpsManager : MonoBehaviourSingleton<RecordFpsManager>
{
	private int _frameCount;

	private float _allTime;

	private bool _start;

	public void Init()
	{
		MonoBehaviourSingleton<GameExitManager>.Instance.RegisterAction(RecordFps);
	}

	public void StartRec()
	{
		_start = true;
	}

	private void Update()
	{
		if (_start)
		{
			_allTime += Time.deltaTime;
			_frameCount++;
		}
	}

	private void RecordFps()
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		int currentMemory = TotalMemoryUtility.GetCurrentMemory();
		this.InfoFormat("RaceType : {3} AvgFps : {0}  time : {1}  frameCount {2}", (float)_frameCount / _allTime, _allTime, _frameCount, raceType);
		StreamWriter streamWriter = File.AppendText("RecordFps.txt");
		streamWriter.WriteLine(DateTime.Now.ToString("yy-MM-dd-hh-mm-ss") + ":" + (float)_frameCount / _allTime + "  time : " + _allTime + "  frameCount : " + _frameCount + "  raceType : " + raceType + "  memory" + currentMemory + "  OpenGPUAnim:" + SpecailDebug.Instance.OpenGPUAnim.ToString() + "  ");
		streamWriter.Flush();
		streamWriter.Close();
	}
}
