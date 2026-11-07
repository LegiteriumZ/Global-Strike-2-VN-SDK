public class CompeteKingModelRandomEffectProvider : gunFightModelRandomEffectProvider, ICompeteKingModelRandomEffectProvider, IModuleProvider
{
	public CompeteKingModelRandomEffectProvider(Contexts contexts)
		: base(contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}
}
