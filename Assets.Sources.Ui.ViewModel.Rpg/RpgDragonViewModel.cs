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
public class RpgDragonViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCenter;

	private GameObject _oBack;

	private RectTransform _oBackRectTransform;

	private GameObject _oLeft;

	private RectTransform _oLeftRectTransform;

	private GameObject _oRight;

	private RectTransform _oRightRectTransform;

	private GameObject _oMessage;

	private Image _oMessageImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "rpgdragon";

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

	public GameObject CenterObj => _oCenter;

	public bool CenterShow
	{
		get
		{
			if (_oCenter != null)
			{
				return _oCenter.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow != value && _oCenter != null)
			{
				_oCenter.SetObjectActive(value);
			}
		}
	}

	public bool BackRootshow
	{
		get
		{
			if (_oBack != null)
			{
				return _oBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackRootshow == value || !(_oBack != null))
			{
				return;
			}
			if (value)
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oBack.SetObjectActive(!value);
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.Register(_resourceAssetName, delegate
				{
					_oBack.SetObjectActive(value);
				});
			}
			else
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oBack.SetObjectActive(value);
			}
		}
	}

	public Vector3 BackSize
	{
		get
		{
			if (_oBackRectTransform != null)
			{
				return _oBackRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (BackSize != value && _oBackRectTransform != null)
			{
				_oBackRectTransform.sizeDelta = value;
			}
		}
	}

	public Vector3 LeftPosition
	{
		get
		{
			if (_oLeftRectTransform != null)
			{
				return _oLeftRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LeftPosition != value && _oLeftRectTransform != null)
			{
				_oLeftRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 LeftSize
	{
		get
		{
			if (_oLeftRectTransform != null)
			{
				return _oLeftRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (LeftSize != value && _oLeftRectTransform != null)
			{
				_oLeftRectTransform.sizeDelta = value;
			}
		}
	}

	public Vector3 RightPosition
	{
		get
		{
			if (_oRightRectTransform != null)
			{
				return _oRightRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightPosition != value && _oRightRectTransform != null)
			{
				_oRightRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 RightSize
	{
		get
		{
			if (_oRightRectTransform != null)
			{
				return _oRightRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightSize != value && _oRightRectTransform != null)
			{
				_oRightRectTransform.sizeDelta = value;
			}
		}
	}

	public bool MessageShow
	{
		get
		{
			if (_oMessage != null)
			{
				return _oMessage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MessageShow != value && _oMessage != null)
			{
				_oMessage.SetObjectActive(value);
			}
		}
	}

	public Sprite MessageSprite
	{
		get
		{
			if (_oMessageImage != null)
			{
				return _oMessageImage.sprite;
			}
			return null;
		}
		set
		{
			if (MessageSprite != value && _oMessageImage != null)
			{
				_oMessageImage.sprite = value;
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
			case "Center":
				_oCenter = transform.gameObject;
				break;
			case "Back":
				_oBack = transform.gameObject;
				_oBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Left":
				_oLeft = transform.gameObject;
				_oLeftRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Right":
				_oRight = transform.gameObject;
				_oRightRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Message":
				_oMessage = transform.gameObject;
				_oMessageImage = transform.gameObject.GetComponent<Image>();
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

	public void MessageNtvsize()
	{
		if (_oMessageImage != null)
		{
			_oMessageImage.SetNativeSize();
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
