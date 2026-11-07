using System.Collections.Generic;
using System.Text;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using NetData;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase_Library.String;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class FreeCheckBoxComponent : FreeBaseComponent
{
	private int _maxSelectedNum = 1;

	private int _maxButtonNum = 1;

	private readonly List<int> _selectedIndex = new List<int>();

	private readonly List<IFreeComponent> _buttonlist = new List<IFreeComponent>();

	public FreeCheckBoxComponent()
	{
		base.Type = 10;
		base.ValueType = 2;
		GameObject engineObj = new GameObject("FreeCheckBox", typeof(RectTransform));
		UnityObject = new UnityUiObject(engineObj);
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	public List<IFreeComponent> GetButtonList()
	{
		return _buttonlist;
	}

	public override void Initial(params object[] ini)
	{
		if (ini[0] is string)
		{
			InitCheckBox(ini[0] as string);
		}
		else if (ini[0] is SimpleProto)
		{
			InitButtons(ini[0] as SimpleProto);
		}
	}

	public override bool ShowMouse()
	{
		return false;
	}

	private void InitCheckBox(string str)
	{
		string[] array = str.Split("_$$$_");
		if (array.Length != 0)
		{
			if (!FreeBaseComponent.IsNullString(array[0]))
			{
				int.TryParse(array[0], out _maxSelectedNum);
			}
			if (array.Length > 1)
			{
				UpdateSelect(array[1]);
			}
		}
	}

	private void UpdateSelect(string str)
	{
		if (FreeBaseComponent.IsNullString(str))
		{
			return;
		}
		string[] array = str.Split(",");
		int num = Mathf.Min(array.Length, _maxSelectedNum);
		for (int i = 0; i < num; i++)
		{
			int result = 0;
			if (int.TryParse(array[i], out result))
			{
				if (!_selectedIndex.Contains(result))
				{
					_selectedIndex.Add(result);
				}
				if (_buttonlist.Count > 0 && _buttonlist.Count > result - 1 && _buttonlist[result - 1] is FreeButtonComponent freeButtonComponent)
				{
					freeButtonComponent.GetButton().Select = true;
				}
			}
		}
	}

	private void InitButtons(SimpleProto simpleProto)
	{
		SimpleFreeUI simpleFreeUI = Group as SimpleFreeUI;
		for (int i = 0; i < simpleProto.Ks.Count - 1; i++)
		{
			IFreeComponent component = FreeUIUtil.GetInstance().GetComponent(simpleProto.Ks[i + 1]);
			component.InitialFreeComponent(i, simpleProto, Group);
			if (simpleFreeUI != null)
			{
				simpleFreeUI.SetChild(component);
				simpleFreeUI.AddComponent(component);
			}
			_buttonlist.Add(component);
			component.AddKeyBoardResponder();
		}
		foreach (int item in _selectedIndex)
		{
			IFreeComponent freeComponent = _buttonlist[item - 1];
			if (freeComponent is FreeButtonComponent)
			{
				(freeComponent as FreeButtonComponent).GetButton().Select = true;
			}
			else
			{
				FreeBaseComponent.Logger.ErrorFormat("{0} type error cant support select property", freeComponent);
			}
		}
		_maxButtonNum = simpleProto.Ks.Count - 1;
	}

	public override void SetValue(SetValueAdapter.SetValueData setValueDataA, SetValueAdapter.SetValueData setValueDataB)
	{
		if (setValueDataB != null)
		{
			UpdateSelect(setValueDataB.ToString());
		}
	}

	public override void SetPos(IComponentGroup freeUI, float x, float y, int width, int height, int relative, int parent, bool isInWorld = true)
	{
		DataElement.Relative = relative;
		DataElement.Parent = parent;
		Group = freeUI;
		DataElement.X = x;
		DataElement.Y = y;
	}

	public override void Frame(IUIDataManager uiDataManager, int frammeTime, IComponentGroup gGroup)
	{
		base.Frame(uiDataManager, frammeTime, gGroup);
		ChangeButtonStatus();
	}

	private void ChangeButtonStatus()
	{
		bool flag = false;
		for (int i = 0; i < _maxButtonNum; i++)
		{
			if (_buttonlist[i] is FreeButtonComponent freeButtonComponent)
			{
				if (freeButtonComponent.GetButton().Interactable && freeButtonComponent.GetButton().Select && !_selectedIndex.Contains(i + 1))
				{
					_selectedIndex.Add(i + 1);
					flag = true;
				}
				if ((!freeButtonComponent.GetButton().Interactable || (freeButtonComponent.GetButton().Interactable && !freeButtonComponent.GetButton().Select)) && _selectedIndex.Remove(i + 1))
				{
					flag = true;
				}
			}
			else
			{
				FreeBaseComponent.Logger.ErrorFormat("type error :{0}", _buttonlist[i]);
			}
		}
		int count = _selectedIndex.Count;
		for (int j = 0; j < count - _maxSelectedNum; j++)
		{
			int num = _selectedIndex[0];
			_selectedIndex.RemoveAt(0);
			if (num - 1 < _buttonlist.Count && num - 1 >= 0)
			{
				if (_buttonlist[num - 1] is FreeButtonComponent freeButtonComponent2)
				{
					freeButtonComponent2.GetButton().Select = false;
				}
				else
				{
					FreeBaseComponent.Logger.ErrorFormat("type error :{0}", _buttonlist[num - 1]);
				}
			}
		}
		if (!flag)
		{
			return;
		}
		string text = null;
		if (_selectedIndex.Count > 0)
		{
			StringBuilder stringBuilder = StringBuilderCache.Get();
			for (int k = 0; k < _selectedIndex.Count; k++)
			{
				if (k != _selectedIndex.Count - 1)
				{
					stringBuilder.Append(StringCache.IntToString(_selectedIndex[k]));
					stringBuilder.Append(",");
				}
				else
				{
					stringBuilder.Append(StringCache.IntToString(_selectedIndex[k]));
				}
			}
			text = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
		}
		else
		{
			text = "null";
		}
		FreeEvent.Event = 6;
		FreeEvent.Key.Key = FreeEvent.Event;
		FreeEvent.Key.Ss.Add(base.EventKey);
		FreeEvent.Key.ComponentName.Add(text);
	}

	public override IFreeComponent Clone()
	{
		return new FreeCheckBoxComponent();
	}
}
