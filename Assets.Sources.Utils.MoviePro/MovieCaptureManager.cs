using System;
using System.IO;
using RenderHeads.Media.AVProMovieCapture;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Utils.MoviePro;

public class MovieCaptureManager : MonoBehaviourSingleton<MovieCaptureManager>
{
	public Action AddCapExceptionAction;

	public Action StartCapExceptionAction;

	public Action StopCapExceptionAction;

	public Action UpdateCapExceptionAction;

	public Action DiskMinExceptionAction;

	public Action FpsLowExceptionAction;

	private MovieCaptureSsjj _ssjjCap;

	private UnityAudioCapture _unityAudio;

	private long _lastFileSize;

	private MovieCaptureConfig _captureConfig = new MovieCaptureConfig();

	private string _preDir;

	public bool IsExclusiveWindowMode;

	private float _startFps;

	private float _stopFps;

	public void SetDir(string dir)
	{
		_preDir = dir;
	}

	private void Init()
	{
		this.Info("MoveCapture Start Init ");
		_captureConfig.ReadConfig();
		float fpsAverage = FpsDisplay.GetInstance().GetFpsAverage();
		if ((float)_captureConfig.AllowFps > fpsAverage)
		{
			if (FpsLowExceptionAction != null)
			{
				FpsLowExceptionAction();
			}
			this.LogError("Fps Too Lower " + fpsAverage + "， Allow Fps " + _captureConfig.AllowFps);
			return;
		}
		_ssjjCap = Camera.main.gameObject.AddComponent<MovieCaptureSsjj>();
		if (_captureConfig.IsAddAudio)
		{
			_unityAudio = Camera.main.gameObject.AddComponent<UnityAudioCapture>();
			_unityAudio.enabled = false;
			_ssjjCap.AudioCaptureSource = AudioCaptureSource.Unity;
			_ssjjCap.UnityAudioCapture = _unityAudio;
		}
		_ssjjCap.MinimumDiskSpaceMB = _captureConfig.MinimumDiskSpaceMb;
		_ssjjCap.ResolutionDownScale = (CaptureBase.DownScale)_captureConfig.DownScale;
		_ssjjCap.FrameRate = _captureConfig.FrameRate;
		if (string.IsNullOrEmpty(_preDir))
		{
			_preDir = Path.Combine(Application.dataPath, "../NullMoviePro");
		}
		else
		{
			_preDir = Path.Combine(_preDir, "MoviePro");
		}
		_ssjjCap.OutputFolderPath = _preDir;
		_ssjjCap.CaptureAwake();
		if (_ssjjCap.IsEnoughDiskSpace())
		{
			return;
		}
		if (DiskMinExceptionAction != null)
		{
			DiskMinExceptionAction();
		}
		throw new Exception("[AVProMovieCapture] Free disk space getting too low.  Stopping capture.");
	}

	private void LateUpdate()
	{
		if (SpecailDebug.Instance.OpenAvi)
		{
			if (Input.GetKeyDown(KeyCode.F5))
			{
				CaptureStartOrdEnd();
			}
			CaptureFrame();
		}
	}

	private void OnApplicationFocus(bool focus)
	{
		if (SpecailDebug.Instance.OpenAvi && _captureConfig.LostIsPauseVideo && IsExclusiveWindowMode)
		{
			if (!focus)
			{
				PauseCapture();
			}
			else
			{
				ResumeCapture();
			}
		}
	}

	private void PauseCapture()
	{
		if (_ssjjCap != null)
		{
			_ssjjCap.PauseCapture();
		}
	}

	private void ResumeCapture()
	{
		if (_ssjjCap != null)
		{
			_ssjjCap.ResumeCapture();
		}
	}

	private void CaptureFrame()
	{
		try
		{
			if (_ssjjCap != null)
			{
				_ssjjCap.UpdateFrame();
			}
		}
		catch (Exception ex)
		{
			if (UpdateCapExceptionAction != null)
			{
				UpdateCapExceptionAction();
			}
			this.LogErrorFormat("Update Frame Error > {0}", ex.ToString());
		}
	}

	private void CaptureTryAdd()
	{
		if (_ssjjCap == null)
		{
			Init();
		}
	}

	public void CaptureStartOrdEnd()
	{
		try
		{
			CaptureTryAdd();
		}
		catch (Exception ex)
		{
			if (AddCapExceptionAction != null)
			{
				AddCapExceptionAction();
			}
			this.LogErrorFormat("AddCapture Error > {0}", ex.ToString());
		}
		if (!(_ssjjCap != null))
		{
			return;
		}
		if (_ssjjCap.IsCapturing())
		{
			try
			{
				_ssjjCap.StopCapture();
				_stopFps = FpsDisplay.GetInstance().GetFpsAverage();
				this.Info("stop Cap fps : " + _stopFps);
				if (!string.IsNullOrEmpty(_ssjjCap.LastFilePath))
				{
					Application.OpenURL(Path.GetDirectoryName(_ssjjCap.LastFilePath));
					string path = Path.Combine(Path.GetDirectoryName(_ssjjCap.LastFilePath), Path.GetFileNameWithoutExtension(_ssjjCap.LastFilePath) + "_msg.txt");
					string text = "";
					text = text + "GPU : " + SystemInfo.graphicsDeviceName + "  " + SystemInfo.graphicsDeviceVersion + " OS: " + SystemInfo.operatingSystem + "\n";
					text = text + "FpsStart : " + _startFps + "  FpsEnd : " + _stopFps + "  InnerFps : " + _ssjjCap.CaptureStats.FPS + "\n";
					text = text + "FramesTotal : " + _ssjjCap.CaptureStats.FramesTotal + "\n";
					text = text + "Config:" + _captureConfig.ToString() + "\n";
					text = text + "StartInfoLog:" + _ssjjCap.StartInfoLog + "\n";
					text = text + FpsDisplay.GetInstance()._text.text + "\n";
					text = text + FpsDisplay.GetInstance()._text2.text + "\n";
					text = text + "RaceType : " + Contexts.sharedInstance.battleRoom.roomData.Data.RaceType + "\n";
					File.WriteAllText(path, text);
				}
				return;
			}
			catch (Exception ex2)
			{
				if (StopCapExceptionAction != null)
				{
					StopCapExceptionAction();
				}
				this.LogErrorFormat("StopCapture Error > {0}", ex2.ToString());
				return;
			}
		}
		try
		{
			_ssjjCap.StartCapture();
			_startFps = FpsDisplay.GetInstance().GetFpsAverage();
			this.Info("start Cap fps : " + _startFps);
		}
		catch (Exception ex3)
		{
			if (StartCapExceptionAction != null)
			{
				StartCapExceptionAction();
			}
			this.LogErrorFormat("StartCapture Error > {0}", ex3.ToString());
		}
	}

	public bool InVideo()
	{
		if (_ssjjCap != null)
		{
			return _ssjjCap.IsCapturing();
		}
		return false;
	}
}
