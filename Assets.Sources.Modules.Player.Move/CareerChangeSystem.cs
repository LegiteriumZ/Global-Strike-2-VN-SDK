using Assets.Sources.Framework;
using Entitas;
using SSJJPhysicsExtensions;

namespace Assets.Sources.Modules.Player.Move;

public class CareerChangeSystem : IEntityCreateSystem
{
	private readonly IGroup<PlayerEntity> _group;

	private readonly WeaponContext _weaponContext;

	public CareerChangeSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Move, PlayerMatcher.BasicInfo));
		_weaponContext = contexts.weapon;
	}

	public void OnEntityCreate()
	{
		foreach (PlayerEntity item in _group)
		{
			if (item.move.PyPlayerMove != null && item.move.PyPlayerMove.GetCareer() != item.basicInfo.CareerInfo.Name)
			{
				item.move.PyPlayerMove = new PyPlayerAdapter(item, _weaponContext);
			}
		}
	}
}
