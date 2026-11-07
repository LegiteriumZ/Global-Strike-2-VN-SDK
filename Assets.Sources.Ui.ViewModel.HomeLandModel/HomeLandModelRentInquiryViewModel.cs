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

namespace Assets.Sources.Ui.ViewModel.HomeLandModel;

[GameUiTest]
public class HomeLandModelRentInquiryViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _orent_btn;

	private Button _orent_btnButton;

	private GameObject _oz_num;

	private Text _oz_numText;

	private GameObject _oy_num;

	private Text _oy_numText;

	private GameObject _oclone_btn;

	private Button _oclone_btnButton;

	private GameObject _otitle;

	private Text _otitleText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/homelandmodel";

	private string _resourceAssetName = "homelandmodelrentinquiry";

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

	public Button.ButtonClickedEvent rent_btnClicked
	{
		get
		{
			if (_orent_btnButton != null)
			{
				return _orent_btnButton.onClick;
			}
			return null;
		}
		set
		{
			if (rent_btnClicked != value && _orent_btnButton != null)
			{
				_orent_btnButton.onClick = value;
			}
		}
	}

	public string z_numString
	{
		get
		{
			if (_oz_numText != null)
			{
				return _oz_numText.text;
			}
			return null;
		}
		set
		{
			if (z_numString != value && _oz_numText != null)
			{
				_oz_numText.text = value;
			}
		}
	}

	public string y_numString
	{
		get
		{
			if (_oy_numText != null)
			{
				return _oy_numText.text;
			}
			return null;
		}
		set
		{
			if (y_numString != value && _oy_numText != null)
			{
				_oy_numText.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent clone_btnClicked
	{
		get
		{
			if (_oclone_btnButton != null)
			{
				return _oclone_btnButton.onClick;
			}
			return null;
		}
		set
		{
			if (clone_btnClicked != value && _oclone_btnButton != null)
			{
				_oclone_btnButton.onClick = value;
			}
		}
	}

	public string titleString
	{
		get
		{
			if (_otitleText != null)
			{
				return _otitleText.text;
			}
			return null;
		}
		set
		{
			if (titleString != value && _otitleText != null)
			{
				_otitleText.text = value;
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
			case "rent_btn":
				_orent_btn = transform.gameObject;
				_orent_btnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "z_num":
				_oz_num = transform.gameObject;
				_oz_numText = transform.gameObject.GetComponent<Text>();
				break;
			case "y_num":
				_oy_num = transform.gameObject;
				_oy_numText = transform.gameObject.GetComponent<Text>();
				break;
			case "clone_btn":
				_oclone_btn = transform.gameObject;
				_oclone_btnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "title":
				_otitle = transform.gameObject;
				_otitleText = transform.gameObject.GetComponent<Text>();
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
