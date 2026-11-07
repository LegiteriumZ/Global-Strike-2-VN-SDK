using System;
using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Input;
using Assets.Sources.Snapshots;
using Assets.Sources.Systems.PacketHandle;
using Assets.Sources.Systems.PacketHandle.Handlers;
using Assets.Sources.Systems.Snapshot;
using Assets.Sources.Systems.UserCommand;
using Assets.Sources.Ui.ForUiTest.Record;
using Assets.Sources.Utils;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Utility;
using SSJJNetworking.BattleServer;
using SSJJNetworking.Packet;
using Sharpen;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ForUiTest;

public static class NetRecordManager
{
	public static bool Open;

	public static bool FinishedQuit;

	public static bool isServerRecord = false;

	private static GameRecordData _records = new GameRecordData();

	public static List<FrameRecordData> PlayRecordList = new List<FrameRecordData>();

	private static int serverObserverPlayerId = 0;

	private static object _lock = new object();

	private static GameRecordData _playRecords = new GameRecordData();

	private static long _startTime;

	public static float[] SpeedScaleArray = new float[5] { 1f, 1.2f, 1.4f, 0.8f, 0.6f };

	public static int SpeedScaleIndex;

	public const int MAX_INPUT_PACKET_ZIPPED_LEN = 20000;

	private static byte[] OutputBuffer = null;

	public static Dictionary<int, string[]> TestCases = new Dictionary<int, string[]>();

	public static Dictionary<int, GameObjectData> Answers = new Dictionary<int, GameObjectData>();

	public static FrameRecordData CurrentRecord { get; private set; }

	public static bool AutoTest { get; private set; }

	public static bool AutoInput { get; set; }

	public static bool TimeSync { get; set; }

	public static bool Playing { get; private set; }

	public static bool Pause { get; set; }

	public static int Index { get; private set; }

	public static int TotalFrame { get; private set; }

	public static int Step { get; set; }

	public static float SpeedScale { get; set; }

	public static string RecordName { get; private set; }

	public static void Add()
	{
		lock (_lock)
		{
			if (_records.FrameRecordList.Count > 0)
			{
				CurrentRecord = new FrameRecordData
				{
					Time = DateTime.Now.Ticks
				};
				_records.FrameRecordList.Add(CurrentRecord);
			}
		}
	}

	public static void Add(byte[] data, int len, bool tcp)
	{
		lock (_lock)
		{
			if (_records.FrameRecordList.Count == 0)
			{
				CurrentRecord = new FrameRecordData
				{
					Time = DateTime.Now.Ticks
				};
				_records.FrameRecordList.Add(CurrentRecord);
			}
			byte[] array = new byte[data.Length];
			Array.Copy(data, array, array.Length);
			CurrentRecord.NetRecordList.Add(new NetRecordData
			{
				Tcp = tcp,
				Data = data
			});
		}
	}

	public static void Add(float axisX, float axisY, Dictionary<int, bool> keys, Dictionary<int, bool> keyDowns, bool leftMouse, bool rightMouse, bool middleMouse, float scrollWheel, float deltaTime, float diff)
	{
		lock (_lock)
		{
			if (_records.FrameRecordList.Count <= 0)
			{
				return;
			}
			CurrentRecord.InputRecord = new InputRecordData
			{
				AxisX = axisX,
				AxisY = axisY,
				LeftMouse = leftMouse,
				RightMouse = rightMouse,
				MiddleMouse = middleMouse,
				ScrollWheel = scrollWheel,
				DeltaTime = deltaTime,
				Diff = diff
			};
			foreach (KeyValuePair<int, bool> key in keys)
			{
				if (key.Value)
				{
					CurrentRecord.InputRecord.Keys.Add(key.Key);
				}
			}
			foreach (KeyValuePair<int, bool> keyDown in keyDowns)
			{
				if (keyDown.Value)
				{
					CurrentRecord.InputRecord.KeyDowns.Add(keyDown.Key);
				}
			}
		}
	}

	public static void Add(Dictionary<int, bool> keyDowns)
	{
		lock (_lock)
		{
			if (_records.FrameRecordList.Count <= 0)
			{
				return;
			}
			CurrentRecord.KeyBoardRecord = new KeyBoardRecordData();
			foreach (KeyValuePair<int, bool> keyDown in keyDowns)
			{
				if (keyDown.Value)
				{
					CurrentRecord.KeyBoardRecord.KeyDowns.Add(keyDown.Key);
				}
			}
		}
	}

	public static void Add(string leftDown, string leftUp, string rightDown, string rightUp, string middleDown, string middleUp, Vector3 mousePos)
	{
		lock (_lock)
		{
			if (_records.FrameRecordList.Count > 0)
			{
				CurrentRecord.MouseRecord = new MouseRecordData();
				CurrentRecord.MouseRecord.LeftDown = leftDown;
				CurrentRecord.MouseRecord.LeftUp = leftUp;
				CurrentRecord.MouseRecord.RightDown = rightDown;
				CurrentRecord.MouseRecord.RightUp = rightUp;
				CurrentRecord.MouseRecord.MiddleDown = middleDown;
				CurrentRecord.MouseRecord.RightUp = rightUp;
				CurrentRecord.MouseRecord.X = mousePos.x;
				CurrentRecord.MouseRecord.Y = mousePos.y;
			}
		}
	}

	public static void Save()
	{
		_records.Version = string.Format("Time:{0}, Branch:{1}, commit:{2}", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"), "origin/abroad_2024_12_17_viet", "55ae00b0013fa47583635b28f2798119277896d8");
		if (!Directory.Exists("Records"))
		{
			Directory.CreateDirectory("Records");
		}
		for (int i = 0; i < _records.FrameRecordList.Count; i++)
		{
			FrameRecordData frameRecordData = _records.FrameRecordList[i];
			for (int num = frameRecordData.NetRecordList.Count - 1; num >= 0; num--)
			{
				if (frameRecordData.NetRecordList[num] == null)
				{
					frameRecordData.NetRecordList.RemoveAt(num);
				}
			}
		}
		File.WriteAllBytes("Records/Record" + DateTime.Now.ToString("_yyyy_MM_dd HH_mm_ss") + ".txt", ProtoBufUtility.Serialize(_records));
		Application.OpenURL(Path.GetFullPath("Records"));
	}

	public static void Start(bool autoInput, bool finishQuit, bool timeSync)
	{
		SpeedScale = 1f;
		SpeedScaleIndex = 0;
		Index = 0;
		_startTime = DateTime.Now.Ticks;
		AutoTest = true;
		AutoInput = autoInput;
		TimeSync = timeSync;
		Playing = true;
		FinishedQuit = finishQuit;
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 150;
	}

	public static bool Update()
	{
		Playing = false;
		if (Index >= _playRecords.FrameRecordList.Count)
		{
			return true;
		}
		Playing = true;
		CurrentRecord = _playRecords.FrameRecordList[Index];
		FrameRecordData frameRecordData = _playRecords.FrameRecordList[(Index > 0) ? (Index - 1) : 0];
		PlayRecordList.Clear();
		if (TimeSync)
		{
			if (Mathf.Approximately(SpeedScale, 1f))
			{
				if (CurrentRecord.Time < 0 || frameRecordData.Time < 0)
				{
					if (Contexts.sharedInstance.battleRoom.gameState.LoadingFinish)
					{
						_startTime = DateTime.Now.Ticks;
						Index++;
						PlayRecordList.Add(CurrentRecord);
						return true;
					}
				}
				else if ((float)(DateTime.Now.Ticks - _startTime) >= (float)(CurrentRecord.Time - frameRecordData.Time) / SpeedScale)
				{
					_startTime = DateTime.Now.Ticks;
					Index++;
					PlayRecordList.Add(CurrentRecord);
					return true;
				}
				return false;
			}
			long num = DateTime.Now.Ticks - _startTime;
			while (num > 0)
			{
				num -= (long)((float)(CurrentRecord.Time - frameRecordData.Time) / SpeedScale);
				if (num >= 0)
				{
					Index++;
					if (Index < _playRecords.FrameRecordList.Count)
					{
						CurrentRecord = _playRecords.FrameRecordList[Index];
						frameRecordData = _playRecords.FrameRecordList[Index - 1];
						PlayRecordList.Add(CurrentRecord);
					}
					_startTime = DateTime.Now.Ticks;
				}
			}
			return true;
		}
		while (IsFrameEmpty(CurrentRecord) && Index < _playRecords.FrameRecordList.Count - 1)
		{
			Index++;
			CurrentRecord = _playRecords.FrameRecordList[Index];
			PlayRecordList.Add(CurrentRecord);
		}
		_startTime = DateTime.Now.Ticks;
		Index++;
		return true;
	}

	private static bool IsFrameEmpty(FrameRecordData frameData)
	{
		if (frameData.NetRecordList.Count > 0)
		{
			return false;
		}
		if (frameData.InputRecord != null)
		{
			if (frameData.InputRecord.AxisX == 0f && frameData.InputRecord.AxisY == 0f && !frameData.InputRecord.LeftMouse && !frameData.InputRecord.RightMouse && !frameData.InputRecord.MiddleMouse && frameData.InputRecord.ScrollWheel == 0f)
			{
				return true;
			}
			return false;
		}
		if (frameData.KeyBoardRecord != null)
		{
			return false;
		}
		if (frameData.MouseRecord != null)
		{
			return false;
		}
		return true;
	}

	public static void Update(IBattleServer battleServer, PacketQueue tcpQueue, PacketQueue udpQueue)
	{
		for (int i = 0; i < PlayRecordList.Count; i++)
		{
			FrameRecordData frameRecordData = PlayRecordList[i];
			for (int j = 0; j < frameRecordData.NetRecordList.Count; j++)
			{
				NetRecordData netRecordData = frameRecordData.NetRecordList[j];
				if (netRecordData.Tcp)
				{
					TcpPacket tcpPacket = TcpPacket.FromFinalData(netRecordData.Data);
					SnapshotUtility.SnapShotDeCompress(tcpPacket, isUdp: false, battleServer.UdpSnapshotCompressed, OutputBuffer);
					tcpQueue.AddPacket(tcpPacket);
					continue;
				}
				if (isServerRecord)
				{
					netRecordData.Data = ServerRecordParser.updateUdpObserverPlayerId(netRecordData.Data, serverObserverPlayerId);
				}
				UdpPacket udpPacket = UdpPacket.ParseUdpPacket(netRecordData.Data, netRecordData.Data.Length);
				if (isServerRecord)
				{
					SnapshotUtility.SnapShotDeCompress2(udpPacket, isUdp: true, battleServer.UdpSnapshotCompressed, OutputBuffer);
				}
				else
				{
					SnapshotUtility.SnapShotDeCompress(udpPacket, isUdp: true, battleServer.UdpSnapshotCompressed, OutputBuffer);
				}
				udpQueue.AddPacket(udpPacket);
			}
			tcpQueue.HandlePackets();
			udpQueue.HandlePackets();
		}
	}

	public static void Update(ref float axisX, ref float axisY, Dictionary<int, bool> keys, Dictionary<int, bool> keyDowns, ref bool leftMouse, ref bool rightMouse, ref bool middleMouse, ref float scrollWheel, ref float deltaTime, ref float diff)
	{
		if (CurrentRecord.InputRecord == null)
		{
			return;
		}
		InputRecordData inputRecord = CurrentRecord.InputRecord;
		axisX = inputRecord.AxisX;
		axisY = inputRecord.AxisY;
		foreach (int key in inputRecord.Keys)
		{
			keys[key] = true;
		}
		foreach (int keyDown in inputRecord.KeyDowns)
		{
			keyDowns[keyDown] = true;
		}
		leftMouse = inputRecord.LeftMouse;
		rightMouse = inputRecord.RightMouse;
		middleMouse = inputRecord.MiddleMouse;
		scrollWheel = inputRecord.ScrollWheel;
		deltaTime = inputRecord.DeltaTime;
		diff = inputRecord.Diff;
	}

	public static void Update(ref Dictionary<int, bool> keyDowns)
	{
		if (CurrentRecord.KeyBoardRecord == null)
		{
			return;
		}
		foreach (int keyDown in CurrentRecord.KeyBoardRecord.KeyDowns)
		{
			keyDowns[keyDown] = true;
		}
	}

	public static Vector2 Update(ref string leftDown, ref string leftUp, ref string rightDown, ref string rightUp, ref string middleDown, ref string middleUp)
	{
		if (CurrentRecord.MouseRecord != null)
		{
			MouseRecordData mouseRecord = CurrentRecord.MouseRecord;
			leftDown = mouseRecord.LeftDown;
			leftUp = mouseRecord.LeftUp;
			rightDown = mouseRecord.RightDown;
			rightUp = mouseRecord.RightUp;
			middleDown = mouseRecord.MiddleDown;
			middleUp = mouseRecord.MiddleUp;
			return new Vector2(mouseRecord.X, mouseRecord.Y);
		}
		return Vector2.zero;
	}

	public static void Read(GameRecordData data)
	{
		RecordName = "";
		isServerRecord = true;
		_playRecords = data;
		TotalFrame = _playRecords.FrameRecordList.Count;
		Debug.Log("Load Record > " + _playRecords.Version);
		TestCases.Clear();
		Answers.Clear();
	}

	public static void Read(string recordName)
	{
		isServerRecord = false;
		string text = $"Records/Record_{recordName}.txt";
		if (!File.Exists(text))
		{
			return;
		}
		RecordName = recordName;
		_playRecords = ProtoBufUtility.Deserialize<GameRecordData>(File.ReadAllBytes(text));
		TotalFrame = _playRecords.FrameRecordList.Count;
		Debug.Log("Load Record > " + _playRecords.Version);
		TestCases.Clear();
		Answers.Clear();
		string path = text.Replace("/Record_", "/Test_").Replace(".txt", "");
		if (!Directory.Exists(path))
		{
			return;
		}
		string[] files = Directory.GetFiles(path, "*_Test*.txt");
		for (int i = 0; i < files.Length; i++)
		{
			string path2 = files[i].Split("_Test")[0] + ".txt";
			if (File.Exists(path2))
			{
				int key = int.Parse(Path.GetFileNameWithoutExtension(path2));
				Answers[key] = ProtoBufUtility.Deserialize<GameObjectData>(File.ReadAllBytes(path2));
				TestCases[key] = File.ReadAllLines(files[i]);
			}
		}
	}

	public static void SaveTestCase()
	{
		GameObjectData gameObjectData = new GameObjectData();
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		foreach (GameObject gameObject in rootGameObjects)
		{
			if (gameObject.GetComponent<Canvas>() != null)
			{
				AddGameObjectData(gameObjectData, gameObject);
			}
			if (!(gameObject.name == "CommonResource"))
			{
				continue;
			}
			GameObjectData gameObjectData2 = new GameObjectData();
			gameObjectData2.Name = gameObject.name;
			gameObjectData2.Active = gameObject.activeSelf;
			gameObjectData2.ActiveInHierarchy = gameObject.activeInHierarchy;
			gameObjectData.Children.Add(gameObjectData2);
			for (int j = 0; j < gameObject.transform.childCount; j++)
			{
				Transform child = gameObject.transform.GetChild(j);
				if (child.name.StartsWith("PlayerHpBar_"))
				{
					AddGameObjectData(gameObjectData2, child.gameObject);
				}
			}
		}
		GameObject obj = GameObject.Find("MyPlayer(Clone)/Body/Eye");
		GameObjectData gameObjectData3 = new GameObjectData
		{
			Name = "MyPlayer(Clone)",
			Active = true
		};
		gameObjectData.Children.Add(gameObjectData3);
		GameObjectData gameObjectData4 = new GameObjectData
		{
			Name = "Body",
			Active = true
		};
		gameObjectData3.Children.Add(gameObjectData4);
		AddGameObjectData(gameObjectData4, obj);
		string text = "Records/Test_" + RecordName;
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		File.WriteAllBytes(text + "/" + Index + ".txt", ProtoBufUtility.Serialize(gameObjectData));
		if (!File.Exists(text + "/" + Index + "_Test.txt"))
		{
			File.WriteAllText(text + "/" + Index + "_Test.txt", "");
		}
		Application.OpenURL(Path.GetFullPath(text));
	}

	private static void AddGameObjectData(GameObjectData parentData, GameObject obj)
	{
		GameObjectData gameObjectData = new GameObjectData();
		gameObjectData.Name = obj.name;
		gameObjectData.Active = obj.activeSelf;
		Text component = obj.GetComponent<Text>();
		if (component != null)
		{
			gameObjectData.Enabled = component.enabled;
			gameObjectData.Text = component.text;
		}
		Image component2 = obj.GetComponent<Image>();
		if (component2 != null)
		{
			gameObjectData.Enabled = component2.enabled;
			gameObjectData.Image = ((component2.sprite != null) ? component2.sprite.name : "");
		}
		parentData.Children.Add(gameObjectData);
		Camera component3 = obj.GetComponent<Camera>();
		if (component3 != null)
		{
			gameObjectData.Position.Add(component3.transform.localPosition.x);
			gameObjectData.Position.Add(component3.transform.localPosition.y);
			gameObjectData.Position.Add(component3.transform.localPosition.z);
			gameObjectData.Rotation.Add(component3.transform.localRotation.x);
			gameObjectData.Rotation.Add(component3.transform.localRotation.y);
			gameObjectData.Rotation.Add(component3.transform.localRotation.z);
			gameObjectData.Scale.Add(component3.transform.localScale.z);
			gameObjectData.Scale.Add(component3.transform.localScale.z);
			gameObjectData.Scale.Add(component3.transform.localScale.z);
		}
		for (int i = 0; i < obj.transform.childCount; i++)
		{
			Transform child = obj.transform.GetChild(i);
			AddGameObjectData(gameObjectData, child.gameObject);
		}
	}

	public static void UpdateObserverPlayerId(int playerid)
	{
		if (isServerRecord)
		{
			serverObserverPlayerId = playerid;
		}
	}

	public static void Init(LoggerAdapter _logger, string commandLine, ref string _playRecord)
	{
		GameObject gameObject = GameObject.Find("QuickLoadRecord");
		if (gameObject != null)
		{
			gameObject.SetActive(value: false);
		}
		if (!SpecailDebug.Instance.OpenRecord)
		{
			return;
		}
		_logger.Info("OpenRecordStart,OpenRecordStart,OpenRecordStart");
		Open = true;
		OutputBuffer = new byte[100000];
		SnapshotPacketHandler.Record = (ComputeUserCommandSystem.Record = (SendUserCommandSystem.Record = (SendP2PPackageSystem.Record = (IRecord)(PacketQueue.Record = (UdpPacketFactory.Record = (GameController.Record = (KeyboardEventSystem.Record = (AssembleSystem.Record = (IRecord)(BaseBattleServer.Record = (TcpPacketFactory.Record = (MouseLockSystem.Record = (InputCollector.Record = new RecordAdapter()))))))))))));
		if (!commandLine.Contains("--la"))
		{
			_logger.Info("Play Record Mode !");
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			if (commandLineArgs.Contains("--play_record"))
			{
				FinishedQuit = true;
				_playRecord = commandLineArgs[Array.IndexOf(commandLineArgs, "--play_record") + 1];
			}
			else if (gameObject != null)
			{
				gameObject.SetActive(value: true);
			}
		}
	}
}
