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

namespace Assets.Sources.Ui.ViewModel.HulaoguanModel;

[GameUiTest]
public class HuLaoGuanDownViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oDotName;

	private Text _oDotNameText;

	private GameObject _oSlider;

	private Slider _oSliderSlider;

	private GameObject _oSpeed;

	private Image _oSpeedImage;

	private GameObject _oBludeBg;

	private GameObject _oBludeNum;

	private Text _oBludeNumText;

	private GameObject _oRedBg;

	private GameObject _oRedNum;

	private Text _oRedNumText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/hulaoguanmodel";

	private string _resourceAssetName = "hulaoguandown";

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

	public string DotNameString
	{
		get
		{
			if (_oDotNameText != null)
			{
				return _oDotNameText.text;
			}
			return null;
		}
		set
		{
			if (DotNameString != value && _oDotNameText != null)
			{
				_oDotNameText.text = value;
			}
		}
	}

	public float SliderSlidervalue
	{
		get
		{
			if (_oSliderSlider != null)
			{
				return _oSliderSlider.value;
			}
			return 0f;
		}
		set
		{
			if (SliderSlidervalue != value && _oSliderSlider != null)
			{
				_oSliderSlider.value = value;
			}
		}
	}

	public Image SpeedImage
	{
		get
		{
			if (_oSpeedImage != null)
			{
				return _oSpeedImage;
			}
			return null;
		}
		set
		{
			if (SpeedImage != value && _oSpeedImage != null)
			{
				_oSpeedImage = value;
			}
		}
	}

	public bool BludeBgShow
	{
		get
		{
			if (_oBludeBg != null)
			{
				return _oBludeBg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BludeBgShow != value && _oBludeBg != null)
			{
				_oBludeBg.SetObjectActive(value);
			}
		}
	}

	public string BludeNumString
	{
		get
		{
			if (_oBludeNumText != null)
			{
				return _oBludeNumText.text;
			}
			return null;
		}
		set
		{
			if (BludeNumString != value && _oBludeNumText != null)
			{
				_oBludeNumText.text = value;
			}
		}
	}

	public bool RedBgShow
	{
		get
		{
			if (_oRedBg != null)
			{
				return _oRedBg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RedBgShow != value && _oRedBg != null)
			{
				_oRedBg.SetObjectActive(value);
			}
		}
	}

	public string RedNumString
	{
		get
		{
			if (_oRedNumText != null)
			{
				return _oRedNumText.text;
			}
			return null;
		}
		set
		{
			if (RedNumString != value && _oRedNumText != null)
			{
				_oRedNumText.text = value;
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
			case "DotName":
				_oDotName = transform.gameObject;
				_oDotNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "Slider":
				_oSlider = transform.gameObject;
				_oSliderSlider = transform.gameObject.GetComponent<Slider>();
				break;
			case "Speed":
				_oSpeed = transform.gameObject;
				_oSpeedImage = transform.gameObject.GetComponent<Image>();
				break;
			case "BludeBg":
				_oBludeBg = transform.gameObject;
				break;
			case "BludeNum":
				_oBludeNum = transform.gameObject;
				_oBludeNumText = transform.gameObject.GetComponent<Text>();
				break;
			case "RedBg":
				_oRedBg = transform.gameObject;
				break;
			case "RedNum":
				_oRedNum = transform.gameObject;
				_oRedNumText = transform.gameObject.GetComponent<Text>();
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
