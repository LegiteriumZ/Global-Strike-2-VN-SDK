using Assets.Res.Assets.Scripts;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.LinkObject;

public class FlashLinkObjectInfo : AbstractLinkObjectInfo
{
	public int Width;

	public int Height;

	public FlashLinkObjectInfo()
	{
		Width = 100;
		Height = 64;
	}

	public override void RenderEntity(SceneObjectEntity entity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		gameObject.name = "move_" + entity.linkObject.Now.LinkType;
		VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
		gameObject.transform.position = dest;
		VectorCoordConverter.SsjjToUnity(entity.linkObject.LerpEnd, out var dest2);
		gameObject.transform.position = Vector3.zero;
		FlashLink component = gameObject.GetComponent<FlashLink>();
		component.start = dest;
		component.end = dest2;
	}
}
