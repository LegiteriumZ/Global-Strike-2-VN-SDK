using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.BaseEvent.Creator;

internal class SoundToggleEvent : IBaseEventCreator
{
	private AssetInfo _onAssetInfo;

	private readonly bool _loop;

	private readonly float? _volume;

	private int _subtype;

	public SoundToggleEvent(int subtype, AssetInfo on, bool loop)
	{
		_onAssetInfo = on;
		_loop = loop;
		_subtype = subtype;
	}

	public SoundToggleEvent(int subtype, AssetInfo on, bool loop, float vol)
	{
		_onAssetInfo = on;
		_loop = loop;
		_volume = vol;
		_subtype = subtype;
	}

	public void Create(BaseEventEntityData eventEntity, PlayerContext playerContext, SceneObjectContext sceneObjectContext)
	{
		if (eventEntity.Data == 0)
		{
			Vector3 vector = new Vector3(eventEntity.X, eventEntity.Y, eventEntity.Z);
			vector = VectorCoordConverter.SsjjToUnity(vector - playerContext.myPlayerEntity.GetCompenstatePos(playerContext.myPlayerEntity.fpos.Change.GetPosIndex()));
			bool isMyself = playerContext.GetEntityWithEntityId(eventEntity.OwnerId)?.isMyPlayer ?? false;
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(_subtype, isMyself, _onAssetInfo, vector, _volume.HasValue ? _volume.Value : 1f, 10000, 0, _loop);
		}
		else if (eventEntity.Data == 1)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.StopSound(ref _onAssetInfo);
		}
	}
}
