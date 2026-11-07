using System;
using Entitas;
using SSJJBase.Logger;
using SSJJBase.Thread;

namespace Assets.Sources.Framework;

public abstract class LoadAndInitResourceSystem<TEntity> : IResourceLoadSystem, IResourceInitSystem where TEntity : class, IEntity
{
	protected abstract IGroup<TEntity> GetLoadGroup();

	protected abstract IGroup<TEntity> GetInitGroup();

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		foreach (TEntity item in GetLoadGroup())
		{
			OnLoadEntityResource(item);
		}
	}

	protected abstract void OnLoadEntityResource(TEntity entity);

	public void OnInitResources()
	{
		foreach (TEntity item in GetInitGroup())
		{
			if (!IsResourceMatch(item))
			{
				CleanResouceComponent(item);
				continue;
			}
			try
			{
				OnInitEntityResource(item);
			}
			catch (Exception message)
			{
				this.LogError(message);
			}
			finally
			{
				CleanResouceComponent(item);
			}
		}
	}

	protected abstract bool IsResourceMatch(TEntity entity);

	protected abstract void CleanResouceComponent(TEntity entity);

	protected abstract void OnInitEntityResource(TEntity entity);
}
