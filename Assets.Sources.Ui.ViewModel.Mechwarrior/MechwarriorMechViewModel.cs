using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Mechwarrior;

[GameUiTest]
public class MechwarriorMechViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oTop;

	private GameObject _oBackImage;

	private Image _oBackImageImage;

	private GameObject _oLvUpImage;

	private CanvasGroup _oLvUpImageCanvasGroup;

	private Image _oLvUpImageImage;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/mechwarrior";

	private string _resourceAssetName = "MechwarriorMech";

	public bool TopShow
	{
		get
		{
			if (_oTop != null)
			{
				return _oTop.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TopShow != value && _oTop != null)
			{
				_oTop.SetObjectActive(value);
			}
		}
	}

	public Sprite BackImageSprite
	{
		get
		{
			if (_oBackImageImage != null)
			{
				return _oBackImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackImageSprite != value && _oBackImageImage != null)
			{
				_oBackImageImage.sprite = value;
			}
		}
	}

	public float LvUpImageAlpha
	{
		get
		{
			if (_oLvUpImageCanvasGroup != null)
			{
				return _oLvUpImageCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (LvUpImageAlpha != value && _oLvUpImageCanvasGroup != null)
			{
				_oLvUpImageCanvasGroup.alpha = value;
			}
		}
	}

	public Sprite LvUpImageSprite
	{
		get
		{
			if (_oLvUpImageImage != null)
			{
				return _oLvUpImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (LvUpImageSprite != value && _oLvUpImageImage != null)
			{
				_oLvUpImageImage.sprite = value;
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
			case "Top":
				_oTop = transform.gameObject;
				break;
			case "BackImage":
				_oBackImage = transform.gameObject;
				_oBackImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "LvUpImage":
				_oLvUpImage = transform.gameObject;
				_oLvUpImageCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				_oLvUpImageImage = transform.gameObject.GetComponent<Image>();
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
