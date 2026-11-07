using System.Collections.Generic;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class CyberRpgMessageHandle : ApcPacketHandler<CyberRpgMessageData>
{
	private MessageContext _messageContext;

	private GameRuleContext _gameRuleContext;

	public CyberRpgMessageHandle(Contexts contexts)
	{
		_messageContext = contexts.message;
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 701;
	}

	public override void Handle(CyberRpgMessageData data)
	{
		switch (data.Type)
		{
		case CyberRpgMessageType.LIVEENERGYCHANGE:
			_messageContext.cyberRpg.energy = data.Energy;
			break;
		case CyberRpgMessageType.ESCAPEAREAEXIST:
			_messageContext.cyberRpg.exittime = data.Timer;
			break;
		case CyberRpgMessageType.STARTESCAPE:
			_gameRuleContext.gameProgressData.CurrentProgressTime = 0;
			_gameRuleContext.gameProgressData.ProgressTotalTime = data.Timer;
			_gameRuleContext.gameProgressData.ProgressType = ProgressType.ACTIVE;
			NotifyManager.ForceInvoke(11);
			_gameRuleContext.gameProgressData.PlayerName = "";
			_gameRuleContext.gameProgressData.Details = "";
			break;
		case CyberRpgMessageType.CANCELESCAPE:
			_gameRuleContext.gameProgressData.ProgressTotalTime = 0;
			_gameRuleContext.gameProgressData.ProgressType = ProgressType.ACTIVE;
			NotifyManager.ForceInvoke(11);
			_gameRuleContext.gameProgressData.PlayerName = "";
			_gameRuleContext.gameProgressData.Details = "";
			break;
		case CyberRpgMessageType.ADDDROPITEMS:
		{
			if (_messageContext.cyberRpg.dropItems == null)
			{
				_messageContext.cyberRpg.dropItems = new List<DropItem>();
			}
			for (int i = 0; i < data.Items.Count; i++)
			{
				bool flag = true;
				for (int j = 0; j < _messageContext.cyberRpg.dropItems.Count; j++)
				{
					if (_messageContext.cyberRpg.dropItems[j].ItemId == data.Items[i].ItemId && _messageContext.cyberRpg.dropItems[j].ItemType == data.Items[i].ItemType)
					{
						flag = false;
						_messageContext.cyberRpg.dropItems[j].Num += data.Items[i].Num;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				_messageContext.cyberRpg.dropItems.Add(data.Items[i]);
				_messageContext.cyberRpg.dropItems.Sort(delegate(DropItem a, DropItem b)
				{
					if (a.Lv > b.Lv)
					{
						return -1;
					}
					return (a.Lv < b.Lv) ? 1 : 0;
				});
			}
			NotifyManager.ForceInvoke(154);
			break;
		}
		}
	}
}
