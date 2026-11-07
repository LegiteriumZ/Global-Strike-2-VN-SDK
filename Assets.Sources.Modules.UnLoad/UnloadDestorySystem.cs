using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.UnLoad;

public class UnloadDestorySystem : IEntityPostDestroySystem
{
	private readonly IGroup<UnloadEntity> _destorys;

	public UnloadDestorySystem(Contexts contexts)
	{
		_destorys = contexts.unload.GetGroup(UnloadMatcher.AllOf(UnloadMatcher.Destroy));
	}

	public void OnEntityPostDestroy()
	{
		foreach (UnloadEntity destory in _destorys)
		{
			destory.Destroy();
		}
	}
}
