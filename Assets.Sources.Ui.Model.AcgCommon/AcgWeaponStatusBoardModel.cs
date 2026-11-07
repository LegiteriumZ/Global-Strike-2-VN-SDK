using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.AcgCommon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJRunTimeDataSample.Utility;
using UnityEngine;

namespace Assets.Sources.Ui.Model.AcgCommon;

[GameUiTest]
public class AcgWeaponStatusBoardModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private AcgWeaponStatusBoardViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private Color OrangeYellow = new Color(1f, 0.75f, 0f);

	private Color Orange = new Color(1f, 0.5f, 0f);

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new AcgWeaponStatusBoardViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_CurrentClip1, SetCurrentClip, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponState_CarryClip1, SetBackClip, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponIcon, null, initinvoke: true);
	}

	private void SetWeaponIcon(string oldStr, string newStr)
	{
		base.Loader.RetriveSprite("ui/acgcommonmodel", "Assets/Res/Assets/ui/GameGUIRes/AcgCommonModel/WeaponStatusBoard/" + newStr + ".png", delegate(Sprite sprite)
		{
			_viewModel.WeaponIconImage.sprite = sprite;
		});
	}

	private void SetCurrentClip(int oldInt, int newInt)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo && currentWeaponEntity.basicInfo.Data != null)
		{
			float num = (float)newInt / (float)_weaponContext.currentWeaponEntity.basicInfo.Data.MaxClip;
			if (num > 0.7f)
			{
				_viewModel.CurrentClipTextcolor = Color.white;
			}
			else if (num <= 0.7f && num > 0.5f)
			{
				_viewModel.CurrentClipTextcolor = Color.yellow;
			}
			else if (num <= 0.5f && num > 0.3f)
			{
				_viewModel.CurrentClipTextcolor = OrangeYellow;
			}
			else if (num <= 0.3f && num > 0.1f)
			{
				_viewModel.CurrentClipTextcolor = Orange;
			}
			else
			{
				_viewModel.CurrentClipTextcolor = Color.red;
			}
			_viewModel.CurrentClipString = StringCache.IntToString(newInt);
		}
	}

	private void SetBackClip(int oldInt, int newInt)
	{
		_viewModel.BackClipString = StringCache.IntToString(newInt);
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
