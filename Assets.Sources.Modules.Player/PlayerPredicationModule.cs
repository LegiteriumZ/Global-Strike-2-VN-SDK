using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Anim.FirstPerson;
using Assets.Sources.Modules.Player.Anim.ThirdPerson;
using Assets.Sources.Modules.Player.Attack;
using Assets.Sources.Modules.Player.ClientTime;
using Assets.Sources.Modules.Player.Move;
using Assets.Sources.Modules.Player.Orientation;
using Assets.Sources.Modules.Player.PlayerBag;

namespace Assets.Sources.Modules.Player;

public class PlayerPredicationModule : GameModule
{
	protected override void OnAddPredicationSystems(Contexts contexts, List<IPredicateSystem> systems)
	{
		systems.Add(new PlayerClientTimePredictionSystem());
		systems.Add(new PlayerPunchOrientationPredictionSystem());
		systems.Add(new PlayerOrientationPredicationSystem(contexts));
		systems.Add(new PlayerPreAttackPredictionSystem(contexts));
		systems.Add(new PlayerDelayAttackPredicationSystem(contexts));
		systems.Add(new PlayerAttackPredicationSystem(contexts));
		systems.Add(new PlayerThrowWeaponPredicationSystem());
		systems.Add(new PlayerSwitchWeaponPredicationSystem(contexts));
		systems.Add(new ChagneCurrentWeaponSystem(contexts));
		systems.Add(new PlayerEffectLevelUpdateInitSystem(contexts));
		systems.Add(new PlayerWeaponRaisePredicationSystem(contexts));
		systems.Add(new PlayerWeaponReloadPredicationSystem(contexts));
		systems.Add(new PlayerWeaponLockPredicationSystem(contexts));
		systems.Add(new PlayerLegPredictionSystem());
		systems.Add(new PlayerLegWrapAnimationPredictionSystem());
		systems.Add(new PlayerTorsePredictionSystem());
		systems.Add(new PlayerMovePredicationSystem(contexts));
		systems.Add(new PlayerViewPredictionSystem());
	}

	public PlayerPredicationModule(Contexts contexts)
		: base(contexts)
	{
	}
}
