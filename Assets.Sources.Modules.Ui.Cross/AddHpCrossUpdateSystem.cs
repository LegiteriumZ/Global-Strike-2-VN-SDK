using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Ui.Cross;

public class AddHpCrossUpdateSystem : IPlaybackSystem
{
	private CrossContext _crossContext;

	private PlayerContext _playerContext;

	private WeaponContext _weaponContext;

	private bool _canAddHp;

	private WeaponEntity _weaponEntity;

	private PlayerEntity _cameraOwner;

	public AddHpCrossUpdateSystem(Contexts contexts)
	{
		_crossContext = contexts.cross;
		_playerContext = contexts.player;
		_weaponContext = contexts.weapon;
		_canAddHp = contexts.gameRule.currentRule.Rule.CanShowAddHpCross();
	}

	public void OnPlayback()
	{
		if (_playerContext.isCameraOwner && _weaponContext.isCurrentWeapon)
		{
			_weaponEntity = _weaponContext.currentWeaponEntity;
			if (!_weaponEntity.hasBasicInfo)
			{
				_crossContext.isAddHpCross = false;
				return;
			}
			_cameraOwner = _playerContext.cameraOwnerEntity;
			_crossContext.isAddHpCross = _canAddHp && CheckAddHp();
		}
	}

	private bool CheckAddHp()
	{
		int entityId = _cameraOwner.normalTrace.EntityId;
		if (entityId != -1 && entityId != -2)
		{
			PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(entityId);
			if (entityWithEntityId != null && entityWithEntityId.basicInfo.Current.Team == _cameraOwner.basicInfo.Current.Team)
			{
				return true;
			}
		}
		return false;
	}
}
