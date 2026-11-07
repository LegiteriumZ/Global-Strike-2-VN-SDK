using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgAngerFireScarViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oImage1;

	private GameObject _oImage2;

	private RectTransform _oImageRectTransform1;

	private RectTransform _oImageRectTransform2;

	private Image _oImageImage1;

	private Image _oImageImage2;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgAngerFireScar";

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

	public Vector3 ImageSize1
	{
		get
		{
			if (_oImageRectTransform1 != null)
			{
				return _oImageRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (ImageSize1 != value && _oImageRectTransform1 != null)
			{
				_oImageRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 ImageSize2
	{
		get
		{
			if (_oImageRectTransform2 != null)
			{
				return _oImageRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (ImageSize2 != value && _oImageRectTransform2 != null)
			{
				_oImageRectTransform2.sizeDelta = value;
			}
		}
	}

	public Rect ImageRect1
	{
		get
		{
			if (_oImageRectTransform1 != null)
			{
				return _oImageRectTransform1.rect;
			}
			return Rect.zero;
		}
	}

	public Rect ImageRect2
	{
		get
		{
			if (_oImageRectTransform2 != null)
			{
				return _oImageRectTransform2.rect;
			}
			return Rect.zero;
		}
	}

	public Sprite ImageSprite1
	{
		get
		{
			if (_oImageImage1 != null)
			{
				return _oImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite1 != value && _oImageImage1 != null)
			{
				_oImageImage1.sprite = value;
			}
		}
	}

	public Sprite ImageSprite2
	{
		get
		{
			if (_oImageImage2 != null)
			{
				return _oImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite2 != value && _oImageImage2 != null)
			{
				_oImageImage2.sprite = value;
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
			case "Image1":
				_oImage1 = transform.gameObject;
				_oImageRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image2":
				_oImage2 = transform.gameObject;
				_oImageRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public Vector3 GetImageSize(int index)
	{
		return index switch
		{
			1 => ImageSize1, 
			2 => ImageSize2, 
			_ => Vector3.zero, 
		};
	}

	public void SetImageSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			ImageSize1 = value;
			break;
		case 2:
			ImageSize2 = value;
			break;
		}
	}

	public Rect GetImageRect(int index)
	{
		return index switch
		{
			1 => ImageRect1, 
			2 => ImageRect2, 
			_ => Rect.zero, 
		};
	}

	public Sprite GetImageSprite(int index)
	{
		return index switch
		{
			1 => ImageSprite1, 
			2 => ImageSprite2, 
			_ => null, 
		};
	}

	public void SetImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			ImageSprite1 = value;
			break;
		case 2:
			ImageSprite2 = value;
			break;
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
