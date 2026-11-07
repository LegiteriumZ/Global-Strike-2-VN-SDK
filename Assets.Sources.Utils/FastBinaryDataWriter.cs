using System;
using UnityEngine;

namespace Assets.Sources.Utils;

public class FastBinaryDataWriter
{
	private int _buffpos;

	private byte[] _buffer;

	private byte[] _intTmp = new byte[4];

	private byte[] _shortTmp = new byte[2];

	private int _realdatalen;

	public int Position
	{
		get
		{
			return _buffpos;
		}
		set
		{
			_buffpos = value;
		}
	}

	public void WriteByte(byte v)
	{
		if (_buffer == null)
		{
			_buffer = new byte[64];
		}
		else
		{
			AdjustBuffer(1);
		}
		_buffer[_buffpos] = v;
		if (_buffpos >= _realdatalen)
		{
			_realdatalen++;
		}
		_buffpos++;
	}

	public void WriteToBuffer(byte[] buffer, int len)
	{
		for (int i = 0; i < len; i++)
		{
			WriteByte(buffer[i]);
		}
	}

	private void AdjustBuffer(int len)
	{
		int num = _buffer.Length - _buffpos;
		if (num >= len)
		{
			return;
		}
		if (_buffer.Length < 256)
		{
			int num2 = Mathf.Max(_buffer.Length, len - num);
			byte[] array = new byte[_buffer.Length + num2];
			Array.Copy(_buffer, array, _buffer.Length);
			_buffer = array;
			return;
		}
		int i;
		for (i = _buffer.Length / 10; i < len - num; i += _buffer.Length / 10)
		{
		}
		byte[] array2 = new byte[_buffer.Length + i];
		Array.Copy(_buffer, array2, _buffer.Length);
		_buffer = array2;
	}

	public void WriteInt(int v)
	{
		if (BitConverter.IsLittleEndian)
		{
			_intTmp[0] = (byte)((uint)(v >> 24) & 0xFFu);
			_intTmp[1] = (byte)((uint)(v >> 16) & 0xFFu);
			_intTmp[2] = (byte)((uint)(v >> 8) & 0xFFu);
			_intTmp[3] = (byte)((uint)v & 0xFFu);
		}
		else
		{
			_intTmp[3] = (byte)((uint)(v >> 24) & 0xFFu);
			_intTmp[2] = (byte)((uint)(v >> 16) & 0xFFu);
			_intTmp[1] = (byte)((uint)(v >> 8) & 0xFFu);
			_intTmp[0] = (byte)((uint)v & 0xFFu);
		}
		WriteToBuffer(_intTmp, _intTmp.Length);
	}

	public void WriteShort(short v)
	{
		if (BitConverter.IsLittleEndian)
		{
			_shortTmp[0] = (byte)((uint)(v >> 8) & 0xFFu);
			_shortTmp[1] = (byte)((uint)v & 0xFFu);
		}
		else
		{
			_shortTmp[1] = (byte)((uint)(v >> 8) & 0xFFu);
			_shortTmp[0] = (byte)((uint)v & 0xFFu);
		}
		WriteToBuffer(_shortTmp, _shortTmp.Length);
	}

	public void FillBytes(out byte[] bytebuffer, out int length)
	{
		bytebuffer = _buffer;
		length = _realdatalen;
	}

	public byte[] GetBytes()
	{
		byte[] array = new byte[_realdatalen];
		for (int i = 0; i < _realdatalen; i++)
		{
			array[i] = _buffer[i];
		}
		return array;
	}

	public void ReUse()
	{
		_buffpos = 0;
		_realdatalen = 0;
	}

	public void Close()
	{
		_realdatalen = 0;
		_buffer = null;
		_buffpos = 0;
	}
}
