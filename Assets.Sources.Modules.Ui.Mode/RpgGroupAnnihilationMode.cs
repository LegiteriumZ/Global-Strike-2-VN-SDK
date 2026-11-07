using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Group;
using Assets.Sources.Ui.Model.RpgGroup;
using Assets.Sources.Ui.Model.RpgGroupAnnihilation;

namespace Assets.Sources.Modules.Ui.Mode;

public class RpgGroupAnnihilationMode : RpgMode
{
	public RpgGroupAnnihilationMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new TeamScoreModel());
		AddPlaybackSystem(new RpgGroupAnnihilationIndividualInfoModel());
		AddPlaybackSystem(new CommonGameOverModel());
		AddPlaybackSystem(new RpgGroupWaitPlayerModel());
		AddPlaybackSystem(new RpgAnnihilationMessageModel());
	}
}
