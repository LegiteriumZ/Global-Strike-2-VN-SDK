using Assets.Generated.Table;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Info.SkillProgress.Effect;

public class NoneEffect : IEffect
{
	public void Effect(IUiResourcesLoader loader, WeaponSkillTable.Row config, bool isInSpecial, SkillprogressViewModel viewModel, AlphaChip iconImageAlphaChip, FrameAnimaChip effectImageFrameAnimaChip, ScaleChip iconImageScaleChip, RotationChip effectImageRotationChip)
	{
		iconImageAlphaChip.Alpha = 1f;
		iconImageAlphaChip.Speed = 0f;
		iconImageScaleChip.Scale = Vector3.one;
		iconImageScaleChip.TargetScale = Vector3.one;
		effectImageRotationChip.Speed = Vector3.zero;
		viewModel.EffectImageShow = false;
	}
}
