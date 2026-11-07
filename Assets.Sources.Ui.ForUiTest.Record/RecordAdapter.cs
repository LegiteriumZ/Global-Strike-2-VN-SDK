using System.Collections.Generic;
using Assets.Sources.Components.Snapshot;
using Assets.Sources.Snapshots;
using Assets.Sources.Systems.Snapshot;
using Assets.Sources.Utils;
using SSJJNetworking.BattleServer;
using SSJJNetworking.Network;
using SSJJNetworking.Packet;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ForUiTest.Record;

public class RecordAdapter : IRecord, INetworkRecord
{
	public void UpdateKeyDowns(ref Dictionary<int, bool> keyDowns)
	{
		if (NetRecordManager.Open)
		{
			keyDowns = new Dictionary<int, bool>();
			if (NetRecordManager.Playing && NetRecordManager.AutoInput)
			{
				NetRecordManager.Update(ref keyDowns);
			}
		}
	}

	public void GetKeyDown(Dictionary<int, bool> keyDowns, ref bool down, int key)
	{
		if (!NetRecordManager.Open)
		{
			return;
		}
		if (NetRecordManager.Playing)
		{
			if (NetRecordManager.AutoInput)
			{
				down = keyDowns.ContainsKey(key);
			}
		}
		else if (down)
		{
			keyDowns[key] = true;
		}
	}

	public void RecordKeyDowns(Dictionary<int, bool> keyDowns)
	{
		if (NetRecordManager.Open && !NetRecordManager.Playing)
		{
			NetRecordManager.Add(keyDowns);
		}
	}

	public void RecordUdp(object factory, byte[] data, int len)
	{
		if (NetRecordManager.Open && !MultiPlayerServerManager.MultiPlayerInstances.Contains(factory))
		{
			NetRecordManager.Add(data, len, tcp: false);
		}
	}

	private string GetObjPath()
	{
		Transform transform = EventSystem.current.currentSelectedGameObject.transform;
		string text = transform.name;
		while (transform.parent != null)
		{
			text = transform.parent.name + "/" + text;
			transform = transform.parent;
		}
		return text;
	}

	public void RecordMouseLock()
	{
		if (NetRecordManager.Open && !NetRecordManager.Playing && EventSystem.current.currentSelectedGameObject != null)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			string text3 = string.Empty;
			string text4 = string.Empty;
			string text5 = string.Empty;
			string text6 = string.Empty;
			if (Input.GetMouseButtonDown(0))
			{
				text = GetObjPath();
			}
			if (Input.GetMouseButtonUp(0))
			{
				text2 = GetObjPath();
			}
			if (Input.GetMouseButtonDown(1))
			{
				text3 = GetObjPath();
			}
			if (Input.GetMouseButtonUp(1))
			{
				text4 = GetObjPath();
			}
			if (Input.GetMouseButtonDown(2))
			{
				text5 = GetObjPath();
			}
			if (Input.GetMouseButtonUp(2))
			{
				text6 = GetObjPath();
			}
			if (!string.IsNullOrEmpty(text) || !string.IsNullOrEmpty(text2) || !string.IsNullOrEmpty(text3) || !string.IsNullOrEmpty(text4) || !string.IsNullOrEmpty(text5) || !string.IsNullOrEmpty(text6))
			{
				NetRecordManager.Add(text, text2, text3, text4, text5, text6, Input.mousePosition);
			}
		}
	}

	private void TriggerDownEvent(string path, PointerEventData.InputButton button, Vector2 mousePos)
	{
		if (string.IsNullOrEmpty(path))
		{
			return;
		}
		GameObject gameObject = GameObject.Find(path);
		if (!(gameObject != null))
		{
			return;
		}
		EventTrigger component = gameObject.GetComponent<EventTrigger>();
		if (!(component != null))
		{
			return;
		}
		foreach (EventTrigger.Entry trigger in component.triggers)
		{
			if (trigger.eventID == EventTriggerType.PointerDown)
			{
				trigger.callback.Invoke(new PointerEventData(EventSystem.current)
				{
					button = button,
					position = mousePos
				});
			}
		}
	}

	private void TriggerUpEvent(string path, PointerEventData.InputButton button, Vector2 mousePos)
	{
		if (string.IsNullOrEmpty(path))
		{
			return;
		}
		GameObject gameObject = GameObject.Find(path);
		if (!(gameObject != null))
		{
			return;
		}
		Button component = gameObject.GetComponent<Button>();
		if (component != null)
		{
			component.onClick.Invoke();
		}
		EventTrigger component2 = gameObject.GetComponent<EventTrigger>();
		if (!(component2 != null))
		{
			return;
		}
		foreach (EventTrigger.Entry trigger in component2.triggers)
		{
			if (trigger.eventID == EventTriggerType.PointerClick || trigger.eventID == EventTriggerType.PointerUp)
			{
				trigger.callback.Invoke(new PointerEventData(EventSystem.current)
				{
					button = button,
					position = mousePos
				});
			}
		}
	}

	public void UpdateMouseLock()
	{
		if (NetRecordManager.Open && NetRecordManager.Playing && NetRecordManager.AutoInput)
		{
			string leftDown = string.Empty;
			string leftUp = string.Empty;
			string rightDown = string.Empty;
			string rightUp = string.Empty;
			string middleDown = string.Empty;
			string middleUp = string.Empty;
			Vector2 mousePos = NetRecordManager.Update(ref leftDown, ref leftUp, ref rightDown, ref rightUp, ref middleDown, ref middleUp);
			TriggerDownEvent(leftDown, PointerEventData.InputButton.Left, mousePos);
			TriggerDownEvent(rightDown, PointerEventData.InputButton.Right, mousePos);
			TriggerDownEvent(middleDown, PointerEventData.InputButton.Middle, mousePos);
			TriggerUpEvent(leftUp, PointerEventData.InputButton.Left, mousePos);
			TriggerUpEvent(rightUp, PointerEventData.InputButton.Right, mousePos);
			TriggerUpEvent(middleUp, PointerEventData.InputButton.Middle, mousePos);
		}
	}

	public object FixSnapshot(object baseSnapshot, object snapshot, object comp)
	{
		object obj = baseSnapshot;
		if (NetRecordManager.Open && NetRecordManager.Playing)
		{
			int num = ((Snapshot)snapshot).Base;
			while (obj == null && num > 0)
			{
				num--;
				obj = AssembleSystem.GetBaseSnapshot((SnapshotsComponent)comp, num);
			}
		}
		return obj;
	}

	public void RecordTcp(object factory, byte[] packetData)
	{
		if (NetRecordManager.Open && !MultiPlayerServerManager.MultiPlayerInstances.Contains(factory))
		{
			NetRecordManager.Add(packetData, packetData.Length, tcp: true);
		}
	}

	public void SelectObserverPlayerId(int playerId)
	{
		if (NetRecordManager.Open)
		{
			NetRecordManager.UpdateObserverPlayerId(playerId);
		}
	}

	public bool UpdateInput(ref float axisX, ref float axisY, Dictionary<int, bool> keys, Dictionary<int, bool> keyDowns, ref bool leftMouse, ref bool rightMouse, ref bool middleMouse, ref float scrollWheel, ref float deltaTime, ref float diff)
	{
		if (NetRecordManager.Open && NetRecordManager.Playing && NetRecordManager.AutoInput)
		{
			NetRecordManager.Update(ref axisX, ref axisY, keys, keyDowns, ref leftMouse, ref rightMouse, ref middleMouse, ref scrollWheel, ref deltaTime, ref diff);
			return true;
		}
		return false;
	}

	public bool SendTcpLog()
	{
		if (!NetRecordManager.Open || !NetRecordManager.Playing)
		{
			return true;
		}
		return false;
	}

	public void RecordInput(float axisX, float axisY, Dictionary<int, bool> keys, Dictionary<int, bool> keyDowns, bool leftMouse, bool rightMouse, bool middleMouse, float scrollWheel, float deltaTime, float diff)
	{
		if (NetRecordManager.Open)
		{
			NetRecordManager.Add(axisX, axisY, keys, keyDowns, leftMouse, rightMouse, middleMouse, scrollWheel, deltaTime, diff);
		}
	}

	public void UpdatePacketQueue(object queueIns, object tcpPacketQueue, object udpPacketQueue)
	{
		if (NetRecordManager.Open && NetRecordManager.Playing && !MultiPlayerServerManager.MultiPlayerInstances.Contains(queueIns))
		{
			NetRecordManager.Update((IBattleServer)queueIns, (PacketQueue)tcpPacketQueue, (PacketQueue)udpPacketQueue);
		}
	}

	public bool UpdateGame()
	{
		if (NetRecordManager.Open)
		{
			if (NetRecordManager.Playing)
			{
				if (NetRecordManager.Pause && NetRecordManager.Step <= 0)
				{
					return true;
				}
				if (NetRecordManager.Step > 0)
				{
					NetRecordManager.Step--;
				}
				if (!NetRecordManager.Update())
				{
					return true;
				}
			}
			else
			{
				NetRecordManager.Add();
			}
		}
		return false;
	}

	public bool NoHandlerLog(object queue)
	{
		if (MultiPlayerServerManager.MultiPlayerInstances.Contains(queue))
		{
			return false;
		}
		return true;
	}

	public bool IsPlaying()
	{
		return NetRecordManager.Playing;
	}

	public bool IsSelfMove()
	{
		return MultiPlayerServerManager.IsSelfMove;
	}

	public bool IsServerRecord()
	{
		return NetRecordManager.isServerRecord;
	}
}
