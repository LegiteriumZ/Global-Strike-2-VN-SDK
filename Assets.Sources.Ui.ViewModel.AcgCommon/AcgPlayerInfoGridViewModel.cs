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
public class AcgPlayerInfoGridViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oPlayerIcon;

	private Image _oPlayerIconImage;

	private GameObject _oDeadIcon;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oDamageNumber;

	private Text _oDamageNumberText;

	private GameObject _oCoinNumber;

	private Text _oCoinNumberText;

	private GameObject _oWeaponIcon;

	private Image _oWeaponIconImage;

	private GameObject _oPowerUp0;

	private GameObject _oPowerUp1;

	private GameObject _oPowerUp2;

	private GameObject _oPowerUp3;

	private Image _oPowerUpImage0;

	private Image _oPowerUpImage1;

	private Image _oPowerUpImage2;

	private Image _oPowerUpImage3;

	private GameObject _oBack0;

	private GameObject _oBack1;

	private GameObject _oBack2;

	private GameObject _oBack3;

	private GameObject _oNumber0;

	private GameObject _oNumber1;

	private GameObject _oNumber2;

	private GameObject _oNumber3;

	private Text _oNumberText0;

	private Text _oNumberText1;

	private Text _oNumberText2;

	private Text _oNumberText3;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgplayerinfogrid";

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

	public string DamageNumberString
	{
		get
		{
			if (_oDamageNumberText != null)
			{
				return _oDamageNumberText.text;
			}
			return null;
		}
		set
		{
			if (DamageNumberString != value && _oDamageNumberText != null)
			{
				_oDamageNumberText.text = value;
			}
		}
	}

	public string CoinNumberString
	{
		get
		{
			if (_oCoinNumberText != null)
			{
				return _oCoinNumberText.text;
			}
			return null;
		}
		set
		{
			if (CoinNumberString != value && _oCoinNumberText != null)
			{
				_oCoinNumberText.text = value;
			}
		}
	}

	public Image WeaponIconImage
	{
		get
		{
			if (_oWeaponIconImage != null)
			{
				return _oWeaponIconImage;
			}
			return null;
		}
		set
		{
			if (WeaponIconImage != value && _oWeaponIconImage != null)
			{
				_oWeaponIconImage = value;
			}
		}
	}

	public Image PowerUpImage0
	{
		get
		{
			if (_oPowerUpImage0 != null)
			{
				return _oPowerUpImage0;
			}
			return null;
		}
		set
		{
			if (PowerUpImage0 != value && _oPowerUpImage0 != null)
			{
				_oPowerUpImage0 = value;
			}
		}
	}

	public Image PowerUpImage1
	{
		get
		{
			if (_oPowerUpImage1 != null)
			{
				return _oPowerUpImage1;
			}
			return null;
		}
		set
		{
			if (PowerUpImage1 != value && _oPowerUpImage1 != null)
			{
				_oPowerUpImage1 = value;
			}
		}
	}

	public Image PowerUpImage2
	{
		get
		{
			if (_oPowerUpImage2 != null)
			{
				return _oPowerUpImage2;
			}
			return null;
		}
		set
		{
			if (PowerUpImage2 != value && _oPowerUpImage2 != null)
			{
				_oPowerUpImage2 = value;
			}
		}
	}

	public Image PowerUpImage3
	{
		get
		{
			if (_oPowerUpImage3 != null)
			{
				return _oPowerUpImage3;
			}
			return null;
		}
		set
		{
			if (PowerUpImage3 != value && _oPowerUpImage3 != null)
			{
				_oPowerUpImage3 = value;
			}
		}
	}

	public bool BackShow0
	{
		get
		{
			if (_oBack0 != null)
			{
				return _oBack0.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackShow0 != value && _oBack0 != null)
			{
				_oBack0.SetObjectActive(value);
			}
		}
	}

	public bool BackShow1
	{
		get
		{
			if (_oBack1 != null)
			{
				return _oBack1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackShow1 != value && _oBack1 != null)
			{
				_oBack1.SetObjectActive(value);
			}
		}
	}

	public bool BackShow2
	{
		get
		{
			if (_oBack2 != null)
			{
				return _oBack2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackShow2 != value && _oBack2 != null)
			{
				_oBack2.SetObjectActive(value);
			}
		}
	}

	public bool BackShow3
	{
		get
		{
			if (_oBack3 != null)
			{
				return _oBack3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackShow3 != value && _oBack3 != null)
			{
				_oBack3.SetObjectActive(value);
			}
		}
	}

	public bool NumberShow0
	{
		get
		{
			if (_oNumber0 != null)
			{
				return _oNumber0.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NumberShow0 != value && _oNumber0 != null)
			{
				_oNumber0.SetObjectActive(value);
			}
		}
	}

	public bool NumberShow1
	{
		get
		{
			if (_oNumber1 != null)
			{
				return _oNumber1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NumberShow1 != value && _oNumber1 != null)
			{
				_oNumber1.SetObjectActive(value);
			}
		}
	}

	public bool NumberShow2
	{
		get
		{
			if (_oNumber2 != null)
			{
				return _oNumber2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NumberShow2 != value && _oNumber2 != null)
			{
				_oNumber2.SetObjectActive(value);
			}
		}
	}

	public bool NumberShow3
	{
		get
		{
			if (_oNumber3 != null)
			{
				return _oNumber3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NumberShow3 != value && _oNumber3 != null)
			{
				_oNumber3.SetObjectActive(value);
			}
		}
	}

	public string NumberString0
	{
		get
		{
			if (_oNumberText0 != null)
			{
				return _oNumberText0.text;
			}
			return null;
		}
		set
		{
			if (NumberString0 != value && _oNumberText0 != null)
			{
				_oNumberText0.text = value;
			}
		}
	}

	public string NumberString1
	{
		get
		{
			if (_oNumberText1 != null)
			{
				return _oNumberText1.text;
			}
			return null;
		}
		set
		{
			if (NumberString1 != value && _oNumberText1 != null)
			{
				_oNumberText1.text = value;
			}
		}
	}

	public string NumberString2
	{
		get
		{
			if (_oNumberText2 != null)
			{
				return _oNumberText2.text;
			}
			return null;
		}
		set
		{
			if (NumberString2 != value && _oNumberText2 != null)
			{
				_oNumberText2.text = value;
			}
		}
	}

	public string NumberString3
	{
		get
		{
			if (_oNumberText3 != null)
			{
				return _oNumberText3.text;
			}
			return null;
		}
		set
		{
			if (NumberString3 != value && _oNumberText3 != null)
			{
				_oNumberText3.text = value;
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
			case "PlayerIcon":
				_oPlayerIcon = transform.gameObject;
				_oPlayerIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "DeadIcon":
				_oDeadIcon = transform.gameObject;
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "DamageNumber":
				_oDamageNumber = transform.gameObject;
				_oDamageNumberText = transform.gameObject.GetComponent<Text>();
				break;
			case "CoinNumber":
				_oCoinNumber = transform.gameObject;
				_oCoinNumberText = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponIcon":
				_oWeaponIcon = transform.gameObject;
				_oWeaponIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PowerUp0":
				_oPowerUp0 = transform.gameObject;
				_oPowerUpImage0 = transform.gameObject.GetComponent<Image>();
				break;
			case "PowerUp1":
				_oPowerUp1 = transform.gameObject;
				_oPowerUpImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "PowerUp2":
				_oPowerUp2 = transform.gameObject;
				_oPowerUpImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "PowerUp3":
				_oPowerUp3 = transform.gameObject;
				_oPowerUpImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Back0":
				_oBack0 = transform.gameObject;
				break;
			case "Back1":
				_oBack1 = transform.gameObject;
				break;
			case "Back2":
				_oBack2 = transform.gameObject;
				break;
			case "Back3":
				_oBack3 = transform.gameObject;
				break;
			case "Number0":
				_oNumber0 = transform.gameObject;
				_oNumberText0 = transform.gameObject.GetComponent<Text>();
				break;
			case "Number1":
				_oNumber1 = transform.gameObject;
				_oNumberText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Number2":
				_oNumber2 = transform.gameObject;
				_oNumberText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Number3":
				_oNumber3 = transform.gameObject;
				_oNumberText3 = transform.gameObject.GetComponent<Text>();
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

	public Image GetPowerUpImage(int index)
	{
		return index switch
		{
			0 => PowerUpImage0, 
			1 => PowerUpImage1, 
			2 => PowerUpImage2, 
			3 => PowerUpImage3, 
			_ => null, 
		};
	}

	public void SetPowerUpImage(int index, Image value)
	{
		switch (index)
		{
		case 0:
			PowerUpImage0 = value;
			break;
		case 1:
			PowerUpImage1 = value;
			break;
		case 2:
			PowerUpImage2 = value;
			break;
		case 3:
			PowerUpImage3 = value;
			break;
		}
	}

	public int GetPowerUpCount()
	{
		return 3;
	}

	public bool GetBackShow(int index)
	{
		return index switch
		{
			0 => BackShow0, 
			1 => BackShow1, 
			2 => BackShow2, 
			3 => BackShow3, 
			_ => false, 
		};
	}

	public void SetBackShow(int index, bool value)
	{
		switch (index)
		{
		case 0:
			BackShow0 = value;
			break;
		case 1:
			BackShow1 = value;
			break;
		case 2:
			BackShow2 = value;
			break;
		case 3:
			BackShow3 = value;
			break;
		}
	}

	public int GetBackCount()
	{
		return 3;
	}

	public bool GetNumberShow(int index)
	{
		return index switch
		{
			0 => NumberShow0, 
			1 => NumberShow1, 
			2 => NumberShow2, 
			3 => NumberShow3, 
			_ => false, 
		};
	}

	public void SetNumberShow(int index, bool value)
	{
		switch (index)
		{
		case 0:
			NumberShow0 = value;
			break;
		case 1:
			NumberShow1 = value;
			break;
		case 2:
			NumberShow2 = value;
			break;
		case 3:
			NumberShow3 = value;
			break;
		}
	}

	public int GetNumberCount()
	{
		return 3;
	}

	public string GetNumberString(int index)
	{
		return index switch
		{
			0 => NumberString0, 
			1 => NumberString1, 
			2 => NumberString2, 
			3 => NumberString3, 
			_ => null, 
		};
	}

	public void SetNumberString(int index, string value)
	{
		switch (index)
		{
		case 0:
			NumberString0 = value;
			break;
		case 1:
			NumberString1 = value;
			break;
		case 2:
			NumberString2 = value;
			break;
		case 3:
			NumberString3 = value;
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
