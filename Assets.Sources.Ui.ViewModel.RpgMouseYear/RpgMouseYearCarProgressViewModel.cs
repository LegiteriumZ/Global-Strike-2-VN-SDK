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
public class RpgMouseYearCarProgressViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oCar;

	private RectTransform _oCarRectTransform;

	private GameObject _oAlertText;

	private Text _oAlertTextText;

	private GameObject _oProgressUp;

	private Image _oProgressUpImage;

	private GameObject _oCheckPoint1;

	private GameObject _oCheckPoint2;

	private GameObject _oCheckPoint3;

	private GameObject _oCheckPoint4;

	private GameObject _oCheckPoint5;

	private GameObject _oCheckPoint6;

	private GameObject _oCheckPoint7;

	private RectTransform _oCheckPointRectTransform1;

	private RectTransform _oCheckPointRectTransform2;

	private RectTransform _oCheckPointRectTransform3;

	private RectTransform _oCheckPointRectTransform4;

	private RectTransform _oCheckPointRectTransform5;

	private RectTransform _oCheckPointRectTransform6;

	private RectTransform _oCheckPointRectTransform7;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgmouseyear";

	private string _resourceAssetName = "RpgMouseYearCarProgress";

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

	public bool CarShow
	{
		get
		{
			if (_oCar != null)
			{
				return _oCar.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CarShow != value && _oCar != null)
			{
				_oCar.SetObjectActive(value);
			}
		}
	}

	public Vector3 CarPosition
	{
		get
		{
			if (_oCarRectTransform != null)
			{
				return _oCarRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CarPosition != value && _oCarRectTransform != null)
			{
				_oCarRectTransform.localPosition = value;
			}
		}
	}

	public bool AlertTextShow
	{
		get
		{
			if (_oAlertText != null)
			{
				return _oAlertText.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AlertTextShow != value && _oAlertText != null)
			{
				_oAlertText.SetObjectActive(value);
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

	public float ProgressUpFillamount
	{
		get
		{
			if (_oProgressUpImage != null)
			{
				return _oProgressUpImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressUpFillamount != value && _oProgressUpImage != null)
			{
				_oProgressUpImage.fillAmount = value;
			}
		}
	}

	public bool CheckPointShow1
	{
		get
		{
			if (_oCheckPoint1 != null)
			{
				return _oCheckPoint1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckPointShow1 != value && _oCheckPoint1 != null)
			{
				_oCheckPoint1.SetObjectActive(value);
			}
		}
	}

	public bool CheckPointShow2
	{
		get
		{
			if (_oCheckPoint2 != null)
			{
				return _oCheckPoint2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckPointShow2 != value && _oCheckPoint2 != null)
			{
				_oCheckPoint2.SetObjectActive(value);
			}
		}
	}

	public bool CheckPointShow3
	{
		get
		{
			if (_oCheckPoint3 != null)
			{
				return _oCheckPoint3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckPointShow3 != value && _oCheckPoint3 != null)
			{
				_oCheckPoint3.SetObjectActive(value);
			}
		}
	}

	public bool CheckPointShow4
	{
		get
		{
			if (_oCheckPoint4 != null)
			{
				return _oCheckPoint4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckPointShow4 != value && _oCheckPoint4 != null)
			{
				_oCheckPoint4.SetObjectActive(value);
			}
		}
	}

	public bool CheckPointShow5
	{
		get
		{
			if (_oCheckPoint5 != null)
			{
				return _oCheckPoint5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckPointShow5 != value && _oCheckPoint5 != null)
			{
				_oCheckPoint5.SetObjectActive(value);
			}
		}
	}

	public bool CheckPointShow6
	{
		get
		{
			if (_oCheckPoint6 != null)
			{
				return _oCheckPoint6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckPointShow6 != value && _oCheckPoint6 != null)
			{
				_oCheckPoint6.SetObjectActive(value);
			}
		}
	}

	public bool CheckPointShow7
	{
		get
		{
			if (_oCheckPoint7 != null)
			{
				return _oCheckPoint7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CheckPointShow7 != value && _oCheckPoint7 != null)
			{
				_oCheckPoint7.SetObjectActive(value);
			}
		}
	}

	public Vector3 CheckPointPosition1
	{
		get
		{
			if (_oCheckPointRectTransform1 != null)
			{
				return _oCheckPointRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CheckPointPosition1 != value && _oCheckPointRectTransform1 != null)
			{
				_oCheckPointRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 CheckPointPosition2
	{
		get
		{
			if (_oCheckPointRectTransform2 != null)
			{
				return _oCheckPointRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CheckPointPosition2 != value && _oCheckPointRectTransform2 != null)
			{
				_oCheckPointRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 CheckPointPosition3
	{
		get
		{
			if (_oCheckPointRectTransform3 != null)
			{
				return _oCheckPointRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CheckPointPosition3 != value && _oCheckPointRectTransform3 != null)
			{
				_oCheckPointRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 CheckPointPosition4
	{
		get
		{
			if (_oCheckPointRectTransform4 != null)
			{
				return _oCheckPointRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CheckPointPosition4 != value && _oCheckPointRectTransform4 != null)
			{
				_oCheckPointRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 CheckPointPosition5
	{
		get
		{
			if (_oCheckPointRectTransform5 != null)
			{
				return _oCheckPointRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CheckPointPosition5 != value && _oCheckPointRectTransform5 != null)
			{
				_oCheckPointRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 CheckPointPosition6
	{
		get
		{
			if (_oCheckPointRectTransform6 != null)
			{
				return _oCheckPointRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CheckPointPosition6 != value && _oCheckPointRectTransform6 != null)
			{
				_oCheckPointRectTransform6.localPosition = value;
			}
		}
	}

	public Vector3 CheckPointPosition7
	{
		get
		{
			if (_oCheckPointRectTransform7 != null)
			{
				return _oCheckPointRectTransform7.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (CheckPointPosition7 != value && _oCheckPointRectTransform7 != null)
			{
				_oCheckPointRectTransform7.localPosition = value;
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
			case "Car":
				_oCar = transform.gameObject;
				_oCarRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "AlertText":
				_oAlertText = transform.gameObject;
				_oAlertTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "ProgressUp":
				_oProgressUp = transform.gameObject;
				_oProgressUpImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CheckPoint1":
				_oCheckPoint1 = transform.gameObject;
				_oCheckPointRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CheckPoint2":
				_oCheckPoint2 = transform.gameObject;
				_oCheckPointRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CheckPoint3":
				_oCheckPoint3 = transform.gameObject;
				_oCheckPointRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CheckPoint4":
				_oCheckPoint4 = transform.gameObject;
				_oCheckPointRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CheckPoint5":
				_oCheckPoint5 = transform.gameObject;
				_oCheckPointRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CheckPoint6":
				_oCheckPoint6 = transform.gameObject;
				_oCheckPointRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "CheckPoint7":
				_oCheckPoint7 = transform.gameObject;
				_oCheckPointRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
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

	public bool GetCheckPointShow(int index)
	{
		return index switch
		{
			1 => CheckPointShow1, 
			2 => CheckPointShow2, 
			3 => CheckPointShow3, 
			4 => CheckPointShow4, 
			5 => CheckPointShow5, 
			6 => CheckPointShow6, 
			7 => CheckPointShow7, 
			_ => false, 
		};
	}

	public void SetCheckPointShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			CheckPointShow1 = value;
			break;
		case 2:
			CheckPointShow2 = value;
			break;
		case 3:
			CheckPointShow3 = value;
			break;
		case 4:
			CheckPointShow4 = value;
			break;
		case 5:
			CheckPointShow5 = value;
			break;
		case 6:
			CheckPointShow6 = value;
			break;
		case 7:
			CheckPointShow7 = value;
			break;
		}
	}

	public Vector3 GetCheckPointPosition(int index)
	{
		return index switch
		{
			1 => CheckPointPosition1, 
			2 => CheckPointPosition2, 
			3 => CheckPointPosition3, 
			4 => CheckPointPosition4, 
			5 => CheckPointPosition5, 
			6 => CheckPointPosition6, 
			7 => CheckPointPosition7, 
			_ => Vector3.zero, 
		};
	}

	public void SetCheckPointPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			CheckPointPosition1 = value;
			break;
		case 2:
			CheckPointPosition2 = value;
			break;
		case 3:
			CheckPointPosition3 = value;
			break;
		case 4:
			CheckPointPosition4 = value;
			break;
		case 5:
			CheckPointPosition5 = value;
			break;
		case 6:
			CheckPointPosition6 = value;
			break;
		case 7:
			CheckPointPosition7 = value;
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
