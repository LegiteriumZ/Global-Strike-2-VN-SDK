using System.Collections.Generic;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgPopMsgViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRpgPopMsg;

	private GameObject _otipsmsg;

	private Text _otipsmsgText;

	private GameObject _ocell;

	private GameObject _oTipmsg;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	public const string cellName = "cell";

	public const string TipmsgName = "Tipmsg";

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgPopMsg";

	public UiReferences UI => uiRef;

	public bool RpgPopMsgShow
	{
		get
		{
			if (_oRpgPopMsg != null)
			{
				return _oRpgPopMsg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RpgPopMsgShow != value && _oRpgPopMsg != null)
			{
				_oRpgPopMsg.SetObjectActive(value);
			}
		}
	}

	public bool tipsmsgShow
	{
		get
		{
			if (_otipsmsg != null)
			{
				return _otipsmsg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (tipsmsgShow != value && _otipsmsg != null)
			{
				_otipsmsg.SetObjectActive(value);
			}
		}
	}

	public string tipsmsgString
	{
		get
		{
			if (_otipsmsgText != null)
			{
				return _otipsmsgText.text;
			}
			return null;
		}
		set
		{
			if (tipsmsgString != value && _otipsmsgText != null)
			{
				_otipsmsgText.text = value;
			}
		}
	}

	public Color tipsmsgTextcolor
	{
		get
		{
			if (_otipsmsgText != null)
			{
				return _otipsmsgText.color;
			}
			return Color.white;
		}
		set
		{
			if (tipsmsgTextcolor != value && _otipsmsgText != null)
			{
				_otipsmsgText.color = value;
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
		uiRef = instance.TryAddComponent<UiReferences>();
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.name.Replace("(Clone)", ""))
			{
			case "RpgPopMsg":
				_oRpgPopMsg = transform.gameObject;
				uiRef.Set("RpgPopMsg", _oRpgPopMsg.transform);
				break;
			case "tipsmsg":
				_otipsmsg = transform.gameObject;
				uiRef.Set("tipsmsg", _otipsmsg.transform);
				_otipsmsgText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("tipsmsgText", _otipsmsgText);
				break;
			case "cell":
				_ocell = transform.gameObject;
				uiRef.Set("cell", _ocell.transform);
				break;
			case "Tipmsg":
				_oTipmsg = transform.gameObject;
				uiRef.Set("Tipmsg", _oTipmsg.transform);
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
