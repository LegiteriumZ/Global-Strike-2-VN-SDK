using System;
using Assets.Sources.Components.Interface.Info.GameRule;
using SSJJAsset.Asset;

namespace Assets.Tests.PlayMode.Cross;

public class TestCrossGameRule : IGameRule
{
	protected bool GoldPig;

	protected bool Jump;

	protected bool Bot;

	protected bool FreeRadarScale;

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

	protected bool Personal;

	protected bool HideRadarDeadImage;

	protected bool ShowRadarEnemy;

	protected bool NewVariantsGrowUp;

	protected bool RefreshSkillCdWhenDounDead;

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

	public TestCrossGameRule()
	{
		ShowAddHpCross = true;
	}

	public virtual bool IsJump()
	{
		return Jump;
	}

	public virtual bool IsBot()
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
		throw new NotImplementedException();
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
		throw new NotImplementedException();
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
		throw new NotImplementedException();
	}

	public bool IsRpgRelive()
	{
		throw new NotImplementedException();
	}

	public bool IsShowGateUnderAttack()
	{
		throw new NotImplementedException();
	}

	public bool IsBioEvolution()
	{
		throw new NotImplementedException();
	}

	public bool IsRpgSpecialMode()
	{
		throw new NotImplementedException();
	}

	public bool IsRpgTowerMode()
	{
		throw new NotImplementedException();
	}

	public bool IsBioEvolutionChallengeMode()
	{
		throw new NotImplementedException();
	}

	public bool IsTDMode()
	{
		throw new NotImplementedException();
	}

	public bool IsNewRpgPvp()
	{
		throw new NotImplementedException();
	}

	public bool IsMechKing()
	{
		throw new NotImplementedException();
	}

	public bool IsRpgDuel()
	{
		throw new NotImplementedException();
	}

	public bool IsRpgHolidayMode()
	{
		throw new NotImplementedException();
	}

	public bool IsAcg()
	{
		throw new NotImplementedException();
	}
}
