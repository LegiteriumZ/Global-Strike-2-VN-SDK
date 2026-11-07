using Assets.Sources.Ui.Model.BigHead;

namespace Assets.Sources.Modules.Ui.Mode;

internal class CrazyBigHeadMode : BigHeadMode
{
	public CrazyBigHeadMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new CrazyBigheadScoreModel());
		AddPlaybackSystem(new CrazyBigheadmessageModel());
		AddPlaybackSystem(new CrazyBigheadChooseWeaponModel());
		AddPlaybackSystem(new CrazyBigheadHeroStateModel());
		RemovePlayerbackSystem<BigHeadMessageModel>();
	}
}
