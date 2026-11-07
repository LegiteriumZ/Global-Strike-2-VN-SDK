using Assets.Sources.Constant.Career;

namespace Assets.Sources.Info.GameRule;

public class BiochemicalGameRule : DefaultGameRule
{
	public BiochemicalGameRule()
	{
		ShowRadarEnemy = false;
	}

	public override bool IsShowLowHp(string career, long hp)
	{
		if ((PlayerCareerConstantUtility.IsDoun(career) || PlayerCareerConstantUtility.IsEmpress(career)) && hp < 500 && hp > 0)
		{
			return true;
		}
		return false;
	}

	public override int GetTipsIndex()
	{
		return 2;
	}

	public override bool IsShowEnemyHpBar()
	{
		return true;
	}

	public override float GetStealthAlpha1()
	{
		return 0.2f;
	}

	public override float GetStealthAlpha2()
	{
		return 0.15f;
	}

	public override float GetStealthAlpha3()
	{
		return 0.1f;
	}

	public override float GetStealthAlpha4()
	{
		return 0f;
	}
}
