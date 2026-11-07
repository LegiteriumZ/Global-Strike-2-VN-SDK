using Assets.Sources.Config;
using NetData;
using SSJJBase.Thread;

namespace Assets.Sources.Ui.ForUiTest.MultiPlayer;

public static class ConnectEventHandler
{
	public static void Handle(MultiPlayerBattleServer server, int success, string message)
	{
		UnityMainThreadDispatcher.Enqueue(delegate
		{
			if (success == 0)
			{
				if (TplManager.Instance.GetBootConfig().RoomId > 0)
				{
					LoginData message2 = new LoginData
					{
						RoomId = TplManager.Instance.GetBootConfig().RoomId,
						UserId = TplManager.Instance.GetBootConfig().CharId,
						Timestamp = TplManager.Instance.GetBootConfig().Timestamp,
						Sign = TplManager.Instance.GetBootConfig().Sign,
						LoginType = LoginDataType.Unity,
						NpGray = TplManager.Instance.GameBootConfig.NpOpen
					};
					server.SendTcpMessage(2, message2);
				}
				else
				{
					server.SendTcpMessage(32);
				}
			}
		});
	}
}
