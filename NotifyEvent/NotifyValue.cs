using System;
using CommonUtils;
using SSJJBase.Logger;
using UnityEngine;

namespace NotifyEvent;

internal class NotifyValue<T> : IValueNotify, INotify, IEquatable<NotifyValue<T>> where T : struct
{
	private int _frameTry = -1;

	protected T OrigionVal;

	protected T CurrentVal;

	protected Func<T> GetNowFunc;

	protected Action<T, T> InvokeFunc;

	public bool Suspend { get; set; }

	internal void Bind(Func<T> getFunc, Action<T, T> eventFunc, bool isFrameSeparation)
	{
		GetNowFunc = getFunc;
		if (GetNowFunc != null)
		{
			OrigionVal = GetNowFunc();
		}
		else
		{
			OrigionVal = default(T);
		}
		InvokeFunc = eventFunc;
		CurrentVal = OrigionVal;
		if (isFrameSeparation)
		{
			_frameTry = UnityEngine.Random.Range(0, 10);
		}
	}

	public virtual void ForceInvoke(int subEvnetId = -1)
	{
		if (InvokeFunc != null)
		{
			try
			{
				T val = GetNowFunc();
				InvokeFunc(CurrentVal, val);
				CurrentVal = val;
			}
			catch (Exception args)
			{
				this.LogErrorFormat("ForceInvoke Error : {0}", args);
			}
		}
	}

	private static bool GenericValueEqual<M>(M left, M right)
	{
		return left.GetHashCode() == right.GetHashCode();
	}

	public virtual bool TryNotify(int nowFrame)
	{
		if (GetNowFunc == null || InvokeFunc == null)
		{
			return false;
		}
		if (_frameTry != -1 && nowFrame != _frameTry)
		{
			return false;
		}
		try
		{
			T val = GetNowFunc();
			if (!GenericValueEqual(CurrentVal, val) && InvokeFunc != null)
			{
				InvokeFunc(CurrentVal, val);
			}
			CurrentVal = val;
			return true;
		}
		catch (Exception args)
		{
			this.LogErrorFormat("TryNotify Error : {0}", args);
		}
		return false;
	}

	public void AddEvent<T1>(Func<T1> getfunc, Action<T1, T1> setfunc)
	{
		if (getfunc is Func<T>)
		{
			Func<T> func = getfunc as Func<T>;
			if (GetNowFunc != null)
			{
				GetNowFunc = (Func<T>)Delegate.Remove(GetNowFunc, func);
				GetNowFunc = (Func<T>)Delegate.Combine(GetNowFunc, func);
			}
			else
			{
				GetNowFunc = func;
			}
		}
		else
		{
			DebugLogger.LogErrorFormat("{0} will ignore", getfunc);
		}
		if (setfunc is Action<T, T>)
		{
			Action<T, T> action = setfunc as Action<T, T>;
			if (InvokeFunc != null)
			{
				InvokeFunc = (Action<T, T>)Delegate.Remove(InvokeFunc, action);
				InvokeFunc = (Action<T, T>)Delegate.Combine(InvokeFunc, action);
			}
			else
			{
				InvokeFunc = action;
			}
		}
		else
		{
			DebugLogger.LogErrorFormat("{0} will ignore", setfunc);
		}
	}

	public void RemoveEvent<T1>(Func<T1> getfunc, Action<T1, T1> setfunc)
	{
		if (getfunc is Func<T>)
		{
			if (GetNowFunc != null)
			{
				GetNowFunc = (Func<T>)Delegate.Remove(GetNowFunc, getfunc as Func<T>);
			}
		}
		else
		{
			DebugLogger.LogErrorFormat("{0} will ignore", getfunc);
		}
		if (setfunc is Action<T, T>)
		{
			if (InvokeFunc != null)
			{
				InvokeFunc = (Action<T, T>)Delegate.Remove(InvokeFunc, setfunc as Action<T, T>);
			}
		}
		else
		{
			DebugLogger.LogErrorFormat("{0} will ignore", setfunc);
		}
	}

	public bool Equals(NotifyValue<T> other)
	{
		if (this == other)
		{
			return true;
		}
		if (other == null)
		{
			return false;
		}
		if (InvokeFunc != other.InvokeFunc)
		{
			return false;
		}
		if (GetNowFunc != other.GetNowFunc)
		{
			return false;
		}
		return true;
	}

	public bool ContainsEvent<T1>(Func<T1> getfunc)
	{
		if (GetNowFunc != null)
		{
			Delegate[] invocationList = GetNowFunc.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				if (invocationList[i].Equals(getfunc))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool ContainsEvent<T1>(Action<T1, T1> setfunc)
	{
		if (InvokeFunc != null)
		{
			Delegate[] invocationList = InvokeFunc.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				if (invocationList[i].Equals(setfunc))
				{
					return true;
				}
			}
		}
		return false;
	}

	public void Release()
	{
		NotifyManager.PushToPool(this);
	}
}
