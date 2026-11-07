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

namespace Assets.Sources.Ui.ViewModel.RpgMystery;

[GameUiTest]
public class LightFireStatusViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oProgress;

	private Image _oProgressImage;

	private GameObject _oLight;

	private RectTransform _oLightRectTransform;

	private GameObject _oGrid;

	private HorizontalLayoutGroup _oGridHorizontalLayoutGroup;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oText;

	private Text _oTextText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgmystery";

	private string _resourceAssetName = "LightFireStatus";

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

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public float ProgressFillamount
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount != value && _oProgressImage != null)
			{
				_oProgressImage.fillAmount = value;
			}
		}
	}

	public Vector2 LightAnchoredposition
	{
		get
		{
			if (_oLightRectTransform != null)
			{
				return _oLightRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (LightAnchoredposition != value && _oLightRectTransform != null)
			{
				_oLightRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 LightPosition
	{
		get
		{
			if (_oLightRectTransform != null)
			{
				return _oLightRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (LightPosition != value && _oLightRectTransform != null)
			{
				_oLightRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 LightGposition
	{
		get
		{
			if (_oLightRectTransform != null)
			{
				return _oLightRectTransform.position;
			}
			return Vector3.zero;
		}
		set
		{
			if (LightGposition != value && _oLightRectTransform != null)
			{
				_oLightRectTransform.position = value;
			}
		}
	}

	public float GridHspacing
	{
		get
		{
			if (_oGridHorizontalLayoutGroup != null)
			{
				return _oGridHorizontalLayoutGroup.spacing;
			}
			return 0f;
		}
		set
		{
			if (GridHspacing != value && _oGridHorizontalLayoutGroup != null)
			{
				_oGridHorizontalLayoutGroup.spacing = value;
			}
		}
	}

	public string PlayerNameString
	{
		get
		{
			if (_oPlayerNameText != null)
			{
				return _oPlayerNameText.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString != value && _oPlayerNameText != null)
			{
				_oPlayerNameText.text = value;
			}
		}
	}

	public string TextString
	{
		get
		{
			if (_oTextText != null)
			{
				return _oTextText.text;
			}
			return null;
		}
		set
		{
			if (TextString != value && _oTextText != null)
			{
				_oTextText.text = value;
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
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "Progress":
				_oProgress = transform.gameObject;
				_oProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Light":
				_oLight = transform.gameObject;
				_oLightRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Grid":
				_oGrid = transform.gameObject;
				_oGridHorizontalLayoutGroup = transform.gameObject.GetComponent<HorizontalLayoutGroup>();
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "Text":
				_oText = transform.gameObject;
				_oTextText = transform.gameObject.GetComponent<Text>();
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

	public void GridHlayoutupdate()
	{
		if (_oGridHorizontalLayoutGroup != null)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(_oGrid.GetComponent<RectTransform>());
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
