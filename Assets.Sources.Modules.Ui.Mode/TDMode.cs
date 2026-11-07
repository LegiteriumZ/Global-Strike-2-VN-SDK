namespace Assets.Sources.Modules.Ui.Mode;

public class TDMode : AbstractMode
{
	public TDMode(Contexts contexts)
		: base(contexts)
	{
		AbstractMode.AddTowerDefenseGui(this);
	}
}
