using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PersonalityListHandler : ApcPacketHandler<PersonalityListData>
{
	private BattleRoomContext _battleRoomContext;

	public PersonalityListHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
	}

	public override int MethodId()
	{
		return 229;
	}

	public override void Handle(PersonalityListData data)
	{
		_battleRoomContext.playerInfo.PersonalizedDic.Clear();
		foreach (PersonalityData item in data.List)
		{
			int pageType = GetPageType(item.PersonalityType);
			if (!_battleRoomContext.playerInfo.PersonalizedDic.TryGetValue(pageType, out var value))
			{
				value = (_battleRoomContext.playerInfo.PersonalizedDic[pageType] = new List<PersonalityData>());
			}
			while (value.Count <= item.Id)
			{
				value.Add(null);
			}
			value[item.Id] = item;
		}
	}

	private int GetPageType(PersonalityType personalityType)
	{
		return personalityType switch
		{
			PersonalityType.GAMEEMOJI => 1, 
			PersonalityType.PLAYERSOUND => 2, 
			_ => 0, 
		};
	}
}
