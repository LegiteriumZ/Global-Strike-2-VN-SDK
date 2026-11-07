using Assets.Sources.Components.Interface.Info.Chat;

namespace Assets.Sources.Chat;

public struct ChatHononaryData : IChatHononaryData
{
	public const int ShowViphononaryLevel = 5;

	public const int HononaryTypeLegendweapon = 0;

	public const int HononaryTypeHeroweapon = 1;

	public const int HononaryTypeVip = 2;

	public const int WaitTime = 300;

	public string MsgType;

	public int Wait;

	public bool IsFriendly;

	public long Cid;

	public int Id;

	public string PlayerName;

	public string HeroWeapon;

	public string LegendWeapon;

	public bool IsObserver;

	public int Team;

	public int VipLevel;

	public bool Changed;

	public ChatHideAnimData AlphaData;

	public string WeaponName;
}
