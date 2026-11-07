using System;
using System.Collections.Generic;

namespace Assets.Sources.Utils;

public class PriorityQueue<T, V> where V : IComparable<V>, IEquatable<V>
{
	private List<KeyValuePair<T, V>> elements = new List<KeyValuePair<T, V>>();

	public int Count => elements.Count;

	public void Enqueue(T item, V priority)
	{
		bool flag = false;
		for (int i = 0; i < elements.Count; i++)
		{
			if (elements[i].Value.CompareTo(priority) > 0)
			{
				flag = true;
				elements.Insert(i, new KeyValuePair<T, V>(item, priority));
				break;
			}
		}
		if (!flag)
		{
			elements.Add(new KeyValuePair<T, V>(item, priority));
		}
	}

	public V PeekPriority()
	{
		if (elements.Count > 0)
		{
			return elements[0].Value;
		}
		return default(V);
	}

	public V DequeuePriority()
	{
		if (elements.Count > 0)
		{
			V value = elements[0].Value;
			elements.RemoveAt(0);
			return value;
		}
		return default(V);
	}

	public T Peek()
	{
		if (elements.Count > 0)
		{
			return elements[0].Key;
		}
		return default(T);
	}

	public T Dequeue()
	{
		if (elements.Count > 0)
		{
			T key = elements[0].Key;
			elements.RemoveAt(0);
			return key;
		}
		return default(T);
	}

	public void ClearWithPriority(V val)
	{
		for (int num = elements.Count - 1; num >= 0; num--)
		{
			if (elements[num].Value.Equals(val))
			{
				elements.RemoveAt(num);
			}
		}
	}

	public void Clear()
	{
		elements.Clear();
	}
}
