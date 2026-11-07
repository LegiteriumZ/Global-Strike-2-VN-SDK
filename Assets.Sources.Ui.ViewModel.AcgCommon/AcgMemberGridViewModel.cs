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
public class AcgMemberGridViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oAcgMemberGrid;

	private GameObject _oPlayerIcon;

	private Image _oPlayerIconImage;

	private GameObject _oDeadIcon;

	private GameObject _oHpBar;

	private Image _oHpBarImage;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oBuffList;

	private GameObject _oBuff;

	private Image _oBuffImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgmembergrid";

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

	public bool AcgMemberGridShow
	{
		get
		{
			if (_oAcgMemberGrid != null)
			{
				return _oAcgMemberGrid.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AcgMemberGridShow != value && _oAcgMemberGrid != null)
			{
				_oAcgMemberGrid.SetObjectActive(value);
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

	public GameObject BuffObj => _oBuff;

	public Image BuffImage
	{
		get
		{
			if (_oBuffImage != null)
			{
				return _oBuffImage;
			}
			return null;
		}
		set
		{
			if (BuffImage != value && _oBuffImage != null)
			{
				_oBuffImage = value;
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
			case "AcgMemberGrid":
				_oAcgMemberGrid = transform.gameObject;
				break;
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
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "BuffList":
				_oBuffList = transform.gameObject;
				break;
			case "Buff":
				_oBuff = transform.gameObject;
				_oBuffImage = transform.gameObject.GetComponent<Image>();
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
