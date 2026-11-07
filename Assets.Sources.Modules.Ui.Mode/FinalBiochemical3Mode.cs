using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Biochemical3;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.FinalBio;
using Assets.Sources.Ui.Model.Rpg;

namespace Assets.Sources.Modules.Ui.Mode;

public class FinalBiochemical3Mode : FinalBiochemicalMode
{
	public FinalBiochemical3Mode(Contexts contexts)
		: base(contexts)
	{
		RemovePlayerbackSystem<BiochemicalTeamScoreModel>();
		RemovePlayerbackSystem<BiochemicalSelectVariantModel>();
		RemovePlayerbackSystem<PlayerStateModel>();
		RemovePlayerbackSystem<BiochemicalSerumModel>();
		RemovePlayerbackSystem<FinalBioSkillIconModel>();
		RemovePlayerbackSystem<WeaponStateModel>();
		RemovePlayerbackSystem<FinalBioHumanityGrowUpModel>();
		RemovePlayerbackSystem<FinalBioVariantsGrowUpModel>();
		AddPlaybackSystem(new Biochemical3TeamScoreModel());
		AddPlaybackSystem(new Biochemical3SelectVariantModel());
		AddPlaybackSystem(new Biochemical3VariantGrowUpModel());
		AddPlaybackSystem(new Biochemical3VariantPlayerStateModel());
		AddPlaybackSystem(new Biochemical3HumanityPlayerStateModel());
		AddPlaybackSystem(new Biochemical3ItemModel());
		AddPlaybackSystem(new Biochemical3SkillModel());
		AddPlaybackSystem(new Biochemical3HumanityGrowUpModel());
		AddPlaybackSystem(new Biochemical3WeaponStateModel());
		AddPlaybackSystem(new RpgExplodeoilModel());
	}
}
