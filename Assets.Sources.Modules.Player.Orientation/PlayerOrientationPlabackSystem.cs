using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using NetData;
using SSJJMath;

namespace Assets.Sources.Modules.Player.Orientation;

public class PlayerOrientationPlabackSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private WorldCameraContext _worldCameraContext;

	private TimeComponent _time;

	public PlayerOrientationPlabackSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_worldCameraContext = contexts.worldCamera;
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.isPrediction && item.hasOrientation)
			{
				if (_worldCameraContext.hasSceneCameraInfo && _worldCameraContext.sceneCameraInfo.PlayerCameraNotMove)
				{
					break;
				}
				PlayerEntityData current2 = item.basicInfo.Current;
				PlayerEntityData next = item.basicInfo.Next;
				item.orientation.Pitch = InterpolateUtility.LinearInterpolateAngel(current2.ViewPitch, next.ViewPitch, _time.FrameInterpolation);
				item.orientation.Yaw = InterpolateUtility.LinearInterpolateAngel(current2.ViewYaw, next.ViewYaw, _time.FrameInterpolation);
				item.punchOrientation.PunchPitch = InterpolateUtility.LinearInterpolateAngel(current2.PunchPitch, next.PunchPitch, _time.FrameInterpolation);
				item.punchOrientation.PunchYaw = InterpolateUtility.LinearInterpolateAngel(current2.PunchYaw, next.PunchYaw, _time.FrameInterpolation);
				item.orientation.MoveYaw = InterpolateUtility.LinearInterpolateAngel(current2.MoveYaw, next.MoveYaw, _time.FrameInterpolation);
				item.orientation.ActThirdMoveInterYaw = InterpolateUtility.LinearInterpolateAngel(current2.ActThirdMoveInterYaw, next.ActThirdMoveInterYaw, _time.FrameInterpolation);
			}
		}
	}
}
