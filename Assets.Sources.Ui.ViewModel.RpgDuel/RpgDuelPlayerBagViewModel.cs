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

namespace Assets.Sources.Ui.ViewModel.RpgDuel;

[GameUiTest]
public class RpgDuelPlayerBagViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oNoWeapon;

	private GameObject _oNoPlayerCareer;

	private GameObject _oNoTacticalWeapon;

	private GameObject _oNoDragon;

	private GameObject _oWeapon;

	private Image _oWeaponImage;

	private GameObject _oPlayerCareer;

	private Image _oPlayerCareerImage;

	private GameObject _oTacticalWeapon;

	private Image _oTacticalWeaponImage;

	private GameObject _oDragon;

	private Image _oDragonImage;

	private GameObject _oSlot1;

	private GameObject _oSlot2;

	private GameObject _oSlot3;

	private EventTrigger _oSlotEventTrigger1;

	private EventTrigger _oSlotEventTrigger2;

	private EventTrigger _oSlotEventTrigger3;

	private Button _oSlotButton1;

	private Button _oSlotButton2;

	private Button _oSlotButton3;

	private GameObject _oSelectedSlot1;

	private GameObject _oSelectedSlot2;

	private GameObject _oSelectedSlot3;

	private EventTrigger _oSelectedSlotEventTrigger1;

	private EventTrigger _oSelectedSlotEventTrigger2;

	private EventTrigger _oSelectedSlotEventTrigger3;

	private Button _oSelectedSlotButton1;

	private Button _oSelectedSlotButton2;

	private Button _oSelectedSlotButton3;

	private GameObject _oDisabledSlot1;

	private GameObject _oDisabledSlot2;

	private GameObject _oDisabledSlot3;

	private GameObject _oChangeCount;

	private Text _oChangeCountText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgduel";

	private string _resourceAssetName = "rpgduelplayerbag";

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

	public bool NoWeaponShow
	{
		get
		{
			if (_oNoWeapon != null)
			{
				return _oNoWeapon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoWeaponShow != value && _oNoWeapon != null)
			{
				_oNoWeapon.SetObjectActive(value);
			}
		}
	}

	public bool NoPlayerCareerShow
	{
		get
		{
			if (_oNoPlayerCareer != null)
			{
				return _oNoPlayerCareer.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoPlayerCareerShow != value && _oNoPlayerCareer != null)
			{
				_oNoPlayerCareer.SetObjectActive(value);
			}
		}
	}

	public bool NoTacticalWeaponShow
	{
		get
		{
			if (_oNoTacticalWeapon != null)
			{
				return _oNoTacticalWeapon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoTacticalWeaponShow != value && _oNoTacticalWeapon != null)
			{
				_oNoTacticalWeapon.SetObjectActive(value);
			}
		}
	}

	public bool NoDragonShow
	{
		get
		{
			if (_oNoDragon != null)
			{
				return _oNoDragon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (NoDragonShow != value && _oNoDragon != null)
			{
				_oNoDragon.SetObjectActive(value);
			}
		}
	}

	public bool WeaponShow
	{
		get
		{
			if (_oWeapon != null)
			{
				return _oWeapon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow != value && _oWeapon != null)
			{
				_oWeapon.SetObjectActive(value);
			}
		}
	}

	public Sprite WeaponSprite
	{
		get
		{
			if (_oWeaponImage != null)
			{
				return _oWeaponImage.sprite;
			}
			return null;
		}
		set
		{
			if (WeaponSprite != value && _oWeaponImage != null)
			{
				_oWeaponImage.sprite = value;
			}
		}
	}

	public bool PlayerCareerShow
	{
		get
		{
			if (_oPlayerCareer != null)
			{
				return _oPlayerCareer.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerCareerShow != value && _oPlayerCareer != null)
			{
				_oPlayerCareer.SetObjectActive(value);
			}
		}
	}

	public Sprite PlayerCareerSprite
	{
		get
		{
			if (_oPlayerCareerImage != null)
			{
				return _oPlayerCareerImage.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerCareerSprite != value && _oPlayerCareerImage != null)
			{
				_oPlayerCareerImage.sprite = value;
			}
		}
	}

	public bool TacticalWeaponShow
	{
		get
		{
			if (_oTacticalWeapon != null)
			{
				return _oTacticalWeapon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TacticalWeaponShow != value && _oTacticalWeapon != null)
			{
				_oTacticalWeapon.SetObjectActive(value);
			}
		}
	}

	public Sprite TacticalWeaponSprite
	{
		get
		{
			if (_oTacticalWeaponImage != null)
			{
				return _oTacticalWeaponImage.sprite;
			}
			return null;
		}
		set
		{
			if (TacticalWeaponSprite != value && _oTacticalWeaponImage != null)
			{
				_oTacticalWeaponImage.sprite = value;
			}
		}
	}

	public bool DragonShow
	{
		get
		{
			if (_oDragon != null)
			{
				return _oDragon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DragonShow != value && _oDragon != null)
			{
				_oDragon.SetObjectActive(value);
			}
		}
	}

	public Sprite DragonSprite
	{
		get
		{
			if (_oDragonImage != null)
			{
				return _oDragonImage.sprite;
			}
			return null;
		}
		set
		{
			if (DragonSprite != value && _oDragonImage != null)
			{
				_oDragonImage.sprite = value;
			}
		}
	}

	public bool SlotShow1
	{
		get
		{
			if (_oSlot1 != null)
			{
				return _oSlot1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow1 != value && _oSlot1 != null)
			{
				_oSlot1.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow2
	{
		get
		{
			if (_oSlot2 != null)
			{
				return _oSlot2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow2 != value && _oSlot2 != null)
			{
				_oSlot2.SetObjectActive(value);
			}
		}
	}

	public bool SlotShow3
	{
		get
		{
			if (_oSlot3 != null)
			{
				return _oSlot3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlotShow3 != value && _oSlot3 != null)
			{
				_oSlot3.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> SlotTriggers1
	{
		get
		{
			if (_oSlotEventTrigger1 != null)
			{
				return _oSlotEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (SlotTriggers1 != value && _oSlotEventTrigger1 != null)
			{
				_oSlotEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SlotTriggers2
	{
		get
		{
			if (_oSlotEventTrigger2 != null)
			{
				return _oSlotEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (SlotTriggers2 != value && _oSlotEventTrigger2 != null)
			{
				_oSlotEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SlotTriggers3
	{
		get
		{
			if (_oSlotEventTrigger3 != null)
			{
				return _oSlotEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (SlotTriggers3 != value && _oSlotEventTrigger3 != null)
			{
				_oSlotEventTrigger3.triggers = value;
			}
		}
	}

	public bool SlotButtonable1
	{
		get
		{
			if (_oSlotButton1 != null)
			{
				return _oSlotButton1.interactable;
			}
			return true;
		}
		set
		{
			if (SlotButtonable1 != value && _oSlotButton1 != null)
			{
				_oSlotButton1.interactable = value;
			}
		}
	}

	public bool SlotButtonable2
	{
		get
		{
			if (_oSlotButton2 != null)
			{
				return _oSlotButton2.interactable;
			}
			return true;
		}
		set
		{
			if (SlotButtonable2 != value && _oSlotButton2 != null)
			{
				_oSlotButton2.interactable = value;
			}
		}
	}

	public bool SlotButtonable3
	{
		get
		{
			if (_oSlotButton3 != null)
			{
				return _oSlotButton3.interactable;
			}
			return true;
		}
		set
		{
			if (SlotButtonable3 != value && _oSlotButton3 != null)
			{
				_oSlotButton3.interactable = value;
			}
		}
	}

	public bool SelectedSlotShow1
	{
		get
		{
			if (_oSelectedSlot1 != null)
			{
				return _oSelectedSlot1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedSlotShow1 != value && _oSelectedSlot1 != null)
			{
				_oSelectedSlot1.SetObjectActive(value);
			}
		}
	}

	public bool SelectedSlotShow2
	{
		get
		{
			if (_oSelectedSlot2 != null)
			{
				return _oSelectedSlot2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedSlotShow2 != value && _oSelectedSlot2 != null)
			{
				_oSelectedSlot2.SetObjectActive(value);
			}
		}
	}

	public bool SelectedSlotShow3
	{
		get
		{
			if (_oSelectedSlot3 != null)
			{
				return _oSelectedSlot3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelectedSlotShow3 != value && _oSelectedSlot3 != null)
			{
				_oSelectedSlot3.SetObjectActive(value);
			}
		}
	}

	public List<EventTrigger.Entry> SelectedSlotTriggers1
	{
		get
		{
			if (_oSelectedSlotEventTrigger1 != null)
			{
				return _oSelectedSlotEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (SelectedSlotTriggers1 != value && _oSelectedSlotEventTrigger1 != null)
			{
				_oSelectedSlotEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectedSlotTriggers2
	{
		get
		{
			if (_oSelectedSlotEventTrigger2 != null)
			{
				return _oSelectedSlotEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (SelectedSlotTriggers2 != value && _oSelectedSlotEventTrigger2 != null)
			{
				_oSelectedSlotEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SelectedSlotTriggers3
	{
		get
		{
			if (_oSelectedSlotEventTrigger3 != null)
			{
				return _oSelectedSlotEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (SelectedSlotTriggers3 != value && _oSelectedSlotEventTrigger3 != null)
			{
				_oSelectedSlotEventTrigger3.triggers = value;
			}
		}
	}

	public bool SelectedSlotButtonable1
	{
		get
		{
			if (_oSelectedSlotButton1 != null)
			{
				return _oSelectedSlotButton1.interactable;
			}
			return true;
		}
		set
		{
			if (SelectedSlotButtonable1 != value && _oSelectedSlotButton1 != null)
			{
				_oSelectedSlotButton1.interactable = value;
			}
		}
	}

	public bool SelectedSlotButtonable2
	{
		get
		{
			if (_oSelectedSlotButton2 != null)
			{
				return _oSelectedSlotButton2.interactable;
			}
			return true;
		}
		set
		{
			if (SelectedSlotButtonable2 != value && _oSelectedSlotButton2 != null)
			{
				_oSelectedSlotButton2.interactable = value;
			}
		}
	}

	public bool SelectedSlotButtonable3
	{
		get
		{
			if (_oSelectedSlotButton3 != null)
			{
				return _oSelectedSlotButton3.interactable;
			}
			return true;
		}
		set
		{
			if (SelectedSlotButtonable3 != value && _oSelectedSlotButton3 != null)
			{
				_oSelectedSlotButton3.interactable = value;
			}
		}
	}

	public bool DisabledSlotShow1
	{
		get
		{
			if (_oDisabledSlot1 != null)
			{
				return _oDisabledSlot1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DisabledSlotShow1 != value && _oDisabledSlot1 != null)
			{
				_oDisabledSlot1.SetObjectActive(value);
			}
		}
	}

	public bool DisabledSlotShow2
	{
		get
		{
			if (_oDisabledSlot2 != null)
			{
				return _oDisabledSlot2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DisabledSlotShow2 != value && _oDisabledSlot2 != null)
			{
				_oDisabledSlot2.SetObjectActive(value);
			}
		}
	}

	public bool DisabledSlotShow3
	{
		get
		{
			if (_oDisabledSlot3 != null)
			{
				return _oDisabledSlot3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DisabledSlotShow3 != value && _oDisabledSlot3 != null)
			{
				_oDisabledSlot3.SetObjectActive(value);
			}
		}
	}

	public string ChangeCountString
	{
		get
		{
			if (_oChangeCountText != null)
			{
				return _oChangeCountText.text;
			}
			return null;
		}
		set
		{
			if (ChangeCountString != value && _oChangeCountText != null)
			{
				_oChangeCountText.text = value;
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
			case "NoWeapon":
				_oNoWeapon = transform.gameObject;
				break;
			case "NoPlayerCareer":
				_oNoPlayerCareer = transform.gameObject;
				break;
			case "NoTacticalWeapon":
				_oNoTacticalWeapon = transform.gameObject;
				break;
			case "NoDragon":
				_oNoDragon = transform.gameObject;
				break;
			case "Weapon":
				_oWeapon = transform.gameObject;
				_oWeaponImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerCareer":
				_oPlayerCareer = transform.gameObject;
				_oPlayerCareerImage = transform.gameObject.GetComponent<Image>();
				break;
			case "TacticalWeapon":
				_oTacticalWeapon = transform.gameObject;
				_oTacticalWeaponImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Dragon":
				_oDragon = transform.gameObject;
				_oDragonImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Slot1":
				_oSlot1 = transform.gameObject;
				_oSlotEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				_oSlotButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "Slot2":
				_oSlot2 = transform.gameObject;
				_oSlotEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				_oSlotButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "Slot3":
				_oSlot3 = transform.gameObject;
				_oSlotEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				_oSlotButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedSlot1":
				_oSelectedSlot1 = transform.gameObject;
				_oSelectedSlotEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				_oSelectedSlotButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedSlot2":
				_oSelectedSlot2 = transform.gameObject;
				_oSelectedSlotEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				_oSelectedSlotButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "SelectedSlot3":
				_oSelectedSlot3 = transform.gameObject;
				_oSelectedSlotEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				_oSelectedSlotButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "DisabledSlot1":
				_oDisabledSlot1 = transform.gameObject;
				break;
			case "DisabledSlot2":
				_oDisabledSlot2 = transform.gameObject;
				break;
			case "DisabledSlot3":
				_oDisabledSlot3 = transform.gameObject;
				break;
			case "ChangeCount":
				_oChangeCount = transform.gameObject;
				_oChangeCountText = transform.gameObject.GetComponent<Text>();
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

	public void WeaponNtvsize()
	{
		if (_oWeaponImage != null)
		{
			_oWeaponImage.SetNativeSize();
		}
	}

	public void TacticalWeaponNtvsize()
	{
		if (_oTacticalWeaponImage != null)
		{
			_oTacticalWeaponImage.SetNativeSize();
		}
	}

	public bool GetSlotShow(int index)
	{
		return index switch
		{
			1 => SlotShow1, 
			2 => SlotShow2, 
			3 => SlotShow3, 
			_ => false, 
		};
	}

	public void SetSlotShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SlotShow1 = value;
			break;
		case 2:
			SlotShow2 = value;
			break;
		case 3:
			SlotShow3 = value;
			break;
		}
	}

	public int GetSlotCount()
	{
		return 3;
	}

	private void CreateSlotTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SlotTriggers1, eventId, callback);
	}

	private void RemoveSlotTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SlotTriggers1, eventId);
	}

	private void CreateSlotTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SlotTriggers2, eventId, callback);
	}

	private void RemoveSlotTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SlotTriggers2, eventId);
	}

	private void CreateSlotTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SlotTriggers3, eventId, callback);
	}

	private void RemoveSlotTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SlotTriggers3, eventId);
	}

	public List<EventTrigger.Entry> GetSlotTriggers(int index)
	{
		return index switch
		{
			1 => SlotTriggers1, 
			2 => SlotTriggers2, 
			3 => SlotTriggers3, 
			_ => null, 
		};
	}

	public void SetSlotTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			SlotTriggers1 = value;
			break;
		case 2:
			SlotTriggers2 = value;
			break;
		case 3:
			SlotTriggers3 = value;
			break;
		}
	}

	private void CreateSlotTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetSlotTriggers(index), eventId, callback);
	}

	private void RemoveSlotTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetSlotTriggers(index), eventId);
	}

	public bool GetSlotButtonable(int index)
	{
		return index switch
		{
			1 => SlotButtonable1, 
			2 => SlotButtonable2, 
			3 => SlotButtonable3, 
			_ => true, 
		};
	}

	public void SetSlotButtonable(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SlotButtonable1 = value;
			break;
		case 2:
			SlotButtonable2 = value;
			break;
		case 3:
			SlotButtonable3 = value;
			break;
		}
	}

	public bool GetSelectedSlotShow(int index)
	{
		return index switch
		{
			1 => SelectedSlotShow1, 
			2 => SelectedSlotShow2, 
			3 => SelectedSlotShow3, 
			_ => false, 
		};
	}

	public void SetSelectedSlotShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectedSlotShow1 = value;
			break;
		case 2:
			SelectedSlotShow2 = value;
			break;
		case 3:
			SelectedSlotShow3 = value;
			break;
		}
	}

	public int GetSelectedSlotCount()
	{
		return 3;
	}

	private void CreateSelectedSlotTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SelectedSlotTriggers1, eventId, callback);
	}

	private void RemoveSelectedSlotTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SelectedSlotTriggers1, eventId);
	}

	private void CreateSelectedSlotTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SelectedSlotTriggers2, eventId, callback);
	}

	private void RemoveSelectedSlotTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SelectedSlotTriggers2, eventId);
	}

	private void CreateSelectedSlotTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SelectedSlotTriggers3, eventId, callback);
	}

	private void RemoveSelectedSlotTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SelectedSlotTriggers3, eventId);
	}

	public List<EventTrigger.Entry> GetSelectedSlotTriggers(int index)
	{
		return index switch
		{
			1 => SelectedSlotTriggers1, 
			2 => SelectedSlotTriggers2, 
			3 => SelectedSlotTriggers3, 
			_ => null, 
		};
	}

	public void SetSelectedSlotTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			SelectedSlotTriggers1 = value;
			break;
		case 2:
			SelectedSlotTriggers2 = value;
			break;
		case 3:
			SelectedSlotTriggers3 = value;
			break;
		}
	}

	private void CreateSelectedSlotTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetSelectedSlotTriggers(index), eventId, callback);
	}

	private void RemoveSelectedSlotTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetSelectedSlotTriggers(index), eventId);
	}

	public bool GetSelectedSlotButtonable(int index)
	{
		return index switch
		{
			1 => SelectedSlotButtonable1, 
			2 => SelectedSlotButtonable2, 
			3 => SelectedSlotButtonable3, 
			_ => true, 
		};
	}

	public void SetSelectedSlotButtonable(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SelectedSlotButtonable1 = value;
			break;
		case 2:
			SelectedSlotButtonable2 = value;
			break;
		case 3:
			SelectedSlotButtonable3 = value;
			break;
		}
	}

	public bool GetDisabledSlotShow(int index)
	{
		return index switch
		{
			1 => DisabledSlotShow1, 
			2 => DisabledSlotShow2, 
			3 => DisabledSlotShow3, 
			_ => false, 
		};
	}

	public void SetDisabledSlotShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			DisabledSlotShow1 = value;
			break;
		case 2:
			DisabledSlotShow2 = value;
			break;
		case 3:
			DisabledSlotShow3 = value;
			break;
		}
	}

	public int GetDisabledSlotCount()
	{
		return 3;
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
