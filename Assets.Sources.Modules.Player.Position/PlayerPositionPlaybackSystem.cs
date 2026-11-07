using System.Collections.Generic;
using Assets.Sources.Components.Player;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Utils.ComponentInit;
using Assets.Sources.Utils.Playback;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Position;

public class PlayerPositionPlaybackSystem : IPlaybackSystem
{
	private readonly PlayerContext _playerContext;

	private TimeComponent _time;

	private readonly SnapshotUtils _utils;

	private readonly Vector3 _randomPosVector;

	private List<Vector3> _randomList = new List<Vector3>();

	public PlayerPositionPlaybackSystem(Contexts contexts)
	{
		_utils = new SnapshotUtils();
		_playerContext = contexts.player;
		_time = contexts.time.time;
		_randomPosVector = new Vector3(Random.Range(0f, 1000f), Random.Range(0f, 1000f), Random.Range(0f, 1000f));
		for (int i = 0; i < 100; i++)
		{
			_randomList.Add(new Vector3(Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f), Random.Range(-1000f, 1000f)));
		}
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.hasFpos)
			{
				PlayerEntityUtility.AddPosition(item);
			}
			if (item.isPrediction || !item.hasBasicInfo)
			{
				continue;
			}
			FposComponent fpos = item.fpos;
			Vector3 playerEntityPosition = _utils.GetPlayerEntityPosition(item.basicInfo.Current, item.basicInfo.Next, _time.FrameInterpolation, _randomPosVector);
			for (int i = 0; i < fpos.Change.PosArray.Length; i++)
			{
				if (i == fpos.Change.GetPosIndex())
				{
					fpos.Sp(_randomPosVector + playerEntityPosition);
				}
				else
				{
					fpos.Sp(_randomList[i] + playerEntityPosition, i);
				}
			}
		}
	}
}
