namespace Assets.Sources.Constant;

internal class EffectResIdConstant
{
	public const int BulletrailIndex = 0;

	public const int SnowBulletrailIndex = 1;

	public const int WeaponGBulletrailIndex = 2;

	public const int HeroRpkBulletrailIndex = 3;

	public const int HeroAwmBulletrailIndex = 4;

	public const int HeroSandanBulletrailIndex = 5;

	public const int BoltBulletrailIndex = 6;

	public const int Bow1BulletrailIndex = 7;

	public const int Bow2BulletrailIndex = 8;

	public const int Ak47HeroBulletrailIndex = 9;

	public const int M4A1HeroBulletrailIndex = 10;

	public const int GhostTwinsBulletrailIndex = 11;

	public const int VipBulletrailIndex = 12;

	public const int GhostRiderBulletrailIndex = 13;

	public const int DefualtHole = 0;

	public const int GrenadeHole = 1;

	public const int KnifeHole = 4;

	public const int GlovesknifeHole = 34;

	public const int CatclawHole = 103;

	public const int BowHitWallHole = 104;

	public const int KnifeHit = 0;

	public const int BulletHit = 1;

	public const int HeadHit = 2;

	public const int BioHit = 3;

	public const int HeroHit = 4;

	public const int VoidDeviceHit = 5;

	public const int MechHit = 6;

	public const int EngineEntityHit = 100;

	public const int BioBlood = 0;

	public const int RpgBlood = 1;

	public const int PveBlood = 2;

	public const int CommonBlood = 3;

	public const int BombExplosion = 0;

	public const int UcbombExplosion = 1;

	public const int BombfoolExplosion = 2;

	public const int SlingshotExplosion = 3;

	public const int BombyExplosion = 4;

	public const int LovebombExplosion = 5;

	public const int BombgExplosion = 6;

	public const int BombpkExplosion = 7;

	public const int BombFirecrackersExplosion = 8;

	public const int BiobombExplosion = 9;

	public const int Turkey = 10;

	public const int MooncakeExplosion = 11;

	public const int SnowballExplosion = 13;

	public const int BombwukongExplosion = 14;

	public const int FootbombbombExplosion = 15;

	public const int DarkbombExplosion = 16;

	public const int BombeggExplosion = 17;

	public const int AbyssExplosion = 18;

	public const int M32Explosion = 19;

	public const int ElectricExplosion = 20;

	public const int Qbz95HeroExplosion = 21;

	public static string GetEffectNameByWeaponName(string weapon)
	{
		switch (weapon)
		{
		case "grenade":
		case "highgrenade":
		case "auga3":
			return "grenade";
		case "highgrenade_y":
			return "grenadeY";
		case "highgrenade_g":
			return "grenadeG";
		case "grenade_pumpkin":
			return "pumpkingrenade";
		case "grenade_uc":
			return "ucgrenade";
		case "grenade_love":
			return "lovegrenade";
		case "ghost_grenade":
			return "foolgrenade";
		case "double_grenade":
			return "grenadefirecrackers";
		case "candy_grenade":
			return "ucgrenade";
		case "biogrenade":
			return "biogrenade";
		case "slingshot":
		case "howitzer":
		case "howitzerwoman":
		case "crossbow":
		case "crossbow_g":
			return "slingshotExplosion";
		default:
			return null;
		}
	}

	public static string GetResidToFileName(int resid)
	{
		return resid switch
		{
			0 => "grenade", 
			1 => "ucgrenade", 
			2 => "foolgrenade", 
			3 => "slingshotExplosion", 
			4 => "grenadeY", 
			5 => "lovegrenade", 
			6 => "grenadeG", 
			7 => "pumpkingrenade", 
			8 => "grenadefirecrackers", 
			9 => "biogrenade", 
			11 => "mooncakegrenade", 
			10 => "turkey", 
			13 => "snowballexplosion", 
			14 => "grenadewukong", 
			15 => "footballgrenade", 
			16 => "darkgrenade", 
			17 => "grenadeegg", 
			18 => "abyssexplosion", 
			19 => "m32explosion", 
			_ => "grenade", 
		};
	}
}
