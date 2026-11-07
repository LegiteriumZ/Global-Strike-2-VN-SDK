using Assets.Sources.Components.Time;
using UnityEngine;

public class bioModelMaolinProgressProvider : IbioModelMaolinProgressProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bioModelMaolinProgressProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.bioMaolingUI.show)
		{
			_gameRuleContext.bioMaolingUI.time1 += time.FrameInterval;
		}
	}

	public float getPercent()
	{
		return (float)_gameRuleContext.bioMaolingUI.time1 / (float)_gameRuleContext.bioMaolingUI.time2;
	}

	public bool isShow()
	{
		return _gameRuleContext.bioMaolingUI.show;
	}

	public bool isLightShow()
	{
		return _gameRuleContext.bioMaolingUI.time1 >= _gameRuleContext.bioMaolingUI.time2;
	}

	public float getLightEffectAlpha()
	{
		int time = _gameRuleContext.bioMaolingUI.time1;
		int time2 = _gameRuleContext.bioMaolingUI.time2;
		if (time < time2)
		{
			return 0f;
		}
		float num = 500f;
		float num2 = num / 2f;
		float num3 = (float)(time - time2) % num;
		return 1f - Mathf.Abs(num2 - num3) / num2;
	}
}
