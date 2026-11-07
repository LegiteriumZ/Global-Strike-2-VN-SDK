using Assets.Sources.Framework;
using Assets.Sources.Utils.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class ChagneCurrentWeaponSystem : IPredicateSystem
{
	private readonly PlayerContext _playerContext;

	public ChagneCurrentWeaponSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity.isCameraOwner && !myPlayerEntity.IsObserver())
		{
			WeaponUtility.ChangeCurrentWeapon(myPlayerEntity);
		}
	}
}
