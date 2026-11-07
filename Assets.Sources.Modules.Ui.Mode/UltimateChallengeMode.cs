using Assets.Sources.Ui.Model.UltimateChallenge;

namespace Assets.Sources.Modules.Ui.Mode;

internal class UltimateChallengeMode : CommonFreeMode
{
	public UltimateChallengeMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new UltimateKillMessageModel());
	}
}
