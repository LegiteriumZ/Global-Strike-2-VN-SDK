using System;
using Assets.Sources.Free.Data;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GameMessageDataHandler : ApcPacketHandler<GameMessageData>
{
	private MessageContext _messageContext;

	public GameMessageDataHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 35;
	}

	public override void Handle(GameMessageData data)
	{
		if (data.Type == GameMessageType.CANNOTBEUSED)
		{
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("CAN_NOT_USE"), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.NOTUSEDNEXTTIME)
		{
			_messageContext.messageRemindData.SetMessage(string.Format(ScriptLocalization.Get("NOT_USED_NEXT_TIME"), data.Time), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.DARTSREDFLASHDESTORY)
		{
			_messageContext.messageRemindData.SetMessage(string.Format(ScriptLocalization.Get("DARTS_REDFLASH_DESTROY"), data.Time), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.DARTSREDFLASHDESTORYED)
		{
			_messageContext.messageRemindData.SetMessage(string.Format(ScriptLocalization.Get("DARTS_REDFLASH_DESTROYED"), data.Time), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.DARTSREDFLASHRETURNDESTORY)
		{
			_messageContext.messageRemindData.SetMessage(string.Format(ScriptLocalization.Get("DARTS_REDFLASH_RETURNDESTORY"), data.Time), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.SELECTEDBAGLOCKED)
		{
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("SELECTEDBAG_LOCKED"), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.BLOCKCOMBINEDNOENOUGH2)
		{
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BLOCK_COMBINED_CONNON_NOENOUGH").Replace("%d", StringCache.IntToString(data.Time)), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.BLOCKCOMBINEDBUILD2)
		{
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BLOCK_COMBINED_CONNON_BUILD"), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.USEGAMEPLUSCANNOTUSEWEAPON)
		{
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("USE_GAMEPLUS_CANNOT_USE_WEAPON"), 86400000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.OVERDISTANCE)
		{
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("OVER_DISTANCE"), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.WAITPLAYER)
		{
			GameModelLocator.GetInstance().GameModel.IsMatchWaitPlayer = true;
		}
		else if (data.Type == GameMessageType.GAMESTART)
		{
			GameModelLocator.GetInstance().GameModel.IsMatchWaitPlayer = false;
		}
		else if (data.Type == GameMessageType.RESISTREMAINTIMES)
		{
			_messageContext.messageRemindData.SetMessage(string.Format(ScriptLocalization.Get("RESIST_VARIATION_WITH_REMAIN"), data.Time), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.NOFAKER)
		{
			_messageContext.messageRemindData.SetMessage(string.Format(ScriptLocalization.Get("NoFaker"), data.Time), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else if (data.Type == GameMessageType.AK47DOMINATIONREFESHCD)
		{
			_messageContext.messageRemindData.SetMessage(string.Format(ScriptLocalization.Get("AK47DOMINATIONREFESHCD"), Math.Ceiling((float)data.Time * 0.001f)), 1000);
			NotifyManager.ForceInvoke(38);
		}
		else
		{
			_messageContext.gameMessageData.MessageData = data;
		}
	}
}
