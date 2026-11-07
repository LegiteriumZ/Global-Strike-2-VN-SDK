using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Modules.SceneObject;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.HoleLogic;

internal class SpecialHoleLogic : IHoleLogic, IParamParse
{
	private int _res;

	public void CreateBulletHoleEntity(Vector3 start, Vector3 position, Vector3 normal, int ownerId, bool isKnife, bool isSpecialMode)
	{
		SceneObjectFactory.Instance.CreateBulletHoleEntity(position, normal, ownerId, _res);
	}

	public void Parse(string param)
	{
		_res = int.Parse(param);
	}
}
