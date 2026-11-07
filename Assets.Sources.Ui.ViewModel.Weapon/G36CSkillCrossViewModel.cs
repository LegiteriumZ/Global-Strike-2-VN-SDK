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
public class G36CSkillCrossViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oSpecial;

	private RectTransform _oSpecialRectTransform;

	private Image _oSpecialImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "G36CSkillCross";

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

	public Vector3 SpecialSize
	{
		get
		{
			if (_oSpecialRectTransform != null)
			{
				return _oSpecialRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (SpecialSize != value && _oSpecialRectTransform != null)
			{
				_oSpecialRectTransform.sizeDelta = value;
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
			string text = transform.name.Replace("(Clone)", "");
			if (!(text == "Show"))
			{
				if (text == "Special")
				{
					_oSpecial = transform.gameObject;
					_oSpecialRectTransform = transform.gameObject.GetComponent<RectTransform>();
					_oSpecialImage = transform.gameObject.GetComponent<Image>();
				}
			}
			else
			{
				_oShow = transform.gameObject;
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
