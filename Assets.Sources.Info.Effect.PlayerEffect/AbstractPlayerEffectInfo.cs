using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public abstract class AbstractPlayerEffectInfo : IPlayerEffectInfo
{
	private readonly string _uniqueId;

	private int[] _supportedRules;

	protected int[] SupportedRules
	{
		get
		{
			if (_supportedRules == null)
			{
				_supportedRules = GetSupportedRules();
			}
			return _supportedRules;
		}
	}

	protected AbstractPlayerEffectInfo()
	{
		_uniqueId = GetType().ToString();
	}

	public virtual string GetUniqueId()
	{
		return _uniqueId;
	}

	public virtual float GetScaleX()
	{
		return 1f;
	}

	public virtual float GetEffectScale()
	{
		return 1f;
	}

	public abstract bool IsEffectOn(PlayerEntity player, IBattleRoom room);

	public abstract AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel);

	protected abstract int[] GetSupportedRules();

	public virtual bool IsAutoSize()
	{
		return false;
	}

	public virtual Type GetThirdRenderType()
	{
		return typeof(DefaultPlayerEffectRender);
	}

	public virtual bool IsThirdEffectAlwaysDisplay()
	{
		return false;
	}

	public virtual bool IsThirdEffectHide()
	{
		return false;
	}

	public virtual bool IsFirstEffectHide()
	{
		return false;
	}

	public virtual bool IsFirstEffectAlwaysDisplay()
	{
		return false;
	}

	public virtual Vector3 GetConfigOffset(PlayerEntity playerEntity)
	{
		return Vector3.zero;
	}

	public virtual int GetConfigViewHeight(PlayerEntity playerEntity)
	{
		return 0;
	}

	public virtual int GetConfigViewHeightTop(PlayerEntity playerEntity)
	{
		return 0;
	}

	public virtual string GetJointName()
	{
		return null;
	}

	public virtual int GetLifeTimeWhenTargetDead()
	{
		return 0;
	}

	public virtual bool IsEffectOnPlayerDead()
	{
		return false;
	}

	public virtual Vector3 GetConfigRotation(PlayerEntity playerEntity)
	{
		if (playerEntity != null && playerEntity.hasThirdPersonUnityObjects)
		{
			return playerEntity.thirdPersonUnityObjects.ThirdTran.RootContainer.transform.eulerAngles;
		}
		return Vector3.zero;
	}

	public virtual bool IsScaleOnlyXy()
	{
		return false;
	}

	public virtual bool IsSmallMirror()
	{
		return false;
	}
}
