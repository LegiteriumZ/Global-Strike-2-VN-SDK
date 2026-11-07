using Assets.Sources.Components.Time;

public class rpgTreasureBossModelTreasureBossBtnCsUIProvider : IrpgTreasureBossModelTreasureBossBtnCsUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	public rpgTreasureBossModelTreasureBossBtnCsUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool checkRootShow()
	{
		if (_playerContext.cameraOwnerEntity.skill.Skills.TryGetValue(103, out var value))
		{
			return value.Kind == 14;
		}
		return false;
	}

	public bool skillIsActive()
	{
		if (_playerContext.cameraOwnerEntity.skill.Skills.TryGetValue(103, out var value))
		{
			return value.CurrentCdTime <= 0;
		}
		return false;
	}

	public float getSkillCd()
	{
		if (_playerContext.cameraOwnerEntity.skill.Skills.TryGetValue(103, out var value))
		{
			return value.CurrentCdTime / 1000;
		}
		return 0f;
	}
}
