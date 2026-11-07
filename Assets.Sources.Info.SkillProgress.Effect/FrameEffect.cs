using Assets.Generated.Table;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Info.SkillProgress.Effect;

public class FrameEffect : IEffect
{
	public void Effect(IUiResourcesLoader loader, WeaponSkillTable.Row config, bool isInSpecial, SkillprogressViewModel viewModel, AlphaChip iconImageAlphaChip, FrameAnimaChip effectImageFrameAnimaChip, ScaleChip iconImageScaleChip, RotationChip effectImageRotationChip)
	{
		viewModel.EffectImageShow = true;
		viewModel.EffectImagePosition = config.EffectPos;
		if (effectImageFrameAnimaChip.Path != config.FrameName)
		{
			effectImageFrameAnimaChip.StartIndex = config.FrameStart;
			effectImageFrameAnimaChip.Count = config.FrameCount;
			effectImageFrameAnimaChip.Delay = 1000 / config.FrameCount;
			effectImageFrameAnimaChip.IsLoop = true;
			effectImageFrameAnimaChip.Path = config.FrameName;
			effectImageFrameAnimaChip.Extension = "";
		}
		else
		{
			viewModel.EffectImageSprite = loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(config.Name), UiAssetBundleUtils.GetWeaponTexturePath(config.Name, effectImageFrameAnimaChip.Value));
			viewModel.EffectImageNtvsize();
		}
	}
}
