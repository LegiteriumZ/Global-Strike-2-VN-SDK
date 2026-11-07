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
public class RpgShieldBrokenViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oMask;

	private Image _oMaskImage;

	private GameObject _oTopImage;

	private RectTransform _oTopImageRectTransform;

	private GameObject _oRightImage;

	private RectTransform _oRightImageRectTransform;

	private GameObject _oLeftImage;

	private RectTransform _oLeftImageRectTransform;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "rpgshieldbroken";

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

	public bool MaskRootshow
	{
		get
		{
			if (_oMask != null)
			{
				return _oMask.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MaskRootshow == value || !(_oMask != null))
			{
				return;
			}
			if (value)
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.Register(_resourceAssetName, delegate
				{
					_oMask.SetObjectActive(value);
				});
			}
			else
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oMask.SetObjectActive(value);
			}
		}
	}

	public Color MaskColor
	{
		get
		{
			if (_oMaskImage != null)
			{
				return _oMaskImage.color;
			}
			return Color.white;
		}
		set
		{
			if (MaskColor != value && _oMaskImage != null)
			{
				_oMaskImage.color = value;
			}
		}
	}

	public Vector3 TopImagePosition
	{
		get
		{
			if (_oTopImageRectTransform != null)
			{
				return _oTopImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (TopImagePosition != value && _oTopImageRectTransform != null)
			{
				_oTopImageRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 RightImagePosition
	{
		get
		{
			if (_oRightImageRectTransform != null)
			{
				return _oRightImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (RightImagePosition != value && _oRightImageRectTransform != null)
			{
				_oRightImageRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 LeftImagePosition
	{
		get
		{
			if (_oLeftImageRectTransform != null)
			{
				return _oLeftImageRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LeftImagePosition != value && _oLeftImageRectTransform != null)
			{
				_oLeftImageRectTransform.localPosition = value;
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
			case "Mask":
				_oMask = transform.gameObject;
				_oMaskImage = transform.gameObject.GetComponent<Image>();
				break;
			case "TopImage":
				_oTopImage = transform.gameObject;
				_oTopImageRectTransform = transform.gameObject.GetComponent<RectTransform>();
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
