using Assets.Sources.Chat;
using Assets.Sources.Ui.ForUiTest;
using Assets.Sources.Utils;
using Entitas;

namespace Assets.Sources.Ui.Model.QuickTest.TestCase;

public class TestChat : QuickTestCase
{
	public TestChat(Contexts contexts)
		: base(contexts)
	{
		IGroup<ChatEntity> chatHistroy = Contexts.sharedInstance.chat.GetGroup(ChatMatcher.ChatJobHistroy);
		AddAction(1, delegate
		{
			foreach (ChatEntity item in chatHistroy)
			{
				contexts.chat.chatJobHistroy.ChatList.Group.Clear();
				item.chatJobHistroy.ContentReceived.Enqueue("<message from=\"Crazy\"&><迷迷米\" type=\"tacticsSound\"><body>\"&>< 我已使出了洪荒之力！在【地狱之城03】冲击了排名第【1】的新纪录。速来膜拜大神！</body></message>");
			}
		}, () => !NetRecordManager.Playing);
		AddAction(1, delegate
		{
			PlayerEntity myPlayerEntity2 = contexts.player.myPlayerEntity;
			string playerName2 = myPlayerEntity2.basicInfo.PlayerName;
			foreach (ChatEntity item2 in chatHistroy)
			{
				myPlayerEntity2.basicInfo.Current.PlayerName = "[电1]" + playerName2;
				item2.chatJobHistroy.ContentReceived.Enqueue($"<message from=\"§椛沐夏\" to=\"{playerName2}\" type=\"personal\" fromCid=\"53523141\" toCid=\"{myPlayerEntity2.basicInfo.Cid % 100000000}\" dateline=\"{TimeUtility.UnixTimeNow()}\" vipLv=\"0\"><body>hhhh</body></message>");
			}
		}, () => !NetRecordManager.Playing);
		AddAction(1, delegate
		{
			PlayerEntity myPlayerEntity = contexts.player.myPlayerEntity;
			string playerName = myPlayerEntity.basicInfo.PlayerName;
			myPlayerEntity.basicInfo.Current.PlayerName = playerName;
			QuickTestCase.Assert(((ChatHistroyData)contexts.chat.chatJobHistroy.ChatList.Group[0]).AssembleHead == "【私聊】§椛沐夏对你说：", $"contexts.chat.chatHistroy.ChatList[0].FromText == 【私聊】§椛沐夏对你说： => {((ChatHistroyData)contexts.chat.chatJobHistroy.ChatList.Group[0]).AssembleHead}");
		});
	}
}
