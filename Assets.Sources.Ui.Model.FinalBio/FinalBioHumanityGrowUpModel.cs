using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.ViewModel.Biochemical;
using I2.Loc;

namespace Assets.Sources.Ui.Model.FinalBio;

public class FinalBioHumanityGrowUpModel : BiochemicalHumanityGrowUpModel
{
	protected override void UpdateHeroText(int level)
	{
		((BiochemicalhumanitygrowupViewModel)ViewModel).HeroTextString = ScriptLocalization.Get("AttackBonusPercentage") + (100 + level * 10) + "%";
	}
}
