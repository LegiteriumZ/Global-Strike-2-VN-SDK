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
public class HomeLandModelRentInfoViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oclone_btn;

	private Button _oclone_btnButton;

	private GameObject _ol_btn;

	private Button _ol_btnButton;

	private GameObject _or_btn;

	private Button _or_btnButton;

	private GameObject _opj_1;

	private GameObject _opj_2;

	private GameObject _opj_3;

	private GameObject _opj_4;

	private GameObject _osl_num;

	private Text _osl_numText;

	private GameObject _otb_num;

	private Text _otb_numText;

	private GameObject _ol_rent_btn;

	private Button _ol_rent_btnButton;

	private GameObject _orent_btn;

	private Button _orent_btnButton;

	private GameObject _oweaponIcon;

	private Image _oweaponIconImage;

	private GameObject _oweaponName;

	private Text _oweaponNameText;

	private GameObject _oShowTips;

	private GameObject _orent2_btn;

	private Button _orent2_btnButton;

	private GameObject _oz_num;

	private Text _oz_numText;

	private GameObject _oy_num;

	private Text _oy_numText;

	private GameObject _oclone2_btn;

	private Button _oclone2_btnButton;

	private GameObject _otitle;

	private Text _otitleText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/homelandmodel";

	private string _resourceAssetName = "homelandmodelrentinfo";

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

	public Button.ButtonClickedEvent l_btnClicked
	{
		get
		{
			if (_ol_btnButton != null)
			{
				return _ol_btnButton.onClick;
			}
			return null;
		}
		set
		{
			if (l_btnClicked != value && _ol_btnButton != null)
			{
				_ol_btnButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent r_btnClicked
	{
		get
		{
			if (_or_btnButton != null)
			{
				return _or_btnButton.onClick;
			}
			return null;
		}
		set
		{
			if (r_btnClicked != value && _or_btnButton != null)
			{
				_or_btnButton.onClick = value;
			}
		}
	}

	public bool pj_Show1
	{
		get
		{
			if (_opj_1 != null)
			{
				return _opj_1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pj_Show1 != value && _opj_1 != null)
			{
				_opj_1.SetObjectActive(value);
			}
		}
	}

	public bool pj_Show2
	{
		get
		{
			if (_opj_2 != null)
			{
				return _opj_2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pj_Show2 != value && _opj_2 != null)
			{
				_opj_2.SetObjectActive(value);
			}
		}
	}

	public bool pj_Show3
	{
		get
		{
			if (_opj_3 != null)
			{
				return _opj_3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pj_Show3 != value && _opj_3 != null)
			{
				_opj_3.SetObjectActive(value);
			}
		}
	}

	public bool pj_Show4
	{
		get
		{
			if (_opj_4 != null)
			{
				return _opj_4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pj_Show4 != value && _opj_4 != null)
			{
				_opj_4.SetObjectActive(value);
			}
		}
	}

	public string sl_numString
	{
		get
		{
			if (_osl_numText != null)
			{
				return _osl_numText.text;
			}
			return null;
		}
		set
		{
			if (sl_numString != value && _osl_numText != null)
			{
				_osl_numText.text = value;
			}
		}
	}

	public string tb_numString
	{
		get
		{
			if (_otb_numText != null)
			{
				return _otb_numText.text;
			}
			return null;
		}
		set
		{
			if (tb_numString != value && _otb_numText != null)
			{
				_otb_numText.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_rent_btnClicked
	{
		get
		{
			if (_ol_rent_btnButton != null)
			{
				return _ol_rent_btnButton.onClick;
			}
			return null;
		}
		set
		{
			if (l_rent_btnClicked != value && _ol_rent_btnButton != null)
			{
				_ol_rent_btnButton.onClick = value;
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

	public Sprite weaponIconSprite
	{
		get
		{
			if (_oweaponIconImage != null)
			{
				return _oweaponIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (weaponIconSprite != value && _oweaponIconImage != null)
			{
				_oweaponIconImage.sprite = value;
			}
		}
	}

	public string weaponNameString
	{
		get
		{
			if (_oweaponNameText != null)
			{
				return _oweaponNameText.text;
			}
			return null;
		}
		set
		{
			if (weaponNameString != value && _oweaponNameText != null)
			{
				_oweaponNameText.text = value;
			}
		}
	}

	public bool ShowTipsShow
	{
		get
		{
			if (_oShowTips != null)
			{
				return _oShowTips.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowTipsShow != value && _oShowTips != null)
			{
				_oShowTips.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent rent2_btnClicked
	{
		get
		{
			if (_orent2_btnButton != null)
			{
				return _orent2_btnButton.onClick;
			}
			return null;
		}
		set
		{
			if (rent2_btnClicked != value && _orent2_btnButton != null)
			{
				_orent2_btnButton.onClick = value;
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

	public Button.ButtonClickedEvent clone2_btnClicked
	{
		get
		{
			if (_oclone2_btnButton != null)
			{
				return _oclone2_btnButton.onClick;
			}
			return null;
		}
		set
		{
			if (clone2_btnClicked != value && _oclone2_btnButton != null)
			{
				_oclone2_btnButton.onClick = value;
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
			case "clone_btn":
				_oclone_btn = transform.gameObject;
				_oclone_btnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "l_btn":
				_ol_btn = transform.gameObject;
				_ol_btnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "r_btn":
				_or_btn = transform.gameObject;
				_or_btnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "pj_1":
				_opj_1 = transform.gameObject;
				break;
			case "pj_2":
				_opj_2 = transform.gameObject;
				break;
			case "pj_3":
				_opj_3 = transform.gameObject;
				break;
			case "pj_4":
				_opj_4 = transform.gameObject;
				break;
			case "sl_num":
				_osl_num = transform.gameObject;
				_osl_numText = transform.gameObject.GetComponent<Text>();
				break;
			case "tb_num":
				_otb_num = transform.gameObject;
				_otb_numText = transform.gameObject.GetComponent<Text>();
				break;
			case "l_rent_btn":
				_ol_rent_btn = transform.gameObject;
				_ol_rent_btnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "rent_btn":
				_orent_btn = transform.gameObject;
				_orent_btnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "weaponIcon":
				_oweaponIcon = transform.gameObject;
				_oweaponIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "weaponName":
				_oweaponName = transform.gameObject;
				_oweaponNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "ShowTips":
				_oShowTips = transform.gameObject;
				break;
			case "rent2_btn":
				_orent2_btn = transform.gameObject;
				_orent2_btnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "z_num":
				_oz_num = transform.gameObject;
				_oz_numText = transform.gameObject.GetComponent<Text>();
				break;
			case "y_num":
				_oy_num = transform.gameObject;
				_oy_numText = transform.gameObject.GetComponent<Text>();
				break;
			case "clone2_btn":
				_oclone2_btn = transform.gameObject;
				_oclone2_btnButton = transform.gameObject.GetComponent<Button>();
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

	public bool Getpj_Show(int index)
	{
		return index switch
		{
			1 => pj_Show1, 
			2 => pj_Show2, 
			3 => pj_Show3, 
			4 => pj_Show4, 
			_ => false, 
		};
	}

	public void Setpj_Show(int index, bool value)
	{
		switch (index)
		{
		case 1:
			pj_Show1 = value;
			break;
		case 2:
			pj_Show2 = value;
			break;
		case 3:
			pj_Show3 = value;
			break;
		case 4:
			pj_Show4 = value;
			break;
		}
	}

	public int Getpj_Count()
	{
		return 4;
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
