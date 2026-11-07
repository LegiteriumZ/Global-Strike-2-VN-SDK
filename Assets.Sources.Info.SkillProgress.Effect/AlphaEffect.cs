using Assets.Generated.Table;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Info.SkillProgress.Effect;

public class AlphaEffect : IEffect
{
	public void Effect(IUiResourcesLoader loader, WeaponSkillTable.Row config, bool isInSpecial, SkillprogressViewModel viewModel, AlphaChip iconImageAlphaChip, FrameAnimaChip effectImageFrameAnimaChip, ScaleChip iconImageScaleChip, RotationChip effectImageRotationChip)
	{
		viewModel.EffectImageShow = false;
		if ((double)iconImageAlphaChip.Alpha <= 0.3)
		{
			iconImageAlphaChip.Speed = 0.7f;
		}
		else if (iconImageAlphaChip.Alpha >= 1f)
		{
			iconImageAlphaChip.Speed = -0.7f;
		}
	}
}
