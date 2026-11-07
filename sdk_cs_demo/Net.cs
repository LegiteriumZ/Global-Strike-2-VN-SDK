using AceSdk;

namespace sdk_cs_demo;

internal class Net
{
	public static void collect_and_send_anti_data(ref TssAntibot antibot)
	{
		antibot.GetReportData();
	}

	public static void on_data_received_from_game_server(byte[] msg, ref TssAntibot antibot)
	{
		antibot.OnRecvAntiData(msg);
	}
}
