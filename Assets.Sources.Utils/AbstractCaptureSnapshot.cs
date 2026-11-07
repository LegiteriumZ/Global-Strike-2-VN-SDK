using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using Assets.Sources.Constant;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Utility;
using UnityEngine;

namespace Assets.Sources.Utils;

public abstract class AbstractCaptureSnapshot : ICaptureSnapshot
{
	public LoggerAdapter _logger = new LoggerAdapter(typeof(AbstractCaptureSnapshot));

	private int _captureScreenShotCount;

	private const int CaptureMaxCount = 1500;

	public string ScreenFilePath;

	public bool IsSendEaseing;

	public int FrameCount;

	public bool PrepareCaping;

	public bool IsCaping;

	private string _dirPath;

	protected string OperatingSystem;

	private bool _deleteAllFile;

	public int _iw = -1;

	public int _ih = -1;

	private Thread _screenshotThread;

	private int GetArea(long cid)
	{
		string text = cid.ToString();
		if (text.Length >= 5)
		{
			return int.Parse(text[3].ToString() + text[4]);
		}
		return -1;
	}

	public bool InitPlayerData()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			if (myPlayerEntity.GetOneKillInfo() != null)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	public bool CheckDestoryThread()
	{
		if (_captureScreenShotCount >= 1500 && !MonoBehaviourSingleton<ScreenShotManager>.Instance.IsUniform)
		{
			return true;
		}
		return false;
	}

	public bool CheckCanCaptrueSnapshot()
	{
		if (SpecailDebug.Instance.AvoidCapture)
		{
			return false;
		}
		if (IsSendEaseing)
		{
			return false;
		}
		if (PrepareCaping)
		{
			return false;
		}
		if (MonoBehaviourSingleton<ScreenShotManager>.Instance.TcpMsgScreentNow)
		{
			MonoBehaviourSingleton<ScreenShotManager>.Instance.TcpMsgScreentNow = false;
			return true;
		}
		return false;
	}

	public string GetPath()
	{
		string dirPath = _dirPath;
		string text = DateTime.Now.ToString("_yyyy_MM_dd_HH_mm_ss");
		string right = string.Format("{0}_{1}.jpg", "Screenshot", "thread_" + text);
		return PathEx.Combine(dirPath, right);
	}

	public string GetDir()
	{
		return _dirPath;
	}

	private void DeleteOrigin()
	{
		if (_deleteAllFile)
		{
			return;
		}
		_deleteAllFile = true;
		if (!Directory.Exists(GetDir()))
		{
			return;
		}
		string[] files = Directory.GetFiles(GetDir(), "*thread_*");
		for (int i = 0; i < files.Length; i++)
		{
			if (File.Exists(files[i]))
			{
				File.Delete(files[i]);
			}
		}
	}

	public void InitScreenThread()
	{
		if (_screenshotThread != null)
		{
			_screenshotThread.Abort();
			_screenshotThread = null;
		}
		else
		{
			if (!InitPlayerData())
			{
				return;
			}
			OperatingSystem = SystemInfo.operatingSystem;
			this.InfoFormat("OperatingSystem {0}", OperatingSystem);
			_screenshotThread = new Thread((ThreadStart)delegate
			{
				Thread.CurrentThread.Name = "SystemScreenShot";
				while (true)
				{
					try
					{
						Thread.Sleep(100);
						FrameCount++;
						DeleteOrigin();
						if (CheckCanCaptrueSnapshot())
						{
							WaitScreen();
						}
						if (MonoBehaviourSingleton<ScreenShotManager>.Instance.IsFocus)
						{
							UpdateScreen();
						}
						if (CheckDestoryThread())
						{
							DestoryThread();
						}
					}
					catch (ThreadAbortException message)
					{
						_logger.Warn(message);
					}
					catch (Exception ex)
					{
						ScreenOver();
						_logger.Error(Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Cid + "ScreenShotManager>" + ex);
					}
				}
			});
			_screenshotThread.Start();
		}
	}

	public void WaitScreen()
	{
		this.Info("Wait");
		if (MonoBehaviourSingleton<ScreenShotManager>.Instance.IsUniform)
		{
			if (!RuleUtilty.IsPveModel(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
			{
				ScreenNow();
			}
		}
		else
		{
			PrepareCaping = true;
		}
	}

	public void ScreenNow()
	{
		if (!IsCaping)
		{
			IsCaping = true;
			IsSendEaseing = true;
		}
	}

	public void ScreenOver()
	{
		_captureScreenShotCount++;
		IsCaping = false;
		ScreenFilePath = null;
		IsSendEaseing = false;
		PrepareCaping = false;
	}

	public abstract void UpdateScreen();

	public void DestoryThread()
	{
		if (_screenshotThread != null)
		{
			this.Info("Destory");
			_screenshotThread.Abort();
			_screenshotThread = null;
		}
	}

	public bool IsPrepareScreen()
	{
		return PrepareCaping;
	}

	public void SetDir(string dir)
	{
		_dirPath = dir;
		Init();
	}

	private void Init()
	{
		if (_iw == -1)
		{
			_iw = Display.main.systemWidth;
			_ih = Display.main.systemHeight;
		}
	}

	public bool CheckIsLocalServer()
	{
		BattleServerContext battleServer = Contexts.sharedInstance.battleServer;
		if (battleServer.hasBattleServer && battleServer.battleServer.Server != null && Contexts.sharedInstance.battleServer.battleServer.Server.IsInLocalNetwork)
		{
			return true;
		}
		return false;
	}

	public bool GetPicThumbnail(string sFile, string outPath, int flag = 50)
	{
		Image image = Image.FromFile(sFile);
		ImageFormat rawFormat = image.RawFormat;
		EncoderParameters encoderParameters = new EncoderParameters();
		EncoderParameter encoderParameter = new EncoderParameter(value: new long[1] { flag }, encoder: Encoder.Quality);
		encoderParameters.Param[0] = encoderParameter;
		try
		{
			ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
			ImageCodecInfo imageCodecInfo = null;
			for (int i = 0; i < imageEncoders.Length; i++)
			{
				if (imageEncoders[i].FormatDescription.Equals("JPEG"))
				{
					imageCodecInfo = imageEncoders[i];
					break;
				}
			}
			if (imageCodecInfo != null)
			{
				image.Save(outPath, imageCodecInfo, encoderParameters);
			}
			else
			{
				image.Save(outPath, rawFormat);
			}
			return true;
		}
		catch (Exception args)
		{
			this.LogErrorFormat(Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Cid + "CaptureSnapShotCompressError > {0}", args);
			return false;
		}
		finally
		{
			image.Dispose();
		}
	}
}
