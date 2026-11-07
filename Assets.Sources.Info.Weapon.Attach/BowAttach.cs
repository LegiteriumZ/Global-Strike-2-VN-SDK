using Assets.Sources.Components.Weapon;

namespace Assets.Sources.Info.Weapon.Attach;

internal class BowAttach : AbstractAttach
{
	public bool isFovDown;

	public float changeFreezTotalTime = 2000f;

	public float changeDameTotalTime = 1000f;

	public float changeFoveTotalTime = 500f;

	public int focusDelayTime = 200;

	public long startAttackTime;

	public long changeDelay;

	public long fireDelay;
}
