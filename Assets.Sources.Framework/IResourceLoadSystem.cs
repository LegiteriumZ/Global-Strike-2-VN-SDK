using SSJJBase.Thread;

namespace Assets.Sources.Framework;

public interface IResourceLoadSystem
{
	void OnLoadResources(ICoRoutineManager coRoutineManager);
}
