namespace Assets.Sources.Constant;

public class LocalEntityType
{
	public const int LeMovingTracer = 1;

	public const int LeMuzzleFlash = 2;

	public const int LeSelfMuzzleFlash = 3;

	public const int LeBulletHole = 4;

	public const int LeBulletEffect = 5;

	public const int LeBulletSmoke = 6;

	public const int LeBulletFire = 7;

	public const int LeBulletRail = 8;

	public const int LeGrenadeEffect = 9;

	public const int LeBulletBlood = 10;

	public const int LeBowHitWall = 11;

	public const int LeSprayEffect = 13;

	public const int LeDisarmExplosion = 14;

	public const int LeGravityRailhide = 17;

	public const int LeBoltRail = 18;

	public const int LeSelfexplosionEffect = 25;

	public const int LeSuperexplosionEffect = 26;

	public const int LeDamagehpEffect = 27;

	public const int LeHelpreliveEffect = 28;

	public const int LeLightningEffect = 29;

	public const int LeTurkeydeadEffect = 30;

	public const int LeAddhpEffect = 31;

	public const int LeVirusmoistureEffect = 32;

	public const int LeThumpEffect = 33;

	public const int LeVariationbombstartEffect = 34;

	public const int LeVariationbombendEffect = 35;

	public const int LeLightningboundexplosionEffect = 38;

	public const int LeTeleporationEffect = 39;

	public const int LeGhostexplsionEffect = 40;

	public const int LeSnokebombexplsionEffect = 41;

	public const int LeQuickmovementEffect = 42;

	public const int LeExplosionEffect = 43;

	public const int LeShockwaveEffect = 44;

	public const int LeAlertcirclesEffect = 45;

	public const int LeJumpAttackEffect = 46;

	public const int LeVoiddeviceExplosionEffect = 47;

	public const int LeWaitultrasouic = 48;

	public const int LeIceExplosion = 49;

	public const int LeHarbordstrict = 50;

	public const int LeAutosavepoint = 51;

	public const int LeMassscredexplsionEffect = 52;

	public const int LeLeibaohongzha = 53;

	public const int LeLeibaohongzhaExplsion = 54;

	public const int LePhasetransferEffect = 55;

	public const int LeRailhide = 56;

	public const int LeDiyuzhiguang = 58;

	public const int LeRevolverExplosion = 59;

	public const int LeParticleEffect = 60;

	public const int LeRocketbombEffect = 61;

	public const int LeViewBulletRail = 62;

	public const int LeWallBloodEffect = 63;

	public const int LeRpgLeitinghuimie = 1001;

	public const int LeRpgShandianchuansong = 1002;

	public const int LeAk47Legendskill = 1003;

	public const int LeBspDecalRenderType = 101;

	public const int LeBspSprite3DRenderType = 102;

	public const int LeBspDecalrotationRenderType = 103;

	public const int LeBspModeleffectRenderType = 104;

	public const int LeBspSnoweffectRenderType = 105;

	public const int LeBspRandomSprite3DRenderType = 106;

	public const int LeBspMoveuvDecalRenderType = 107;

	public const int LeBspReflectionProbeRenderType = 108;

	public const int LeBspSceneitemRenderType = 109;

	public const int LeBspMoveuvModeleffectRenderType = 110;

	public const int LeBspParticleEffectRenderType = 111;

	public static bool IsLocalBspEntityType(int eType)
	{
		if ((uint)(eType - 101) <= 9u)
		{
			return true;
		}
		return false;
	}

	public static bool CollectGarbageType(int eType)
	{
		switch (eType)
		{
		case 4:
		case 5:
		case 6:
		case 8:
		case 9:
		case 10:
		case 11:
		case 13:
		case 14:
		case 17:
		case 18:
		case 25:
		case 26:
		case 27:
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 38:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 47:
		case 48:
		case 49:
		case 50:
		case 51:
		case 52:
		case 53:
		case 54:
		case 55:
		case 56:
		case 58:
		case 59:
		case 60:
		case 61:
		case 62:
		case 63:
		case 108:
		case 110:
		case 111:
		case 1001:
		case 1002:
			return true;
		default:
			return false;
		}
	}
}
