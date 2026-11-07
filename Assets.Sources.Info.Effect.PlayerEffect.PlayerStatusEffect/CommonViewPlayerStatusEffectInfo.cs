using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.PlayerStatusEffect;

public class CommonViewPlayerStatusEffectInfo : CommonPlayerStatusEffectInfo
{
	private readonly int _statusId;

	public CommonViewPlayerStatusEffectInfo(int statusId)
		: base(statusId)
	{
		_statusId = statusId;
	}

	public override string GetUniqueId()
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.Matrix;
		}
		return "";
	}

	public override Type GetThirdRenderType()
	{
		return typeof(CommonViewPlayerStatusRender);
	}

	public override float GetScaleX()
	{
		if (StatusInfoData != null && StatusInfoData.EffectScaleX > 0f)
		{
			return StatusInfoData.EffectScaleX;
		}
		return base.GetScaleX();
	}

	public override float GetEffectScale()
	{
		if (StatusInfoData != null && StatusInfoData.EffectScale > 0f)
		{
			return StatusInfoData.EffectScale;
		}
		return base.GetEffectScale();
	}

	public override bool IsAutoSize()
	{
		return false;
	}

	public override Vector3 GetConfigRotation(PlayerEntity playerEntity)
	{
		if (playerEntity != null && playerEntity.hasFirstPersonUnityObjects)
		{
			return playerEntity.firstPersonUnityObjects.HandCameraObject.transform.eulerAngles;
		}
		return Vector3.zero;
	}

	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.HasStatus(_statusId);
	}

	public override Vector3 GetConfigOffset(PlayerEntity playerEntity)
	{
		return base.GetConfigOffset(playerEntity);
	}

	public override string GetJointName()
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.JointName;
		}
		return base.GetJointName();
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		return false;
	}

	public override bool IsThirdEffectHide()
	{
		return false;
	}

	public override bool IsFirstEffectHide()
	{
		return false;
	}

	public override bool IsFirstEffectAlwaysDisplay()
	{
		return false;
	}

	public override int GetConfigViewHeight(PlayerEntity playerEntity)
	{
		return 0;
	}

	public override int GetConfigViewHeightTop(PlayerEntity playerEntity)
	{
		return 0;
	}

	public override int GetLifeTimeWhenTargetDead()
	{
		return 0;
	}

	public override bool IsEffectOnPlayerDead()
	{
		return false;
	}

	protected override int[] GetSupportedRules()
	{
		return new int[0];
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		if (StatusInfoData != null)
		{
			return StatusInfoData.AssetInfo;
		}
		return default(AssetInfo);
	}
}
