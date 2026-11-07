using System.Collections.Generic;
using NetData;
using SSJJBase.Extensions;

namespace Assets.Sources.Snapshots;

public class SnapshotTemplate
{
	public bool IsTiny;

	public int Base;

	public int SeqId;

	public int ServerTime;

	public int SelfClientTime;

	public int Self;

	public int Observer;

	public int ControlId;

	public List<int> DeletedEntityIdList = new List<int>();

	public PlayerBagListData BagList;

	public int LastCmd;

	public bool BulletHoleCreated;

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

	public static void CloneBag(SnapshotTemplate dst, SnapshotTemplate src)
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
		dst.BagList.C4Weapon = EntityDataExtension.CloneBaseWeaponData(dst.BagList.C4Weapon, src.BagList.C4Weapon);
	}

	public static void SetFristPlayerEntity(Snapshot dst, Dictionary<int, PlayerEntityData> fristPlayerEntityDict)
	{
		foreach (KeyValuePair<int, PlayerEntityData> item in dst.PlayerEntityDataDict)
		{
			if (fristPlayerEntityDict.ContainsKey(item.Key))
			{
				PlayerEntityData playerEntityData = fristPlayerEntityDict[item.Key];
				item.Value.EType = playerEntityData.EType;
				item.Value.PlayerName = playerEntityData.PlayerName;
				item.Value.BiochemicalMagazineFlag = playerEntityData.BiochemicalMagazineFlag;
				item.Value.DetectorFlag = playerEntityData.DetectorFlag;
				item.Value.CharacterId = playerEntityData.CharacterId;
				item.Value.IsBot = playerEntityData.IsBot;
				item.Value.AccessoryList.Clear();
				for (int i = 0; i < playerEntityData.AccessoryList.Count; i++)
				{
					item.Value.AccessoryList.Add(playerEntityData.AccessoryList[i]);
				}
			}
			else if (item.Value.ETypeSpecified)
			{
				fristPlayerEntityDict[item.Key] = item.Value;
			}
		}
	}
}
