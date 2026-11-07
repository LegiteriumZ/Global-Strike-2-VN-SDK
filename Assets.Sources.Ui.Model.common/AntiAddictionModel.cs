using System.Collections.Generic;
using System.Diagnostics;
using Assets.Sources.Config;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.SimpleJson;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class AntiAddictionModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ICursorControl
{
	private AntiAddictionViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private int _finalDelay = -1;

	private Dictionary<string, JObject> _jObjects = new Dictionary<string, JObject>();

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new AntiAddictionViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowRootshow = false;
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_Addiction, InitAddiction, null, initinvoke: true, isFrameSeparation: true);
		_viewModel.CreateTriggerEntry(_viewModel.CloseTriggers, EventTriggerType.PointerClick, CloseBtnClick);
		_viewModel.CreateTriggerEntry(_viewModel.ComfirmTriggers1, EventTriggerType.PointerClick, ComfirmBtn1);
		_viewModel.CreateTriggerEntry(_viewModel.ComfirmTriggers2, EventTriggerType.PointerClick, ComfirmBtn2);
		_viewModel.CreateTriggerEntry(_viewModel.ComfirmTriggers3, EventTriggerType.PointerClick, ComfirmBtn3);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		if (_finalDelay > 0)
		{
			_finalDelay -= _timeComponent.FrameInterval;
			if (_finalDelay < 0)
			{
				JObjectDataHandler("final");
			}
		}
	}

	private void ResetFinal()
	{
		_finalDelay = -1;
	}

	private void JObjectDataHandler(string sign)
	{
		if (!_jObjects.ContainsKey(sign))
		{
			return;
		}
		if (sign == "final" || sign == "close")
		{
			if (_jObjects[sign] != null)
			{
				string data = "";
				_jObjects[sign].TryGetJsonData(ref data, "url");
				Application.OpenURL(data);
			}
			_viewModel.ShowRootshow = false;
		}
		else
		{
			JObject data2 = null;
			if (_jObjects[sign].TryGetJsonData(ref data2, "url_info"))
			{
				string data3 = "";
				data2.TryGetJsonData(ref data3, "url");
				Application.OpenURL(data3);
			}
			string data4 = "";
			_jObjects[sign].TryGetJsonData(ref data4, "func");
			switch (data4)
			{
			case "exit_game":
				ExitGame();
				break;
			case "switch_account":
				ExitGame();
				break;
			case "exit_popup":
				_viewModel.ShowRootshow = false;
				break;
			}
		}
		ResetFinal();
	}

	private void ExitGame()
	{
		this.Info("AntiAddiction Exit Game");
		UnityMainThreadDispatcher.Enqueue(delegate
		{
			MonoBehaviourSingleton<GameExitManager>.Instance.ExitGame();
			ExecuteGG.CloseNPGameMon();
			if (!Application.isEditor)
			{
				Process.GetCurrentProcess().Kill();
			}
		});
		UnityProxyData message = new UnityProxyData
		{
			Type = UnityProxyType.EVENT,
			Func = "CLOSE_GAME",
			Key = TplManager.Instance.GameBootConfig.Sign
		};
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(23, message);
	}

	private void CloseBtnClick(BaseEventData data)
	{
		JObjectDataHandler("close");
	}

	private void ComfirmBtn1(BaseEventData data)
	{
		JObjectDataHandler("button_1");
	}

	private void ComfirmBtn2(BaseEventData data)
	{
		JObjectDataHandler("button_2");
	}

	private void ComfirmBtn3(BaseEventData data)
	{
		JObjectDataHandler("button_3");
	}

	private void InitAddiction(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_battleRoomContext.antiAddiction.IsRefresh = false;
			ParseAddictionJObject();
		}
	}

	private void SetPosition(int all)
	{
		switch (all)
		{
		case 1:
			_viewModel.SetComfirmPosition(1, new Vector3(0f, 8f, 0f));
			break;
		case 2:
			_viewModel.SetComfirmPosition(1, new Vector3(-130f, 8f, 0f));
			_viewModel.SetComfirmPosition(2, new Vector3(130f, 8f, 0f));
			break;
		default:
			_viewModel.SetComfirmPosition(1, new Vector3(-170f, 8f, 0f));
			_viewModel.SetComfirmPosition(2, new Vector3(10f, 8f, 0f));
			_viewModel.SetComfirmPosition(3, new Vector3(196f, 8f, 0f));
			break;
		}
	}

	private void ParseAddictionJObject()
	{
		_jObjects.Clear();
		_viewModel.ShowRootshow = false;
		_viewModel.ShowRootshow = true;
		JObject antiJObject = _battleRoomContext.antiAddiction.AntiJObject;
		string data = "";
		string data2 = "";
		bool data3 = false;
		List<JObject> data4 = new List<JObject>();
		antiJObject.TryGetJsonData(ref data, "title");
		antiJObject.TryGetJsonData(ref data2, "content");
		antiJObject.TryGetJsonData(ref data3, "isTipsEmpty");
		_viewModel.TitleString = data;
		_viewModel.TitleContentString = data2;
		_viewModel.TipsString = ScriptLocalization.Get("REMNDER");
		_viewModel.TipsShow = !data3;
		_viewModel.TipsContentShow = !data3;
		_viewModel.TipsContentString = "";
		if (!data3)
		{
			antiJObject.TryGetJsonData(ref data4, "tips");
			for (int i = 0; i < data4.Count; i++)
			{
				_viewModel.TipsContentString += data4[i].StringValue;
				_viewModel.TipsContentString += "\n\n";
			}
		}
		List<JObject> data5 = new List<JObject>();
		antiJObject.TryGetJsonData(ref data5, "buttons");
		for (int j = 0; j < 3; j++)
		{
			_viewModel.SetComfirmShow(j + 1, value: false);
		}
		for (int k = 0; k < data5.Count; k++)
		{
			_viewModel.SetComfirmShow(k + 1, value: true);
			string data6 = "";
			data5[k].TryGetJsonData(ref data6, "name");
			_viewModel.SetchattextString(k + 1, data6);
			string key = "button_" + (k + 1);
			_jObjects.Add(key, data5[k]);
		}
		SetPosition(data5.Count);
		_viewModel.CloseShow = false;
		JObject data7 = null;
		if (antiJObject.TryGetJsonData(ref data7, "close_button"))
		{
			bool data8 = false;
			_viewModel.CloseShow = data7.TryGetJsonData(ref data8, "show");
			string key2 = "close";
			JObject data9 = null;
			data7.TryGetJsonData(ref data9, "url_info");
			_jObjects.Add(key2, data9);
		}
		JObject data10 = null;
		if (antiJObject.TryGetJsonData(ref data10, "final"))
		{
			data10.TryGetJsonData(ref _finalDelay, "time");
			_finalDelay *= 1000;
			string key3 = "final";
			JObject data11 = null;
			data10.TryGetJsonData(ref data11, "url_info");
			_jObjects.Add(key3, data11);
		}
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowRootshow)
		{
			return 0;
		}
		return 1048576;
	}

	public int GetForbidButtons()
	{
		return 175;
	}
}
