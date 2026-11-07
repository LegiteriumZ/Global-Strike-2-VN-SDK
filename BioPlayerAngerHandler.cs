using Assets.Sources.Components.Message.Bochemical;
using Assets.Sources.Systems.PacketHandle.Handlers;
using NetData;

public class BioPlayerAngerHandler : ApcPacketHandler<BioPlayerAngerData>
{
	private MessageContext _messageContext;

	private PlayerContext _playerContext;

	public BioPlayerAngerHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 264;
	}

	public override void Handle(BioPlayerAngerData data)
	{
		BioMessageDataComponent bioMessageData = _messageContext.bioMessageData;
		if (_playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.GetId() == data.Id)
		{
			bioMessageData.AngleLv = data.AngerLv;
			bioMessageData.id = data.Id;
			bioMessageData.FrientAttack = data.Hp;
			bioMessageData.EliteAttack = data.Height;
			bioMessageData.AngleShow = data.Show;
		}
	}
}
