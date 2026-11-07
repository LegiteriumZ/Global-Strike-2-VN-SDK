namespace Assets.Sources.Chat;

public class ChattingType
{
	public const int MaxChathistory = 6;

	public const string Vip = "vip";

	public const string AllPlayer = "battle_all";

	public const string ObserverAllPlayer = "battle_observer_all";

	public const string CampPlayer = "battle_team";

	public const string TeamPlayer = "team";

	public const string WhisperPlayer = "personal";

	public const string System = "system";

	public const string Prompt = "prompt";

	public const string Tacticssound = "tacticsSound";

	public const string Playerlogin = "playerlogin";

	public const string Playerlogout = "playerlogout";

	public const string BigHorn2 = "big_horn2";

	public const string BigHorn3 = "big_horn3";

	public const string LiveBarrage = "live_barrage";

	public const string LiveGift = "live_gift";

	public const string Hononary1 = "hononary1";

	public const string Hononary2 = "hononary2";

	public static bool IsShieldChattingType(string chattingType)
	{
		if (IsLiveChattingType(chattingType))
		{
			return false;
		}
		if (IsBigHornChattingType(chattingType))
		{
			return false;
		}
		if ("system" == chattingType)
		{
			return false;
		}
		return true;
	}

	public static bool IsLiveChattingType(string chattingType)
	{
		if ("live_barrage" == chattingType || "live_gift" == chattingType)
		{
			return true;
		}
		return false;
	}

	public static bool IsCampPlayerChattingType(string chattingType)
	{
		if ("battle_team" == chattingType)
		{
			return true;
		}
		return false;
	}

	public static bool IsBigHornChattingType(string chattingType)
	{
		if ("big_horn2" == chattingType || "big_horn3" == chattingType)
		{
			return true;
		}
		return false;
	}

	public static bool IsObserverAllChattingType(string chattingType)
	{
		if ("battle_observer_all" == chattingType)
		{
			return true;
		}
		return false;
	}
}
