using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Utils.Optimize;

namespace Assets.Sources.Framework;

public class PredicationInitComponentHistory<T> where T : IPredicationInitComponent<T>, new()
{
	private struct Item : IEquatable<Item>
	{
		public int CmdSeq;

		public T Component;

		public Item(int cmdSeq, T component)
		{
			CmdSeq = cmdSeq;
			Component = component;
		}

		public bool Equals(Item other)
		{
			if (CmdSeq != other.CmdSeq)
			{
				return false;
			}
			if (!Component.Equals(other.Component))
			{
				return false;
			}
			return true;
		}
	}

	private const int predicationCnt = 100;

	private CircularBuffer<Item> _history = new CircularBuffer<Item>(101);

	public string LastErrorMsg;

	public void Save(int cmdSeq, T comp)
	{
		Item item;
		if (_history.Capacity == _history.Size)
		{
			item = _history.Back();
			_history.PopBack();
			item.CmdSeq = cmdSeq;
		}
		else
		{
			item = new Item(cmdSeq, new T());
		}
		comp.ClonePredicationState(item.Component);
		_history.PushFront(item);
	}

	public T GetHistory(int cmdSeq)
	{
		foreach (Item item in _history)
		{
			if (item.CmdSeq == cmdSeq)
			{
				return item.Component;
			}
		}
		return default(T);
	}

	public bool IsApproximatelyEqual(int cmdSeq, T comp)
	{
		foreach (Item item in _history)
		{
			if (item.CmdSeq == cmdSeq)
			{
				return comp.IsApproximatelyEqual(item.Component);
			}
		}
		return false;
	}
}
