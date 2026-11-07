using Assets.Generated.Table;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Info.SkillProgress.Effect;

public class ScaleEffect : IEffect
{
	public void Effect(IUiResourcesLoader loader, WeaponSkillTable.Row config, bool isInSpecial, SkillprogressViewModel viewModel, AlphaChip iconImageAlphaChip, FrameAnimaChip effectImageFrameAnimaChip, ScaleChip iconImageScaleChip, RotationChip effectImageRotationChip)
	{
		viewModel.EffectImageShow = false;
		if (iconImageScaleChip.Scale.x <= 1f)
		{
			iconImageScaleChip.Speed = new Vector3(1f, 1f);
			iconImageScaleChip.TargetScale = new Vector3(1.5f, 1.5f, 1f);
		}
		else if (iconImageScaleChip.Scale.x >= 1.5f)
		{
			iconImageScaleChip.Speed = new Vector3(-1f, -1f);
			iconImageScaleChip.TargetScale = new Vector3(1f, 1f, 1f);
		}
	}
}
