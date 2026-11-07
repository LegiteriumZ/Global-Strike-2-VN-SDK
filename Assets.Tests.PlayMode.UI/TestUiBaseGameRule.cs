using Assets.Sources.Components.Interface.Info.GameRule;
using SSJJAsset.Asset;

namespace Assets.Tests.PlayMode.UI;

public class TestUiBaseGameRule : IGameRule
{
	protected bool GoldPig;

	protected bool Bot;

	public bool Jump;

	public bool FreeRadarScale;

	public bool Explode;

	public int NotMoveTime;

	public bool HasC4;

	public AssetInfo StartGameSound;

	public int C4TotalTime;

	public int UltimateTime;

	public bool ShowAddHpCross;

	public bool ShowKiller;

	public bool ShowLowHp;

	public bool ShowHeroCraft;

	public bool Rpg;

	public bool RpgPvp;

	public int TipsIndex;

	public bool ShowEnemyHpBar;

	public float StealthAlpha1;

	public float StealthAlpha2;

	public float StealthAlpha3;

	protected float StealthAlpha4;

	public bool ShowTargetHp;

	public bool GeneralPve;

	public bool Pve;

	public bool Bio;

	protected bool Bio2;

	public bool Bighead;

	public string ModeConfig;

	public bool Relive;

	public bool LockWeapon;

	public bool Personal;

	public bool HideRadarDeadImage;

	public bool ShowRadarEnemy;

	public bool NewVariantsGrowUp;

	public bool RefreshSkillCdWhenDounDead;

	private int _getObserverView;

	private bool _hasTacticsSound;

	private int _getDefaultTacticsPage;

	private bool _enableFreeMark;

	public virtual string GetModeConfig => ModeConfig;

	public int GetObserverView => _getObserverView;

	public bool HasTacticsSound => _hasTacticsSound;

	public int GetDefaultTacticsPage => _getDefaultTacticsPage;

	public bool EnableFreeMark => _enableFreeMark;

	public bool IsRpgKillOther()
	{
		return false;
	}

	public bool IsGoldPig()
	{
		return GoldPig;
	}

	public bool IsBot()
	{
		return Bot;
	}

	public bool IsTeamRace()
	{
		return false;
	}

	public bool IsZhouNianQing()
	{
		return false;
	}

	public bool IsCrazeMode()
	{
		return false;
	}

	public bool IsRpgDanrenMineMode()
	{
		return false;
	}

	public virtual bool IsJump()
	{
		return Jump;
	}

	public bool IsFreeRadarScale()
	{
		return FreeRadarScale;
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

	public bool IsShowLowHp(string career, long hp)
	{
		return ShowLowHp;
	}

	public virtual bool IsShowLowHp(string career, int hp)
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

	public bool IsLockWeaponTips()
	{
		return false;
	}

	public virtual bool IsPersonal()
	{
		return Personal;
	}

	public virtual bool IsHideRadarDeadImage()
	{
		return HideRadarDeadImage;
	}

	public bool IsNoShowRadarDead()
	{
		return false;
	}

	public bool IsShowRadarEnemy()
	{
		return ShowRadarEnemy;
	}

	public bool IsNewVariantsGrowUp()
	{
		return NewVariantsGrowUp;
	}

	public bool IsRefreshSkillCdWhenDounDead()
	{
		return RefreshSkillCdWhenDounDead;
	}

	public bool IsRpgServivalPvp()
	{
		return false;
	}

	public bool IsRpgSpeed()
	{
		return false;
	}

	public bool IsRpgTeamRace()
	{
		return false;
	}

	public bool IsHideSkillWhenHidePlayer()
	{
		return false;
	}

	public bool CanChangeWeapon()
	{
		return true;
	}

	public bool IsGuoQingRace()
	{
		return false;
	}

	public bool IsRpgGroup()
	{
		return false;
	}

	public bool HasBagChangeLimit()
	{
		return false;
	}

	public bool IsBio3()
	{
		return false;
	}

	public bool IsBattleRoyaleMode()
	{
		return false;
	}

	public bool IsRpgAnnihilationModel()
	{
		return false;
	}

	public bool IsRpgRelive()
	{
		return false;
	}

	public bool IsShowGateUnderAttack()
	{
		return false;
	}

	public bool IsBioEvolution()
	{
		return false;
	}

	public bool IsRpgSpecialMode()
	{
		return false;
	}

	public bool IsRpgTowerMode()
	{
		return false;
	}

	public bool IsBioEvolutionChallengeMode()
	{
		return false;
	}

	public bool IsTDMode()
	{
		return false;
	}

	public bool IsNewRpgPvp()
	{
		return false;
	}

	public bool IsMechKing()
	{
		return false;
	}

	public bool IsRpgDuel()
	{
		return false;
	}

	public bool IsRpgHolidayMode()
	{
		return false;
	}

	public bool IsAcg()
	{
		return false;
	}
}
