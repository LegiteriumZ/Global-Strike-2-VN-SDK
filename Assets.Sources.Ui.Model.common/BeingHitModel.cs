using Assets.Sources.Config;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class BeingHitModel : AbstractModel, IPlaybackSystem, ISetCameraContext
{
	private BeinghitViewModel _viewModel = new BeinghitViewModel();

	private WorldCameraContext _cameraContext;

	private Vector3 _lastPosition;

	private LerpShowDelegate _lerpShowArraw;

	private int _arrowShowTime = 1000;

	private static AssetInfo _beingHit2 = new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/beinghit/beingHit2.png");

	private static AssetInfo _shieldIcon = new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/beinghit/shieldIcon.png");

	private static AssetInfo _beingHit = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/beingHit.png");

	private int _beingHitKind;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetCameraContext(WorldCameraContext context)
	{
		_cameraContext = context;
	}

	protected override void GetConfigValue()
	{
		if (!int.TryParse(GetValue("ShowTime"), out _arrowShowTime))
		{
			this.LogError("beinghit uiConfig is illegal !!");
		}
	}

	public void OnPlayback()
	{
		if (_lerpShowArraw != null)
		{
			_lerpShowArraw.OnPlayback(_timeComponent.ClientRealTime);
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowAlpha = 0f;
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_beingHit_BeinghitData, SetBeinghitData, null, initinvoke: true);
	}

	private void SetBeinghitData(BeingHitEventEntityData ov, BeingHitEventEntityData beinghitData)
	{
		if (beinghitData == null || GameSetting.Config.EffectParticleLevel < 2)
		{
			return;
		}
		if (beinghitData.Kind != _beingHitKind)
		{
			_beingHitKind = beinghitData.Kind;
			if (_beingHitKind == 1)
			{
				this.GetLoader().RetriveSprite(_beingHit2, delegate(Sprite sprite)
				{
					_viewModel.ImageSprite = sprite;
				});
			}
			else
			{
				this.GetLoader().RetriveSprite(_beingHit, delegate(Sprite sprite)
				{
					_viewModel.ImageSprite = sprite;
				});
			}
		}
		_viewModel.ShieldIconShow = beinghitData.IsDun;
		if (beinghitData.IsDun)
		{
			this.GetLoader().RetriveSprite(_shieldIcon, delegate(Sprite sprite)
			{
				_viewModel.ShieldIconSprite = sprite;
				_viewModel.ShieldIconNtvsize();
			});
		}
		if (_lerpShowArraw == null)
		{
			_lerpShowArraw = new LerpShowDelegate(_arrowShowTime, UpdateArrow, HideArrow);
		}
		else
		{
			_lerpShowArraw.ReStart();
		}
		_lastPosition = new Vector3(0f - beinghitData.BaseEventEntity.Y, beinghitData.BaseEventEntity.Z, beinghitData.BaseEventEntity.X);
	}

	private void HideArrow()
	{
		_viewModel.ShowAlpha = 0f;
	}

	private void UpdateArrow(float percent)
	{
		if (!(_lastPosition == Vector3.zero))
		{
			_viewModel.ShowAlpha = percent;
			Camera mainCamera = _cameraContext.unityObjects.mainCamera;
			bool num = Vector3.Dot(_lastPosition - mainCamera.transform.position, mainCamera.transform.forward) > 0f;
			float num2 = Mathf.Acos((RectTransformUtility.WorldToScreenPoint(mainCamera, _lastPosition) - new Vector2((float)Screen.width / 2f, 0f)).normalized.x) * 57.29578f;
			if (!num)
			{
				num2 = 180f + num2;
			}
			_viewModel.ShowRotation = Quaternion.Euler(new Vector3(0f, 0f, num2));
			if (_viewModel.ShieldIconShow)
			{
				_viewModel.ShieldIconRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f - num2));
			}
		}
	}
}
