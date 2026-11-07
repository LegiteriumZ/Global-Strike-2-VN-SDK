using System;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Info.Weapon.Logic;
using SSJJAnim.Weapon;

namespace Assets.Sources.Info.Weapon.WeaponInfo.Info;

internal class RifleScopeWeaponInfo : DefaultWeaponInfo, IGunWeaponInfo, IWeaponInfo, IEntitsWeaponInfo, IRifleScppeWeaponInfo, IParseSpecial
{
	public IKickbackLogic KickbackLogic { get; set; }

	public int FovAttackInterval { get; set; }

	public int FovDelayTime { get; set; }

	public IRailLogic RailLogic { get; set; }

	public RifleScopeWeaponInfo(string name, string attackType, string specialAttackType, bool isSharedPredication)
		: base(name, attackType, specialAttackType, isSharedPredication)
	{
	}

	public void Parse(WeaponTable.Row rowData)
	{
		int[] array = new int[2];
		string[] array2 = rowData.RifleScopeParams.Split(',');
		if (array2.Length != 2)
		{
			throw new Exception($"param error:{rowData.RifleScopeParams}");
		}
		for (int i = 0; i < array2.Length; i++)
		{
			if (string.IsNullOrEmpty(array2[i]) || !int.TryParse(array2[i], out array[i]))
			{
				throw new Exception($"param error:{rowData.RifleScopeParams}");
			}
		}
		FovAttackInterval = array[0];
		FovDelayTime = array[1];
	}
}
