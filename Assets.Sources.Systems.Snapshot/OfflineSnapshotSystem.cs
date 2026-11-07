using Assets.Sources.Snapshots;
using Entitas;
using NetData;

namespace Assets.Sources.Systems.Snapshot;

public class OfflineSnapshotSystem : IExecuteSystem, ISystem
{
	private readonly SnapshotContext _snapshot;

	private readonly PlayerContext _player;

	public OfflineSnapshotSystem(Contexts contexts)
	{
		_snapshot = contexts.snapshot;
		_player = contexts.player;
		Assets.Sources.Snapshots.Snapshot snapshot = new Assets.Sources.Snapshots.Snapshot();
		snapshot.Self = 123;
		PlayerEntityData value = new PlayerEntityData
		{
			Id = 123,
			CurrentWeaponName = OfflineGameController.setting.Weapon,
			Career = OfflineGameController.setting.Player,
			CurrentHandName = OfflineGameController.setting.Hand,
			LegsAnim = 7,
			CurrentBagId = 1,
			CurrentWeapon = 1,
			CurrentWeaponIndex = 1,
			X = (0f - OfflineGameController.setting.X) * 100f,
			Y = (0f - OfflineGameController.setting.Z) * 100f,
			Z = OfflineGameController.setting.Y * 100f,
			Fov = 75,
			DuckState = 3,
			ViewHeight = 150f,
			GravityEffectRate = 1f
		};
		snapshot.PlayerEntityDataDict.Add(123, value);
		snapshot.BagList = new PlayerBagListData();
		PlayerBagData item = new PlayerBagData
		{
			BagId = 1,
			FirstWeapon = new BaseWeaponData
			{
				WeaponName = OfflineGameController.setting.Weapon,
				Clip = 30,
				CarryClip = 30000
			}
		};
		snapshot.BagList.Bags.Add(item);
		PlayerInfoData playerInfoData = new PlayerInfoData
		{
			Cid = 0L
		};
		contexts.battleRoom.playerInfo.PlayerInfoDatas[playerInfoData.Cid] = playerInfoData;
		_snapshot.snapshots.LatestSnapshot = (_snapshot.snapshots.NowSnapshot = (_snapshot.snapshots.NextSnapshot = snapshot));
	}

	public void Execute()
	{
		_snapshot.snapshots.LatestSnapshot.LastCmd += 20;
		if (_snapshot.snapshots.LatestSnapshot.SeqId < 5)
		{
			_snapshot.snapshots.LatestSnapshot.SeqId++;
		}
		if (_player.cameraOwnerEntity != null)
		{
			_ = _player.cameraOwnerEntity.hasMove;
		}
	}
}
