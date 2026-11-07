using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Utility;

internal class UtilityLodSystem : IRenderSystem
{
	private readonly UtilityContext _contexts;

	public UtilityLodSystem(Contexts contexts)
	{
		_contexts = contexts.utility;
	}

	public void OnRender()
	{
	}
}
