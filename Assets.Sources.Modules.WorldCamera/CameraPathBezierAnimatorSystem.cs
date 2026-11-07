using Assets.Sources.Components.Camera;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Info.Camera;
using Assets.Sources.Info.Career;
using Assets.Sources.Particle;
using NetData;
using share;

namespace Assets.Sources.Modules.WorldCamera;

public class CameraPathBezierAnimatorSystem : IAfterPredicationSystem
{
	private CameraPathBezierAnimator _playCameraPathBezierAnimator;

	private Vector3D _basePosition = new Vector3D();

	private WorldCameraContext _worldCameraContext;

	private PlayerContext _playerContexts;

	private TimeContext _timeContext;

	private string _currentName;

	public CameraPathBezierAnimatorSystem(Contexts contexts)
	{
		_worldCameraContext = contexts.worldCamera;
		_timeContext = contexts.time;
		_playerContexts = contexts.player;
		_worldCameraContext.SetCameraEffect(newPlaying: false, new Matrix3D(), newHideScene: false, newHideGui: false, 0, 0, null, null);
	}

	private void Update(int frameinterval, int rendertime)
	{
		CameraEffectComponent cameraEffect = _worldCameraContext.cameraEffect;
		if (_playCameraPathBezierAnimator != null)
		{
			if (rendertime > cameraEffect.StartTime + _playCameraPathBezierAnimator.Time)
			{
				Stop();
				return;
			}
			cameraEffect.Playing = _playCameraPathBezierAnimator.Player(rendertime - cameraEffect.StartTime, cameraEffect.Matrix3D);
			cameraEffect.Position = _playCameraPathBezierAnimator.Position;
			cameraEffect.Rotation = _playCameraPathBezierAnimator.Rotation;
		}
	}

	private void LateUpdate()
	{
		PlayerEntity cameraOwnerEntity = _playerContexts.cameraOwnerEntity;
		CameraEffectComponent cameraEffect = _worldCameraContext.cameraEffect;
		if (cameraEffect.Playing && _playerContexts.GetEntityWithEntityId(cameraEffect.AttachId) == null)
		{
			Stop();
			return;
		}
		bool flag = false;
		foreach (PlayerEntity playerContext in _playerContexts)
		{
			if (playerContext.hasBasicInfo)
			{
				PlotCameraInfoData plotCameraInfoData = playerContext.basicInfo.Current.PlotCameraInfoData;
				if (plotCameraInfoData != null && CanPlay(plotCameraInfoData, playerContext, cameraOwnerEntity))
				{
					_basePosition.x = playerContext.GetCompenstatePos(playerContext.fpos.Change.GetPosIndex()).x;
					_basePosition.y = playerContext.GetCompenstatePos(playerContext.fpos.Change.GetPosIndex()).y;
					_basePosition.z = playerContext.GetCompenstatePos(playerContext.fpos.Change.GetPosIndex()).z;
					Play(cameraEffect, _basePosition, playerContext.orientation.Yaw, plotCameraInfoData.PlotName, plotCameraInfoData.StartTime);
					_worldCameraContext.cameraEffect.AttachId = playerContext.GetId();
					_worldCameraContext.cameraEffect.HideScene = plotCameraInfoData.HideScene;
					_worldCameraContext.cameraEffect.HideGui = plotCameraInfoData.HideGUI;
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			_worldCameraContext.cameraEffect.AttachId = -1;
			_worldCameraContext.cameraEffect.HideScene = false;
			_worldCameraContext.cameraEffect.HideGui = false;
		}
	}

	public void OnAfterPredication()
	{
		TimeComponent time = _timeContext.time;
		Update(time.FrameInterval, time.RenderTime);
		LateUpdate();
	}

	private bool CanPlay(PlotCameraInfoData plotCameraInfom, PlayerEntity playerEntity, PlayerEntity selfPlayerEntity)
	{
		if (plotCameraInfom.Kind == PlotCameraKind.NONE)
		{
			return false;
		}
		if (plotCameraInfom.Kind == PlotCameraKind.SELF && playerEntity == selfPlayerEntity)
		{
			return true;
		}
		if (plotCameraInfom.Kind == PlotCameraKind.UNSAMETEAM && playerEntity.GetTeam() != selfPlayerEntity.GetTeam())
		{
			return true;
		}
		if (plotCameraInfom.Kind == PlotCameraKind.SAMETEAM && playerEntity.GetTeam() == selfPlayerEntity.GetTeam())
		{
			return true;
		}
		if (plotCameraInfom.Kind == PlotCameraKind.ALL)
		{
			return true;
		}
		return false;
	}

	private void Stop()
	{
		_worldCameraContext.cameraEffect.Playing = false;
		_playCameraPathBezierAnimator = null;
		_currentName = null;
	}

	private void Play(CameraEffectComponent effect, Vector3D basePosition, float z, string name, int serverTime)
	{
		if (string.IsNullOrEmpty(name))
		{
			Stop();
		}
		else
		{
			if (effect.Playing && _currentName == name)
			{
				return;
			}
			_currentName = name;
			CameraEffectConfigItem cameraEffectData = ParticleManager.Instance().GetCameraEffectData(name);
			if (cameraEffectData != null)
			{
				if (_playCameraPathBezierAnimator == null || _playCameraPathBezierAnimator.name != name)
				{
					if (_playCameraPathBezierAnimator == null)
					{
						_playCameraPathBezierAnimator = new CameraPathBezierAnimator();
					}
					_playCameraPathBezierAnimator.SetData(cameraEffectData);
				}
				effect.Matrix3D.Identity();
				effect.Matrix3D.AppendRotation(0.0, Vector3D.X_AXIS);
				effect.Matrix3D.AppendRotation(0.0, Vector3D.Y_AXIS);
				effect.Matrix3D.AppendRotation(z, Vector3D.Z_AXIS);
				effect.Matrix3D.AppendTranslation(basePosition.x, basePosition.y, basePosition.z);
				effect.StartTime = serverTime;
			}
			else
			{
				Stop();
			}
		}
	}
}
