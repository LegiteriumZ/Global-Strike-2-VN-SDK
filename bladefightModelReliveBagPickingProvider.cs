using Assets.Sources.Components.GameRule.Blade;
using Assets.Sources.Components.Time;

public class bladefightModelReliveBagPickingProvider : IbladefightModelReliveBagPickingProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bladefightModelReliveBagPickingProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		BladeFightReliveBagPickingDataComponent bladeFightReliveBagPickingData = _gameRuleContext.bladeFightReliveBagPickingData;
		bladeFightReliveBagPickingData.time += time.FrameInterval;
		if (bladeFightReliveBagPickingData.time < 0)
		{
			bladeFightReliveBagPickingData.time = 0;
		}
	}

	public float getProgress()
	{
		BladeFightReliveBagPickingDataComponent bladeFightReliveBagPickingData = _gameRuleContext.bladeFightReliveBagPickingData;
		if (bladeFightReliveBagPickingData.maxTime == 0)
		{
			return 0f;
		}
		return (float)bladeFightReliveBagPickingData.time / (float)bladeFightReliveBagPickingData.maxTime;
	}

	public bool isShow()
	{
		BladeFightReliveBagPickingDataComponent bladeFightReliveBagPickingData = _gameRuleContext.bladeFightReliveBagPickingData;
		return bladeFightReliveBagPickingData.time < bladeFightReliveBagPickingData.maxTime;
	}
}
