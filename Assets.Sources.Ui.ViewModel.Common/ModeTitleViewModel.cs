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
public class ModeTitleViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oTop;

	private CanvasGroup _oTopCanvasGroup;

	private GameObject _oTitleImage;

	private Image _oTitleImageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "ModeTitle";

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

	public float TopAlpha
	{
		get
		{
			if (_oTopCanvasGroup != null)
			{
				return _oTopCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (TopAlpha != value && _oTopCanvasGroup != null)
			{
				_oTopCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite TitleImageSprite
	{
		get
		{
			if (_oTitleImageImage != null)
			{
				return _oTitleImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (TitleImageSprite != value && _oTitleImageImage != null)
			{
				_oTitleImageImage.sprite = value;
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
			case "Top":
				_oTop = transform.gameObject;
				_oTopCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "TitleImage":
				_oTitleImage = transform.gameObject;
				_oTitleImageImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void TitleImageNtvsize()
	{
		if (_oTitleImageImage != null)
		{
			_oTitleImageImage.SetNativeSize();
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
