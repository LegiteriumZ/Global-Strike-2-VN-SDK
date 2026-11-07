using Assets.Sources.Components.Interface;

namespace Assets.Sources.Framework;

public abstract class PredicationInitSystemBase<T> : IPredicationInitSystem where T : IPredicationInitComponent<T>, new()
{
	private PredicationInitComponentHistory<T> _initComponentHistory = new PredicationInitComponentHistory<T>();

	public T TempValue = new T();

	public string LastErrorMsg => _initComponentHistory.LastErrorMsg;

	public abstract T CurrentComponent { get; }

	public virtual void OnPredicatoinInit()
	{
		GetComponentFromSnapshot(CurrentComponent);
	}

	public virtual void SavePredicationState(int cmdSeq)
	{
		_initComponentHistory.Save(cmdSeq, CurrentComponent);
	}

	public bool HasPredicatonError(int cmdSeq)
	{
		GetComponentFromSnapshot(TempValue);
		return !_initComponentHistory.IsApproximatelyEqual(cmdSeq, TempValue);
	}

	public virtual void OnPredicatoinError(int cmdSeq)
	{
	}

	public virtual void OnPredicatoinSucc(int cmdSeq)
	{
	}

	public virtual bool ShouldResetAll()
	{
		return true;
	}

	public PredicationInitComponentHistory<T> GetHistory()
	{
		return _initComponentHistory;
	}

	public T GetHistory(int cmdSeq)
	{
		return _initComponentHistory.GetHistory(cmdSeq);
	}

	public abstract void GetComponentFromSnapshot(T comp);

	public virtual void AfterPredicationInit()
	{
	}
}
