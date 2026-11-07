using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class WayPointBufferEffectRender : AbstractSceneBuffEffectRender
{
	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		if (!entity.HasSceneBuff)
		{
			return;
		}
		Transform transform = effectGameObject.transform.Find("GameObject/1/sprite");
		Transform transform2 = effectGameObject.transform.Find("GameObject/3/sprite");
		string bufName = entity.SceneBuff.Data.BufName;
		if (!(bufName == "kongzhiqi1"))
		{
			if (bufName == "kongzhiqi2")
			{
				transform.GetComponent<SpriteRenderer>().sprite = transform.GetComponent<SpriteList>().Sprites[1];
				transform2.GetComponent<SpriteRenderer>().sprite = transform.GetComponent<SpriteList>().Sprites[1];
			}
		}
		else
		{
			transform.GetComponent<SpriteRenderer>().sprite = transform.GetComponent<SpriteList>().Sprites[0];
			transform2.GetComponent<SpriteRenderer>().sprite = transform.GetComponent<SpriteList>().Sprites[0];
		}
	}
}
