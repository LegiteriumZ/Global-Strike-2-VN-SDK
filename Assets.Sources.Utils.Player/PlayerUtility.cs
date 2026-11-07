using System;
using Assets.Sources.Components.Player;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Utils.Player;

public class PlayerUtility
{
	public const int PLAYER = 0;

	public const int PLAYER_NOMB = 1;

	public const int PLAYER_BACKACCESSORY = 2;

	public const int PLAYER_ZUIBA_EffECT = 3;

	public const int PLAYER_FLY_EFFECT = 4;

	public const int PLAYER_JIGUANGJIAN = 5;

	public const int PLAYER_JIGUANGPAO = 6;

	public const int PLAYER_BOSS09FIREL = 7;

	public const int PLAYER_BOSS09FIRER = 8;

	public const int PLAYER_LEFTJIGUANGJIAN = 9;

	public const int PLAYER_RIGHTEFFECT1 = 10;

	public const int PLAYER_RIGHTEFFECT2 = 11;

	public const int PLAYER_UV2_HUXI = 12;

	public const int PLAYER_UV2_LIUGUANG = 13;

	public const int PLAYER_UV2_HUXI_PLAYER = 14;

	public const int PLAYER_UV2_LIUGUANG_LOUKONG = 15;

	public const int PLAYER_PARTICLE_EFFECT1 = 16;

	public const int PLAYER_FEIXINGQI = 17;

	public const int PLAYER_PARTICLE_EFFECT2 = 18;

	public const int PLAYER_PARTICLE_EFFECT3 = 19;

	public const string JOINT_NAME_BOMB = "bomb";

	public const string JOINT_NAME_PELVIS = "bip01_pelvis";

	public const string JOINT_NAME_HEAD = "bip01_head";

	public const string JOINT_NAME_BACKACCESSORY = "backaccessory";

	public const string JOINT_NAME_ZUIBA = "zuiba";

	public const string JOINT_NAME_FLYEFFECT = "flyeffect";

	public const string JOINT_NAME_JIGUANGJIAN = "jiguangjianeffect";

	public const string JOINT_NAME_JIGUANGPAO = "jiguangpao";

	public const string JOINT_NAME_BOSS09FIREL = "boss09firel";

	public const string JOINT_NAME_BOSS09FIRER = "boss09firer";

	public const string JOINT_NAME_LEFTJIGUANGJIAN = "leftjiguangjian";

	public const string JOINT_NAME_RIGHTEFFECT1 = "righteffect1";

	public const string JOINT_NAME_RIGHTEFFECT2 = "righteffect2";

	public const string JOINT_NAME_PARTICLE_EFFECT1 = "player_particle_effect1";

	public const string JOINT_NAME_FEIXINGQI = "feixingqi_texiao";

	public const string JOINT_NAME_PARTICLE_EFFECT2 = "player_particle_effect2";

	public const string JOINT_NAME_PARTICLE_EFFECT3 = "player_particle_effect3";

	public const string JOINT_NAME_PARTICLE_EFFECT4 = "player_particle_effect4";

	public const string JOINT_NAME_PARTICLE_EFFECT5 = "player_particle_effect5";

	public const string JOINT_NAME_PARTICLE_EFFECT6 = "player_particle_effect6";

	public const string GUADIAN1 = "guadian_1";

	public const string GUADIAN2 = "guadian_2";

	public const string GUADIAN3 = "guadian_3";

	public const string GUADIAN4 = "guadian_4";

	public const string GUADIAN5 = "guadian_5";

	public const string GUADIAN6 = "guadian_6";

	public const string GUADIAN7 = "guadian_7";

	public const string GUADIAN8 = "guadian_8";

	public const string GUADIAN9 = "guadian_9";

	public const string GUADIAN10 = "guadian_10";

	public const string JOINTGUADIAN1 = "zlsw_a1";

	public const string JOINTGUADIAN2 = "zlsw_a2";

	public const string JOINTGUADIAN3 = "zlsw_a3";

	public const string JOINTGUADIAN4 = "zlsw_b1";

	public const string JOINTGUADIAN5 = "zlsw_b2";

	public const string JOINTGUADIAN6 = "zlsw_b3";

	private static IAllOfMatcher<PlayerEntity> _allmatcher = PlayerMatcher.AllOf(PlayerMatcher.Skill, PlayerMatcher.BasicInfo);

	public static float PlayerLength2D(MoveComponent move)
	{
		return (float)Math.Sqrt(move.Velocity.x * move.Velocity.x + move.Velocity.y * move.Velocity.y);
	}

	public static float PlayerLength2D(PlayerEntity player)
	{
		return (float)Math.Sqrt(player.move.Velocity.x * player.move.Velocity.x + player.move.Velocity.y * player.move.Velocity.y);
	}

	public static int GetBowWeaponState(PlayerEntity player)
	{
		int num = 0;
		if (!player.hasCurrentWeapon)
		{
			return 0;
		}
		if (player.GetCurrentWeaponSubType() != 2)
		{
			num |= 1;
		}
		if (!player.hasTorseAnim || player.torseAnim.TorsoAnimInfo == null)
		{
			return 0;
		}
		if (player.torseAnim.TorsoAnimInfo.StateId.Equals(15) && player.torseAnim.EclipsedTime >= 100)
		{
			num |= 2;
		}
		return num;
	}

	public static PlayerEntity GetPlayerEntityById(int cid)
	{
		foreach (PlayerEntity item in Contexts.sharedInstance.player)
		{
			if (item != null && item.hasEntityId && item.entityId.Value == cid)
			{
				return item;
			}
		}
		return null;
	}

	public static PlayerEntity GetPlayerByCid(long cid)
	{
		if (Contexts.sharedInstance.battleRoom.lobbyInfo.Cid2IdDic.TryGetValue(cid, out var value))
		{
			PlayerEntity entityWithEntityId = Contexts.sharedInstance.player.GetEntityWithEntityId(value);
			if (entityWithEntityId != null)
			{
				return entityWithEntityId;
			}
		}
		foreach (PlayerEntity item in Contexts.sharedInstance.player.GetGroup(_allmatcher))
		{
			if (item.basicInfo.Cid == cid)
			{
				return item;
			}
		}
		return null;
	}

	public static Transform GetRootBone(GameObject obj)
	{
		if (obj == null)
		{
			return null;
		}
		SkinnedMeshRenderer[] componentsInChildren = obj.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		for (int num = componentsInChildren.Length - 1; num >= 0; num--)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = componentsInChildren[num];
			if (skinnedMeshRenderer.rootBone.name.Equals("bip01_pelvis", StringComparison.OrdinalIgnoreCase))
			{
				return skinnedMeshRenderer.transform;
			}
		}
		for (int num2 = componentsInChildren.Length - 1; num2 >= 0; num2--)
		{
			SkinnedMeshRenderer skinnedMeshRenderer2 = componentsInChildren[num2];
			if (skinnedMeshRenderer2.rootBone.name.Equals("bip01", StringComparison.OrdinalIgnoreCase))
			{
				return skinnedMeshRenderer2.transform;
			}
		}
		for (int num3 = componentsInChildren.Length - 1; num3 >= 0; num3--)
		{
			SkinnedMeshRenderer skinnedMeshRenderer3 = componentsInChildren[num3];
			if (skinnedMeshRenderer3.rootBone.name.Equals("playermesh", StringComparison.OrdinalIgnoreCase))
			{
				return skinnedMeshRenderer3.transform;
			}
		}
		return null;
	}
}
