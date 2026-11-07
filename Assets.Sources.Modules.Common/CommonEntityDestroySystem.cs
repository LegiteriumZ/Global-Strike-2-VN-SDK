using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.Common;

public class CommonEntityDestroySystem : IEntityPostDestroySystem
{
	private readonly IContextDestroyInfo _contextInfo;

	public CommonEntityDestroySystem(IContextDestroyInfo contextInfo)
	{
		_contextInfo = contextInfo;
	}

	public void OnEntityPostDestroy()
	{
		foreach (IEntity destoryEntity in _contextInfo.DestoryEntities)
		{
			destoryEntity.Destroy();
		}
	}
}
