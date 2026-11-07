using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.ViewModel.Biochemical;
using I2.Loc;

namespace Assets.Sources.Ui.Model.SuperBio;

public class SuperBioHumanityGrowUpModel : BiochemicalHumanityGrowUpModel
{
	protected override void UpdateHeroText(int level)
	{
		((BiochemicalhumanitygrowupViewModel)ViewModel).HeroTextString = ScriptLocalization.Get("AttackBonusPercentage") + (100 + level * 7) + "%";
	}
}
