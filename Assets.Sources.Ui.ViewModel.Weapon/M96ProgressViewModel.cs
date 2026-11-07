using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class M96ProgressViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oCapacityBack;

	private Image _oCapacityBackImage;

	private GameObject _oCapacityBar;

	private RectTransform _oCapacityBarRectTransform;

	private Image _oCapacityBarImage;

	private GameObject _viewGameObject;

	private bool _CapacityBarHere = true;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "M96Progress";

	public bool ShowShow
	{
		get
		{
			if (_oShow != null)
			{
				return _oShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowShow != value && _oShow != null)
			{
				_oShow.SetObjectActive(value);
			}
		}
	}

	public Sprite CapacityBackSprite
	{
		get
		{
			if (_oCapacityBackImage != null)
			{
				return _oCapacityBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (CapacityBackSprite != value && _oCapacityBackImage != null)
			{
				_oCapacityBackImage.sprite = value;
			}
		}
	}

	public bool CapacityBarHere
	{
		get
		{
			return _CapacityBarHere;
		}
		set
		{
			if (CapacityBarHere != value && _oCapacityBarRectTransform != null)
			{
				_CapacityBarHere = value;
				if (value)
				{
					_oCapacityBarRectTransform.localPosition -= new Vector3(10000f, 10000f, 0f);
				}
				else
				{
					_oCapacityBarRectTransform.localPosition += new Vector3(10000f, 10000f, 0f);
				}
			}
		}
	}

	public Sprite CapacityBarSprite
	{
		get
		{
			if (_oCapacityBarImage != null)
			{
				return _oCapacityBarImage.sprite;
			}
			return null;
		}
		set
		{
			if (CapacityBarSprite != value && _oCapacityBarImage != null)
			{
				_oCapacityBarImage.sprite = value;
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
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "CapacityBack":
				_oCapacityBack = transform.gameObject;
				_oCapacityBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CapacityBar":
				_oCapacityBar = transform.gameObject;
				_oCapacityBarRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oCapacityBarImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void CapacityBackNtvsize()
	{
		if (_oCapacityBackImage != null)
		{
			_oCapacityBackImage.SetNativeSize();
		}
	}

	public void CapacityBarNtvsize()
	{
		if (_oCapacityBarImage != null)
		{
			_oCapacityBarImage.SetNativeSize();
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
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
}
