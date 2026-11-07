using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Sources.Ui.DynamicLoader;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgShieldRecoveryViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private CanvasGroup _oShowCanvasGroup;

	private GameObject _oRightImage;

	private RectTransform _oRightImageRectTransform;

	private GameObject _oLeftImage;

	private RectTransform _oLeftImageRectTransform;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "rpgshieldrecovery";

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

	public bool ShowRootshow
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
			if (ShowRootshow == value || !(_oShow != null))
			{
				return;
			}
			if (value)
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.Register(_resourceAssetName, delegate
				{
					_oShow.SetObjectActive(value);
				});
			}
			else
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oShow.SetObjectActive(value);
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

	public GameObject RightImageObj => _oRightImage;

	public Vector3 RightImageSize
	{
		get
		{
			if (_oRightImageRectTransform != null)
			{
				return _oRightImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightImageSize != value && _oRightImageRectTransform != null)
			{
				_oRightImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Rect RightImageRect
	{
		get
		{
			if (_oRightImageRectTransform != null)
			{
				return _oRightImageRectTransform.rect;
			}
			return Rect.zero;
		}
	}

	public Vector3 LeftImageSize
	{
		get
		{
			if (_oLeftImageRectTransform != null)
			{
				return _oLeftImageRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (LeftImageSize != value && _oLeftImageRectTransform != null)
			{
				_oLeftImageRectTransform.sizeDelta = value;
			}
		}
	}

	public Rect LeftImageRect
	{
		get
		{
			if (_oLeftImageRectTransform != null)
			{
				return _oLeftImageRectTransform.rect;
			}
			return Rect.zero;
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
				_oShowCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "RightImage":
				_oRightImage = transform.gameObject;
				_oRightImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "LeftImage":
				_oLeftImage = transform.gameObject;
				_oLeftImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			}
		}
		BattleSingletonInstance<UiDynamicLoadManager>.Instance.InitDynLoader(_resourceAssetName, instance.transform);
	}

	public void LoadRefrenceless(IUiResourcesLoader loader)
	{
		if (_refrencelessLoaded)
		{
			return;
		}
		_refrencelessLoaded = true;
		RefrencelessHelper component = _viewGameObject.GetComponent<RefrencelessHelper>();
		if (!(component != null))
		{
			return;
		}
		for (int i = 0; i < component.SpritePaths.Count; i++)
		{
			try
			{
				if (i < component.AutoLoad.Count && !component.AutoLoad[i])
				{
					continue;
				}
				string[] array = component.SpritePaths[i].Split(':');
				Image image = component.transform.Find(component.Images[i]).GetComponent<Image>();
				if (!string.IsNullOrEmpty(array[0]))
				{
					loader.RetriveSprite(array[0], array[1], delegate(Sprite sprite)
					{
						image.sprite = sprite;
					});
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
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
			UnityEngine.Object.Destroy(_viewGameObject);
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

	public void RemoveTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId)
	{
		foreach (EventTrigger.Entry trigger in triggers)
		{
			if (trigger.eventID == eventId)
			{
				triggers.Remove(trigger);
				break;
			}
		}
	}
}
