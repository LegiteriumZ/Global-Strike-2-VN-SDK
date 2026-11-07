public class ExplodewdModel : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/explodewdmodel";
		Providers.Add(new explodewdModelExplodeWdGameOverProvider(contexts));
		Providers.Add(new explodewdModelExplodeWdGameTipsProvider(contexts));
		Providers.Add(new explodewdModelExplodeWdSurplusExplodeProvider(contexts));
	}
}
