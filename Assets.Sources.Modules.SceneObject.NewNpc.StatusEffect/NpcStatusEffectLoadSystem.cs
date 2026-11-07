using Assets.Sources.Components.Common;
using Assets.Sources.Framework;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Entitas;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Thread;

namespace Assets.Sources.Modules.SceneObject.NewNpc.StatusEffect;

public class NpcStatusEffectLoadSystem : IResourceLoadSystem
{
	private SceneObjectContext _sceneObjectContext;

	private IGroup<SceneObjectEntity> _npcGroup;

	public NpcStatusEffectLoadSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_npcGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NpcBasicInfo));
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		foreach (SceneObjectEntity item in _npcGroup)
		{
			NpcEntityData current = item.npcBasicInfo.Current;
			int num = (int)current.SkillEffectLevel;
			for (int i = 0; i < 32; i++)
			{
				int num2 = 1 << i;
				if ((num & num2) == 0)
				{
					continue;
				}
				SkillId skillId = new SkillId(current.Id, num2);
				if (_sceneObjectContext.GetEntityWithSkillId(skillId) == null)
				{
					DragoonStatusEffectData dragoonStatusEffectData = ParticleManager.Instance().GetDragoonStatusEffectData(num2);
					if (dragoonStatusEffectData == null)
					{
						this.LogErrorFormat("can not find dragon status {0}", num2);
						continue;
					}
					SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
					sceneObjectEntity.AddSkillId(skillId);
					sceneObjectEntity.AddNpcStatusEffect(current.Id, num2);
					sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(dragoonStatusEffectData.AssetInfo), null);
				}
			}
		}
	}
}
