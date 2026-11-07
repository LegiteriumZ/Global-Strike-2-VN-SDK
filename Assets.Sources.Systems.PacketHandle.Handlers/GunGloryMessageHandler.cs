using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GunGloryMessageHandler : ApcPacketHandler<GunGloryMessageData>
{
	private GameRuleContext _gameRuleContext;

	public GunGloryMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 128;
	}

	public override void Handle(GunGloryMessageData data)
	{
		int type = (int)data.Type;
		int i;
		for (i = 0; i < _gameRuleContext.gunGlory.GunGloryList.Count && type != _gameRuleContext.gunGlory.GunGloryList[i]; i++)
		{
			if (type < _gameRuleContext.gunGlory.GunGloryList[i])
			{
				_gameRuleContext.gunGlory.GunGloryList.Insert(i, type);
				break;
			}
		}
		if (i == _gameRuleContext.gunGlory.GunGloryList.Count)
		{
			_gameRuleContext.gunGlory.GunGloryList.Add(type);
		}
		_gameRuleContext.gunGlory.GunGloryDelayShow = 1500;
	}
}
