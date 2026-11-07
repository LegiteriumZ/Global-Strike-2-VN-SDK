using data;
using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class ContextInfo : IContextInfo
{
	public static IContextInfo Instance = new ContextInfo();

	public static bool IsDebug = false;

	public bool IsWeightless()
	{
		if (Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld().GetSceneMoveData() is SceneMoveData sceneMoveData)
		{
			return sceneMoveData.isWeightlessness;
		}
		return false;
	}

	public int GetRealRaceType()
	{
		return Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
	}

	public bool IsPredicateDebug()
	{
		return false;
	}

	public void SetPredicateDebug(bool debug)
	{
	}
}
