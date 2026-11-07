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

namespace Assets.Sources.Ui.ViewModel.RpgTower;

[GameUiTest]
public class RpgTowerLevelUpPropertyMenuViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oSale;

	private EventTrigger _oSaleEventTrigger;

	private GameObject _oMove;

	private EventTrigger _oMoveEventTrigger;

	private GameObject _oLevelUp;

	private EventTrigger _oLevelUpEventTrigger;

	private GameObject _oClose;

	private EventTrigger _oCloseEventTrigger;

	private GameObject _oTitle;

	private Image _oTitleImage;

	private GameObject _oCount1;

	private GameObject _oCount2;

	private GameObject _oCount3;

	private GameObject _oCount4;

	private Text _oCountText1;

	private Text _oCountText2;

	private Text _oCountText3;

	private Text _oCountText4;

	private GameObject _oSkill1;

	private GameObject _oSkill2;

	private Image _oSkillImage1;

	private Image _oSkillImage2;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgtower";

	private string _resourceAssetName = "RpgTowerLevelUpPropertyMenu";

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

	public List<EventTrigger.Entry> SaleTriggers
	{
		get
		{
			if (_oSaleEventTrigger != null)
			{
				return _oSaleEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (SaleTriggers != value && _oSaleEventTrigger != null)
			{
				_oSaleEventTrigger.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> MoveTriggers
	{
		get
		{
			if (_oMoveEventTrigger != null)
			{
				return _oMoveEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (MoveTriggers != value && _oMoveEventTrigger != null)
			{
				_oMoveEventTrigger.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> LevelUpTriggers
	{
		get
		{
			if (_oLevelUpEventTrigger != null)
			{
				return _oLevelUpEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (LevelUpTriggers != value && _oLevelUpEventTrigger != null)
			{
				_oLevelUpEventTrigger.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> CloseTriggers
	{
		get
		{
			if (_oCloseEventTrigger != null)
			{
				return _oCloseEventTrigger.triggers;
			}
			return null;
		}
		set
		{
			if (CloseTriggers != value && _oCloseEventTrigger != null)
			{
				_oCloseEventTrigger.triggers = value;
			}
		}
	}

	public Sprite TitleSprite
	{
		get
		{
			if (_oTitleImage != null)
			{
				return _oTitleImage.sprite;
			}
			return null;
		}
		set
		{
			if (TitleSprite != value && _oTitleImage != null)
			{
				_oTitleImage.sprite = value;
			}
		}
	}

	public string CountString1
	{
		get
		{
			if (_oCountText1 != null)
			{
				return _oCountText1.text;
			}
			return null;
		}
		set
		{
			if (CountString1 != value && _oCountText1 != null)
			{
				_oCountText1.text = value;
			}
		}
	}

	public string CountString2
	{
		get
		{
			if (_oCountText2 != null)
			{
				return _oCountText2.text;
			}
			return null;
		}
		set
		{
			if (CountString2 != value && _oCountText2 != null)
			{
				_oCountText2.text = value;
			}
		}
	}

	public string CountString3
	{
		get
		{
			if (_oCountText3 != null)
			{
				return _oCountText3.text;
			}
			return null;
		}
		set
		{
			if (CountString3 != value && _oCountText3 != null)
			{
				_oCountText3.text = value;
			}
		}
	}

	public string CountString4
	{
		get
		{
			if (_oCountText4 != null)
			{
				return _oCountText4.text;
			}
			return null;
		}
		set
		{
			if (CountString4 != value && _oCountText4 != null)
			{
				_oCountText4.text = value;
			}
		}
	}

	public bool SkillShow1
	{
		get
		{
			if (_oSkill1 != null)
			{
				return _oSkill1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow1 != value && _oSkill1 != null)
			{
				_oSkill1.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow2
	{
		get
		{
			if (_oSkill2 != null)
			{
				return _oSkill2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow2 != value && _oSkill2 != null)
			{
				_oSkill2.SetObjectActive(value);
			}
		}
	}

	public Sprite SkillSprite1
	{
		get
		{
			if (_oSkillImage1 != null)
			{
				return _oSkillImage1.sprite;
			}
			return null;
		}
		set
		{
			if (SkillSprite1 != value && _oSkillImage1 != null)
			{
				_oSkillImage1.sprite = value;
			}
		}
	}

	public Sprite SkillSprite2
	{
		get
		{
			if (_oSkillImage2 != null)
			{
				return _oSkillImage2.sprite;
			}
			return null;
		}
		set
		{
			if (SkillSprite2 != value && _oSkillImage2 != null)
			{
				_oSkillImage2.sprite = value;
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
			case "Sale":
				_oSale = transform.gameObject;
				_oSaleEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Move":
				_oMove = transform.gameObject;
				_oMoveEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "LevelUp":
				_oLevelUp = transform.gameObject;
				_oLevelUpEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Close":
				_oClose = transform.gameObject;
				_oCloseEventTrigger = transform.gameObject.GetComponent<EventTrigger>();
				break;
			case "Title":
				_oTitle = transform.gameObject;
				_oTitleImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Count1":
				_oCount1 = transform.gameObject;
				_oCountText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Count2":
				_oCount2 = transform.gameObject;
				_oCountText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Count3":
				_oCount3 = transform.gameObject;
				_oCountText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Count4":
				_oCount4 = transform.gameObject;
				_oCountText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Skill1":
				_oSkill1 = transform.gameObject;
				_oSkillImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Skill2":
				_oSkill2 = transform.gameObject;
				_oSkillImage2 = transform.gameObject.GetComponent<Image>();
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

	private void CreateSaleTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SaleTriggers, eventId, callback);
	}

	private void RemoveSaleTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SaleTriggers, eventId);
	}

	private void CreateMoveTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(MoveTriggers, eventId, callback);
	}

	private void RemoveMoveTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(MoveTriggers, eventId);
	}

	private void CreateLevelUpTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(LevelUpTriggers, eventId, callback);
	}

	private void RemoveLevelUpTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(LevelUpTriggers, eventId);
	}

	private void CreateCloseTriggersEntry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(CloseTriggers, eventId, callback);
	}

	private void RemoveCloseTriggersEntry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(CloseTriggers, eventId);
	}

	public string GetCountString(int index)
	{
		return index switch
		{
			1 => CountString1, 
			2 => CountString2, 
			3 => CountString3, 
			4 => CountString4, 
			_ => null, 
		};
	}

	public void SetCountString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CountString1 = value;
			break;
		case 2:
			CountString2 = value;
			break;
		case 3:
			CountString3 = value;
			break;
		case 4:
			CountString4 = value;
			break;
		}
	}

	public int GetCountCount()
	{
		return 4;
	}

	public bool GetSkillShow(int index)
	{
		return index switch
		{
			1 => SkillShow1, 
			2 => SkillShow2, 
			_ => false, 
		};
	}

	public void SetSkillShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillShow1 = value;
			break;
		case 2:
			SkillShow2 = value;
			break;
		}
	}

	public int GetSkillCount()
	{
		return 2;
	}

	public Sprite GetSkillSprite(int index)
	{
		return index switch
		{
			1 => SkillSprite1, 
			2 => SkillSprite2, 
			_ => null, 
		};
	}

	public void SetSkillSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			SkillSprite1 = value;
			break;
		case 2:
			SkillSprite2 = value;
			break;
		}
	}

	public void SkillNtvsize1()
	{
		if (_oSkillImage1 != null)
		{
			_oSkillImage1.SetNativeSize();
		}
	}

	public void SkillNtvsize2()
	{
		if (_oSkillImage2 != null)
		{
			_oSkillImage2.SetNativeSize();
		}
	}

	public void CallSkillNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			SkillNtvsize1();
			break;
		case 2:
			SkillNtvsize2();
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
