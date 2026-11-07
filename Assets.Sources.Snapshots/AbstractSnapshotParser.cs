using System;
using System.IO;
using Assets.Sources.Free.Data;
using Assets.Sources.Systems.Snapshot;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Utility;
using SSJJNetworking.Server;
using weapon.nets;

namespace Assets.Sources.Snapshots;

public abstract class AbstractSnapshotParser : IPacketBodyParser<Snapshot>
{
	protected LoggerAdapter Logger;

	public int Offset;

	public const int MAX_INPUT_PACKET_ZIPPED_LEN = 20000;

	public Snapshot Parse(byte[] data, int len)
	{
		if (GameModelLocator.GetInstance().GameModel.RoomData != null && !GameModelLocator.GetInstance().GameModel.RoomData.UdpOptimize)
		{
			return ParseOld(data, len);
		}
		if (data == null)
		{
			return null;
		}
		MemoryStream memoryStream = new MemoryStream(data)
		{
			Position = 0L
		};
		byte[] array = new byte[2];
		memoryStream.Read(array, 0, 2);
		if (BitConverter.IsLittleEndian)
		{
			BinaryDataWriter.ReverseArray(array, 0, array.Length - 1);
		}
		ushort num = BitConverter.ToUInt16(array, 0);
		if (num >= 20000)
		{
			NetByteFactory.Instance.AddSnapshotReceive(data);
			return null;
		}
		long position = memoryStream.Position;
		int @base = NetTableBase.readVarint64(memoryStream);
		int serverTime = NetTableBase.readVarint64(memoryStream);
		int self = NetTableBase.readVarint64(memoryStream);
		int seqId = NetTableBase.readVarint64(memoryStream);
		int lastCmd = NetTableBase.readVarint64(memoryStream);
		ushort num2 = (ushort)(memoryStream.Position - position);
		num -= num2;
		byte[] array2 = new byte[num];
		memoryStream.Read(array2, 0, num);
		SnapshotData snapshotData = ProtoBufUtility.Deserialize<SnapshotData>(array2);
		snapshotData.Base = @base;
		snapshotData.ServerTime = serverTime;
		snapshotData.Self = self;
		snapshotData.SeqId = seqId;
		snapshotData.LastCmd = lastCmd;
		int base2 = snapshotData.Base;
		Snapshot snapshot = null;
		if (base2 != -1)
		{
			snapshot = AssembleSystem.GetBaseSnapshot(Contexts.sharedInstance.snapshot.snapshots, base2);
			if (snapshot != null)
			{
				snapshotData.SeqId += base2;
				snapshotData.LastCmd += snapshot.LastCmd;
				snapshotData.ServerTime += snapshot.ServerTime;
			}
		}
		Snapshot orCreate = SnapshotFactory.Instance.GetOrCreate();
		orCreate.Base = snapshotData.Base;
		orCreate.Self = snapshotData.Self;
		orCreate.ServerTime = snapshotData.ServerTime;
		orCreate.Observer = snapshotData.Observer;
		orCreate.SeqId = snapshotData.SeqId;
		orCreate.LastCmd = snapshotData.LastCmd;
		orCreate.DeletedEntityIdList.AddRange(snapshotData.DeleteIdList);
		orCreate.IsDispose = false;
		orCreate.BagList = snapshotData.BagList;
		orCreate.ControlId = snapshotData.ControlId;
		orCreate.MainCameraId = snapshotData.MainCameraId;
		if (snapshotData.Base > 0 && snapshot == null)
		{
			return null;
		}
		while (memoryStream.CanRead && memoryStream.Position < len)
		{
			int num3 = 0;
			int num4 = NetTableBase.readVarint64(memoryStream);
			if (num4 <= 127)
			{
				num3 = memoryStream.ReadByte();
			}
			else
			{
				long position2 = memoryStream.Position;
				long position3 = position2 + num4;
				memoryStream.Position = position3;
				num3 = memoryStream.ReadByte();
				memoryStream.Position = position2;
			}
			byte[] array3 = new byte[num4];
			if (num3 != 1 && num3 != 13)
			{
				memoryStream.Read(array3, 0, num4);
			}
			switch (num3)
			{
			case 1:
			{
				long position5 = memoryStream.Position;
				PlayerEntityData playerEntityData = new PlayerEntityData();
				playerEntityData.Id = NetTableBase.readVarint64(memoryStream);
				byte b = (byte)memoryStream.ReadByte();
				readPlayerPart1(memoryStream, snapshot, playerEntityData, b);
				bool hasField2or = (b & 0x80) > 0;
				byte field2or3Flag = readPlayerPart2(memoryStream, snapshot, playerEntityData, hasField2or);
				readPlayerPart3(memoryStream, snapshot, playerEntityData, hasField2or, field2or3Flag);
				long num7 = memoryStream.Position - position5;
				long num8 = num4 - num7;
				array3 = new byte[num8];
				memoryStream.Read(array3, 0, (int)num8);
				PlayerEntityData playerEntityData2 = ProtoBufUtility.Deserialize<PlayerEntityData>(array3);
				if (playerEntityData.XSpecified)
				{
					playerEntityData2.X = playerEntityData.X;
				}
				if (playerEntityData.YSpecified)
				{
					playerEntityData2.Y = playerEntityData.Y;
				}
				if (playerEntityData.ZSpecified)
				{
					playerEntityData2.Z = playerEntityData.Z;
				}
				if (playerEntityData.ViewPitchSpecified)
				{
					playerEntityData2.ViewPitch = playerEntityData.ViewPitch;
				}
				if (playerEntityData.ViewYawSpecified)
				{
					playerEntityData2.ViewYaw = playerEntityData.ViewYaw;
				}
				if (playerEntityData.MoveYawSpecified)
				{
					playerEntityData2.MoveYaw = playerEntityData.MoveYaw;
				}
				if (playerEntityData.Velocity2DSpecified)
				{
					playerEntityData2.Velocity2D = playerEntityData.Velocity2D;
				}
				if (playerEntityData.LegsAnimSpecified)
				{
					playerEntityData2.LegsAnim = playerEntityData.LegsAnim;
				}
				if (playerEntityData.IsDeadSpecified)
				{
					playerEntityData2.IsDead = playerEntityData.IsDead;
				}
				if (playerEntityData.MovingSpecified)
				{
					playerEntityData2.Moving = playerEntityData.Moving;
				}
				if (playerEntityData.OnGroundSpecified)
				{
					playerEntityData2.OnGround = playerEntityData.OnGround;
				}
				if (playerEntityData.PunchYawSpecified)
				{
					playerEntityData2.PunchYaw = playerEntityData.PunchYaw;
				}
				if (playerEntityData.PunchPitchSpecified)
				{
					playerEntityData2.PunchPitch = playerEntityData.PunchPitch;
				}
				if (playerEntityData.ClientTimeSpecified)
				{
					playerEntityData2.ClientTime = playerEntityData.ClientTime;
				}
				if (playerEntityData.CmdSequenceSpecified)
				{
					playerEntityData2.CmdSequence = playerEntityData.CmdSequence;
				}
				if (playerEntityData.LegsSpeedAnimTimeSpecified)
				{
					playerEntityData2.LegsSpeedAnimTime = playerEntityData.LegsSpeedAnimTime;
				}
				if (playerEntityData.ViewAnimationTimerSpecified)
				{
					playerEntityData2.ViewAnimationTimer = playerEntityData.ViewAnimationTimer;
				}
				if (playerEntityData.LegsAnimationTimerSpecified)
				{
					playerEntityData2.LegsAnimationTimer = playerEntityData.LegsAnimationTimer;
				}
				if (playerEntityData.LeftViewAnimationTimerSpecified)
				{
					playerEntityData2.LeftViewAnimationTimer = playerEntityData.LeftViewAnimationTimer;
				}
				if (playerEntityData.DeadTimerSpecified)
				{
					playerEntityData2.DeadTimer = playerEntityData.DeadTimer;
				}
				if (playerEntityData.TorsoAnimationTimerSpecified)
				{
					playerEntityData2.TorsoAnimationTimer = playerEntityData.TorsoAnimationTimer;
				}
				playerEntityData2.Id = playerEntityData.Id;
				orCreate.PlayerEntityDataDict.Add(playerEntityData2.Id, playerEntityData2);
				break;
			}
			case 15:
			{
				LinkEntityData linkEntityData = ProtoBufUtility.Deserialize<LinkEntityData>(array3);
				orCreate.LinkEntityDataDict.Add(linkEntityData.Id, linkEntityData);
				break;
			}
			case 3:
			{
				BulletHitWallEventEntityData bulletHitWallEventEntityData = ProtoBufUtility.Deserialize<BulletHitWallEventEntityData>(array3);
				orCreate.BulletHitWallEventEntityDataDict.Add(bulletHitWallEventEntityData.BaseEventEntity.Id, bulletHitWallEventEntityData);
				break;
			}
			case 7:
			{
				BulletRailEventEntityData bulletRailEventEntityData = ProtoBufUtility.Deserialize<BulletRailEventEntityData>(array3);
				orCreate.BulletRailEventEntityDataDict.Add(bulletRailEventEntityData.BaseEventEntity.Id, bulletRailEventEntityData);
				break;
			}
			case 11:
			{
				BaseEventEntityData baseEventEntityData = ProtoBufUtility.Deserialize<BaseEventEntityData>(array3);
				orCreate.BaseEventEntityDataDict.Add(baseEventEntityData.Id, baseEventEntityData);
				break;
			}
			case 12:
			{
				ShowDamageEventEntityData showDamageEventEntityData = ProtoBufUtility.Deserialize<ShowDamageEventEntityData>(array3);
				orCreate.ShowDamageEventEntityDataDict.Add(showDamageEventEntityData.BaseEventEntity.Id, showDamageEventEntityData);
				break;
			}
			case 4:
			{
				BeingHitEventEntityData beingHitEventEntityData = ProtoBufUtility.Deserialize<BeingHitEventEntityData>(array3);
				orCreate.BeingHitEventEntityDataDict.Add(beingHitEventEntityData.BaseEventEntity.Id, beingHitEventEntityData);
				break;
			}
			case 6:
			{
				SceneWeaponEntityData sceneWeaponEntityData = ProtoBufUtility.Deserialize<SceneWeaponEntityData>(array3);
				orCreate.SceneWeaponEntityDataDict.Add(sceneWeaponEntityData.Id, sceneWeaponEntityData);
				break;
			}
			case 5:
			{
				GrenadeExplosionEventEntityData grenadeExplosionEventEntityData = ProtoBufUtility.Deserialize<GrenadeExplosionEventEntityData>(array3);
				orCreate.GrenadeExplosionEventEntityDataDict.Add(grenadeExplosionEventEntityData.BaseEventEntity.Id, grenadeExplosionEventEntityData);
				break;
			}
			case 16:
			{
				TowerEventEntityData towerEventEntityData = ProtoBufUtility.Deserialize<TowerEventEntityData>(array3);
				orCreate.TowerEventEntityDataDict.Add(towerEventEntityData.BaseEventEntity.Id, towerEventEntityData);
				break;
			}
			case 17:
			{
				FlashEventEntityData flashEventEntityData = ProtoBufUtility.Deserialize<FlashEventEntityData>(array3);
				orCreate.FlashEventEntityDataDict.Add(flashEventEntityData.BaseEventEntity.Id, flashEventEntityData);
				break;
			}
			case 9:
			{
				SceneBufEntityData sceneBufEntityData = ProtoBufUtility.Deserialize<SceneBufEntityData>(array3);
				orCreate.SceneBufEntityDataDict.Add(sceneBufEntityData.Id, sceneBufEntityData);
				break;
			}
			case 2:
			{
				PlayerPartEntityData playerPartEntityData = ProtoBufUtility.Deserialize<PlayerPartEntityData>(array3);
				orCreate.PlayerPartEntityDataDict.Add(playerPartEntityData.Id, playerPartEntityData);
				break;
			}
			case 10:
			{
				MoveEntityData moveEntityData = ProtoBufUtility.Deserialize<MoveEntityData>(array3);
				orCreate.MoveEntityDataDict.Add(moveEntityData.Id, moveEntityData);
				break;
			}
			case 14:
			case 26:
			{
				PveTowerEntityData pveTowerEntityData = ProtoBufUtility.Deserialize<PveTowerEntityData>(array3);
				orCreate.PveTowerEntityDataDict.Add(pveTowerEntityData.Id, pveTowerEntityData);
				break;
			}
			case 23:
			{
				SceneItweenEntityData sceneItweenEntityData = ProtoBufUtility.Deserialize<SceneItweenEntityData>(array3);
				orCreate.SceneItweenEntityDataDict.Add(sceneItweenEntityData.BaseMoveEntity.Id, sceneItweenEntityData);
				Snapshot.ItweenRecords[sceneItweenEntityData] = orCreate.ServerTime;
				break;
			}
			case 13:
			{
				long position4 = memoryStream.Position;
				NetFluxInputStreamImpl netFluxInputStreamImpl = new NetFluxInputStreamImpl(memoryStream);
				int num5 = netFluxInputStreamImpl.ReadRawVarint32();
				NpcEntityData value = null;
				NpcSnapData npcSnapData = null;
				if (snapshot != null)
				{
					snapshot.NpcEntityDataDict.TryGetValue(num5, out value);
					if (value != null)
					{
						npcSnapData = new NpcSnapData();
						npcSnapData.x = value.X;
						npcSnapData.y = value.Y;
						npcSnapData.yaw = value.Yaw;
					}
				}
				NpcSnapData npcSnapData2 = new NpcSnapData();
				npcSnapData2.ReadFromData(npcSnapData, netFluxInputStreamImpl);
				long num6 = num4 - netFluxInputStreamImpl.GetPos() + position4;
				array3 = new byte[num6];
				memoryStream.Read(array3, 0, (int)num6);
				NpcEntityData npcEntityData = ProtoBufUtility.Deserialize<NpcEntityData>(array3);
				npcEntityData.Id = num5;
				npcEntityData.X = npcSnapData2.x;
				npcEntityData.Y = npcSnapData2.y;
				npcEntityData.Yaw = npcSnapData2.yaw;
				orCreate.NpcEntityDataDict.Add(npcEntityData.Id, npcEntityData);
				break;
			}
			case 8:
			{
				ShakeEventEntityData shakeEventEntityData = ProtoBufUtility.Deserialize<ShakeEventEntityData>(array3);
				orCreate.ShakeEventEntityDataDict.Add(shakeEventEntityData.BaseEventEntity.Id, shakeEventEntityData);
				break;
			}
			case 30:
			{
				SimpleEngineEntityData simpleEngineEntityData = ProtoBufUtility.Deserialize<SimpleEngineEntityData>(array3);
				orCreate.SimpleEngineEntityDataDict.Add(simpleEngineEntityData.Id, simpleEngineEntityData);
				break;
			}
			case 20:
			{
				CameraEntityData cameraEntityData = ProtoBufUtility.Deserialize<CameraEntityData>(array3);
				orCreate.CameraEntityDataDict.Add(cameraEntityData.Id, cameraEntityData);
				break;
			}
			case 18:
			{
				TitanEventEntityData titanEventEntityData = ProtoBufUtility.Deserialize<TitanEventEntityData>(array3);
				orCreate.TitanEventEntityDataDict.Add(titanEventEntityData.BaseEventEntity.Id, titanEventEntityData);
				break;
			}
			case 19:
			{
				SceneItemEntityData sceneItemEntityData = ProtoBufUtility.Deserialize<SceneItemEntityData>(array3);
				orCreate.SceneItemEntityDataDict.Add(sceneItemEntityData.Id, sceneItemEntityData);
				break;
			}
			case 34:
			{
				ShowBodyEffectEntityData showBodyEffectEntityData = ProtoBufUtility.Deserialize<ShowBodyEffectEntityData>(array3);
				orCreate.ShowBodyEffectEntityDataDict.Add(showBodyEffectEntityData.BaseEventEntity.Id, showBodyEffectEntityData);
				break;
			}
			case 21:
			{
				Pve3EventEntityData pve3EventEntityData = ProtoBufUtility.Deserialize<Pve3EventEntityData>(array3);
				orCreate.Pve3EventEntityDataDict.Add(pve3EventEntityData.BaseEventEntity.Id, pve3EventEntityData);
				break;
			}
			case 22:
			{
				BowHitWallEventEntityData bowHitWallEventEntityData = ProtoBufUtility.Deserialize<BowHitWallEventEntityData>(array3);
				orCreate.BowHitWallEventEntityDataDict.Add(bowHitWallEventEntityData.BaseEventEntity.Id, bowHitWallEventEntityData);
				break;
			}
			case 25:
			{
				GeneralPveSceneItemEntityData generalPveSceneItemEntityData = ProtoBufUtility.Deserialize<GeneralPveSceneItemEntityData>(array3);
				orCreate.GeneralPveSceneItemEntityDataDict.Add(generalPveSceneItemEntityData.Id, generalPveSceneItemEntityData);
				break;
			}
			case 31:
			{
				ComplexEngineEntityData complexEngineEntityData = ProtoBufUtility.Deserialize<ComplexEngineEntityData>(array3);
				orCreate.ComplexEngineEntityDataDict.Add(complexEngineEntityData.Id, complexEngineEntityData);
				break;
			}
			case 35:
			{
				SoundEventEntityData soundEventEntityData = ProtoBufUtility.Deserialize<SoundEventEntityData>(array3);
				orCreate.SoundEventEntityDataDict.Add(soundEventEntityData.BaseEventEntity.Id, soundEventEntityData);
				break;
			}
			case 36:
			{
				CustomMoveEntityData customMoveEntityData = ProtoBufUtility.Deserialize<CustomMoveEntityData>(array3);
				orCreate.CustomMoveEntityDataDict.Add(customMoveEntityData.Id, customMoveEntityData);
				break;
			}
			}
			if (num4 > 127)
			{
				memoryStream.ReadByte();
			}
		}
		NetByteFactory.Instance.AddSnapshotReceive(data);
		return orCreate;
	}

	public Snapshot ParseOld(byte[] data, int len)
	{
		if (data == null)
		{
			return null;
		}
		MemoryStream memoryStream = new MemoryStream(data)
		{
			Position = 0L
		};
		byte[] array = new byte[4];
		memoryStream.Read(array, 0, 4);
		if (BitConverter.IsLittleEndian)
		{
			BinaryDataWriter.ReverseArray(array, 0, array.Length - 1);
		}
		int num = BitConverter.ToInt32(array, 0);
		if (num >= 20000)
		{
			NetByteFactory.Instance.AddSnapshotReceive(data);
			return null;
		}
		byte[] array2 = new byte[num];
		memoryStream.Read(array2, 0, num);
		SnapshotData snapshotData = ProtoBufUtility.Deserialize<SnapshotData>(array2);
		Snapshot orCreate = SnapshotFactory.Instance.GetOrCreate();
		orCreate.Base = snapshotData.Base;
		orCreate.Self = snapshotData.Self;
		orCreate.ServerTime = snapshotData.ServerTime;
		orCreate.Observer = snapshotData.Observer;
		orCreate.SeqId = snapshotData.SeqId;
		orCreate.LastCmd = snapshotData.LastCmd;
		orCreate.DeletedEntityIdList.AddRange(snapshotData.DeleteIdList);
		orCreate.BagList = snapshotData.BagList;
		orCreate.ControlId = snapshotData.ControlId;
		orCreate.MainCameraId = snapshotData.MainCameraId;
		while (memoryStream.CanRead && memoryStream.Position < len)
		{
			int num2 = memoryStream.ReadByte();
			byte[] array3 = new byte[4];
			memoryStream.Read(array3, 0, 4);
			if (BitConverter.IsLittleEndian)
			{
				BinaryDataWriter.ReverseArray(array3, 0, array3.Length - 1);
			}
			int num3 = BitConverter.ToInt32(array3, 0);
			if (num3 >= 20000)
			{
				NetByteFactory.Instance.AddSnapshotReceive(data);
				return null;
			}
			byte[] array4 = new byte[num3];
			memoryStream.Read(array4, 0, num3);
			switch (num2)
			{
			case 15:
			{
				LinkEntityData linkEntityData = ProtoBufUtility.Deserialize<LinkEntityData>(array4);
				orCreate.LinkEntityDataDict.Add(linkEntityData.Id, linkEntityData);
				break;
			}
			case 3:
			{
				BulletHitWallEventEntityData bulletHitWallEventEntityData = ProtoBufUtility.Deserialize<BulletHitWallEventEntityData>(array4);
				orCreate.BulletHitWallEventEntityDataDict.Add(bulletHitWallEventEntityData.BaseEventEntity.Id, bulletHitWallEventEntityData);
				break;
			}
			case 7:
			{
				BulletRailEventEntityData bulletRailEventEntityData = ProtoBufUtility.Deserialize<BulletRailEventEntityData>(array4);
				orCreate.BulletRailEventEntityDataDict.Add(bulletRailEventEntityData.BaseEventEntity.Id, bulletRailEventEntityData);
				break;
			}
			case 11:
			{
				BaseEventEntityData baseEventEntityData = ProtoBufUtility.Deserialize<BaseEventEntityData>(array4);
				orCreate.BaseEventEntityDataDict.Add(baseEventEntityData.Id, baseEventEntityData);
				break;
			}
			case 12:
			{
				ShowDamageEventEntityData showDamageEventEntityData = ProtoBufUtility.Deserialize<ShowDamageEventEntityData>(array4);
				orCreate.ShowDamageEventEntityDataDict.Add(showDamageEventEntityData.BaseEventEntity.Id, showDamageEventEntityData);
				break;
			}
			case 4:
			{
				BeingHitEventEntityData beingHitEventEntityData = ProtoBufUtility.Deserialize<BeingHitEventEntityData>(array4);
				orCreate.BeingHitEventEntityDataDict.Add(beingHitEventEntityData.BaseEventEntity.Id, beingHitEventEntityData);
				break;
			}
			case 6:
			{
				SceneWeaponEntityData sceneWeaponEntityData = ProtoBufUtility.Deserialize<SceneWeaponEntityData>(array4);
				orCreate.SceneWeaponEntityDataDict.Add(sceneWeaponEntityData.Id, sceneWeaponEntityData);
				break;
			}
			case 5:
			{
				GrenadeExplosionEventEntityData grenadeExplosionEventEntityData = ProtoBufUtility.Deserialize<GrenadeExplosionEventEntityData>(array4);
				orCreate.GrenadeExplosionEventEntityDataDict.Add(grenadeExplosionEventEntityData.BaseEventEntity.Id, grenadeExplosionEventEntityData);
				break;
			}
			case 16:
			{
				TowerEventEntityData towerEventEntityData = ProtoBufUtility.Deserialize<TowerEventEntityData>(array4);
				orCreate.TowerEventEntityDataDict.Add(towerEventEntityData.BaseEventEntity.Id, towerEventEntityData);
				break;
			}
			case 17:
			{
				FlashEventEntityData flashEventEntityData = ProtoBufUtility.Deserialize<FlashEventEntityData>(array4);
				orCreate.FlashEventEntityDataDict.Add(flashEventEntityData.BaseEventEntity.Id, flashEventEntityData);
				break;
			}
			case 1:
			{
				PlayerEntityData playerEntityData = ProtoBufUtility.Deserialize<PlayerEntityData>(array4);
				orCreate.PlayerEntityDataDict.Add(playerEntityData.Id, playerEntityData);
				break;
			}
			case 9:
			{
				SceneBufEntityData sceneBufEntityData = ProtoBufUtility.Deserialize<SceneBufEntityData>(array4);
				orCreate.SceneBufEntityDataDict.Add(sceneBufEntityData.Id, sceneBufEntityData);
				break;
			}
			case 2:
			{
				PlayerPartEntityData playerPartEntityData = ProtoBufUtility.Deserialize<PlayerPartEntityData>(array4);
				orCreate.PlayerPartEntityDataDict.Add(playerPartEntityData.Id, playerPartEntityData);
				break;
			}
			case 10:
			{
				MoveEntityData moveEntityData = ProtoBufUtility.Deserialize<MoveEntityData>(array4);
				orCreate.MoveEntityDataDict.Add(moveEntityData.Id, moveEntityData);
				break;
			}
			case 14:
			case 26:
			{
				PveTowerEntityData pveTowerEntityData = ProtoBufUtility.Deserialize<PveTowerEntityData>(array4);
				orCreate.PveTowerEntityDataDict.Add(pveTowerEntityData.Id, pveTowerEntityData);
				break;
			}
			case 23:
			{
				SceneItweenEntityData sceneItweenEntityData = ProtoBufUtility.Deserialize<SceneItweenEntityData>(array4);
				orCreate.SceneItweenEntityDataDict.Add(sceneItweenEntityData.BaseMoveEntity.Id, sceneItweenEntityData);
				Snapshot.ItweenRecords[sceneItweenEntityData] = orCreate.ServerTime;
				break;
			}
			case 13:
			{
				NpcEntityData npcEntityData = ProtoBufUtility.Deserialize<NpcEntityData>(array4);
				orCreate.NpcEntityDataDict.Add(npcEntityData.Id, npcEntityData);
				break;
			}
			case 8:
			{
				ShakeEventEntityData shakeEventEntityData = ProtoBufUtility.Deserialize<ShakeEventEntityData>(array4);
				orCreate.ShakeEventEntityDataDict.Add(shakeEventEntityData.BaseEventEntity.Id, shakeEventEntityData);
				break;
			}
			case 30:
			{
				SimpleEngineEntityData simpleEngineEntityData = ProtoBufUtility.Deserialize<SimpleEngineEntityData>(array4);
				orCreate.SimpleEngineEntityDataDict.Add(simpleEngineEntityData.Id, simpleEngineEntityData);
				break;
			}
			case 20:
			{
				CameraEntityData cameraEntityData = ProtoBufUtility.Deserialize<CameraEntityData>(array4);
				orCreate.CameraEntityDataDict.Add(cameraEntityData.Id, cameraEntityData);
				break;
			}
			case 18:
			{
				TitanEventEntityData titanEventEntityData = ProtoBufUtility.Deserialize<TitanEventEntityData>(array4);
				orCreate.TitanEventEntityDataDict.Add(titanEventEntityData.BaseEventEntity.Id, titanEventEntityData);
				break;
			}
			case 34:
			{
				ShowBodyEffectEntityData showBodyEffectEntityData = ProtoBufUtility.Deserialize<ShowBodyEffectEntityData>(array4);
				orCreate.ShowBodyEffectEntityDataDict.Add(showBodyEffectEntityData.BaseEventEntity.Id, showBodyEffectEntityData);
				break;
			}
			case 21:
			{
				Pve3EventEntityData pve3EventEntityData = ProtoBufUtility.Deserialize<Pve3EventEntityData>(array4);
				orCreate.Pve3EventEntityDataDict.Add(pve3EventEntityData.BaseEventEntity.Id, pve3EventEntityData);
				break;
			}
			case 22:
			{
				BowHitWallEventEntityData bowHitWallEventEntityData = ProtoBufUtility.Deserialize<BowHitWallEventEntityData>(array4);
				orCreate.BowHitWallEventEntityDataDict.Add(bowHitWallEventEntityData.BaseEventEntity.Id, bowHitWallEventEntityData);
				break;
			}
			case 25:
			{
				GeneralPveSceneItemEntityData generalPveSceneItemEntityData = ProtoBufUtility.Deserialize<GeneralPveSceneItemEntityData>(array4);
				orCreate.GeneralPveSceneItemEntityDataDict.Add(generalPveSceneItemEntityData.Id, generalPveSceneItemEntityData);
				break;
			}
			case 31:
			{
				ComplexEngineEntityData complexEngineEntityData = ProtoBufUtility.Deserialize<ComplexEngineEntityData>(array4);
				orCreate.ComplexEngineEntityDataDict.Add(complexEngineEntityData.Id, complexEngineEntityData);
				break;
			}
			case 35:
			{
				SoundEventEntityData soundEventEntityData = ProtoBufUtility.Deserialize<SoundEventEntityData>(array4);
				orCreate.SoundEventEntityDataDict.Add(soundEventEntityData.BaseEventEntity.Id, soundEventEntityData);
				break;
			}
			case 36:
			{
				CustomMoveEntityData customMoveEntityData = ProtoBufUtility.Deserialize<CustomMoveEntityData>(array4);
				orCreate.CustomMoveEntityDataDict.Add(customMoveEntityData.Id, customMoveEntityData);
				break;
			}
			}
		}
		NetByteFactory.Instance.AddSnapshotReceive(data);
		return orCreate;
	}

	private void readPlayerPart1(MemoryStream stream, Snapshot baseSnap, PlayerEntityData playerEntityData, int hasField)
	{
		PlayerEntityData value = null;
		baseSnap?.PlayerEntityDataDict.TryGetValue(playerEntityData.Id, out value);
		if (((uint)hasField & 0x7Fu) != 0)
		{
			if ((hasField & 1) > 0)
			{
				float viewPitch = NetTableBase.readAngle(stream);
				playerEntityData.ViewPitch = viewPitch;
			}
			if ((hasField & 2) > 0)
			{
				float x = ((value == null) ? NetTableBase.readWholeFloat(stream) : NetTableBase.readDeltaFloat(stream, value.X));
				playerEntityData.X = x;
			}
			if ((hasField & 4) > 0)
			{
				float y = ((value == null) ? NetTableBase.readWholeFloat(stream) : NetTableBase.readDeltaFloat(stream, value.Y));
				playerEntityData.Y = y;
			}
			if ((hasField & 8) > 0)
			{
				float viewYaw = NetTableBase.readAngle(stream);
				playerEntityData.ViewYaw = viewYaw;
			}
			if ((hasField & 0x10) > 0)
			{
				float moveYaw = NetTableBase.readAngle(stream);
				playerEntityData.MoveYaw = moveYaw;
			}
			if ((hasField & 0x20) > 0)
			{
				int velocity2D = NetTableBase.readVarint64(stream);
				playerEntityData.Velocity2D = velocity2D;
			}
			if ((hasField & 0x40) > 0)
			{
				int legsAnim = NetTableBase.readVarint64(stream);
				playerEntityData.LegsAnim = legsAnim;
			}
		}
	}

	private byte readPlayerPart2(MemoryStream stream, Snapshot baseSnap, PlayerEntityData playerEntityData, bool hasField2or3)
	{
		int num = 0;
		byte b = 0;
		if (!hasField2or3)
		{
			num = 0;
		}
		else
		{
			b = (byte)stream.ReadByte();
			num = (((b & 0x80) > 0) ? 1 : (((b & 0x40) <= 0) ? 3 : 2));
		}
		PlayerEntityData value = null;
		baseSnap?.PlayerEntityDataDict.TryGetValue(playerEntityData.Id, out value);
		if (num == 0 || num == 3)
		{
			return b;
		}
		if (value == null)
		{
			if ((b & 1) > 0 && (b & 2) > 0 && (b & 4) > 0 && (b & 8) > 0 && (b & 0x10) > 0 && (b & 0x20) > 0)
			{
				playerEntityData.Z = NetTableBase.readWholeFloat(stream);
				NetTableBase.readPlayerBooleanField(stream, playerEntityData);
				playerEntityData.ClientTime = NetTableBase.readVarint64(stream);
				playerEntityData.CmdSequence = NetTableBase.readVarint64(stream);
				playerEntityData.PunchYaw = NetTableBase.readAngle(stream);
				playerEntityData.PunchPitch = NetTableBase.readAngle(stream);
			}
			else if ((b & 1) > 0 && (b & 2) > 0)
			{
				playerEntityData.Z = NetTableBase.readWholeFloat(stream);
				NetTableBase.readPlayerBooleanField(stream, playerEntityData);
			}
		}
		else
		{
			if ((b & 1) > 0)
			{
				playerEntityData.Z = NetTableBase.readDeltaFloat(stream, value.Z);
			}
			if ((b & 2) > 0)
			{
				NetTableBase.readPlayerBooleanField(stream, playerEntityData);
			}
			if ((b & 4) > 0)
			{
				int num2 = NetTableBase.readVarint64(stream);
				playerEntityData.ClientTime = num2 + value.ClientTime;
			}
			if ((b & 8) > 0)
			{
				int num3 = NetTableBase.readVarint64(stream);
				playerEntityData.CmdSequence = num3 + value.CmdSequence;
			}
			if ((b & 0x10) > 0)
			{
				playerEntityData.PunchYaw = NetTableBase.readAngle(stream);
			}
			if ((b & 0x20) > 0)
			{
				playerEntityData.PunchPitch = NetTableBase.readAngle(stream);
			}
		}
		return b;
	}

	private void readPlayerPart3(MemoryStream stream, Snapshot baseSnap, PlayerEntityData playerEntityData, bool hasField2or3, byte field2or3Flag)
	{
		int num = 0;
		num = (hasField2or3 ? (((field2or3Flag & 0x80) > 0) ? 1 : (((field2or3Flag & 0x40) <= 0) ? 3 : 2)) : 0);
		PlayerEntityData value = null;
		baseSnap?.PlayerEntityDataDict.TryGetValue(playerEntityData.Id, out value);
		int num2;
		switch (num)
		{
		case 0:
		case 2:
			return;
		default:
			num2 = field2or3Flag;
			break;
		case 1:
			num2 = stream.ReadByte();
			break;
		}
		if ((num2 & 1) > 0)
		{
			playerEntityData.LegsSpeedAnimTime = NetTableBase.readVarint64(stream);
		}
		if ((num2 & 2) > 0)
		{
			playerEntityData.ViewAnimationTimer = NetTableBase.readVarint64(stream);
		}
		if ((num2 & 4) > 0)
		{
			playerEntityData.LegsAnimationTimer = NetTableBase.readVarint64(stream);
		}
		if ((num2 & 8) > 0)
		{
			playerEntityData.LeftViewAnimationTimer = NetTableBase.readVarint64(stream);
		}
		if ((num2 & 0x10) > 0)
		{
			playerEntityData.DeadTimer = NetTableBase.readVarint64(stream);
		}
		if ((num2 & 0x20) > 0)
		{
			playerEntityData.TorsoAnimationTimer = NetTableBase.readVarint64(stream);
		}
	}
}
