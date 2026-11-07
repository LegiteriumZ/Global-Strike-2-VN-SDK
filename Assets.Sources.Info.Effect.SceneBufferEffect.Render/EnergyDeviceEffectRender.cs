using Assets.Sources.Components.Interface;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class EnergyDeviceEffectRender : AbstractSceneBuffEffectRender
{
	private TextMesh _textMesh;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		_textMesh = effectGameObject.transform.Find("GameObject/Point/DistanceText").GetComponent<TextMesh>();
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		if (Entity.HasSceneBuff)
		{
			_textMesh.text = StringCache.IntToString(GetDistance(new Vector3(Entity.SceneBuff.Data.X, Entity.SceneBuff.Data.Y, Entity.SceneBuff.Data.Z)));
		}
	}

	protected int GetDistance(Vector3 position)
	{
		return (int)(Vector3.Distance(Contexts.sharedInstance.player.myPlayerEntity.GetCompenstatePos(Contexts.sharedInstance.player.myPlayerEntity.fpos.Change.GetPosIndex()), position) * 0.01f);
	}
}
