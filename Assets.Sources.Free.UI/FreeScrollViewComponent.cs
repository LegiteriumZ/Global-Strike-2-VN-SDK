using System;
using System.Collections.Generic;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Free.UI;

public class FreeScrollViewComponent : FreeBaseComponent
{
	public class ScrollViewComponentData
	{
		public int BackGroundWidth = 200;

		public int BackGroundHeight = 400;

		public int ContentPosX = 10;

		public int ContentPosY = 10;

		public int ContentWidth = 180;

		public int ContentHeight = 360;

		public int ItemPadingLeft = 10;

		public int ItemPadingUp = 10;

		public int ItemDeltaX = 20;

		public int ItemDeltaY = 20;

		public int ColumeCount = 2;

		public int CellHeight = 100;

		public int CellWidth = 100;

		public int CurrentContentX;

		public int CurrentContentY;

		public int CurrentContentWidth;

		public int CurrentContentHeight;

		public int StartX;

		public int StartY;

		public int NewX;

		public int NewY;

		public int AllHeight;

		public int Line;

		public void Reset()
		{
			StartX = ItemPadingLeft;
			StartY = -ItemPadingUp;
			Line = 1;
		}

		public void AddItem(int width, int height, int index)
		{
			int num = index % ColumeCount;
			int num2 = index / ColumeCount;
			NewX = ItemPadingLeft + (width + ItemDeltaX) * num;
			NewY = -(ItemPadingUp + (height + ItemDeltaY) * num2);
			Line = Mathf.Max(Line, num2 + 1);
			AllHeight = Line * (height + ItemDeltaY) + ItemPadingUp;
		}

		public void AddOver()
		{
			StartX = NewX;
			StartY = NewY;
		}

		public override string ToString()
		{
			return "";
		}
	}

	private class SimpleFreeData
	{
		public string Key;

		public int Index;
	}

	private Transform _parent;

	private Transform _background;

	private Transform _scrollViewContent;

	private Transform _scrollViewItemParent;

	private Transform _scrollViewBar;

	private Texture2D _backTexture2D;

	private Texture2D _barTexture2D;

	private ScrollViewComponentData _data;

	private readonly List<SimpleFreeData> _simpleFreeDatas = new List<SimpleFreeData>();

	public string KeyWord => base.FreeUi.Key;

	public void Reset()
	{
		_simpleFreeDatas.Clear();
	}

	public FreeScrollViewComponent()
	{
		base.Type = 12;
		base.ValueType = 2;
		AssetInfoDirs = new Dictionary<string, AssetInfo>();
		GameObject engineObj = new GameObject("ScollViewToUi");
		UnityObject = new UnityUiObject(engineObj);
		UnityObject.Anchor = new Vector2(0f, 1f);
		UnityObject.GameObject.GetComponent<RectTransform>().pivot = new Vector2(0f, 1f);
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	private void LoadBackImageOver(Texture2D texture2D)
	{
		_backTexture2D = texture2D;
		LoadingOverSetData();
	}

	private void LoadBarImageOver(Texture2D texture2D)
	{
		_barTexture2D = texture2D;
		LoadingOverSetData();
	}

	private void LoadScrollViewOver(GameObject gameObject)
	{
		gameObject.name = base.Key;
		_parent = gameObject.transform;
		_background = _parent.Find("Center/BackImage");
		_scrollViewContent = _parent.Find("Center/Scroll View");
		_scrollViewBar = _scrollViewContent.Find("ScrollbarVertical/Sliding Area/Handle");
		_scrollViewItemParent = _scrollViewContent.Find("Viewport/Content");
		int siblingIndex = ToUI().GameObject.transform.GetSiblingIndex();
		gameObject.transform.SetParent(ToUI().GameObject.transform.parent);
		gameObject.transform.SetSiblingIndex(siblingIndex);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		Vector2 anchorMax = (gameObject.GetComponent<RectTransform>().anchorMin = ToUI().Anchor);
		component.anchorMax = anchorMax;
		RectTransform component2 = ToUI().GameObject.GetComponent<RectTransform>();
		gameObject.GetComponent<RectTransform>().pivot = component2.pivot;
		gameObject.GetComponent<RectTransform>().localPosition = component2.localPosition;
		gameObject.GetComponent<RectTransform>().sizeDelta = component2.sizeDelta;
		gameObject.name = "ScrollView";
		RectTransform component3 = _scrollViewItemParent.GetComponent<RectTransform>();
		if (_data.CurrentContentWidth >= _data.ContentWidth && _data.CurrentContentHeight >= _data.ContentHeight)
		{
			component3.sizeDelta = new Vector2(_data.CurrentContentWidth, _data.CurrentContentHeight);
			component3.localPosition = new Vector3(_data.CurrentContentX, _data.CurrentContentY, 0f);
		}
		ToUI().GameObject = gameObject;
		LoadingOverSetData();
	}

	private void LoadingOverSetData()
	{
		if (_backTexture2D != null && _barTexture2D != null && _parent != null && _data != null)
		{
			_background.GetComponent<RectTransform>().sizeDelta = new Vector2(_data.BackGroundWidth, _data.BackGroundHeight);
			_scrollViewContent.localPosition = new Vector3(_data.ContentPosX, _data.ContentPosY, 0f);
			_scrollViewContent.GetComponent<RectTransform>().sizeDelta = new Vector2(_data.ContentWidth, _data.ContentHeight);
			_scrollViewBar.GetComponent<Image>().sprite = Sprite.Create(_barTexture2D, new Rect(0f, 0f, _barTexture2D.width, _barTexture2D.height), new Vector2(0f, 1f));
			_background.GetComponent<Image>().sprite = Sprite.Create(_backTexture2D, new Rect(0f, 0f, _backTexture2D.width, _backTexture2D.height), new Vector2(0f, 1f));
			Reset();
			RefreshView();
			FreeUiScrollViewAdapter.Instance.AddScrollView(this);
		}
	}

	public override void Initial(params object[] ini)
	{
		InitialAuto(ini[1] as string);
		string[] array = (ini[0] as string).Split("_$$$_");
		if (array.Length > 1)
		{
			string[] array2 = array[0].Split(',');
			_data = new ScrollViewComponentData
			{
				BackGroundWidth = (int)float.Parse(array2[0]),
				BackGroundHeight = (int)float.Parse(array2[1]),
				ContentPosX = (int)float.Parse(array2[2]),
				ContentPosY = -(int)float.Parse(array2[3]),
				ContentWidth = (int)float.Parse(array2[4]),
				ContentHeight = (int)float.Parse(array2[5]),
				ItemPadingLeft = (int)float.Parse(array2[6]),
				ItemPadingUp = (int)float.Parse(array2[7]),
				ItemDeltaX = (int)float.Parse(array2[8]),
				ItemDeltaY = (int)float.Parse(array2[9]),
				ColumeCount = (int)float.Parse(array2[10]),
				CellWidth = (int)float.Parse(array2[11]),
				CellHeight = (int)float.Parse(array2[12]),
				CurrentContentX = (int)float.Parse(array2[13]),
				CurrentContentWidth = (int)float.Parse(array2[14]),
				CurrentContentY = (int)float.Parse(array2[15]),
				CurrentContentHeight = (int)float.Parse(array2[16])
			};
			array2 = array[1].Split(',');
			BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadTexture2D(GetAssetInfoGenImageUrl(array2[0]), LoadBackImageOver));
			BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadTexture2D(GetAssetInfoGenImageUrl(array2[1]), LoadBarImageOver));
			BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadScrollView(LoadScrollViewOver));
		}
	}

	private void SetVisiable(bool vaule)
	{
		if (!vaule)
		{
			Reset();
		}
	}

	public override void SetRelation(SimpleFreeUI freeUi)
	{
		base.SetRelation(freeUi);
		freeUi.SetVisiable = (Action<bool>)Delegate.Combine(freeUi.SetVisiable, new Action<bool>(SetVisiable));
	}

	public override void Frame(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		base.Frame(uiDataManager, frameTime, gGroup);
		foreach (AutoField auto in Autos)
		{
			if (auto.field == "add")
			{
				string @string = auto.auto.Frame(frameTime).String;
				if (!FreeBaseComponent.IsNullString(@string))
				{
					string[] array = @string.Split("***");
					for (int i = 0; i < array.Length; i += 2)
					{
						string simpleFreeUiKey = array[i];
						int scrollViewContentIndex = int.Parse(array[i + 1]);
						AddSimpleFreeUi(simpleFreeUiKey, scrollViewContentIndex);
						RefreshView();
					}
				}
			}
			if (!(auto.field == "remove"))
			{
				continue;
			}
			string string2 = auto.auto.Frame(frameTime).String;
			if (!FreeBaseComponent.IsNullString(string2))
			{
				string[] array2 = string2.Split("***");
				for (int j = 0; j < array2.Length; j += 2)
				{
					string simpleFreeUiKey2 = array2[j];
					RemoveSimpleFreeUi(simpleFreeUiKey2);
				}
			}
		}
	}

	protected override void handleToBeBindField(AutoField auto)
	{
		base.handleToBeBindField(auto);
		if (auto.field.Equals("scrollComponentProgress"))
		{
			auto.auto.SetValue(GetValue());
		}
	}

	public override IFreeComponent Clone()
	{
		return new FreeScrollViewComponent();
	}

	public void AddSimpleFreeUi(string simpleFreeUiKey)
	{
		SimpleFreeUI value = null;
		if (MonoBehaviourSingleton<FreeUiManager>.Instance.Uis.TryGetValue(simpleFreeUiKey, out value))
		{
			AddSimpleFreeUi(value);
		}
		else
		{
			FreeBaseComponent.Logger.ErrorFormat("Find No SimpleFreeUi, Key {0}", simpleFreeUiKey);
		}
	}

	private void AddSimpleFreeUi(SimpleFreeUI simpleFree)
	{
		AddSimpleFreeUi(simpleFree.Key, simpleFree.ScrollViewContentIndex);
		RefreshView();
	}

	public void AddSimpleFreeUi(List<SimpleFreeUI> simpleFrees)
	{
		for (int i = 0; i < simpleFrees.Count; i++)
		{
			AddSimpleFreeUi(simpleFrees[i].Key, simpleFrees[i].ScrollViewContentIndex);
		}
		RefreshView();
	}

	public void AddSimpleFreeUi(string simpleFreeUiKey, int scrollViewContentIndex)
	{
		int num = -1;
		for (int i = 0; i < _simpleFreeDatas.Count; i++)
		{
			if (_simpleFreeDatas[i].Key.Equals(simpleFreeUiKey))
			{
				num = i;
				break;
			}
		}
		if (num > -1)
		{
			_simpleFreeDatas[num].Index = scrollViewContentIndex;
			return;
		}
		_simpleFreeDatas.Add(new SimpleFreeData
		{
			Index = scrollViewContentIndex,
			Key = simpleFreeUiKey
		});
	}

	public void RemoveSimpleFreeUi(string simpleFreeUiKey)
	{
		SimpleFreeUI value = null;
		if (MonoBehaviourSingleton<FreeUiManager>.Instance.Uis.TryGetValue(simpleFreeUiKey, out value))
		{
			RemoveSimpleFreeUi(value);
		}
		else
		{
			FreeBaseComponent.Logger.ErrorFormat("Find No SimpleFreeUi, Key {0}", simpleFreeUiKey);
		}
	}

	private void RemoveSimpleFreeUi(SimpleFreeUI simpleFree)
	{
		int num = -1;
		for (int i = 0; i < _simpleFreeDatas.Count; i++)
		{
			if (_simpleFreeDatas[i].Key.Equals(simpleFree.Key))
			{
				num = i;
				break;
			}
		}
		if (num > 0)
		{
			_simpleFreeDatas.RemoveAt(num);
			RefreshView();
		}
	}

	private void RefreshView()
	{
		if (_parent == null || _data == null)
		{
			return;
		}
		_data.Reset();
		List<Transform> list = new List<Transform>();
		for (int i = 0; i < _scrollViewItemParent.childCount; i++)
		{
			list.Add(_scrollViewItemParent.GetChild(i));
		}
		foreach (Transform item in list)
		{
			item.SetParent(base.FreeUi.gameObject.transform.parent);
		}
		List<Transform> list2 = new List<Transform>();
		for (int j = 0; j < _simpleFreeDatas.Count; j++)
		{
			SimpleFreeUI value = null;
			if (MonoBehaviourSingleton<FreeUiManager>.Instance.Uis.TryGetValue(_simpleFreeDatas[j].Key, out value))
			{
				if (value == null)
				{
					this.LogErrorFormat("Find No Simple Free Ui {0}", _simpleFreeDatas[j].Key);
					continue;
				}
				_data.AddItem(_data.CellWidth, _data.CellHeight, _simpleFreeDatas[j].Index);
				_data.AddOver();
				value.transform.localPosition = new Vector3(_data.StartX, _data.StartY, 0f);
				list2.Add(value.transform);
			}
		}
		_scrollViewItemParent.GetComponent<RectTransform>().sizeDelta = new Vector2(_data.ContentWidth, _data.AllHeight);
		foreach (Transform item2 in list2)
		{
			Vector3 localPosition = item2.localPosition;
			item2.SetParent(_scrollViewItemParent);
			item2.localPosition = localPosition;
		}
	}

	protected override string[] GetValue()
	{
		string[] result = new string[1] { "" };
		if (_scrollViewItemParent == null)
		{
			return result;
		}
		RectTransform component = _scrollViewItemParent.GetComponent<RectTransform>();
		if (component == null)
		{
			return result;
		}
		int num = (int)component.localPosition.y;
		int num2 = (int)component.sizeDelta.y;
		int num3 = (int)component.localPosition.x;
		int num4 = (int)component.sizeDelta.x;
		return new string[1] { num3 + "," + num4 + "," + num + "," + num2 };
	}
}
