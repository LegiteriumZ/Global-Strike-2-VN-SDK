using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Sources.Snapshots;
using NetData;
using SSJJBase.Utility;
using SSJJSceneLoader;
using UnityEngine;
using zlib;

namespace Assets.Sources.Ui.ForUiTest;

public class ServerRecordParser
{
	public static int snapSelf = 0;

	private static UdpSnapshotParser parser = new UdpSnapshotParser();

	public static GameRecordData parse(string recordPath)
	{
		Contexts.sharedInstance.snapshot.snapshots.BaseSnapshotList.Clear();
		byte[] array = File.ReadAllBytes(recordPath);
		new MemoryStream(array);
		DefaultByteArray defaultByteArray = new DefaultByteArray(array);
		defaultByteArray.readUTFBytes(7);
		int num = readInt(defaultByteArray);
		int num2 = readInt(defaultByteArray);
		int num3 = readInt(defaultByteArray);
		int num4 = readInt(defaultByteArray);
		long ticks = DateTime.Now.Ticks;
		int num5 = Mathf.FloorToInt(1650000f);
		GameRecordData gameRecordData = new GameRecordData();
		gameRecordData.Version = num + "_" + num2 + "_" + num3 + "_" + num4;
		FrameRecordData frameRecordData = new FrameRecordData();
		frameRecordData.Time = ticks;
		gameRecordData.FrameRecordList.Add(frameRecordData);
		RoomData roomData = new RoomData();
		roomData.SceneId = num2;
		roomData.RaceType = num3;
		roomData.WinScore = num4;
		roomData.UdpOptimize = true;
		addNetData(frameRecordData, 12, roomData);
		OnGameinitData onGameinitData = new OnGameinitData();
		onGameinitData.EngineID = 4;
		onGameinitData.SceneId = num2;
		onGameinitData.IsObserver = true;
		addNetData(frameRecordData, 3, onGameinitData);
		ticks += num5;
		frameRecordData = new FrameRecordData();
		frameRecordData.Time = ticks;
		gameRecordData.FrameRecordList.Add(frameRecordData);
		CallBackLoginData callBackLoginData = new CallBackLoginData();
		callBackLoginData.Res = true;
		addNetData(frameRecordData, 1, callBackLoginData);
		ticks += num5;
		new Dictionary<int, SnapshotData>();
		bool flag = false;
		int num6 = 0;
		snapSelf = 0;
		long num7 = 0L;
		while (defaultByteArray.remain > 0)
		{
			NetRecordData netRecordData = new NetRecordData();
			int num8 = readInt(defaultByteArray);
			int length = readInt(defaultByteArray);
			netRecordData.Tcp = num8 == 1;
			netRecordData.Data = readBytes(defaultByteArray, length, netRecordData.Tcp);
			if (!netRecordData.Tcp && flag)
			{
				frameRecordData = new FrameRecordData();
				frameRecordData.Time = ticks;
				gameRecordData.FrameRecordList.Add(frameRecordData);
			}
			flag = !netRecordData.Tcp;
			frameRecordData = new FrameRecordData();
			frameRecordData.Time = ticks;
			frameRecordData.NetRecordList.Add(netRecordData);
			gameRecordData.FrameRecordList.Add(frameRecordData);
			if (flag)
			{
				if (num7 > 0)
				{
					long num9 = getLatestServerTime() - num7;
					ticks = (frameRecordData.Time = ticks + num9 * 10000);
				}
				num6++;
				if (num6 == 1)
				{
					frameRecordData = new FrameRecordData();
					frameRecordData.Time = ticks;
					gameRecordData.FrameRecordList.Add(frameRecordData);
					addP2pPData(frameRecordData);
					frameRecordData = new FrameRecordData();
					frameRecordData.Time = -1L;
					gameRecordData.FrameRecordList.Add(frameRecordData);
				}
				num7 = getLatestServerTime();
			}
		}
		Contexts.sharedInstance.snapshot.snapshots.BaseSnapshotList.Clear();
		return gameRecordData;
	}

	private static long getLatestServerTime()
	{
		int count = Contexts.sharedInstance.snapshot.snapshots.BaseSnapshotList.Count;
		if (count > 0)
		{
			return Contexts.sharedInstance.snapshot.snapshots.BaseSnapshotList[count - 1].ServerTime;
		}
		return 0L;
	}

	private static void AddMiddleFrameData(List<FrameRecordData> list, ref long startTime)
	{
		int num = Mathf.FloorToInt(Mathf.FloorToInt(1650000f) / 10 / 3);
		startTime += num;
		for (int i = 0; i < 3; i++)
		{
			FrameRecordData frameRecordData = new FrameRecordData();
			frameRecordData.Time = startTime;
			list.Add(frameRecordData);
			startTime += num;
		}
	}

	private static byte[] ZLibCompress(byte[] bytes)
	{
		MemoryStream memoryStream = new MemoryStream();
		ZOutputStream zOutputStream = new ZOutputStream(memoryStream, 2);
		zOutputStream.Write(bytes, 0, bytes.Length);
		zOutputStream.Close();
		return memoryStream.ToArray();
	}

	private static void addNetData(FrameRecordData frameData, int funcId, object message)
	{
		NetRecordData netRecordData = new NetRecordData();
		netRecordData.Tcp = true;
		netRecordData.Data = getMessageByteData(funcId, message);
		frameData.NetRecordList.Add(netRecordData);
	}

	private static void addP2pPData(FrameRecordData frameData)
	{
		NetRecordData netRecordData = new NetRecordData();
		netRecordData.Tcp = false;
		netRecordData.Data = new byte[5];
		frameData.NetRecordList.Add(netRecordData);
	}

	public static byte[] getMessageByteData(int methodid, object message)
	{
		APC obj = new APC
		{
			Id = methodid
		};
		byte[] content = null;
		if (message != null)
		{
			content = ProtoBufUtility.Serialize(message);
		}
		obj.Content = content;
		byte[] array = ProtoBufUtility.Serialize(obj);
		int num = 4;
		byte[] array2 = new byte[array.Length + num];
		byte[] bytes = BitConverter.GetBytes(array.Length);
		ReverseArray(bytes);
		Array.Copy(bytes, 0, array2, 0, num);
		Array.Copy(array, 0, array2, num, array.Length);
		return array2;
	}

	public static byte[] readBytes(DefaultByteArray reader, int length, bool isTcp)
	{
		int num = 4;
		int num2 = num;
		if (!isTcp)
		{
			num2++;
		}
		byte[] array = new byte[length + num2];
		byte[] bytes = BitConverter.GetBytes(length);
		ReverseArray(bytes);
		Array.Copy(bytes, 0, array, 0, num);
		if (!isTcp)
		{
			array[4] = 1;
		}
		if (!isTcp)
		{
			byte[] array2 = new byte[length];
			Array.Copy(reader.getBytes(), reader.position, array2, 0, length);
			if (snapSelf == 0)
			{
				Snapshot snapshot = parser.Parse(array2, length);
				if (snapshot != null && snapshot.Self == 0)
				{
					snapSelf = snapshot.PlayerEntityDataDict.ElementAt(0).Value.Id;
				}
			}
			Array.Copy(array2, 0, array, num2, array2.Length);
		}
		else
		{
			Array.Copy(reader.getBytes(), reader.position, array, num2, length);
		}
		reader.position += length;
		return array;
	}

	public static byte[] updateUdpObserverPlayerId(byte[] srcData, int PlayerId)
	{
		int num = 4 + 1;
		if (srcData.Length <= num)
		{
			return srcData;
		}
		int length = srcData.Length - num;
		byte[] array = new byte[srcData.Length - num];
		Array.Copy(srcData, num, array, 0, length);
		array = updateObserverId(array, PlayerId);
		byte[] array2 = new byte[num + array.Length];
		Array.Copy(srcData, 0, array2, 0, num);
		Array.Copy(array, 0, array2, num, array.Length);
		return array2;
	}

	private static byte[] updateObserverId(byte[] data, int id)
	{
		if (data == null || data.Length == 0)
		{
			return data;
		}
		MemoryStream memoryStream = new MemoryStream(data);
		memoryStream.Position = 0L;
		byte[] array = new byte[2];
		memoryStream.Read(array, 0, 2);
		if (BitConverter.IsLittleEndian)
		{
			BinaryDataWriter.ReverseArray(array, 0, array.Length - 1);
		}
		ushort num = BitConverter.ToUInt16(array, 0);
		int num2 = num;
		long position = memoryStream.Position;
		NetTableBase.readVarint64(memoryStream);
		NetTableBase.readVarint64(memoryStream);
		NetTableBase.readVarint64(memoryStream);
		NetTableBase.readVarint64(memoryStream);
		NetTableBase.readVarint64(memoryStream);
		ushort num3 = (ushort)(memoryStream.Position - position);
		num -= num3;
		long position2 = memoryStream.Position;
		byte[] array2 = new byte[num];
		memoryStream.Read(array2, 0, num);
		SnapshotData snapshotData = ProtoBufUtility.Deserialize<SnapshotData>(array2);
		snapshotData.Observer = id;
		byte[] array3 = ProtoBufUtility.Serialize(snapshotData);
		if (array3.Length != num)
		{
			num2 += array3.Length - num;
			byte[] bytes = BitConverter.GetBytes((ushort)num2);
			ReverseArray(bytes);
			Array.Copy(bytes, 0, data, 0, 2);
		}
		byte[] array4 = new byte[data.Length + array3.Length - num];
		Array.Copy(data, 0L, array4, 0L, position2);
		Array.Copy(array3, 0L, array4, position2, array3.Length);
		Array.Copy(data, position2 + num, array4, position2 + array3.Length, data.Length - position2 - num);
		return array4;
	}

	private static byte[] updateSnapSelf(byte[] data, int selfId)
	{
		MemoryStream memoryStream = new MemoryStream(data)
		{
			Position = 2L
		};
		NetTableBase.readVarint64(memoryStream);
		NetTableBase.readVarint64(memoryStream);
		int num = (int)memoryStream.Position;
		NetTableBase.readVarint64(memoryStream);
		int num2 = (int)memoryStream.Position;
		byte[] array = WriteVarint32(selfId);
		int num3 = array.Length - (num2 - num);
		if (num3 != 0 || array.Length > 1)
		{
			byte[] array2 = new byte[data.Length + num3];
			Array.Copy(data, 0, array2, 0, num);
			memoryStream.Position = 0L;
			byte[] array3 = new byte[2];
			memoryStream.Read(array3, 0, 2);
			if (BitConverter.IsLittleEndian)
			{
				BinaryDataWriter.ReverseArray(array3, 0, array3.Length - 1);
			}
			byte[] bytes = BitConverter.GetBytes((ushort)(BitConverter.ToUInt16(array3, 0) + (ushort)num3));
			ReverseArray(bytes);
			Array.Copy(bytes, 0, array2, 0, 2);
			Array.Copy(array, 0, array2, num, array.Length);
			Array.Copy(data, num2, array2, num + array.Length, data.Length - num2);
			return array2;
		}
		data[num] = (byte)selfId;
		return data;
	}

	public static byte[] WriteVarint32(int num)
	{
		int num2 = 28;
		while (num2 > 0 && ((num >> num2) & 0x7F) <= 0)
		{
			num2 -= 7;
		}
		num2 += 7;
		List<byte> list = new List<byte>();
		for (int i = 0; i < num2; i += 7)
		{
			int num3 = (num >> i) & 0x7F;
			if (num2 - i > 7)
			{
				num3 = 0x80 | num3;
			}
			list.Add((byte)num3);
		}
		return list.ToArray();
	}

	public static void ReverseArray(byte[] arr)
	{
		int num = arr.Length / 2;
		for (int i = 0; i < num; i++)
		{
			byte b = arr[i];
			byte b2 = arr[arr.Length - 1 - i];
			arr[i] = b2;
			arr[arr.Length - 1 - i] = b;
		}
	}

	public static int readInt(DefaultByteArray reader)
	{
		return (reader.readByte() << 24) | (reader.readByte() << 16) | (reader.readByte() << 8) | reader.readByte();
	}
}
