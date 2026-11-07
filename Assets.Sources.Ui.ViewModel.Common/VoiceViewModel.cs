using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class VoiceViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oContent;

	private GameObject _oIcon;

	private Image _oIconImage;

	private GameObject _oStates;

	private GameObject _oCloseTips;

	private GameObject _oSelfPlayer;

	private GameObject _oSelfName;

	private Text _oSelfNameText;

	private GameObject _oSelfState;

	private Image _oSelfStateImage;

	private GameObject _oSelfStateTxt;

	private Text _oSelfStateTxtText;

	private GameObject _oPlayer1;

	private GameObject _oPlayer2;

	private GameObject _oPlayer3;

	private GameObject _oPlayer4;

	private GameObject _oPlayer5;

	private GameObject _oPlayer6;

	private GameObject _oPlayer7;

	private GameObject _oName1;

	private GameObject _oName2;

	private GameObject _oName3;

	private GameObject _oName4;

	private GameObject _oName5;

	private GameObject _oName6;

	private GameObject _oName7;

	private Text _oNameText1;

	private Text _oNameText2;

	private Text _oNameText3;

	private Text _oNameText4;

	private Text _oNameText5;

	private Text _oNameText6;

	private Text _oNameText7;

	private GameObject _oTips;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Voice";

	public bool ContentShow
	{
		get
		{
			if (_oContent != null)
			{
				return _oContent.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ContentShow != value && _oContent != null)
			{
				_oContent.SetObjectActive(value);
			}
		}
	}

	public Sprite IconSprite
	{
		get
		{
			if (_oIconImage != null)
			{
				return _oIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite != value && _oIconImage != null)
			{
				_oIconImage.sprite = value;
			}
		}
	}

	public bool StatesShow
	{
		get
		{
			if (_oStates != null)
			{
				return _oStates.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StatesShow != value && _oStates != null)
			{
				_oStates.SetObjectActive(value);
			}
		}
	}

	public bool CloseTipsShow
	{
		get
		{
			if (_oCloseTips != null)
			{
				return _oCloseTips.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CloseTipsShow != value && _oCloseTips != null)
			{
				_oCloseTips.SetObjectActive(value);
			}
		}
	}

	public bool SelfPlayerShow
	{
		get
		{
			if (_oSelfPlayer != null)
			{
				return _oSelfPlayer.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfPlayerShow != value && _oSelfPlayer != null)
			{
				_oSelfPlayer.SetObjectActive(value);
			}
		}
	}

	public string SelfNameString
	{
		get
		{
			if (_oSelfNameText != null)
			{
				return _oSelfNameText.text;
			}
			return null;
		}
		set
		{
			if (SelfNameString != value && _oSelfNameText != null)
			{
				_oSelfNameText.text = value;
			}
		}
	}

	public Sprite SelfStateSprite
	{
		get
		{
			if (_oSelfStateImage != null)
			{
				return _oSelfStateImage.sprite;
			}
			return null;
		}
		set
		{
			if (SelfStateSprite != value && _oSelfStateImage != null)
			{
				_oSelfStateImage.sprite = value;
			}
		}
	}

	public string SelfStateTxtString
	{
		get
		{
			if (_oSelfStateTxtText != null)
			{
				return _oSelfStateTxtText.text;
			}
			return null;
		}
		set
		{
			if (SelfStateTxtString != value && _oSelfStateTxtText != null)
			{
				_oSelfStateTxtText.text = value;
			}
		}
	}

	public bool PlayerShow1
	{
		get
		{
			if (_oPlayer1 != null)
			{
				return _oPlayer1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow1 != value && _oPlayer1 != null)
			{
				_oPlayer1.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow2
	{
		get
		{
			if (_oPlayer2 != null)
			{
				return _oPlayer2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow2 != value && _oPlayer2 != null)
			{
				_oPlayer2.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow3
	{
		get
		{
			if (_oPlayer3 != null)
			{
				return _oPlayer3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow3 != value && _oPlayer3 != null)
			{
				_oPlayer3.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow4
	{
		get
		{
			if (_oPlayer4 != null)
			{
				return _oPlayer4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow4 != value && _oPlayer4 != null)
			{
				_oPlayer4.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow5
	{
		get
		{
			if (_oPlayer5 != null)
			{
				return _oPlayer5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow5 != value && _oPlayer5 != null)
			{
				_oPlayer5.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow6
	{
		get
		{
			if (_oPlayer6 != null)
			{
				return _oPlayer6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow6 != value && _oPlayer6 != null)
			{
				_oPlayer6.SetObjectActive(value);
			}
		}
	}

	public bool PlayerShow7
	{
		get
		{
			if (_oPlayer7 != null)
			{
				return _oPlayer7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerShow7 != value && _oPlayer7 != null)
			{
				_oPlayer7.SetObjectActive(value);
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

	public string NameString3
	{
		get
		{
			if (_oNameText3 != null)
			{
				return _oNameText3.text;
			}
			return null;
		}
		set
		{
			if (NameString3 != value && _oNameText3 != null)
			{
				_oNameText3.text = value;
			}
		}
	}

	public string NameString4
	{
		get
		{
			if (_oNameText4 != null)
			{
				return _oNameText4.text;
			}
			return null;
		}
		set
		{
			if (NameString4 != value && _oNameText4 != null)
			{
				_oNameText4.text = value;
			}
		}
	}

	public string NameString5
	{
		get
		{
			if (_oNameText5 != null)
			{
				return _oNameText5.text;
			}
			return null;
		}
		set
		{
			if (NameString5 != value && _oNameText5 != null)
			{
				_oNameText5.text = value;
			}
		}
	}

	public string NameString6
	{
		get
		{
			if (_oNameText6 != null)
			{
				return _oNameText6.text;
			}
			return null;
		}
		set
		{
			if (NameString6 != value && _oNameText6 != null)
			{
				_oNameText6.text = value;
			}
		}
	}

	public string NameString7
	{
		get
		{
			if (_oNameText7 != null)
			{
				return _oNameText7.text;
			}
			return null;
		}
		set
		{
			if (NameString7 != value && _oNameText7 != null)
			{
				_oNameText7.text = value;
			}
		}
	}

	public bool TipsShow
	{
		get
		{
			if (_oTips != null)
			{
				return _oTips.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TipsShow != value && _oTips != null)
			{
				_oTips.SetObjectActive(value);
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
			case "Content":
				_oContent = transform.gameObject;
				break;
			case "Icon":
				_oIcon = transform.gameObject;
				_oIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "States":
				_oStates = transform.gameObject;
				break;
			case "CloseTips":
				_oCloseTips = transform.gameObject;
				break;
			case "SelfPlayer":
				_oSelfPlayer = transform.gameObject;
				break;
			case "SelfName":
				_oSelfName = transform.gameObject;
				_oSelfNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "SelfState":
				_oSelfState = transform.gameObject;
				_oSelfStateImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SelfStateTxt":
				_oSelfStateTxt = transform.gameObject;
				_oSelfStateTxtText = transform.gameObject.GetComponent<Text>();
				break;
			case "Player1":
				_oPlayer1 = transform.gameObject;
				break;
			case "Player2":
				_oPlayer2 = transform.gameObject;
				break;
			case "Player3":
				_oPlayer3 = transform.gameObject;
				break;
			case "Player4":
				_oPlayer4 = transform.gameObject;
				break;
			case "Player5":
				_oPlayer5 = transform.gameObject;
				break;
			case "Player6":
				_oPlayer6 = transform.gameObject;
				break;
			case "Player7":
				_oPlayer7 = transform.gameObject;
				break;
			case "Name1":
				_oName1 = transform.gameObject;
				_oNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name2":
				_oName2 = transform.gameObject;
				_oNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name3":
				_oName3 = transform.gameObject;
				_oNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name4":
				_oName4 = transform.gameObject;
				_oNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name5":
				_oName5 = transform.gameObject;
				_oNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name6":
				_oName6 = transform.gameObject;
				_oNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Name7":
				_oName7 = transform.gameObject;
				_oNameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "Tips":
				_oTips = transform.gameObject;
				break;
			}
		}
	}

	public bool GetPlayerShow(int index)
	{
		return index switch
		{
			1 => PlayerShow1, 
			2 => PlayerShow2, 
			3 => PlayerShow3, 
			4 => PlayerShow4, 
			5 => PlayerShow5, 
			6 => PlayerShow6, 
			7 => PlayerShow7, 
			_ => false, 
		};
	}

	public void SetPlayerShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			PlayerShow1 = value;
			break;
		case 2:
			PlayerShow2 = value;
			break;
		case 3:
			PlayerShow3 = value;
			break;
		case 4:
			PlayerShow4 = value;
			break;
		case 5:
			PlayerShow5 = value;
			break;
		case 6:
			PlayerShow6 = value;
			break;
		case 7:
			PlayerShow7 = value;
			break;
		}
	}

	public string GetNameString(int index)
	{
		return index switch
		{
			1 => NameString1, 
			2 => NameString2, 
			3 => NameString3, 
			4 => NameString4, 
			5 => NameString5, 
			6 => NameString6, 
			7 => NameString7, 
			_ => null, 
		};
	}

	public void SetNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			NameString1 = value;
			break;
		case 2:
			NameString2 = value;
			break;
		case 3:
			NameString3 = value;
			break;
		case 4:
			NameString4 = value;
			break;
		case 5:
			NameString5 = value;
			break;
		case 6:
			NameString6 = value;
			break;
		case 7:
			NameString7 = value;
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
