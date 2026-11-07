using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Components.Time;
using UnityEngine;

public class commonSkatePressGuiProvider : IcommonSkatePressGuiProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public commonSkatePressGuiProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool getVisible()
	{
		SkatePressComponent skatePress = _gameRuleContext.skatePress;
		if (skatePress != null && skatePress.IsPress)
		{
			return Time.time - skatePress.StartTime < skatePress.RemainTime;
		}
		return false;
	}

	public float getProgress()
	{
		SkatePressComponent skatePress = _gameRuleContext.skatePress;
		if (skatePress != null && skatePress.IsPress && Time.time - skatePress.StartTime < skatePress.RemainTime)
		{
			return (Time.time - skatePress.StartTime) / skatePress.RemainTime;
		}
		return 0f;
	}
}
