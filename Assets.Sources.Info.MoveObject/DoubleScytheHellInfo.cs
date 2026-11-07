using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.MoveObject;

internal class DoubleScytheHellInfo : AbstractMoveObjectInfo
{
	private GameObject gameObj;

	public override void InitEntity(SceneObjectEntity entity)
	{
		base.InitEntity(entity);
	}

	public override void RenderEntity(SceneObjectEntity entity)
	{
		gameObj = entity.unityObjects.LoadResults[0].GameObject;
		if (!(gameObj == null))
		{
			VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
			gameObj.transform.position = dest;
			UpdateRotation();
		}
	}

	private void UpdateRotation()
	{
		gameObj.transform.Rotate(0f, 360f * Time.deltaTime * 5f, 0f);
	}
}
