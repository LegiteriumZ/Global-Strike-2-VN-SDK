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
public class BestKillViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oBestItem1;

	private GameObject _oBestItem2;

	private GameObject _oBestItem3;

	private GameObject _oBestItem4;

	private Image _oBestItemImage1;

	private Image _oBestItemImage2;

	private Image _oBestItemImage3;

	private Image _oBestItemImage4;

	private GameObject _oPlayerName1;

	private GameObject _oPlayerName2;

	private GameObject _oPlayerName3;

	private GameObject _oPlayerName4;

	private Text _oPlayerNameText1;

	private Text _oPlayerNameText2;

	private Text _oPlayerNameText3;

	private Text _oPlayerNameText4;

	private GameObject _oData1;

	private GameObject _oData2;

	private GameObject _oData3;

	private GameObject _oData4;

	private Text _oDataText1;

	private Text _oDataText2;

	private Text _oDataText3;

	private Text _oDataText4;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "BestKill";

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

	public bool BestItemShow1
	{
		get
		{
			if (_oBestItem1 != null)
			{
				return _oBestItem1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BestItemShow1 != value && _oBestItem1 != null)
			{
				_oBestItem1.SetObjectActive(value);
			}
		}
	}

	public bool BestItemShow2
	{
		get
		{
			if (_oBestItem2 != null)
			{
				return _oBestItem2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BestItemShow2 != value && _oBestItem2 != null)
			{
				_oBestItem2.SetObjectActive(value);
			}
		}
	}

	public bool BestItemShow3
	{
		get
		{
			if (_oBestItem3 != null)
			{
				return _oBestItem3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BestItemShow3 != value && _oBestItem3 != null)
			{
				_oBestItem3.SetObjectActive(value);
			}
		}
	}

	public bool BestItemShow4
	{
		get
		{
			if (_oBestItem4 != null)
			{
				return _oBestItem4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BestItemShow4 != value && _oBestItem4 != null)
			{
				_oBestItem4.SetObjectActive(value);
			}
		}
	}

	public Sprite BestItemSprite1
	{
		get
		{
			if (_oBestItemImage1 != null)
			{
				return _oBestItemImage1.sprite;
			}
			return null;
		}
		set
		{
			if (BestItemSprite1 != value && _oBestItemImage1 != null)
			{
				_oBestItemImage1.sprite = value;
			}
		}
	}

	public Sprite BestItemSprite2
	{
		get
		{
			if (_oBestItemImage2 != null)
			{
				return _oBestItemImage2.sprite;
			}
			return null;
		}
		set
		{
			if (BestItemSprite2 != value && _oBestItemImage2 != null)
			{
				_oBestItemImage2.sprite = value;
			}
		}
	}

	public Sprite BestItemSprite3
	{
		get
		{
			if (_oBestItemImage3 != null)
			{
				return _oBestItemImage3.sprite;
			}
			return null;
		}
		set
		{
			if (BestItemSprite3 != value && _oBestItemImage3 != null)
			{
				_oBestItemImage3.sprite = value;
			}
		}
	}

	public Sprite BestItemSprite4
	{
		get
		{
			if (_oBestItemImage4 != null)
			{
				return _oBestItemImage4.sprite;
			}
			return null;
		}
		set
		{
			if (BestItemSprite4 != value && _oBestItemImage4 != null)
			{
				_oBestItemImage4.sprite = value;
			}
		}
	}

	public GameObject PlayerNameObj1 => _oPlayerName1;

	public GameObject PlayerNameObj2 => _oPlayerName2;

	public GameObject PlayerNameObj3 => _oPlayerName3;

	public GameObject PlayerNameObj4 => _oPlayerName4;

	public string PlayerNameString1
	{
		get
		{
			if (_oPlayerNameText1 != null)
			{
				return _oPlayerNameText1.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString1 != value && _oPlayerNameText1 != null)
			{
				_oPlayerNameText1.text = value;
			}
		}
	}

	public string PlayerNameString2
	{
		get
		{
			if (_oPlayerNameText2 != null)
			{
				return _oPlayerNameText2.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString2 != value && _oPlayerNameText2 != null)
			{
				_oPlayerNameText2.text = value;
			}
		}
	}

	public string PlayerNameString3
	{
		get
		{
			if (_oPlayerNameText3 != null)
			{
				return _oPlayerNameText3.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString3 != value && _oPlayerNameText3 != null)
			{
				_oPlayerNameText3.text = value;
			}
		}
	}

	public string PlayerNameString4
	{
		get
		{
			if (_oPlayerNameText4 != null)
			{
				return _oPlayerNameText4.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString4 != value && _oPlayerNameText4 != null)
			{
				_oPlayerNameText4.text = value;
			}
		}
	}

	public string DataString1
	{
		get
		{
			if (_oDataText1 != null)
			{
				return _oDataText1.text;
			}
			return null;
		}
		set
		{
			if (DataString1 != value && _oDataText1 != null)
			{
				_oDataText1.text = value;
			}
		}
	}

	public string DataString2
	{
		get
		{
			if (_oDataText2 != null)
			{
				return _oDataText2.text;
			}
			return null;
		}
		set
		{
			if (DataString2 != value && _oDataText2 != null)
			{
				_oDataText2.text = value;
			}
		}
	}

	public string DataString3
	{
		get
		{
			if (_oDataText3 != null)
			{
				return _oDataText3.text;
			}
			return null;
		}
		set
		{
			if (DataString3 != value && _oDataText3 != null)
			{
				_oDataText3.text = value;
			}
		}
	}

	public string DataString4
	{
		get
		{
			if (_oDataText4 != null)
			{
				return _oDataText4.text;
			}
			return null;
		}
		set
		{
			if (DataString4 != value && _oDataText4 != null)
			{
				_oDataText4.text = value;
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
			case "BestItem1":
				_oBestItem1 = transform.gameObject;
				_oBestItemImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "BestItem2":
				_oBestItem2 = transform.gameObject;
				_oBestItemImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "BestItem3":
				_oBestItem3 = transform.gameObject;
				_oBestItemImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "BestItem4":
				_oBestItem4 = transform.gameObject;
				_oBestItemImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerName1":
				_oPlayerName1 = transform.gameObject;
				_oPlayerNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName2":
				_oPlayerName2 = transform.gameObject;
				_oPlayerNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName3":
				_oPlayerName3 = transform.gameObject;
				_oPlayerNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName4":
				_oPlayerName4 = transform.gameObject;
				_oPlayerNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Data1":
				_oData1 = transform.gameObject;
				_oDataText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Data2":
				_oData2 = transform.gameObject;
				_oDataText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Data3":
				_oData3 = transform.gameObject;
				_oDataText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Data4":
				_oData4 = transform.gameObject;
				_oDataText4 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetBestItemShow(int index)
	{
		return index switch
		{
			1 => BestItemShow1, 
			2 => BestItemShow2, 
			3 => BestItemShow3, 
			4 => BestItemShow4, 
			_ => false, 
		};
	}

	public void SetBestItemShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			BestItemShow1 = value;
			break;
		case 2:
			BestItemShow2 = value;
			break;
		case 3:
			BestItemShow3 = value;
			break;
		case 4:
			BestItemShow4 = value;
			break;
		}
	}

	public Sprite GetBestItemSprite(int index)
	{
		return index switch
		{
			1 => BestItemSprite1, 
			2 => BestItemSprite2, 
			3 => BestItemSprite3, 
			4 => BestItemSprite4, 
			_ => null, 
		};
	}

	public void SetBestItemSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			BestItemSprite1 = value;
			break;
		case 2:
			BestItemSprite2 = value;
			break;
		case 3:
			BestItemSprite3 = value;
			break;
		case 4:
			BestItemSprite4 = value;
			break;
		}
	}

	public GameObject GetPlayerNameObj(int index)
	{
		return index switch
		{
			1 => PlayerNameObj1, 
			2 => PlayerNameObj2, 
			3 => PlayerNameObj3, 
			4 => PlayerNameObj4, 
			_ => null, 
		};
	}

	public string GetPlayerNameString(int index)
	{
		return index switch
		{
			1 => PlayerNameString1, 
			2 => PlayerNameString2, 
			3 => PlayerNameString3, 
			4 => PlayerNameString4, 
			_ => null, 
		};
	}

	public void SetPlayerNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PlayerNameString1 = value;
			break;
		case 2:
			PlayerNameString2 = value;
			break;
		case 3:
			PlayerNameString3 = value;
			break;
		case 4:
			PlayerNameString4 = value;
			break;
		}
	}

	public string GetDataString(int index)
	{
		return index switch
		{
			1 => DataString1, 
			2 => DataString2, 
			3 => DataString3, 
			4 => DataString4, 
			_ => null, 
		};
	}

	public void SetDataString(int index, string value)
	{
		switch (index)
		{
		case 1:
			DataString1 = value;
			break;
		case 2:
			DataString2 = value;
			break;
		case 3:
			DataString3 = value;
			break;
		case 4:
			DataString4 = value;
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
