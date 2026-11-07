using Assets.Sources.Ui.Model.Blast;
using Assets.Sources.Ui.Model.UltimateChallenge;

namespace Assets.Sources.Modules.Ui.Mode;

internal class UIExtremeWipeOutMode : CommonFreeMode
{
	public UIExtremeWipeOutMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new UltimateKillMessageModel());
		AddPlaybackSystem(new BlastTacticsSoundModel());
		AddPlaybackSystem(new ExtremewipeoutscoreinfoModel());
	}
}
