using System.IO;
using Assets.Scripts.Utility;
using SSJJBase.Logger;
using SSJJBase.Singleton;

namespace Assets.Sources.Utils;

public class SpecailDebug
{
	private static SpecailDebug _instance;

	private bool _isShowLog;

	public bool OpenRecord;

	public bool UseTcp;

	public bool GetUdpBytes;

	public bool OpenAvi;

	public bool GetMainFest;

	public bool KillScreenSave;

	public bool IsOpenThreadToScreen;

	public bool AvoidCapture;

	public bool RunTimeDebug;

	public bool RecordFps;

	public bool HideParticle;

	public bool DataSampler;

	public bool RecordWeaponPlayerMsg;

	public bool OpenGPUAnim;

	public int ErrorCount;

	public static SpecailDebug Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SpecailDebug();
				_instance.InitConfig();
			}
			return _instance;
		}
	}

	public void InitConfig()
	{
		_isShowLog = File.Exists("ShowLog.txt") || File.Exists("ShowLog");
		OpenAvi = File.Exists("OpenAvi.txt") || File.Exists("OpenAvi");
		RecordWeaponPlayerMsg = File.Exists("RecordWeaponPlayerMsg.txt") || File.Exists("RecordWeaponPlayerMsg");
		RecordFps = File.Exists("RecordFps.txt") || File.Exists("RecordFps");
		HideParticle = File.Exists("HideParticle.txt") || File.Exists("HideParticle");
		AvoidCapture = File.Exists("AvoidCapture.txt") || File.Exists("AvoidCapture");
		RunTimeDebug = File.Exists("RunTimeDebug.txt") || File.Exists("RunTimeDebug");
		GetMainFest = File.Exists("GetMainFest.txt") || File.Exists("GetMainFest");
		UseTcp = File.Exists("UseTcp.txt") || File.Exists("UseTcp");
		OpenRecord = File.Exists("OpenRecord.txt") || File.Exists("OpenRecord");
		GetUdpBytes = File.Exists("GetUdpBytes.txt") || File.Exists("GetUdpBytes");
		KillScreenSave = File.Exists("FirstKillScreen.txt") || File.Exists("FirstKillScreen");
		IsOpenThreadToScreen = File.Exists("IsOpenThreadToScreen.txt") || File.Exists("IsOpenThreadToScreen");
		DataSampler = File.Exists("DataSampler.txt") || File.Exists("DataSampler");
		OpenGPUAnim = File.Exists("OpenGPUAnim.txt") || File.Exists("OpenGPUAnim");
		if (_isShowLog)
		{
			this.InfoFormat("NetWork, UseTcp{0} GetUdpBytes{1} GetMainFest{2}", UseTcp, GetUdpBytes, GetMainFest);
			this.InfoFormat("RunTimeDebug {0}", RunTimeDebug);
			this.InfoFormat("DataSampler {0}", DataSampler);
			this.InfoFormat("OpenRecord {0}", OpenRecord);
			this.InfoFormat("OpenAvi {0}", OpenAvi);
			this.InfoFormat("Capture KillScreenSave {0} IsOpenThreadToScreen{1} Avoid {2}", KillScreenSave, IsOpenThreadToScreen, AvoidCapture);
		}
		if (RecordFps)
		{
			MonoBehaviourSingleton<RecordFpsManager>.Instance.Init();
		}
		if (RecordWeaponPlayerMsg)
		{
			MonoBehaviourSingleton<RecordWeaponPlayerManager>.Instance.Init();
		}
	}
}
