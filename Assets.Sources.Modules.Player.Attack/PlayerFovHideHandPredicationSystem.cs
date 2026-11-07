using Assets.Generated.Table;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using SSJJUserCmd;
using share.constant;

namespace Assets.Sources.Modules.Player.Attack;

internal class PlayerFovHideHandPredicationSystem : IPredicateSystem
{
	private readonly PlayerContext _playerContext;

	public PlayerFovHideHandPredicationSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		bool flag = false;
		if (!_playerContext.cameraOwnerEntity.hasFov)
		{
			return;
		}
		if (_playerContext.cameraOwnerEntity.fov.IsZoom())
		{
			WeaponCrossTable.Row row = WeaponCrossLoader.Instance.Table.Find_Name(_playerContext.cameraOwnerEntity.currentWeapon.Name);
			if (row != null && row.IsHideHand)
			{
				flag = true;
			}
			if (!flag && player.HasStatus(PlayerInfoStatusConstant.HIDE_FIRST_VIEW.ID))
			{
				flag = true;
			}
		}
		_playerContext.cameraOwnerEntity.fov.IsHideFristView = flag;
	}
}
