using Assets.Sources.Free.Weapon;
using I2.Loc;

namespace Assets.Sources.Utils.Ui;

public static class LanguageUtils
{
	public static string GetWeaponCnName(string weaponName)
	{
		string text = ScriptLocalization.Get(weaponName.ToUpper() + "_USEDNAME");
		if (string.IsNullOrEmpty(text))
		{
			if (FreeWeaponManager.WeaponConfigs.TryGetValue(weaponName, out var value))
			{
				text = value.WeaponName;
			}
			else
			{
				text = ScriptLocalization.Get(weaponName);
				if (string.IsNullOrEmpty(text))
				{
					text = weaponName;
				}
			}
		}
		return text;
	}
}
