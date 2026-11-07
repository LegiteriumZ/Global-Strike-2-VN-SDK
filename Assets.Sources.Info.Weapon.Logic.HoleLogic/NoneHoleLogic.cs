using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.HoleLogic;

internal class NoneHoleLogic : IHoleLogic, IParamParse
{
	public void CreateBulletHoleEntity(Vector3 start, Vector3 position, Vector3 normal, int ownerId, bool isKnife, bool isSpecialMode)
	{
	}

	public void Parse(string param)
	{
	}
}
