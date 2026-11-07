using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Map;
using Assets.Sources.Free.Utility;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class FreeUiManager : MonoBehaviourSingleton<FreeUiManager>
{
	private readonly Dictionary<string, SimpleFreeUI> _uis;

	private Transform _uiParent;

	private readonly Dictionary<int, Transform> _layerDictionary = new Dictionary<int, Transform>();

	private GameObject _freeCanvas;

	private Transform _freeUi;

	private GameObject _freeHighSortCanvas;

	private Transform _freeHightSortUi;

	private bool _hasActivate;

	public Dictionary<string, SimpleFreeUI> Uis => _uis;

	public SimpleProto FreeEvent
	{
		get
		{
			foreach (KeyValuePair<string, SimpleFreeUI> ui in _uis)
			{
				SimpleFreeUI value = ui.Value;
				FreeUIEvent freeUiEvent = value.GetFreeUiEvent();
				if (freeUiEvent != null && value.Visible)
				{
					SimpleProto result = freeUiEvent.ToData();
					freeUiEvent.ResetEvent();
					return result;
				}
			}
			return null;
		}
	}

	public bool ShowMouse
	{
		get
		{
			foreach (KeyValuePair<string, SimpleFreeUI> ui in _uis)
			{
				SimpleFreeUI value = ui.Value;
				if (value.ShowMouse && value.Visible)
				{
					return true;
				}
			}
			return false;
		}
	}

	public Dictionary<string, SimpleFreeUI> FreeUIs => _uis;

	public FreeUiManager()
	{
		_uis = new Dictionary<string, SimpleFreeUI>();
	}

	public Transform GetTemplateParent()
	{
		if (_uiParent == null)
		{
			GameObject gameObject = new GameObject("FreeUI");
			_uiParent = gameObject.transform;
		}
		return _uiParent;
	}

	public SimpleFreeUI GetSmallMap()
	{
		return GetUi("小地图UI");
	}

	public SimpleFreeUI GetAllKillInfo()
	{
		return GetUi("对战战绩UI");
	}

	public SimpleFreeUI GetUi(string key)
	{
		SimpleFreeUI value = null;
		_uis.TryGetValue(key, out value);
		return value;
	}

	public List<SimpleFreeUI> GetUiWithPrefix(string key)
	{
		List<SimpleFreeUI> list = new List<SimpleFreeUI>();
		foreach (SimpleFreeUI value in _uis.Values)
		{
			if (value.Key.StartsWith(key))
			{
				list.Add(value);
			}
		}
		return list;
	}

	public void RemoveOldUi(string key)
	{
		SimpleFreeUI ui = GetUi(key);
		if (ui != null)
		{
			ui.IsDisabled = true;
			if (MonoBehaviourSingleton<FreePool>.Instance.CheckIsRecyclable(key))
			{
				MonoBehaviourSingleton<FreePool>.Instance.Collect(ui);
			}
			else
			{
				Object.Destroy(ui.gameObject);
			}
		}
		FreeUiScrollViewAdapter.Instance.RemoveFreeUiKey(key, ui, isReplace: true);
		_uis.Remove(key);
	}

	public Transform GetOrCreateLayerTran(int layer)
	{
		if (_layerDictionary.ContainsKey(layer))
		{
			return _layerDictionary[layer];
		}
		GameObject gameObject = new GameObject();
		gameObject.transform.parent = _freeUi;
		gameObject.transform.SetSiblingIndex(layer);
		RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchorMin = new Vector2(0f, 1f);
		rectTransform.anchorMax = new Vector2(0f, 1f);
		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
		rectTransform.pivot = new Vector2(0f, 1f);
		gameObject.AddComponent<CanvasRenderer>();
		_layerDictionary.Add(layer, gameObject.transform);
		return _layerDictionary[layer];
	}

	public void RemoveAllUi()
	{
		_uis.Clear();
	}

	public void AddUi(SimpleFreeUI ui)
	{
		_uis.Add(ui.Key, ui);
	}

	public Transform GetFreeUiTran()
	{
		return _freeUi;
	}

	public GameObject GetFreeCanvas()
	{
		_freeCanvas = GameObject.Find("FreeCanvas");
		if (_freeCanvas == null)
		{
			_freeCanvas = UnityUiUtility.CreateCanvas(Screen.width, Screen.height);
		}
		if (!_hasActivate)
		{
			_freeCanvas.GetComponent<Canvas>().enabled = false;
		}
		_freeUi = _freeCanvas.transform.Find("FreeUI");
		if (_freeUi == null)
		{
			GameObject gameObject = new GameObject("FreeUI");
			gameObject.transform.parent = _freeCanvas.transform;
			RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
			rectTransform.anchorMin = new Vector2(0f, 1f);
			rectTransform.anchorMax = new Vector2(0f, 1f);
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
			rectTransform.pivot = new Vector2(0f, 1f);
			gameObject.AddComponent<CanvasRenderer>();
			_freeUi = gameObject.transform;
		}
		_freeCanvas.GetComponent<Canvas>().sortingOrder = 111;
		return _freeCanvas;
	}

	public void CopyHighSortFreeCanvas()
	{
		_freeHighSortCanvas = Object.Instantiate(_freeCanvas);
		_freeHighSortCanvas.name = "HightSortFreeCanvas";
		_freeHighSortCanvas.GetComponent<Canvas>().sortingOrder++;
		_freeHighSortCanvas.GetComponent<Canvas>().enabled = true;
		_freeHightSortUi = _freeHighSortCanvas.transform.Find("FreeUI");
	}

	public void SetScrollViewHigtSortCanvas(SimpleFreeUI sf)
	{
		sf.gameObject.transform.SetParent(_freeHightSortUi);
	}

	public void ResetScollViewCanvas(SimpleFreeUI sf)
	{
		sf.gameObject.transform.SetParent(_freeUi);
	}

	public void ClickSmallMap(Vector3 pos, float distance)
	{
		GetSmallMap().SmallMapComponent?.ClickSmallMap(pos, distance);
	}

	public void ActivateCanvas()
	{
		if (_freeCanvas != null)
		{
			_freeCanvas.GetComponent<Canvas>().enabled = true;
		}
		_hasActivate = true;
	}

	public void OnPlayback()
	{
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			SimpleFreeUI allKillInfo = GetAllKillInfo();
			if (allKillInfo != null)
			{
				allKillInfo.Visible = true;
			}
		}
		if (Input.GetKeyDown(KeyCode.BackQuote))
		{
			SimpleFreeUI smallMap = GetSmallMap();
			if (smallMap != null)
			{
				smallMap.Visible = true;
			}
		}
		if (Input.GetKeyUp(KeyCode.Tab))
		{
			SimpleFreeUI allKillInfo2 = GetAllKillInfo();
			if (allKillInfo2 != null)
			{
				allKillInfo2.Visible = false;
			}
		}
		if (Input.GetKeyUp(KeyCode.BackQuote))
		{
			SimpleFreeUI smallMap2 = GetSmallMap();
			if (smallMap2 != null)
			{
				smallMap2.Visible = false;
			}
		}
		SendFreeMessage();
	}

	private void SendFreeMessage()
	{
		SimpleProto freeEvent = FreeEvent;
		if (freeEvent != null)
		{
			SendFreeMessage(freeEvent, null);
		}
	}

	public void SendFreeMessage(SimpleProto proto, IFreeComponent component)
	{
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(100, proto);
		if (proto != null)
		{
			if (proto.Ss == null)
			{
				this.LogErrorFormat("Room > {0}, Ss==null, component > {1}", GetRoomMsg(), component?.Type ?? (-1));
			}
			else if (proto.Ss.Count == 0)
			{
				this.LogErrorFormat("Room > {0}, Ss.Count==0, component > {1}", GetRoomMsg(), component?.Type ?? (-1));
			}
		}
	}

	private string GetRoomMsg()
	{
		RoomData data = Contexts.sharedInstance.battleRoom.roomData.Data;
		IMapInfo mapInfo = Contexts.sharedInstance.battleRoom.mapInfo.MapInfo;
		string text = "";
		if (data != null && mapInfo != null)
		{
			text = text + "RaceType > " + data.RaceType + "  FreeType > " + data.FreeType + "  SceneId > " + mapInfo.Id;
		}
		return text;
	}
}
