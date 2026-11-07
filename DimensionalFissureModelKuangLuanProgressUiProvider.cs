using Assets.Sources.Components.Time;

public class DimensionalFissureModelKuangLuanProgressUiProvider : IDimensionalFissureModelKuangLuanProgressUiProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public DimensionalFissureModelKuangLuanProgressUiProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float SetDerangement()
	{
		return (float)_gameRuleContext.dimentionData.Derangement / 100f;
	}
}
