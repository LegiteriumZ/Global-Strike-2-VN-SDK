using Assets.Sources.Ui.ForUiTest;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.ViewModel.Common;

namespace Assets.Sources.Ui.Model.QuickTest.TestCase;

public class TestBiochemicalBag : QuickTestCase
{
	public TestBiochemicalBag(Contexts contexts)
		: base(contexts)
	{
		if (!(NetRecordManager.RecordName != "Biochemical"))
		{
			Priority = 1;
			AddAction(1, delegate
			{
				QuickTestCase.Assert(!GetProperty<PlayerBagModel, PlayerbagViewModel>("ViewModel").BagOpenedPanelShow, " viewModel.BagOpenedPanelShow == false");
			}, () => NetRecordManager.Index == 350);
			AddAction(1, delegate
			{
				QuickTestCase.Assert(GetProperty<PlayerBagModel, PlayerbagViewModel>("ViewModel").BagOpenedPanelShow, " viewModel.BagOpenedPanelShow == true");
			}, () => NetRecordManager.Index == 500);
		}
	}
}
