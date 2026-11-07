using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class SkillBufferEffectRender : AbstractSceneBuffEffectRender
{
	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		if (entity.HasSceneBuff)
		{
			Transform transform = effectGameObject.transform.Find("GameObject/0/model");
			Transform transform2 = effectGameObject.transform.Find("GameObject/1/model");
			Transform transform3 = effectGameObject.transform.Find("GameObject/2/sprite");
			Transform transform4 = effectGameObject.transform.Find("GameObject/2/sprite1");
			Transform transform5 = effectGameObject.transform.Find("GameObject/2/3/sprite");
			transform5.GetComponent<SpriteAnimation>().SetImageSprite(transform5.GetComponent<SpriteList>().Sprites[SkillNameConstant.GetSkillIndex(entity.SceneBuff.Data.BufName.ToUpper())]);
			if (SkillNameConstant.IsDisposableSkill(entity.SceneBuff.Data.BufName.ToUpper()))
			{
				transform3.GetComponent<SpriteAnimation>().Sprites = transform3.GetComponent<SpriteList>().Sprites;
				transform.GetComponent<ModelTextureSheetAnimation>().Textures = transform.GetComponent<TextureList>().Textures;
				transform2.SetObjectActive(isactive: false);
				transform4.SetObjectActive(isactive: false);
				transform.SetObjectActive(isactive: true);
				transform3.SetObjectActive(isactive: true);
			}
			else
			{
				transform4.GetComponent<SpriteAnimation>().Sprites = transform4.GetComponent<SpriteList>().Sprites;
				transform2.GetComponent<ModelTextureSheetAnimation>().Textures = transform2.GetComponent<TextureList>().Textures;
				transform.SetObjectActive(isactive: false);
				transform3.SetObjectActive(isactive: false);
				transform2.SetObjectActive(isactive: true);
				transform4.SetObjectActive(isactive: true);
			}
		}
	}
}
