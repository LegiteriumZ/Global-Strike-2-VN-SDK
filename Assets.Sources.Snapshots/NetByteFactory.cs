using System.Collections.Generic;
using SSJJBase.Logger;

namespace Assets.Sources.Snapshots;

public class NetByteFactory
{
	private readonly LoggerAdapter _logger = new LoggerAdapter(typeof(NetByteFactory));

	public static NetByteFactory Instance = new NetByteFactory();

	private readonly Dictionary<byte[], bool> _byteDicPoolForSnapshot = new Dictionary<byte[], bool>();

	private readonly Dictionary<byte[], bool> _byteDicPoolForNormal = new Dictionary<byte[], bool>();

	private readonly object _byteLockObject = new object();

	private bool _isInit;

	public void InitBytes()
	{
		if (!_isInit)
		{
			_isInit = true;
			for (int i = 0; i < 8; i++)
			{
				GetOrCreateForSnapshotReceive(5000, log: false);
			}
			for (int j = 1; j < 100; j++)
			{
				GetOrCreateNormalByte(j, log: false);
			}
			Collect();
		}
	}

	public override string ToString()
	{
		return "_byteDicPoolForSnapshot > " + _byteDicPoolForSnapshot.Count + "  _byteDicPoolForNormal > " + _byteDicPoolForNormal.Count;
	}

	public byte[] GetOrCreateNormalByte(int length, bool log = true)
	{
		byte[] array = null;
		foreach (KeyValuePair<byte[], bool> item in _byteDicPoolForNormal)
		{
			if (!item.Value && item.Key != null && item.Key.Length == length)
			{
				array = item.Key;
				break;
			}
		}
		if (array == null)
		{
			array = new byte[length];
			_byteDicPoolForNormal.Add(array, value: true);
			if (log)
			{
				_logger.Info("Create New Normal Byte " + length);
			}
		}
		else
		{
			_byteDicPoolForNormal[array] = true;
		}
		return array;
	}

	public byte[] GetOrCreateForSnapshotReceive(int length, bool log = true)
	{
		lock (_byteLockObject)
		{
			byte[] array = null;
			foreach (KeyValuePair<byte[], bool> item in _byteDicPoolForSnapshot)
			{
				if (!item.Value && item.Key != null && item.Key.Length >= length)
				{
					array = item.Key;
					break;
				}
			}
			if (array == null)
			{
				array = new byte[length * 2];
				_byteDicPoolForSnapshot.Add(array, value: true);
			}
			else
			{
				_byteDicPoolForSnapshot[array] = true;
			}
			return array;
		}
	}

	public void AddNormal(byte[] bytes)
	{
		if (bytes != null && _byteDicPoolForNormal.ContainsKey(bytes))
		{
			_byteDicPoolForNormal[bytes] = false;
		}
	}

	public void AddSnapshotReceive(byte[] bytes)
	{
		lock (_byteLockObject)
		{
			if (bytes != null && _byteDicPoolForSnapshot.ContainsKey(bytes))
			{
				_byteDicPoolForSnapshot[bytes] = false;
			}
		}
	}

	public void AddSnapshotReceive(byte[] bytes1, byte[] bytes2)
	{
		lock (_byteLockObject)
		{
			if (bytes1 != null && _byteDicPoolForSnapshot.ContainsKey(bytes1))
			{
				_byteDicPoolForSnapshot[bytes1] = false;
			}
			if (bytes2 != null && _byteDicPoolForSnapshot.ContainsKey(bytes2))
			{
				_byteDicPoolForSnapshot[bytes2] = false;
			}
		}
	}

	public void Collect()
	{
		lock (_byteLockObject)
		{
			foreach (byte[] item in new List<byte[]>(_byteDicPoolForSnapshot.Keys))
			{
				_byteDicPoolForSnapshot[item] = false;
			}
		}
		foreach (byte[] item2 in new List<byte[]>(_byteDicPoolForNormal.Keys))
		{
			_byteDicPoolForNormal[item2] = false;
		}
	}
}
