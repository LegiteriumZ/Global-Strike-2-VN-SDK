using System.Collections;
using Assets.Sources.Chat;
using Assets.Sources.Ui.Model.Common;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Common;

public class ChattingLiveModelTest
{
	private Contexts _contexts;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
	}

	public IEnumerator Test()
	{
		TestUiDataInitUtils.InitChatHistroy();
		yield return TestUiModuleUtils.InitUiTest<ChattingLiveModel>(() => true);
		TestUiStep.Step("添加 Gift消息");
		for (int i = 0; i < 20; i++)
		{
			_contexts.chat.chatJobHistroy.LiveList.Group.Add(new ChatHistroyData
			{
				AssembleBody = "Gift消息 " + i,
				MsgType = "live_gift",
				Weight = i % 5
			});
			_contexts.chat.chatJobHistroy.LiveList.Mark = true;
			yield return new WaitForSeconds(0.5f);
		}
		yield return new WaitForSeconds(3f);
		TestUiStep.Step("添加 Barrage消息");
		for (int i = 0; i < 20; i++)
		{
			_contexts.chat.chatJobHistroy.LiveList.Group.Add(new ChatHistroyData
			{
				AssembleBody = "Barrage消息 " + i,
				MsgType = "live_barrage",
				Weight = i % 5
			});
			_contexts.chat.chatJobHistroy.LiveList.Mark = true;
			yield return new WaitForSeconds(0.5f);
		}
		yield return new WaitForSeconds(3f);
	}
}
