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

namespace Assets.Sources.Ui.ViewModel.BigHead;

[GameUiTest]
public class CrazyBigheadHeroStateViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oHPBar;

	private Image _oHPBarImage;

	private GameObject _oENBar;

	private Image _oENBarImage;

	private GameObject _oHPNumber;

	private Text _oHPNumberText;

	private GameObject _oEnNumber;

	private Text _oEnNumberText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/bighead";

	private string _resourceAssetName = "CrazyBigheadHeroState";

	private List<RectTransform> _holdPosTrans;

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

	public float HPBarFillamount
	{
		get
		{
			if (_oHPBarImage != null)
			{
				return _oHPBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HPBarFillamount != value && _oHPBarImage != null)
			{
				_oHPBarImage.fillAmount = value;
			}
		}
	}

	public float ENBarFillamount
	{
		get
		{
			if (_oENBarImage != null)
			{
				return _oENBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ENBarFillamount != value && _oENBarImage != null)
			{
				_oENBarImage.fillAmount = value;
			}
		}
	}

	public string HPNumberString
	{
		get
		{
			if (_oHPNumberText != null)
			{
				return _oHPNumberText.text;
			}
			return null;
		}
		set
		{
			if (HPNumberString != value && _oHPNumberText != null)
			{
				_oHPNumberText.text = value;
			}
		}
	}

	public string EnNumberString
	{
		get
		{
			if (_oEnNumberText != null)
			{
				return _oEnNumberText.text;
			}
			return null;
		}
		set
		{
			if (EnNumberString != value && _oEnNumberText != null)
			{
				_oEnNumberText.text = value;
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
			case "HPBar":
				_oHPBar = transform.gameObject;
				_oHPBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ENBar":
				_oENBar = transform.gameObject;
				_oENBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HPNumber":
				_oHPNumber = transform.gameObject;
				_oHPNumberText = transform.gameObject.GetComponent<Text>();
				break;
			case "EnNumber":
				_oEnNumber = transform.gameObject;
				_oEnNumberText = transform.gameObject.GetComponent<Text>();
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		if (_oHPNumberText != null)
		{
			_holdPosTrans.Add(_oHPNumberText.GetComponent<RectTransform>());
		}
		if (_oEnNumberText != null)
		{
			_holdPosTrans.Add(_oEnNumberText.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
