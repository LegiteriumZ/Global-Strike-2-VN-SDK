using System;
using System.Collections.Generic;
using System.IO;
using Assets.Sources.Utils.EventLogger;
using SSJJBase.Logger;
using SSJJBase.String;
using SSJJBase.Utility;
using UnityEngine;

namespace Assets.Scripts.Utility.NetWorkRecord;

public class NetWorkRecord
{
	public enum RecordDataType
	{
		None = 0,
		TcpConnectSucc = 1,
		TcpConnectFailed = 2,
		CanReciveSnapshotFirstTime = 4,
		CannotReciveSnapshotFirstTime = 5
	}

	private RecordDataType _hasRecordDataType;

	private int _tcpConnectSign;

	private int _udpConnectSign;

	private bool _hasSetGamingTcpReciveError;

	private Dictionary<RecordDataType, int> _recordCounts;

	private bool _init;

	private string _dirPath;

	private bool _initError;

	public void Init()
	{
		if (_init)
		{
			return;
		}
		_init = true;
		_recordCounts = new Dictionary<RecordDataType, int>();
		_recordCounts.Add(RecordDataType.TcpConnectSucc, 1);
		_recordCounts.Add(RecordDataType.TcpConnectFailed, 4);
		_recordCounts.Add(RecordDataType.CanReciveSnapshotFirstTime, 1);
		_recordCounts.Add(RecordDataType.CannotReciveSnapshotFirstTime, 4);
		try
		{
			_dirPath = PathEx.Combine(Application.persistentDataPath, "NetWork");
			if (!Directory.Exists(_dirPath))
			{
				Directory.CreateDirectory(_dirPath);
			}
			this.Info(_dirPath);
		}
		catch (Exception args)
		{
			this.LogErrorFormat("InitRecordError {0}", args);
			_initError = true;
		}
	}

	private string GetRecord()
	{
		string path = PathEx.Combine(_dirPath, "netWork.txt");
		if (!File.Exists(path))
		{
			return null;
		}
		return File.ReadAllText(path);
	}

	private void SetRecord(string record)
	{
		File.WriteAllText(PathEx.Combine(_dirPath, "netWork.txt"), record);
	}

	public void SetConnectUdp()
	{
		_udpConnectSign = 1;
	}

	public void LoadingSuccess()
	{
		if (_udpConnectSign == 1)
		{
			_udpConnectSign = 2;
		}
	}

	public void SetUdpReceiveSnapshot()
	{
		_udpConnectSign = 3;
	}

	public void SetTryConnectTcp()
	{
		_tcpConnectSign = 1;
	}

	public void SetTcpFirstReciveData()
	{
		_tcpConnectSign = 2;
	}

	public void RecordData(RecordDataType dataType)
	{
		if (!_initError && dataType != 0 && _hasRecordDataType != dataType)
		{
			_hasRecordDataType = dataType;
			if (CheckFromLog(dataType))
			{
				GlobalProperties.Instance.Properties["NetWorkState0"] = (int)_hasRecordDataType;
				EventLogger.Instance.StageLogger("NetWorkState:" + _hasRecordDataType, StartStageEnum.NetWork);
			}
		}
	}

	private bool CheckFromLog(RecordDataType dataType)
	{
		bool result = false;
		try
		{
			string text = GetRecord();
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text.Trim()))
			{
				text = ResetRecord();
			}
			string[] array = text.Split(':');
			if (array.Length != 6)
			{
				_initError = true;
				throw new Exception(string.Concat("SplitLenError, RecordStr > [", text, "]  dataType > ", dataType, "  Now > ", DateTime.Now.Day));
			}
			if (int.Parse(array[0]) != DateTime.Now.Day)
			{
				text = ResetRecord();
				array = text.Split(':');
			}
			int num = int.Parse(array[(int)dataType]);
			num++;
			if (_recordCounts[dataType] == num)
			{
				result = true;
			}
			array[(int)dataType] = StringCache.IntToString(num);
			text = array[0] + ":" + array[1] + ":" + array[2] + ":" + array[3] + ":" + array[4] + ":" + array[5];
			SetRecord(text);
			this.Info("RecordStr >> " + text);
		}
		catch (Exception arg)
		{
			_initError = true;
			string text2 = ResetRecord();
			SetRecord(text2);
			this.LogErrorFormat("GetRecordError {0}  Record{1}", arg, text2);
		}
		return result;
	}

	private string ResetRecord()
	{
		return DateTime.Now.Day + ":0:0:0:0:0";
	}

	public void GameOver()
	{
		if (_tcpConnectSign == 1)
		{
			RecordData(RecordDataType.TcpConnectFailed);
		}
		else if (_tcpConnectSign == 2)
		{
			RecordData(RecordDataType.TcpConnectSucc);
		}
		if (_udpConnectSign == 2)
		{
			RecordData(RecordDataType.CannotReciveSnapshotFirstTime);
		}
		else if (_udpConnectSign == 3)
		{
			RecordData(RecordDataType.CanReciveSnapshotFirstTime);
		}
	}
}
