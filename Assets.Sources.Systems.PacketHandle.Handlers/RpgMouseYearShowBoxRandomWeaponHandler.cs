using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Rpg;
using NetData;
using SSJJBase.Logger;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgMouseYearShowBoxRandomWeaponHandler : ApcPacketHandler<ShowBaoxiangChooseWeaponUI>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgMouseYearShowBoxRandomWeaponHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 257;
	}

	public override void Handle(ShowBaoxiangChooseWeaponUI data)
	{
		MouseYearComponent mouseYear = _gameRuleContext.mouseYear;
		if (mouseYear.ChooseDropWeaponList == null)
		{
			mouseYear.ChooseDropWeaponList = new List<string>();
		}
		mouseYear.ChooseDropWeaponList.Clear();
		mouseYear.IsChooseDropWeaponList = true;
		foreach (string codeName in data.CodeNameList)
		{
			mouseYear.ChooseDropWeaponList.Add(codeName);
		}
		for (int i = 0; i < mouseYear.ChooseDropWeaponList.Count; i++)
		{
			this.Info("ChooseDropWeaponList handle" + i + "   " + mouseYear.ChooseDropWeaponList[i]);
		}
	}
}
