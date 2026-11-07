using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.AcgCommon;

[GameUiTest]
public class AcgTextNotificationBoardViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oMiddle;

	private RectTransform _oMiddleRectTransform;

	private Text _oMiddleText;

	private GameObject _oBottom;

	private RectTransform _oBottomRectTransform;

	private Text _oBottomText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgtextnotificationboard";

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

	public bool MiddleShow
	{
		get
		{
			if (_oMiddle != null)
			{
				return _oMiddle.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MiddleShow != value && _oMiddle != null)
			{
				_oMiddle.SetObjectActive(value);
			}
		}
	}

	public Vector2 MiddleAnchoredposition
	{
		get
		{
			if (_oMiddleRectTransform != null)
			{
				return _oMiddleRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (MiddleAnchoredposition != value && _oMiddleRectTransform != null)
			{
				_oMiddleRectTransform.anchoredPosition = value;
			}
		}
	}

	public string MiddleString
	{
		get
		{
			if (_oMiddleText != null)
			{
				return _oMiddleText.text;
			}
			return null;
		}
		set
		{
			if (MiddleString != value && _oMiddleText != null)
			{
				_oMiddleText.text = value;
			}
		}
	}

	public Color MiddleTextcolor
	{
		get
		{
			if (_oMiddleText != null)
			{
				return _oMiddleText.color;
			}
			return Color.white;
		}
		set
		{
			if (MiddleTextcolor != value && _oMiddleText != null)
			{
				_oMiddleText.color = value;
			}
		}
	}

	public bool BottomShow
	{
		get
		{
			if (_oBottom != null)
			{
				return _oBottom.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BottomShow != value && _oBottom != null)
			{
				_oBottom.SetObjectActive(value);
			}
		}
	}

	public Vector2 BottomAnchoredposition
	{
		get
		{
			if (_oBottomRectTransform != null)
			{
				return _oBottomRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (BottomAnchoredposition != value && _oBottomRectTransform != null)
			{
				_oBottomRectTransform.anchoredPosition = value;
			}
		}
	}

	public string BottomString
	{
		get
		{
			if (_oBottomText != null)
			{
				return _oBottomText.text;
			}
			return null;
		}
		set
		{
			if (BottomString != value && _oBottomText != null)
			{
				_oBottomText.text = value;
			}
		}
	}

	public Color BottomTextcolor
	{
		get
		{
			if (_oBottomText != null)
			{
				return _oBottomText.color;
			}
			return Color.white;
		}
		set
		{
			if (BottomTextcolor != value && _oBottomText != null)
			{
				_oBottomText.color = value;
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
			case "Middle":
				_oMiddle = transform.gameObject;
				_oMiddleRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oMiddleText = transform.gameObject.GetComponent<Text>();
				break;
			case "Bottom":
				_oBottom = transform.gameObject;
				_oBottomRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oBottomText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
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
