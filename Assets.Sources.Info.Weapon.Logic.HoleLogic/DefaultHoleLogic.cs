using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Modules.SceneObject;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.HoleLogic;

internal class DefaultHoleLogic : IHoleLogic, IParamParse
{
	public void CreateBulletHoleEntity(Vector3 start, Vector3 position, Vector3 normal, int ownerId, bool isKnife, bool isSpecialMode)
	{
		if (isKnife)
		{
			SceneObjectFactory.Instance.CreateBulletHoleEntity(position, normal, ownerId, 4);
		}
		else
		{
			SceneObjectFactory.Instance.CreateBulletHoleEntity(position, normal, ownerId, 0);
		}
	}

	public void Parse(string param)
	{
	}
}
