using Assets.Sources.Ui.Model.RpgTower;

namespace Assets.Sources.Modules.Ui.Mode;

public class RpgTowerMode : RpgMode
{
	public RpgTowerMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new RpgTowerLevelUpPropertyMenuModel());
		AddPlaybackSystem(new RpgTowerLevelUpPropertyModel());
		AddPlaybackSystem(new RpgTowerLevelUpTypeDetailModel());
		AddPlaybackSystem(new RpgTowerLevelUpTypeMenuModel());
		AddPlaybackSystem(new RpgTowerMoveModel());
		AddPlaybackSystem(new RpgTowerSaleModel());
		AddPlaybackSystem(new RpgTowerMoneyModel());
		AddPlaybackSystem(new RpgTowerMessageModel());
	}
}
