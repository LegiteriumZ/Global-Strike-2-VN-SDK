using Assets.Sources.Components.Time;
using SSJJMath;

public class freeRpg_107000ModelExpProgressProvider : IfreeRpg_107000ModelExpProgressProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public freeRpg_107000ModelExpProgressProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.mystery.IsExpProgress)
		{
			_gameRuleContext.mystery.FireExpStartTime += time.FrameInterval;
		}
	}

	public bool IsShowExp()
	{
		return _gameRuleContext.mystery.IsExpProgress;
	}

	public float SetFirePercent()
	{
		return (float)_gameRuleContext.mystery.FirePercent / 100f;
	}

	public string SetFirePercentText()
	{
		return _gameRuleContext.mystery.FirePercent + "%";
	}

	public string SwitchAni()
	{
		int textureIndex = FlashMaths.GetTextureIndex(0, 11, 41.5f, _gameRuleContext.mystery.FireExpStartTime, repeat: true);
		if (_gameRuleContext.mystery.FireType == 1)
		{
			return $"/ui/GameGUIRes/freeRpg_107000Model/fire_lv01/fire_lv01_{textureIndex}";
		}
		if (_gameRuleContext.mystery.FireType == 2)
		{
			return $"/ui/GameGUIRes/freeRpg_107000Model/fire_lv02/fire_lv02_{textureIndex}";
		}
		return $"/ui/GameGUIRes/freeRpg_107000Model/fire_lv03/fire_lv03_{textureIndex}";
	}

	public bool IsFire()
	{
		return _gameRuleContext.mystery.IsFire;
	}
}
