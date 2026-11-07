using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class TianhuoshizheEffectRender : AbstractSceneBuffEffectRender
{
	private static readonly Vector3 Offset = new Vector3(0f, 0f, 10f);

	public override Vector3 GetOffset(IBattleRoom battleRoom)
	{
		return Offset;
	}

	public override Vector3 GetRotation(SceneObjectEntity target)
	{
		return new Vector3(target.sceneBuff.Data.Pitch - 90f, 0f - target.sceneBuff.Data.Yaw - 180f, 0f);
	}
}
