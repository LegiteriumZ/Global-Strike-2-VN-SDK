using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class SceneBufferEffectRender : AbstractSceneBuffEffectRender
{
	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		if (Entity.HasSceneBuff)
		{
			EffectObject.transform.Find("SceneBuffer_6").gameObject.SetObjectActive(battleRoom.GetRuleModel() == 6);
			EffectObject.transform.Find("SceneBuffer_7").gameObject.SetObjectActive(battleRoom.GetRuleModel() == 7);
			EffectObject.transform.Find("SceneBuffer_30").gameObject.SetObjectActive(battleRoom.GetRuleModel() == 30);
		}
	}
}
