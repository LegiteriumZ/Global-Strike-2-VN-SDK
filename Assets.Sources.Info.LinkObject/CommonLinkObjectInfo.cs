using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.LinkObject;

public class CommonLinkObjectInfo : AbstractLinkObjectInfo
{
	public int Width;

	public int Height;

	private SpriteRenderer _spriteRenderer;

	public CommonLinkObjectInfo()
	{
		Width = 256;
		Height = 64;
	}

	public override void RenderEntity(SceneObjectEntity entity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
		gameObject.transform.position = dest;
		if (_spriteRenderer == null)
		{
			_spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
		}
		if (_spriteRenderer != null)
		{
			_spriteRenderer.size = new Vector2((float)Width * entity.scale.Scale.z, Height);
		}
		VectorCoordConverter.SsjjToUnity(entity.linkObject.LerpEnd, out var dest2);
		gameObject.transform.LookAt(dest2);
	}
}
