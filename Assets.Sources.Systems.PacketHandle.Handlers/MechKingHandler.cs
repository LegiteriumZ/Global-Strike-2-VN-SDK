using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class MechKingHandler : ApcPacketHandler<MechKingMessageData>
{
	private GameRuleContext _gameRuleContext;

	public MechKingHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 337;
	}

	public override void Handle(MechKingMessageData data)
	{
		if (data.Type == MechKingMessageType.POWERSTATUS)
		{
			_gameRuleContext.mechKingData._Lv = data.IntData[0];
			_gameRuleContext.mechKingData._exp = data.IntData[1];
			_gameRuleContext.mechKingData._maxexp = data.IntData[2];
		}
		if (data.Type == MechKingMessageType.POWERSTATUS)
		{
			_gameRuleContext.mechKingData._Lv = data.IntData[0];
			_gameRuleContext.mechKingData._exp = data.IntData[1];
			_gameRuleContext.mechKingData._maxexp = data.IntData[2];
		}
		if (data.Type == MechKingMessageType.SECTIONSTARTMECH)
		{
			_gameRuleContext.mechKingData._showmessagemech = true;
		}
		if (data.Type == MechKingMessageType.SECTIONSTARTHUAMN)
		{
			_gameRuleContext.mechKingData._showmessagehuamn = true;
		}
		if (data.Type == MechKingMessageType.ESCAPESTART)
		{
			_gameRuleContext.mechKingData._showTime = data.IntData[0];
		}
		if (data.Type == MechKingMessageType.CANPICKSTATUS)
		{
			_gameRuleContext.mechKingData._showweapon = data.BoolData[0];
		}
		if (data.Type == MechKingMessageType.SELECTMECHLATER)
		{
			_gameRuleContext.mechKingData._startTime = data.IntData[0];
		}
		if (data.Type == MechKingMessageType.SHOWTAG)
		{
			_gameRuleContext.mechKingData.showMarks = data.BoolData[0];
		}
	}
}
