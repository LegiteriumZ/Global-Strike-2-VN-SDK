using Assets.Sources.Components.Time;

public class freeRpg_107000ModelCanLightFireProvider : IfreeRpg_107000ModelCanLightFireProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public freeRpg_107000ModelCanLightFireProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float SetExp1()
	{
		return _gameRuleContext.mystery.Exp1;
	}

	public float SetExp2()
	{
		return _gameRuleContext.mystery.Exp2;
	}

	public float SetExp3()
	{
		return _gameRuleContext.mystery.Exp3;
	}

	public bool IsShowCanLightFire()
	{
		return _gameRuleContext.mystery.IsCanLightFireTips;
	}
}
