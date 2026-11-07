using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.UltimateChallenge;

namespace Assets.Sources.Modules.Ui.Mode;

internal class UltimateChallenge2Mode : CommonFreeMode
{
	public UltimateChallenge2Mode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new UltimateKillMessageModel());
		AddPlaybackSystem(new PlayerBagModel());
	}
}
