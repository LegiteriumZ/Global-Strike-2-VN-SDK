using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.PveCommon;

[GameUiTest]
public class PveAllKillInfoViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPveAllKillInfo;

	private GameObject _oShow;

	private GameObject _oRoomName;

	private Text _oRoomNameText;

	private GameObject _oPlayerCount;

	private Text _oPlayerCountText;

	private GameObject _oTeamGrid;

	private GameObject _oLoot1;

	private GameObject _oLoot2;

	private GameObject _oLoot3;

	private GameObject _oLoot4;

	private RectTransform _oLootRectTransform1;

	private RectTransform _oLootRectTransform2;

	private RectTransform _oLootRectTransform3;

	private RectTransform _oLootRectTransform4;

	private Image _oLootImage1;

	private Image _oLootImage2;

	private Image _oLootImage3;

	private Image _oLootImage4;

	private GameObject _oTitle;

	private Image _oTitleImage;

	private GameObject _oResult;

	private GameObject _oButtonExit;

	private Button _oButtonExitButton;

	private GameObject _oButtonContinue;

	private Button _oButtonContinueButton;

	private GameObject _oCountDown;

	private Text _oCountDownText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/pvecommon";

	private string _resourceAssetName = "PveAllKillInfo";

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

	public bool PveAllKillInfoShow
	{
		get
		{
			if (_oPveAllKillInfo != null)
			{
				return _oPveAllKillInfo.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PveAllKillInfoShow != value && _oPveAllKillInfo != null)
			{
				_oPveAllKillInfo.SetObjectActive(value);
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

	public string RoomNameString
	{
		get
		{
			if (_oRoomNameText != null)
			{
				return _oRoomNameText.text;
			}
			return null;
		}
		set
		{
			if (RoomNameString != value && _oRoomNameText != null)
			{
				_oRoomNameText.text = value;
			}
		}
	}

	public string PlayerCountString
	{
		get
		{
			if (_oPlayerCountText != null)
			{
				return _oPlayerCountText.text;
			}
			return null;
		}
		set
		{
			if (PlayerCountString != value && _oPlayerCountText != null)
			{
				_oPlayerCountText.text = value;
			}
		}
	}

	public GameObject TeamGridObj => _oTeamGrid;

	public bool LootShow1
	{
		get
		{
			if (_oLoot1 != null)
			{
				return _oLoot1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LootShow1 != value && _oLoot1 != null)
			{
				_oLoot1.SetObjectActive(value);
			}
		}
	}

	public bool LootShow2
	{
		get
		{
			if (_oLoot2 != null)
			{
				return _oLoot2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LootShow2 != value && _oLoot2 != null)
			{
				_oLoot2.SetObjectActive(value);
			}
		}
	}

	public bool LootShow3
	{
		get
		{
			if (_oLoot3 != null)
			{
				return _oLoot3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LootShow3 != value && _oLoot3 != null)
			{
				_oLoot3.SetObjectActive(value);
			}
		}
	}

	public bool LootShow4
	{
		get
		{
			if (_oLoot4 != null)
			{
				return _oLoot4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LootShow4 != value && _oLoot4 != null)
			{
				_oLoot4.SetObjectActive(value);
			}
		}
	}

	public Vector2 LootAnchoredposition1
	{
		get
		{
			if (_oLootRectTransform1 != null)
			{
				return _oLootRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (LootAnchoredposition1 != value && _oLootRectTransform1 != null)
			{
				_oLootRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 LootAnchoredposition2
	{
		get
		{
			if (_oLootRectTransform2 != null)
			{
				return _oLootRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (LootAnchoredposition2 != value && _oLootRectTransform2 != null)
			{
				_oLootRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector2 LootAnchoredposition3
	{
		get
		{
			if (_oLootRectTransform3 != null)
			{
				return _oLootRectTransform3.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (LootAnchoredposition3 != value && _oLootRectTransform3 != null)
			{
				_oLootRectTransform3.anchoredPosition = value;
			}
		}
	}

	public Vector2 LootAnchoredposition4
	{
		get
		{
			if (_oLootRectTransform4 != null)
			{
				return _oLootRectTransform4.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (LootAnchoredposition4 != value && _oLootRectTransform4 != null)
			{
				_oLootRectTransform4.anchoredPosition = value;
			}
		}
	}

	public Sprite LootSprite1
	{
		get
		{
			if (_oLootImage1 != null)
			{
				return _oLootImage1.sprite;
			}
			return null;
		}
		set
		{
			if (LootSprite1 != value && _oLootImage1 != null)
			{
				_oLootImage1.sprite = value;
			}
		}
	}

	public Sprite LootSprite2
	{
		get
		{
			if (_oLootImage2 != null)
			{
				return _oLootImage2.sprite;
			}
			return null;
		}
		set
		{
			if (LootSprite2 != value && _oLootImage2 != null)
			{
				_oLootImage2.sprite = value;
			}
		}
	}

	public Sprite LootSprite3
	{
		get
		{
			if (_oLootImage3 != null)
			{
				return _oLootImage3.sprite;
			}
			return null;
		}
		set
		{
			if (LootSprite3 != value && _oLootImage3 != null)
			{
				_oLootImage3.sprite = value;
			}
		}
	}

	public Sprite LootSprite4
	{
		get
		{
			if (_oLootImage4 != null)
			{
				return _oLootImage4.sprite;
			}
			return null;
		}
		set
		{
			if (LootSprite4 != value && _oLootImage4 != null)
			{
				_oLootImage4.sprite = value;
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

	public bool ResultShow
	{
		get
		{
			if (_oResult != null)
			{
				return _oResult.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ResultShow != value && _oResult != null)
			{
				_oResult.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent ButtonExitClicked
	{
		get
		{
			if (_oButtonExitButton != null)
			{
				return _oButtonExitButton.onClick;
			}
			return null;
		}
		set
		{
			if (ButtonExitClicked != value && _oButtonExitButton != null)
			{
				_oButtonExitButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent ButtonContinueClicked
	{
		get
		{
			if (_oButtonContinueButton != null)
			{
				return _oButtonContinueButton.onClick;
			}
			return null;
		}
		set
		{
			if (ButtonContinueClicked != value && _oButtonContinueButton != null)
			{
				_oButtonContinueButton.onClick = value;
			}
		}
	}

	public string CountDownString
	{
		get
		{
			if (_oCountDownText != null)
			{
				return _oCountDownText.text;
			}
			return null;
		}
		set
		{
			if (CountDownString != value && _oCountDownText != null)
			{
				_oCountDownText.text = value;
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
			case "PveAllKillInfo":
				_oPveAllKillInfo = transform.gameObject;
				break;
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "RoomName":
				_oRoomName = transform.gameObject;
				_oRoomNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerCount":
				_oPlayerCount = transform.gameObject;
				_oPlayerCountText = transform.gameObject.GetComponent<Text>();
				break;
			case "TeamGrid":
				_oTeamGrid = transform.gameObject;
				break;
			case "Loot1":
				_oLoot1 = transform.gameObject;
				_oLootRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oLootImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Loot2":
				_oLoot2 = transform.gameObject;
				_oLootRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oLootImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Loot3":
				_oLoot3 = transform.gameObject;
				_oLootRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oLootImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Loot4":
				_oLoot4 = transform.gameObject;
				_oLootRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oLootImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Title":
				_oTitle = transform.gameObject;
				_oTitleImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Result":
				_oResult = transform.gameObject;
				break;
			case "ButtonExit":
				_oButtonExit = transform.gameObject;
				_oButtonExitButton = transform.gameObject.GetComponent<Button>();
				break;
			case "ButtonContinue":
				_oButtonContinue = transform.gameObject;
				_oButtonContinueButton = transform.gameObject.GetComponent<Button>();
				break;
			case "CountDown":
				_oCountDown = transform.gameObject;
				_oCountDownText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetLootShow(int index)
	{
		return index switch
		{
			1 => LootShow1, 
			2 => LootShow2, 
			3 => LootShow3, 
			4 => LootShow4, 
			_ => false, 
		};
	}

	public void SetLootShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LootShow1 = value;
			break;
		case 2:
			LootShow2 = value;
			break;
		case 3:
			LootShow3 = value;
			break;
		case 4:
			LootShow4 = value;
			break;
		}
	}

	public Vector2 GetLootAnchoredposition(int index)
	{
		return index switch
		{
			1 => LootAnchoredposition1, 
			2 => LootAnchoredposition2, 
			3 => LootAnchoredposition3, 
			4 => LootAnchoredposition4, 
			_ => Vector2.zero, 
		};
	}

	public void SetLootAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			LootAnchoredposition1 = value;
			break;
		case 2:
			LootAnchoredposition2 = value;
			break;
		case 3:
			LootAnchoredposition3 = value;
			break;
		case 4:
			LootAnchoredposition4 = value;
			break;
		}
	}

	public Sprite GetLootSprite(int index)
	{
		return index switch
		{
			1 => LootSprite1, 
			2 => LootSprite2, 
			3 => LootSprite3, 
			4 => LootSprite4, 
			_ => null, 
		};
	}

	public void SetLootSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			LootSprite1 = value;
			break;
		case 2:
			LootSprite2 = value;
			break;
		case 3:
			LootSprite3 = value;
			break;
		case 4:
			LootSprite4 = value;
			break;
		}
	}

	public void LootNtvsize1()
	{
		if (_oLootImage1 != null)
		{
			_oLootImage1.SetNativeSize();
		}
	}

	public void LootNtvsize2()
	{
		if (_oLootImage2 != null)
		{
			_oLootImage2.SetNativeSize();
		}
	}

	public void LootNtvsize3()
	{
		if (_oLootImage3 != null)
		{
			_oLootImage3.SetNativeSize();
		}
	}

	public void LootNtvsize4()
	{
		if (_oLootImage4 != null)
		{
			_oLootImage4.SetNativeSize();
		}
	}

	public void CallLootNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			LootNtvsize1();
			break;
		case 2:
			LootNtvsize2();
			break;
		case 3:
			LootNtvsize3();
			break;
		case 4:
			LootNtvsize4();
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
			Object.Destroy(_viewGameObject);
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
