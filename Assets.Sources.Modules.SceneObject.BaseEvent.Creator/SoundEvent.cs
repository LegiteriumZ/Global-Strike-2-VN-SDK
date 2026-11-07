using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.BaseEvent.Creator;

internal class SoundEvent : IBaseEventCreator
{
	private AssetInfo _soundAsset;

	private SoundType _soundType;

	private bool _is3D;

	private int _subtype;

	public SoundEvent(int subtype, AssetInfo soundAsset, SoundType type, bool is3D = false)
	{
		_soundAsset = soundAsset;
		_soundType = type;
		_is3D = is3D;
		_subtype = subtype;
	}

	public void Create(BaseEventEntityData eventEntity, PlayerContext playerContext, SceneObjectContext sceneObjectContext)
	{
		bool isMyself = playerContext.GetEntityWithEntityId(eventEntity.OwnerId)?.isMyPlayer ?? false;
		float num = 1f;
		switch (_soundType)
		{
		case SoundType.Weapon:
			num = GameSoundManager.Config.WeaponVolume;
			break;
		case SoundType.Environment:
			num = GameSoundManager.Config.EnvironmentVolume;
			break;
		}
		if (_is3D)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(_subtype, isMyself, _soundAsset, VectorCoordConverter.SsjjToUnity(new Vector3(eventEntity.X, eventEntity.Y, eventEntity.Z)), num, 10000);
		}
		else
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(_subtype, isMyself, _soundAsset, num);
		}
	}
}
