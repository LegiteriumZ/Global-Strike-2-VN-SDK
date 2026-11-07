using Assets.Sources.Components.Player;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Weapon;
using Entitas;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class PlayerWeaponInitSystem : PredicationInitSystemBase<CurrentWeaponComponent>, IPlaybackInitSystem
{
	private readonly IGroup<PlayerEntity> _group;

	private readonly PlayerContext _playerContext;

	public override CurrentWeaponComponent CurrentComponent => _playerContext.predictionEntity.currentWeapon;

	public PlayerWeaponInitSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.CurrentWeapon));
	}

	public void OnPlaybackInit()
	{
		foreach (PlayerEntity item in _group)
		{
			if (!item.isPrediction)
			{
				InitComponent(item.currentWeapon, item);
				if (item.isCameraOwner)
				{
					WeaponUtility.ChangeCurrentWeapon(item);
				}
			}
		}
	}

	public override void GetComponentFromSnapshot(CurrentWeaponComponent comp)
	{
		PlayerEntity predictionEntity = _playerContext.predictionEntity;
		InitComponent(comp, predictionEntity);
	}

	public override void OnPredicatoinInit()
	{
		base.OnPredicatoinInit();
		if (_playerContext.predictionEntity.isCameraOwner)
		{
			WeaponUtility.ChangeCurrentWeapon(_playerContext.predictionEntity);
		}
	}

	private void InitComponent(CurrentWeaponComponent comp, PlayerEntity player)
	{
		WeaponUtility.CopyToWeaponComponent(comp, player.basicInfo.Current);
	}
}
