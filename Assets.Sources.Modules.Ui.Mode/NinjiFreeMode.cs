using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Rpg;

namespace Assets.Sources.Modules.Ui.Mode;

public class NinjiFreeMode : RpgMode
{
	public NinjiFreeMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new RPGNanjiMarkModel());
		AddPlaybackSystem(new PlayerBagModel());
	}
}
