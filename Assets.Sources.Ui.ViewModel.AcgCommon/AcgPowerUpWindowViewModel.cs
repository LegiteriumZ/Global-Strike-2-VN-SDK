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
public class AcgPowerUpWindowViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oSelectedFrame;

	private RectTransform _oSelectedFrameRectTransform;

	private GameObject _oPowerUp0;

	private GameObject _oPowerUp1;

	private GameObject _oPowerUp2;

	private Image _oPowerUpImage0;

	private Image _oPowerUpImage1;

	private Image _oPowerUpImage2;

	private EventTrigger _oPowerUpEventTrigger0;

	private EventTrigger _oPowerUpEventTrigger1;

	private EventTrigger _oPowerUpEventTrigger2;

	private Button _oPowerUpButton0;

	private Button _oPowerUpButton1;

	private Button _oPowerUpButton2;

	private GameObject _oIcon0;

	private GameObject _oIcon1;

	private GameObject _oIcon2;

	private Image _oIconImage0;

	private Image _oIconImage1;

	private Image _oIconImage2;

	private GameObject _oName0;

	private GameObject _oName1;

	private GameObject _oName2;

	private Text _oNameText0;

	private Text _oNameText1;

	private Text _oNameText2;

	private GameObject _oDiscription0;

	private GameObject _oDiscription1;

	private GameObject _oDiscription2;

	private Text _oDiscriptionText0;

	private Text _oDiscriptionText1;

	private Text _oDiscriptionText2;

	private GameObject _oCommonText;

	private Text _oCommonTextText;

	private GameObject _oWeaponText;

	private Text _oWeaponTextText;

	private GameObject _oCharacterText;

	private Text _oCharacterTextText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgpowerupwindow";

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

	public bool SelectedFrameShow
	{
		get
		{
			if (_oSelectedFrame != null)
			{
				return _oSelectedFrame.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedFrameShow != value && _oSelectedFrame != null)
			{
				_oSelectedFrame.SetObjectActive(value);
			}
		}
	}

	public Vector2 SelectedFrameAnchoredposition
	{
		get
		{
			if (_oSelectedFrameRectTransform != null)
			{
				return _oSelectedFrameRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (SelectedFrameAnchoredposition != value && _oSelectedFrameRectTransform != null)
			{
				_oSelectedFrameRectTransform.anchoredPosition = value;
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

	public List<EventTrigger.Entry> PowerUpTriggers0
	{
		get
		{
			if (_oPowerUpEventTrigger0 != null)
			{
				return _oPowerUpEventTrigger0.triggers;
			}
			return null;
		}
		set
		{
			if (PowerUpTriggers0 != value && _oPowerUpEventTrigger0 != null)
			{
				_oPowerUpEventTrigger0.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PowerUpTriggers1
	{
		get
		{
			if (_oPowerUpEventTrigger1 != null)
			{
				return _oPowerUpEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (PowerUpTriggers1 != value && _oPowerUpEventTrigger1 != null)
			{
				_oPowerUpEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> PowerUpTriggers2
	{
		get
		{
			if (_oPowerUpEventTrigger2 != null)
			{
				return _oPowerUpEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (PowerUpTriggers2 != value && _oPowerUpEventTrigger2 != null)
			{
				_oPowerUpEventTrigger2.triggers = value;
			}
		}
	}

	public Button.ButtonClickedEvent PowerUpClicked0
	{
		get
		{
			if (_oPowerUpButton0 != null)
			{
				return _oPowerUpButton0.onClick;
			}
			return null;
		}
		set
		{
			if (PowerUpClicked0 != value && _oPowerUpButton0 != null)
			{
				_oPowerUpButton0.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PowerUpClicked1
	{
		get
		{
			if (_oPowerUpButton1 != null)
			{
				return _oPowerUpButton1.onClick;
			}
			return null;
		}
		set
		{
			if (PowerUpClicked1 != value && _oPowerUpButton1 != null)
			{
				_oPowerUpButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent PowerUpClicked2
	{
		get
		{
			if (_oPowerUpButton2 != null)
			{
				return _oPowerUpButton2.onClick;
			}
			return null;
		}
		set
		{
			if (PowerUpClicked2 != value && _oPowerUpButton2 != null)
			{
				_oPowerUpButton2.onClick = value;
			}
		}
	}

	public Button PowerUpButton0
	{
		get
		{
			if (_oPowerUpButton0 != null)
			{
				return _oPowerUpButton0;
			}
			return null;
		}
		set
		{
			if (PowerUpButton0 != value && _oPowerUpButton0 != null)
			{
				_oPowerUpButton0 = value;
			}
		}
	}

	public Button PowerUpButton1
	{
		get
		{
			if (_oPowerUpButton1 != null)
			{
				return _oPowerUpButton1;
			}
			return null;
		}
		set
		{
			if (PowerUpButton1 != value && _oPowerUpButton1 != null)
			{
				_oPowerUpButton1 = value;
			}
		}
	}

	public Button PowerUpButton2
	{
		get
		{
			if (_oPowerUpButton2 != null)
			{
				return _oPowerUpButton2;
			}
			return null;
		}
		set
		{
			if (PowerUpButton2 != value && _oPowerUpButton2 != null)
			{
				_oPowerUpButton2 = value;
			}
		}
	}

	public Sprite IconSprite0
	{
		get
		{
			if (_oIconImage0 != null)
			{
				return _oIconImage0.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite0 != value && _oIconImage0 != null)
			{
				_oIconImage0.sprite = value;
			}
		}
	}

	public Sprite IconSprite1
	{
		get
		{
			if (_oIconImage1 != null)
			{
				return _oIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite1 != value && _oIconImage1 != null)
			{
				_oIconImage1.sprite = value;
			}
		}
	}

	public Sprite IconSprite2
	{
		get
		{
			if (_oIconImage2 != null)
			{
				return _oIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite2 != value && _oIconImage2 != null)
			{
				_oIconImage2.sprite = value;
			}
		}
	}

	public string NameString0
	{
		get
		{
			if (_oNameText0 != null)
			{
				return _oNameText0.text;
			}
			return null;
		}
		set
		{
			if (NameString0 != value && _oNameText0 != null)
			{
				_oNameText0.text = value;
			}
		}
	}

	public string NameString1
	{
		get
		{
			if (_oNameText1 != null)
			{
				return _oNameText1.text;
			}
			return null;
		}
		set
		{
			if (NameString1 != value && _oNameText1 != null)
			{
				_oNameText1.text = value;
			}
		}
	}

	public string NameString2
	{
		get
		{
			if (_oNameText2 != null)
			{
				return _oNameText2.text;
			}
			return null;
		}
		set
		{
			if (NameString2 != value && _oNameText2 != null)
			{
				_oNameText2.text = value;
			}
		}
	}

	public string DiscriptionString0
	{
		get
		{
			if (_oDiscriptionText0 != null)
			{
				return _oDiscriptionText0.text;
			}
			return null;
		}
		set
		{
			if (DiscriptionString0 != value && _oDiscriptionText0 != null)
			{
				_oDiscriptionText0.text = value;
			}
		}
	}

	public string DiscriptionString1
	{
		get
		{
			if (_oDiscriptionText1 != null)
			{
				return _oDiscriptionText1.text;
			}
			return null;
		}
		set
		{
			if (DiscriptionString1 != value && _oDiscriptionText1 != null)
			{
				_oDiscriptionText1.text = value;
			}
		}
	}

	public string DiscriptionString2
	{
		get
		{
			if (_oDiscriptionText2 != null)
			{
				return _oDiscriptionText2.text;
			}
			return null;
		}
		set
		{
			if (DiscriptionString2 != value && _oDiscriptionText2 != null)
			{
				_oDiscriptionText2.text = value;
			}
		}
	}

	public string CommonTextString
	{
		get
		{
			if (_oCommonTextText != null)
			{
				return _oCommonTextText.text;
			}
			return null;
		}
		set
		{
			if (CommonTextString != value && _oCommonTextText != null)
			{
				_oCommonTextText.text = value;
			}
		}
	}

	public string WeaponTextString
	{
		get
		{
			if (_oWeaponTextText != null)
			{
				return _oWeaponTextText.text;
			}
			return null;
		}
		set
		{
			if (WeaponTextString != value && _oWeaponTextText != null)
			{
				_oWeaponTextText.text = value;
			}
		}
	}

	public string CharacterTextString
	{
		get
		{
			if (_oCharacterTextText != null)
			{
				return _oCharacterTextText.text;
			}
			return null;
		}
		set
		{
			if (CharacterTextString != value && _oCharacterTextText != null)
			{
				_oCharacterTextText.text = value;
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
			case "SelectedFrame":
				_oSelectedFrame = transform.gameObject;
				_oSelectedFrameRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "PowerUp0":
				_oPowerUp0 = transform.gameObject;
				_oPowerUpImage0 = transform.gameObject.GetComponent<Image>();
				_oPowerUpEventTrigger0 = transform.gameObject.GetComponent<EventTrigger>();
				_oPowerUpButton0 = transform.gameObject.GetComponent<Button>();
				break;
			case "PowerUp1":
				_oPowerUp1 = transform.gameObject;
				_oPowerUpImage1 = transform.gameObject.GetComponent<Image>();
				_oPowerUpEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				_oPowerUpButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "PowerUp2":
				_oPowerUp2 = transform.gameObject;
				_oPowerUpImage2 = transform.gameObject.GetComponent<Image>();
				_oPowerUpEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				_oPowerUpButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "Icon0":
				_oIcon0 = transform.gameObject;
				_oIconImage0 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon1":
				_oIcon1 = transform.gameObject;
				_oIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon2":
				_oIcon2 = transform.gameObject;
				_oIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Name0":
				_oName0 = transform.gameObject;
				_oNameText0 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name1":
				_oName1 = transform.gameObject;
				_oNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name2":
				_oName2 = transform.gameObject;
				_oNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Discription0":
				_oDiscription0 = transform.gameObject;
				_oDiscriptionText0 = transform.gameObject.GetComponent<Text>();
				break;
			case "Discription1":
				_oDiscription1 = transform.gameObject;
				_oDiscriptionText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Discription2":
				_oDiscription2 = transform.gameObject;
				_oDiscriptionText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CommonText":
				_oCommonText = transform.gameObject;
				_oCommonTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponText":
				_oWeaponText = transform.gameObject;
				_oWeaponTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "CharacterText":
				_oCharacterText = transform.gameObject;
				_oCharacterTextText = transform.gameObject.GetComponent<Text>();
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
		}
	}

	public int GetPowerUpCount()
	{
		return 2;
	}

	public void PowerUpNtvsize0()
	{
		if (_oPowerUpImage0 != null)
		{
			_oPowerUpImage0.SetNativeSize();
		}
	}

	public void PowerUpNtvsize1()
	{
		if (_oPowerUpImage1 != null)
		{
			_oPowerUpImage1.SetNativeSize();
		}
	}

	public void PowerUpNtvsize2()
	{
		if (_oPowerUpImage2 != null)
		{
			_oPowerUpImage2.SetNativeSize();
		}
	}

	public void CallPowerUpNtvsize(int index)
	{
		switch (index)
		{
		case 0:
			PowerUpNtvsize0();
			break;
		case 1:
			PowerUpNtvsize1();
			break;
		case 2:
			PowerUpNtvsize2();
			break;
		}
	}

	private void CreatePowerUpTriggers0Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(PowerUpTriggers0, eventId, callback);
	}

	private void RemovePowerUpTriggers0Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(PowerUpTriggers0, eventId);
	}

	private void CreatePowerUpTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(PowerUpTriggers1, eventId, callback);
	}

	private void RemovePowerUpTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(PowerUpTriggers1, eventId);
	}

	private void CreatePowerUpTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(PowerUpTriggers2, eventId, callback);
	}

	private void RemovePowerUpTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(PowerUpTriggers2, eventId);
	}

	public List<EventTrigger.Entry> GetPowerUpTriggers(int index)
	{
		return index switch
		{
			0 => PowerUpTriggers0, 
			1 => PowerUpTriggers1, 
			2 => PowerUpTriggers2, 
			_ => null, 
		};
	}

	public void SetPowerUpTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 0:
			PowerUpTriggers0 = value;
			break;
		case 1:
			PowerUpTriggers1 = value;
			break;
		case 2:
			PowerUpTriggers2 = value;
			break;
		}
	}

	private void CreatePowerUpTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetPowerUpTriggers(index), eventId, callback);
	}

	private void RemovePowerUpTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetPowerUpTriggers(index), eventId);
	}

	public Button.ButtonClickedEvent GetPowerUpClicked(int index)
	{
		return index switch
		{
			0 => PowerUpClicked0, 
			1 => PowerUpClicked1, 
			2 => PowerUpClicked2, 
			_ => null, 
		};
	}

	public void SetPowerUpClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 0:
			PowerUpClicked0 = value;
			break;
		case 1:
			PowerUpClicked1 = value;
			break;
		case 2:
			PowerUpClicked2 = value;
			break;
		}
	}

	public Button GetPowerUpButton(int index)
	{
		return index switch
		{
			0 => PowerUpButton0, 
			1 => PowerUpButton1, 
			2 => PowerUpButton2, 
			_ => null, 
		};
	}

	public void SetPowerUpButton(int index, Button value)
	{
		switch (index)
		{
		case 0:
			PowerUpButton0 = value;
			break;
		case 1:
			PowerUpButton1 = value;
			break;
		case 2:
			PowerUpButton2 = value;
			break;
		}
	}

	public Sprite GetIconSprite(int index)
	{
		return index switch
		{
			0 => IconSprite0, 
			1 => IconSprite1, 
			2 => IconSprite2, 
			_ => null, 
		};
	}

	public void SetIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 0:
			IconSprite0 = value;
			break;
		case 1:
			IconSprite1 = value;
			break;
		case 2:
			IconSprite2 = value;
			break;
		}
	}

	public int GetIconCount()
	{
		return 2;
	}

	public string GetNameString(int index)
	{
		return index switch
		{
			0 => NameString0, 
			1 => NameString1, 
			2 => NameString2, 
			_ => null, 
		};
	}

	public void SetNameString(int index, string value)
	{
		switch (index)
		{
		case 0:
			NameString0 = value;
			break;
		case 1:
			NameString1 = value;
			break;
		case 2:
			NameString2 = value;
			break;
		}
	}

	public int GetNameCount()
	{
		return 2;
	}

	public string GetDiscriptionString(int index)
	{
		return index switch
		{
			0 => DiscriptionString0, 
			1 => DiscriptionString1, 
			2 => DiscriptionString2, 
			_ => null, 
		};
	}

	public void SetDiscriptionString(int index, string value)
	{
		switch (index)
		{
		case 0:
			DiscriptionString0 = value;
			break;
		case 1:
			DiscriptionString1 = value;
			break;
		case 2:
			DiscriptionString2 = value;
			break;
		}
	}

	public int GetDiscriptionCount()
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
