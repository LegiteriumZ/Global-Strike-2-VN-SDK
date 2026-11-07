using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class SkillSmallProgressModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private SkillSmallProgressViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
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
		_viewModel = new SkillSmallProgressViewModel();
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
		base.DoSubscribe();
		if (!RuleUtilty.IsPveModel(_battleRoomContext.roomData.Data.RaceType))
		{
			_viewModel.dunShow = false;
		}
		SetUI();
		NotifyManager.MakeTempNotify(GetDunProgress, SetDunProgress, null, initinvoke: true);
	}

	private void SetDunProgress(float arg1, float arg2)
	{
		_viewModel.DunProgressFillamount = arg2;
	}

	private float GetDunProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasPower)
		{
			return 0f;
		}
		if (currentWeaponEntity.power.MaxPower2 != 0)
		{
			return (float)currentWeaponEntity.power.Power2 / (float)currentWeaponEntity.power.MaxPower2;
		}
		return 0f;
	}

	private void SetUI()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo)
		{
			base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/progressBg.png", delegate(Sprite sprite)
			{
				_viewModel.dunSprite = sprite;
				_viewModel.dunNtvsize();
			});
			base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/progress.png", delegate(Sprite sprite)
			{
				_viewModel.DunProgressSprite = sprite;
				_viewModel.DunProgressNtvsize();
			});
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
