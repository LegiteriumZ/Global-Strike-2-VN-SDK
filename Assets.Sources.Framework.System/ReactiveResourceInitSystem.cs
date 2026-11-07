using Entitas;

namespace Assets.Sources.Framework.System;

public abstract class ReactiveResourceInitSystem<T> : ReactiveSystem<T>, IResourceInitSystem where T : Entity
{
	protected ReactiveResourceInitSystem(IContext<T> context)
		: base(context)
	{
		Activate();
	}

	protected ReactiveResourceInitSystem(ICollector<T> collector)
		: base(collector)
	{
	}

	public void OnInitResources()
	{
		Execute();
	}
}
