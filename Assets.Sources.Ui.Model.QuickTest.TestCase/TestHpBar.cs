using Assets.Sources.Ui.ForUiTest;

namespace Assets.Sources.Ui.Model.QuickTest.TestCase;

public class TestHpBar : QuickTestCase
{
	public TestHpBar(Contexts contexts)
		: base(contexts)
	{
		AddAction(1, delegate
		{
		}, () => !NetRecordManager.Playing);
	}
}
