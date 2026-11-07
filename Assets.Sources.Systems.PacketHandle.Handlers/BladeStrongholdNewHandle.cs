using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class BladeStrongholdNewHandle : ApcPacketHandler<BladeStrongholdNewMessageData>
{
	private GameRuleContext _gameRuleContext;

	public BladeStrongholdNewHandle(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 801;
	}

	public override void Handle(BladeStrongholdNewMessageData data)
	{
		BladeStrongholdData data2 = data.Data;
		if (_gameRuleContext.bladeStrongholdNewData.data == null)
		{
			_gameRuleContext.bladeStrongholdNewData.data = new BladeStrongholdData();
		}
		_gameRuleContext.bladeStrongholdNewData.data.Team1Num = data2.Team1Num;
		_gameRuleContext.bladeStrongholdNewData.data.Team2Num = data2.Team2Num;
		_gameRuleContext.bladeStrongholdNewData.data.Progress1 = data2.Progress1;
		_gameRuleContext.bladeStrongholdNewData.data.Progress2 = data2.Progress2;
		_gameRuleContext.bladeStrongholdNewData.data.State = data2.State;
		_gameRuleContext.bladeStrongholdNewData.data.Occupy = data2.Occupy;
		_gameRuleContext.bladeStrongholdNewData.data.RemainTime = data2.RemainTime;
		_gameRuleContext.bladeStrongholdNewData.data.AllTime = data2.AllTime;
	}
}
