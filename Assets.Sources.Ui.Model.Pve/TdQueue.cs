using System;
using System.Collections.Generic;

namespace Assets.Sources.Ui.Model.Pve;

public class TdQueue<T> where T : IChanged, IEquatable<T>
{
	public interface ISamePriorityProcess
	{
		bool QueueDataReplace(TdQueue<T> queue, ref T oldData, ref T newData);

		void QueueNewData(TdQueue<T> queue, ref T newData);

		void Leave(TdQueue<T> queue, ref T newData);

		void Pause(TdQueue<T> queue, ref T newData);

		void Refresh(TdQueue<T> queue, ref T newData);
	}

	private List<T> _elements = new List<T>();

	private ISamePriorityProcess _process;

	public int Count => _elements.Count;

	public TdQueue()
	{
	}

	public TdQueue(ISamePriorityProcess sp)
	{
		_process = sp;
	}

	public void TimePassForLater(int frameinterval)
	{
		for (int i = 1; i < _elements.Count; i++)
		{
			T value = _elements[i];
			value.Time -= frameinterval;
			_elements[i] = value;
		}
	}

	public void Enqueue(T item, int priority)
	{
		bool flag = false;
		int num = priority;
		if (_elements.Count > 0)
		{
			num = _elements[0].Priority;
		}
		item.Priority = priority;
		for (int i = 0; i < _elements.Count; i++)
		{
			T newData = _elements[i];
			if (newData.Priority > priority)
			{
				flag = true;
				if (_process != null)
				{
					_process.Pause(this, ref newData);
					_process.QueueNewData(this, ref item);
					_elements.Insert(i, item);
				}
				else if (_process == null)
				{
					_elements.Insert(i, item);
				}
				break;
			}
			if (newData.Priority != priority)
			{
				continue;
			}
			if (_process != null)
			{
				if (newData.Equals(item))
				{
					_process.Refresh(this, ref newData);
				}
				else
				{
					_process.Leave(this, ref newData);
				}
			}
			if (_process != null && _process.QueueDataReplace(this, ref newData, ref item))
			{
				_elements[i] = item;
			}
			else if (_process == null)
			{
				_elements[i] = item;
			}
			flag = true;
			break;
		}
		if (!flag)
		{
			if (_process != null && num == priority)
			{
				_process.QueueNewData(this, ref item);
			}
			_elements.Add(item);
		}
	}

	public T Peek()
	{
		if (_elements.Count > 0)
		{
			return _elements[0];
		}
		return default(T);
	}

	public T Dequeue()
	{
		if (_elements.Count > 0)
		{
			T newData = _elements[0];
			_elements.RemoveAt(0);
			if (_process != null)
			{
				_process.Leave(this, ref newData);
			}
			return newData;
		}
		return default(T);
	}

	public bool ContainsPriority(int val)
	{
		for (int i = 0; i < _elements.Count; i++)
		{
			if (_elements[i].Priority == val)
			{
				return true;
			}
		}
		return false;
	}

	public void Clear()
	{
		for (int i = 0; i < _elements.Count; i++)
		{
			T newData = _elements[i];
			if (_process != null)
			{
				_process.Leave(this, ref newData);
			}
		}
		_elements.Clear();
	}
}
