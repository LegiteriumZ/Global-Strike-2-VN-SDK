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
public class AcgPlayerStatusBoardViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPlayerIcon;

	private Image _oPlayerIconImage;

	private GameObject _oDeadIcon;

	private GameObject _oHpBar;

	private Image _oHpBarImage;

	private GameObject _oShieldHpBar;

	private Image _oShieldHpBarImage;

	private GameObject _oHpBarText;

	private Text _oHpBarTextText;

	private GameObject _oShieldHpBarText;

	private Text _oShieldHpBarTextText;

	private GameObject _oBuffList;

	private GameObject _oBuff0;

	private Image _oBuffImage0;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgplayerstatusboard";

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

	public Image PlayerIconImage
	{
		get
		{
			if (_oPlayerIconImage != null)
			{
				return _oPlayerIconImage;
			}
			return null;
		}
		set
		{
			if (PlayerIconImage != value && _oPlayerIconImage != null)
			{
				_oPlayerIconImage = value;
			}
		}
	}

	public bool DeadIconShow
	{
		get
		{
			if (_oDeadIcon != null)
			{
				return _oDeadIcon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DeadIconShow != value && _oDeadIcon != null)
			{
				_oDeadIcon.SetObjectActive(value);
			}
		}
	}

	public float HpBarFillamount
	{
		get
		{
			if (_oHpBarImage != null)
			{
				return _oHpBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HpBarFillamount != value && _oHpBarImage != null)
			{
				_oHpBarImage.fillAmount = value;
			}
		}
	}

	public float ShieldHpBarFillamount
	{
		get
		{
			if (_oShieldHpBarImage != null)
			{
				return _oShieldHpBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ShieldHpBarFillamount != value && _oShieldHpBarImage != null)
			{
				_oShieldHpBarImage.fillAmount = value;
			}
		}
	}

	public string HpBarTextString
	{
		get
		{
			if (_oHpBarTextText != null)
			{
				return _oHpBarTextText.text;
			}
			return null;
		}
		set
		{
			if (HpBarTextString != value && _oHpBarTextText != null)
			{
				_oHpBarTextText.text = value;
			}
		}
	}

	public string ShieldHpBarTextString
	{
		get
		{
			if (_oShieldHpBarTextText != null)
			{
				return _oShieldHpBarTextText.text;
			}
			return null;
		}
		set
		{
			if (ShieldHpBarTextString != value && _oShieldHpBarTextText != null)
			{
				_oShieldHpBarTextText.text = value;
			}
		}
	}

	public GameObject BuffListObj => _oBuffList;

	public bool BuffListShow
	{
		get
		{
			if (_oBuffList != null)
			{
				return _oBuffList.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffListShow != value && _oBuffList != null)
			{
				_oBuffList.SetObjectActive(value);
			}
		}
	}

	public GameObject BuffObj0 => _oBuff0;

	public Image BuffImage0
	{
		get
		{
			if (_oBuffImage0 != null)
			{
				return _oBuffImage0;
			}
			return null;
		}
		set
		{
			if (BuffImage0 != value && _oBuffImage0 != null)
			{
				_oBuffImage0 = value;
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
			case "PlayerIcon":
				_oPlayerIcon = transform.gameObject;
				_oPlayerIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "DeadIcon":
				_oDeadIcon = transform.gameObject;
				break;
			case "HpBar":
				_oHpBar = transform.gameObject;
				_oHpBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ShieldHpBar":
				_oShieldHpBar = transform.gameObject;
				_oShieldHpBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HpBarText":
				_oHpBarText = transform.gameObject;
				_oHpBarTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "ShieldHpBarText":
				_oShieldHpBarText = transform.gameObject;
				_oShieldHpBarTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "BuffList":
				_oBuffList = transform.gameObject;
				break;
			case "Buff0":
				_oBuff0 = transform.gameObject;
				_oBuffImage0 = transform.gameObject.GetComponent<Image>();
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

	public GameObject GetBuffObj(int index)
	{
		if (index == 0)
		{
			return BuffObj0;
		}
		return null;
	}

	public int GetBuffCount()
	{
		return 0;
	}

	public Image GetBuffImage(int index)
	{
		if (index == 0)
		{
			return BuffImage0;
		}
		return null;
	}

	public void SetBuffImage(int index, Image value)
	{
		if (index == 0)
		{
			BuffImage0 = value;
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
