using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Skill;

public class PlayerSkillModule : GameModule
{
	public PlayerSkillModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerSkillRemainTimeUpdateSystem(contexts));
		systems.Add(new PlayerBuffCdSystem(contexts));
		systems.Add(new PlayerCarrierMessageUpdateSystem(contexts));
		systems.Add(new SkillNotifySystem(contexts));
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new PlayerStatePredicateInitSystem(contexts));
		systems.Add(new PlayerSkillAndBuffInitSystem(contexts));
	}

	protected override void OnAddPredicationSystems(Contexts contexts, List<IPredicateSystem> systems)
	{
	}

	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
		systems.Add(new PlayerStatePredicateInitSystem(contexts));
	}
}
