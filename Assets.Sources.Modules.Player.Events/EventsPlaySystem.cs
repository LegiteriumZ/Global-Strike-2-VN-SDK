using Assets.Generated.Table;
using Assets.Sources.Components.Interface.Info.EventParticle;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.EventParticle;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using Entitas;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Events;

public class EventsPlaySystem : IResourceLoadSystem
{
	private readonly IGroup<PlayerEntity> _players;

	private readonly IGroup<PlayerEntity> _selfPlayer;

	private Vector3 position;

	public EventsPlaySystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Events, PlayerMatcher.Fpos, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.EventParticle).NoneOf(PlayerMatcher.Prediction));
		_selfPlayer = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Events, PlayerMatcher.FirstPersonUnityObjects, PlayerMatcher.EventParticle));
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		foreach (PlayerEntity player in _players)
		{
			if (player.events.Events == null)
			{
				continue;
			}
			foreach (int @event in player.events.Events)
			{
				VectorCoordConverter.SsjjToUnity(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()), out position);
				Process(player, player.currentWeapon.WeaponInfo.Name, position, @event);
				ProcessQkhh(player, @event);
				ProcessEventParticles(player, @event);
			}
			player.events.Events = null;
			ProcessUnpredictableEvenets(player);
		}
		if (_selfPlayer.count == 0)
		{
			return;
		}
		foreach (PlayerEntity item in _selfPlayer)
		{
			ProcessUnpredictableEvenets(item);
		}
	}

	private void ProcessUnpredictableEvenets(PlayerEntity entity)
	{
		if (entity.events.UnpredictableEvents == null)
		{
			return;
		}
		foreach (int unpredictableEvent in entity.events.UnpredictableEvents)
		{
			if (!ProcessEventParticles(entity, unpredictableEvent))
			{
				ProcessUnpredicatableSoundEvent(entity, unpredictableEvent);
			}
		}
		entity.events.UnpredictableEvents = null;
	}

	private bool ProcessUnpredicatableSoundEvent(PlayerEntity entity, int eventId)
	{
		if (eventId == 100050)
		{
			Process(entity, entity.currentWeapon.WeaponInfo.Name, position, eventId);
			return true;
		}
		return false;
	}

	public static bool ProcessEventParticles(PlayerEntity entity, int eventId)
	{
		if ((uint)(eventId - 100042) <= 7u)
		{
			HandleEvent(entity, eventId);
			return true;
		}
		return false;
	}

	private static void HandleEvent(PlayerEntity entity, int eventId)
	{
		EventParticleData eventParticleData = ParticleManager.Instance().GetEventParticleData(eventId);
		if (eventParticleData == null || !entity.hasEventParticle || entity.eventParticle.EventParticles == null)
		{
			return;
		}
		if (entity.eventParticle.EventParticles.Count > 0)
		{
			foreach (IEventParticle value2 in entity.eventParticle.EventParticles.Values)
			{
				if (value2.GetLevel() == eventParticleData.Level)
				{
					value2.ZeroEvent();
				}
			}
		}
		if (entity.eventParticle.EventParticles.TryGetValue(eventId, out var value))
		{
			value.hasRestarted = true;
			value.ResetEvent();
		}
		else
		{
			entity.eventParticle.EventParticles[eventId] = new EventParticle(eventParticleData.Time, eventParticleData.EventType, eventParticleData.Level);
		}
	}

	private void ProcessQkhh(PlayerEntity entity, int eventId)
	{
		switch (eventId)
		{
		case 1:
		case 11:
		case 47:
		case 59:
			entity.currentWeapon.WeaponInfo.EventLogic.PlayEvent(entity, eventId);
			break;
		case 79:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Explorde, entity.isMyPlayer, new AssetInfo("sound/biomechsound", "Assets/Res/Assets/sound/biomechsound/mechexplosion.mp3"), GameSoundManager.Config.WeaponVolume);
			break;
		case 33:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Other, entity.isMyPlayer, new AssetInfo("sound/deathmatch", "Assets/Res/Assets/sound/deathmatch/relive.mp3"), GameSoundManager.Config.AsideVolume);
			break;
		case 36:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Skill, entity.isMyPlayer, new AssetInfo("sound/ghostbiosound", $"Assets/Res/Assets/sound/ghostbiosound/lightning{Random.Range(0, 6)}.mp3"), GameSoundManager.Config.AsideVolume);
			break;
		case 54:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Skill, entity.isMyPlayer, new AssetInfo("sound/losttemple", "Assets/Res/Assets/sound/losttemple/shockwave.mp3"), GameSoundManager.Config.WeaponVolume);
			break;
		case 37:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Other, entity.isMyPlayer, new AssetInfo("sound/npcsound", "Assets/Res/Assets/sound/npcsound/killChicken.mp3"), GameSoundManager.Config.AsideVolume);
			break;
		case 69:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Explorde, entity.isMyPlayer, new AssetInfo("sound/pvecommon", "Assets/Res/Assets/sound/pvecommon/bowexplosion.mp3"), GameSoundManager.Config.WeaponVolume);
			break;
		case 106:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Explorde, entity.isMyPlayer, new AssetInfo("sound/pvecommon", "Assets/Res/Assets/sound/pvecommon/herocolddeathskill.mp3"), GameSoundManager.Config.WeaponVolume);
			break;
		case 67:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Operate, entity.isMyPlayer, new AssetInfo("sound/common", "Assets/Res/Assets/sound/common/pickweapon.mp3"), GameSoundManager.Config.EnvironmentVolume);
			break;
		case 90:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Explorde, entity.isMyPlayer, new AssetInfo("sound/deathmatch", "Assets/Res/Assets/sound/deathmatch/relive.mp3"), GameSoundManager.Config.AsideVolume);
			break;
		case 1141:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Skill, entity.isMyPlayer, new AssetInfo("sound/pvecommon", "Assets/Res/Assets/sound/pvecommon/ak47_legent_skill1.mp3"), GameSoundManager.Config.WeaponVolume);
			break;
		case 1145:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Skill, entity.isMyPlayer, new AssetInfo("sound/pvecommon", "Assets/Res/Assets/sound/pvecommon/ak47_legent_skill2.mp3"), GameSoundManager.Config.WeaponVolume);
			break;
		}
	}

	private AssetInfo GetSecondFireCipName(string weaponName)
	{
		if (weaponName == "rpg_redflash" || weaponName == "rpg_redflash1")
		{
			return SoundResourceUtility.GetWeaponSoundFireAssetInfo(weaponName);
		}
		return SoundResourceUtility.GetWeaponSoundSecFireAssetInfo(weaponName);
	}

	private void Process(PlayerEntity entity, string weaponName, Vector3 position, int eventId)
	{
		AssetInfo info = default(AssetInfo);
		switch (eventId)
		{
		case 1:
		case 47:
			info = SoundResourceUtility.GetWeaponSoundFireAssetInfo(weaponName);
			break;
		case 11:
			info = GetSecondFireCipName(weaponName);
			break;
		case 59:
			info = SoundResourceUtility.GetWeaponSoundFire3AssetInfo(weaponName);
			break;
		case 100050:
			info = SoundResourceUtility.GetWeaponSoundChangeAssetInfo(weaponName);
			break;
		}
		if ((string)info.AssetName != null)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Shoot, entity.isMyPlayer, info, position, GameSoundManager.Config.WeaponVolume, GameSoundManager.RollOffDistance.Distance94);
		}
		position = Vector3.zero;
	}
}
