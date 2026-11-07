using System.Collections.Generic;
using Assets.Generated.Table;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Sound;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJMath;

namespace Assets.Sources.Modules.Player.Sound;

public class SniperSoundSytem : IPlaybackSystem
{
	private readonly PlayerContext _playerContext;

	private static Dictionary<long, int> _fovs = new Dictionary<long, int>();

	private static AssetInfo _pickupAsset = new AssetInfo("sound/free", "Assets/Res/Assets/sound/free/pickup.mp3");

	public SniperSoundSytem(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			if (!item.hasFov || item.fov.Fov <= 0)
			{
				continue;
			}
			if (_fovs.ContainsKey(item.basicInfo.Cid))
			{
				if (_fovs[item.basicInfo.Cid] != item.fov.Fov)
				{
					_fovs[item.basicInfo.Cid] = item.fov.Fov;
					if (item.fov.Fov == 40 || item.fov.Fov == 10 || item.fov.Fov == 55)
					{
						VectorCoordConverter.SsjjToUnity(item.GetCompenstatePos(item.fpos.Change.GetPosIndex()), out var dest);
						MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Operate, item.isMyPlayer, _pickupAsset, dest, GameSoundManager.Config.WeaponVolume * 0.5f, GameSoundManager.RollOffDistance.Distance25);
					}
				}
			}
			else
			{
				_fovs.Add(item.basicInfo.Cid, item.fov.Fov);
			}
		}
	}
}
