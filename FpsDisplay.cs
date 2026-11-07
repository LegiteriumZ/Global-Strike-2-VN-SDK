using System;
using System.Collections.Generic;
using Assets.Libs.ForAce;
using Assets.Scripts.QuickRuntimeConsole;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Config;
using Assets.Sources.Utils;
using Assets.Sources.Utils.EventLogger;
using SSJJAsset.AssetBundle;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJRunTimeDataSample.Interface;
using UnityEngine;
using UnityEngine.UI;

public class FpsDisplay : MonoBehaviour, IFpsDisplay
{
	public static bool ChatInputVisible;

	private static FpsDisplay _instance;

	public float fpsMeasuringDelta = 2f;

	private float timePassed;

	private int m_FrameCount;

	private float m_FPS = -1f;

	private float _lastFPS;

	private float timePassedAverage;

	private int m_FrameCountAverage;

	private float m_FPS_AVG = 60f;

	private List<int> historyAvgFpsList = new List<int>();

	private bool flag;

	private bool lastButtonStat;

	private float lastLoggerTime;

	private string fullScreenMode;

	public Text _text;

	public Text _text2;

	public bool StartRecordFps;

	private RoomDataComponent _component;

	private void Awake()
	{
		_instance = this;
		string commandLine = Environment.CommandLine;
		this.InfoFormat("Run From Command {0}", commandLine);
		fullScreenMode = (commandLine.Contains("exclusive") ? "全屏独占" : "全屏窗口化");
		_text2.text = fullScreenMode;
	}

	private void Start()
	{
		timePassed = 0f;
		base.gameObject.AddComponent<QuickRuntimeConsole>();
	}

	public static FpsDisplay GetInstance()
	{
		return _instance;
	}

	public float GetFpsAverage()
	{
		int num = 0;
		foreach (int historyAvgFps in historyAvgFpsList)
		{
			num += historyAvgFps;
		}
		if (historyAvgFpsList.Count > 0)
		{
			return (float)num * 1f / (float)historyAvgFpsList.Count;
		}
		return 0f;
	}

	private int GetSceneId()
	{
		if (_component == null && Contexts.sharedInstance.battleRoom.hasRoomData)
		{
			_component = Contexts.sharedInstance.battleRoom.roomData;
		}
		if (_component != null && _component.Data != null)
		{
			return _component.Data.SceneId;
		}
		return -1;
	}

	public string GetRaceInfo()
	{
		if (_component == null && Contexts.sharedInstance.battleRoom.hasRoomData)
		{
			_component = Contexts.sharedInstance.battleRoom.roomData;
		}
		if (_component != null && _component.Data != null)
		{
			return $"RaceType0:{_component.Data.RaceType} FreeType0:{_component.Data.FreeType} FPSAVG0:{m_FPS_AVG} ScreenW:{Screen.width} ScreenH:{Screen.height},ScreenWh:{Screen.width * Screen.height}";
		}
		return "";
	}

	private void Update()
	{
		if (GameController.Instance.InitFinish)
		{
			m_FrameCount++;
			timePassed += Time.deltaTime;
			m_FrameCountAverage++;
			timePassedAverage += Time.deltaTime;
			if (timePassed > fpsMeasuringDelta)
			{
				m_FPS = (float)m_FrameCount / timePassed;
				if (m_FPS >= 59f && m_FPS < 60f)
				{
					m_FPS = 60f;
				}
				timePassed = 0f;
				m_FrameCount = 0;
			}
			if (timePassedAverage > 5f)
			{
				m_FPS_AVG = (float)m_FrameCountAverage / timePassedAverage;
				timePassedAverage = 0f;
				m_FrameCountAverage = 0;
				historyAvgFpsList.Add((int)m_FPS_AVG);
				if (Time.fixedTime > lastLoggerTime)
				{
					lastLoggerTime = Time.fixedTime + 120f;
					int sceneId = GetSceneId();
					if (sceneId > 0)
					{
						bool isFullFrame = GameSetting.Config.FrameLimit >= 140 && GameSetting.Config.VSync == 0;
						EventLogger.Instance.FrameLogger(m_FPS_AVG, GetRaceInfo(), isFullFrame, sceneId);
						GlobalProperties.Instance.Properties["gctm0"] = GC.GetTotalMemory(forceFullCollection: false);
					}
				}
			}
		}
		if (Input.GetKey(KeyCode.H))
		{
			if (ChatInputVisible)
			{
				return;
			}
			if (!lastButtonStat)
			{
				flag = !flag;
				_text.text = "";
			}
			lastButtonStat = true;
		}
		else
		{
			lastButtonStat = false;
		}
		if (flag && (_lastFPS != m_FPS || _lastFPS == -1f))
		{
			_text.text = string.Format("FPS:{0},vsync:{10},screen:{1}*{2},disp:{6}*{7},vs:{3},br:{4},bT:{9},ct:{5},resver:{8},snt:{11},snc:{12},ace:{13},OpenGPUAnim：{14} , ErrorCount:{15},fpsAverage:{16}", Mathf.RoundToInt(m_FPS), Screen.width, Screen.height, "0.0.0.5", "origin/abroad_2024_12_17_viet", "55ae00b0013fa47583635b28f2798119277896d8", Display.main.systemWidth, Display.main.systemHeight, AssetBundleManager.GetAssetBundleManifestMd5(), "", QualitySettings.vSyncCount, Contexts.sharedInstance.battleServer.battleServer.Server.IsDefaultUseTcp, Contexts.sharedInstance.battleServer.battleServer.Server.UdpSnapshotCompressed, MonoBehaviourSingleton<AceClientManager>.Instance.AceMsgToString(), SpecailDebug.Instance.OpenGPUAnim, SpecailDebug.Instance.ErrorCount, Mathf.RoundToInt(GetFpsAverage()));
			_lastFPS = m_FPS;
		}
	}
}
