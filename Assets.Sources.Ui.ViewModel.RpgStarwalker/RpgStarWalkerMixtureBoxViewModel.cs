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

namespace Assets.Sources.Ui.ViewModel.RpgStarwalker;

[GameUiTest]
public class RpgStarWalkerMixtureBoxViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRpgStarWalkerMixtureBox;

	private GameObject _oShow;

	private GameObject _oBack;

	private Image _oBackImage;

	private GameObject _oMixtureSlot;

	private Image _oMixtureSlotImage;

	private GameObject _oMixtureIcon;

	private Image _oMixtureIconImage;

	private GameObject _oText;

	private GameObject _oMixtureName;

	private Text _oMixtureNameText;

	private GameObject _oMixtureDesc;

	private Text _oMixtureDescText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgstarwalker";

	private string _resourceAssetName = "rpgstarwalkermixturebox";

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

	public GameObject RpgStarWalkerMixtureBoxObj => _oRpgStarWalkerMixtureBox;

	public bool RpgStarWalkerMixtureBoxShow
	{
		get
		{
			if (_oRpgStarWalkerMixtureBox != null)
			{
				return _oRpgStarWalkerMixtureBox.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RpgStarWalkerMixtureBoxShow != value && _oRpgStarWalkerMixtureBox != null)
			{
				_oRpgStarWalkerMixtureBox.SetObjectActive(value);
			}
		}
	}

	public GameObject ShowObj => _oShow;

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

	public GameObject BackObj => _oBack;

	public Image BackImage
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage;
			}
			return null;
		}
		set
		{
			if (BackImage != value && _oBackImage != null)
			{
				_oBackImage = value;
			}
		}
	}

	public GameObject MixtureSlotObj => _oMixtureSlot;

	public Image MixtureSlotImage
	{
		get
		{
			if (_oMixtureSlotImage != null)
			{
				return _oMixtureSlotImage;
			}
			return null;
		}
		set
		{
			if (MixtureSlotImage != value && _oMixtureSlotImage != null)
			{
				_oMixtureSlotImage = value;
			}
		}
	}

	public GameObject MixtureIconObj => _oMixtureIcon;

	public Image MixtureIconImage
	{
		get
		{
			if (_oMixtureIconImage != null)
			{
				return _oMixtureIconImage;
			}
			return null;
		}
		set
		{
			if (MixtureIconImage != value && _oMixtureIconImage != null)
			{
				_oMixtureIconImage = value;
			}
		}
	}

	public GameObject TextObj => _oText;

	public GameObject MixtureNameObj => _oMixtureName;

	public string MixtureNameString
	{
		get
		{
			if (_oMixtureNameText != null)
			{
				return _oMixtureNameText.text;
			}
			return null;
		}
		set
		{
			if (MixtureNameString != value && _oMixtureNameText != null)
			{
				_oMixtureNameText.text = value;
			}
		}
	}

	public GameObject MixtureDescObj => _oMixtureDesc;

	public string MixtureDescString
	{
		get
		{
			if (_oMixtureDescText != null)
			{
				return _oMixtureDescText.text;
			}
			return null;
		}
		set
		{
			if (MixtureDescString != value && _oMixtureDescText != null)
			{
				_oMixtureDescText.text = value;
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
			case "RpgStarWalkerMixtureBox":
				_oRpgStarWalkerMixtureBox = transform.gameObject;
				break;
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "Back":
				_oBack = transform.gameObject;
				_oBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "MixtureSlot":
				_oMixtureSlot = transform.gameObject;
				_oMixtureSlotImage = transform.gameObject.GetComponent<Image>();
				break;
			case "MixtureIcon":
				_oMixtureIcon = transform.gameObject;
				_oMixtureIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Text":
				_oText = transform.gameObject;
				break;
			case "MixtureName":
				_oMixtureName = transform.gameObject;
				_oMixtureNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "MixtureDesc":
				_oMixtureDesc = transform.gameObject;
				_oMixtureDescText = transform.gameObject.GetComponent<Text>();
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
