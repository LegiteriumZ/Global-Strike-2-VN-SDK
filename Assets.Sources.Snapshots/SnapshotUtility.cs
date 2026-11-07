using System;
using System.IO;
using LZ4;
using SSJJBase.Logger;
using SSJJNetworking.Packet;
using zlib;

namespace Assets.Sources.Snapshots;

public static class SnapshotUtility
{
	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(SnapshotUtility));

	private static bool _determined;

	private static bool _useLz4;

	private static string _lz4Magic = "LZ4";

	public const int MAX_INPUT_PACKET_ZIPPED_LEN = 20000;

	public static void SnapShotDeCompress2(PacketBase packetBase, bool isUdp, bool snapshotCompressed, byte[] outputBuffer)
	{
		packetBase.DeCompressBodyData = null;
		_ = packetBase.BodyData;
		if (isUdp)
		{
			packetBase.DeCompressBodyData = packetBase.BodyData;
			packetBase.SetDefaultLength(packetBase.BodyDataLen);
		}
		else if (packetBase.Id != 2)
		{
			packetBase.DeCompressBodyData = packetBase.BodyData;
			packetBase.SetDefaultLength();
		}
	}

	public static void SnapShotDeCompress(PacketBase packetBase, bool isUdp, bool snapshotCompressed, byte[] outputBuffer)
	{
		packetBase.DeCompressBodyData = null;
		byte[] bodyData = packetBase.BodyData;
		int num = 0;
		if (isUdp)
		{
			num = 5;
			if (packetBase.Id != 1)
			{
				packetBase.DeCompressBodyData = packetBase.BodyData;
				packetBase.SetDefaultLength(packetBase.BodyDataLen);
				return;
			}
		}
		else if (packetBase.Id != 2)
		{
			packetBase.DeCompressBodyData = packetBase.BodyData;
			packetBase.SetDefaultLength();
			return;
		}
		if (bodyData == null || bodyData.Length < 4 + num)
		{
			return;
		}
		snapshotCompressed = true;
		if (!snapshotCompressed)
		{
			if (num > 0)
			{
				byte[] array = new byte[bodyData.Length - num];
				Array.Copy(bodyData, num, array, 0, bodyData.Length - num);
				packetBase.DeCompressBodyData = array;
				packetBase.SetDefaultLength();
			}
			else
			{
				packetBase.DeCompressBodyData = bodyData;
				packetBase.SetDefaultLength();
			}
			return;
		}
		int num2 = bodyData[num];
		int num3 = bodyData[1 + num];
		int num4 = bodyData[2 + num];
		try
		{
			if (!_determined)
			{
				_determined = true;
				_useLz4 = num2 == _lz4Magic[0] && num3 == _lz4Magic[1] && num4 == _lz4Magic[2];
			}
			if (_useLz4)
			{
				if (bodyData.Length > 3 + num && bodyData.Length < 20000)
				{
					int inputLength = packetBase.BodyDataLen - 3 - num;
					int num5 = LZ4Codec.Decode(bodyData, num + 3, inputLength, outputBuffer, 0, 100000);
					bodyData = NetByteFactory.Instance.GetOrCreateForSnapshotReceive(num5);
					Array.Copy(outputBuffer, 0, bodyData, 0, num5);
					packetBase.DeCompressBodyData = bodyData;
					packetBase.SetDefaultLength(num5);
				}
			}
			else
			{
				Stream stream = ZlibDeCompressStream(bodyData, num);
				int num6 = (int)stream.Length;
				byte[] orCreateForSnapshotReceive = NetByteFactory.Instance.GetOrCreateForSnapshotReceive(num6);
				stream.Position = 0L;
				stream.Read(orCreateForSnapshotReceive, 0, num6);
				stream.Close();
				packetBase.DeCompressBodyData = orCreateForSnapshotReceive;
				packetBase.SetDefaultLength(num6);
			}
		}
		catch (Exception arg)
		{
			_determined = false;
			Logger.ErrorFormat("SnapShot DeCompress Error  >>> _useLz4:{0} msg:{1}", _useLz4, arg);
		}
	}

	private static Stream ZlibDeCompressStream(byte[] bytes, int offset)
	{
		MemoryStream memoryStream = new MemoryStream();
		ZOutputStream zOutputStream = new ZOutputStream(memoryStream);
		zOutputStream.Write(bytes, offset, bytes.Length - offset);
		zOutputStream.Flush();
		zOutputStream.finish();
		return memoryStream;
	}
}
