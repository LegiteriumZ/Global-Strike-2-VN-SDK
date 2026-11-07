using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Modules.Ui.Mode;

public class CommonFreeMode : AbstractMode
{
	public CommonFreeMode(Contexts contexts)
		: base(contexts)
	{
		RadarMapModel system = new RadarMapModel();
		AddPlaybackSystem(system);
		MiniMapModel system2 = new MiniMapModel();
		AddPlaybackSystem(system2);
		WeaponStateModel system3 = new WeaponStateModel();
		AddPlaybackSystem(system3);
		AddPlaybackSystem(new CommonKillBroadModel());
	}
}
