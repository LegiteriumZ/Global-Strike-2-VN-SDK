using Assets.Sources.Components.Time;

public class rpgDanrenMineModelDamageCountProvider : IrpgDanrenMineModelDamageCountProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public rpgDanrenMineModelDamageCountProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float GetDamageCount()
	{
		return _gameRuleContext.danrenMine.DamageCount;
	}
}
