using Assets.Sources.Ui.Model.Pve;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.RpgCraze;
using Assets.Sources.Ui.Model.Weapon;

namespace Assets.Sources.Modules.Ui.Mode;

public class CrazeRpgModeMode : TDMode
{
	public CrazeRpgModeMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new CrazeLearnTabModel());
		AddPlaybackSystem(new CrazeSkillChooseModel());
		RemovePlayerbackSystem<PveAllKillInfoModel>();
		RemovePlayerbackSystem<PveScoreRankModel>();
		RemovePlayerbackSystem<PveStarsModel>();
		RemovePlayerbackSystem<PvetdskilltreeModel>();
		RemovePlayerbackSystem<SkillProgressModel>();
	}
}
