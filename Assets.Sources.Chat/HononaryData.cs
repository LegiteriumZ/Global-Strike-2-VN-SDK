namespace Assets.Sources.Chat;

public class HononaryData
{
	public static readonly int ShowViphononaryLevel = 5;

	public static readonly int HononaryTypeLegendweapon = 0;

	public static readonly int HononaryTypeHeroweapon = 1;

	public static readonly int HononaryTypeVip = 2;

	public bool IsFriendly;

	public float Cid;

	public string PlayerName;

	public string HeroWeapon;

	public string LegendWeapon;

	public bool IsObserver;

	public int Team;

	public int VipLevel = 2;

	public bool Changed;

	public HononaryData Clone()
	{
		return new HononaryData
		{
			IsFriendly = IsFriendly,
			Cid = Cid,
			PlayerName = PlayerName,
			HeroWeapon = HeroWeapon,
			LegendWeapon = LegendWeapon,
			IsObserver = IsObserver,
			Team = Team,
			VipLevel = VipLevel,
			Changed = Changed
		};
	}
}
