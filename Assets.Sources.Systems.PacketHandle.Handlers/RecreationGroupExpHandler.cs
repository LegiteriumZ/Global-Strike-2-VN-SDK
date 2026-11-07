using Assets.Generated.Table;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class RecreationGroupExpHandler : ApcPacketHandler<RecreationGroupExpData>
{
	private PlayerContext _playerContext;

	public RecreationGroupExpHandler(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 54;
	}

	public override void Handle(RecreationGroupExpData data)
	{
		if (_playerContext.isMyPlayer && data.LvUp)
		{
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/player", "Assets/Res/Assets/sound/player/pl_levelup.mp3"), GameSoundManager.Config.AsideVolume);
		}
	}
}
