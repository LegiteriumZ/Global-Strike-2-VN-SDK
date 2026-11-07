using Assets.Generated.Table;
using Assets.Sources.Info.Sound;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class TacticsSoundHandler : ApcPacketHandler<TacticsSoundData>
{
	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	private TacticsSoundModel _tactics;

	private ChatContext _chatContext;

	public TacticsSoundHandler(Contexts contexts)
	{
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
		_chatContext = contexts.chat;
	}

	public override int MethodId()
	{
		return 22;
	}

	public override void Handle(TacticsSoundData data)
	{
		if (!_playerContext.isMyPlayer || _battleRoomContext.roomData.IsObserver)
		{
			return;
		}
		if (_tactics == null)
		{
			_tactics = new TacticsSoundModel();
			_tactics.IsWoman = _battleRoomContext.roomData.IsWoman;
			_tactics.AddSoundList(_battleRoomContext.roomData.Data.RaceType, _battleRoomContext.roomData.IsWoman, 0);
		}
		PlayerEntity entityWithEntityId = _playerContext.GetEntityWithEntityId(data.PlayerId);
		if (entityWithEntityId != null)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Tactics, entityWithEntityId.isMyPlayer, new AssetInfo("sound/" + (_tactics.IsWoman ? "tacticswoman" : "tactics"), "Assets/Res/Assets/" + _tactics.GetUrlByIndex(data.SoundId)), GameSoundManager.Config.AsideVolume);
			if (!entityWithEntityId.hasTacticsSound)
			{
				entityWithEntityId.AddTacticsSound(data.SoundId, 4000);
			}
			else
			{
				entityWithEntityId.tacticsSound.SoundId = data.SoundId;
				entityWithEntityId.tacticsSound.RemainTime = 4000;
			}
			if (_chatContext.hasChatJobHistroy)
			{
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message from=\"{2}\" type=\"{0}\" ><body>{1}</body></message>", "tacticsSound", _tactics.GetChattingGuiTextByIndex(data.SoundId), data.PlayerName));
			}
		}
	}
}
