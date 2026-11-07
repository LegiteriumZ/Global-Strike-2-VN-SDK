using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.CameraEffect;
using Assets.Sources.Info.Effect.CameraEffect.Render;
using NetData;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Info.Effect.CameraEffect;

public class PlayerCameraEffectInfo : ICameraEffectInfo
{
	private AssetInfo _assetInfo = new AssetInfo("effectprefab/playercamera", "PlayerCamera", typeof(GameObject));

	public string GetTypeId()
	{
		return GetType().ToString();
	}

	public bool IsEffectOn(ISceneObjectEntity entity)
	{
		bool flag = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 25;
		if (!Contexts.sharedInstance.gameRule.currentRule.Rule.IsJump() && !flag)
		{
			return false;
		}
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity == null)
		{
			return false;
		}
		CameraEntityData current = (entity as SceneObjectEntity).cameraObject.Current;
		if (myPlayerEntity.GetTeam() == 1 && current.Cid != myPlayerEntity.basicInfo.Cid)
		{
			if (flag)
			{
				return getTeam(current.Cid) == 1;
			}
			return true;
		}
		return false;
	}

	private int getTeam(long cid)
	{
		foreach (PlayerEntity item in Contexts.sharedInstance.player)
		{
			if (item.basicInfo.Cid == cid)
			{
				return item.GetTeam();
			}
		}
		return -1;
	}

	public AssetInfo GetAssetInfo()
	{
		return _assetInfo;
	}

	public Type GetRenderType()
	{
		return typeof(CameraEffectRender);
	}
}
