public interface IPlayerDataProvider : IDataProvider
{
	int EffectLevel();

	int ViewAnimId();

	int ViewAnimCurrentTime();

	int ViewAnimTime();

	int TorsoAnimId();

	int LegAnimId();

	int TorsoAnimCurrentTime();

	int LegAnimCurrentTime();

	int GetWeaponState();

	int GetPlayerId();

	int GetPlayerHp();

	bool HasStatus(int a);

	int getStatusNum(int a);

	float getStatusScale(int a);

	bool HasPlayerStateFlag(int a);

	bool IsRightFiring();

	bool IsLeftFiring();

	bool GetEventParticle(int a);

	bool GetSameLevelEventParticle(int a);
}
