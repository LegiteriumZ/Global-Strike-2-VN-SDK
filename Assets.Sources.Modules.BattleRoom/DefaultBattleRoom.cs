using Assets.Sources.Components.Interface;

namespace Assets.Sources.Modules.BattleRoom;

public class DefaultBattleRoom : IBattleRoom
{
	private Contexts _contexts;

	public DefaultBattleRoom(Contexts contexts)
	{
		_contexts = contexts;
	}

	public int GetRaceType()
	{
		if (_contexts.battleRoom.hasRoomData)
		{
			return _contexts.battleRoom.roomData.Data.RaceType;
		}
		return -1;
	}

	public IPlayerEntity GetMyPlayer()
	{
		return _contexts.player.myPlayerEntity;
	}

	public IPlayerEntity GetPlayer(int entityId)
	{
		return _contexts.player.GetEntityWithEntityId(entityId);
	}

	public int GetRuleModel()
	{
		return _contexts.battleRoom.roomData.Data.RaceType;
	}

	public int GetTeamSuggestFlag()
	{
		return 2;
	}

	public int GetRenderTime()
	{
		return _contexts.time.time.RenderTime;
	}

	public string GetFreeType()
	{
		return _contexts.battleRoom.roomData.Data.FreeType;
	}
}
