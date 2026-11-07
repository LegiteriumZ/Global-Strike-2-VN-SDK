using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class SkillMessageProgressModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private SkillMessageProgressViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

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
		_viewModel = new SkillMessageProgressViewModel();
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
			_viewModel.RightBottomShow = false;
		}
		SetUI();
		NotifyManager.MakeTempNotify(GetDunProgress, SetDunProgress, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetDunShow, SetDunShow, null, initinvoke: true);
	}

	private void SetUI()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo)
		{
			base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/skillProgress.png", delegate(Sprite sprite)
			{
				_viewModel.DunProgressSprite = sprite;
				_viewModel.DunProgressNtvsize();
			});
			base.Loader.RetriveSprite($"weapon/{currentWeaponEntity.basicInfo.Info.Name}", $"Assets/Res/Assets/weapon/{currentWeaponEntity.basicInfo.Info.Name}/ui/skill.png", delegate(Sprite sprite)
			{
				_viewModel.SkillMessageSprite = sprite;
				_viewModel.SkillMessageNtvsize();
			});
		}
	}

	private void SetDunProgress(float arg1, float arg2)
	{
		if (arg2 == 0f)
		{
			_viewModel.dunShow = false;
			return;
		}
		_viewModel.dunShow = true;
		_viewModel.DunProgressFillamount = arg2;
	}

	private float GetDunProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.hasClip)
		{
			return 0f;
		}
		if (currentWeaponEntity.clip.CarryClip2 != 0)
		{
			return (float)currentWeaponEntity.clip.Clip2 / (float)currentWeaponEntity.clip.CarryClip2;
		}
		return 0f;
	}

	private void SetDunShow(bool arg1, bool arg2)
	{
		_viewModel.SkillMessageShow = arg2;
	}

	private bool GetDunShow()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (!_viewModel.ViewGameObject.activeSelf || currentWeaponEntity == null || (!currentWeaponEntity.hasPower && !currentWeaponEntity.hasClip))
		{
			return false;
		}
		if (currentWeaponEntity.power.MaxPower2 != 0)
		{
			if (currentWeaponEntity.power.Power2 / currentWeaponEntity.power.MaxPower2 >= 1)
			{
				return currentWeaponEntity.clip.Clip2 == 0;
			}
			return false;
		}
		return false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
