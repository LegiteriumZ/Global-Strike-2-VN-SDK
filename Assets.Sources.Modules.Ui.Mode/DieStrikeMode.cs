using Assets.Sources.Ui.Model.Pve;

namespace Assets.Sources.Modules.Ui.Mode;

public class DieStrikeMode : AbstractMode
{
	public DieStrikeMode(Contexts contexts)
		: base(contexts)
	{
		AbstractMode.AddTowerDefenseGui(this);
		AddPlaybackSystem(new DiestrikeuitrasonicModel());
	}
}
