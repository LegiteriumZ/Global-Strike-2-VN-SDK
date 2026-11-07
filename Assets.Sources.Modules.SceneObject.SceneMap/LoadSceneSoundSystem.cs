using Assets.Generated.Table;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Sound;
using Entitas;
using SSJJAsset.Asset;
using SSJJBase.Pool;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using SSJJMath;
using SSJJSceneLoader;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class LoadSceneSoundSystem : IResourceLoadSystem
{
	private BattleRoomContext _battleRoomContext;

	private IGroup<SceneObjectEntity> _group;

	public LoadSceneSoundSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneMap).AnyOf(SceneObjectMatcher.MapUnityObjects).NoneOf(SceneObjectMatcher.MadeInUnity, SceneObjectMatcher.SoundAreaUnityObjects));
	}

	private void SetUp(SceneObjectEntity entity)
	{
		MyList<CSoundArea> soundAreaList = entity.mapUnityObjects.MapObject.GetComponent<BaseSceneRender>().GetSceneClipMap().soundAreaList;
		if (soundAreaList != null)
		{
			GameObject[] array = new GameObject[soundAreaList.Count];
			for (int i = 0; i < soundAreaList.Count; i++)
			{
				CSoundArea cSoundArea = soundAreaList[i];
				GameObject gameObject = new GameObject();
				gameObject.transform.localPosition = VectorCoordConverter.SsjjToUnity(new Vector3((float)cSoundArea.point.x, (float)cSoundArea.point.y, (float)cSoundArea.point.z));
				AudioSource audioSource = gameObject.AddComponent<AudioSource>();
				audioSource.dopplerLevel = 0.01f;
				audioSource.rolloffMode = AudioRolloffMode.Linear;
				audioSource.spatialBlend = 1f;
				audioSource.playOnAwake = true;
				audioSource.loop = true;
				audioSource.volume = GameSoundManager.Config.AsideVolume;
				audioSource.maxDistance = (float)cSoundArea.radius * 200f;
				audioSource.minDistance = (float)cSoundArea.radius * 100f;
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Scene, isMyself: false, audioSource, new AssetInfo("sound/scenesound", cSoundArea.soundName), 2000);
				array[i] = gameObject;
			}
			entity.AddSoundAreaUnityObjects(array);
		}
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		if (!_battleRoomContext.hasMapInfo)
		{
			return;
		}
		foreach (SceneObjectEntity item in _group)
		{
			SetUp(item);
		}
	}
}
