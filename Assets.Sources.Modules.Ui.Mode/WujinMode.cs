using Assets.Sources.Ui.Model.Common;

namespace Assets.Sources.Modules.Ui.Mode;

public class WujinMode : RpgMode
{
	public WujinMode(Contexts contexts)
		: base(contexts)
	{
		AbstractMode.AddWujin(this);
		AddPlaybackSystem(new PlayerBagModel());
	}
}
