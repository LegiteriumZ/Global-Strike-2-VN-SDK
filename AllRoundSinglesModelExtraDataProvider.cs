public class AllRoundSinglesModelExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/allroundsinglesmodel";
		Providers.Add(new AllRoundSinglesModelbattletipProvider(contexts));
		Providers.Add(new AllRoundSinglesModelCurRoundResoultProvider(contexts));
		Providers.Add(new AllRoundSinglesModelSelectModeProvider(contexts));
		Providers.Add(new AllRoundSinglesModelTopShowInfoProvider(contexts));
	}
}
