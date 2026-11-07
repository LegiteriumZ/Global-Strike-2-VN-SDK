using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.SceneBufferEffect.Render;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class RobChickenBufferEffectRender : AbstractSceneBuffEffectRender
{
	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		if (Entity.HasSceneBuff)
		{
			Transform transform = EffectObject.transform.Find("GameObject/0/model");
			if (Entity.SceneBuff.Data.Lv >= 5)
			{
				transform.GetComponent<MeshFilter>().mesh = transform.GetComponent<MeshList>().Meshes[0];
				transform.GetComponent<ModelTextureSheetAnimation>().Textures = transform.GetComponent<TextureList>().Textures;
			}
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
	}
}
