using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Framework.System;
using Assets.Sources.Utils.PlayerAnim;
using Entitas;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class GPUAnimSystem : FrameExecuteSystem, IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _players;

	private bool _isCanFrame;

	public GPUAnimSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonGPUAnim));
		int raceType = contexts.battleRoom.roomData.Data.RaceType;
		_isCanFrame = !RuleUtilty.IsGroupModel(raceType) && !RuleUtilty.IsExplode(raceType);
	}

	public void OnPlayback()
	{
		if (Frame() || !_isCanFrame)
		{
			OnRender();
		}
	}

	public void OnRender()
	{
		foreach (PlayerEntity player in _players)
		{
			int torsoAnimId = PlayerAnimationUtility.GetTorsoAnimId(player);
			int legAnimId = PlayerAnimationUtility.GetLegAnimId(player);
			if (!PlayerAnimationUtility.CheckIsWarpAnimSystem(player, legAnimId, torsoAnimId) && !PlayerAnimationUtility.CheckIsTPSAnimSystem(player))
			{
				SetPlayerLegsAnim(player);
			}
		}
	}

	private void SetPlayerLegsAnim(PlayerEntity entity)
	{
		if (entity.hasThirdPersonUnityObjects)
		{
			ILegAnimStateInfo legsAnimInfo = entity.legAnim.LegsAnimInfo;
			if (legsAnimInfo != null)
			{
				entity.thirdPersonGPUAnim.gpuSkinningPlayerMono.PlayerAnim(GetAnimName(entity.thirdPersonGPUAnim.gpuSkinningPlayerMono, legsAnimInfo.StateId), legsAnimInfo.IsLoop);
			}
		}
	}

	public static string GetAnimName(IGPUSkinningPlayerMono legAnimSet, int legsAnim, int duckState = 0)
	{
		string result = "idle1";
		switch (legsAnim)
		{
		case 1:
			result = "run";
			break;
		case 2:
			result = ((!legAnimSet.HasAnimName("runb")) ? "run" : "runb");
			break;
		case 4:
			result = ((!legAnimSet.HasAnimName("walkb")) ? ((!legAnimSet.HasAnimName("walk")) ? "run" : "walk") : "walkb");
			break;
		case 10:
			result = ((!legAnimSet.HasAnimName("crouchrun")) ? "run" : "crouchrun");
			break;
		case 3:
			result = ((!legAnimSet.HasAnimName("walk")) ? "run" : "walk");
			break;
		case 8:
			result = "crouch_idle";
			break;
		case 9:
			result = ((!legAnimSet.HasAnimName("crouchrun")) ? "run" : "crouchrun");
			break;
		case 5:
			result = "jump";
			break;
		case 11:
			result = ((!legAnimSet.HasAnimName("head")) ? "idle1" : "head");
			break;
		case 42:
			result = "headshot";
			break;
		case 43:
			result = "headshot_f";
			break;
		case 27:
			result = "skill";
			break;
		case 67:
			result = "fly";
			break;
		case 45:
			result = "legs_attack";
			break;
		case 49:
			result = "legs_attack2";
			break;
		case 50:
			result = "skill2";
			break;
		case 51:
			result = "skill_start";
			break;
		case 52:
			result = "skill_loop";
			break;
		case 53:
			result = "skill_end";
			break;
		case 54:
			result = "skill3";
			break;
		case 57:
			result = "skill4";
			break;
		case 58:
			result = "chuchang";
			break;
		case 56:
			result = "weapon_flash";
			break;
		case 59:
			result = "die_b";
			break;
		case 60:
			result = "die_f";
			break;
		case 61:
			result = "die_l";
			break;
		case 62:
			result = "die_r";
			break;
		case 68:
			result = "skill5";
			break;
		case 73:
			result = "paqiang";
			break;
		case 74:
			result = "skill_start1";
			break;
		case 82:
			result = "xp_skill_1";
			break;
		case 75:
			result = "skill_loop1";
			break;
		case 76:
			result = "skill_end1";
			break;
		case 77:
			result = "skill_start2";
			break;
		case 78:
			result = "skill_loop2";
			break;
		case 79:
			result = "skill_end2";
			break;
		case 80:
			result = "ghost_rider_skill";
			break;
		case 83:
			result = "skill_start3";
			break;
		case 84:
			result = "skill_loop3";
			break;
		case 95:
			result = "legs_yunxuan";
			break;
		case 97:
			result = "legs_skill_2";
			break;
		case 85:
			result = "skill_end3";
			break;
		case 91:
			result = "m60_attack";
			break;
		case 89:
			result = "m60_down";
			break;
		case 90:
			result = "m60_up";
			break;
		case 92:
			result = "m60_idle";
			break;
		case 138:
			result = "m60_move";
			break;
		case 156:
			result = "m60_move_back";
			break;
		case 157:
			result = "m60_move_left";
			break;
		case 158:
			result = "m60_move_right";
			break;
		case 101:
			result = "gatling_down_attack";
			break;
		case 99:
			result = "gatling_down";
			break;
		case 100:
			result = "gatling_up";
			break;
		case 102:
			result = "gatling_down_idle";
			break;
		case 98:
			result = "saber_skill";
			break;
		case 93:
			result = "hero_cold_skill";
			break;
		case 105:
			result = "legs_xp_skill_3";
			break;
		case 145:
			result = "legs_role_skill_start_1";
			break;
		case 164:
			result = "legs_role_skill_start_4";
			break;
		case 152:
			result = "legs_role_skill2";
			break;
		case 154:
			result = "legs_role_skill3";
			break;
		case 159:
			result = "legs_fukong";
			break;
		case 146:
			result = "legs_role_skill_loop_1";
			break;
		case 147:
			result = "legs_role_skill_end_1";
			break;
		case 165:
			result = "legs_role_skill_loop_4";
			break;
		case 166:
			result = "legs_role_skill_end_4";
			break;
		case 107:
			result = "legs_debug1";
			break;
		case 108:
			result = "legs_debug2";
			break;
		case 109:
			result = "legs_debug3";
			break;
		case 110:
			result = "legs_debug4";
			break;
		case 111:
			result = "legs_debug5";
			break;
		case 112:
			result = "legs_debug6";
			break;
		case 113:
			result = "legs_debug7";
			break;
		case 114:
			result = "legs_debug8";
			break;
		case 115:
			result = "legs_debug9";
			break;
		case 116:
			result = "legs_debug10";
			break;
		case 120:
			result = "dodge_left";
			break;
		case 121:
			result = "dodge_right";
			break;
		case 119:
			result = "dodge_front";
			break;
		case 118:
			result = "dodge_back";
			break;
		case 127:
			result = "hitground";
			break;
		case 128:
			result = "avatar_jump";
			break;
		case 129:
			result = "avatar_jumping";
			break;
		case 130:
			result = "avatar_fall";
			break;
		case 139:
			result = "sprint_start";
			break;
		case 140:
			result = "sprint_loop";
			break;
		case 141:
			result = "sprint_end";
			break;
		case 131:
			result = "summon";
			break;
		case 134:
			result = "shengdianqishi_idle";
			break;
		case 133:
			result = "destroyrider_idle";
			break;
		default:
			result = ((duckState != 0) ? "idle1" : "crouch_idle");
			break;
		case 6:
			break;
		}
		return result;
	}

	public static string GetLegAnimName(int legsAnim, string weaponName)
	{
		return legsAnim switch
		{
			7 => "idle1", 
			1 => "run", 
			2 => "run", 
			177 => "run", 
			178 => "run", 
			4 => "run", 
			3 => "run", 
			9 => "run", 
			10 => "run", 
			300 => "run", 
			8 => "crouch_idle", 
			5 => "jump", 
			340 => "jump_loop", 
			6 => "land", 
			11 => "head", 
			42 => "headshot", 
			43 => "headshot_f", 
			27 => "skill", 
			45 => "legs_attack", 
			327 => "legs_attack_raise", 
			49 => "legs_attack2", 
			353 => "legs_attack2_raise", 
			184 => "legs_attack3", 
			195 => "legs_attack4", 
			196 => "legs_attack5", 
			185 => "behit", 
			50 => "skill2", 
			51 => "skill_start", 
			52 => "skill_loop", 
			53 => "skill_end", 
			54 => "skill3", 
			56 => "weapon_flash", 
			57 => "skill4", 
			58 => "chuchang", 
			59 => "die_b", 
			60 => "die_f", 
			61 => "die_l", 
			62 => "die_r", 
			67 => "fly", 
			68 => "skill5", 
			194 => "skill6", 
			73 => "paqiang", 
			74 => "skill_start1", 
			75 => "skill_loop1", 
			76 => "skill_end1", 
			179 => "skill_start4", 
			180 => "skill_loop4", 
			181 => "skill_end4", 
			186 => "skill_start5", 
			187 => "skill_loop5", 
			188 => "skill_end5", 
			189 => "skill_start6", 
			190 => "skill_loop6", 
			191 => "skill_end6", 
			77 => "skill_start2", 
			78 => "skill_loop2", 
			182 => "yunxuan_start1", 
			183 => "yunxuan_loop1", 
			192 => "yunxuan_start2", 
			193 => "yunxuan_loop2", 
			82 => "xp_skill_1", 
			95 => "legs_yunxuan", 
			97 => "legs_skill_2", 
			105 => "legs_xp_skill_3", 
			145 => "legs_role_skill_start_1", 
			164 => "legs_role_skill_start_4", 
			213 => "legs_role_skill_start_10", 
			214 => "legs_role_skill_loop_10", 
			215 => "legs_role_skill_end_10", 
			219 => "legs_role_skill_start_11", 
			220 => "legs_role_skill_loop_11", 
			221 => "legs_role_skill_end_11", 
			152 => "legs_role_skill2", 
			197 => "legs_role_skill_5", 
			312 => "legs_role_skill_13", 
			323 => "legs_role_skill_17", 
			370 => "legs_role_skill_24", 
			372 => "legs_role_skill_25", 
			154 => "legs_role_skill3", 
			146 => "legs_role_skill_loop_1", 
			165 => "legs_role_skill_loop_4", 
			159 => "legs_fukong", 
			147 => "legs_role_skill_end_1", 
			166 => "legs_role_skill_end_4", 
			79 => "skill_end2", 
			80 => "ghost_rider_skill", 
			83 => "skill_start3", 
			84 => "skill_loop3", 
			85 => "skill_end3", 
			91 => "m60_attack", 
			89 => "m60_down", 
			90 => "m60_up", 
			92 => "m60_idle", 
			138 => "m60_move", 
			156 => "m60_move_back", 
			157 => "m60_move_left", 
			158 => "m60_move_right", 
			98 => "saber_skill", 
			93 => "hero_cold_skill", 
			101 => "gatling_down_attack", 
			99 => "gatling_down", 
			100 => "gatling_up", 
			102 => "gatling_down_idle", 
			107 => "legs_debug1", 
			108 => "legs_debug2", 
			109 => "legs_debug3", 
			110 => "legs_debug4", 
			111 => "legs_debug5", 
			112 => "legs_debug6", 
			113 => "legs_debug7", 
			114 => "legs_debug8", 
			115 => "legs_debug9", 
			116 => "legs_debug10", 
			118 => "dodge_back", 
			119 => "dodge_front", 
			120 => "dodge_left", 
			121 => "dodge_right", 
			127 => "hitground", 
			128 => "avatar_jump", 
			129 => "avatar_jumping", 
			130 => "avatar_fall", 
			131 => "summon", 
			139 => "sprint_start", 
			140 => "sprint_loop", 
			141 => "sprint_end", 
			203 => "skill3_left", 
			204 => "skill3_right", 
			205 => "skill3_back", 
			207 => "legs_gliding", 
			209 => "legs_landoff", 
			225 => "legs_role_skill_start_12", 
			226 => "legs_role_skill_loop_12", 
			227 => "legs_role_skill_end_12", 
			228 => "legs_airmovestep1", 
			229 => "legs_airmovestep2", 
			230 => "legs_airmovestep3", 
			305 => "legs_jiuzhu_start", 
			307 => "legs_jiuzhu_loop", 
			309 => "legs_jiuzhu_end", 
			303 => "legs_shoushang", 
			311 => "legs_jipao", 
			316 => "legs_twins_skill_loop", 
			317 => "legs_twins_skill_end", 
			318 => "legs_sec_knife_attack", 
			319 => "legs_sec_knife_attack_raise", 
			320 => "legs_sec_knife_attack2", 
			321 => "legs_sec_knife_attack2_raise", 
			322 => "legs_sec_knife_attack3", 
			326 => "legs_weapon_skill_" + weaponName, 
			336 => "legs_mirage_skill_start", 
			337 => "legs_mirage_skill_end", 
			343 => "legs_skate_run", 
			347 => "legs_light_with_shadow_skill_start", 
			349 => "legs_light_with_shadow_skill_loop", 
			351 => "legs_light_with_shadow_skill_end", 
			345 => "legs_light_with_shadow_attack", 
			1011 => "p3hero_skill1001_common", 
			1021 => "p3hero_skill1002_common", 
			1030 => "p3hero_skill1003_common", 
			1040 => "p3hero_skill1004_common", 
			1050 => "p3hero_skill1005_common", 
			1060 => "p3hero_skill1006_common", 
			1070 => "p3hero_skill1007_common", 
			1080 => "p3hero_skill1008_common", 
			1090 => "p3hero_skill1009_common", 
			1100 => "p3hero_skill1010_common", 
			1110 => "p3hero_skill1011_common", 
			1112 => "p3hero_skill1012_common", 
			354 => "legs_role_skill_20", 
			358 => "legs_broad_sword_skill1", 
			359 => "legs_broad_sword_skill2", 
			357 => "legs_darkdiamond_skill", 
			408 => "legs_snake_skill_loop", 
			_ => null, 
		};
	}
}
