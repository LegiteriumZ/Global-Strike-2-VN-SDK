namespace Assets.Sources.Info.Weapon.Attach;

internal class MikadukiSwordAttach : MikadukiSwordBaseAttach
{
	public override void Init()
	{
		randomMin = 200;
		randomMax = 300;
		maxValue = 400;
		pardon = 50;
		offset = -25;
	}
}
