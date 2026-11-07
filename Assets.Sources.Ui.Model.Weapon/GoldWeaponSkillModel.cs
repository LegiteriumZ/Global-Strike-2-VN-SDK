using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class GoldWeaponSkillModel : AbstractModel, IPlaybackSystem, ISetWeaponContext, ISetGameRuleContext
{
	private SkillprogressViewModel _viewModel;

	private WeaponContext _weaponContext;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

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
		_viewModel = new SkillprogressViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		if (_gameRuleContext.currentRule.Rule.IsGeneralPve())
		{
			base.DoSubscribe();
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/goldweaponskill/icon.png", delegate(Sprite sprite)
			{
				_viewModel.IconImageSprite = sprite;
				_viewModel.IconImageNtvsize();
			});
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/goldweaponskill/icon_bg.png", delegate(Sprite sprite)
			{
				_viewModel.BackImageSprite = sprite;
				_viewModel.BackImageNtvsize();
			});
			base.Loader.RetriveSprite("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/goldweaponskill/progress.png", delegate(Sprite sprite)
			{
				_viewModel.ProgressImageSprite = sprite;
				_viewModel.ProgressImageNtvsize();
			});
			SimpleNotify.Add(GetProgress, SetProgress);
		}
	}

	private void SetProgress(float arg1, int arg2)
	{
		_viewModel.ProgressImageFillamount = arg1;
		_viewModel.IconImageShow = arg1 >= 1f;
	}

	private float GetProgress(int arg1)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			if (!currentWeaponEntity.hasPower || currentWeaponEntity.power.RpgMaxPower < 1)
			{
				return 0f;
			}
			return (float)_gameRuleContext.tdSkillStateData.CurrentMp / (float)currentWeaponEntity.power.RpgMaxPower;
		}
		return 0f;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
