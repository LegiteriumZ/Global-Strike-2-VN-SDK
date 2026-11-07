using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Biochemical2;

[GameUiTest]
public class Biochemical2SkillMessageViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oBack;

	private Image _oBackImage;

	private GameObject _oEvent;

	private Image _oEventImage;

	private GameObject _oSkillName;

	private Image _oSkillNameImage;

	private GameObject _oLeft;

	private CanvasGroup _oLeftCanvasGroup;

	private GameObject _oRight;

	private CanvasGroup _oRightCanvasGroup;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/biochemical2";

	private string _resourceAssetName = "Biochemical2SkillMessage";

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

	public Sprite BackSprite
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite != value && _oBackImage != null)
			{
				_oBackImage.sprite = value;
			}
		}
	}

	public Sprite EventSprite
	{
		get
		{
			if (_oEventImage != null)
			{
				return _oEventImage.sprite;
			}
			return null;
		}
		set
		{
			if (EventSprite != value && _oEventImage != null)
			{
				_oEventImage.sprite = value;
			}
		}
	}

	public Sprite SkillNameSprite
	{
		get
		{
			if (_oSkillNameImage != null)
			{
				return _oSkillNameImage.sprite;
			}
			return null;
		}
		set
		{
			if (SkillNameSprite != value && _oSkillNameImage != null)
			{
				_oSkillNameImage.sprite = value;
			}
		}
	}

	public float LeftAlpha
	{
		get
		{
			if (_oLeftCanvasGroup != null)
			{
				return _oLeftCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (LeftAlpha != value && _oLeftCanvasGroup != null)
			{
				_oLeftCanvasGroup.alpha = value;
			}
		}
	}

	public float RightAlpha
	{
		get
		{
			if (_oRightCanvasGroup != null)
			{
				return _oRightCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (RightAlpha != value && _oRightCanvasGroup != null)
			{
				_oRightCanvasGroup.alpha = value;
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
			case "Back":
				_oBack = transform.gameObject;
				_oBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Event":
				_oEvent = transform.gameObject;
				_oEventImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillName":
				_oSkillName = transform.gameObject;
				_oSkillNameImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Left":
				_oLeft = transform.gameObject;
				_oLeftCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "Right":
				_oRight = transform.gameObject;
				_oRightCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
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
