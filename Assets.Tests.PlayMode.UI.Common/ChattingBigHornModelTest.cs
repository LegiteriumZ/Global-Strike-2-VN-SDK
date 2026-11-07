using System.Collections;
using Assets.Sources.Chat;
using Assets.Sources.Ui.Model.Common;
using NetData;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Common;

public class ChattingBigHornModelTest
{
	private Contexts _contexts;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
	}

	public IEnumerator Test()
	{
		TestUiDataInitUtils.InitChatHistroy();
		_contexts.gameRule.SetCurrentRule(new TestUiBaseGameRule());
		(_contexts.gameRule.currentRule.Rule as TestUiBaseGameRule).Explode = true;
		yield return TestUiModuleUtils.InitUiTest<ChattingBigHornModel>(delegate
		{
			if (!_contexts.battleRoom.hasRoomData)
			{
				return false;
			}
			_contexts.battleRoom.roomData.Data = new RoomData();
			return true;
		});
		_contexts.battleRoom.roomData.Data.RaceType = 2;
		TestUiStep.Step("添加 短消息");
		_contexts.chat.chatJobHistroy.BigHornList.Group.Add(new ChatHistroyData
		{
			AssembleHead = "短消息",
			AssembleBody = "短一点的消息"
		});
		_contexts.chat.chatJobHistroy.BigHornList.Mark = true;
		yield return new WaitForSeconds(13f);
		TestUiStep.Step("添加 长消息");
		_contexts.chat.chatJobHistroy.BigHornList.Group.Add(new ChatHistroyData
		{
			AssembleHead = "长消息",
			MsgType = "big_horn2",
			AssembleBody = "长一点的消息, 长一点的消息,长一点的消息 长一点的消息长一点的消息 长一点的消息 长一点的消息 长一点的消息长一点的消息 长一点的消息 长一点的消息 "
		});
		_contexts.chat.chatJobHistroy.BigHornList.Mark = true;
		yield return new WaitForSeconds(7f);
		TestUiStep.Step("连续添加消息");
		_contexts.chat.chatJobHistroy.BigHornList.Group.Add(new ChatHistroyData
		{
			AssembleHead = "连续消息",
			MsgType = "big_horn2",
			AssembleBody = "连续消息 连续消息 连续消息 连续消息 连续消息 连续消息 连续消息 连续消息 连续消息 连续消息 连续消息 连续消息 连续消息  "
		});
		_contexts.chat.chatJobHistroy.BigHornList.Mark = true;
		yield return new WaitForSeconds(13f);
	}
}
