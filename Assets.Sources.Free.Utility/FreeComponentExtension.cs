using System.Collections.Generic;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.UI;
using NetData;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using SSJJUserCmd;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Free.Utility;

public static class FreeComponentExtension
{
	public static void InitialFreeComponent(this IFreeComponent newPo, int index, SimpleProto sp, IComponentGroup gGroup, float deltaY = 0f, bool isWorld = true)
	{
		newPo.SetPos(gGroup, sp.Fs[index * 2], sp.Fs[index * 2 + 1] + deltaY, sp.Ins[index * 4], sp.Ins[index * 4 + 1], sp.Ins[index * 4 + 2], sp.Ins[index * 4 + 3], isWorld);
		newPo.Initial(sp.Ss[index * 4 + 1], sp.Ss[index * 4 + 2]);
		newPo.EventKey = sp.Ss[index * 4 + 3];
		newPo.CanDrag = sp.Bs.Count >= 3 && sp.Bs[2];
	}

	public static void SendTcpMsg(this IFreeComponent newPo, FreeUIEvent uiEvent)
	{
		MonoBehaviourSingleton<FreeUiManager>.Instance.SendFreeMessage(uiEvent.Key, newPo);
	}

	public static void ImagePointClick(this IFreeComponent newPo, ref FreeUIEvent freeEvent, PointerEventData eventData, string eventKey)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			freeEvent.Event = 1;
			freeEvent.Key.Key = freeEvent.Event;
			freeEvent.Key.Ss.Add(eventKey);
		}
		else if (eventData.button != PointerEventData.InputButton.Middle)
		{
			freeEvent.Event = 8;
			UserCmd value = Contexts.sharedInstance.userCommand.commands.CommandToSendList.First.Value;
			if (value != null && (value.Buttons & 0x40000000) > 0)
			{
				freeEvent.Event = 9;
			}
			freeEvent.Key.Key = freeEvent.Event;
			freeEvent.Key.Ss.Add(eventKey);
		}
	}

	public static void ImagePointerEnter(this IFreeComponent newPo, ref FreeUIEvent freeEvent, string eventKey)
	{
		freeEvent.Event = 4;
		freeEvent.Key.Key = freeEvent.Event;
		freeEvent.Key.Ss.Add(eventKey);
	}

	public static void ImagePointerExit(this IFreeComponent newPo, ref FreeUIEvent freeEvent, string eventKey)
	{
		freeEvent.Event = 5;
		freeEvent.Key.Key = freeEvent.Event;
		freeEvent.Key.Ss.Add(eventKey);
	}

	public static void ImageBeginDrag(this IFreeComponent newPo, PointerEventData eventData, ref float beginDragX, ref float beginDragY, ref float beginSfX, ref float beginSfY)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			DragStartCheckSetScrollView(newPo.FreeUi);
			Vector2 position = eventData.position;
			beginDragX = position.x;
			beginDragY = position.y;
			beginSfX = newPo.FreeUi.X;
			beginSfY = newPo.FreeUi.Y;
		}
	}

	public static void ImageDraging(this IFreeComponent newPo, PointerEventData eventData, float beginDragX, float beginDragY, float beginSfX, float beginSfY, bool isFixed)
	{
		if (eventData.button == PointerEventData.InputButton.Left && newPo.FreeUi != null && !isFixed)
		{
			newPo.FreeUi.gameObject.transform.SetSiblingIndex(10000);
			Vector2 position = eventData.position;
			newPo.FreeUi.X = beginSfX + (position.x - beginDragX);
			newPo.FreeUi.Y = beginSfY + (0f - (position.y - beginDragY));
		}
	}

	public static void ImageEndDrag(this IFreeComponent newPo, PointerEventData eventData, float beginDragX, float beginDragY, float beginSfX, float beginSfY, bool isFixed, ref FreeUIEvent freeEvent, string eventKey, List<AutoField> autos)
	{
		if (eventData.button != 0 || !(newPo.FreeUi != null) || isFixed)
		{
			return;
		}
		freeEvent.Key.Ss.Clear();
		freeEvent.Key.Ins.Clear();
		freeEvent.Event = 3;
		freeEvent.Key.Key = freeEvent.Event;
		freeEvent.Key.Ss.Add(eventKey);
		freeEvent.Key.Ins.Add((int)(eventData.position.x - beginDragX));
		freeEvent.Key.Ins.Add((int)(0f - (eventData.position.y - beginDragY)));
		Vector2 position = eventData.position;
		freeEvent.Key.Ins.Add((int)position.x);
		freeEvent.Key.Ins.Add((int)((float)Screen.height - position.y));
		freeEvent.Key.Ins.Add(Screen.width);
		freeEvent.Key.Ins.Add(Screen.height);
		freeEvent.Key.Ins.Add((int)beginDragX);
		freeEvent.Key.Ins.Add((int)((float)Screen.height - beginDragY));
		string text = null;
		for (int i = 0; i < autos.Count; i++)
		{
			AutoField autoField = autos[i];
			if (autoField.field == "eventData")
			{
				text = autoField.auto.Frame(0).String;
			}
		}
		if (text != null && text.Split(",").Length == 4)
		{
			freeEvent.Key.Ss.Add(text);
		}
		DragEndCheckSetScrollView(newPo.FreeUi);
	}

	private static void DragStartCheckSetScrollView(SimpleFreeUI freeUi)
	{
		if (freeUi != null && FreeUiScrollViewAdapter.Instance.GetScrollViewSimpleFreeUi(freeUi) != null)
		{
			freeUi.gameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetFreeUiTran());
		}
	}

	private static void DragEndCheckSetScrollView(SimpleFreeUI freeUi)
	{
		if (freeUi != null)
		{
			SimpleFreeUI scrollViewSimpleFreeUi = FreeUiScrollViewAdapter.Instance.GetScrollViewSimpleFreeUi(freeUi);
			if (scrollViewSimpleFreeUi != null)
			{
				freeUi.gameObject.transform.SetParent(scrollViewSimpleFreeUi.transform);
			}
		}
	}
}
