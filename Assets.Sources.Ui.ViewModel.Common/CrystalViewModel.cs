using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class CrystalViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCrystalBack;

	private GameObject _oFirstDrop;

	private GameObject _oNormalDrop;

	private GameObject _oCrystalNum;

	private Text _oCrystalNumText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Crystal";

	public GameObject ViewGameObject => _viewGameObject;

	public bool ViewGameObjectShow
	{
		get
		{
			if (_viewGameObject != null)
			{
				return _viewGameObject.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ViewGameObjectShow != value && _viewGameObject != null)
			{
				_viewGameObject.SetObjectActive(value);
			}
		}
	}

	public bool CrystalBackShow
	{
		get
		{
			if (_oCrystalBack != null)
			{
				return _oCrystalBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CrystalBackShow != value && _oCrystalBack != null)
			{
				_oCrystalBack.SetObjectActive(value);
			}
		}
	}

	public bool FirstDropShow
	{
		get
		{
			if (_oFirstDrop != null)
			{
				return _oFirstDrop.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (FirstDropShow != value && _oFirstDrop != null)
			{
				_oFirstDrop.SetObjectActive(value);
			}
		}
	}

	public bool NormalDropShow
	{
		get
		{
			if (_oNormalDrop != null)
			{
				return _oNormalDrop.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NormalDropShow != value && _oNormalDrop != null)
			{
				_oNormalDrop.SetObjectActive(value);
			}
		}
	}

	public string CrystalNumString
	{
		get
		{
			if (_oCrystalNumText != null)
			{
				return _oCrystalNumText.text;
			}
			return null;
		}
		set
		{
			if (CrystalNumString != value && _oCrystalNumText != null)
			{
				_oCrystalNumText.text = value;
			}
		}
	}

	public string ResourceBundleName
	{
		get
		{
			return _resourceBundleName;
		}
		set
		{
			_resourceBundleName = value;
		}
	}

	public string ResourceAssetName
	{
		get
		{
			return _resourceAssetName;
		}
		set
		{
			_resourceAssetName = value;
		}
	}

	public string ConfigBundleName => "";

	public string ConfigAssetName => "";

	public bool IsInited => _viewGameObject != null;

	public void CreateBinding(GameObject instance)
	{
		_viewGameObject = instance;
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.name.Replace("(Clone)", ""))
			{
			case "CrystalBack":
				_oCrystalBack = transform.gameObject;
				break;
			case "FirstDrop":
				_oFirstDrop = transform.gameObject;
				break;
			case "NormalDrop":
				_oNormalDrop = transform.gameObject;
				break;
			case "CrystalNum":
				_oCrystalNum = transform.gameObject;
				_oCrystalNumText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool IsPropertyExist(string name)
	{
		return true;
	}

	public Transform GetParentLinkNode()
	{
		return null;
	}

	public Transform GetChildLinkNode()
	{
		return null;
	}

	public void Destory()
	{
		if (_viewGameObject != null)
		{
			Object.Destroy(_viewGameObject);
		}
	}

	public void Visible(bool isVisible)
	{
		if (_viewGameObject != null)
		{
			_viewGameObject.SetObjectActive(isVisible);
		}
	}

	public EventTrigger.Entry CreateTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		EventTrigger.Entry entry = new EventTrigger.Entry
		{
			callback = new EventTrigger.TriggerEvent(),
			eventID = eventId
		};
		entry.callback.AddListener(callback);
		triggers?.Add(entry);
		return entry;
	}

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
