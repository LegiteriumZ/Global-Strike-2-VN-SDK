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
public class AcgPowerUpCoinBoardViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private RectTransform _oShowRectTransform;

	private GameObject _oCoinIcon;

	private RectTransform _oCoinIconRectTransform;

	private GameObject _oCoinNumber;

	private RectTransform _oCoinNumberRectTransform;

	private Text _oCoinNumberText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgpowerupcoinboard";

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

	public Vector3 ShowScale
	{
		get
		{
			if (_oShowRectTransform != null)
			{
				return _oShowRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (ShowScale != value && _oShowRectTransform != null)
			{
				_oShowRectTransform.localScale = value;
			}
		}
	}

	public Vector3 CoinIconScale
	{
		get
		{
			if (_oCoinIconRectTransform != null)
			{
				return _oCoinIconRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CoinIconScale != value && _oCoinIconRectTransform != null)
			{
				_oCoinIconRectTransform.localScale = value;
			}
		}
	}

	public Vector3 CoinNumberScale
	{
		get
		{
			if (_oCoinNumberRectTransform != null)
			{
				return _oCoinNumberRectTransform.localScale;
			}
			return Vector3.zero;
		}
		set
		{
			if (CoinNumberScale != value && _oCoinNumberRectTransform != null)
			{
				_oCoinNumberRectTransform.localScale = value;
			}
		}
	}

	public string CoinNumberString
	{
		get
		{
			if (_oCoinNumberText != null)
			{
				return _oCoinNumberText.text;
			}
			return null;
		}
		set
		{
			if (CoinNumberString != value && _oCoinNumberText != null)
			{
				_oCoinNumberText.text = value;
			}
		}
	}

	public Color CoinNumberTextcolor
	{
		get
		{
			if (_oCoinNumberText != null)
			{
				return _oCoinNumberText.color;
			}
			return Color.white;
		}
		set
		{
			if (CoinNumberTextcolor != value && _oCoinNumberText != null)
			{
				_oCoinNumberText.color = value;
			}
		}
	}

	public int CoinNumberFontsize
	{
		get
		{
			if (_oCoinNumberText != null)
			{
				return _oCoinNumberText.fontSize;
			}
			return 16;
		}
		set
		{
			if (CoinNumberFontsize != value && _oCoinNumberText != null)
			{
				_oCoinNumberText.fontSize = value;
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
				_oShowRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CoinIcon":
				_oCoinIcon = transform.gameObject;
				_oCoinIconRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CoinNumber":
				_oCoinNumber = transform.gameObject;
				_oCoinNumberRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oCoinNumberText = transform.gameObject.GetComponent<Text>();
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
