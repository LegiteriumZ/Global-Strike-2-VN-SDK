using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Input;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class StrokeAnalysisModel : AbstractModel, IPlaybackSystem, IKeyboardResponder, ISetGameRuleContext
{
	private StrokeAnalysisViewModel _viewModel;

	private const int MaxUiItemCount = 10;

	private KillPlayerInfoData _bekilledData;

	private GameRuleContext _gameRuleContext;

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private int _killByC4;

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel = new StrokeAnalysisViewModel();
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowShow = false;
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		if (!_gameRuleContext.currentRule.Rule.IsBio() && !RuleUtilty.IsOldPve(raceType) && !UiIEventCondition.Get_uiRoomData_IsObserver() && !_gameRuleContext.currentRule.Rule.IsPve())
		{
			NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_IsDead, SetIsDead, null, initinvoke: true);
			_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsDead, SetMyIsDead, null, initinvoke: true));
			NotifyManager.MakeNotifyClass(22, UiIEventCondition.Get_killPlayerInfo_InfoList, SetInfoList, initinvoke: true);
			_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_gameMessageData_MessageData, SetMessageData, null, initinvoke: true));
			_notifyGroup.Add(NotifyManager.MakeNotifyClass(36, UiIEventCondition.Get_damageCountData_DamageDataList, SetDamageDataList, initinvoke: true));
			_notifyGroup.SetSuspend(suspend: true);
		}
	}

	private void SetMyIsDead(bool arg1, bool arg2)
	{
		if (!arg2)
		{
			_viewModel.ShowShow = false;
			_notifyGroup.SetSuspend(suspend: true);
		}
	}

	private void SetInfoList(Queue<KillPlayerInfoData> arg1, Queue<KillPlayerInfoData> arg2)
	{
		_bekilledData = null;
		foreach (KillPlayerInfoData killPlayerInfo_Info in UiIEventCondition.Get_killPlayerInfo_InfoList())
		{
			if (!(killPlayerInfo_Info.BeKillPlayerName != UiIEventCondition.Get_uiMyPlayer_PlayerName()))
			{
				if (killPlayerInfo_Info.CurKillNum == 0 || killPlayerInfo_Info.WeaponName == "c4")
				{
					_killByC4 = 1000;
					_viewModel.ShowShow = false;
					_notifyGroup.SetSuspend(suspend: true);
					return;
				}
				_bekilledData = killPlayerInfo_Info;
			}
		}
		RefreshKillInfo();
	}

	private void SetIsDead(bool arg1, bool arg2)
	{
		if (!_viewModel.KillInfoShow && UiIEventCondition.Get_cameraOwnerData_IsDead() && UiIEventCondition.Get_cameraOwnerData_PlayerId() == UiIEventCondition.Get_uiMyPlayer_PlayerId() && _killByC4 <= 0)
		{
			_viewModel.ShowShow = true;
			_viewModel.KillInfoShow = true;
			_notifyGroup.SetSuspend(suspend: false);
		}
		if (_viewModel.KillInfoShow && !UiIEventCondition.Get_cameraOwnerData_IsDead())
		{
			_viewModel.KillInfoShow = false;
		}
		if (arg2)
		{
			SetDamageDataList(null, UiIEventCondition.Get_damageCountData_DamageDataList());
		}
	}

	private void SetMessageData(GameMessageData ov, GameMessageData messageData)
	{
		if (messageData != null)
		{
			GameMessageType type = messageData.Type;
			if (type == GameMessageType.SHOWNEXTBATTLE)
			{
				_viewModel.ShowShow = false;
				_notifyGroup.SetSuspend(suspend: true);
			}
		}
	}

	private void SetDamageDataList(List<DamageData> ov, List<DamageData> damageList)
	{
		for (int i = 0; i < 10; i++)
		{
			int index = i + 1;
			_viewModel.SetVictimNameShow(index, value: false);
		}
		for (int j = 0; j < damageList.Count; j++)
		{
			int index2 = j + 1;
			_viewModel.SetVictimNameShow(index2, value: true);
			_viewModel.SetDamageString(index2, StringCache.IntToString(damageList[j].Damage));
			_viewModel.SetVictimNameString(index2, damageList[j].PlayerName);
			_viewModel.SetKillIconEnabled(index2, damageList[j].IsDead);
		}
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			_killByC4 -= _timeComponent.FrameInterval;
		}
	}

	private void RefreshKillInfo()
	{
		if (_bekilledData == null)
		{
			return;
		}
		_viewModel.KillerNameString = _bekilledData.KillPlayerName;
		_viewModel.WeaponNameString = LanguageUtils.GetWeaponCnName(_bekilledData.WeaponName);
		IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(_bekilledData.WeaponName);
		if (weaponInfo == null)
		{
			return;
		}
		AssetInfo weaponIconAssetInfo = weaponInfo.GetWeaponIconAssetInfo(_bekilledData.WeaponSkinName);
		this.GetLoader().RetriveSprite(weaponIconAssetInfo, delegate(Sprite v)
		{
			_viewModel.WeaponSprite = v;
			_viewModel.WeaponNtvsize();
			if (v.rect.width > 200f)
			{
				_viewModel.WeaponScale = Vector3.one * 200f / v.rect.width;
			}
			else if (v.rect.height > 64f)
			{
				_viewModel.WeaponScale = Vector3.one * 64f / v.rect.height;
			}
		});
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.Equals)
		{
			if (_gameRuleContext.currentRule.Rule.IsRpg())
			{
				return false;
			}
			if (!_viewModel.ShowShow)
			{
				return false;
			}
			_viewModel.KillInfoShow = !_viewModel.KillInfoShow;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
