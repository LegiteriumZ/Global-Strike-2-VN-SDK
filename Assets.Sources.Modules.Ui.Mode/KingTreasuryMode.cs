using Assets.Sources.Ui.Model.Rpg;

namespace Assets.Sources.Modules.Ui.Mode;

public class KingTreasuryMode : CommonRpgMode
{
	public KingTreasuryMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new RpgExploreTargetModel());
	}
}
