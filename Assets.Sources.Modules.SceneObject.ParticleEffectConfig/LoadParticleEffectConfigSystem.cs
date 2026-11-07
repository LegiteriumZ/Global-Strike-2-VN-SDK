using System.Collections.Generic;
using System.Text;
using Assets.Sources.Components.SceneObject;
using Assets.Sources.Framework;
using Assets.Sources.Particle;
using Entitas;
using SSJJAsset.Asset;

namespace Assets.Sources.Modules.SceneObject.ParticleEffectConfig;

public class LoadParticleEffectConfigSystem : LoadAndInitResourceSystem<SceneObjectEntity>
{
	private readonly IGroup<SceneObjectEntity> _loadGroup;

	private readonly IGroup<SceneObjectEntity> _initGroup;

	private readonly StringBuilder _stringBuilder = new StringBuilder();

	public LoadParticleEffectConfigSystem(Contexts contexts)
	{
		_loadGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NeedResource).NoneOf(SceneObjectMatcher.LoadNeedLoadResource, SceneObjectMatcher.NeedLoadResource, SceneObjectMatcher.Destroy));
		_initGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.NeedLoadResource).NoneOf(SceneObjectMatcher.Destroy));
	}

	protected override IGroup<SceneObjectEntity> GetLoadGroup()
	{
		return _loadGroup;
	}

	protected override IGroup<SceneObjectEntity> GetInitGroup()
	{
		return _initGroup;
	}

	protected override void OnLoadEntityResource(SceneObjectEntity entity)
	{
		LoadRequests loadRequests = new LoadRequests();
		NeedResourceComponent needResource = entity.needResource;
		foreach (string needLoadSkill in needResource.NeedLoadSkillList)
		{
			ParticleManager.InitSkillParticleXmlLoadRequests(loadRequests, needLoadSkill);
		}
		entity.AddLoadNeedLoadResource(loadRequests, GetResourceKey(needResource.NeedLoadSkillList));
	}

	private string GetResourceKey(List<string> skills)
	{
		foreach (string skill in skills)
		{
			_stringBuilder.Append(skill);
		}
		string result = _stringBuilder.ToString();
		_stringBuilder.Length = 0;
		return result;
	}

	protected override void OnInitEntityResource(SceneObjectEntity entity)
	{
		foreach (string needLoadSkill in entity.needResource.NeedLoadSkillList)
		{
			ParticleManager.InitSkillParticleXmlLoadResults(entity.needLoadResource.LoadResults, needLoadSkill);
		}
		entity.isDestroy = true;
	}

	protected override bool IsResourceMatch(SceneObjectEntity entity)
	{
		return (string)entity.needLoadResource.Identifier == GetResourceKey(entity.needResource.NeedLoadSkillList);
	}

	protected override void CleanResouceComponent(SceneObjectEntity entity)
	{
		if (!entity.isDestroy)
		{
			entity.RemoveNeedLoadResource();
		}
	}
}
