using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Rpg;

namespace Assets.Sources.Modules.Ui.Mode;

public class RpgLastDefenderMode : RpgMode
{
	public RpgLastDefenderMode(Contexts contexts)
		: base(contexts)
	{
		RemovePlayerbackSystem<PlayerBagModel>();
		AddPlaybackSystem(new RpgMoneyModel());
		AddPlaybackSystem(new RpgSelectMainModel());
		AddPlaybackSystem(new RpgSelectViewModel());
		AddPlaybackSystem(new RpgPopMsgModel());
		AddPlaybackSystem(new LastDefenseOtherTowerHpModel());
		AddPlaybackSystem(new LastDefenseEffectModel());
	}
}
