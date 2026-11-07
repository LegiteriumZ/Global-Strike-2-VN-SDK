using Assets.Generated.Table;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class DeathMatchMessageExpHandler : ApcPacketHandler<DeathMatchMessageData>
{
	private PlayerContext _playerContext;

	public DeathMatchMessageExpHandler(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 56;
	}

	public override void Handle(DeathMatchMessageData data)
	{
		if (_playerContext.isMyPlayer && data.Type == DeathMatchMessageType.RELIVESOUND)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/deathmatch", "Assets/Res/Assets/sound/deathmatch/helprelive.mp3"), GameSoundManager.Config.AsideVolume);
		}
	}
}
