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

namespace Assets.Sources.Ui.ViewModel.BioChemical_Z;

[GameUiTest]
public class BioChemical_ZPlayerInfoViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPIcon;

	private Image _oPIconImage;

	private GameObject _oLv;

	private Text _oLvText;

	private GameObject _oHP;

	private Image _oHPImage;

	private GameObject _oHD;

	private Image _oHDImage;

	private GameObject _op_skill1;

	private GameObject _op_skill2;

	private GameObject _op_skill3;

	private GameObject _op_skill4;

	private GameObject _op_skill5;

	private Image _op_skillImage1;

	private Image _op_skillImage2;

	private Image _op_skillImage3;

	private Image _op_skillImage4;

	private Image _op_skillImage5;

	private GameObject _oHP_2;

	private Text _oHP_Text2;

	private GameObject _oHD_2;

	private Text _oHD_Text2;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical_z";

	private string _resourceAssetName = "biochemical_zplayerinfo";

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

	public Sprite PIconSprite
	{
		get
		{
			if (_oPIconImage != null)
			{
				return _oPIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (PIconSprite != value && _oPIconImage != null)
			{
				_oPIconImage.sprite = value;
			}
		}
	}

	public string LvString
	{
		get
		{
			if (_oLvText != null)
			{
				return _oLvText.text;
			}
			return null;
		}
		set
		{
			if (LvString != value && _oLvText != null)
			{
				_oLvText.text = value;
			}
		}
	}

	public float HPFillamount
	{
		get
		{
			if (_oHPImage != null)
			{
				return _oHPImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HPFillamount != value && _oHPImage != null)
			{
				_oHPImage.fillAmount = value;
			}
		}
	}

	public float HDFillamount
	{
		get
		{
			if (_oHDImage != null)
			{
				return _oHDImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HDFillamount != value && _oHDImage != null)
			{
				_oHDImage.fillAmount = value;
			}
		}
	}

	public bool p_skillShow1
	{
		get
		{
			if (_op_skill1 != null)
			{
				return _op_skill1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (p_skillShow1 != value && _op_skill1 != null)
			{
				_op_skill1.SetObjectActive(value);
			}
		}
	}

	public bool p_skillShow2
	{
		get
		{
			if (_op_skill2 != null)
			{
				return _op_skill2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (p_skillShow2 != value && _op_skill2 != null)
			{
				_op_skill2.SetObjectActive(value);
			}
		}
	}

	public bool p_skillShow3
	{
		get
		{
			if (_op_skill3 != null)
			{
				return _op_skill3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (p_skillShow3 != value && _op_skill3 != null)
			{
				_op_skill3.SetObjectActive(value);
			}
		}
	}

	public bool p_skillShow4
	{
		get
		{
			if (_op_skill4 != null)
			{
				return _op_skill4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (p_skillShow4 != value && _op_skill4 != null)
			{
				_op_skill4.SetObjectActive(value);
			}
		}
	}

	public bool p_skillShow5
	{
		get
		{
			if (_op_skill5 != null)
			{
				return _op_skill5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (p_skillShow5 != value && _op_skill5 != null)
			{
				_op_skill5.SetObjectActive(value);
			}
		}
	}

	public Sprite p_skillSprite1
	{
		get
		{
			if (_op_skillImage1 != null)
			{
				return _op_skillImage1.sprite;
			}
			return null;
		}
		set
		{
			if (p_skillSprite1 != value && _op_skillImage1 != null)
			{
				_op_skillImage1.sprite = value;
			}
		}
	}

	public Sprite p_skillSprite2
	{
		get
		{
			if (_op_skillImage2 != null)
			{
				return _op_skillImage2.sprite;
			}
			return null;
		}
		set
		{
			if (p_skillSprite2 != value && _op_skillImage2 != null)
			{
				_op_skillImage2.sprite = value;
			}
		}
	}

	public Sprite p_skillSprite3
	{
		get
		{
			if (_op_skillImage3 != null)
			{
				return _op_skillImage3.sprite;
			}
			return null;
		}
		set
		{
			if (p_skillSprite3 != value && _op_skillImage3 != null)
			{
				_op_skillImage3.sprite = value;
			}
		}
	}

	public Sprite p_skillSprite4
	{
		get
		{
			if (_op_skillImage4 != null)
			{
				return _op_skillImage4.sprite;
			}
			return null;
		}
		set
		{
			if (p_skillSprite4 != value && _op_skillImage4 != null)
			{
				_op_skillImage4.sprite = value;
			}
		}
	}

	public Sprite p_skillSprite5
	{
		get
		{
			if (_op_skillImage5 != null)
			{
				return _op_skillImage5.sprite;
			}
			return null;
		}
		set
		{
			if (p_skillSprite5 != value && _op_skillImage5 != null)
			{
				_op_skillImage5.sprite = value;
			}
		}
	}

	public string HP_String2
	{
		get
		{
			if (_oHP_Text2 != null)
			{
				return _oHP_Text2.text;
			}
			return null;
		}
		set
		{
			if (HP_String2 != value && _oHP_Text2 != null)
			{
				_oHP_Text2.text = value;
			}
		}
	}

	public string HD_String2
	{
		get
		{
			if (_oHD_Text2 != null)
			{
				return _oHD_Text2.text;
			}
			return null;
		}
		set
		{
			if (HD_String2 != value && _oHD_Text2 != null)
			{
				_oHD_Text2.text = value;
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
			case "PIcon":
				_oPIcon = transform.gameObject;
				_oPIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Lv":
				_oLv = transform.gameObject;
				_oLvText = transform.gameObject.GetComponent<Text>();
				break;
			case "HP":
				_oHP = transform.gameObject;
				_oHPImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HD":
				_oHD = transform.gameObject;
				_oHDImage = transform.gameObject.GetComponent<Image>();
				break;
			case "p_skill1":
				_op_skill1 = transform.gameObject;
				_op_skillImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "p_skill2":
				_op_skill2 = transform.gameObject;
				_op_skillImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "p_skill3":
				_op_skill3 = transform.gameObject;
				_op_skillImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "p_skill4":
				_op_skill4 = transform.gameObject;
				_op_skillImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "p_skill5":
				_op_skill5 = transform.gameObject;
				_op_skillImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "HP_2":
				_oHP_2 = transform.gameObject;
				_oHP_Text2 = transform.gameObject.GetComponent<Text>();
				break;
			case "HD_2":
				_oHD_2 = transform.gameObject;
				_oHD_Text2 = transform.gameObject.GetComponent<Text>();
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

	public bool Getp_skillShow(int index)
	{
		return index switch
		{
			1 => p_skillShow1, 
			2 => p_skillShow2, 
			3 => p_skillShow3, 
			4 => p_skillShow4, 
			5 => p_skillShow5, 
			_ => false, 
		};
	}

	public void Setp_skillShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			p_skillShow1 = value;
			break;
		case 2:
			p_skillShow2 = value;
			break;
		case 3:
			p_skillShow3 = value;
			break;
		case 4:
			p_skillShow4 = value;
			break;
		case 5:
			p_skillShow5 = value;
			break;
		}
	}

	public int Getp_skillCount()
	{
		return 5;
	}

	public Sprite Getp_skillSprite(int index)
	{
		return index switch
		{
			1 => p_skillSprite1, 
			2 => p_skillSprite2, 
			3 => p_skillSprite3, 
			4 => p_skillSprite4, 
			5 => p_skillSprite5, 
			_ => null, 
		};
	}

	public void Setp_skillSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			p_skillSprite1 = value;
			break;
		case 2:
			p_skillSprite2 = value;
			break;
		case 3:
			p_skillSprite3 = value;
			break;
		case 4:
			p_skillSprite4 = value;
			break;
		case 5:
			p_skillSprite5 = value;
			break;
		}
	}

	public string GetHP_String(int index)
	{
		if (index == 2)
		{
			return HP_String2;
		}
		return null;
	}

	public void SetHP_String(int index, string value)
	{
		if (index == 2)
		{
			HP_String2 = value;
		}
	}

	public int GetHP_Count()
	{
		return 2;
	}

	public string GetHD_String(int index)
	{
		if (index == 2)
		{
			return HD_String2;
		}
		return null;
	}

	public void SetHD_String(int index, string value)
	{
		if (index == 2)
		{
			HD_String2 = value;
		}
	}

	public int GetHD_Count()
	{
		return 2;
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
