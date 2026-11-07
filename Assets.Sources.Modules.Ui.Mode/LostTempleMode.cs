namespace Assets.Sources.Modules.Ui.Mode;

public class LostTempleMode : AbstractMode
{
	public LostTempleMode(Contexts contexts)
		: base(contexts)
	{
		AbstractMode.AddTowerDefenseGui(this);
	}
}
