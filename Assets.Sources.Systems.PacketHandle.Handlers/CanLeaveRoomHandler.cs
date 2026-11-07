namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class CanLeaveRoomHandler : ApcPacketHandler<object>
{
	private readonly BattleRoomContext _battleRoomContext;

	public CanLeaveRoomHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 204;
	}

	public override void Handle(object data)
	{
		_battleRoomContext.gameState.InputDetectEnabled = true;
	}
}
