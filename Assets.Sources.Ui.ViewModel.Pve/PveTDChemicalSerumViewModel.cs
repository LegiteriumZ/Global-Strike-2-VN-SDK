using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class PveTDChemicalSerumViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _opveTDChemicalSerum;

	private GameObject _oback;

	private GameObject _oclip;

	private GameObject _oarmorbodyBack;

	private GameObject _oarmorbody;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "PveTDChemicalSerum";

	public bool pveTDChemicalSerumShow
	{
		get
		{
			if (_opveTDChemicalSerum != null)
			{
				return _opveTDChemicalSerum.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pveTDChemicalSerumShow != value && _opveTDChemicalSerum != null)
			{
				_opveTDChemicalSerum.SetObjectActive(value);
			}
		}
	}

	public bool backShow
	{
		get
		{
			if (_oback != null)
			{
				return _oback.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (backShow != value && _oback != null)
			{
				_oback.SetObjectActive(value);
			}
		}
	}

	public bool clipShow
	{
		get
		{
			if (_oclip != null)
			{
				return _oclip.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (clipShow != value && _oclip != null)
			{
				_oclip.SetObjectActive(value);
			}
		}
	}

	public bool armorbodyBackShow
	{
		get
		{
			if (_oarmorbodyBack != null)
			{
				return _oarmorbodyBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (armorbodyBackShow != value && _oarmorbodyBack != null)
			{
				_oarmorbodyBack.SetObjectActive(value);
			}
		}
	}

	public bool armorbodyShow
	{
		get
		{
			if (_oarmorbody != null)
			{
				return _oarmorbody.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (armorbodyShow != value && _oarmorbody != null)
			{
				_oarmorbody.SetObjectActive(value);
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
			case "pveTDChemicalSerum":
				_opveTDChemicalSerum = transform.gameObject;
				break;
			case "back":
				_oback = transform.gameObject;
				break;
			case "clip":
				_oclip = transform.gameObject;
				break;
			case "armorbodyBack":
				_oarmorbodyBack = transform.gameObject;
				break;
			case "armorbody":
				_oarmorbody = transform.gameObject;
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
