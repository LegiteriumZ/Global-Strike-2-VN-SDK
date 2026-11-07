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

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class Td5maskViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _otd5mask;

	private GameObject _omaskImg;

	private RectTransform _omaskImgRectTransform;

	private Image _omaskImgImage;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "Td5mask";

	public UiReferences UI => uiRef;

	public GameObject td5maskObj => _otd5mask;

	public bool td5maskShow
	{
		get
		{
			if (_otd5mask != null)
			{
				return _otd5mask.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (td5maskShow != value && _otd5mask != null)
			{
				_otd5mask.SetObjectActive(value);
			}
		}
	}

	public bool maskImgShow
	{
		get
		{
			if (_omaskImg != null)
			{
				return _omaskImg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (maskImgShow != value && _omaskImg != null)
			{
				_omaskImg.SetObjectActive(value);
			}
		}
	}

	public Vector2 maskImgAnchoredposition
	{
		get
		{
			if (_omaskImgRectTransform != null)
			{
				return _omaskImgRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (maskImgAnchoredposition != value && _omaskImgRectTransform != null)
			{
				_omaskImgRectTransform.anchoredPosition = value;
			}
		}
	}

	public Sprite maskImgSprite
	{
		get
		{
			if (_omaskImgImage != null)
			{
				return _omaskImgImage.sprite;
			}
			return null;
		}
		set
		{
			if (maskImgSprite != value && _omaskImgImage != null)
			{
				_omaskImgImage.sprite = value;
			}
		}
	}

	public Color maskImgColor
	{
		get
		{
			if (_omaskImgImage != null)
			{
				return _omaskImgImage.color;
			}
			return Color.white;
		}
		set
		{
			if (maskImgColor != value && _omaskImgImage != null)
			{
				_omaskImgImage.color = value;
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
			string text = transform.name.Replace("(Clone)", "");
			if (!(text == "td5mask"))
			{
				if (text == "maskImg")
				{
					_omaskImg = transform.gameObject;
					uiRef.Set("maskImg", _omaskImg.transform);
					_omaskImgRectTransform = transform.gameObject.GetComponent<RectTransform>();
					uiRef.Set("maskImgRectTransform", _omaskImgRectTransform);
					_omaskImgImage = transform.gameObject.GetComponent<Image>();
					uiRef.Set("maskImgImage", _omaskImgImage);
				}
			}
			else
			{
				_otd5mask = transform.gameObject;
				uiRef.Set("td5mask", _otd5mask.transform);
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
