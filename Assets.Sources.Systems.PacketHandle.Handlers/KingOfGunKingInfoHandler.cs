using Assets.Generated.Table;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class KingOfGunKingInfoHandler : ApcPacketHandler<KingOfGunScoreData>
{
	private PlayerContext _playerContext;

	private GameRuleContext _gameRuleContext;

	public KingOfGunKingInfoHandler(Contexts contexts)
	{
		_playerContext = contexts.player;
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 45;
	}

	public override void Handle(KingOfGunScoreData data)
	{
		_gameRuleContext.gunKingTeamScoreData.GunkingPhase = data.Lv;
		_gameRuleContext.gunKingTeamScoreData.GunkingPlayerName = data.PlayerName;
		_gameRuleContext.gunKingTeamScoreData.GunkingPlayerId = data.PlayerId;
		_gameRuleContext.gunKingTeamScoreData.GunkingKillCount = data.CurKillNum;
		_gameRuleContext.gunKingTeamScoreData.GunkingPhaseKillCount = data.MaxKillNum;
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			if (data.PlayerId == myPlayerEntity.basicInfo.Current.Id && !myPlayerEntity.isLastHaveAce)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/common", "Assets/Res/Assets/sound/common/getace.mp3"), GameSoundManager.Config.AsideVolume);
				myPlayerEntity.isLastHaveAce = true;
			}
			else if (data.PlayerId != myPlayerEntity.basicInfo.Current.Id && myPlayerEntity.isLastHaveAce)
			{
				MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/common", "Assets/Res/Assets/sound/common/lostace.mp3"), GameSoundManager.Config.AsideVolume);
				myPlayerEntity.isLastHaveAce = false;
			}
		}
	}
}
