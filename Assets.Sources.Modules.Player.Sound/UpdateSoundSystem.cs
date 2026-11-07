using Assets.Generated.Table;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Sound;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Sound;

public class UpdateSoundSystem : IPlaybackSystem
{
	private readonly BattleRoomContext _battleRoomContext;

	private readonly PlayerContext _playerContext;

	private bool _bioGameStartSoundPlayed;

	private string _playingSound;

	public UpdateSoundSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public void OnPlayback()
	{
		PlayBioGameStartSound();
	}

	private void PlayBioGameStartSound()
	{
		if (!_battleRoomContext.hasRoomData || !_playerContext.isMyPlayer || _battleRoomContext.hasSectionTime || !RuleUtilty.IsPlayBioStartSoundMode(_battleRoomContext.roomData.Data.RaceType))
		{
			return;
		}
		int num = 15000;
		if (_battleRoomContext.roomData.Data.RaceType == 33)
		{
			num = 25000;
		}
		int passed = _battleRoomContext.sectionTime.Passed;
		if (passed > 4000 && passed < num)
		{
			int num2 = (int)((double)(num - passed) * 0.001);
			if (num2 <= 0)
			{
				return;
			}
			string text = $"Assets/Res/Assets/sound/bioGameStart/{num2}.mp3";
			if (_playingSound != text)
			{
				_bioGameStartSoundPlayed = true;
				_playingSound = text;
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/biogamestart", _playingSound), GameSoundManager.Config.AsideVolume);
			}
		}
		if (_battleRoomContext.roomData.Data.RaceType == 17)
		{
			if (passed > 17000 && _bioGameStartSoundPlayed)
			{
				_bioGameStartSoundPlayed = false;
				int num3 = Random.Range(0, 5);
				string assetName = $"Assets/Res/Assets/sound/ghostbiosound/dounstart{num3}.mp3";
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/ghostbiosound", assetName), GameSoundManager.Config.AsideVolume);
			}
			if (_battleRoomContext.roomData.WarningLv > 0 && (PlayerCareerConstantUtility.IsHumanity(_playerContext.myPlayerEntity.basicInfo.Current.Career) || PlayerCareerConstantUtility.IsHero(_playerContext.myPlayerEntity.basicInfo.Current.Career)))
			{
				string assetName2 = $"Assets/Res/Assets/sound/ghostbiosound/annunciator{_battleRoomContext.roomData.WarningLv}.mp3";
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/ghostbiosound", assetName2), GameSoundManager.Config.AsideVolume);
			}
		}
	}
}
