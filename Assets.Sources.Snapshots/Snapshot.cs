using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using NetData;
using SSJJBase.Extensions;

namespace Assets.Sources.Snapshots;

public class Snapshot : ISnapshot
{
	public static Dictionary<SceneItweenEntityData, int> ItweenRecords = new Dictionary<SceneItweenEntityData, int>();

	public Dictionary<int, BombEntityData> BombEntityDataDict = new Dictionary<int, BombEntityData>(24);

	public Dictionary<int, BowHitWallEventEntityData> BowHitWallEventEntityDataDict = new Dictionary<int, BowHitWallEventEntityData>(24);

	public Dictionary<int, ComplexEngineEntityData> ComplexEngineEntityDataDict = new Dictionary<int, ComplexEngineEntityData>(24);

	public Dictionary<int, GeneralPveSceneItemEntityData> GeneralPveSceneItemEntityDataDict = new Dictionary<int, GeneralPveSceneItemEntityData>(24);

	public Dictionary<int, ITweenEntityData> ITweenEntityDataDict = new Dictionary<int, ITweenEntityData>(24);

	public Dictionary<int, SprayEventEntityData> SprayEventEntityDataDict = new Dictionary<int, SprayEventEntityData>(24);

	public bool IsDispose { get; set; }

	public bool IsTiny { get; set; }

	public int Base { get; set; }

	public int SeqId { get; set; }

	public int ServerTime { get; set; }

	public int SelfClientTime { get; set; }

	public int SelfClientTimeLastDiff { get; set; }

	public int Self { get; set; }

	public int Observer { get; set; }

	public int ControlId { get; set; }

	public List<int> DeletedEntityIdList { get; set; }

	public PlayerBagListData BagList { get; set; }

	public int LastCmd { get; set; }

	public bool BulletHoleCreated { get; set; }

	public int MainCameraId { get; set; }

	public Dictionary<int, BaseEventEntityData> BaseEventEntityDataDict { get; set; }

	public Dictionary<int, BeingHitEventEntityData> BeingHitEventEntityDataDict { get; set; }

	public Dictionary<int, BulletHitWallEventEntityData> BulletHitWallEventEntityDataDict { get; set; }

	public Dictionary<int, BulletRailEventEntityData> BulletRailEventEntityDataDict { get; set; }

	public Dictionary<int, CameraEntityData> CameraEntityDataDict { get; set; }

	public Dictionary<int, CustomMoveEntityData> CustomMoveEntityDataDict { get; set; }

	public Dictionary<int, FlashEventEntityData> FlashEventEntityDataDict { get; set; }

	public Dictionary<int, GrenadeExplosionEventEntityData> GrenadeExplosionEventEntityDataDict { get; set; }

	public Dictionary<int, LinkEntityData> LinkEntityDataDict { get; set; }

	public Dictionary<int, MoveEntityData> MoveEntityDataDict { get; set; }

	public Dictionary<int, NpcEntityData> NpcEntityDataDict { get; set; }

	public Dictionary<int, PlayerEntityData> PlayerEntityDataDict { get; set; }

	public Dictionary<int, PlayerPartEntityData> PlayerPartEntityDataDict { get; set; }

	public Dictionary<int, Pve3EventEntityData> Pve3EventEntityDataDict { get; set; }

	public Dictionary<int, PveTowerEntityData> PveTowerEntityDataDict { get; set; }

	public Dictionary<int, SceneBufEntityData> SceneBufEntityDataDict { get; set; }

	public Dictionary<int, SceneItemEntityData> SceneItemEntityDataDict { get; set; }

	public Dictionary<int, SceneItweenEntityData> SceneItweenEntityDataDict { get; set; }

	public Dictionary<int, SceneWeaponEntityData> SceneWeaponEntityDataDict { get; set; }

	public Dictionary<int, ShakeEventEntityData> ShakeEventEntityDataDict { get; set; }

	public Dictionary<int, ShowBodyEffectEntityData> ShowBodyEffectEntityDataDict { get; set; }

	public Dictionary<int, ShowDamageEventEntityData> ShowDamageEventEntityDataDict { get; set; }

	public Dictionary<int, SimpleEngineEntityData> SimpleEngineEntityDataDict { get; set; }

	public Dictionary<int, SoundEventEntityData> SoundEventEntityDataDict { get; set; }

	public Dictionary<int, TitanEventEntityData> TitanEventEntityDataDict { get; set; }

	public Dictionary<int, TowerEventEntityData> TowerEventEntityDataDict { get; set; }

	public Snapshot()
	{
		SeqId = 0;
		ServerTime = 0;
		SelfClientTime = 0;
		SelfClientTimeLastDiff = 0;
		Self = 0;
		Observer = 0;
		ControlId = 0;
		DeletedEntityIdList = new List<int>();
		LastCmd = 0;
		MainCameraId = 0;
		BaseEventEntityDataDict = new Dictionary<int, BaseEventEntityData>(24);
		BeingHitEventEntityDataDict = new Dictionary<int, BeingHitEventEntityData>(24);
		BulletHitWallEventEntityDataDict = new Dictionary<int, BulletHitWallEventEntityData>(24);
		BulletRailEventEntityDataDict = new Dictionary<int, BulletRailEventEntityData>(24);
		CameraEntityDataDict = new Dictionary<int, CameraEntityData>(24);
		CustomMoveEntityDataDict = new Dictionary<int, CustomMoveEntityData>(24);
		FlashEventEntityDataDict = new Dictionary<int, FlashEventEntityData>(16);
		GrenadeExplosionEventEntityDataDict = new Dictionary<int, GrenadeExplosionEventEntityData>(24);
		LinkEntityDataDict = new Dictionary<int, LinkEntityData>(24);
		MoveEntityDataDict = new Dictionary<int, MoveEntityData>(24);
		NpcEntityDataDict = new Dictionary<int, NpcEntityData>(16);
		PlayerEntityDataDict = new Dictionary<int, PlayerEntityData>(24);
		PlayerPartEntityDataDict = new Dictionary<int, PlayerPartEntityData>(24);
		Pve3EventEntityDataDict = new Dictionary<int, Pve3EventEntityData>(24);
		PveTowerEntityDataDict = new Dictionary<int, PveTowerEntityData>(24);
		SceneBufEntityDataDict = new Dictionary<int, SceneBufEntityData>(24);
		SceneItweenEntityDataDict = new Dictionary<int, SceneItweenEntityData>(24);
		SceneWeaponEntityDataDict = new Dictionary<int, SceneWeaponEntityData>(24);
		ShakeEventEntityDataDict = new Dictionary<int, ShakeEventEntityData>(24);
		ShowBodyEffectEntityDataDict = new Dictionary<int, ShowBodyEffectEntityData>(24);
		ShowDamageEventEntityDataDict = new Dictionary<int, ShowDamageEventEntityData>(24);
		SimpleEngineEntityDataDict = new Dictionary<int, SimpleEngineEntityData>(24);
		SoundEventEntityDataDict = new Dictionary<int, SoundEventEntityData>(24);
		TitanEventEntityDataDict = new Dictionary<int, TitanEventEntityData>(24);
		TowerEventEntityDataDict = new Dictionary<int, TowerEventEntityData>(24);
		SceneItemEntityDataDict = new Dictionary<int, SceneItemEntityData>(24);
	}

	public void Reset()
	{
		DeletedEntityIdList.Clear();
		BulletHoleCreated = false;
	}

	private static PlayerBagData GetBag(PlayerBagListData bagList, int bagId)
	{
		foreach (PlayerBagData bag in bagList.Bags)
		{
			if (bag.BagId == bagId)
			{
				return bag;
			}
		}
		return null;
	}

	public static void CloneBag(Snapshot dst, Snapshot src)
	{
		if (src == null || src.BagList == null || src.Observer != dst.Observer)
		{
			return;
		}
		if (dst.BagList == null)
		{
			dst.BagList = src.BagList;
		}
		foreach (PlayerBagData bag2 in src.BagList.Bags)
		{
			PlayerBagData bag = GetBag(dst.BagList, bag2.BagId);
			if (bag != null)
			{
				bag.FirstWeapon = (bag.DelWeaponIndex.Contains(1) ? null : EntityDataExtension.CloneBaseWeaponData(bag.FirstWeapon, bag2.FirstWeapon));
				bag.SecondaryWeapon = (bag.DelWeaponIndex.Contains(2) ? null : EntityDataExtension.CloneBaseWeaponData(bag.SecondaryWeapon, bag2.SecondaryWeapon));
				bag.MeleeWeapon = (bag.DelWeaponIndex.Contains(3) ? null : EntityDataExtension.CloneBaseWeaponData(bag.MeleeWeapon, bag2.MeleeWeapon));
				bag.BombWeapons0 = (bag.DelWeaponIndex.Contains(4) ? null : EntityDataExtension.CloneBaseWeaponData(bag.BombWeapons0, bag2.BombWeapons0));
				bag.BombWeapons1 = (bag.DelWeaponIndex.Contains(5) ? null : EntityDataExtension.CloneBaseWeaponData(bag.BombWeapons1, bag2.BombWeapons1));
				bag.BombWeapons2 = (bag.DelWeaponIndex.Contains(6) ? null : EntityDataExtension.CloneBaseWeaponData(bag.BombWeapons2, bag2.BombWeapons2));
			}
			else
			{
				dst.BagList.Bags.Add(bag2);
			}
		}
		dst.BagList.C4Weapon = ((dst.BagList.C4Weapon == null) ? null : EntityDataExtension.CloneBaseWeaponData(dst.BagList.C4Weapon, src.BagList.C4Weapon));
	}

	public static void SetFristPlayerEntity(Snapshot dst, Dictionary<int, PlayerEntityData> fristPlayerEntityDict, Dictionary<int, PlayerEntityData> fristAccessoryPlayerEntityDict)
	{
		foreach (KeyValuePair<int, PlayerEntityData> item in dst.PlayerEntityDataDict)
		{
			PlayerEntityData value = null;
			if (fristAccessoryPlayerEntityDict.TryGetValue(item.Key, out value))
			{
				if (!value.Career.Equals(item.Value.Career))
				{
					fristAccessoryPlayerEntityDict[item.Key] = item.Value;
				}
				else if (item.Value.AccessoryList.Count == 0)
				{
					item.Value.AccessoryList.Clear();
					for (int i = 0; i < value.AccessoryList.Count; i++)
					{
						item.Value.AccessoryList.Add(value.AccessoryList[i]);
					}
				}
				else
				{
					value.AccessoryList.Clear();
					for (int j = 0; j < item.Value.AccessoryList.Count; j++)
					{
						value.AccessoryList.Add(item.Value.AccessoryList[j]);
					}
				}
			}
			else
			{
				fristAccessoryPlayerEntityDict[item.Key] = item.Value;
			}
		}
		foreach (KeyValuePair<int, PlayerEntityData> item2 in dst.PlayerEntityDataDict)
		{
			if (!fristPlayerEntityDict.ContainsKey(item2.Key) && item2.Value.ETypeSpecified)
			{
				fristPlayerEntityDict[item2.Key] = item2.Value;
			}
		}
	}

	public void ResetEntities()
	{
		BaseEventEntityDataDict.Clear();
		BeingHitEventEntityDataDict.Clear();
		BombEntityDataDict.Clear();
		BowHitWallEventEntityDataDict.Clear();
		BulletHitWallEventEntityDataDict.Clear();
		BulletRailEventEntityDataDict.Clear();
		CameraEntityDataDict.Clear();
		ComplexEngineEntityDataDict.Clear();
		CustomMoveEntityDataDict.Clear();
		FlashEventEntityDataDict.Clear();
		GeneralPveSceneItemEntityDataDict.Clear();
		GrenadeExplosionEventEntityDataDict.Clear();
		ITweenEntityDataDict.Clear();
		LinkEntityDataDict.Clear();
		MoveEntityDataDict.Clear();
		NpcEntityDataDict.Clear();
		PlayerEntityDataDict.Clear();
		PlayerPartEntityDataDict.Clear();
		Pve3EventEntityDataDict.Clear();
		PveTowerEntityDataDict.Clear();
		SceneBufEntityDataDict.Clear();
		SceneItemEntityDataDict.Clear();
		SceneItweenEntityDataDict.Clear();
		SceneWeaponEntityDataDict.Clear();
		ShakeEventEntityDataDict.Clear();
		ShowBodyEffectEntityDataDict.Clear();
		ShowDamageEventEntityDataDict.Clear();
		SimpleEngineEntityDataDict.Clear();
		SoundEventEntityDataDict.Clear();
		SprayEventEntityDataDict.Clear();
		TitanEventEntityDataDict.Clear();
		TowerEventEntityDataDict.Clear();
	}

	public static void CloneEntities(Snapshot dst, Snapshot src)
	{
		if (src == null)
		{
			return;
		}
		foreach (KeyValuePair<int, BaseEventEntityData> item in dst.BaseEventEntityDataDict)
		{
			BaseEventEntityData value = null;
			src.BaseEventEntityDataDict.TryGetValue(item.Key, out value);
			EntityDataExtension.CloneBaseEventEntityData(item.Value, value);
		}
		foreach (KeyValuePair<int, BaseEventEntityData> item2 in src.BaseEventEntityDataDict)
		{
			if (!dst.BaseEventEntityDataDict.ContainsKey(item2.Key) && !dst.DeletedEntityIdList.Contains(item2.Key))
			{
				dst.BaseEventEntityDataDict.Add(item2.Key, item2.Value);
			}
		}
		foreach (KeyValuePair<int, BeingHitEventEntityData> item3 in dst.BeingHitEventEntityDataDict)
		{
			BeingHitEventEntityData value2 = null;
			src.BeingHitEventEntityDataDict.TryGetValue(item3.Key, out value2);
			EntityDataExtension.CloneBeingHitEventEntityData(item3.Value, value2);
		}
		foreach (KeyValuePair<int, BeingHitEventEntityData> item4 in src.BeingHitEventEntityDataDict)
		{
			if (!dst.BeingHitEventEntityDataDict.ContainsKey(item4.Key) && !dst.DeletedEntityIdList.Contains(item4.Key))
			{
				dst.BeingHitEventEntityDataDict.Add(item4.Key, item4.Value);
			}
		}
		foreach (KeyValuePair<int, BombEntityData> item5 in dst.BombEntityDataDict)
		{
			BombEntityData value3 = null;
			src.BombEntityDataDict.TryGetValue(item5.Key, out value3);
			EntityDataExtension.CloneBombEntityData(item5.Value, value3);
		}
		foreach (KeyValuePair<int, BombEntityData> item6 in src.BombEntityDataDict)
		{
			if (!dst.BombEntityDataDict.ContainsKey(item6.Key) && !dst.DeletedEntityIdList.Contains(item6.Key))
			{
				dst.BombEntityDataDict.Add(item6.Key, item6.Value);
			}
		}
		foreach (KeyValuePair<int, BowHitWallEventEntityData> item7 in dst.BowHitWallEventEntityDataDict)
		{
			BowHitWallEventEntityData value4 = null;
			src.BowHitWallEventEntityDataDict.TryGetValue(item7.Key, out value4);
			EntityDataExtension.CloneBowHitWallEventEntityData(item7.Value, value4);
		}
		foreach (KeyValuePair<int, BowHitWallEventEntityData> item8 in src.BowHitWallEventEntityDataDict)
		{
			if (!dst.BowHitWallEventEntityDataDict.ContainsKey(item8.Key) && !dst.DeletedEntityIdList.Contains(item8.Key))
			{
				dst.BowHitWallEventEntityDataDict.Add(item8.Key, item8.Value);
			}
		}
		foreach (KeyValuePair<int, BulletHitWallEventEntityData> item9 in dst.BulletHitWallEventEntityDataDict)
		{
			BulletHitWallEventEntityData value5 = null;
			src.BulletHitWallEventEntityDataDict.TryGetValue(item9.Key, out value5);
			EntityDataExtension.CloneBulletHitWallEventEntityData(item9.Value, value5);
		}
		foreach (KeyValuePair<int, BulletHitWallEventEntityData> item10 in src.BulletHitWallEventEntityDataDict)
		{
			if (!dst.BulletHitWallEventEntityDataDict.ContainsKey(item10.Key) && !dst.DeletedEntityIdList.Contains(item10.Key))
			{
				dst.BulletHitWallEventEntityDataDict.Add(item10.Key, item10.Value);
			}
		}
		foreach (KeyValuePair<int, BulletRailEventEntityData> item11 in dst.BulletRailEventEntityDataDict)
		{
			BulletRailEventEntityData value6 = null;
			src.BulletRailEventEntityDataDict.TryGetValue(item11.Key, out value6);
			EntityDataExtension.CloneBulletRailEventEntityData(item11.Value, value6);
		}
		foreach (KeyValuePair<int, BulletRailEventEntityData> item12 in src.BulletRailEventEntityDataDict)
		{
			if (!dst.BulletRailEventEntityDataDict.ContainsKey(item12.Key) && !dst.DeletedEntityIdList.Contains(item12.Key))
			{
				dst.BulletRailEventEntityDataDict.Add(item12.Key, item12.Value);
			}
		}
		foreach (KeyValuePair<int, CameraEntityData> item13 in dst.CameraEntityDataDict)
		{
			CameraEntityData value7 = null;
			src.CameraEntityDataDict.TryGetValue(item13.Key, out value7);
			EntityDataExtension.CloneCameraEntityData(item13.Value, value7);
		}
		foreach (KeyValuePair<int, CameraEntityData> item14 in src.CameraEntityDataDict)
		{
			if (!dst.CameraEntityDataDict.ContainsKey(item14.Key) && !dst.DeletedEntityIdList.Contains(item14.Key))
			{
				dst.CameraEntityDataDict.Add(item14.Key, item14.Value);
			}
		}
		foreach (KeyValuePair<int, ComplexEngineEntityData> item15 in dst.ComplexEngineEntityDataDict)
		{
			ComplexEngineEntityData value8 = null;
			src.ComplexEngineEntityDataDict.TryGetValue(item15.Key, out value8);
			EntityDataExtension.CloneComplexEngineEntityData(item15.Value, value8);
		}
		foreach (KeyValuePair<int, ComplexEngineEntityData> item16 in src.ComplexEngineEntityDataDict)
		{
			if (!dst.ComplexEngineEntityDataDict.ContainsKey(item16.Key) && !dst.DeletedEntityIdList.Contains(item16.Key))
			{
				dst.ComplexEngineEntityDataDict.Add(item16.Key, item16.Value);
			}
		}
		foreach (KeyValuePair<int, CustomMoveEntityData> item17 in dst.CustomMoveEntityDataDict)
		{
			CustomMoveEntityData value9 = null;
			src.CustomMoveEntityDataDict.TryGetValue(item17.Key, out value9);
			EntityDataExtension.CloneCustomMoveEntityData(item17.Value, value9);
		}
		foreach (KeyValuePair<int, CustomMoveEntityData> item18 in src.CustomMoveEntityDataDict)
		{
			if (!dst.CustomMoveEntityDataDict.ContainsKey(item18.Key) && !dst.DeletedEntityIdList.Contains(item18.Key))
			{
				dst.CustomMoveEntityDataDict.Add(item18.Key, item18.Value);
			}
		}
		foreach (KeyValuePair<int, FlashEventEntityData> item19 in dst.FlashEventEntityDataDict)
		{
			FlashEventEntityData value10 = null;
			src.FlashEventEntityDataDict.TryGetValue(item19.Key, out value10);
			EntityDataExtension.CloneFlashEventEntityData(item19.Value, value10);
		}
		foreach (KeyValuePair<int, FlashEventEntityData> item20 in src.FlashEventEntityDataDict)
		{
			if (!dst.FlashEventEntityDataDict.ContainsKey(item20.Key) && !dst.DeletedEntityIdList.Contains(item20.Key))
			{
				dst.FlashEventEntityDataDict.Add(item20.Key, item20.Value);
			}
		}
		foreach (KeyValuePair<int, GeneralPveSceneItemEntityData> item21 in dst.GeneralPveSceneItemEntityDataDict)
		{
			GeneralPveSceneItemEntityData value11 = null;
			src.GeneralPveSceneItemEntityDataDict.TryGetValue(item21.Key, out value11);
			EntityDataExtension.CloneGeneralPveSceneItemEntityData(item21.Value, value11);
		}
		foreach (KeyValuePair<int, GeneralPveSceneItemEntityData> item22 in src.GeneralPveSceneItemEntityDataDict)
		{
			if (!dst.GeneralPveSceneItemEntityDataDict.ContainsKey(item22.Key) && !dst.DeletedEntityIdList.Contains(item22.Key))
			{
				dst.GeneralPveSceneItemEntityDataDict.Add(item22.Key, item22.Value);
			}
		}
		foreach (KeyValuePair<int, GrenadeExplosionEventEntityData> item23 in dst.GrenadeExplosionEventEntityDataDict)
		{
			GrenadeExplosionEventEntityData value12 = null;
			src.GrenadeExplosionEventEntityDataDict.TryGetValue(item23.Key, out value12);
			EntityDataExtension.CloneGrenadeExplosionEventEntityData(item23.Value, value12);
		}
		foreach (KeyValuePair<int, GrenadeExplosionEventEntityData> item24 in src.GrenadeExplosionEventEntityDataDict)
		{
			if (!dst.GrenadeExplosionEventEntityDataDict.ContainsKey(item24.Key) && !dst.DeletedEntityIdList.Contains(item24.Key))
			{
				dst.GrenadeExplosionEventEntityDataDict.Add(item24.Key, item24.Value);
			}
		}
		foreach (KeyValuePair<int, ITweenEntityData> item25 in dst.ITweenEntityDataDict)
		{
			ITweenEntityData value13 = null;
			src.ITweenEntityDataDict.TryGetValue(item25.Key, out value13);
			EntityDataExtension.CloneITweenEntityData(item25.Value, value13);
		}
		foreach (KeyValuePair<int, ITweenEntityData> item26 in src.ITweenEntityDataDict)
		{
			if (!dst.ITweenEntityDataDict.ContainsKey(item26.Key) && !dst.DeletedEntityIdList.Contains(item26.Key))
			{
				dst.ITweenEntityDataDict.Add(item26.Key, item26.Value);
			}
		}
		foreach (KeyValuePair<int, LinkEntityData> item27 in dst.LinkEntityDataDict)
		{
			LinkEntityData value14 = null;
			src.LinkEntityDataDict.TryGetValue(item27.Key, out value14);
			EntityDataExtension.CloneLinkEntityData(item27.Value, value14);
		}
		foreach (KeyValuePair<int, LinkEntityData> item28 in src.LinkEntityDataDict)
		{
			if (!dst.LinkEntityDataDict.ContainsKey(item28.Key) && !dst.DeletedEntityIdList.Contains(item28.Key))
			{
				dst.LinkEntityDataDict.Add(item28.Key, item28.Value);
			}
		}
		foreach (KeyValuePair<int, MoveEntityData> item29 in dst.MoveEntityDataDict)
		{
			MoveEntityData value15 = null;
			src.MoveEntityDataDict.TryGetValue(item29.Key, out value15);
			EntityDataExtension.CloneMoveEntityData(item29.Value, value15);
		}
		foreach (KeyValuePair<int, MoveEntityData> item30 in src.MoveEntityDataDict)
		{
			if (!dst.MoveEntityDataDict.ContainsKey(item30.Key) && !dst.DeletedEntityIdList.Contains(item30.Key))
			{
				dst.MoveEntityDataDict.Add(item30.Key, item30.Value);
			}
		}
		foreach (KeyValuePair<int, NpcEntityData> item31 in dst.NpcEntityDataDict)
		{
			NpcEntityData value16 = null;
			src.NpcEntityDataDict.TryGetValue(item31.Key, out value16);
			EntityDataExtension.CloneNpcEntityData(item31.Value, value16);
		}
		foreach (KeyValuePair<int, NpcEntityData> item32 in src.NpcEntityDataDict)
		{
			if (!dst.NpcEntityDataDict.ContainsKey(item32.Key) && !dst.DeletedEntityIdList.Contains(item32.Key))
			{
				dst.NpcEntityDataDict.Add(item32.Key, item32.Value);
			}
		}
		foreach (KeyValuePair<int, PlayerEntityData> item33 in dst.PlayerEntityDataDict)
		{
			PlayerEntityData value17 = null;
			src.PlayerEntityDataDict.TryGetValue(item33.Key, out value17);
			EntityDataExtension.ClonePlayerEntityData(item33.Value, value17);
		}
		foreach (KeyValuePair<int, PlayerEntityData> item34 in src.PlayerEntityDataDict)
		{
			if (!dst.PlayerEntityDataDict.ContainsKey(item34.Key) && !dst.DeletedEntityIdList.Contains(item34.Key))
			{
				dst.PlayerEntityDataDict.Add(item34.Key, item34.Value);
			}
		}
		foreach (KeyValuePair<int, PlayerPartEntityData> item35 in dst.PlayerPartEntityDataDict)
		{
			PlayerPartEntityData value18 = null;
			src.PlayerPartEntityDataDict.TryGetValue(item35.Key, out value18);
			EntityDataExtension.ClonePlayerPartEntityData(item35.Value, value18);
		}
		foreach (KeyValuePair<int, PlayerPartEntityData> item36 in src.PlayerPartEntityDataDict)
		{
			if (!dst.PlayerPartEntityDataDict.ContainsKey(item36.Key) && !dst.DeletedEntityIdList.Contains(item36.Key))
			{
				dst.PlayerPartEntityDataDict.Add(item36.Key, item36.Value);
			}
		}
		foreach (KeyValuePair<int, Pve3EventEntityData> item37 in dst.Pve3EventEntityDataDict)
		{
			Pve3EventEntityData value19 = null;
			src.Pve3EventEntityDataDict.TryGetValue(item37.Key, out value19);
			EntityDataExtension.ClonePve3EventEntityData(item37.Value, value19);
		}
		foreach (KeyValuePair<int, Pve3EventEntityData> item38 in src.Pve3EventEntityDataDict)
		{
			if (!dst.Pve3EventEntityDataDict.ContainsKey(item38.Key) && !dst.DeletedEntityIdList.Contains(item38.Key))
			{
				dst.Pve3EventEntityDataDict.Add(item38.Key, item38.Value);
			}
		}
		foreach (KeyValuePair<int, PveTowerEntityData> item39 in dst.PveTowerEntityDataDict)
		{
			PveTowerEntityData value20 = null;
			src.PveTowerEntityDataDict.TryGetValue(item39.Key, out value20);
			EntityDataExtension.ClonePveTowerEntityData(item39.Value, value20);
		}
		foreach (KeyValuePair<int, PveTowerEntityData> item40 in src.PveTowerEntityDataDict)
		{
			if (!dst.PveTowerEntityDataDict.ContainsKey(item40.Key) && !dst.DeletedEntityIdList.Contains(item40.Key))
			{
				dst.PveTowerEntityDataDict.Add(item40.Key, item40.Value);
			}
		}
		foreach (KeyValuePair<int, SceneBufEntityData> item41 in dst.SceneBufEntityDataDict)
		{
			SceneBufEntityData value21 = null;
			src.SceneBufEntityDataDict.TryGetValue(item41.Key, out value21);
			EntityDataExtension.CloneSceneBufEntityData(item41.Value, value21);
		}
		foreach (KeyValuePair<int, SceneBufEntityData> item42 in src.SceneBufEntityDataDict)
		{
			if (!dst.SceneBufEntityDataDict.ContainsKey(item42.Key) && !dst.DeletedEntityIdList.Contains(item42.Key))
			{
				dst.SceneBufEntityDataDict.Add(item42.Key, item42.Value);
			}
		}
		foreach (KeyValuePair<int, SceneItemEntityData> item43 in dst.SceneItemEntityDataDict)
		{
			SceneItemEntityData value22 = null;
			src.SceneItemEntityDataDict.TryGetValue(item43.Key, out value22);
			EntityDataExtension.CloneSceneItemEntityData(item43.Value, value22);
		}
		foreach (KeyValuePair<int, SceneItemEntityData> item44 in src.SceneItemEntityDataDict)
		{
			if (!dst.SceneItemEntityDataDict.ContainsKey(item44.Key) && !dst.DeletedEntityIdList.Contains(item44.Key))
			{
				dst.SceneItemEntityDataDict.Add(item44.Key, item44.Value);
			}
		}
		foreach (KeyValuePair<int, SceneItweenEntityData> item45 in dst.SceneItweenEntityDataDict)
		{
			SceneItweenEntityData value23 = null;
			src.SceneItweenEntityDataDict.TryGetValue(item45.Key, out value23);
			EntityDataExtension.CloneSceneItweenEntityData(item45.Value, value23);
		}
		foreach (KeyValuePair<int, SceneItweenEntityData> item46 in src.SceneItweenEntityDataDict)
		{
			if (!dst.SceneItweenEntityDataDict.ContainsKey(item46.Key) && !dst.DeletedEntityIdList.Contains(item46.Key))
			{
				dst.SceneItweenEntityDataDict.Add(item46.Key, item46.Value);
			}
		}
		foreach (KeyValuePair<int, SceneWeaponEntityData> item47 in dst.SceneWeaponEntityDataDict)
		{
			SceneWeaponEntityData value24 = null;
			src.SceneWeaponEntityDataDict.TryGetValue(item47.Key, out value24);
			EntityDataExtension.CloneSceneWeaponEntityData(item47.Value, value24);
		}
		foreach (KeyValuePair<int, SceneWeaponEntityData> item48 in src.SceneWeaponEntityDataDict)
		{
			if (!dst.SceneWeaponEntityDataDict.ContainsKey(item48.Key) && !dst.DeletedEntityIdList.Contains(item48.Key))
			{
				dst.SceneWeaponEntityDataDict.Add(item48.Key, item48.Value);
			}
		}
		foreach (KeyValuePair<int, ShakeEventEntityData> item49 in dst.ShakeEventEntityDataDict)
		{
			ShakeEventEntityData value25 = null;
			src.ShakeEventEntityDataDict.TryGetValue(item49.Key, out value25);
			EntityDataExtension.CloneShakeEventEntityData(item49.Value, value25);
		}
		foreach (KeyValuePair<int, ShakeEventEntityData> item50 in src.ShakeEventEntityDataDict)
		{
			if (!dst.ShakeEventEntityDataDict.ContainsKey(item50.Key) && !dst.DeletedEntityIdList.Contains(item50.Key))
			{
				dst.ShakeEventEntityDataDict.Add(item50.Key, item50.Value);
			}
		}
		foreach (KeyValuePair<int, ShowBodyEffectEntityData> item51 in dst.ShowBodyEffectEntityDataDict)
		{
			ShowBodyEffectEntityData value26 = null;
			src.ShowBodyEffectEntityDataDict.TryGetValue(item51.Key, out value26);
			EntityDataExtension.CloneShowBodyEffectEntityData(item51.Value, value26);
		}
		foreach (KeyValuePair<int, ShowBodyEffectEntityData> item52 in src.ShowBodyEffectEntityDataDict)
		{
			if (!dst.ShowBodyEffectEntityDataDict.ContainsKey(item52.Key) && !dst.DeletedEntityIdList.Contains(item52.Key))
			{
				dst.ShowBodyEffectEntityDataDict.Add(item52.Key, item52.Value);
			}
		}
		foreach (KeyValuePair<int, ShowDamageEventEntityData> item53 in dst.ShowDamageEventEntityDataDict)
		{
			ShowDamageEventEntityData value27 = null;
			src.ShowDamageEventEntityDataDict.TryGetValue(item53.Key, out value27);
			EntityDataExtension.CloneShowDamageEventEntityData(item53.Value, value27);
		}
		foreach (KeyValuePair<int, ShowDamageEventEntityData> item54 in src.ShowDamageEventEntityDataDict)
		{
			if (!dst.ShowDamageEventEntityDataDict.ContainsKey(item54.Key) && !dst.DeletedEntityIdList.Contains(item54.Key))
			{
				dst.ShowDamageEventEntityDataDict.Add(item54.Key, item54.Value);
			}
		}
		foreach (KeyValuePair<int, SimpleEngineEntityData> item55 in dst.SimpleEngineEntityDataDict)
		{
			SimpleEngineEntityData value28 = null;
			src.SimpleEngineEntityDataDict.TryGetValue(item55.Key, out value28);
			EntityDataExtension.CloneSimpleEngineEntityData(item55.Value, value28);
		}
		foreach (KeyValuePair<int, SimpleEngineEntityData> item56 in src.SimpleEngineEntityDataDict)
		{
			if (!dst.SimpleEngineEntityDataDict.ContainsKey(item56.Key) && !dst.DeletedEntityIdList.Contains(item56.Key))
			{
				dst.SimpleEngineEntityDataDict.Add(item56.Key, item56.Value);
			}
		}
		foreach (KeyValuePair<int, SoundEventEntityData> item57 in dst.SoundEventEntityDataDict)
		{
			SoundEventEntityData value29 = null;
			src.SoundEventEntityDataDict.TryGetValue(item57.Key, out value29);
			EntityDataExtension.CloneSoundEventEntityData(item57.Value, value29);
		}
		foreach (KeyValuePair<int, SoundEventEntityData> item58 in src.SoundEventEntityDataDict)
		{
			if (!dst.SoundEventEntityDataDict.ContainsKey(item58.Key) && !dst.DeletedEntityIdList.Contains(item58.Key))
			{
				dst.SoundEventEntityDataDict.Add(item58.Key, item58.Value);
			}
		}
		foreach (KeyValuePair<int, SprayEventEntityData> item59 in dst.SprayEventEntityDataDict)
		{
			SprayEventEntityData value30 = null;
			src.SprayEventEntityDataDict.TryGetValue(item59.Key, out value30);
			EntityDataExtension.CloneSprayEventEntityData(item59.Value, value30);
		}
		foreach (KeyValuePair<int, SprayEventEntityData> item60 in src.SprayEventEntityDataDict)
		{
			if (!dst.SprayEventEntityDataDict.ContainsKey(item60.Key) && !dst.DeletedEntityIdList.Contains(item60.Key))
			{
				dst.SprayEventEntityDataDict.Add(item60.Key, item60.Value);
			}
		}
		foreach (KeyValuePair<int, TitanEventEntityData> item61 in dst.TitanEventEntityDataDict)
		{
			TitanEventEntityData value31 = null;
			src.TitanEventEntityDataDict.TryGetValue(item61.Key, out value31);
			EntityDataExtension.CloneTitanEventEntityData(item61.Value, value31);
		}
		foreach (KeyValuePair<int, TitanEventEntityData> item62 in src.TitanEventEntityDataDict)
		{
			if (!dst.TitanEventEntityDataDict.ContainsKey(item62.Key) && !dst.DeletedEntityIdList.Contains(item62.Key))
			{
				dst.TitanEventEntityDataDict.Add(item62.Key, item62.Value);
			}
		}
		foreach (KeyValuePair<int, TowerEventEntityData> item63 in dst.TowerEventEntityDataDict)
		{
			TowerEventEntityData value32 = null;
			src.TowerEventEntityDataDict.TryGetValue(item63.Key, out value32);
			EntityDataExtension.CloneTowerEventEntityData(item63.Value, value32);
		}
		foreach (KeyValuePair<int, TowerEventEntityData> item64 in src.TowerEventEntityDataDict)
		{
			if (!dst.TowerEventEntityDataDict.ContainsKey(item64.Key) && !dst.DeletedEntityIdList.Contains(item64.Key))
			{
				dst.TowerEventEntityDataDict.Add(item64.Key, item64.Value);
			}
		}
	}

	public static void DeleteEntities(Snapshot snapshot, List<int> deleteIdList)
	{
		foreach (int deleteId in deleteIdList)
		{
			if (snapshot.BaseEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.BaseEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.BeingHitEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.BeingHitEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.BombEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.BombEntityDataDict.Remove(deleteId);
			}
			if (snapshot.BowHitWallEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.BowHitWallEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.BulletHitWallEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.BulletHitWallEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.BulletRailEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.BulletRailEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.CameraEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.CameraEntityDataDict.Remove(deleteId);
			}
			if (snapshot.ComplexEngineEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.ComplexEngineEntityDataDict.Remove(deleteId);
			}
			if (snapshot.CustomMoveEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.CustomMoveEntityDataDict.Remove(deleteId);
			}
			if (snapshot.FlashEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.FlashEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.GeneralPveSceneItemEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.GeneralPveSceneItemEntityDataDict.Remove(deleteId);
			}
			if (snapshot.GrenadeExplosionEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.GrenadeExplosionEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.ITweenEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.ITweenEntityDataDict.Remove(deleteId);
			}
			if (snapshot.LinkEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.LinkEntityDataDict.Remove(deleteId);
			}
			if (snapshot.MoveEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.MoveEntityDataDict.Remove(deleteId);
			}
			if (snapshot.NpcEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.NpcEntityDataDict.Remove(deleteId);
			}
			if (snapshot.PlayerEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.PlayerEntityDataDict.Remove(deleteId);
			}
			if (snapshot.PlayerPartEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.PlayerPartEntityDataDict.Remove(deleteId);
			}
			if (snapshot.Pve3EventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.Pve3EventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.PveTowerEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.PveTowerEntityDataDict.Remove(deleteId);
			}
			if (snapshot.SceneBufEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.SceneBufEntityDataDict.Remove(deleteId);
			}
			if (snapshot.SceneItemEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.SceneItemEntityDataDict.Remove(deleteId);
			}
			if (snapshot.SceneItweenEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.SceneItweenEntityDataDict.Remove(deleteId);
			}
			if (snapshot.SceneWeaponEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.SceneWeaponEntityDataDict.Remove(deleteId);
			}
			if (snapshot.ShakeEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.ShakeEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.ShowBodyEffectEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.ShowBodyEffectEntityDataDict.Remove(deleteId);
			}
			if (snapshot.ShowDamageEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.ShowDamageEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.SimpleEngineEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.SimpleEngineEntityDataDict.Remove(deleteId);
			}
			if (snapshot.SoundEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.SoundEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.SprayEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.SprayEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.TitanEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.TitanEventEntityDataDict.Remove(deleteId);
			}
			if (snapshot.TowerEventEntityDataDict.ContainsKey(deleteId))
			{
				snapshot.TowerEventEntityDataDict.Remove(deleteId);
			}
		}
	}
}
