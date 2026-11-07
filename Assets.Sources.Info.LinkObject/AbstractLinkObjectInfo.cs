using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.LinkObject;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils.ComponentInit;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.String;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.LinkObject;

public class AbstractLinkObjectInfo : ILinkObjectInfo
{
	public float EffectScale = 1f;

	public float UnitLengthScale = 1f;

	public float UnitLength = 1f;

	public bool isForecast;

	public int traceLength = 1000;

	public int forecastType;

	public bool serverSize;

	public bool isReplace;

	public string jointName;

	public int LerpStartz;

	public int LerpEndz;

	public int StartBackLen;

	public bool onlyView;

	private AssetInfo _info;

	private List<Material> _mats = new List<Material>();

	private List<Color> _colors = new List<Color>();

	public AssetInfo Info => _info;

	public virtual void InitEntity(SceneObjectEntity entity)
	{
		_info = default(AssetInfo);
		LinkEntityData now = entity.linkObject.Now;
		string playerEntityWeaponSkinName = PlayerEntityUtility.GetPlayerEntityWeaponSkinName(now.UsePlayerId);
		if (GetAssetInfo((now.LinkType2 > 0) ? now.LinkType2 : ((int)now.LinkType), ref _info, !string.IsNullOrEmpty(playerEntityWeaponSkinName)))
		{
			entity.AddLoadUnityObjects(new LoadRequests(_info), now.Id);
		}
		else
		{
			this.LogErrorFormat("Unknow LinkEntity Name:{0}", now.LinkType);
		}
	}

	private void InitMaterial(GameObject gameObject)
	{
		if (_mats.Count > 0)
		{
			return;
		}
		Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Material sharedMaterial = componentsInChildren[i].sharedMaterial;
			if (sharedMaterial != null && sharedMaterial.HasProperty("_TintColor"))
			{
				_colors.Add(sharedMaterial.GetColor("_TintColor"));
				_mats.Add(sharedMaterial);
			}
		}
	}

	public virtual void RenderEntity(SceneObjectEntity entity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
		SetLinkEffectWH(entity);
		if (UnitLengthScale > 0f)
		{
			entity.scale.Scale.z *= UnitLengthScale;
		}
		gameObject.transform.position = dest;
		gameObject.transform.localScale = entity.scale.Scale;
		VectorCoordConverter.SsjjToUnity(entity.linkObject.LerpEnd, out var dest2);
		gameObject.transform.LookAt(dest2);
		UpdateLinkAlpha(entity, gameObject);
	}

	private void UpdateLinkAlpha(SceneObjectEntity sceneObjectEntity, GameObject effectObject)
	{
		InitMaterial(effectObject);
		PlayerContext player = Contexts.sharedInstance.player;
		if (!player.cameraOwnerEntity.hasBasicInfo || player.cameraOwnerEntity.basicInfo.Current.Id == sceneObjectEntity.linkObject.UseId)
		{
			return;
		}
		for (int i = 0; i < _mats.Count; i++)
		{
			if (!Mathf.Approximately(_colors[i].a, sceneObjectEntity.linkObject.Alpha / 100f))
			{
				_colors[i] = new Color(_colors[i].r, _colors[i].g, _colors[i].b, sceneObjectEntity.linkObject.Alpha / 100f);
				_mats[i].SetColor("_TintColor", _colors[i]);
			}
		}
	}

	public void SetLinkEffectWH(SceneObjectEntity entity)
	{
		if (serverSize)
		{
			entity.scale.Scale.x = (float)entity.linkObject.Now.LinkWidth / 100f;
			entity.scale.Scale.y = (float)entity.linkObject.Now.LinkHeight / 100f;
			return;
		}
		LinkEntityType linkType = entity.linkObject.Now.LinkType;
		if ((uint)(linkType - 93) <= 1u)
		{
			entity.scale.Scale.x = (float)entity.linkObject.Now.LinkWidth / 100f;
			entity.scale.Scale.y = (float)entity.linkObject.Now.LinkHeight / 100f;
		}
		else
		{
			entity.scale.Scale.x = (entity.scale.Scale.y = EffectScale);
		}
	}

	public virtual bool GetAssetInfo(int id, ref AssetInfo info, bool isHasWeaponSkin)
	{
		switch (id)
		{
		case 2:
			info.AssetName = "Assets/Res/Assets/linkprefab/ghosttwins/FlashLink.prefab";
			info.BundleName = "linkprefab/ghosttwins";
			return true;
		case 0:
			info.AssetName = "Assets/Res/Assets/linkprefab/soullink/SoulLink.prefab";
			info.BundleName = "linkprefab/soullink";
			return true;
		case 1:
			info.AssetName = "Assets/Res/Assets/linkprefab/zhizhulianxian/lostgravemode/ZhizhuLianxian.prefab";
			info.BundleName = "linkprefab/zhizhulianxian/lostgravemode";
			return true;
		case 133:
		case 401:
			info.AssetName = "Assets/Res/Assets/linkprefab/tracklink/TrackBlueLink.prefab";
			info.BundleName = "linkprefab/tracklink";
			return true;
		case 134:
		case 402:
			info.AssetName = "Assets/Res/Assets/linkprefab/tracklink/TrackPurpleLink.prefab";
			info.BundleName = "linkprefab/tracklink";
			return true;
		default:
		{
			LineLinkEffectData lineLinkEffectData = ParticleManager.Instance().GetLineLinkEffectData(StringCache.IntToString(id), isHasWeaponSkin);
			if (lineLinkEffectData != null)
			{
				UnitLengthScale = lineLinkEffectData.UnitLengthScale;
				UnitLength = lineLinkEffectData.UnitLength;
				EffectScale = lineLinkEffectData.EffectScale;
				isForecast = lineLinkEffectData.isForecast;
				forecastType = lineLinkEffectData.forecastType;
				serverSize = lineLinkEffectData.serverSize;
				isReplace = lineLinkEffectData.isReplace;
				jointName = lineLinkEffectData.jointName;
				LerpStartz = lineLinkEffectData.LerpStartz;
				LerpEndz = lineLinkEffectData.LerpEndz;
				onlyView = lineLinkEffectData.onlyView;
				traceLength = lineLinkEffectData.traceLength;
				StartBackLen = lineLinkEffectData.StartBackLen;
				info.AssetName = lineLinkEffectData.AssetInfo.AssetName;
				info.BundleName = lineLinkEffectData.AssetInfo.BundleName;
				return true;
			}
			return false;
		}
		}
	}
}
