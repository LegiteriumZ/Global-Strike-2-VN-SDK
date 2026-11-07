namespace Assets.Sources.Info.Weapon.Logic.KickbackLogic;

internal class Ak47UniqueKickbackLogic : IKickbackLogic, IParamParse
{
	private G18UniqueKickbackLogic normal = new G18UniqueKickbackLogic();

	private G18UniqueKickbackLogic special = new G18UniqueKickbackLogic();

	public void KickBack(int seed, PlayerEntity player, WeaponEntity currentWeapon, bool isWeightlessness)
	{
		if (currentWeapon.special.SpecialMode)
		{
			special.KickBack(seed, player, currentWeapon, isWeightlessness);
		}
		else
		{
			normal.KickBack(seed, player, currentWeapon, isWeightlessness);
		}
	}

	public void Parse(string param)
	{
		int num = findIndex(param, 28, ',');
		if (num != -1)
		{
			special.Parse(param.Substring(0, num));
			normal.Parse(param.Substring(num + 1));
		}
	}

	private int findIndex(string s, int cnt, char x)
	{
		int num = 0;
		for (int i = 0; i < s.Length; i++)
		{
			if (s[i] == x)
			{
				num++;
				if (num == cnt)
				{
					return i;
				}
			}
		}
		return -1;
	}
}
