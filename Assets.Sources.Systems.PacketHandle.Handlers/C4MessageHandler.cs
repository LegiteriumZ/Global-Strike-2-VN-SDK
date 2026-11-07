using Assets.Generated.Table;
using Assets.Sources.Utils.Sound;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class C4MessageHandler : ApcPacketHandler<C4MessageData>
{
	private MessageContext _messageContext;

	private PlayerContext _playerContext;

	public C4MessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 16;
	}

	public override void Handle(C4MessageData data)
	{
		_messageContext.blastMessageData.PlayerName = data.PlayerName;
		_messageContext.blastMessageData.Type = data.Type;
		_messageContext.blastMessageData.Changed = true;
		NotifyManager.ForceInvoke(48);
		_messageContext.blastMessageData.GoldMessageChanged = true;
		NotifyManager.ForceInvoke(25);
		_messageContext.blastMessageData.GameOverGuiChanged = true;
		NotifyManager.ForceInvoke(50);
		_messageContext.blastMessageData.GhostMessageChanged = true;
		NotifyManager.ForceInvoke(59);
		switch (data.Type)
		{
		case C4MessageType.ACTIVE:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/c4", "Assets/Res/Assets/sound/c4/c4active.mp3"), GameSoundManager.Config.WeaponVolume);
			break;
		case C4MessageType.DEMOLITIONSUCCESS:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.Operate, data.PlayerName == _playerContext.myPlayerEntity.basicInfo.PlayerName, new AssetInfo("sound/c4", "Assets/Res/Assets/sound/c4/c4demolition.mp3"), VectorCoordConverter.SsjjToUnity(new Vector3(data.X, data.Y, data.Z)), GameSoundManager.Config.WeaponVolume, 10000);
			break;
		case C4MessageType.FINDC4INA:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/common", "Assets/Res/Assets/sound/common/findc4a.mp3"), GameSoundManager.Config.AsideVolume);
			break;
		case C4MessageType.FINDC4INB:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/common", "Assets/Res/Assets/sound/common/findc4b.mp3"), GameSoundManager.Config.AsideVolume);
			break;
		case C4MessageType.FALLING:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/common", "Assets/Res/Assets/sound/common/fallc4.mp3"), GameSoundManager.Config.AsideVolume);
			break;
		case C4MessageType.PICKUP:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/common", "Assets/Res/Assets/sound/common/pickup.mp3"), GameSoundManager.Config.WeaponVolume);
			break;
		case C4MessageType.SINGLEDWINNING:
		case C4MessageType.AMULTIWIN:
			break;
		}
	}
}
