public interface IWeaponDataProvider : IDataProvider
{
	int GetKill();

	int GetPower();

	int GetMaxPower();

	int GetMaxPower2();

	int GetPower2();

	int GetClip();

	int GetClip2();

	int GetCarryClip();

	int GetCarryClip2();

	int GetRpgMaxPower();

	long GetWeaponTimer1();

	long GetNextSkillTimer();

	int GetWeaponFlag();

	int GetIcon1();

	int GetMaxIcon1();

	int GetIcon2();

	int GetMaxIcon2();

	int GetNextAttackTimer();

	int GetNextSecondaryAttackTimer();

	int GetWeaponCd();

	int GetWeaponFov();

	int GetWeaponOwnerId();

	bool IsHoldWeapon(string a);

	bool GetSpecalMode();
}
