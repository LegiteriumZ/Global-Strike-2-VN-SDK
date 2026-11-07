namespace Assets.Libs.UiEditor.UIEditorRunTime.DataProvider.ModeProviderCollector;

internal class DimensionalFissureModelExtraDataProvider : AbstractModeExtraDataProvider
{
	public override void Init(Contexts contexts)
	{
		_keyInfo = "ui/dimensionalfissuremodel";
		Providers.Add(new DimensionalFissureModelKuangLuanProgressUiProvider(contexts));
	}
}
