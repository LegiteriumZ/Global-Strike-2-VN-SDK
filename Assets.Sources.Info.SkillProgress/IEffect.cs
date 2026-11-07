using Assets.Generated.Table;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Info.SkillProgress;

public interface IEffect
{
	void Effect(IUiResourcesLoader loader, WeaponSkillTable.Row config, bool isInSpecial, SkillprogressViewModel viewModel, AlphaChip iconImageAlphaChip, FrameAnimaChip effectImageFrameAnimaChip, ScaleChip iconImageScaleChip, RotationChip effectImageRotationChip);
}
