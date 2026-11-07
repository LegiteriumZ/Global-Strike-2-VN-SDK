using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Modules.SceneObject;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.HoleLogic;

internal class EndBowHoleLogic : IHoleLogic, IParamParse
{
	private int _res;

	public void CreateBulletHoleEntity(Vector3 start, Vector3 position, Vector3 normal, int ownerId, bool isKnife, bool isSpecialMode)
	{
		if (!isSpecialMode)
		{
			Vector3 vector = position - start;
			if (isKnife)
			{
				SceneObjectFactory.Instance.CreateBulletHoleEntity(position, normal, ownerId, 4);
			}
			else
			{
				SceneObjectFactory.Instance.CreateBulletHoleEntity(position, vector.normalized, ownerId, _res);
			}
		}
	}

	public void Parse(string param)
	{
		_res = int.Parse(param);
	}
}
