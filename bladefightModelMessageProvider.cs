using Assets.Sources.Components.GameRule.Blade;
using Assets.Sources.Components.Time;

public class bladefightModelMessageProvider : IbladefightModelMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public bladefightModelMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		BladeFightMessageDataComponent bladeFightMessageData = _gameRuleContext.bladeFightMessageData;
		bladeFightMessageData.topMessageTime -= time.FrameInterval;
		bladeFightMessageData.bottonMessageTime -= time.FrameInterval;
		if (bladeFightMessageData.topMessageTime < 0)
		{
			bladeFightMessageData.isWaitRealStart = false;
			bladeFightMessageData.isFogAreaRefresh = false;
			bladeFightMessageData.isSafeAreaRefresh = false;
		}
		if (bladeFightMessageData.bottonMessageTime < 0)
		{
			bladeFightMessageData.isGetEnergyPack = false;
			bladeFightMessageData.isTargetGetEnergyPack = false;
		}
	}

	public bool isFogAreaRefresh()
	{
		BladeFightMessageDataComponent bladeFightMessageData = _gameRuleContext.bladeFightMessageData;
		if (bladeFightMessageData.isFogAreaRefresh)
		{
			return bladeFightMessageData.topMessageTime > 0;
		}
		return false;
	}

	public bool isWaitRealStart()
	{
		BladeFightMessageDataComponent bladeFightMessageData = _gameRuleContext.bladeFightMessageData;
		if (bladeFightMessageData.isWaitRealStart)
		{
			return bladeFightMessageData.topMessageTime > 0;
		}
		return false;
	}

	public float getWaitRealStartTime()
	{
		return _gameRuleContext.bladeFightMessageData.topMessageTime / 1000;
	}

	public bool isSafeAreaRefresh()
	{
		BladeFightMessageDataComponent bladeFightMessageData = _gameRuleContext.bladeFightMessageData;
		if (bladeFightMessageData.isSafeAreaRefresh)
		{
			return bladeFightMessageData.topMessageTime > 0;
		}
		return false;
	}

	public bool isObserve()
	{
		return _gameRuleContext.bladeFightMessageData.isObserver;
	}

	public bool isGetEnergyPack()
	{
		BladeFightMessageDataComponent bladeFightMessageData = _gameRuleContext.bladeFightMessageData;
		if (bladeFightMessageData.isGetEnergyPack)
		{
			return bladeFightMessageData.bottonMessageTime > 0;
		}
		return false;
	}

	public bool isTargetGetEnergyPack()
	{
		BladeFightMessageDataComponent bladeFightMessageData = _gameRuleContext.bladeFightMessageData;
		if (bladeFightMessageData.isTargetGetEnergyPack)
		{
			return bladeFightMessageData.bottonMessageTime > 0;
		}
		return false;
	}
}
