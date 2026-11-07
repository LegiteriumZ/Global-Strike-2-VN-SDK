using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Sources.Utils.Optimize;

public class CircularBuffer<U>
{
	public struct Enumerator : IEnumerator<U>, IEnumerator, IDisposable
	{
		private CircularBuffer<U> list;

		private int index;

		private U current;

		public U Current => current;

		object IEnumerator.Current
		{
			get
			{
				if (index == 0 || index == list._size + 1)
				{
					throw new ArgumentException();
				}
				return Current;
			}
		}

		internal Enumerator(CircularBuffer<U> list)
		{
			this.list = list;
			index = 0;
			current = default(U);
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			CircularBuffer<U> circularBuffer = list;
			if (index < circularBuffer._size)
			{
				int num = (circularBuffer._start + index) % circularBuffer._buffer.Length;
				current = circularBuffer._buffer[num];
				index++;
				return true;
			}
			return MoveNextRare();
		}

		private bool MoveNextRare()
		{
			index = list._size + 1;
			current = default(U);
			return false;
		}

		void IEnumerator.Reset()
		{
			index = 0;
			current = default(U);
		}
	}

	private readonly U[] _buffer;

	private int _start;

	private int _end;

	private int _size;

	public int Capacity => _buffer.Length;

	public bool IsFull => Size == Capacity;

	public bool IsEmpty => Size == 0;

	public int Size => _size;

	public U this[int index]
	{
		get
		{
			if (IsEmpty)
			{
				throw new IndexOutOfRangeException($"Cannot access index {index}. Buffer is empty");
			}
			if (index >= _size)
			{
				throw new IndexOutOfRangeException($"Cannot access index {index}. Buffer size is {_size}");
			}
			int num = InternalIndex(index);
			return _buffer[num];
		}
		set
		{
			if (IsEmpty)
			{
				throw new IndexOutOfRangeException($"Cannot access index {index}. Buffer is empty");
			}
			if (index >= _size)
			{
				throw new IndexOutOfRangeException($"Cannot access index {index}. Buffer size is {_size}");
			}
			int num = InternalIndex(index);
			_buffer[num] = value;
		}
	}

	public CircularBuffer(int capacity)
		: this(capacity, new U[0])
	{
	}

	public CircularBuffer(int capacity, U[] items)
	{
		if (capacity < 1)
		{
			throw new ArgumentException("Circular buffer cannot have negative or zero capacity.", capacity.ToString());
		}
		if (items == null)
		{
			throw new ArgumentNullException(items.ToString());
		}
		if (items.Length > capacity)
		{
			throw new ArgumentException("Too many items to fit circular buffer", items.ToString());
		}
		_buffer = new U[capacity];
		Array.Copy(items, _buffer, items.Length);
		_size = items.Length;
		_start = 0;
		_end = ((_size != capacity) ? _size : 0);
	}

	public U Front()
	{
		ThrowIfEmpty();
		return _buffer[_start];
	}

	public U Back()
	{
		ThrowIfEmpty();
		return _buffer[((_end != 0) ? _end : Capacity) - 1];
	}

	public void PushBack(U item)
	{
		if (IsFull)
		{
			_buffer[_end] = item;
			Increment(ref _end);
			_start = _end;
		}
		else
		{
			_buffer[_end] = item;
			Increment(ref _end);
			_size++;
		}
	}

	public void PushFront(U item)
	{
		if (IsFull)
		{
			Decrement(ref _start);
			_end = _start;
			_buffer[_start] = item;
		}
		else
		{
			Decrement(ref _start);
			_buffer[_start] = item;
			_size++;
		}
	}

	public void PopBack()
	{
		ThrowIfEmpty("Cannot take elements from an empty buffer.");
		Decrement(ref _end);
		_buffer[_end] = default(U);
		_size--;
	}

	public void PopFront()
	{
		ThrowIfEmpty("Cannot take elements from an empty buffer.");
		_buffer[_start] = default(U);
		Increment(ref _start);
		_size--;
	}

	public U[] ToArray()
	{
		U[] array = new U[Size];
		int num = 0;
		ArraySegment<U>[] array2 = new ArraySegment<U>[2]
		{
			ArrayOne(),
			ArrayTwo()
		};
		for (int i = 0; i < array2.Length; i++)
		{
			ArraySegment<U> arraySegment = array2[i];
			Array.Copy(arraySegment.Array, arraySegment.Offset, array, num, arraySegment.Count);
			num += arraySegment.Count;
		}
		return array;
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	private void ThrowIfEmpty(string message = "Cannot access an empty buffer.")
	{
		if (IsEmpty)
		{
			throw new InvalidOperationException(message);
		}
	}

	private void Increment(ref int index)
	{
		if (++index == Capacity)
		{
			index = 0;
		}
	}

	private void Decrement(ref int index)
	{
		if (index == 0)
		{
			index = Capacity;
		}
		index--;
	}

	private int InternalIndex(int index)
	{
		return _start + ((index < Capacity - _start) ? index : (index - Capacity));
	}

	private ArraySegment<U> ArrayOne()
	{
		if (_start < _end)
		{
			return new ArraySegment<U>(_buffer, _start, _end - _start);
		}
		return new ArraySegment<U>(_buffer, _start, _buffer.Length - _start);
	}

	private ArraySegment<U> ArrayTwo()
	{
		if (_start < _end)
		{
			return new ArraySegment<U>(_buffer, _end, 0);
		}
		return new ArraySegment<U>(_buffer, 0, _end);
	}
}
