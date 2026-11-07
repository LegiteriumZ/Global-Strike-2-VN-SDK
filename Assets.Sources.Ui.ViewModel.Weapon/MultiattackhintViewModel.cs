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
public class MultiattackhintViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _ocenter;

	private GameObject _oclickLeft;

	private Image _oclickLeftImage;

	private GameObject _oclickRight;

	private Image _oclickRightImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "Multiattackhint";

	public bool centerShow
	{
		get
		{
			if (_ocenter != null)
			{
				return _ocenter.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (centerShow != value && _ocenter != null)
			{
				_ocenter.SetObjectActive(value);
			}
		}
	}

	public bool clickLeftShow
	{
		get
		{
			if (_oclickLeft != null)
			{
				return _oclickLeft.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (clickLeftShow != value && _oclickLeft != null)
			{
				_oclickLeft.SetObjectActive(value);
			}
		}
	}

	public Sprite clickLeftSprite
	{
		get
		{
			if (_oclickLeftImage != null)
			{
				return _oclickLeftImage.sprite;
			}
			return null;
		}
		set
		{
			if (clickLeftSprite != value && _oclickLeftImage != null)
			{
				_oclickLeftImage.sprite = value;
			}
		}
	}

	public bool clickRightShow
	{
		get
		{
			if (_oclickRight != null)
			{
				return _oclickRight.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (clickRightShow != value && _oclickRight != null)
			{
				_oclickRight.SetObjectActive(value);
			}
		}
	}

	public Sprite clickRightSprite
	{
		get
		{
			if (_oclickRightImage != null)
			{
				return _oclickRightImage.sprite;
			}
			return null;
		}
		set
		{
			if (clickRightSprite != value && _oclickRightImage != null)
			{
				_oclickRightImage.sprite = value;
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
			case "center":
				_ocenter = transform.gameObject;
				break;
			case "clickLeft":
				_oclickLeft = transform.gameObject;
				_oclickLeftImage = transform.gameObject.GetComponent<Image>();
				break;
			case "clickRight":
				_oclickRight = transform.gameObject;
				_oclickRightImage = transform.gameObject.GetComponent<Image>();
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
