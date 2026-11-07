using System.Collections.Generic;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Player.Attack;

public class PlayerDecayDestroySystem : ReactiveSystem<WeaponEntity>, IEntityDestroySystem
{
	public PlayerDecayDestroySystem(Contexts contexts)
		: base((IContext<WeaponEntity>)contexts.weapon)
	{
		Activate();
	}

	public void OnEntityDestroy()
	{
		Execute();
	}

	protected override ICollector<WeaponEntity> GetTrigger(IContext<WeaponEntity> context)
	{
		return context.CreateCollector(WeaponMatcher.CurrentWeapon.Removed());
	}

	protected override bool Filter(WeaponEntity entity)
	{
		return entity.hasDelayAttack;
	}

	protected override void Execute(List<WeaponEntity> entities)
	{
		foreach (WeaponEntity entity in entities)
		{
			entity.RemoveDelayAttack();
		}
	}
}
