using Entitas;

namespace Assets.Sources.Framework.System;

public class ModuleInitSystem : IInitializeSystem, ISystem
{
	private readonly IGameModule _module;

	public ModuleInitSystem(IGameModule module)
	{
		_module = module;
	}

	public void Initialize()
	{
		foreach (IModuleInitSystem initializeSystem in _module.InitializeSystems)
		{
			initializeSystem.OnInitModule();
		}
	}
}
