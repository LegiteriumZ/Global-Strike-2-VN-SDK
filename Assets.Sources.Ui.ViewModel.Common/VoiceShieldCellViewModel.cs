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
public class VoiceShieldCellViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oVoiceShieldCell;

	private Toggle _oVoiceShieldCellToggle;

	private GameObject _oNameLabel1;

	private Text _oNameLabelText1;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "VoiceShieldCell";

	public GameObject VoiceShieldCellObj => _oVoiceShieldCell;

	public bool VoiceShieldCellShow
	{
		get
		{
			if (_oVoiceShieldCell != null)
			{
				return _oVoiceShieldCell.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VoiceShieldCellShow != value && _oVoiceShieldCell != null)
			{
				_oVoiceShieldCell.SetObjectActive(value);
			}
		}
	}

	public bool VoiceShieldCellOn
	{
		get
		{
			if (_oVoiceShieldCellToggle != null)
			{
				return _oVoiceShieldCellToggle.isOn;
			}
			return false;
		}
		set
		{
			if (VoiceShieldCellOn != value && _oVoiceShieldCellToggle != null)
			{
				_oVoiceShieldCellToggle.isOn = value;
			}
		}
	}

	public string NameLabelString1
	{
		get
		{
			if (_oNameLabelText1 != null)
			{
				return _oNameLabelText1.text;
			}
			return null;
		}
		set
		{
			if (NameLabelString1 != value && _oNameLabelText1 != null)
			{
				_oNameLabelText1.text = value;
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
			string text = transform.name.Replace("(Clone)", "");
			if (!(text == "VoiceShieldCell"))
			{
				if (text == "NameLabel1")
				{
					_oNameLabel1 = transform.gameObject;
					_oNameLabelText1 = transform.gameObject.GetComponent<Text>();
				}
			}
			else
			{
				_oVoiceShieldCell = transform.gameObject;
				_oVoiceShieldCellToggle = transform.gameObject.GetComponent<Toggle>();
			}
		}
	}

	public string GetNameLabelString(int index)
	{
		if (index == 1)
		{
			return NameLabelString1;
		}
		return null;
	}

	public void SetNameLabelString(int index, string value)
	{
		if (index == 1)
		{
			NameLabelString1 = value;
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
