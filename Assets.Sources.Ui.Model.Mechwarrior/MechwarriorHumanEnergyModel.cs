using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Mechwarrior;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Mechwarrior;

public class MechwarriorHumanEnergyModel : AbstractModel, IPlaybackSystem
{
	private MechwarriorHumanEnergyViewModel _viewModel;

	private static AssetInfo _weaponnoclipAsset = new AssetInfo("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/humangrowup/weaponnoclip.png");

	private static AssetInfo _movespeedAsset = new AssetInfo("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/humangrowup/movespeed.png");

	private static AssetInfo _maxhpAsset = new AssetInfo("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/humangrowup/maxhp.png");

	private static AssetInfo _superjumpAsset = new AssetInfo("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/humangrowup/superjump.png");

	private FrameAnimaChip _anima;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MechwarriorHumanEnergyViewModel();
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
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiMyPlayer_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_mechwarriorHumanEnergyData_CurrentEnergy, SetCurrentEnergy, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_mechwarriorHumanEnergyData_MaxEnergy, SetMaxEnergy, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_mechwarriorHumanEnergyData_ChangeGiftType, SetChangeGiftType, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_mechwarriorHumanEnergyData_ChangeGiftTime, SetChangeGiftTime, null, initinvoke: true);
	}

	private void SetMaxEnergy(int arg1, int arg2)
	{
		UpdateEnergy();
	}

	private void SetCurrentEnergy(int arg1, int arg2)
	{
		UpdateEnergy();
	}

	private void SetChangeGiftType(MechWarriorChargeGiftType ov, MechWarriorChargeGiftType type)
	{
		switch (type)
		{
		case MechWarriorChargeGiftType.WEAPONNOCONSUMECLIPBUFF:
			this.GetLoader().RetriveSprite(_weaponnoclipAsset, delegate(Sprite sprite)
			{
				_viewModel.EffectSprite = sprite;
			});
			break;
		case MechWarriorChargeGiftType.MOVESPEEDBUFF:
			this.GetLoader().RetriveSprite(_movespeedAsset, delegate(Sprite sprite)
			{
				_viewModel.EffectSprite = sprite;
			});
			break;
		case MechWarriorChargeGiftType.MAXHPBUFF:
			this.GetLoader().RetriveSprite(_maxhpAsset, delegate(Sprite sprite)
			{
				_viewModel.EffectSprite = sprite;
			});
			break;
		case MechWarriorChargeGiftType.SUPERJUMPBUFF:
			this.GetLoader().RetriveSprite(_superjumpAsset, delegate(Sprite sprite)
			{
				_viewModel.EffectSprite = sprite;
			});
			break;
		}
	}

	private void SetChangeGiftTime(int ov, int time)
	{
		_viewModel.GiftMessageShow = time > 0 && !_viewModel.EnergyMessageShow;
		_viewModel.MessageTimeString = (time / 1000).ToString();
	}

	private void UpdateEnergy()
	{
		if (UiIEventCondition.Get_mechwarriorHumanEnergyData_MaxEnergy() > 0)
		{
			_viewModel.ProgressFillamount = (float)UiIEventCondition.Get_mechwarriorHumanEnergyData_CurrentEnergy() / (float)UiIEventCondition.Get_mechwarriorHumanEnergyData_MaxEnergy();
			_viewModel.EnergyTextString = UiIEventCondition.Get_mechwarriorHumanEnergyData_CurrentEnergy().ToString();
			if (_viewModel.ProgressFillamount >= 1f)
			{
				_viewModel.EffectShow = true;
				_viewModel.FullImageShow = true;
				_viewModel.EnergyMessageShow = true;
			}
		}
		else
		{
			_viewModel.ProgressFillamount = 0f;
			_viewModel.EnergyTextString = "0";
			_viewModel.EffectShow = false;
			_viewModel.FullImageShow = false;
			_viewModel.EnergyMessageShow = false;
			_viewModel.GiftMessageShow = false;
		}
	}

	private void SetCareer(string ov, string career)
	{
		_viewModel.BottomShow = !PlayerCareerConstantUtility.IsMech(career) && UiIEventCondition.Get_cameraOwnerData_Observer() == 0;
	}

	private void InitChips()
	{
		_anima = new FrameAnimaChip
		{
			Path = "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/humangrowup/progresseffect",
			Delay = 125,
			Count = 4,
			IsLoop = true
		};
	}

	private void UpdateChips()
	{
		if (_viewModel.EffectShow)
		{
			_anima.Update(_timeComponent);
			if (_anima.Changed)
			{
				base.Loader.RetriveSprite("ui/mechwarriormodel", _anima.Value, delegate(Sprite sprite)
				{
					_viewModel.EffectSprite = sprite;
				});
			}
		}
		else
		{
			_anima.Index = 1;
		}
	}
}
