using System;
using weapon.predicateSystem;
using weapon.predicateSystem.implementSeparately;

namespace Assets.Sources.Modules.Player.Attack.SharePredicationApapter;

public class WeaponPropertiesAdapter : IWeaponPropertiesAdapter
{
	public WeaponEntity WeaponEntity;

	public int GetShotsFired()
	{
		return WeaponEntity.attack.ShotsFired;
	}

	public int GetKill()
	{
		return WeaponEntity.basicInfo.Data.Kill;
	}

	public void SetLevel(int level)
	{
		WeaponEntity.basicInfo.Data.Level = level;
	}

	public void SetKill(int kill)
	{
		WeaponEntity.basicInfo.Data.Kill = kill;
	}

	public int GetClip()
	{
		return WeaponEntity.clip.Clip;
	}

	public void SetClip(int n)
	{
		WeaponEntity.clip.Clip = n;
	}

	public void SetCarryClip(int n)
	{
		WeaponEntity.clip.CarryClip = n;
	}

	public void SetCarryClip2(int n)
	{
		WeaponEntity.clip.CarryClip2 = n;
	}

	public int GetCarryClip()
	{
		return WeaponEntity.clip.CarryClip;
	}

	public int GetCarryClip2()
	{
		return WeaponEntity.clip.CarryClip2;
	}

	public int GetClip2()
	{
		return WeaponEntity.clip.Clip2;
	}

	public void SetClip2(int clip2)
	{
		WeaponEntity.clip.Clip2 = clip2;
	}

	public int GetAttackInterval()
	{
		return WeaponEntity.basicInfo.Info.AttackInterval;
	}

	public void SetAttackInterval(int attackInterval)
	{
		WeaponEntity.basicInfo.Info.AttackInterval = attackInterval;
	}

	public int GetEffectLevel()
	{
		return WeaponEntity.special.EffectLevel;
	}

	public void SetEffectLevel(int effectLevel)
	{
		WeaponEntity.special.EffectLevel = effectLevel;
	}

	public int GetPower2()
	{
		return WeaponEntity.power.Power2;
	}

	public void SetPower2(int power2)
	{
		WeaponEntity.power.Power2 = power2;
	}

	public int GetMaxPower2()
	{
		return WeaponEntity.power.MaxPower2;
	}

	public void SetMaxPower2(int maxPower2)
	{
		WeaponEntity.power.MaxPower2 = maxPower2;
	}

	public int GetWeaponType()
	{
		return WeaponEntity.basicInfo.Info.WeaponType;
	}

	public void SetPenetration(int penetration)
	{
	}

	public int GetPenetration()
	{
		return 1;
	}

	public float GetRangeModifier()
	{
		throw new NotImplementedException();
	}

	public void SetRangeModifier(float rangeModifier)
	{
		throw new NotImplementedException();
	}

	public void SetNextSkillTimer(long nextSkillTimer)
	{
		WeaponEntity.basicInfo.Data.NextSkillTimer = (uint)nextSkillTimer;
	}

	public int GetMaxClip()
	{
		return WeaponEntity.clip.MaxClip;
	}

	public void SetMaxClip(int maxClip)
	{
		WeaponEntity.clip.MaxClip = maxClip;
	}

	public void SetMaxCarryClip2(int maxCarryClip2)
	{
	}

	public int GetMaxCarryClip2()
	{
		return WeaponEntity.clip.CarryClip2;
	}

	public int GetMaxClip2()
	{
		return WeaponEntity.clip.Clip2;
	}

	public void SetMaxClip2(int maxClip2)
	{
	}

	public int GetClipPerShot()
	{
		return WeaponEntity.basicInfo.Info.ClipPerShot;
	}

	public int GetMaxCarryClip()
	{
		return WeaponEntity.clip.MaxCarryClip;
	}

	public void SetMaxCarryClip(int maxCarryClip)
	{
		WeaponEntity.clip.MaxCarryClip = maxCarryClip;
	}

	public bool IsSpecialMode()
	{
		return WeaponEntity.special.SpecialMode;
	}

	public void SetSpecialMode(bool specialMode)
	{
		WeaponEntity.special.SpecialMode = specialMode;
	}

	public int GetPower()
	{
		return WeaponEntity.power.Power;
	}

	public void SetPower(int power)
	{
		WeaponEntity.power.Power = power;
	}

	public int GetMaxPower()
	{
		return WeaponEntity.power.MaxPower;
	}

	public void SetMaxPower(int maxPower)
	{
		WeaponEntity.power.MaxPower = maxPower;
	}

	public int GetRpgMaxPower()
	{
		return WeaponEntity.basicInfo.Data.RpgMaxPower;
	}

	public void SetRpgMaxPower(int rpgMaxPower)
	{
		WeaponEntity.basicInfo.Data.RpgMaxPower = rpgMaxPower;
	}

	public void Deploy()
	{
		SetShotsFired(0);
		SetBurstModeShotsFired(0);
		SetAccuracy(WeaponEntity.basicInfo.Info.DefaultAccuracy);
	}

	public int ShotDistance(int buttons)
	{
		return 20000;
	}

	public bool IsReloadStart()
	{
		return WeaponEntity.reload.IsStartReload;
	}

	public void SetReloadStart(bool startReload)
	{
		WeaponEntity.reload.IsStartReload = startReload;
	}

	public bool IsReloadStart2()
	{
		return WeaponEntity.reload.IsStartReload2;
	}

	public void SetReloadStart2(bool startReload2)
	{
		WeaponEntity.reload.IsStartReload2 = startReload2;
	}

	public void SetAccuracyDivisor(double accuracyDivisor)
	{
		WeaponEntity.basicInfo.Info.AccuracyDivisor = (float)accuracyDivisor;
	}

	public void SetAccuracyOffset(double accuracyOffset)
	{
		WeaponEntity.basicInfo.Info.AccuracyOffset = (float)accuracyOffset;
	}

	public void SetMaxInaccuracy(double maxInaccuracy)
	{
		WeaponEntity.basicInfo.Info.MaxInaccuracy = (float)maxInaccuracy;
	}

	public void SetAccuracy(double accuracy)
	{
		WeaponEntity.accuracy.Accuracy = (float)accuracy;
	}

	public void SetDefaultAccuracy(double defaultAccuracy)
	{
		WeaponEntity.basicInfo.Info.DefaultAccuracy = (float)defaultAccuracy;
	}

	public bool IsMeleeStartAttack()
	{
		return WeaponEntity.meleeAttack.MeleeStartAttack;
	}

	public void SetMeleeStartAttack(bool meleeStartAttack)
	{
		WeaponEntity.meleeAttack.MeleeStartAttack = meleeStartAttack;
	}

	public long GetNextAttackTimer()
	{
		return (long)WeaponEntity.attack.NextAttackTimer;
	}

	public void SetNextAttackTimer(long nextAttackTimer)
	{
		WeaponEntity.attack.NextAttackTimer = (int)nextAttackTimer;
	}

	public long GetWeaponTimer1()
	{
		return WeaponEntity.basicInfo.Data.WeaponTimer1;
	}

	public void SetWeaponTimer1(long weaponTimer1)
	{
		WeaponEntity.basicInfo.Data.WeaponTimer1 = (uint)weaponTimer1;
	}

	public long GetNextSecondaryAttackTimer()
	{
		return (long)WeaponEntity.attack.NextSecondaryAttackTimer;
	}

	public void SetNextSecondaryAttackTimer(long nextSecondaryAttackTimer)
	{
		WeaponEntity.attack.NextSecondaryAttackTimer = nextSecondaryAttackTimer;
	}

	public long GetNextSkillTimer()
	{
		return WeaponEntity.basicInfo.Data.NextSkillTimer;
	}

	public int GetBurstModeShotsFired()
	{
		return WeaponEntity.burstMode.BurstModeShotsFired;
	}

	public void SetBurstModeShotsFired(int burstModeShotsFired)
	{
		WeaponEntity.burstMode.BurstModeShotsFired = burstModeShotsFired;
	}

	public long GetReloadEndTime()
	{
		return (long)WeaponEntity.reload.ReloadEndTime;
	}

	public void SetReloadEndTime(long reloadEndTime)
	{
		WeaponEntity.reload.ReloadEndTime = reloadEndTime;
	}

	public long GetReloadEndTime2()
	{
		return (long)WeaponEntity.reload.ReloadEndTime2;
	}

	public void SetReloadEndTime2(long reloadEndTime2)
	{
		WeaponEntity.reload.ReloadEndTime2 = reloadEndTime2;
	}

	public double GetSpread()
	{
		return WeaponEntity.spread.Spread;
	}

	public void SetSpread(double spread)
	{
		WeaponEntity.spread.Spread = (float)spread;
	}

	public double GetAccuracyDivisor()
	{
		return WeaponEntity.basicInfo.Info.AccuracyDivisor;
	}

	public double GetAccuracyOffset()
	{
		return WeaponEntity.basicInfo.Info.AccuracyOffset;
	}

	public double GetMaxInaccuracy()
	{
		return WeaponEntity.basicInfo.Info.MaxInaccuracy;
	}

	public double GetAccuracy()
	{
		return WeaponEntity.accuracy.Accuracy;
	}

	public double GetDefaultAccuracy()
	{
		return WeaponEntity.basicInfo.Info.DefaultAccuracy;
	}

	public int GetSlashStabTime()
	{
		return WeaponEntity.basicInfo.Info.SlashStabTime;
	}

	public void SetSlashStabTime(int slashStabTime)
	{
		WeaponEntity.basicInfo.Info.SlashStabTime = slashStabTime;
	}

	public int GetStabSlashTime()
	{
		return WeaponEntity.basicInfo.Info.StabSlashTime;
	}

	public void SetStabSlashTime(int stabSlashTime)
	{
		WeaponEntity.basicInfo.Info.StabSlashTime = stabSlashTime;
	}

	public int GetStabStabTime()
	{
		return WeaponEntity.basicInfo.Info.StabStabTime;
	}

	public void SetStabStabTime(int stabStabTime)
	{
		WeaponEntity.basicInfo.Info.StabStabTime = stabStabTime;
	}

	public int GetSlashSlashTime()
	{
		return WeaponEntity.basicInfo.Info.SlashSlashTime;
	}

	public void SetSlashSlashTime(int slashSlashTime)
	{
		WeaponEntity.basicInfo.Info.SlashSlashTime = slashSlashTime;
	}

	public int GetDelayAttackSlashTime()
	{
		return WeaponEntity.basicInfo.Info.DelayAttackSlashTime;
	}

	public void SetDelayAttackSlashTime(int delayAttackSlashTime)
	{
		WeaponEntity.basicInfo.Info.DelayAttackSlashTime = delayAttackSlashTime;
	}

	public int GetDelayAttackSlashTime2()
	{
		return WeaponEntity.basicInfo.Info.DelayAttackSlashTime2;
	}

	public void SetDelayAttackSlashTime2(int delayAttackSlashTime2)
	{
		WeaponEntity.basicInfo.Info.DelayAttackSlashTime2 = delayAttackSlashTime2;
	}

	public int GetDelayAttackStabTime()
	{
		return WeaponEntity.basicInfo.Info.DelayAttackStabTime;
	}

	public void SetDelayAttackStabTime(int delayAttackStabTime)
	{
		WeaponEntity.basicInfo.Info.DelayAttackStabTime = delayAttackStabTime;
	}

	public int GetRaiseAttackDelay()
	{
		return WeaponEntity.basicInfo.Info.DelayRaiseAttackTime;
	}

	public void SetRaiseAttackDelay(int raiseAttackDelay)
	{
		WeaponEntity.basicInfo.Info.DelayRaiseAttackTime = raiseAttackDelay;
	}

	public bool IsDelayFire()
	{
		return WeaponEntity.basicInfo.Data.DelayFire;
	}

	public void SetDelayFire(bool delayFire)
	{
		WeaponEntity.basicInfo.Data.DelayFire = delayFire;
	}

	public float GetSpreadScaleY()
	{
		return WeaponEntity.basicInfo.Info.SpreadScaleY;
	}

	public void SetSpreadScaleY(float spreadScaleY)
	{
		WeaponEntity.basicInfo.Info.SpreadScaleY = spreadScaleY;
	}

	public int GetDecreaseShotsFired()
	{
		return WeaponEntity.basicInfo.Data.DecreaseShotsFired;
	}

	public void SetDecreaseShotsFired(int decreaseShotsFired)
	{
		WeaponEntity.basicInfo.Data.DecreaseShotsFired = decreaseShotsFired;
	}

	public void SetShotsFired(int shotsFired)
	{
		WeaponEntity.attack.ShotsFired = shotsFired;
	}

	public bool IsHitPlayer()
	{
		return WeaponEntity.special.IsHitPlayer;
	}

	public void SetHitPlayer(bool hit)
	{
		WeaponEntity.special.IsHitPlayer = hit;
	}

	public float GetMaxChargeTime()
	{
		throw new NotImplementedException();
	}

	public void SetMaxChargeTime(float maxChargeTime)
	{
		throw new NotImplementedException();
	}

	public string GetWeaponName()
	{
		return WeaponEntity.basicInfo.Info.Name;
	}

	public bool IsMeleeAttack()
	{
		return WeaponEntity.meleeAttack.MeleeAttack;
	}

	public void SetMeleeAttack(bool meleeAttack)
	{
		WeaponEntity.meleeAttack.MeleeAttack = meleeAttack;
	}

	public bool IsSecondaryAttackAnim(IPlayerPropertiesAdapter player)
	{
		if (player.GetViewAnimId() == 20 || player.GetViewAnimId() == 72 || player.GetViewAnimId() == 28 || player.GetViewAnimId() == 96 || player.GetViewAnimId() == 16 || player.GetViewAnimId() == 47)
		{
			return true;
		}
		return false;
	}

	public IServerPredicableCallback GetIServerPredicableCallback()
	{
		return ServerPredicableCallback.Instance;
	}

	public PredicationConfig GetPredicationConfig()
	{
		if (WeaponEntity != null && WeaponEntity.hasBasicInfo)
		{
			return WeaponEntity.basicInfo.PredicationConfig;
		}
		return null;
	}

	public int GetShotsFiredSpreadMin()
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			return WeaponEntity.basicInfo.Data.ShotsFiredSpreadMin;
		}
		return 0;
	}

	public int GetShotsFiredSpreadMax()
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			return WeaponEntity.basicInfo.Data.ShotsFiredSpreadMax;
		}
		return 0;
	}

	public int GetShotsFiredSpreadTime()
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			return WeaponEntity.basicInfo.Data.ShotsFiredSpreadTime;
		}
		return 0;
	}

	public int GetDirection()
	{
		if (!WeaponEntity.direction.Direction)
		{
			return 0;
		}
		return 1;
	}

	public void SetDirection(int direction)
	{
		WeaponEntity.direction.Direction = direction == 1;
	}

	public bool IsStartSniperSpecialAttack()
	{
		return false;
	}

	public void SetStartSniperSpecialAttack(bool startSniperSpecialAttack)
	{
		throw new NotImplementedException();
	}

	public int GetSniperSpecialRrightMouseDownTime()
	{
		return 0;
	}

	public void SetSniperSpecialRrightMouseDownTime(int sniperSpecialRrightMouseDownTime)
	{
		throw new NotImplementedException();
	}

	public int GetExtraDecreaseShots()
	{
		return 0;
	}

	public void SetExtraDecreaseShots(int extraDecreaseShots)
	{
		throw new NotImplementedException();
	}

	public bool IsEffectLevelValue(int key)
	{
		return (WeaponEntity.special.EffectLevel & key) > 0;
	}

	public void AddEffectLevel(int effectLevel)
	{
		WeaponEntity.special.EffectLevel |= effectLevel;
	}

	public void RemoveEffectLevel(int effectLevel)
	{
		WeaponEntity.special.EffectLevel &= ~effectLevel;
	}

	PredicationConfig IWeaponPropertiesAdapter.GetPredicationConfig()
	{
		if (WeaponEntity != null && WeaponEntity.hasBasicInfo)
		{
			return WeaponEntity.basicInfo.PredicationConfig;
		}
		return null;
	}

	public int GetWeaponFlag()
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			return WeaponEntity.basicInfo.Data.WeaponFlag;
		}
		return 0;
	}

	public int GetIcon1()
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			return WeaponEntity.basicInfo.Data.Icon1;
		}
		return 0;
	}

	public void SetIcon1(int v)
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			WeaponEntity.basicInfo.Data.Icon1 = v;
		}
	}

	public int GetMaxIcon1()
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			return WeaponEntity.basicInfo.Data.MaxIcon1;
		}
		return 0;
	}

	public void SetMaxIcon1(int v)
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			WeaponEntity.basicInfo.Data.MaxIcon1 = v;
		}
	}

	public int GetIcon2()
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			return WeaponEntity.basicInfo.Data.Icon2;
		}
		return 0;
	}

	public void SetIcon2(int v)
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			WeaponEntity.basicInfo.Data.Icon2 = v;
		}
	}

	public int GetMaxIcon2()
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			return WeaponEntity.basicInfo.Data.MaxIcon2;
		}
		return 0;
	}

	public void SetMaxIcon2(int v)
	{
		if (WeaponEntity.hasBasicInfo && WeaponEntity.basicInfo.Data != null)
		{
			WeaponEntity.basicInfo.Data.MaxIcon2 = v;
		}
	}
}
