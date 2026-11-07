using System;
using CommonUtils;
using SSJJBase.Logger;

namespace NotifyEvent;

internal class NotifyProperyElement<T, TF> : INotifyPropertyElement where T : class
{
	private bool _isnull;

	private TF _current;

	private bool _isClass;

	private ListGetDelegate<T, TF> _getnowfunc;

	private ListSetDelegate<T, TF> _invokefunc;

	private T _last;

	private int _bindIndex;

	public string Name { get; set; }

	public int Bind => _bindIndex;

	public int SubEventId { get; set; }

	public NotifyProperyElement(string propertyname, T firstval, int binder, int idx, ListGetDelegate<T, TF> callback, int subEventId)
	{
		_bindIndex = binder;
		_getnowfunc = callback;
		_isClass = typeof(TF).IsClass;
		if (firstval == null)
		{
			_isnull = true;
			_current = default(TF);
		}
		else
		{
			_current = callback(firstval, idx);
		}
		_last = firstval;
		Name = propertyname;
		SubEventId = subEventId;
	}

	public void AddEvent(ListSetDelegate<T, TF> setfunc)
	{
		if (_invokefunc == null)
		{
			_invokefunc = setfunc;
			return;
		}
		_invokefunc = (ListSetDelegate<T, TF>)Delegate.Remove(_invokefunc, setfunc);
		_invokefunc = (ListSetDelegate<T, TF>)Delegate.Combine(_invokefunc, setfunc);
	}

	private bool GenericValueEqual<M>(M left, M right)
	{
		if (_isClass)
		{
			if (left == null && right != null)
			{
				return false;
			}
			if (left != null && right == null)
			{
				return false;
			}
			if (left == null && right == null)
			{
				return true;
			}
		}
		return left.GetHashCode() == right.GetHashCode();
	}

	public bool Invoke<TU>(TU target, int index, ElementStatus status) where TU : class
	{
		try
		{
			T val = target as T;
			TF val2 = ((val != null) ? _getnowfunc(val, index) : default(TF));
			if (status == ElementStatus.RemoveFromList)
			{
				val = _last;
			}
			if (_isnull || status == ElementStatus.RemoveFromList || !GenericValueEqual(_current, val2))
			{
				if (_invokefunc != null)
				{
					if (_bindIndex >= 0)
					{
						if (_bindIndex == index)
						{
							_invokefunc(val, index, _current, val2, status);
						}
					}
					else
					{
						_invokefunc(val, index, _current, val2, status);
					}
				}
				_isnull = false;
				_current = val2;
				if (status != ElementStatus.RemoveFromList)
				{
					_last = val;
				}
				return true;
			}
		}
		catch (Exception args)
		{
			this.LogErrorFormat("Invoke Error : {0}", args);
		}
		return false;
	}

	public INotifyPropertyElement CloneNew<T1>(T1 target, int idx, int binder = -1) where T1 : class
	{
		NotifyProperyElement<T, TF> notifyProperyElement = new NotifyProperyElement<T, TF>(Name, target as T, binder, idx, _getnowfunc, SubEventId);
		notifyProperyElement.AddEvent(_invokefunc);
		return notifyProperyElement;
	}

	public void ForceInvoke<T1>(T1 target, int index) where T1 : class
	{
		if (!(target is T))
		{
			return;
		}
		try
		{
			T val = target as T;
			TF val2 = _getnowfunc(val, index);
			if (_invokefunc != null)
			{
				_invokefunc(val, index, _current, val2, ElementStatus.InList);
			}
			_current = val2;
		}
		catch (Exception args)
		{
			this.LogErrorFormat("ForceInvoke Error : {0}", args);
		}
	}

	public void ApplyToOther(INotifyPropertyElement other, int binder = -1)
	{
		if (other is NotifyProperyElement<T, TF>)
		{
			NotifyProperyElement<T, TF> obj = other as NotifyProperyElement<T, TF>;
			obj._getnowfunc = _getnowfunc;
			obj._invokefunc = _invokefunc;
			obj._bindIndex = binder;
		}
		else
		{
			DebugLogger.LogErrorFormat("{0} Type Not Match :{1}", other, this);
		}
	}
}
