using Assets.Generated.Table;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Info.SkillProgress.Effect;

public class RotationEffect : IEffect
{
	public void Effect(IUiResourcesLoader loader, WeaponSkillTable.Row config, bool isInSpecial, SkillprogressViewModel viewModel, AlphaChip iconImageAlphaChip, FrameAnimaChip effectImageFrameAnimaChip, ScaleChip iconImageScaleChip, RotationChip effectImageRotationChip)
	{
		if (isInSpecial)
		{
			viewModel.EffectImageShow = true;
			viewModel.EffectImagePosition = config.EffectPos;
			viewModel.EffectImageSprite = loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(config.Name), UiAssetBundleUtils.GetWeaponTexturePath(config.Name, config.FrameName));
			viewModel.EffectImageNtvsize();
			effectImageRotationChip.Speed = new Vector3(0f, 0f, -360f);
		}
		else
		{
			viewModel.EffectImageShow = false;
			effectImageRotationChip.Speed = Vector3.zero;
		}
	}
}
