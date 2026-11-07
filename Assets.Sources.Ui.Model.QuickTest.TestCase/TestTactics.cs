using Assets.Sources.Info.Sound;
using Assets.Sources.Ui.ForUiTest;

namespace Assets.Sources.Ui.Model.QuickTest.TestCase;

public class TestTactics : QuickTestCase
{
	public TestTactics(Contexts contexts)
		: base(contexts)
	{
		if (contexts.gameRule.currentRule.Rule.IsExplode())
		{
			AddAction(1000, delegate
			{
				contexts.chat.chatJobHistroy.ChatList.Group.Clear();
				contexts.chat.chatJobHistroy.ChatList.Mark = true;
				TacticsSoundModel.Instance.SendSound(0, 0);
			}, () => !NetRecordManager.Playing);
			AddAction(5000, delegate
			{
				QuickTestCase.Assert(!TacticsSoundModel.Instance.SendSound(0, 0), "小于6s内连发");
			});
			AddAction(1500, delegate
			{
				QuickTestCase.Assert(TacticsSoundModel.Instance.SendSound(0, 0), "大于6s连发");
			});
			AddAction(6500, delegate
			{
				TacticsSoundModel.Instance.SendSound(0, 0);
			});
			AddAction(10000, delegate
			{
				QuickTestCase.Assert(!TacticsSoundModel.Instance.SendSound(0, 0), "小于24s 三连发");
			});
			AddAction(1200, delegate
			{
				QuickTestCase.Assert(TacticsSoundModel.Instance.SendSound(0, 0), "大于24s 三连发");
			});
			AddAction(6000, delegate
			{
				QuickTestCase.Assert(TacticsSoundModel.Instance.SendSound(0, 0), "刷新后 连发");
			});
		}
	}
}
