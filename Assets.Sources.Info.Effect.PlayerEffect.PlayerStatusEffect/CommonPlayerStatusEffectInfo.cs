using Assets.Sources.Components.Interface;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using SSJJAsset.Asset;
using SSJJBase.String;
using SSJJMath;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect.PlayerStatusEffect;

public class CommonPlayerStatusEffectInfo : AbstractPlayerEffectInfo
{
	protected PlayerInfoEffectData StatusInfoData;

	private readonly int _statusId;

	protected readonly string PrefabName;

	public CommonPlayerStatusEffectInfo(int statusId)
	{
		_statusId = statusId;
		PrefabName = $"playerinfo_{statusId}";
		StatusInfoData = ParticleManager.Instance().GetPlayerInfoEffectData(StringCache.IntToString(_statusId));
		if (StatusInfoData == null)
		{
			_ = _statusId;
			_ = 0;
		}
	}

	public override string GetUniqueId()
	{
		return PrefabName;
	}

	public override float GetScaleX()
	{
		if (StatusInfoData != null && StatusInfoData.EffectScaleX > 0f)
		{
			return StatusInfoData.EffectScaleX;
		}
		return base.GetScaleX();
	}

	public override bool IsScaleOnlyXy()
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.scaleOnlyXY;
		}
		return base.IsScaleOnlyXy();
	}

	public override bool IsSmallMirror()
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.isSmallMirror;
		}
		return base.IsSmallMirror();
	}

	public override bool IsAutoSize()
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.AutoSize;
		}
		return false;
	}

	public override Vector3 GetConfigRotation(PlayerEntity playerEntity)
	{
		if (StatusInfoData != null)
		{
			Vector3 inv = new Vector3(StatusInfoData.PitchTrim, 0f, 0f);
			if (playerEntity.move.ActThirdMove)
			{
				inv.z = (float)StatusInfoData.YawTrim + playerEntity.orientation.MoveYaw;
			}
			else
			{
				inv.z = (float)StatusInfoData.YawTrim + playerEntity.GetViewYaw();
			}
			return VectorCoordConverter.SsjjRotationToUnity(inv);
		}
		return base.GetConfigRotation(playerEntity);
	}

	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.HasStatus(_statusId);
	}

	protected override int[] GetSupportedRules()
	{
		return new int[6] { 6, 11, -2, -3, 24, 25 };
	}

	public override Vector3 GetConfigOffset(PlayerEntity playerEntity)
	{
		return base.GetConfigOffset(playerEntity);
	}

	public override int GetConfigViewHeight(PlayerEntity playerEntity)
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.ViewHeight;
		}
		return base.GetConfigViewHeight(playerEntity);
	}

	public override int GetConfigViewHeightTop(PlayerEntity playerEntity)
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.ViewHeightTop;
		}
		return base.GetConfigViewHeightTop(playerEntity);
	}

	public override string GetJointName()
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.JointName;
		}
		return base.GetJointName();
	}

	public override int GetLifeTimeWhenTargetDead()
	{
		if (_statusId == PlayerInfoStatusConstant.RPG_XP1003_SKILL_KILLED.ID)
		{
			return 500;
		}
		if (_statusId == PlayerInfoStatusConstant.SHOTGUN_LASER_BEATTACK.ID)
		{
			return 1000;
		}
		if (_statusId == PlayerInfoStatusConstant.BLOCK_COMBINED_CANNON_KILL.ID)
		{
			return 1000;
		}
		if (_statusId == PlayerInfoStatusConstant.AWM_LEGEND_LIUXUE.ID)
		{
			return 600;
		}
		return base.GetLifeTimeWhenTargetDead();
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		if (_statusId != PlayerInfoStatusConstant.DRAGOON_A_108.ID && _statusId != PlayerInfoStatusConstant.DRAGOON_A_105.ID && _statusId != PlayerInfoStatusConstant.DRAGOON_A_106.ID && _statusId != PlayerInfoStatusConstant.DRAGOON_A_107.ID && _statusId != PlayerInfoStatusConstant.DRAGOON_A_109.ID && _statusId != PlayerInfoStatusConstant.DRAGOON_B_111.ID && _statusId != PlayerInfoStatusConstant.DRAGOON_B_116.ID && _statusId != PlayerInfoStatusConstant.ABYSS_BLADE_HUDUN.ID && _statusId != PlayerInfoStatusConstant.ABYSS_BLADE_HUDUN1.ID && _statusId != PlayerInfoStatusConstant.ABYSS_BLADE_HUDUN2.ID && _statusId != PlayerInfoStatusConstant.MIKADUKI_SWORD_ZHENGDANGBO.ID)
		{
			return _statusId == PlayerInfoStatusConstant.DUAN_ZUI_TE_XIAO.ID;
		}
		return true;
	}

	public override bool IsFirstEffectHide()
	{
		return _statusId == PlayerInfoStatusConstant.DRAGOON_B_116.ID;
	}

	public override bool IsThirdEffectHide()
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.ThirdEffectHide;
		}
		return false;
	}

	public override bool IsFirstEffectAlwaysDisplay()
	{
		if (StatusInfoData != null && StatusInfoData.HasViewEffect)
		{
			return true;
		}
		if (_statusId != PlayerInfoStatusConstant.MENTAL_BURSTER_SXKC_BUFF.ID)
		{
			return _statusId == PlayerInfoStatusConstant.SWORD_HEAVEN_JUDGE_HUDUN.ID;
		}
		return true;
	}

	public float NeedUpCorrect()
	{
		if (StatusInfoData == null)
		{
			return -1f;
		}
		if (_statusId == PlayerInfoStatusConstant.STARRING_RIFLE_STAR_RING_AROUND.ID || _statusId == PlayerInfoStatusConstant.STARRING_RIFLE_STAR_RING_AROUND_MAX.ID || _statusId == PlayerInfoStatusConstant.CHRISTMAS_BLADE_ROTATE.ID)
		{
			return StatusInfoData.Up;
		}
		return -1f;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.AssetInfo;
		}
		string text = null;
		switch (_statusId)
		{
		case 1001:
			text = string.Format("{0}{1}", "player/", "bossjy3002");
			break;
		case 1003:
		case 1004:
			text = string.Format("{0}{1}", "skill/", "xp1001");
			break;
		case 1114:
			text = string.Format("{0}{1}", "skill/", "role1001");
			break;
		case 1041:
			text = string.Format("{0}{1}", "player/", "bossjy3006");
			break;
		case 1138:
			text = string.Format("{0}{1}", "player/", "rpg_10600101");
			break;
		case 1022:
		case 1028:
		case 1060:
			text = string.Format("{0}{1}", "effect/", "rpgcommon");
			break;
		case 1106:
		case 1107:
			text = string.Format("{0}{1}", "effect/", "titfortatmode");
			break;
		case 1015:
		case 1017:
		case 1025:
		case 1051:
		case 1057:
		case 1065:
		case 1069:
		case 1077:
		case 1091:
		case 1097:
		case 1098:
		case 1105:
		case 1108:
		case 1112:
		case 1132:
		case 1139:
			text = string.Format("{0}{1}", "weapon/", Contexts.sharedInstance.player.myPlayerEntity.currentWeapon.Name);
			break;
		default:
			text = string.Format("{0}{1}", "player/", player.GetCareer());
			break;
		}
		return new AssetInfo(text, PrefabName, typeof(GameObject), StatusInfoData == null);
	}
}
