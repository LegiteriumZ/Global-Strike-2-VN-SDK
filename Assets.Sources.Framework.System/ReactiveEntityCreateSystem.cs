using Entitas;

namespace Assets.Sources.Framework.System;

public abstract class ReactiveEntityCreateSystem<T> : ReactiveSystem<T>, IEntityCreateSystem where T : Entity
{
	protected ReactiveEntityCreateSystem(IContext<T> context)
		: base(context)
	{
		Activate();
	}

	protected ReactiveEntityCreateSystem(ICollector<T> collector)
		: base(collector)
	{
	}

	public void OnEntityCreate()
	{
		Execute();
	}
}
