namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class CanNotLeaveRoomHandler : ApcPacketHandler<object>
{
	private readonly BattleRoomContext _battleRoomContext;

	public CanNotLeaveRoomHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 205;
	}

	public override void Handle(object data)
	{
		_battleRoomContext.gameState.InputDetectEnabled = false;
	}
}
