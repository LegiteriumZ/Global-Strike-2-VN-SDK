using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Mechwarrior;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Mechwarrior;

public class MechwarriorHeroGrowupModel : AbstractModel, IPlaybackSystem
{
	private MechwarriorHeroGrowupViewModel _viewModel;

	private int _getEffectTime;

	private const int EnergyEffectTime = 416;

	private float _CurrentEnergy;

	private FrameAnimaChip _effectFrameAnimaChip = new FrameAnimaChip();

	private ScaleChip _skillImageScaleChip = new ScaleChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MechwarriorHeroGrowupViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_getEffectTime <= 3000)
		{
			_getEffectTime += _timeComponent.FrameInterval;
			if (_getEffectTime <= 416)
			{
				_viewModel.GetEnergyEffectRotation = Quaternion.Euler(new Vector3(0f, 0f, (float)_getEffectTime / 416f * 360f));
				_viewModel.GetEnergyEffectScale = Vector3.one * (416 - _getEffectTime) / 416f;
				if ((float)_getEffectTime < 208f)
				{
					_viewModel.GetEnergyEffectAlpha = (float)_getEffectTime / 208f;
				}
				else
				{
					_viewModel.GetEnergyEffectAlpha = (float)(416 - _getEffectTime) / 208f;
				}
			}
			else
			{
				_viewModel.GetEnergyEffectShow = false;
			}
			if (_getEffectTime > 3000)
			{
				_viewModel.MessageShow = false;
			}
		}
		_CurrentEnergy += (float)(Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.EnergySpeed * _timeComponent.FrameInterval) * 0.001f;
		if (_CurrentEnergy < 0f)
		{
			_CurrentEnergy = 0f;
		}
		else if (_CurrentEnergy > (float)Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.MaxEnergy)
		{
			_CurrentEnergy = Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.MaxEnergy;
		}
		UpdateEnergy();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiMyPlayer_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_mechwarriorHeroGrowupData_CurrentEnergy, SetCurrentEnergy, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_mechwarriorHeroGrowupData_MaxEnergy, SetMaxEnergy, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_mechwarriorHeroGrowupData_Lv, SetLv, null, initinvoke: true);
		NotifyManager.MakeNotify(63, UiIEventCondition.Get_mechwarriorHeroGrowupData_GetEnergy, SetGetEnergy, initinvoke: true);
		NotifyManager.MakeNotifyClass(62, UiIEventCondition.Get_mechwarriorHeroGrowupData_EnergyPlayerName, SetEnergyPlayerName, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_mechwarriorHeroGrowupData_CurrentExp, SetCurrentExp, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_mechwarriorHeroGrowupData_MaxExp, SetMaxExp, null, initinvoke: true);
	}

	private void SetMaxEnergy(int arg1, int arg2)
	{
		UpdateEnergy();
	}

	private void SetCurrentEnergy(int arg1, int arg2)
	{
		_CurrentEnergy = Contexts.sharedInstance.gameRule.mechwarriorHeroGrowupData.CurrentEnergy;
	}

	private void SetMaxExp(int ov, int maxExp)
	{
		_viewModel.MaxExpTextString = maxExp.ToString();
		_viewModel.ExpProgressFillamount = ((UiIEventCondition.Get_mechwarriorHeroGrowupData_MaxExp() > 0) ? ((float)UiIEventCondition.Get_mechwarriorHeroGrowupData_CurrentExp() / (float)UiIEventCondition.Get_mechwarriorHeroGrowupData_MaxExp()) : 0f);
	}

	private void SetCurrentExp(int ov, int exp)
	{
		_viewModel.ExpTextString = exp.ToString();
		_viewModel.ExpProgressFillamount = ((UiIEventCondition.Get_mechwarriorHeroGrowupData_MaxExp() > 0) ? ((float)UiIEventCondition.Get_mechwarriorHeroGrowupData_CurrentExp() / (float)UiIEventCondition.Get_mechwarriorHeroGrowupData_MaxExp()) : 0f);
	}

	private void SetEnergyPlayerName(string ov, string name)
	{
		_viewModel.PlayerNameString = name;
	}

	private void SetGetEnergy(bool ov, bool flag)
	{
		_viewModel.GetEnergyEffectShow = flag;
		_viewModel.MessageShow = flag;
		if (flag)
		{
			_getEffectTime = 0;
		}
	}

	private void SetLv(int ov, int lv)
	{
		_viewModel.LevelTextString = lv.ToString();
		_viewModel.EffectShow = lv >= 5;
		if (lv >= 4)
		{
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/herogrowup/levelmech4.png", delegate(Sprite sprite)
			{
				_viewModel.SkillImageSprite = sprite;
			});
		}
		else if (lv == 1)
		{
			base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/herogrowup/levelmech1.png", delegate(Sprite sprite)
			{
				_viewModel.SkillImageSprite = sprite;
			});
		}
		else
		{
			string uiMyPlayer_Career = UiIEventCondition.Get_uiMyPlayer_Career();
			if (!(uiMyPlayer_Career == "mechfar"))
			{
				if (uiMyPlayer_Career == "mechnear")
				{
					base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/herogrowup/nearskill.png", delegate(Sprite sprite)
					{
						_viewModel.SkillImageSprite = sprite;
					});
				}
				else
				{
					base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/herogrowup/bombskill.png", delegate(Sprite sprite)
					{
						_viewModel.SkillImageSprite = sprite;
					});
				}
			}
			else
			{
				base.Loader.RetriveSprite("ui/mechwarriormodel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/herogrowup/farskill.png", delegate(Sprite sprite)
				{
					_viewModel.SkillImageSprite = sprite;
				});
			}
		}
		if (lv > 0)
		{
			_skillImageScaleChip.Scale = Vector3.one;
		}
		if (lv >= 5)
		{
			_viewModel.EffectShow = true;
		}
	}

	private void UpdateEnergy()
	{
		_viewModel.EnergyTextString = ((int)_CurrentEnergy).ToString();
		_viewModel.EnergyProgressFillamount = ((UiIEventCondition.Get_mechwarriorHeroGrowupData_MaxEnergy() > 0) ? (_CurrentEnergy / (float)UiIEventCondition.Get_mechwarriorHeroGrowupData_MaxEnergy() * 0.842f + 0.078f) : 0f);
	}

	private void SetCareer(string ov, string career)
	{
		_viewModel.BottomShow = PlayerCareerConstantUtility.IsMech(career);
	}

	private void InitChips()
	{
		_skillImageScaleChip.Scale = new Vector3(1f, 1f, 1f);
		_skillImageScaleChip.TargetScale = new Vector3(0.8f, 0.8f, 1f);
		_skillImageScaleChip.Speed = new Vector3(-1f, -1f, 0f);
		_effectFrameAnimaChip.IsLoop = true;
		_effectFrameAnimaChip.Delay = 125;
		_effectFrameAnimaChip.Count = 4;
		_effectFrameAnimaChip.Path = "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/herogrowup/progresseffect";
	}

	private void UpdateChips()
	{
		if (_viewModel.EffectShow)
		{
			_effectFrameAnimaChip.Update(_timeComponent);
			if (_effectFrameAnimaChip.Changed)
			{
				base.Loader.RetriveSprite("ui/mechwarriormodel", _effectFrameAnimaChip.Value, delegate(Sprite sprite)
				{
					_viewModel.EffectSprite = sprite;
				});
			}
		}
		_viewModel.SkillImageScale = _skillImageScaleChip.Update(_timeComponent);
	}
}
