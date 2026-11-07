using System;
using System.Collections.Generic;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using NetData;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class FreeListComponent : FreeBaseComponent, IComponentGroup
{
	private readonly List<IFreeComponent> _allTextList;

	private int _row;

	private int _colum;

	private readonly GameObject sprite;

	private int _height;

	private int _width;

	private float _deltaY;

	private List<int> index;

	private List<List<IFreeComponent>> llist;

	public int ComponentCount => _colum * _row;

	public FreeListComponent()
	{
		base.Type = 4;
		base.ValueType = 7;
		sprite = new GameObject("List");
		sprite.AddComponent<RectTransform>();
		sprite.AddComponent<CanvasRenderer>();
		UnityObject = new UnityUiObject(sprite);
		_allTextList = new List<IFreeComponent>();
		llist = new List<List<IFreeComponent>>();
		index = new List<int>();
		for (int i = 0; i < 8; i++)
		{
			index.Add(0);
		}
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	public override void Frame(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		for (int i = 0; i < _allTextList.Count; i++)
		{
			_allTextList[i].Frame(uiDataManager, frameTime, gGroup);
		}
	}

	public override void SetValue(SetValueAdapter.SetValueData setValueDataA, SetValueAdapter.SetValueData setValueDataB)
	{
		string str = setValueDataA.ToString();
		for (int i = 0; i < _allTextList.Count; i++)
		{
			IFreeComponent freeComponent = _allTextList[i];
			SetValueAdapter.SetValueData data = SetValueAdapter.Instance.GetData();
			SetValueAdapter.SetValueData data2 = SetValueAdapter.Instance.GetData();
			data.SetValueInt = 0;
			data2.SetValueStr = "";
			freeComponent.SetValue(data, data2);
			SetValueAdapter.Instance.Release(data, data2);
		}
		if (!FreeBaseComponent.IsNullString(str))
		{
			string[] array = str.Split("_");
			SimpleProto setValueProto = setValueDataB.SetValueProto;
			for (int j = 0; j < Math.Min(array.Length, _row); j++)
			{
				int num = Convert.ToInt32(array[j]);
				SimpleProto simpleProto = setValueProto.Ps[num];
				SimpleFreeUI.SetValue(base.Key, simpleProto, llist[j]);
			}
		}
	}

	public override void Initial(params object[] ini)
	{
		if (ini[0] is string)
		{
			string[] array = (ini[0] as string).Split("_");
			if (array.Length == 2)
			{
				_colum = int.Parse(array[0]);
				_row = int.Parse(array[1]);
				_deltaY = _height / _row;
			}
		}
		else
		{
			if (!(ini[0] is SimpleProto))
			{
				return;
			}
			SimpleFreeUI simpleFreeUI = Group as SimpleFreeUI;
			SimpleProto simpleProto = ini[0] as SimpleProto;
			for (int i = 0; i < _row; i++)
			{
				List<IFreeComponent> list = new List<IFreeComponent>();
				for (int j = 0; j < simpleProto.Ks.Count - 1; j++)
				{
					IFreeComponent component = FreeUIUtil.GetInstance().GetComponent(simpleProto.Ks[j + 1]);
					component.InitialFreeComponent(j, simpleProto, this, _deltaY * (float)i, isWorld: false);
					if (simpleFreeUI != null)
					{
						component.FreeUi = simpleFreeUI;
					}
					_allTextList.Add(component);
					list.Add(component);
					UnityObject.AddChild(component.ToUI());
				}
				llist.Add(list);
			}
		}
	}

	public override void SetPos(IComponentGroup freeUI, float x, float y, int width, int height, int relative, int parent, bool isInWorld = true)
	{
		base.SetPos(freeUI, x, y, width, height, relative, parent);
		_width = width;
		_height = height;
	}

	public override IFreeComponent Clone()
	{
		return new FreeListComponent();
	}

	public IFreeComponent GetComponent(int index)
	{
		if (index < _allTextList.Count)
		{
			return _allTextList[index];
		}
		return null;
	}
}
