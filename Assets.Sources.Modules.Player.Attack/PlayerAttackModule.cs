using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Orientation;

namespace Assets.Sources.Modules.Player.Attack;

public class PlayerAttackModule : GameModule
{
	public PlayerAttackModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
		systems.Add(new PlayerDecayInitSystem(contexts));
		systems.Add(new PlayerFovInitSystem(contexts));
	}

	protected override void OnAddEntityDestroySystems(Contexts contexts, List<IEntityDestroySystem> systems)
	{
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
	}

	protected override void OnAddPredicationSystems(Contexts contexts, List<IPredicateSystem> systems)
	{
		base.OnAddPredicationSystems(contexts, systems);
		systems.Add(new PlayerFovHideHandPredicationSystem(contexts));
	}

	protected override void OnAddAfterPredicationSystems(Contexts contexts, List<IAfterPredicationSystem> systems)
	{
		systems.Add(new PunchSmoothSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerWeaponParticleEffectPlaybackSystem(contexts));
		systems.Add(new PlayerWeaponEffectPlaybackSystem(contexts));
		systems.Add(new PlayerWeaponLogicEffectPlaybackSystem(contexts));
		systems.Add(new PlayerWeaponFirePlaybackSystem(contexts));
	}
}
