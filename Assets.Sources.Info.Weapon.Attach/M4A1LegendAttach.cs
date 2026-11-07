using Assets.Sources.Components.Weapon;

namespace Assets.Sources.Info.Weapon.Attach;

internal class M4A1LegendAttach : AbstractAttach
{
	public const int Level1 = 1;

	public const int Level2 = 2;

	public const int Level3 = 4;

	public const int MaxEffectTime = 500;

	public int StartTime;

	public int OriginalLevel;

	public int TargetLevel;

	public float OriginalCiScale;

	public float OriginalDaorenScale = 0.5f;
}
