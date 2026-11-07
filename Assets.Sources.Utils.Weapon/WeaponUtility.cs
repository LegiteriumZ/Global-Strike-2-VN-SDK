using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Components.Player;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Constant.Weapon;
using Assets.Sources.CsvLoader;
using Assets.Sources.Info.UnityObjects;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;
using SSJJAnim.Weapon;
using SSJJBase.Logger;
using SSJJBase.Pool;
using SSJJBase.Singleton;
using SSJJBase.String;
using UnityEngine;
using share.constant;
using weapon.predicateSystem;
using weapon.utils;

namespace Assets.Sources.Utils.Weapon;

public class WeaponUtility
{
	private static LoggerAdapter _logger = new LoggerAdapter(typeof(WeaponUtility));

	private const int COMPONENT1SELECTED = 2;

	public static bool IsAllFire(PlayerEntity player)
	{
		IEntitsWeaponInfo weaponInfo = player.currentWeapon.WeaponInfo;
		if (weaponInfo == null)
		{
			return false;
		}
		switch (weaponInfo.Name)
		{
		case "revolver_battle":
		case "revolver_battle1":
		case "revolver_battle2":
		case "block_combined_jet":
			return true;
		default:
			return false;
		}
	}

	public static bool HasBulletOtherFireEffect(PlayerEntity player, int fireEvent)
	{
		if (!(player.currentWeapon.WeaponInfo is IWeaponInfo weaponInfo))
		{
			return false;
		}
		if (fireEvent == 11 && weaponInfo.Name == "trans_machinegun")
		{
			return true;
		}
		return false;
	}

	public static bool HasMuzzleFlashForFov(PlayerEntity player, int fov)
	{
		if (!(player.currentWeapon.WeaponInfo is IWeaponInfo weaponInfo))
		{
			return false;
		}
		if (weaponInfo.Name == "trans_machinegun")
		{
			return true;
		}
		return fov == 90;
	}

	public static bool HasMuzzleFlash(PlayerEntity player, bool secondaryFire)
	{
		if (!(player.currentWeapon.WeaponInfo is IWeaponInfo weaponInfo))
		{
			return false;
		}
		if (secondaryFire)
		{
			switch (weaponInfo.Name)
			{
			case "glock":
			case "famas":
			case "famas_r":
			case "md_93r":
			case "qbz97":
			case "ghost_twins":
			case "ghost_twins1":
			case "m249_rocket":
			case "shotgun3_barrel":
			case "hero_cold_death":
			case "m32_a":
			case "roar_sniper_hero":
			case "roar_sniper_hero1":
			case "trans_machinegun":
				return true;
			default:
				if (weaponInfo.AttackType == AttackType.InfiniteHand1 || weaponInfo.AttackType == AttackType.InfiniteHand1Change2)
				{
					return true;
				}
				return false;
			}
		}
		if (IsSpecialWeapon(weaponInfo.Name) || WeaponConstant.IsKnifeByName(weaponInfo.Name))
		{
			return false;
		}
		return true;
	}

	public static WeaponEntity GetCurrentWeapon(PlayerEntity playerEntity)
	{
		if (!Contexts.sharedInstance.playerBag.isCurrentBag)
		{
			return null;
		}
		CurrentWeaponComponent currentWeapon = playerEntity.currentWeapon;
		if (currentWeapon == null)
		{
			return null;
		}
		return GetWeaponAtSlot(playerEntity, Contexts.sharedInstance.playerBag.currentBagEntity.bagId.Value, currentWeapon.Weapon, currentWeapon.Index);
	}

	public static WeaponEntity GetCanUsedWeapon(PlayerEntity myPlayer, PlayerBagEntity bag, int slot)
	{
		WeaponEntity weaponEntity = null;
		if (bag != null)
		{
			Queue<int> queue = QueuePool<int>.Get();
			if (slot == 4)
			{
				queue.Enqueue(4);
				queue.Enqueue(1);
				queue.Enqueue(2);
				queue.Enqueue(3);
			}
			else
			{
				for (int i = 0; i < 3; i++)
				{
					int item = 1 + (slot + i) % 3;
					queue.Enqueue(item);
				}
			}
			while (queue.Count > 0)
			{
				int num = queue.Dequeue();
				if (num == 4)
				{
					bool flag = false;
					for (int j = 0; j < 3; j++)
					{
						weaponEntity = GetWeaponAtSlot(myPlayer, bag, num, j);
						if (weaponEntity != null && weaponEntity.hasBasicInfo && weaponEntity.basicInfo.Data.Clip != 0)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						break;
					}
				}
				else
				{
					weaponEntity = GetWeaponAtSlot(myPlayer, bag, num, 0);
					if (weaponEntity != null)
					{
						break;
					}
				}
			}
			QueuePool<int>.Release(queue);
		}
		return weaponEntity;
	}

	public static WeaponEntity GetWeaponAtSlot(PlayerEntity myPlayer, int bagId, int slot, int index)
	{
		PlayerBagEntity entityWithBagId = Contexts.sharedInstance.playerBag.GetEntityWithBagId(bagId);
		if (entityWithBagId != null)
		{
			return GetWeaponAtSlot(myPlayer, entityWithBagId, slot, index);
		}
		return null;
	}

	public static WeaponEntity GetWeaponAtSlot(PlayerEntity myPlayer, PlayerBagEntity bag, int slot, int index)
	{
		switch (slot)
		{
		case 1:
			if (bag.basicInfo.Data.FirstWeapon == null)
			{
				return null;
			}
			return Contexts.sharedInstance.weapon.GetEntityWithWeaponId(bag.basicInfo.Data.FirstWeapon.Id);
		case 2:
			if (bag.basicInfo.Data.SecondaryWeapon == null)
			{
				return null;
			}
			return Contexts.sharedInstance.weapon.GetEntityWithWeaponId(bag.basicInfo.Data.SecondaryWeapon.Id);
		case 3:
			if (bag.basicInfo.Data.MeleeWeapon == null)
			{
				return null;
			}
			return Contexts.sharedInstance.weapon.GetEntityWithWeaponId(bag.basicInfo.Data.MeleeWeapon.Id);
		case 4:
			switch (index)
			{
			case 0:
				if (bag.basicInfo.Data.BombWeapons0 == null)
				{
					return null;
				}
				return Contexts.sharedInstance.weapon.GetEntityWithWeaponId(bag.basicInfo.Data.BombWeapons0.Id);
			case 1:
				if (bag.basicInfo.Data.BombWeapons1 == null)
				{
					return null;
				}
				return Contexts.sharedInstance.weapon.GetEntityWithWeaponId(bag.basicInfo.Data.BombWeapons1.Id);
			case 2:
				if (bag.basicInfo.Data.BombWeapons2 == null)
				{
					return null;
				}
				return Contexts.sharedInstance.weapon.GetEntityWithWeaponId(bag.basicInfo.Data.BombWeapons2.Id);
			}
			break;
		case 5:
			if (!Contexts.sharedInstance.playerBag.hasC4Bag)
			{
				return null;
			}
			if (Contexts.sharedInstance.playerBag.c4Bag.C4Weapon == null)
			{
				return null;
			}
			return Contexts.sharedInstance.weapon.GetEntityWithWeaponId(Contexts.sharedInstance.playerBag.c4Bag.C4Weapon.Id);
		case 6:
			if (bag.basicInfo.Data.BombWeapons1 == null)
			{
				return null;
			}
			return Contexts.sharedInstance.weapon.GetEntityWithWeaponId(bag.basicInfo.Data.BombWeapons1.Id);
		case 7:
			if (bag.basicInfo.Data.BombWeapons2 == null)
			{
				return null;
			}
			return Contexts.sharedInstance.weapon.GetEntityWithWeaponId(bag.basicInfo.Data.BombWeapons2.Id);
		}
		return null;
	}

	public static bool IsBowCanSwitchToWeapon(PlayerEntity myPlayer, PlayerBagEntity bag, int slot)
	{
		WeaponEntity weaponAtSlot = GetWeaponAtSlot(myPlayer, bag, slot, 0);
		if (weaponAtSlot != null && weaponAtSlot.slot.Slot == 4 && weaponAtSlot.hasBasicInfo && !weaponAtSlot.basicInfo.Data.WeaponName.Equals("c4") && weaponAtSlot.basicInfo.Data.Clip == 0)
		{
			return false;
		}
		return true;
	}

	public static bool NonCuttingWeapon(WeaponEntity targetWeapon)
	{
		if (targetWeapon == null)
		{
			return false;
		}
		if (targetWeapon.basicInfo.Info.Name == "wind_spirit" && targetWeapon.basicInfo.Data.Clip <= 0)
		{
			return true;
		}
		return false;
	}

	public static bool CanSwitchToWeapon(PlayerEntity myPlayer, int bagId, WeaponEntity targetWeapon)
	{
		WeaponEntity weaponAtSlot = GetWeaponAtSlot(myPlayer, bagId, 1, 0);
		if (weaponAtSlot != null)
		{
			return !FreeWeaponConstant.IsCombinationWeapon(weaponAtSlot.basicInfo.Info.Name, targetWeapon.basicInfo.Info.Name);
		}
		return true;
	}

	public static bool WeaponCanBeChanged(PlayerEntity myPlayer, int bagId, WeaponEntity targetWeapon)
	{
		string career = myPlayer.GetCareer();
		if (!string.IsNullOrEmpty(career) && ((targetWeapon.basicInfo.Info.WeaponType == 14 && !PlayerCareerUtil.IsHumanity(career)) || PlayerCareerUtil.IsMech(career) || PlayerCareerUtil.IsHumanHero(career) || PlayerCareerUtil.IsZombieHero(career)))
		{
			return false;
		}
		return true;
	}

	public static bool CanFire(WeaponEntity weapon, int clientTime)
	{
		if (CanAttack(weapon, clientTime))
		{
			return weapon.clip.Clip > 0;
		}
		return false;
	}

	public static bool CanFire2(ref CommonWeaponArg arg)
	{
		if (CanSecondaryAttack(ref arg))
		{
			return arg.CurrentWeapon.clip.Clip2 > 0;
		}
		return false;
	}

	public static bool CanAttack(WeaponEntity weapon, int clientTime)
	{
		return (float)clientTime >= weapon.attack.NextAttackTimer;
	}

	public static bool CanSecondaryAttack(ref CommonWeaponArg arg)
	{
		return (float)arg.ClientTime >= arg.CurrentWeapon.attack.NextSecondaryAttackTimer;
	}

	public static bool CanReload(WeaponEntity weapon)
	{
		if (!weapon.reload.IsStartReload && weapon.clip.CarryClip > 0)
		{
			return weapon.clip.Clip < weapon.basicInfo.Info.MaxClip;
		}
		return false;
	}

	public static bool CanAdvanceFire(BaseWeaponData weapon, int time)
	{
		return false;
	}

	public static bool CanSecondaryFire(WeaponEntity weapon, int time)
	{
		return false;
	}

	public static void ChangeCurrentWeapon(PlayerEntity player, WeaponEntity oldWeapon, WeaponEntity newWeapon, int slotindex)
	{
		if (newWeapon == null)
		{
			_logger.Error("Clear CurrentWeaponEntity");
		}
		else
		{
			if (oldWeapon == newWeapon || (slotindex == 4 && newWeapon.hasBasicInfo && !newWeapon.basicInfo.Data.WeaponName.Equals("c4") && newWeapon.basicInfo.Data.Clip == 0))
			{
				return;
			}
			if (!player.hasLastWeapon)
			{
				player.AddLastWeapon(0, 0);
			}
			if (oldWeapon != null)
			{
				if (oldWeapon.hasBasicInfo && oldWeapon.basicInfo.Info.ChangeWeaponLogic != null)
				{
					oldWeapon.basicInfo.Info.ChangeWeaponLogic.LeaveWeapon(oldWeapon);
				}
				player.lastWeapon.BagId = oldWeapon.slot.BagId;
				if (oldWeapon.slot.Slot == 4)
				{
					if (oldWeapon.slot.Index == 1)
					{
						player.lastWeapon.WeaponId = 6;
					}
					else if (oldWeapon.slot.Index == 2)
					{
						player.lastWeapon.WeaponId = 7;
					}
					else
					{
						player.lastWeapon.WeaponId = 4;
					}
				}
				else
				{
					player.lastWeapon.WeaponId = oldWeapon.slot.Slot;
				}
			}
			if (Contexts.sharedInstance.weapon.lastWeaponEntity != null)
			{
				Contexts.sharedInstance.weapon.lastWeaponEntity.isLastWeapon = false;
			}
			if (oldWeapon != null)
			{
				oldWeapon.isCurrentWeapon = false;
				oldWeapon.isLastWeapon = true;
			}
			if (newWeapon != null)
			{
				if (newWeapon.basicInfo.Info.ChangeWeaponLogic != null)
				{
					newWeapon.basicInfo.Info.ChangeWeaponLogic.EnterWeapon(newWeapon);
				}
				newWeapon.isCurrentWeapon = true;
			}
			if (player.hasThirdPersonUnityObjects)
			{
				player.thirdPersonUnityObjects.Clear();
			}
			if (player.hasFirstPersonUnityObjects)
			{
				player.firstPersonUnityObjects.Clear();
			}
		}
	}

	public static void ChangeCurrentWeapon(PlayerEntity player)
	{
		WeaponEntity weaponAtSlot = GetWeaponAtSlot(player, player.basicInfo.Current.CurrentBagId, player.currentWeapon.Weapon, player.currentWeapon.Index);
		if (weaponAtSlot != null)
		{
			ChangeCurrentWeapon(player, Contexts.sharedInstance.weapon.currentWeaponEntity, weaponAtSlot, player.currentWeapon.Weapon);
		}
	}

	public static void DescClip(WeaponEntity weapon, int num)
	{
		weapon.clip.Clip -= num;
	}

	public static void DescClip2(WeaponEntity weapon, int num)
	{
		weapon.clip.Clip2 -= num;
	}

	public static void DescClip(WeaponEntity weapon)
	{
		DescClip(weapon, weapon.basicInfo.Info.ClipPerShot);
	}

	public static void DescClip2(WeaponEntity weapon)
	{
		DescClip2(weapon, weapon.basicInfo.Info.ClipPerShot);
	}

	public static void Depoly(WeaponEntity currentWeapon)
	{
		currentWeapon.attack.ShotsFired = 0;
		currentWeapon.accuracy.Accuracy = currentWeapon.basicInfo.Info.DefaultAccuracy;
		if (currentWeapon.hasBurstMode)
		{
			currentWeapon.burstMode.BurstModeShotsFired = 0;
		}
	}

	public static void Fire(List<IEntitsFireEffectControl> fires, bool special, string fireParentTranName = null, string fireTranName = null)
	{
		foreach (IEntitsFireEffectControl fire in fires)
		{
			IFireEffectControl fireEffectControl = fire as IFireEffectControl;
			if (fireEffectControl.gameObject.activeInHierarchy && ((fireParentTranName == null && fireTranName == null && fireEffectControl.Fire(special)) || (fireParentTranName != null && fireEffectControl.transform.parent.name.Equals(fireParentTranName) && fireEffectControl.Fire(special)) || (fireTranName != null && fireEffectControl.transform.name.Equals(fireTranName) && fireEffectControl.Fire(special)) || (fireTranName != null && fireEffectControl.transform.name.Replace("(Clone)", "").Equals(fireTranName) && fireEffectControl.Fire(special))))
			{
				break;
			}
		}
	}

	public static void AllFire(List<IEntitsFireEffectControl> fires, bool special)
	{
		foreach (IEntitsFireEffectControl fire in fires)
		{
			(fire as IFireEffectControl).Fire(special);
		}
	}

	public static void AllFire(PlayerEntity entity)
	{
		LeftFire(entity);
		RightFire(entity);
	}

	public static void LeftFire(PlayerEntity entity)
	{
		changeWeaponFireTime(entity);
		if (entity.hasFirstPersonUnityObjects)
		{
			entity.firstPersonUnityObjects.LeftFireRemainTime = 50;
		}
		if (entity.hasThirdPersonUnityObjects)
		{
			entity.thirdPersonUnityObjects.LeftFireRemainTime = 50;
		}
	}

	public static void RightFire(PlayerEntity entity)
	{
		int rightFireRemainTime = 50;
		if (changeWeaponFireTime(entity))
		{
			rightFireRemainTime = 200;
		}
		if (entity.hasFirstPersonUnityObjects)
		{
			entity.firstPersonUnityObjects.RightFireRemainTime = rightFireRemainTime;
		}
		if (entity.hasThirdPersonUnityObjects)
		{
			entity.thirdPersonUnityObjects.RightFireRemainTime = rightFireRemainTime;
		}
	}

	private static bool changeWeaponFireTime(PlayerEntity entity)
	{
		if (entity != null && (entity.currentWeapon.Name == "nova_shotgun" || entity.currentWeapon.Name == "nova_shotgun1" || entity.currentWeapon.Name == "nova_shotgun2"))
		{
			return true;
		}
		return false;
	}

	public static void ClearFireEffect(List<IFireEffectControl> fires)
	{
		foreach (IFireEffectControl fire in fires)
		{
			fire.SetNoUse();
		}
	}

	public static void GetRightFireDict(GameObject weaponObj, List<IEntitsFireEffectControl> fires, bool setGameObjectActive = false)
	{
		GetFireDict(weaponObj, WeaponJoinConstant.RightFireJoins, fires, setGameObjectActive);
	}

	public static void GetLeftFireDict(GameObject weaponObj, List<IEntitsFireEffectControl> fires, bool setGameObjectActive = false)
	{
		GetFireDict(weaponObj, WeaponJoinConstant.LeftFireJoins, fires, setGameObjectActive);
	}

	private static void GetFireDict(GameObject weaponObj, HashSet<IgnoreCaseString> joins, List<IEntitsFireEffectControl> fires, bool setGameObjectActive = false)
	{
		if (weaponObj == null)
		{
			return;
		}
		List<IEntitsFireEffectControl> list = new List<IEntitsFireEffectControl>();
		List<IEntitsFireEffectControl> list2 = new List<IEntitsFireEffectControl>();
		List<IEntitsFireEffectControl> list3 = new List<IEntitsFireEffectControl>();
		IFireEffectControl[] componentsInChildren = weaponObj.GetComponentsInChildren<IFireEffectControl>(includeInactive: true);
		foreach (IFireEffectControl fireEffectControl in componentsInChildren)
		{
			if (fireEffectControl is FireModelMeshEffect)
			{
				FireModelMeshEffect fireModelMeshEffect = fireEffectControl as FireModelMeshEffect;
				_ = fireModelMeshEffect.gameObject.GetComponent<SkinnedMeshRenderer>().rootBone;
				string name = fireModelMeshEffect.gameObject.GetComponent<SkinnedMeshRenderer>().rootBone.name;
				if (joins.Contains(name))
				{
					list.Add(fireModelMeshEffect);
				}
			}
			else if (fireEffectControl is ParticleFireEffect)
			{
				Transform parent = fireEffectControl.gameObject.transform.parent;
				if (setGameObjectActive)
				{
					fireEffectControl.gameObject.SetActive(value: true);
				}
				string name2 = parent.name;
				string name3 = parent.parent.name;
				if (joins.Contains(name3) || joins.Contains(name2))
				{
					list3.Add(fireEffectControl);
				}
				else if (name2.Equals("leftdefaultqkhh", StringComparison.OrdinalIgnoreCase) || name2.Equals("rightdefaultqkhh", StringComparison.OrdinalIgnoreCase))
				{
					list2.Add(fireEffectControl);
				}
			}
		}
		fires.AddRange(list3);
		fires.AddRange(list);
		fires.AddRange(list2);
	}

	public static void GetSkins(GameObject weaponObj, Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins)
	{
		if (weaponObj == null)
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren = weaponObj.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		for (int num = componentsInChildren.Length - 1; num >= 0; num--)
		{
			Transform[] bones = componentsInChildren[num].bones;
			foreach (Transform transform in bones)
			{
				string text = transform.name.Split(' ')[0];
				if (transform.name.Equals("bingdongjian_1") || transform.name.Equals("chuantoujian_1"))
				{
					text = transform.name.Split('_')[0];
				}
				if (WeaponJoinConstant.JoinsInfo.ContainsKey(text))
				{
					skins[text] = componentsInChildren[num];
					break;
				}
			}
		}
	}

	public static void GetParticles(GameObject weaponObj, ref IPaticlePrefabInstancecs[] skins)
	{
		if (weaponObj == null)
		{
			return;
		}
		skins = weaponObj.GetComponentsInChildren<IPaticlePrefabInstancecs>(includeInactive: true);
		for (int num = skins.Length - 1; num >= 0; num--)
		{
			PaticlePrefabInstancecs paticlePrefabInstancecs = skins[num] as PaticlePrefabInstancecs;
			if (paticlePrefabInstancecs.OriginalList == null)
			{
				Renderer[] componentsInChildren = paticlePrefabInstancecs.getGameObject().GetComponentsInChildren<Renderer>(includeInactive: true);
				if (componentsInChildren.Length != 0)
				{
					paticlePrefabInstancecs.OriginalList = new List<RecordOriginal>(componentsInChildren.Length);
					Renderer[] array = componentsInChildren;
					foreach (Renderer render in array)
					{
						paticlePrefabInstancecs.OriginalList.Add(new RecordOriginal(render));
					}
				}
			}
		}
	}

	public static void GetParticles(GameObject weaponObj, Dictionary<IParticleKey, IPaticlePrefabInstancecs> skins)
	{
		if (weaponObj == null)
		{
			return;
		}
		PaticlePrefabInstancecs[] componentsInChildren = weaponObj.GetComponentsInChildren<PaticlePrefabInstancecs>(includeInactive: true);
		for (int num = componentsInChildren.Length - 1; num >= 0; num--)
		{
			PaticlePrefabInstancecs paticlePrefabInstancecs = componentsInChildren[num];
			if (!(paticlePrefabInstancecs.instance == null))
			{
				ParticleKey particleKey = new ParticleKey(paticlePrefabInstancecs.gameObject.name, paticlePrefabInstancecs.instance.name, paticlePrefabInstancecs.AnimationEffectConfig);
				if (!skins.ContainsKey(particleKey))
				{
					skins.Add(particleKey, paticlePrefabInstancecs);
					if (paticlePrefabInstancecs.OriginalList == null)
					{
						Renderer[] componentsInChildren2 = paticlePrefabInstancecs.gameObject.GetComponentsInChildren<Renderer>(includeInactive: true);
						if (componentsInChildren2.Length != 0)
						{
							paticlePrefabInstancecs.OriginalList = new List<RecordOriginal>(componentsInChildren2.Length);
							Renderer[] array = componentsInChildren2;
							foreach (Renderer render in array)
							{
								paticlePrefabInstancecs.OriginalList.Add(new RecordOriginal(render));
							}
						}
					}
				}
				else
				{
					paticlePrefabInstancecs.SetInsActive(flag: false);
				}
			}
		}
	}

	public static void SetWeaponColor(WeaponColorData colorData, SkinnedMeshRenderer[] renderers)
	{
		if (colorData == null)
		{
			return;
		}
		Color value = new Color(colorData.R, colorData.G, colorData.B, colorData.A);
		Color value2 = new Color(colorData.R1, colorData.G1, colorData.B1, colorData.A1);
		if (Mathf.Approximately(value2.r, 0f) && Mathf.Approximately(value2.g, 0f) && Mathf.Approximately(value2.b, 0f) && Mathf.Approximately(value2.a, 0f))
		{
			value2 = Color.white;
		}
		int index = colorData.Index;
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in renderers)
		{
			Material[] materials = skinnedMeshRenderer.materials;
			MaterialCache materialCache = skinnedMeshRenderer.gameObject.GetComponent<MaterialCache>();
			if (materialCache == null)
			{
				materialCache = skinnedMeshRenderer.gameObject.AddComponent<MaterialCache>();
				materialCache.GetCache();
			}
			Material[] array = materials;
			foreach (Material material in array)
			{
				if (index == 0)
				{
					if (material.shader.name.Contains("_SkinColor"))
					{
						material.shader = Shader.Find(material.shader.name.Replace("_SkinColor", ""));
					}
				}
				else
				{
					if (!material.shader.name.Contains("_SkinColor"))
					{
						Shader shader = Shader.Find(material.shader.name + "_SkinColor");
						if (shader != null)
						{
							material.shader = shader;
						}
						else
						{
							_logger.LogErrorFormat("Find no shader {0}", material.shader.name + "_SkinColor");
						}
					}
					material.SetTexture("_SkinTex", SingletonInstance<WeaponSkinColorLoader>.Instance.Skins[index - 1]);
					material.SetColor("_SkinColor", value2);
				}
				material.SetColor("_WeaponColor", value);
				int value3 = 0;
				if (materialCache.RenderQueues.TryGetValue(material, out value3))
				{
					if (value.a < 1f || (value2.a < 1f && index > 0))
					{
						material.renderQueue = value3 + 1;
					}
					else
					{
						material.renderQueue = value3;
					}
				}
				bool value4 = false;
				if (materialCache.Zwrites.TryGetValue(material, out value4) && value4)
				{
					material.SetInt("_ZWrite", (!(value.a < 1f)) ? 1 : 0);
				}
			}
		}
	}

	public static void SetDelayAttackSlashTime(ref CommonWeaponArg arg, int delay)
	{
		if (arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo)
		{
			(arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo).DelayAttackSlashTime = delay;
		}
		if (arg.CurrentWeapon.basicInfo.Info is RifleMeleeWeaponInfo)
		{
			(arg.CurrentWeapon.basicInfo.Info as RifleMeleeWeaponInfo).DelayAttackSlashTime = delay;
		}
		if (arg.CurrentWeapon.basicInfo.Info is ShotGunMeleeWeaponInfo)
		{
			(arg.CurrentWeapon.basicInfo.Info as ShotGunMeleeWeaponInfo).DelayAttackSlashTime = delay;
		}
	}

	public static void SetDelayAttackSlashTime2(ref CommonWeaponArg arg, int delay)
	{
		if (arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo)
		{
			(arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo).DelayAttackSlashTime2 = delay;
		}
		if (arg.CurrentWeapon.basicInfo.Info is RifleMeleeWeaponInfo)
		{
			(arg.CurrentWeapon.basicInfo.Info as RifleMeleeWeaponInfo).DelayAttackSlashTime2 = delay;
		}
		if (arg.CurrentWeapon.basicInfo.Info is ShotGunMeleeWeaponInfo)
		{
			(arg.CurrentWeapon.basicInfo.Info as ShotGunMeleeWeaponInfo).DelayAttackSlashTime2 = delay;
		}
	}

	public static void SetDelayAttackStabTime(ref CommonWeaponArg arg, int delay)
	{
		if (arg.CurrentWeapon.basicInfo.Info is KnifeWeaponInfo)
		{
			(arg.CurrentWeapon.basicInfo.Info as KnifeWeaponInfo).DelayAttackStabTime = delay;
		}
		if (arg.CurrentWeapon.basicInfo.Info is RifleMeleeWeaponInfo)
		{
			(arg.CurrentWeapon.basicInfo.Info as RifleMeleeWeaponInfo).DelayAttackStabTime = delay;
		}
		if (arg.CurrentWeapon.basicInfo.Info is ShotGunMeleeWeaponInfo)
		{
			(arg.CurrentWeapon.basicInfo.Info as ShotGunMeleeWeaponInfo).DelayAttackStabTime = delay;
		}
	}

	public static string GetAssetBundleName(string soundName)
	{
		if (soundName.EndsWith("_sec_fire"))
		{
			soundName = soundName.Remove(soundName.Length - "_sec_fire".Length);
		}
		else if (soundName.EndsWith("_fire"))
		{
			soundName = soundName.Remove(soundName.Length - "_fire".Length);
		}
		else if (soundName.EndsWith("_fire3"))
		{
			soundName = soundName.Remove(soundName.Length - "_fire3".Length);
		}
		else if (soundName.EndsWith("_fire4"))
		{
			soundName = soundName.Remove(soundName.Length - "_fire4".Length);
		}
		else if (soundName.EndsWith("_change"))
		{
			soundName = soundName.Remove(soundName.Length - "_change".Length);
		}
		else if (soundName.EndsWith("_change2"))
		{
			soundName = soundName.Remove(soundName.Length - "_change2".Length);
		}
		else if (soundName.EndsWith("_raise"))
		{
			soundName = soundName.Remove(soundName.Length - "_raise".Length);
		}
		else if (soundName.EndsWith("_raise2"))
		{
			soundName = soundName.Remove(soundName.Length - "_raise2".Length);
		}
		else if (soundName.EndsWith("_reload"))
		{
			soundName = soundName.Remove(soundName.Length - "_reload".Length);
		}
		else if (soundName.EndsWith("_reload2"))
		{
			soundName = soundName.Remove(soundName.Length - "_reload2".Length);
		}
		else if (soundName.EndsWith("_skill"))
		{
			soundName = soundName.Remove(soundName.Length - "_skill".Length);
		}
		else if (soundName.EndsWith("_skill2"))
		{
			soundName = soundName.Remove(soundName.Length - "_skill2".Length);
		}
		else if (soundName.EndsWith("_skill3"))
		{
			soundName = soundName.Remove(soundName.Length - "_skill3".Length);
		}
		return soundName;
	}

	public static string GetAssetMp3BundleName(string head, string path)
	{
		string text = path.Replace("Assets/Res/Assets/sound/weapon/", "").Replace(".mp3", "");
		if (text.EndsWith("_sec_fire"))
		{
			text = text.Remove(text.Length - "_sec_fire".Length);
		}
		else if (text.EndsWith("_fire"))
		{
			text = text.Remove(text.Length - "_fire".Length);
		}
		else if (text.EndsWith("_fire3"))
		{
			text = text.Remove(text.Length - "_fire3".Length);
		}
		else if (text.EndsWith("_fire4"))
		{
			text = text.Remove(text.Length - "_fire4".Length);
		}
		else if (text.EndsWith("_change"))
		{
			text = text.Remove(text.Length - "_change".Length);
		}
		else if (text.EndsWith("_change2"))
		{
			text = text.Remove(text.Length - "_change2".Length);
		}
		else if (text.EndsWith("_raise"))
		{
			text = text.Remove(text.Length - "_raise".Length);
		}
		else if (text.EndsWith("_raise2"))
		{
			text = text.Remove(text.Length - "_raise2".Length);
		}
		else if (text.EndsWith("_reload"))
		{
			text = text.Remove(text.Length - "_reload".Length);
		}
		else if (text.EndsWith("_reload2"))
		{
			text = text.Remove(text.Length - "_reload2".Length);
		}
		else if (text.EndsWith("_skill"))
		{
			text = text.Remove(text.Length - "_skill".Length);
		}
		else if (text.EndsWith("_skill2"))
		{
			text = text.Remove(text.Length - "_skill2".Length);
		}
		else if (text.EndsWith("_skill3"))
		{
			text = text.Remove(text.Length - "_skill3".Length);
		}
		else if (text.EndsWith("_skill4"))
		{
			text = text.Remove(text.Length - "_skill4".Length);
		}
		else if (text.EndsWith("_1"))
		{
			text = text.Remove(text.Length - "_1".Length);
		}
		else if (text.StartsWith("mechbomberman"))
		{
			text = "mechbomberman";
		}
		else if (text.StartsWith("mechfar"))
		{
			text = "mechfar";
		}
		else if (text.StartsWith("mechnear"))
		{
			text = "mechnear";
		}
		else if (text.StartsWith("mechpredator"))
		{
			text = "mechpredator";
		}
		return head + text;
	}

	public static bool GetThirdFireTransform(PlayerEntity player, out Transform result, bool isLeftFire = false)
	{
		if (player.hasThirdPersonUnityObjects)
		{
			Dictionary<IgnoreCaseString, Transform> allTransforms = player.thirdPersonUnityObjects.AllTransforms;
			if ((player.currentWeapon.WeaponInfo as IWeaponInfo).AttackType == AttackType.ShotGun)
			{
				if (allTransforms.TryGetValue(new IgnoreCaseString("weapon_left_particle_fire_effect1"), out result))
				{
					return true;
				}
			}
			else if (player.currentWeapon.WeaponInfo.Name.Contains("pistol_frozen_air") || player.currentWeapon.WeaponInfo.Name.Contains("spike_rifle") || player.currentWeapon.WeaponInfo.Name.Contains("rainbow_pistol") || player.currentWeapon.WeaponInfo.Name.Contains("flying_shuttle") || player.currentWeapon.WeaponInfo.Name.Contains("trans_machinegun"))
			{
				if (allTransforms.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect"), out result))
				{
					return true;
				}
			}
			else if (player.currentWeapon.WeaponInfo.Name.Contains("r28rifle"))
			{
				if (allTransforms.TryGetValue(new IgnoreCaseString("fire"), out result))
				{
					return true;
				}
			}
			else if (player.currentWeapon.WeaponInfo.Name.Contains("shotgun_laser"))
			{
				if (allTransforms.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect1"), out result))
				{
					return true;
				}
			}
			else if (player.currentWeapon.WeaponInfo.Name.Contains("dawn_light_shotgun"))
			{
				if (allTransforms.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect1"), out result))
				{
					return true;
				}
			}
			else if (player.currentWeapon.WeaponInfo.Name.Contains("thunder_scepter"))
			{
				if (allTransforms.TryGetValue(new IgnoreCaseString("weapon_left_particle_effect"), out result))
				{
					return true;
				}
			}
			else if (player.currentWeapon.WeaponInfo.Name.Contains("parasitic_sniper") || player.currentWeapon.WeaponInfo.Name.Contains("parasitic_sniper1") || player.currentWeapon.WeaponInfo.Name.Contains("parasitic_sniper2") || player.currentWeapon.WeaponInfo.Name.Contains("block_dragon_pistol"))
			{
				if (allTransforms.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect"), out result))
				{
					return true;
				}
			}
			else if (player.currentWeapon.WeaponInfo.Name.Contains("mech_king"))
			{
				if (player.thirdPersonUnityObjects.AllPlayerTransforms.TryGetValue(new IgnoreCaseString("fire"), out result))
				{
					return true;
				}
			}
			else if (player.currentWeapon.WeaponInfo.Name.Contains("phantom_smg"))
			{
				Dictionary<IgnoreCaseString, Transform> allTransforms2 = player.thirdPersonUnityObjects.AllTransforms;
				if (isLeftFire)
				{
					if (allTransforms2.TryGetValue(new IgnoreCaseString("weapon_left_particle_fire_effect"), out result))
					{
						return true;
					}
				}
				else if ((player.GetCurrentWeaponEffectLevel() & 0x10) > 0)
				{
					if (allTransforms2.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect"), out result))
					{
						return true;
					}
				}
				else if (allTransforms2.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect1"), out result))
				{
					return true;
				}
			}
			else
			{
				if (allTransforms.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect"), out result))
				{
					return true;
				}
				if (allTransforms.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect1"), out result))
				{
					return true;
				}
				if (allTransforms.TryGetValue(new IgnoreCaseString("weapon_dummy_particle_fire_effect"), out result))
				{
					return true;
				}
				if (allTransforms.TryGetValue(new IgnoreCaseString("weapon_left_particle_fire_effect1"), out result))
				{
					return true;
				}
			}
		}
		result = null;
		return false;
	}

	public static bool GetViewFireTransform(PlayerEntity player, int hand, out Transform result)
	{
		if (player.hasFirstPersonUnityObjects)
		{
			Dictionary<IgnoreCaseString, Transform> allTransforms = player.firstPersonUnityObjects.AllTransforms;
			if (player.currentWeapon.WeaponInfo.Name.Contains("shotgun_laser") && allTransforms.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect1"), out result))
			{
				return true;
			}
			if ((player.currentWeapon.WeaponInfo.Name.Contains("fireofjustice") || player.currentWeapon.WeaponInfo.Name.Contains("fireofjustice1") || player.currentWeapon.WeaponInfo.Name.Contains("fireofjustice2") || player.currentWeapon.WeaponInfo.Name.Contains("rainbow_pistol")) && allTransforms.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect"), out result))
			{
				return true;
			}
			if (player.currentWeapon.WeaponInfo.Name.Contains("mech_king") && player.firstPersonUnityObjects.AllHeadTransforms.TryGetValue(new IgnoreCaseString("fire"), out result))
			{
				return true;
			}
			if (player.currentWeapon.WeaponInfo.Name.Contains("phantom_smg") && hand == 1 && allTransforms.TryGetValue(new IgnoreCaseString("weapon_left_particle_fire_effect"), out result))
			{
				return true;
			}
			if (hand != 0 || !allTransforms.TryGetValue(new IgnoreCaseString("fire2"), out result))
			{
				allTransforms.TryGetValue(new IgnoreCaseString("fire"), out result);
			}
			if (result == null && !allTransforms.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect"), out result) && !allTransforms.TryGetValue(new IgnoreCaseString("weapon_particle_fire_effect1"), out result) && !allTransforms.TryGetValue(new IgnoreCaseString("weapon_dummy_particle_fire_effect"), out result) && !allTransforms.TryGetValue(new IgnoreCaseString("weapon_left_particle_fire_effect1"), out result))
			{
				return false;
			}
			return result != null;
		}
		result = null;
		return false;
	}

	public static bool GetThirdLinkTransform(PlayerEntity player, out Transform result, string jointName)
	{
		if (player.hasThirdPersonUnityObjects)
		{
			if (player.thirdPersonUnityObjects.AllTransforms.TryGetValue(new IgnoreCaseString(jointName), out result))
			{
				return true;
			}
			return result != null;
		}
		result = null;
		return false;
	}

	public static bool GetViewLinkTransform(PlayerEntity player, out Transform result, string jointName)
	{
		if (player.hasFirstPersonUnityObjects)
		{
			if (player.firstPersonUnityObjects.AllTransforms.TryGetValue(new IgnoreCaseString(jointName), out result))
			{
				return true;
			}
			return result != null;
		}
		result = null;
		return false;
	}

	public static bool HasLeftAnim(IEntitsWeaponInfo iWeaponInfo)
	{
		IWeaponInfo weaponInfo = iWeaponInfo as IWeaponInfo;
		if (weaponInfo.AttackType == AttackType.GatlingDouRage2 || weaponInfo.AttackType == AttackType.DoubleRifle || weaponInfo.AttackType == AttackType.StormHeroes || weaponInfo.AttackType == AttackType.RpgRedflash || weaponInfo.AttackType == AttackType.MetalStorm || weaponInfo.AttackType == AttackType.InfiniteHand1 || weaponInfo.AttackType == AttackType.InfiniteHand1Change2)
		{
			return true;
		}
		PredicationConfig predicationConfig = PredicationConfigFactory.Instance.GetPredicationConfig(weaponInfo.Name);
		if (predicationConfig != null && WeaponConfigUtils.RealDouble(predicationConfig.GetAttackType()))
		{
			return true;
		}
		return false;
	}

	public static void ResetDelayFire(WeaponEntity currentWeapon)
	{
		if (currentWeapon.hasDelayAttack)
		{
			currentWeapon.delayAttack.CallBack = null;
			currentWeapon.delayAttack.DelayFireRemain = 0;
		}
	}

	public static void ResetReload(WeaponEntity currentWeapon)
	{
		if (currentWeapon.hasReload)
		{
			currentWeapon.reload.IsStartReload = false;
			currentWeapon.reload.IsStartReload2 = false;
		}
	}

	public static void ReloadClipRight(WeaponEntity currentWeapon)
	{
		int clip = currentWeapon.clip.Clip;
		int maxClip = currentWeapon.basicInfo.Info.MaxClip;
		int carryClip = currentWeapon.clip.CarryClip;
		int num = 0;
		if (clip < maxClip)
		{
			if (carryClip + clip > maxClip)
			{
				currentWeapon.clip.Clip = maxClip;
				num = maxClip - clip;
			}
			else
			{
				currentWeapon.clip.Clip = carryClip + clip;
				num = carryClip;
			}
		}
		currentWeapon.clip.CarryClip -= num;
	}

	public static void ReloadClipLeft(WeaponEntity currentWeapon)
	{
		int clip = currentWeapon.clip.Clip2;
		int maxClip = currentWeapon.basicInfo.Info.MaxClip2;
		int carryClip = currentWeapon.clip.CarryClip2;
		int num = 0;
		if (clip < maxClip)
		{
			if (carryClip + clip > maxClip)
			{
				currentWeapon.clip.Clip2 = maxClip;
				num = maxClip - clip;
			}
			else
			{
				currentWeapon.clip.Clip2 = carryClip + clip;
				num = carryClip;
			}
		}
		currentWeapon.clip.CarryClip2 -= num;
	}

	public static bool IsNormalWeaponForTest(string weaponName)
	{
		switch (weaponName)
		{
		case "rpgcaptaionyc":
		case "rpgcaptaionjz":
		case "botweapon":
		case "c4":
		case "pvegatling_boss1021":
		case "m202flash_rpg":
		case "burst_assault1":
		case "burst_assault":
		case "fire_demon_rpg":
		case "fire_demon_rpg1":
		case "fire_demon_rpg2":
		case "justice_from_above":
		case "rpg_7_2":
		case "rpg_7_1":
		case "rpg_7":
		case "skin_carbon_fiber_show":
		case "smaw_rpg":
		case "m249_howitzer":
		case "m249_howitzer_huawei":
		case "crossbow_black":
		case "crossbow_black1":
		case "crossbow_black2":
		case "rifle_opticor":
		case "s17巅峰王者":
			return false;
		default:
			return true;
		}
	}

	public static bool IsEmptyWeapon(string weaponName)
	{
		if (weaponName == "fist")
		{
			return true;
		}
		return false;
	}

	public static bool IsSpecialWeapon(string weaponName)
	{
		switch (weaponName)
		{
		case "death":
		case "doun":
		case "hero":
		case "phantom":
		case "twine":
		case "petrified":
		case "howitzer":
		case "herowoman":
		case "howitzerwoman":
		case "queen":
		case "death_ray":
		case "metalman":
		case "kingslayer":
		case "mechfar":
		case "mechfar2":
		case "mechnear":
		case "mechbomberman":
		case "nurse":
		case "snaker":
		case "snake_doun":
		case "cat":
		case "chicken":
		case "pig":
		case "doun_master":
		case "phantom_master":
		case "polypideMonther":
		case "pandoraMonther":
		case "hero_close":
		case "herowoman_close":
		case "hero_gun":
		case "herowoman_gun":
		case "mech_king":
		case "pandoraMonther_baigu":
		case "kunlungongzhu":
		case "qingniujing":
		case "qingniujing_mother":
			return true;
		default:
			return false;
		}
	}

	public static bool IsBioKnifeKill(int weaponType, string weaponName, bool specialKill)
	{
		GameRuleContext gameRule = Contexts.sharedInstance.gameRule;
		if (weaponType != 2)
		{
			return false;
		}
		if (!gameRule.currentRule.Rule.IsBio())
		{
			return false;
		}
		if (specialKill && weaponName == "double_scythe")
		{
			return false;
		}
		if (weaponName == "howitzer" || weaponName == "howitzerwoman")
		{
			return false;
		}
		if (!PlayerCareerConstantUtility.IsHumanity(UiIEventCondition.Get_cameraOwnerData_Career()) && !PlayerCareerUtil.IsAnimal(UiIEventCondition.Get_cameraOwnerData_Career()))
		{
			return false;
		}
		return true;
	}

	private static bool HideThirdLeftForeArm(string weaponName, int currentWeaponEffectLevel)
	{
		switch (weaponName)
		{
		case "infinite_hand1_change_2":
			if (((uint)currentWeaponEffectLevel & 2u) != 0)
			{
				goto default;
			}
			goto case "horror_claw";
		default:
			if ((!(weaponName == "infinite_hand2_change_2") || ((uint)currentWeaponEffectLevel & 2u) != 0) && (!(weaponName == "infinite_hand3_change_2") || ((uint)currentWeaponEffectLevel & 2u) != 0) && !(weaponName == "mantis_arm") && !(weaponName == "shield_pistol"))
			{
				return false;
			}
			goto case "horror_claw";
		case "horror_claw":
		case "infinite_hand1":
		case "infinite_hand2":
		case "infinite_hand3":
		case "infinite_hand1_change_1":
		case "infinite_hand2_change_1":
		case "infinite_hand3_change_1":
			return true;
		}
	}

	private static bool HideThirdRightForeArm(string weaponName)
	{
		switch (weaponName)
		{
		case "horror_claw":
		case "infinite_hand1":
		case "infinite_hand1_change_1":
		case "infinite_hand1_change_2":
		case "infinite_hand2":
		case "infinite_hand2_change_1":
		case "infinite_hand2_change_2":
		case "infinite_hand3":
		case "infinite_hand3_change_1":
		case "infinite_hand3_change_2":
		case "mantis_arm":
		case "shield_pistol":
			return true;
		default:
			return false;
		}
	}

	private static bool HideThirdHand(string weaponName)
	{
		switch (weaponName)
		{
		case "horror_claw":
		case "infinite_hand1":
		case "infinite_hand1_change_1":
		case "infinite_hand1_change_2":
		case "infinite_hand2":
		case "infinite_hand2_change_1":
		case "infinite_hand2_change_2":
		case "infinite_hand3":
		case "infinite_hand3_change_1":
		case "infinite_hand3_change_2":
		case "shield_pistol":
			return true;
		default:
			return false;
		}
	}

	public static bool OnlyHideRightHand(string weaponName)
	{
		switch (weaponName)
		{
		case "shield_cannon":
		case "shield_cannon1":
		case "shield_cannon2":
			return true;
		default:
			return false;
		}
	}

	public static void SetHandBoneScale(ISjAnimatior animator, float scale, string weaponName = null)
	{
		if (OnlyHideRightHand(weaponName))
		{
			Transform bone = animator.GetBone("bip01_r_hand");
			if (bone != null)
			{
				bone.localScale = UnityEngine.Vector3.one * scale;
			}
			return;
		}
		Transform bone2 = animator.GetBone("bip01_l_hand");
		if (bone2 != null)
		{
			bone2.localScale = UnityEngine.Vector3.one * scale;
		}
		Transform bone3 = animator.GetBone("bip01_r_hand");
		if (bone3 != null)
		{
			bone3.localScale = UnityEngine.Vector3.one * scale;
		}
	}

	public static void ResetHandScale(ISjAnimatior animator, float scale)
	{
		List<Transform> allBones = animator.GetAllBones();
		if (allBones == null)
		{
			return;
		}
		foreach (Transform item in allBones)
		{
			item.localScale = UnityEngine.Vector3.one * scale;
		}
		ListPool<Transform>.Release(allBones);
	}

	public static bool IsSpecial(string weaponName)
	{
		switch (weaponName)
		{
		case "infinite_hand1":
		case "infinite_hand1_change_1":
		case "infinite_hand1_change_2":
		case "infinite_hand2":
		case "infinite_hand2_change_1":
		case "infinite_hand2_change_2":
		case "infinite_hand3":
		case "infinite_hand3_change_1":
		case "infinite_hand3_change_2":
		case "shield_pistol":
			return true;
		default:
			return false;
		}
	}

	public static bool IsSpecialChange2(string weaponName)
	{
		switch (weaponName)
		{
		case "infinite_hand1_change_2":
		case "infinite_hand2_change_2":
		case "infinite_hand3_change_2":
			return true;
		default:
			return false;
		}
	}

	public static void SetHandBoneScale(ISjAnimatior animator, float scale, string weaponName, int effectlv)
	{
		if (HideThirdLeftForeArm(weaponName, effectlv))
		{
			Transform bone = animator.GetBone("Bip01_L_Forearm");
			if (bone != null)
			{
				bone.localScale = UnityEngine.Vector3.one * scale;
			}
		}
		if (HideThirdRightForeArm(weaponName))
		{
			Transform bone2 = animator.GetBone("Bip01_R_Forearm");
			if (bone2 != null)
			{
				bone2.localScale = UnityEngine.Vector3.one * scale;
			}
		}
		else if (HideThirdHand(weaponName))
		{
			Transform bone3 = animator.GetBone("bip01_l_hand");
			if (bone3 != null)
			{
				bone3.localScale = UnityEngine.Vector3.one * scale;
			}
			Transform bone4 = animator.GetBone("bip01_r_hand");
			if (bone4 != null)
			{
				bone4.localScale = UnityEngine.Vector3.one * scale;
			}
		}
	}

	public static void CopyToWeaponComponent(CurrentWeaponComponent comp, PlayerEntityData playerEntityData)
	{
		comp.Weapon = playerEntityData.CurrentWeapon;
		comp.Index = playerEntityData.CurrentWeaponIndex;
		comp.Name = playerEntityData.CurrentWeaponName;
		comp.Level = playerEntityData.CurrentWeaponLevel;
		comp.SkinName = playerEntityData.CurrentWeaponSkinName;
		comp.Worn = playerEntityData.CurrentWeaponWorn;
		comp.QuenchId = playerEntityData.CurrentWeaponQuenchId;
		comp.WeaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(comp.Name);
	}

	public static void CopyToQianglingWeaponComponent(QianglingWeaponComponent comp, PlayerEntityData playerEntityData)
	{
		foreach (QianglingWeaponData qianglingWeapon in playerEntityData.QianglingWeaponList)
		{
			comp.weaponList.Add(qianglingWeapon);
			comp.WeaponInfoList.Add(WeaponInfoFactory.Instance.GetWeaponInfo(qianglingWeapon.CodeName));
		}
	}

	public static void CopyToWeaponComponent(CurrentWeaponComponent comp, WeaponEntity weaponEntity)
	{
		comp.Weapon = weaponEntity.slot.Slot;
		comp.Index = weaponEntity.slot.Index;
		comp.Name = weaponEntity.basicInfo.Data.WeaponName;
		comp.Level = weaponEntity.basicInfo.Data.Level;
		comp.WeaponInfo = weaponEntity.basicInfo.Info;
		comp.SkinName = weaponEntity.basicInfo.Data.WeaponSkinName;
		comp.Worn = weaponEntity.basicInfo.Data.WeaponWorn;
		comp.QuenchId = weaponEntity.basicInfo.Data.QuenchId;
	}

	public static bool IsParticleFireEffect(string name)
	{
		switch (name)
		{
		case "weapon_particle_fire_effect":
		case "weapon_particle_fire_effect1":
		case "weapon_left_particle_fire_effect":
		case "weapon_left_particle_fire_effect1":
			return true;
		default:
			return false;
		}
	}

	public static void UseInputShader(PlayerEntity player, string shaderName)
	{
		SkinnedMeshRenderer[] handSkinnedMeshRenderers = player.firstPersonUnityObjects.HandSkinnedMeshRenderers;
		for (int i = 0; i < handSkinnedMeshRenderers.Length; i++)
		{
			handSkinnedMeshRenderers[i].sharedMaterial.shader = Shader.Find(shaderName);
		}
		handSkinnedMeshRenderers = player.firstPersonUnityObjects.WeaponSkinnedMeshRenderers;
		for (int i = 0; i < handSkinnedMeshRenderers.Length; i++)
		{
			handSkinnedMeshRenderers[i].sharedMaterial.shader = Shader.Find(shaderName);
		}
	}

	public static string GetWeaponAnimConvertHelper(IEntitsWeaponInfo weaponInfo, string weaponName)
	{
		if (!RuleUtilty.EnableAvater())
		{
			return weaponName;
		}
		switch (weaponInfo.WeaponType)
		{
		case 1:
		case 5:
			return "buqiang";
		case 10:
			return "jiqiang";
		case 3:
			return "shoulei";
		case 0:
			return "shouqiang";
		case 12:
			return "shuangchichongfeng";
		case 6:
			return "xiandanqiang";
		case 2:
			return "kongshou";
		default:
			return weaponName;
		}
	}

	public static bool GetWeaponSuperCross(string weaponName)
	{
		if (weaponName == "vinesheart_sniper")
		{
			return true;
		}
		return false;
	}
}
