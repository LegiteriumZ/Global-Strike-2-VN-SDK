using System;
using System.Collections.Generic;
using Entitas;
using SSJJBase.Logger;

namespace Assets.Sources.Framework.System;

public abstract class FrameworkSystemBase<T> : Entitas.Systems
{
	public abstract List<T> Systems { get; }

	public abstract void SingleExecute(T system);

	protected void Init()
	{
	}

	public override void Execute()
	{
		ExecuteSystems();
	}

	protected void ExecuteSystems()
	{
		for (int i = 0; i < Systems.Count; i++)
		{
			T system = Systems[i];
			try
			{
				SingleExecute(system);
			}
			catch (Exception arg)
			{
				this.LogErrorFormat("error executing {0}: {1}", system.GetType(), arg);
			}
		}
	}
}
