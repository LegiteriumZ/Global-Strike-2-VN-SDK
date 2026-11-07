using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.PveCommon;

namespace Assets.Sources.Modules.Ui.Mode;

public class CommonRpgMode : RpgMode
{
	public CommonRpgMode(Contexts contexts)
		: base(contexts)
	{
		AbstractMode.AddCommonRpg(this);
		AddPlaybackSystem(new PlayerBagModel());
		AddPlaybackSystem(new PveScoreRankModel());
	}
}
