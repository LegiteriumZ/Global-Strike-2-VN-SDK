using System;
using System.IO;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Utility;
using UnityEngine;

namespace Assets.Sources.Utils;

public class ScreenShotManager : MonoBehaviourSingleton<ScreenShotManager>
{
	private static int MaxScreenCount = 50;

	private static int _index;

	private static string FileNamePrefix = "Screenshot_";

	public static string DirPath;

	public static bool ScreenshotFlag;

	private static float _screenShotFrameTime;

	public bool IsFocus = true;

	public bool IsExclusiveWindowMode;

	private ICaptureSnapshot _captureSnapshot;

	public bool TcpMsgScreentNow;

	public int ScreenImageReason;

	public bool IsUniform;

	private string _uniformResoucesBase = "http://cdn.ssjj.iwan4399.com/s996/";

	private LoggerAdapter _logger;

	public bool IsMustScreen;

	private bool _isOpenThreadToScreen = true;

	private void Awake()
	{
		DirPath = GetDir();
		_logger = new LoggerAdapter(typeof(ScreenShotManager));
		MonoBehaviourSingleton<NetEaseCloudManager>.Instance.Init();
	}

	private void OnApplicationFocus(bool focus)
	{
		IsFocus = focus;
	}

	public ICaptureSnapshot GetCaptureSnapshot()
	{
		return _captureSnapshot;
	}

	public void CreateScreenThread()
	{
		if (!_isOpenThreadToScreen && !SpecailDebug.Instance.IsOpenThreadToScreen)
		{
			return;
		}
		if (!IsExclusiveWindowMode)
		{
			if (UnityEngine.Random.Range(0, 3) == 1)
			{
				_captureSnapshot = new WindowCaptureSnapshot();
			}
			else
			{
				_captureSnapshot = new WindowHdcCaptureSnapshot();
			}
		}
		else
		{
			_captureSnapshot = new ExclusiveCaptureSnapshot();
		}
		_captureSnapshot.SetDir(DirPath);
		_captureSnapshot.InitScreenThread();
	}

	public void ParseResouceBase(string resourceBase)
	{
		if (!string.IsNullOrEmpty(resourceBase) && resourceBase.Trim().Equals(_uniformResoucesBase, StringComparison.OrdinalIgnoreCase))
		{
			IsUniform = true;
		}
		this.Info("Uniform > " + IsUniform);
	}

	public string GetDir()
	{
		return PathEx.Combine(Application.persistentDataPath, "screenshot");
	}

	private void Update()
	{
		if (Time.time - _screenShotFrameTime > 2f && Input.GetKeyDown(KeyCode.SysReq))
		{
			_screenShotFrameTime = Time.time;
			int num = _index++ % MaxScreenCount;
			string right = $"{FileNamePrefix}_{num}.png";
			if (!Directory.Exists(DirPath))
			{
				Directory.CreateDirectory(DirPath);
			}
			string text = PathEx.Combine(DirPath, right);
			ScreenCapture.CaptureScreenshot(text);
			this.InfoFormat("Save Screenshot to {0}", text);
			ScreenshotFlag = true;
			if (SpecailDebug.Instance.KillScreenSave)
			{
				TcpMsgScreentNow = true;
			}
		}
	}

	public bool GetOpenThreadToScreen()
	{
		return _isOpenThreadToScreen;
	}

	private void OnApplicationQuit()
	{
		this.Info("Destory Manager Thread");
		if (_captureSnapshot != null)
		{
			_captureSnapshot.DestoryThread();
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (_captureSnapshot != null)
		{
			_captureSnapshot.DestoryThread();
		}
	}
}
