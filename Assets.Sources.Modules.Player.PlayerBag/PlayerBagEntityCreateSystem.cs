using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class PlayerBagEntityCreateSystem : IEntityCreateSystem
{
	private readonly PlayerBagContext _playerBagContext;

	private readonly PlayerContext _playerContext;

	private readonly SnapshotContext _snapshotContext;

	public PlayerBagEntityCreateSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_playerBagContext = contexts.playerBag;
		_playerContext = contexts.player;
	}

	public void OnEntityCreate()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot latestSnapshot = _snapshotContext.snapshots.LatestSnapshot;
		if (nowSnapshot == null)
		{
			return;
		}
		ISnapshot snapshot = ((nowSnapshot.Observer != 0) ? nowSnapshot : latestSnapshot);
		if (snapshot == null || snapshot.BagList == null)
		{
			return;
		}
		if (_playerBagContext.currentBagEntity != null)
		{
			_playerBagContext.currentBagEntity.isCurrentBag = false;
		}
		foreach (PlayerBagData bag in snapshot.BagList.Bags)
		{
			PlayerBagEntity playerBagEntity = _playerBagContext.GetEntityWithBagId(bag.BagId);
			if (playerBagEntity == null)
			{
				playerBagEntity = _playerBagContext.CreateEntity();
				playerBagEntity.AddBagId(bag.BagId);
				playerBagEntity.AddBasicInfo(bag, snapshot.ServerTime);
			}
			playerBagEntity.basicInfo.Data = bag;
			playerBagEntity.basicInfo.SnapshotServerTime = snapshot.ServerTime;
			foreach (int item in bag.DelWeaponIndex)
			{
				if (item == 1)
				{
					bag.FirstWeapon = null;
				}
				if (item == 2)
				{
					bag.SecondaryWeapon = null;
				}
				if (item == 3)
				{
					bag.MeleeWeapon = null;
				}
				if (item == 4)
				{
					bag.BombWeapons0 = null;
				}
				if (item == 5)
				{
					bag.BombWeapons1 = null;
				}
				if (item == 6)
				{
					bag.BombWeapons2 = null;
				}
			}
			if (_playerContext.cameraOwnerEntity != null && bag.BagId == _playerContext.cameraOwnerEntity.basicInfo.Current.CurrentBagId)
			{
				playerBagEntity.isCurrentBag = true;
			}
		}
		foreach (PlayerBagEntity item2 in _playerBagContext)
		{
			if (item2 != _playerBagContext.c4BagEntity && item2.basicInfo.SnapshotServerTime < snapshot.ServerTime)
			{
				item2.Destroy();
			}
		}
		if (snapshot.BagList.C4Weapon != null)
		{
			PlayerBagEntity playerBagEntity2 = _playerBagContext.c4BagEntity;
			if (playerBagEntity2 == null)
			{
				playerBagEntity2 = _playerBagContext.CreateEntity();
				playerBagEntity2.AddC4Bag(snapshot.BagList.C4Weapon);
			}
			playerBagEntity2.c4Bag.C4Weapon = snapshot.BagList.C4Weapon;
		}
		else if (_playerBagContext.c4BagEntity != null)
		{
			_playerBagContext.RemoveC4Bag();
		}
	}
}
