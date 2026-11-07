using Assets.Generated.Table;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GhostBioMessageHandler : ApcPacketHandler<GhostBioMessageData>
{
	private BattleRoomContext _battleRoomContext;

	public GhostBioMessageHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 63;
	}

	public override void Handle(GhostBioMessageData data)
	{
		switch (data.Type)
		{
		case GhostBioMessageType.WARNING:
			_battleRoomContext.roomData.WarningLv = data.WarningLv;
			break;
		case GhostBioMessageType.ZOMBIESOUND:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Other, isMyself: false, new AssetInfo("sound/ghostbiosound", $"Assets/Res/Assets/sound/ghostbiosound/dounsound{data.ZombieSoundId}.mp3"), GameSoundManager.Config.AsideVolume);
			break;
		}
	}
}
