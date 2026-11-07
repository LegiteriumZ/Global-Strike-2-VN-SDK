using Assets.Sources.Components.Interface.Info.GameRule;
using Assets.Sources.Constant;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.String;

namespace Assets.Sources.Info.GameRule;

public class DefaultGameRule : IGameRule
{
	protected bool FreeMark;

	protected bool RpgServivalPvp;

	protected bool RpgSpeed;

	protected bool RpgTeamRace;

	protected bool GuoQingRace;

	protected bool RpgGroup;

	protected bool BagChangeLimit;

	protected bool RpgRelive;

	protected bool Bio3;

	protected bool BioEvolution;

	private bool _groupAnnihilation;

	protected bool TacticsSound;

	protected int DefaultTacticsPage;

	protected bool Jump;

	protected bool RpgKillOther;

	protected bool GoldPig;

	protected bool Bot;

	protected bool RpgSpecialMode;

	protected bool RpgTowerMode;

	protected bool BioEvoChallengeMode;

	protected bool CrazeMode;

	protected bool RpgDanrenMineMode;

	protected bool Explode;

	protected int NotMoveTime;

	protected bool HasC4;

	protected AssetInfo StartGameSound;

	protected int C4TotalTime;

	protected int UltimateTime;

	protected bool ShowAddHpCross;

	protected bool ShowKiller;

	protected bool ShowLowHp;

	protected bool ShowHeroCraft;

	protected bool Rpg;

	protected bool RpgPvp;

	protected int TipsIndex;

	protected bool ShowEnemyHpBar;

	protected float StealthAlpha1;

	protected float StealthAlpha2;

	protected float StealthAlpha3;

	protected float StealthAlpha4;

	protected bool ShowTargetHp;

	protected bool GeneralPve;

	protected bool Pve;

	protected bool Bio;

	protected bool Bio2;

	protected bool Bighead;

	protected string ModeConfig;

	protected bool Relive;

	protected bool LockWeapon;

	protected bool LockWeaponTips;

	protected bool Personal;

	protected bool HideRadarDeadImage;

	protected bool NoShowRadarDead;

	protected bool ShowRadarEnemy;

	protected bool NewVariantsGrowUp;

	protected bool RefreshSkillCdWhenDounDead;

	protected int ObserverView;

	protected bool TD;

	protected bool NewRpgPvp;

	protected bool MechKing;

	protected bool RpgDuel;

	protected bool RpgHoliday;

	protected bool battleRoyaleMode;

	protected bool Acg;

	public virtual bool EnableFreeMark => FreeMark;

	public virtual bool HasTacticsSound => TacticsSound;

	public virtual int GetDefaultTacticsPage => DefaultTacticsPage;

	public virtual string GetModeConfig => ModeConfig;

	public virtual int GetObserverView => ObserverView;

	public DefaultGameRule()
	{
		RoomData data = Contexts.sharedInstance.battleRoom.roomData.Data;
		int raceType = data.RaceType;
		C4TotalTime = 35000;
		Rpg = RuleUtilty.IsRpg(raceType);
		Rpg = RuleUtilty.IsRpg(raceType);
		RpgPvp = RuleUtilty.IsRpgPvp(raceType);
		Explode = RuleUtilty.IsExplode(raceType);
		Jump = raceType == 30;
		StealthAlpha1 = 0.7f;
		StealthAlpha2 = 0.5f;
		StealthAlpha3 = 0.3f;
		GeneralPve = RuleUtilty.IsGeneralPve(raceType);
		Pve = RuleUtilty.IsPve(raceType);
		Bio = RuleUtilty.IsBioMode(raceType);
		Bio2 = 33 == raceType;
		Bio3 = RuleUtilty.IsNewBio3Rule(raceType);
		battleRoyaleMode = RuleUtilty.IsBattleRoyaleMode(raceType);
		Bighead = RuleUtilty.IsBigHeadModel(raceType);
		BioEvolution = RuleUtilty.IsBioEvoLutionMode(raceType);
		ModeConfig = StringCache.IntToString(RuleUtilty.GetConfigRule(raceType));
		Relive = !RuleUtilty.IsExplode(raceType) && !RuleUtilty.IsMultipleRpg(raceType) && !RuleUtilty.IsDeathRule(raceType);
		LockWeapon = raceType == 9 || raceType == 10 || raceType == 64 || RuleUtilty.IsUltimateChallenge();
		Personal = RuleUtilty.IsPersonlKillInfo(raceType);
		HideRadarDeadImage = true;
		ShowRadarEnemy = true;
		NewVariantsGrowUp = raceType == 6 || raceType == 31 || raceType == 69 || raceType == 117;
		RefreshSkillCdWhenDounDead = raceType == 6 || raceType == 69 || raceType == 117;
		ShowKiller = !data.IsPromise && !data.IsMatch && !RuleUtilty.IsBioMode(raceType) && !RuleUtilty.IsPveModel(raceType);
		GoldPig = raceType == 18001;
		RpgGroup = raceType == 15000 || raceType == 18010 || raceType == 18011;
		CrazeMode = 1100 == raceType;
		RpgDanrenMineMode = 18017 == raceType;
		Bot = RuleUtilty.IsBotMode(raceType);
		ObserverView = ((data.FreeType == "DeformedMen") ? 3 : 0);
		TacticsSound = Pve || raceType == 39;
		DefaultTacticsPage = ((RuleUtilty.IsPve(raceType) || !TacticsSound) ? 1 : 0);
		NoShowRadarDead = RuleUtilty.IsUltimateChallenge();
		FreeMark = RuleUtilty.IsUltimateChallenge();
		LockWeaponTips = !RuleUtilty.IsUltimateChallenge();
		RpgKillOther = raceType == 15005;
		RpgTeamRace = RuleUtilty.IsTeamRace(raceType);
		RpgServivalPvp = raceType == 15006;
		RpgSpeed = RuleUtilty.IsRpgSpeedMode(raceType);
		GuoQingRace = raceType == 18009;
		RpgSpecialMode = RuleUtilty.IsRpgSpecailMode(raceType);
		BagChangeLimit = Rpg || RpgSpecialMode;
		bool flag = raceType == 18021 || raceType == 18022;
		RpgRelive = (Rpg && !RpgPvp && !flag) || RpgSpecialMode;
		_groupAnnihilation = raceType == 15007;
		RpgTowerMode = RuleUtilty.IsRpgTower(raceType);
		BioEvoChallengeMode = raceType == 122;
		TD = raceType == 1001;
		NewRpgPvp = RuleUtilty.IsNewRpgPvp(raceType);
		MechKing = RuleUtilty.isMechKingMode(raceType);
		RpgDuel = raceType == 15012 || raceType == 15014;
		RpgHoliday = raceType == 18018;
		Acg = RuleUtilty.IsTpsAcgMode(raceType);
	}

	public virtual bool IsRpgServivalPvp()
	{
		return RpgServivalPvp;
	}

	public bool IsRpgSpeed()
	{
		return RpgSpeed;
	}

	public virtual bool IsRpgTeamRace()
	{
		return RpgTeamRace;
	}

	public virtual bool IsHideSkillWhenHidePlayer()
	{
		return false;
	}

	public virtual bool CanChangeWeapon()
	{
		return true;
	}

	public virtual bool IsGuoQingRace()
	{
		return GuoQingRace;
	}

	public virtual bool IsRpgGroup()
	{
		return RpgGroup;
	}

	public virtual bool HasBagChangeLimit()
	{
		return BagChangeLimit;
	}

	public virtual bool IsRpgRelive()
	{
		return RpgRelive;
	}

	public virtual bool IsShowGateUnderAttack()
	{
		return true;
	}

	public bool IsBio3()
	{
		return Bio3;
	}

	public bool IsBioEvolution()
	{
		return BioEvolution;
	}

	public bool IsRpgAnnihilationModel()
	{
		return _groupAnnihilation;
	}

	public virtual bool IsJump()
	{
		return Jump;
	}

	public virtual bool IsRpgKillOther()
	{
		return RpgKillOther;
	}

	public virtual bool IsGoldPig()
	{
		return GoldPig;
	}

	public virtual bool IsBot()
	{
		return Bot;
	}

	public virtual bool IsTeamRace()
	{
		return false;
	}

	public virtual bool IsRpgSpecialMode()
	{
		return RpgSpecialMode;
	}

	public bool IsRpgTowerMode()
	{
		return RpgTowerMode;
	}

	public bool IsBioEvolutionChallengeMode()
	{
		return BioEvoChallengeMode;
	}

	public bool IsCrazeMode()
	{
		return CrazeMode;
	}

	public bool IsRpgDanrenMineMode()
	{
		return RpgDanrenMineMode;
	}

	public virtual bool IsExplode()
	{
		return Explode;
	}

	public virtual int GetNotMoveTime()
	{
		return NotMoveTime;
	}

	public virtual bool IsHasC4()
	{
		return HasC4;
	}

	public virtual AssetInfo GetStartGameSound(int team)
	{
		return StartGameSound;
	}

	public virtual int GetC4TotalTime()
	{
		return C4TotalTime;
	}

	public virtual int GetUltimateTime()
	{
		return UltimateTime;
	}

	public virtual bool CanShowAddHpCross()
	{
		return ShowAddHpCross;
	}

	public virtual bool IsShowKiller()
	{
		return ShowKiller;
	}

	public virtual bool IsShowLowHp(string career, long hp)
	{
		return ShowLowHp;
	}

	public virtual bool CanShowHeroCraft()
	{
		return ShowHeroCraft;
	}

	public virtual bool IsRpg()
	{
		return Rpg;
	}

	public virtual bool IsRpgPvp()
	{
		return RpgPvp;
	}

	public virtual int GetTipsIndex()
	{
		return TipsIndex;
	}

	public virtual bool IsShowEnemyHpBar()
	{
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 18023)
		{
			return true;
		}
		return ShowEnemyHpBar;
	}

	public virtual float GetStealthAlpha1()
	{
		return StealthAlpha1;
	}

	public virtual float GetStealthAlpha2()
	{
		return StealthAlpha2;
	}

	public virtual float GetStealthAlpha3()
	{
		return StealthAlpha3;
	}

	public virtual float GetStealthAlpha4()
	{
		return StealthAlpha4;
	}

	public virtual bool IsShowTargetHp()
	{
		return ShowTargetHp;
	}

	public virtual bool IsGeneralPve()
	{
		return GeneralPve;
	}

	public virtual bool IsPve()
	{
		return Pve;
	}

	public virtual bool IsBio()
	{
		return Bio;
	}

	public virtual bool IsBio2()
	{
		return Bio2;
	}

	public virtual bool IsBighead()
	{
		return Bighead;
	}

	public virtual bool CanRelive()
	{
		return Relive;
	}

	public virtual bool GetLockWeapon()
	{
		return LockWeapon;
	}

	public virtual bool IsLockWeaponTips()
	{
		return LockWeaponTips;
	}

	public virtual bool IsPersonal()
	{
		return Personal;
	}

	public virtual bool IsHideRadarDeadImage()
	{
		return HideRadarDeadImage;
	}

	public virtual bool IsNoShowRadarDead()
	{
		return NoShowRadarDead;
	}

	public virtual bool IsShowRadarEnemy()
	{
		return ShowRadarEnemy;
	}

	public virtual bool IsNewVariantsGrowUp()
	{
		return NewVariantsGrowUp;
	}

	public virtual bool IsRefreshSkillCdWhenDounDead()
	{
		return RefreshSkillCdWhenDounDead;
	}

	public virtual bool IsTDMode()
	{
		return TD;
	}

	public bool IsNewRpgPvp()
	{
		return NewRpgPvp;
	}

	public bool IsMechKing()
	{
		return MechKing;
	}

	public bool IsRpgDuel()
	{
		return RpgDuel;
	}

	public bool IsRpgHolidayMode()
	{
		return RpgHoliday;
	}

	public bool IsBattleRoyaleMode()
	{
		return battleRoyaleMode;
	}

	public bool IsAcg()
	{
		return Acg;
	}
}
