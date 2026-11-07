public class PeekabooDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/peekabooModel";
		Providers.Add(new peekabooModelPeekAbooByLikesGUIProvider(contexts));
		Providers.Add(new peekabooModelPeekAbooGameOverGUIProvider(contexts));
		Providers.Add(new peekabooModelPeekAbooHumanityBackGUIProvider(contexts));
		Providers.Add(new peekabooModelPeekAbooLikesGUIProvider(contexts));
		Providers.Add(new peekabooModelPeekAbooMessageGUIProvider(contexts));
		Providers.Add(new peekabooModelPeekAbooSceneItemControlStateGUIProvider(contexts));
		Providers.Add(new peekabooModelPeekAbooStarsItemGUIProvider(contexts));
		Providers.Add(new peekabooModelPeekAbooTeamScoreGUIProvider(contexts));
	}
}
