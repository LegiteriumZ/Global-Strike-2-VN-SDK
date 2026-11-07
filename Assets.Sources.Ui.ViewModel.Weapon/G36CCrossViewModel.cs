using System.Collections.Generic;
using Assets.Scripts.ResScripts.Refrenceless.DyVersion;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class G36CCrossViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oSpecial;

	private Image _oSpecialImage;

	private GameObject _oSpecialCenter;

	private RectTransform _oSpecialCenterRectTransform;

	private Image _oSpecialCenterImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "G36CCross";

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

	public bool SpecialEnabled
	{
		get
		{
			if (_oSpecialImage != null)
			{
				return _oSpecialImage.enabled;
			}
			return false;
		}
		set
		{
			if (SpecialEnabled != value && _oSpecialImage != null)
			{
				_oSpecialImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public Sprite SpecialSprite
	{
		get
		{
			if (_oSpecialImage != null)
			{
				return _oSpecialImage.sprite;
			}
			return null;
		}
		set
		{
			if (SpecialSprite != value && _oSpecialImage != null)
			{
				_oSpecialImage.sprite = value;
			}
		}
	}

	public bool SpecialCenterShow
	{
		get
		{
			if (_oSpecialCenter != null)
			{
				return _oSpecialCenter.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SpecialCenterShow != value && _oSpecialCenter != null)
			{
				_oSpecialCenter.SetObjectActive(value);
			}
		}
	}

	public Vector3 SpecialCenterScale
	{
		get
		{
			if (_oSpecialCenterRectTransform != null)
			{
				return _oSpecialCenterRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (SpecialCenterScale != value && _oSpecialCenterRectTransform != null)
			{
				_oSpecialCenterRectTransform.localScale = value;
			}
		}
	}

	public Sprite SpecialCenterSprite
	{
		get
		{
			if (_oSpecialCenterImage != null)
			{
				return _oSpecialCenterImage.sprite;
			}
			return null;
		}
		set
		{
			if (SpecialCenterSprite != value && _oSpecialCenterImage != null)
			{
				_oSpecialCenterImage.sprite = value;
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
			case "Special":
				_oSpecial = transform.gameObject;
				_oSpecialImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SpecialCenter":
				_oSpecialCenter = transform.gameObject;
				_oSpecialCenterRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oSpecialCenterImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void SpecialNtvsize()
	{
		if (_oSpecialImage != null)
		{
			_oSpecialImage.SetNativeSize();
		}
	}

	public void SpecialCenterNtvsize()
	{
		if (_oSpecialCenterImage != null)
		{
			_oSpecialCenterImage.SetNativeSize();
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
