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
public class BeinghitViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private RectTransform _oShowRectTransform;

	private CanvasGroup _oShowCanvasGroup;

	private GameObject _oImage;

	private Image _oImageImage;

	private GameObject _oShieldIcon;

	private RectTransform _oShieldIconRectTransform;

	private Image _oShieldIconImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Beinghit";

	public Quaternion ShowRotation
	{
		get
		{
			if (_oShowRectTransform != null)
			{
				return _oShowRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (ShowRotation != value && _oShowRectTransform != null)
			{
				_oShowRectTransform.localRotation = value;
			}
		}
	}

	public float ShowAlpha
	{
		get
		{
			if (_oShowCanvasGroup != null)
			{
				return _oShowCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (ShowAlpha != value && _oShowCanvasGroup != null)
			{
				_oShowCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite ImageSprite
	{
		get
		{
			if (_oImageImage != null)
			{
				return _oImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite != value && _oImageImage != null)
			{
				_oImageImage.sprite = value;
			}
		}
	}

	public bool ShieldIconShow
	{
		get
		{
			if (_oShieldIcon != null)
			{
				return _oShieldIcon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShieldIconShow != value && _oShieldIcon != null)
			{
				_oShieldIcon.SetObjectActive(value);
			}
		}
	}

	public Quaternion ShieldIconRotation
	{
		get
		{
			if (_oShieldIconRectTransform != null)
			{
				return _oShieldIconRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (ShieldIconRotation != value && _oShieldIconRectTransform != null)
			{
				_oShieldIconRectTransform.localRotation = value;
			}
		}
	}

	public Sprite ShieldIconSprite
	{
		get
		{
			if (_oShieldIconImage != null)
			{
				return _oShieldIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (ShieldIconSprite != value && _oShieldIconImage != null)
			{
				_oShieldIconImage.sprite = value;
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
				_oShowRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oShowCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Image":
				_oImage = transform.gameObject;
				_oImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ShieldIcon":
				_oShieldIcon = transform.gameObject;
				_oShieldIconRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oShieldIconImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void ShieldIconNtvsize()
	{
		if (_oShieldIconImage != null)
		{
			_oShieldIconImage.SetNativeSize();
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
