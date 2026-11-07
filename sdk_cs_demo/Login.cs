using System;
using AceSdk;

namespace sdk_cs_demo;

internal class Login
{
	public static void user_login(ref AceClient ace_client)
	{
		string account_ = get_open_id("some token");
		Console.WriteLine("Setting account information...");
		AceAccountInfo acc = default(AceAccountInfo);
		acc.account_id_.account_type_ = 601;
		acc.account_id_.account_ = account_;
		acc.plat_id_ = 3;
		acc.game_id_ = 347u;
		acc.world_id_ = 0u;
		acc.channel_id_ = 0u;
		acc.role_id_ = 0uL;
		if (ace_client.log_on(ref acc) != 0)
		{
			Console.WriteLine("log on failed");
		}
	}

	private static string get_open_id(string some_token)
	{
		return "oB4nYjvY13SVtaWC-BFztM2f3TlU";
	}
}
