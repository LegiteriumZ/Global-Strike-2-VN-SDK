using Assets.Sources.Ui.Model.BioEvolution;
using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Biochemical3;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Rpg;

namespace Assets.Sources.Modules.Ui.Mode;

public class Biochemical3Mode : BiochemicalMode
{
	public Biochemical3Mode(Contexts contexts)
		: base(contexts)
	{
		RemovePlayerbackSystem<BiochemicalTeamScoreModel>();
		RemovePlayerbackSystem<BiochemicalSelectVariantModel>();
		RemovePlayerbackSystem<BiochemicalNewVariantsGrowUpModel>();
		RemovePlayerbackSystem<PlayerStateModel>();
		RemovePlayerbackSystem<BiochemicalSerumModel>();
		RemovePlayerbackSystem<BiochemicalSkillIconModel>();
		RemovePlayerbackSystem<WeaponStateModel>();
		RemovePlayerbackSystem<BiochemicalHumanityGrowUpModel>();
		AddPlaybackSystem(new Biochemical3TeamScoreModel());
		AddPlaybackSystem(new BioEvolutionSelectVariantModel());
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
