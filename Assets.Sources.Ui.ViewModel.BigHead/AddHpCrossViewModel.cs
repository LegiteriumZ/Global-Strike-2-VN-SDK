using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.BigHead;

[GameUiTest]
public class AddHpCrossViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private RectTransform _oShowRectTransform;

	private GameObject _oSpecial;

	private Image _oSpecialImage;

	private GameObject _viewGameObject;

	private bool _ShowHere = true;

	private string _resourceBundleName = "uiprefabs/bighead";

	private string _resourceAssetName = "AddHpCross";

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

	public bool ShowHere
	{
		get
		{
			return _ShowHere;
		}
		set
		{
			if (ShowHere != value && _oShowRectTransform != null)
			{
				_ShowHere = value;
				if (value)
				{
					_oShowRectTransform.localPosition -= new Vector3(10000f, 10000f, 0f);
				}
				else
				{
					_oShowRectTransform.localPosition += new Vector3(10000f, 10000f, 0f);
				}
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

	public Color SpecialColor
	{
		get
		{
			if (_oSpecialImage != null)
			{
				return _oSpecialImage.color;
			}
			return Color.white;
		}
		set
		{
			if (SpecialColor != value && _oSpecialImage != null)
			{
				_oSpecialImage.color = value;
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
			if (!(text == "Show"))
			{
				if (text == "Special")
				{
					_oSpecial = transform.gameObject;
					_oSpecialImage = transform.gameObject.GetComponent<Image>();
				}
			}
			else
			{
				_oShow = transform.gameObject;
				_oShowRectTransform = transform.gameObject.GetComponent<RectTransform>();
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
