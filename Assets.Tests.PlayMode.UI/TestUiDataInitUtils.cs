using System.Collections.Generic;
using Assets.Sources.Chat;
using Assets.Sources.Components.Chat;
using Assets.Sources.Components.Interface.Info.Chat;
using Assets.Sources.Info.Career;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Utils.ComponentInit;
using NetData;
using SSJJAnim.AnimState;
using SSJJBase.Obscure;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI;

public static class TestUiDataInitUtils
{
	public static void InitHpProgressData()
	{
	}

	public static void InitGunKingTeamScoreData()
	{
		Contexts.sharedInstance.gameRule.SetGunKingTeamScoreData(0, 0, 0, 0, 0, 0, "", 0);
	}

	public static void InitKillPlayerInfo()
	{
	}

	public static void InitChatHistroy()
	{
		Contexts.sharedInstance.chat.SetChatJobHistroy(default(ChatInputData), new Queue<string>(), new MarkGroup<IChatHistroyData>(), new MarkGroup<IChatHistroyData>(), new MarkGroup<IChatHistroyData>(), new MarkGroup<IChatHononaryData>());
	}

	public static void InitBio2SkillLvUpData()
	{
		Contexts.sharedInstance.gameRule.SetBio2SkillLvUpData(0, 0, 0, 0);
	}

	public static void CreateGameEntity()
	{
		Contexts sharedInstance = Contexts.sharedInstance;
		for (int i = 0; i < 16; i++)
		{
			int num = i + 1;
			PlayerEntity playerEntity = sharedInstance.player.CreateEntity();
			playerEntity.AddEntityId(num);
			if (i == 0)
			{
				playerEntity.isMyPlayer = true;
			}
			string text = "default";
			PlayerEntityData playerEntityData = new PlayerEntityData();
			playerEntityData.PlayerName = "Player" + (i + 1);
			playerEntityData.Id = num;
			playerEntityData.Career = text;
			playerEntityData.BackAccessory = "hellsnake";
			playerEntityData.BackWeapon = "ak47_g";
			playerEntityData.Team = 1;
			playerEntity.AddBasicInfo(playerEntityData, playerEntityData, null, new DefaultCareerInfo(text), null, 0, newIsPart: false, 0.0);
		}
	}

	public static PlayerEntity CreateOtherPlayerEntity()
	{
		Contexts sharedInstance = Contexts.sharedInstance;
		string text = "police";
		int num = 1001;
		string text2 = "ak47";
		Vector3 vector = new Vector3(0f, 100f, 0f);
		PlayerEntityData playerEntityData = new PlayerEntityData
		{
			PlayerName = "其他名字",
			Id = num,
			Career = text,
			BackAccessory = "hellsnake",
			BackWeapon = "ak47_g",
			Team = 1,
			CurrentBagId = 1,
			CurrentWeapon = 0,
			CurrentWeaponName = text2,
			CurrentHandName = "man",
			X = vector.x,
			Y = vector.y,
			Z = vector.z,
			Velocity = new Vector3DData()
		};
		PlayerEntity playerEntity = sharedInstance.player.CreateEntity();
		playerEntity.AddEntityId(num);
		playerEntity.AddBasicInfo(playerEntityData, playerEntityData, null, new DefaultCareerInfo(text), null, 0, newIsPart: false, 0.0);
		playerEntity.AddFpos(new Change());
		PlayerEntityUtility.AddMove(playerEntity, Contexts.sharedInstance.weapon);
		playerEntity.AddTorseAnim(new TorseAnimStateInfo(15), 0, 2000, 0, 0, null, new Dictionary<string, float>(), newSpecialMode: false);
		playerEntity.AddViewAnim(1000, 0, 1000, 0, 100, 0, 1f, 1f, newIsBowing: false, 0, null, new ViewAnimStateInfo(15), null, null);
		playerEntity.AddCurrentWeapon(0, 0, text2, 0, WeaponInfoFactory.Instance.GetWeaponInfo(text2), newIsLock: false, newCanDuck: false, null, 0f, 0);
		PlayerEntityUtility.AddClientTime(playerEntity);
		PlayerEntityUtility.AddNormalTrace(playerEntity);
		PlayerEntityUtility.AddState(playerEntity);
		PlayerEntityUtility.AddSkill(playerEntity);
		return playerEntity;
	}

	public static PlayerEntity CreateMyPlayerEntity()
	{
		Contexts sharedInstance = Contexts.sharedInstance;
		string text = "police";
		int num = 1000;
		string text2 = "ak47";
		Vector3 vector = new Vector3(0f, 100f, 0f);
		PlayerEntityData playerEntityData = new PlayerEntityData
		{
			PlayerName = "忘记名字",
			Id = num,
			Career = text,
			BackAccessory = "hellsnake",
			BackWeapon = "ak47_g",
			Team = 1,
			CurrentBagId = 1,
			CurrentWeapon = 0,
			CurrentWeaponName = text2,
			CurrentHandName = "man",
			X = vector.x,
			Y = vector.y,
			Z = vector.z,
			Velocity = new Vector3DData()
		};
		PlayerEntity playerEntity = sharedInstance.player.CreateEntity();
		playerEntity.isMyPlayer = true;
		playerEntity.isCameraOwner = true;
		playerEntity.isPrediction = true;
		playerEntity.isFirstPersonView = true;
		playerEntity.AddEntityId(num);
		playerEntity.AddBasicInfo(playerEntityData, playerEntityData, null, new DefaultCareerInfo(text), null, 0, newIsPart: false, 0.0);
		playerEntity.AddFpos(new Change());
		PlayerEntityUtility.AddMove(playerEntity, Contexts.sharedInstance.weapon);
		playerEntity.AddTorseAnim(new TorseAnimStateInfo(15), 0, 2000, 0, 0, null, new Dictionary<string, float>(), newSpecialMode: false);
		playerEntity.AddViewAnim(1000, 0, 1000, 0, 100, 0, 1f, 1f, newIsBowing: false, 0, null, new ViewAnimStateInfo(15), null, null);
		playerEntity.AddCurrentWeapon(0, 0, text2, 0, WeaponInfoFactory.Instance.GetWeaponInfo(text2), newIsLock: false, newCanDuck: false, null, 0f, 0);
		PlayerEntityUtility.AddClientTime(playerEntity);
		PlayerEntityUtility.AddFov(playerEntity);
		PlayerEntityUtility.AddPunchOrientation(playerEntity);
		PlayerEntityUtility.AddNormalTrace(playerEntity);
		PlayerEntityUtility.AddState(playerEntity);
		PlayerEntityUtility.AddPassiveSkillInfo(playerEntity);
		PlayerEntityUtility.AddSkill(playerEntity);
		return playerEntity;
	}

	public static void InitgameProgressData()
	{
		Contexts.sharedInstance.gameRule.SetGameProgressData(ProgressType.ACTIVE, 0, 0, "", "", 0f);
	}

	public static void InitGameMessageData()
	{
	}

	public static void InitWeaponPendantDrop()
	{
		Contexts.sharedInstance.gameRule.SetWeaponPendantDrop(newIsStormScore: false, 0, "", 0, 0);
	}

	public static void InitAllKillInfo()
	{
	}
}
