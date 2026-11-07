using Assets.Sources.Components.Weapon;

namespace Assets.Sources.Info.Weapon.Attach;

internal class BowBurnAttach : AbstractAttach
{
	public int focusDelayTime = 200;

	public int focusEndIntvalTime = 1000;

	public int focusDamageMin = 85;

	public int focusDamageMax = 125;

	public bool isInit;

	public int arrowType;
}
