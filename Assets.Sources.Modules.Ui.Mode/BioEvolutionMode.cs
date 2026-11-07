using Assets.Sources.Ui.Model.BioEvolution;
using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Biochemical2;
using Assets.Sources.Ui.Model.Biochemical3;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.FinalBio;
using Assets.Sources.Ui.Model.Rpg;

namespace Assets.Sources.Modules.Ui.Mode;

public class BioEvolutionMode : FinalBiochemicalMode
{
	public BioEvolutionMode(Contexts contexts)
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
		RemovePlayerbackSystem<BiochemicalIndividualScoreInfoModel>();
		RemovePlayerbackSystem<CommonIndividualScoreInfoModel>();
		RemovePlayerbackSystem<FinalBioStartGameModel>();
		RemovePlayerbackSystem<Biochemical3SelectVariantModel>();
		AddPlaybackSystem(new Biochemical3TeamScoreModel());
		AddPlaybackSystem(new BioEvolutionSelectVariantModel());
		AddPlaybackSystem(new BioEvolutionShortcutKeyModel());
		AddPlaybackSystem(new Biochemical3VariantPlayerStateModel());
		AddPlaybackSystem(new Biochemical3HumanityPlayerStateModel());
		AddPlaybackSystem(new Biochemical3ItemModel());
		AddPlaybackSystem(new Biochemical3SkillModel());
		AddPlaybackSystem(new Biochemical3WeaponStateModel());
		AddPlaybackSystem(new BioEvolutionVariantGrowUpModel());
		AddPlaybackSystem(new BioEvolutionHuManGrowUpModel());
		AddPlaybackSystem(new BioEvolutionPickUpModel());
		AddPlaybackSystem(new FinalBioDecisiveBattleModel());
		AddPlaybackSystem(new Biochemical2IndividualScoreInfoModel());
		AddPlaybackSystem(new BioEvolutionStartGameModel());
		AddPlaybackSystem(new RpgExplodeoilModel());
	}
}
