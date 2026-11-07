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

namespace Assets.Sources.Ui.ViewModel.RpgMouseYear;

[GameUiTest]
public class RpgChooseWeaponViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oImageBG;

	private RectTransform _oImageBGRectTransform;

	private EventTrigger _oImageBGEventTrigger;

	private Button _oImageBGButton;

	private GameObject _oNobombWeapon1;

	private GameObject _oNobombWeapon2;

	private GameObject _oNobombWeapon3;

	private GameObject _oNobombWeapon4;

	private GameObject _oNobombWeapon5;

	private GameObject _oAlertText;

	private Text _oAlertTextText;

	private GameObject _oChoose1;

	private GameObject _oChoose2;

	private GameObject _oChoose3;

	private GameObject _oChoose4;

	private GameObject _oChoose5;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgmouseyear";

	private string _resourceAssetName = "RpgChooseWeapon";

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

	public GameObject ImageBGObj => _oImageBG;

	public Vector3 ImageBGPosition
	{
		get
		{
			if (_oImageBGRectTransform != null)
			{
				return _oImageBGRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ImageBGPosition != value && _oImageBGRectTransform != null)
			{
				_oImageBGRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 ImageBGSize
	{
		get
		{
			if (_oImageBGRectTransform != null)
			{
				return _oImageBGRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (ImageBGSize != value && _oImageBGRectTransform != null)
			{
				_oImageBGRectTransform.sizeDelta = value;
			}
		}
	}

	public Rect ImageBGRect
	{
		get
		{
			if (_oImageBGRectTransform != null)
			{
				return _oImageBGRectTransform.rect;
			}
			return Rect.zero;
		}
	}

	public List<EventTrigger.Entry> ImageBGTriggers
	{
		get
		{
			if (_oImageBGEventTrigger != null)
			{
				return _oImageBGEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (ImageBGTriggers != value && _oImageBGEventTrigger != null)
			{
				_oImageBGEventTrigger.triggers = value;
			}
		}
	}

	public Button.ButtonClickedEvent ImageBGClicked
	{
		get
		{
			if (_oImageBGButton != null)
			{
				return _oImageBGButton.onClick;
			}
			return null;
		}
		set
		{
			if (ImageBGClicked != value && _oImageBGButton != null)
			{
				_oImageBGButton.onClick = value;
			}
		}
	}

	public bool ImageBGButtonable
	{
		get
		{
			if (_oImageBGButton != null)
			{
				return _oImageBGButton.interactable;
			}
			return true;
		}
		set
		{
			if (ImageBGButtonable != value && _oImageBGButton != null)
			{
				_oImageBGButton.interactable = value;
			}
		}
	}

	public bool NobombWeaponShow1
	{
		get
		{
			if (_oNobombWeapon1 != null)
			{
				return _oNobombWeapon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NobombWeaponShow1 != value && _oNobombWeapon1 != null)
			{
				_oNobombWeapon1.SetObjectActive(value);
			}
		}
	}

	public bool NobombWeaponShow2
	{
		get
		{
			if (_oNobombWeapon2 != null)
			{
				return _oNobombWeapon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NobombWeaponShow2 != value && _oNobombWeapon2 != null)
			{
				_oNobombWeapon2.SetObjectActive(value);
			}
		}
	}

	public bool NobombWeaponShow3
	{
		get
		{
			if (_oNobombWeapon3 != null)
			{
				return _oNobombWeapon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NobombWeaponShow3 != value && _oNobombWeapon3 != null)
			{
				_oNobombWeapon3.SetObjectActive(value);
			}
		}
	}

	public bool NobombWeaponShow4
	{
		get
		{
			if (_oNobombWeapon4 != null)
			{
				return _oNobombWeapon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NobombWeaponShow4 != value && _oNobombWeapon4 != null)
			{
				_oNobombWeapon4.SetObjectActive(value);
			}
		}
	}

	public bool NobombWeaponShow5
	{
		get
		{
			if (_oNobombWeapon5 != null)
			{
				return _oNobombWeapon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NobombWeaponShow5 != value && _oNobombWeapon5 != null)
			{
				_oNobombWeapon5.SetObjectActive(value);
			}
		}
	}

	public string AlertTextString
	{
		get
		{
			if (_oAlertTextText != null)
			{
				return _oAlertTextText.text;
			}
			return null;
		}
		set
		{
			if (AlertTextString != value && _oAlertTextText != null)
			{
				_oAlertTextText.text = value;
			}
		}
	}

	public bool ChooseShow1
	{
		get
		{
			if (_oChoose1 != null)
			{
				return _oChoose1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseShow1 != value && _oChoose1 != null)
			{
				_oChoose1.SetObjectActive(value);
			}
		}
	}

	public bool ChooseShow2
	{
		get
		{
			if (_oChoose2 != null)
			{
				return _oChoose2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseShow2 != value && _oChoose2 != null)
			{
				_oChoose2.SetObjectActive(value);
			}
		}
	}

	public bool ChooseShow3
	{
		get
		{
			if (_oChoose3 != null)
			{
				return _oChoose3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseShow3 != value && _oChoose3 != null)
			{
				_oChoose3.SetObjectActive(value);
			}
		}
	}

	public bool ChooseShow4
	{
		get
		{
			if (_oChoose4 != null)
			{
				return _oChoose4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseShow4 != value && _oChoose4 != null)
			{
				_oChoose4.SetObjectActive(value);
			}
		}
	}

	public bool ChooseShow5
	{
		get
		{
			if (_oChoose5 != null)
			{
				return _oChoose5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ChooseShow5 != value && _oChoose5 != null)
			{
				_oChoose5.SetObjectActive(value);
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
			case "ImageBG":
				_oImageBG = transform.gameObject;
				_oImageBGRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oImageBGEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				_oImageBGButton = transform.gameObject.GetComponent<Button>();
				break;
			case "NobombWeapon1":
				_oNobombWeapon1 = transform.gameObject;
				break;
			case "NobombWeapon2":
				_oNobombWeapon2 = transform.gameObject;
				break;
			case "NobombWeapon3":
				_oNobombWeapon3 = transform.gameObject;
				break;
			case "NobombWeapon4":
				_oNobombWeapon4 = transform.gameObject;
				break;
			case "NobombWeapon5":
				_oNobombWeapon5 = transform.gameObject;
				break;
			case "AlertText":
				_oAlertText = transform.gameObject;
				_oAlertTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "Choose1":
				_oChoose1 = transform.gameObject;
				break;
			case "Choose2":
				_oChoose2 = transform.gameObject;
				break;
			case "Choose3":
				_oChoose3 = transform.gameObject;
				break;
			case "Choose4":
				_oChoose4 = transform.gameObject;
				break;
			case "Choose5":
				_oChoose5 = transform.gameObject;
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

	public bool GetNobombWeaponShow(int index)
	{
		return index switch
		{
			1 => NobombWeaponShow1, 
			2 => NobombWeaponShow2, 
			3 => NobombWeaponShow3, 
			4 => NobombWeaponShow4, 
			5 => NobombWeaponShow5, 
			_ => false, 
		};
	}

	public void SetNobombWeaponShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			NobombWeaponShow1 = value;
			break;
		case 2:
			NobombWeaponShow2 = value;
			break;
		case 3:
			NobombWeaponShow3 = value;
			break;
		case 4:
			NobombWeaponShow4 = value;
			break;
		case 5:
			NobombWeaponShow5 = value;
			break;
		}
	}

	public bool GetChooseShow(int index)
	{
		return index switch
		{
			1 => ChooseShow1, 
			2 => ChooseShow2, 
			3 => ChooseShow3, 
			4 => ChooseShow4, 
			5 => ChooseShow5, 
			_ => false, 
		};
	}

	public void SetChooseShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ChooseShow1 = value;
			break;
		case 2:
			ChooseShow2 = value;
			break;
		case 3:
			ChooseShow3 = value;
			break;
		case 4:
			ChooseShow4 = value;
			break;
		case 5:
			ChooseShow5 = value;
			break;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
