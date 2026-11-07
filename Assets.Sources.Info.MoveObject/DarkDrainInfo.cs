using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.MoveObject;

internal class DarkDrainInfo : AbstractMoveObjectInfo
{
	public override void InitEntity(SceneObjectEntity entity)
	{
		base.InitEntity(entity);
	}

	public override void RenderEntity(SceneObjectEntity entity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
		gameObject.transform.position = dest;
	}
}
