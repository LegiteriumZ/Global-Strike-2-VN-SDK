using Assets.Sources.Constant.Career;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Biochemical;

namespace Assets.Sources.Ui.Model.Mechwarrior;

public class MechwarriorSkillIconModel : BiochemicalSkillIconModel
{
	public override void Initialize()
	{
		_assetBundle = "ui/mechwarriormodel";
		_assetPath = "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/skillicon/";
		base.Initialize();
	}

	public override void OnPlayback()
	{
		if (_playerContext.isMyPlayer)
		{
			for (int i = 1; i < 5; i++)
			{
				_viewModel.SetBackImageShow(i, value: false);
				_viewModel.SetWaitImageShow(i, value: false);
				_viewModel.SetMaskImageFillamount(i, 0f);
				_viewModel.SetBackImageShow(i, value: false);
				_viewModel.SetTimeTextShow(i, value: false);
				_viewModel.SetEffectImageShow(i, value: false);
				_viewModel.SetMpTextShow(i, value: false);
				_viewModel.SetSkillShow(i, value: false);
			}
			UpdateSkillImage(1, 106);
			UpdateFlySkill(2);
			UpdateEnergySkill(3);
		}
	}

	private void UpdateEnergySkill(int index)
	{
		if (PlayerCareerConstantUtility.IsHumanity(UiIEventCondition.Get_uiMyPlayer_Career()))
		{
			UpdateSkillBackImage(index, 59);
			if (UiIEventCondition.Get_mechwarriorHumanEnergyData_CurrentEnergy() == UiIEventCondition.Get_mechwarriorHumanEnergyData_MaxEnergy() && UiIEventCondition.Get_mechwarriorHumanEnergyData_MaxEnergy() > 0)
			{
				_viewModel.SetBackImageShow(index, value: true);
				_viewModel.SetWaitImageShow(index, value: false);
			}
			else
			{
				_viewModel.SetBackImageShow(index, value: false);
				_viewModel.SetWaitImageShow(index, value: true);
			}
			_viewModel.SetSkillShow(index, value: true);
		}
		else
		{
			_viewModel.SetSkillShow(index, value: false);
		}
	}

	private void UpdateFlySkill(int index)
	{
		if (PlayerCareerConstantUtility.IsMech(UiIEventCondition.Get_uiMyPlayer_Career()))
		{
			UpdateSkillBackImage(index, 58);
			if (UiIEventCondition.Get_uiMyPlayer_Lv() >= 2)
			{
				if (UiIEventCondition.Get_mechwarriorHeroGrowupData_CurrentEnergy() > 50)
				{
					_viewModel.SetBackImageShow(index, value: true);
					_viewModel.SetWaitImageShow(index, value: false);
				}
				else
				{
					_viewModel.SetBackImageShow(index, value: false);
					_viewModel.SetWaitImageShow(index, value: true);
				}
				_viewModel.SetSkillShow(index, value: true);
			}
		}
		else
		{
			_viewModel.SetSkillShow(index, value: false);
		}
	}

	protected override void UpdateSkillBackImage(int index, int skillName)
	{
		switch (skillName)
		{
		case 55:
			UpdateSkillImageState(index, "rush", "waitrush");
			break;
		case 56:
			UpdateSkillImageByModel(index, "cover", "waitcover");
			break;
		case 58:
			UpdateSkillImageByModel(index, "fly", "waitfly");
			break;
		case 59:
			UpdateSkillImageByModel(index, "energy", "waitenergy");
			break;
		case 77:
			UpdateSkillImageByModel(index, "energyball", "waitenergyball");
			break;
		}
	}
}
