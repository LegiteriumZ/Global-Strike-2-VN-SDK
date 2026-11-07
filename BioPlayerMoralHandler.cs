using Assets.Sources.Components.Message.Bochemical;
using Assets.Sources.Systems.PacketHandle.Handlers;
using NetData;

public class BioPlayerMoralHandler : ApcPacketHandler<BioPlayerMoralData>
{
	private MessageContext _messageContext;

	private PlayerContext _playerContext;

	public BioPlayerMoralHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 265;
	}

	public override void Handle(BioPlayerMoralData data)
	{
		BioMessageDataComponent bioMessageData = _messageContext.bioMessageData;
		if (_playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.GetId() == data.Id)
		{
			bioMessageData.MoralLv = data.TotalLV;
			bioMessageData.FrientAttack = data.FrientAttack;
			bioMessageData.GlobalAttack = data.GlobalAttack;
			bioMessageData.EliteAttack = data.EliteAttack;
			bioMessageData.id = data.Id;
			bioMessageData.MoralShow = data.Show;
		}
	}
}
