using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.BaseEvent.Creator;

internal class SoundDistanceEvent : IBaseEventCreator
{
	private readonly AssetInfo _AssetInfo;

	private readonly bool _loop;

	private readonly float? _volume;

	private int _subtype;

	public SoundDistanceEvent(int subtype, AssetInfo info, bool loop)
	{
		_AssetInfo = info;
		_loop = loop;
		_subtype = subtype;
	}

	public SoundDistanceEvent(int subtype, AssetInfo info, bool loop, float vol)
	{
		_AssetInfo = info;
		_loop = loop;
		_volume = vol;
		_subtype = subtype;
	}

	public void Create(BaseEventEntityData eventEntity, PlayerContext playerContext, SceneObjectContext sceneObjectContext)
	{
		Vector3 inv = new Vector3(eventEntity.X, eventEntity.Y, eventEntity.Z);
		inv = VectorCoordConverter.SsjjToUnity(inv);
		Vector3 compenstatePos = playerContext.myPlayerEntity.GetCompenstatePos(playerContext.myPlayerEntity.fpos.Change.GetPosIndex());
		bool isMyself = playerContext.GetEntityWithEntityId(eventEntity.OwnerId)?.isMyPlayer ?? false;
		MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(_subtype, isMyself, _AssetInfo, inv - compenstatePos, _volume.HasValue ? _volume.Value : 1f, 10000, 0, _loop);
	}
}
