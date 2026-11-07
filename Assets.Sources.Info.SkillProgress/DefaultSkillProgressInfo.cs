using Assets.Generated.Table;

namespace Assets.Sources.Info.SkillProgress;

public class DefaultSkillProgressInfo : ISkillProgressInfo
{
	public ICanUse CanUse { get; set; }

	public ICd Cd { get; set; }

	public IProgress Progress { get; set; }

	public IVisiable Visiable { get; set; }

	public IEffect Effect { get; set; }

	public ISpecial Special { get; set; }

	public IProgressVisiable ProgressVisiable { get; set; }

	public WeaponSkillTable.Row Config { get; set; }
}
