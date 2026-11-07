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
public class AwmStrikeCrossViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oAwp;

	private Image _oAwpImage;

	private GameObject _oSpecial;

	private Image _oSpecialImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "AwmStrikeCross";

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

	public bool AwpShow
	{
		get
		{
			if (_oAwp != null)
			{
				return _oAwp.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AwpShow != value && _oAwp != null)
			{
				_oAwp.SetObjectActive(value);
			}
		}
	}

	public Sprite AwpSprite
	{
		get
		{
			if (_oAwpImage != null)
			{
				return _oAwpImage.sprite;
			}
			return null;
		}
		set
		{
			if (AwpSprite != value && _oAwpImage != null)
			{
				_oAwpImage.sprite = value;
			}
		}
	}

	public bool SpecialShow
	{
		get
		{
			if (_oSpecial != null)
			{
				return _oSpecial.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SpecialShow != value && _oSpecial != null)
			{
				_oSpecial.SetObjectActive(value);
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
			case "Awp":
				_oAwp = transform.gameObject;
				_oAwpImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Special":
				_oSpecial = transform.gameObject;
				_oSpecialImage = transform.gameObject.GetComponent<Image>();
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
