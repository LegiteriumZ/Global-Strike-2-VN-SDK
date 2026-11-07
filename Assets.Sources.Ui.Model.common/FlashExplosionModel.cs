using System;
using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJMath;
using SSJJPhysics;
using UnityEngine;
using config;
using physics.trace;
using share;
using share.constant;

namespace Assets.Sources.Ui.Model.Common;

public class FlashExplosionModel : AbstractModel, IPlaybackSystem
{
	private class FlashInfo
	{
		public int PlayerId;

		public int KeepTime;

		public float Alpha;

		public int DeletionTime;

		public int TotalDeletionTime;
	}

	private FlashexplosionViewModel _viewModel;

	private Dictionary<int, FlashInfo> _flashInfoDic = new Dictionary<int, FlashInfo>();

	private List<int> _deleteList = new List<int>();

	private int _currColor;

	private AssetInfo[] _colorList = new AssetInfo[3]
	{
		new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/flash/selfflash.png"),
		new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/flash/selfflash_h.png"),
		new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/flash/selfflash_huise.png")
	};

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
	}

	public override void CreateViewModel()
	{
		_viewModel = new FlashexplosionViewModel();
	}

	public void OnPlayback()
	{
		UpdateExplosionInfo();
	}

	protected override void DoSubscribe()
	{
		SetData(null, null);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_flashExplosionData_Data, SetData);
	}

	private void UpdateImage()
	{
		_viewModel.ShowRootshow = false;
		_viewModel.TipsTextString = "";
		_viewModel.FlashImageShow = false;
		_viewModel.ObserverImageShow = false;
		int cameraOwnerData_Observer = UiIEventCondition.Get_cameraOwnerData_Observer();
		bool flag = cameraOwnerData_Observer > 0;
		int key = (flag ? cameraOwnerData_Observer : UiIEventCondition.Get_cameraOwnerData_PlayerId());
		if (_flashInfoDic.ContainsKey(key))
		{
			FlashInfo flashInfo = _flashInfoDic[key];
			_viewModel.ShowRootshow = false;
			_viewModel.ShowRootshow = true;
			bool cameraOwnerData_IsDead = UiIEventCondition.Get_cameraOwnerData_IsDead();
			if (flag)
			{
				_viewModel.ObserverImageShow = true;
				_viewModel.TipsTextString = ScriptLocalization.Get("Inflash");
			}
			else if (!cameraOwnerData_IsDead)
			{
				_viewModel.FlashImageShow = true;
			}
			else
			{
				flashInfo.DeletionTime = 0;
				flashInfo.KeepTime = 0;
				_viewModel.FlashImageShow = false;
			}
			if (flashInfo.KeepTime > 0)
			{
				_viewModel.FlashImageAlpha = flashInfo.Alpha;
				_viewModel.ObserverImageAlpha = flashInfo.Alpha;
			}
			else
			{
				FlashexplosionViewModel viewModel = _viewModel;
				float observerImageAlpha = (_viewModel.FlashImageAlpha = flashInfo.Alpha * (float)flashInfo.DeletionTime / (float)flashInfo.TotalDeletionTime);
				viewModel.ObserverImageAlpha = observerImageAlpha;
			}
		}
	}

	private void UpdateExplosionInfo()
	{
		if (_flashInfoDic.Count <= 0)
		{
			return;
		}
		foreach (KeyValuePair<int, FlashInfo> item in _flashInfoDic)
		{
			FlashInfo value = item.Value;
			value.KeepTime -= _timeComponent.FrameInterval;
			if (value.KeepTime <= 0)
			{
				value.DeletionTime -= _timeComponent.FrameInterval;
				if (value.DeletionTime <= 0)
				{
					_deleteList.Add(value.PlayerId);
				}
			}
		}
		foreach (int delete in _deleteList)
		{
			_flashInfoDic.Remove(delete);
		}
		_deleteList.Clear();
		UpdateImage();
	}

	private void SetData(GrenadeExplosionEventEntityData ov, GrenadeExplosionEventEntityData data)
	{
		if (data == null)
		{
			_viewModel.ShowRootshow = false;
			return;
		}
		Vector3 cameraOwnerData_Position = UiIEventCondition.Get_cameraOwnerData_Position();
		Vector3D vector3D = new Vector3D(cameraOwnerData_Position.x, cameraOwnerData_Position.y, cameraOwnerData_Position.z);
		float cameraOwnerData_ViewHeight = UiIEventCondition.Get_cameraOwnerData_ViewHeight();
		Vector3D vector3D2 = new Vector3D(vector3D.x, vector3D.y, vector3D.z + (double)cameraOwnerData_ViewHeight);
		Vector3DData collisionPoint = data.CollisionPoint;
		Vector3DData collisionNormal = data.CollisionNormal;
		Vector3D a = ((!data.HaveBulletHole) ? new Vector3D(collisionPoint.X, collisionPoint.Y, collisionPoint.Z) : new Vector3D(collisionPoint.X + collisionNormal.X * 2f, collisionPoint.Y + collisionNormal.Y * 2f, collisionPoint.Z + collisionNormal.Z * 2f));
		Trace trace = new Trace();
		TraceResult traceResult = default(TraceResult);
		float[] array = new float[3];
		float[] array2 = new float[3];
		float[] mins = new float[3];
		float[] maxs = new float[3];
		VectorUtils.Vector3DToFloat3(vector3D2, array);
		VectorUtils.Vector3DToFloat3(a, array2);
		PyEngineUtility.BulletTraceToWorld(UiIEventCondition.Get_uiPyEngine_PyEngine(), trace, array, array2, mins, maxs);
		traceResult.CopyFrom(trace);
		if (traceResult.Fraction == 1f || BspConstantUtil.NoImpact(UiIEventCondition.Get_uiPyEngine_DecalsId(), traceResult.SurfaceFlags))
		{
			vector3D2.z -= cameraOwnerData_ViewHeight;
			vector3D2 = a.Subtract(vector3D2);
			double num = vector3D2.Normalize();
			Vector3D cameraOwnerData_Viewaxi = UiIEventCondition.Get_cameraOwnerData_Viewaxi();
			double num2 = vector3D2.x * cameraOwnerData_Viewaxi.x + vector3D2.y * cameraOwnerData_Viewaxi.z + vector3D2.z * cameraOwnerData_Viewaxi.y;
			FlashInfo flashInfo = new FlashInfo();
			if (num2 > 0.0)
			{
				flashInfo.Alpha = 1f;
				if (num <= 2000.0)
				{
					flashInfo.KeepTime = (int)(3000.0 * Math.Pow(0.5, num / 2000.0));
					flashInfo.TotalDeletionTime = (flashInfo.DeletionTime = 4000);
				}
				else
				{
					flashInfo.KeepTime = (int)(500.0 * Math.Pow(0.5, num / 2000.0));
					flashInfo.TotalDeletionTime = (flashInfo.DeletionTime = flashInfo.KeepTime);
				}
				if (Contexts.sharedInstance.player.cameraOwnerEntity.skill.Status.ContainsKey(PlayerInfoStatusConstant.BE_FLASH_SUBTIME_RAGE.ID))
				{
					flashInfo.KeepTime = (int)((float)flashInfo.KeepTime * Mathf.Max(0f, 1f - 0.001f * (float)Contexts.sharedInstance.player.cameraOwnerEntity.skill.Status[PlayerInfoStatusConstant.BE_FLASH_SUBTIME_RAGE.ID].Number));
				}
				num2 = 1.0 - num * 0.00025;
			}
			else
			{
				flashInfo.Alpha = 0.7f;
				flashInfo.KeepTime = 0;
				flashInfo.TotalDeletionTime = (flashInfo.DeletionTime = 2800);
				num2 -= num * 0.001;
			}
			if (num2 < 0.0)
			{
				return;
			}
			flashInfo.PlayerId = UiIEventCondition.Get_cameraOwnerData_PlayerId();
			_flashInfoDic[flashInfo.PlayerId] = flashInfo;
			if ("grenade_wasp".Equals(data.WeaponName, StringComparison.OrdinalIgnoreCase))
			{
				if (flashInfo.KeepTime > 1500)
				{
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/weapon/grenade_wasp", "Assets/Res/Assets/sound/weapon/grenade_wasp_skill.mp3"), GameSoundManager.Config.AsideVolume);
				}
				else if (flashInfo.KeepTime >= 500)
				{
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/weapon/grenade_wasp", "Assets/Res/Assets/sound/weapon/grenade_wasp_fire4.mp3"), GameSoundManager.Config.AsideVolume);
				}
				else
				{
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/weapon/grenade_wasp", "Assets/Res/Assets/sound/weapon/grenade_wasp_fire3.mp3"), GameSoundManager.Config.AsideVolume);
				}
			}
		}
		UpdateImage();
		if (_currColor == data.Color)
		{
			return;
		}
		_currColor = data.Color;
		if (_currColor > 0 && _currColor < _colorList.Length)
		{
			this.GetLoader().RetriveSprite(_colorList[_currColor], delegate(Sprite sprite)
			{
				_viewModel.FlashImageSprite = sprite;
			});
		}
		else
		{
			this.GetLoader().RetriveSprite(_colorList[0], delegate(Sprite sprite)
			{
				_viewModel.FlashImageSprite = sprite;
			});
		}
	}
}
