using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Blade;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BattleRoomEventHandler : ApcPacketHandler<BattleRoomEventData>
{
	private readonly GameRuleContext _gameRuleContext;

	private static Dictionary<string, int> _bladefightEvent = new Dictionary<string, int>
	{
		{ "BLADE_FIGHT_SPEED", 1 },
		{ "BLADE_FIGHT_JUMP", 2 },
		{ "BLADE_FIGHT_DOUBLEJUMP", 3 },
		{ "BLADE_FIGHT_WEIGHTLESS", 4 },
		{ "BLADE_FIGHT_ATTACKDISTANCE", 5 },
		{ "BLADE_FIGHT_HPMAX", 6 },
		{ "BLADE_FIGHT_HPRECOVER", 7 },
		{ "BLADE_FIGHT_DAMAGE", 8 }
	};

	private static Dictionary<string, int> _bioEvoluttonEvent = new Dictionary<string, int>
	{
		{ "BLADE_FIGHT_SPEED_ZOMBIE", 1 },
		{ "BLADE_FIGHT_JUMP_ZOMBIE", 2 },
		{ "BLADE_FIGHT_DOUBLEJUMP_ZOMBIE", 3 },
		{ "BLADE_FIGHT_WEIGHTLESS_ZOMBIE", 4 },
		{ "BLADE_FIGHT_ATTACKDISTANCE_ZOMBIE", 5 },
		{ "BLADE_FIGHT_HPMAX_ZOMBIE", 6 },
		{ "BLADE_FIGHT_HPRECOVER_ZOMBIE", 7 },
		{ "BLADE_FIGHT_DAMAGE_ZOMBIE", 8 }
	};

	public BattleRoomEventHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 333;
	}

	public override void Handle(BattleRoomEventData data)
	{
		BattleRoomEventComponent battleRoomEvent = _gameRuleContext.battleRoomEvent;
		battleRoomEvent.index = "";
		List<int> list = new List<int>();
		foreach (string item in data.Event)
		{
			if (_bladefightEvent.ContainsKey(item))
			{
				list.Add(_bladefightEvent[item]);
			}
		}
		foreach (string item2 in data.Event)
		{
			if (_bioEvoluttonEvent.ContainsKey(item2) && !list.Contains(_bioEvoluttonEvent[item2]))
			{
				list.Add(_bioEvoluttonEvent[item2]);
			}
		}
		list.Sort();
		if (list.Count == 1)
		{
			battleRoomEvent.index = list[0].ToString();
		}
		else if (data.Event.Count > 1)
		{
			foreach (int item3 in list)
			{
				battleRoomEvent.index = battleRoomEvent.index + item3 + "_";
			}
			battleRoomEvent.index = battleRoomEvent.index.Substring(0, battleRoomEvent.index.Length - 1);
		}
		battleRoomEvent.time = 3000;
	}
}
