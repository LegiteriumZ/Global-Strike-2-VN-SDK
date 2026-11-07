using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using AceSdk;
using Assets.Sources.Config;
using Assets.Sources.Utils.EventLogger;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.SimpleJson;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase.Utility;
using UnityEngine;

namespace Assets.Libs.ForAce;

public class AceClientManager : MonoBehaviourSingleton<AceClientManager>
{
	public enum ACE_SUSPEND
	{
		DLL_NOT_FOUND_FAIL,
		INIT_FAIL,
		LOGIN_ON_FAIL,
		SUCC
	}

	public bool _isOpen;

	public bool _initSucc;

	public bool _loginSucc;

	private int _gameId = 463;

	private readonly TssSdkAntiSendDataInfo _sendData = new TssSdkAntiSendDataInfo();

	private Action _aceSelfAction;

	private List<int> _reportRuleList;

	private int _caculateCount;

	private long _milliseconds;

	private Thread _tickThread;

	[DllImport("AcePackage", CharSet = CharSet.Auto)]
	public static extern int init_ace(int processId);

	[DllImport("AcePackage", CharSet = CharSet.Auto)]
	public static extern int user_loginOn_ace(ref AceClient.TokenData data, int worldid, int channelid, int roleid);

	[DllImport("AcePackage", CharSet = CharSet.Auto)]
	public static extern IntPtr user_tick_ace();

	[DllImport("AcePackage", CharSet = CharSet.Auto)]
	public static extern int user_loginOff_ace();

	[DllImport("AcePackage", CharSet = CharSet.Auto)]
	public static extern int eixt_ace();

	[DllImport("AcePackage", CharSet = CharSet.Auto)]
	public static extern void receive_antiData(ref AceClient.TssAntiData data);

	[DllImport("AcePackage", CharSet = CharSet.Auto)]
	public static extern int delete_antiData();

	public string AceMsgToString()
	{
		return $"open:{_isOpen},init:{_initSucc},login:{_loginSucc}";
	}

	public void Close()
	{
		_isOpen = false;
	}

	public bool CheckRuleOpen()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data.NeedAce;
	}

	public void CheckAceOpenRuleList()
	{
		_reportRuleList = new List<int>();
		string gameStartJsonAttribute = TplManager.Instance.GameBootConfig.GameStartJsonAttribute;
		if (gameStartJsonAttribute == null || !JsonDecoder.Decode(gameStartJsonAttribute).ObjectValue.TryGetValue("aceModeList", out var value))
		{
			return;
		}
		List<JObject> arrayValue = value.ArrayValue;
		for (int i = 0; i < arrayValue.Count; i++)
		{
			if (!string.IsNullOrEmpty(arrayValue[i].StringValue))
			{
				_reportRuleList.Add(int.Parse(arrayValue[i].StringValue));
			}
		}
	}

	public void CheckAceSwitch()
	{
		string gameStartJsonAttribute = TplManager.Instance.GameBootConfig.GameStartJsonAttribute;
		this.InfoFormat("AceSwitch {0}", gameStartJsonAttribute);
		if (gameStartJsonAttribute != null && JsonDecoder.Decode(gameStartJsonAttribute).ObjectValue.TryGetValue("aceControlSwitch", out var value))
		{
			this.InfoFormat("Check Ace Open {0}", _isOpen = value.BooleanValue);
		}
	}

	public void GameAceInit()
	{
		try
		{
			if (_isOpen && !Application.isEditor)
			{
				this.Info("GameAceInit");
				AntiCheatExpertResult antiCheatExpertResult = (AntiCheatExpertResult)init_ace(Process.GetCurrentProcess().Id);
				string text = "..\\..\\AntiCheatExpert\\InGame\\x86\\ACE-Base32.dll";
				string text2 = "..\\..\\AntiCheatExpert\\InGame\\x86\\ACE-Base-Unity32.dat";
				this.InfoFormat("dll path {0}, exist {1}, dat path {2}, exist {3}", text, File.Exists(text), text2, File.Exists(text2));
				AceInitLog(antiCheatExpertResult);
				if (antiCheatExpertResult != 0)
				{
					this.LogErrorFormat("ACE login on failed, Ret is :{0}, Game is exiting...", _gameId);
					AceLog(ACE_SUSPEND.INIT_FAIL);
				}
				else
				{
					_initSucc = true;
					this.Info("Init Success");
					MonoBehaviourSingleton<GameExitManager>.Instance.RegisterAction(Exit);
				}
			}
		}
		catch (Exception ex)
		{
			if (ex.ToString().ToLower().Contains("dllnotfound"))
			{
				AceLog(ACE_SUSPEND.DLL_NOT_FOUND_FAIL);
			}
			this.LogErrorFormat("GameAceInit Error {0}", ex.ToString());
			EventLogger.Instance.StageLogger("GameAceInit Error " + ex, StartStageEnum.AceException);
		}
	}

	public void AddAceSelfUpdateAction(Action action)
	{
		_aceSelfAction = (Action)Delegate.Combine(_aceSelfAction, action);
	}

	private void FixedUpdate()
	{
		if (_isOpen && _aceSelfAction != null)
		{
			_aceSelfAction();
		}
	}

	private string GetSelfCid()
	{
		return StringCache.LongToString(Contexts.sharedInstance.player.myPlayerEntity.basicInfo.Cid);
	}

	public void LoginSucc()
	{
		try
		{
			if (_isOpen && !Application.isEditor && _initSucc)
			{
				string selfCid = GetSelfCid();
				AceClient.TokenData data = SingletonInstance<AceClient>.Instance.GetTokenData(Encoding.UTF8.GetBytes(selfCid));
				AntiCheatExpertResult antiCheatExpertResult = (AntiCheatExpertResult)user_loginOn_ace(ref data, 10000, 0, 0);
				AceLoginOnLog(antiCheatExpertResult);
				if (antiCheatExpertResult != 0)
				{
					this.LogErrorFormat("ACE login on failed, Ret is :{0}, Game is exiting...", antiCheatExpertResult);
					AceLog(ACE_SUSPEND.LOGIN_ON_FAIL);
					return;
				}
				_loginSucc = true;
				_sendData.AccountInfo = new TssSdkAccountInfo
				{
					AccountId = new TssSdkAccountId
					{
						Account = Encoding.Default.GetBytes(selfCid),
						AccountType = 601
					},
					GameId = _gameId,
					PlatId = 3,
					RoleId = 0L,
					ChannelId = 0,
					WorldId = 10000,
					ReserveBuf = null
				};
				this.Info("Login Success");
				InitTick();
				this.Info("--Start Send-- ");
				Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(123, new CheckFileInfo
				{
					FileName = "platform.ini",
					FilePath = PathEx.ConvertAssetPathToAbstractPath("../../platform.ini"),
					CheckResult = ((!TplManager.Instance.GameBootConfig.ConfigFileRevise) ? 1 : 0),
					CheckValue = ((TplManager.Instance.GameBootConfig.configMd5 != null) ? TplManager.Instance.GameBootConfig.configMd5 : "")
				});
				this.Info("--End Send--");
				AceLog(ACE_SUSPEND.SUCC);
			}
		}
		catch (Exception ex)
		{
			this.LogErrorFormat("LoginSucc Error {0}", ex.ToString());
			EventLogger.Instance.StageLogger("LoginSucc Error : " + ex, StartStageEnum.AceException);
		}
	}

	private void InitTick()
	{
		this.Info("Ace Tick  Tick  Tick ...");
		_tickThread = new Thread((ThreadStart)delegate
		{
			while (true)
			{
				try
				{
					IntPtr intPtr = user_tick_ace();
					if (!(intPtr == IntPtr.Zero))
					{
						AceClient.TssAntiData tssAntiData = (AceClient.TssAntiData)Marshal.PtrToStructure(intPtr, typeof(AceClient.TssAntiData));
						if (tssAntiData.data_len == 0 || tssAntiData.data == IntPtr.Zero)
						{
							this.Info("data_len > anti_data.data_len == 0 ");
						}
						else
						{
							byte[] array = new byte[tssAntiData.data_len];
							Marshal.Copy(tssAntiData.data, array, 0, (int)tssAntiData.data_len);
							_sendData.AntiData = null;
							_sendData.UserExtData = null;
							_sendData.AntiData = array;
							Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(121, _sendData);
							delete_antiData();
						}
					}
				}
				catch (Exception ex)
				{
					this.LogError("Tick Exception > " + ex);
					EventLogger.Instance.StageLogger("Tick Exception : " + ex, StartStageEnum.AceException);
				}
				Thread.Sleep(100);
			}
		})
		{
			Name = "AceTick"
		};
		_tickThread.Start();
	}

	public void Exit()
	{
		try
		{
			if (_isOpen && !Application.isEditor)
			{
				this.InfoFormat("CaculateFrameCount {0}, CaculateTime {1}", _caculateCount, _milliseconds);
				if (_tickThread != null)
				{
					_tickThread.Abort();
					_tickThread = null;
				}
				if (_loginSucc)
				{
					this.Info("Logging Off...");
					user_loginOff_ace();
				}
				if (_initSucc)
				{
					this.Info("Exiting...");
					eixt_ace();
				}
			}
		}
		catch (Exception ex)
		{
			this.LogErrorFormat("Exit Error {0}", ex.ToString());
			EventLogger.Instance.StageLogger("Exit Error : " + ex, StartStageEnum.AceException);
		}
	}

	public void ReceiveData(byte[] datas, TssSdkAccountInfo accountInfo)
	{
		try
		{
			if (_isOpen && !Application.isEditor)
			{
				AceClient.TssAntiData data = SingletonInstance<AceClient>.Instance.GetAutiData(datas);
				receive_antiData(ref data);
			}
		}
		catch (Exception ex)
		{
			this.LogErrorFormat("ReceiveData Error {0}", ex.ToString());
			EventLogger.Instance.StageLogger("ReceiveData Error : " + ex, StartStageEnum.AceException);
		}
	}

	public void AceInitLog(AntiCheatExpertResult ret)
	{
		GlobalProperties.Instance.Properties["AceInit0"] = (int)ret;
		EventLogger.Instance.StageLogger(string.Concat(ret), StartStageEnum.AceInit);
		GlobalProperties.Instance.Properties.Remove("AceInit0");
	}

	public void AceLoginOnLog(AntiCheatExpertResult ret)
	{
		GlobalProperties.Instance.Properties["AceLoginOn0"] = (int)ret;
		EventLogger.Instance.StageLogger(string.Concat(ret), StartStageEnum.AceLogin);
		GlobalProperties.Instance.Properties.Remove("AceLoginOn0");
	}

	public void AceLog(ACE_SUSPEND ret)
	{
		GlobalProperties.Instance.Properties["AceLogType0"] = (int)ret;
		EventLogger.Instance.StageLogger(string.Concat(ret), StartStageEnum.Ace);
		GlobalProperties.Instance.Properties.Remove("AceLogType0");
	}
}
