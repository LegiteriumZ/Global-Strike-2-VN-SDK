using System;
using System.Threading;
using AceSdk;

namespace sdk_cs_demo;

internal class MainLoop
{
	public static bool g_is_exiting;

	public static void loop(ref AceClient ace_client)
	{
		TssAntibot antibot = ace_client.get_optional_interface().get_tss_antibot();
		Console.WriteLine("starting main loop...");
		while (!g_is_exiting)
		{
			ace_client.tick();
			Net.collect_and_send_anti_data(ref antibot);
			Thread.Sleep(30);
		}
	}
}
