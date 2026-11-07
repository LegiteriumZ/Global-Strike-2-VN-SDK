using Assets.Scripts.Utility.Sound;
using NetData;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PeekabooMissionReportHandler : ApcPacketHandler<PeekabooResultScoreData>
{
	private BattleRoomContext _roomContext;

	private PlayerContext _playerContext;

	public PeekabooMissionReportHandler(Contexts contexts)
	{
		_roomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 78;
	}

	public override void Handle(PeekabooResultScoreData data)
	{
		bool flag = data.WinTeam == _playerContext.myPlayerEntity.GetTeam();
		MonoBehaviourSingleton<AutoSoundManager>.Instance.OnAutoSound((!flag) ? AutoSoundEventType.Lose : AutoSoundEventType.Win);
		_roomContext.gameOver.peekabooMissionChange = true;
		_roomContext.gameOver.peekabooData = data;
	}
}
