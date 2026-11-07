using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using AceSdk;

namespace sdk_cs_demo;

internal class Program
{
	private class DataReceivingTh
	{
		private AceClient ace_client;

		public DataReceivingTh(ref AceClient a)
		{
			ace_client = a;
		}

		public void worker_th()
		{
			TssAntibot antibot = ace_client.get_optional_interface().get_tss_antibot();
			data_receiving_simulator(ref antibot);
			MainLoop.g_is_exiting = true;
		}

		private void data_receiving_simulator(ref TssAntibot antibot)
		{
			byte[] bytes = Encoding.UTF8.GetBytes("dummy data");
			for (int i = 0; i < 10; i++)
			{
				Net.on_data_received_from_game_server(bytes, ref antibot);
				Thread.Sleep(2000);
			}
		}
	}

	private static void Main(string[] args)
	{
		Console.WriteLine("initializing ACE...");
		ClientInitInfo init_info = default(ClientInitInfo);
		init_info.first_process_pid = Process.GetCurrentProcess().Id;
		init_info.current_process_role_id = -1;
		init_info.base_dat_path = null;
		AceClient ace_client;
		AntiCheatExpertResult antiCheatExpertResult = AceClient.init(ref init_info, null, out ace_client);
		if (antiCheatExpertResult != 0)
		{
			Console.WriteLine("ACE init failed, err:{0}, game is exiting...", antiCheatExpertResult);
			return;
		}
		Thread thread = new Thread(new DataReceivingTh(ref ace_client).worker_th);
		thread.Start();
		Login.user_login(ref ace_client);
		MainLoop.loop(ref ace_client);
		thread.Join();
		Console.WriteLine("logging off...");
		ace_client.log_off();
		Console.WriteLine("exiting...");
		ace_client.exit_process();
	}
}
