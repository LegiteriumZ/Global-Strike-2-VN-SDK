using Assets.Sources.Components.SceneObject.Npc;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.NewNpc.StatusEffect;

public class NpcChickenEffectRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _group;

	public NpcChickenEffectRenderSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo, SceneObjectMatcher.ChickenUnityObjects));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _group)
		{
			ChickenUnityObjects chickenUnityObjects = item.chickenUnityObjects;
			bool flag = (item.npcBasicInfo.Current.SkillEffectData & 3) > 0;
			if (chickenUnityObjects.Root.IsActiveSelf() != flag)
			{
				chickenUnityObjects.Root.SetObjectActive(flag);
			}
			if (flag)
			{
				chickenUnityObjects.ProgressImage.fillAmount = (float)item.npcBasicInfo.Current.EffectData / 10f;
				chickenUnityObjects.TimeText.text = item.npcBasicInfo.Current.EffectData.ToString();
			}
		}
	}
}
