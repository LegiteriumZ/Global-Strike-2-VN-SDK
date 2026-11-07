using Assets.Generated.Table;

namespace Assets.Sources.Info.SkillProgress;

public interface ISkillProgressInfo
{
	ICanUse CanUse { get; set; }

	ICd Cd { get; set; }

	IProgress Progress { get; set; }

	IVisiable Visiable { get; set; }

	IEffect Effect { get; set; }

	ISpecial Special { get; set; }

	IProgressVisiable ProgressVisiable { get; set; }

	WeaponSkillTable.Row Config { get; set; }
}
