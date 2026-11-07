using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GroupKingOfGunMessageHandler : ApcPacketHandler<GroupKingOfGunMessageData>
{
	private MessageContext _messageContext;

	public GroupKingOfGunMessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 50;
	}

	public override void Handle(GroupKingOfGunMessageData data)
	{
		_messageContext.groupGunKingMessageData.Type = (int)data.Type;
		NotifyManager.ForceInvoke(24);
		_messageContext.groupGunKingMessageData.Phase = data.Lv;
		_messageContext.groupGunKingMessageData.WinTeam = data.WinTeam;
		_messageContext.groupGunKingMessageData.PhaseScore = data.Score;
		if (data.WinTeam == 1)
		{
			_messageContext.groupGunKingMessageData.WinScore = data.Team1KillNum;
			_messageContext.groupGunKingMessageData.LoseScore = data.Team2KillNum;
		}
		else
		{
			_messageContext.groupGunKingMessageData.WinScore = data.Team2KillNum;
			_messageContext.groupGunKingMessageData.LoseScore = data.Team1KillNum;
		}
	}
}
