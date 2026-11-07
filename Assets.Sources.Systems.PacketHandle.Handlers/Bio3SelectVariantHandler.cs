using Assets.Sources.Constant;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class Bio3SelectVariantHandler : ApcPacketHandler<SelectZombieData>
{
	private readonly GameRuleContext _gameRuleContext;

	private readonly BattleRoomContext _battleRoomContext;

	public Bio3SelectVariantHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 239;
	}

	public override void Handle(SelectZombieData data)
	{
		_gameRuleContext.selectZombie.Data = data;
		if (RuleUtilty.IsBioEvoLutionMode(_battleRoomContext.roomData.Data.RaceType))
		{
			_gameRuleContext.selectZombie.Time = 10000;
		}
		else if (_battleRoomContext.roomData.Data.RaceType == 6 || _battleRoomContext.roomData.Data.RaceType == 14)
		{
			_gameRuleContext.selectZombie.Time = 6000;
		}
		else
		{
			_gameRuleContext.selectZombie.Time = 3000;
		}
	}
}
