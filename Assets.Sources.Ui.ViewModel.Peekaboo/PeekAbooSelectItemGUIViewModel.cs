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

namespace Assets.Sources.Ui.ViewModel.Peekaboo;

[GameUiTest]
public class PeekAbooSelectItemGUIViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _Show;

	private GameObject _oimgItem0;

	private GameObject _oimgItem1;

	private GameObject _oimgItem2;

	private GameObject _oimgItem3;

	private GameObject _oimgItem0_1;

	private GameObject _oimgItem1_1;

	private GameObject _oimgItem2_1;

	private GameObject _obtn0;

	private GameObject _obtn1;

	private GameObject _obtn2;

	private GameObject _obtn3;

	private Button _obtnButton0;

	private Button _obtnButton1;

	private Button _obtnButton2;

	private Button _obtnButton3;

	private GameObject _oimgSelect;

	private RectTransform _oimgSelectRectTransform;

	private GameObject _obtnSelectSecond;

	private Button _obtnSelectSecondButton;

	private GameObject _oconTime;

	private GameObject _otxtTime;

	private Text _otxtTimeText;

	private GameObject _oconBtn;

	private GameObject _oconSpecalImg;

	private GameObject _otxtName1;

	private GameObject _otxtName2;

	private GameObject _otxtName3;

	private GameObject _otxtName4;

	private Text _otxtNameText1;

	private Text _otxtNameText2;

	private Text _otxtNameText3;

	private Text _otxtNameText4;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/peekaboo";

	private string _resourceAssetName = "peekabooselectitemgui";

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
			if (_Show != null)
			{
				return _Show.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowShow != value && _Show != null)
			{
				_Show.SetObjectActive(value);
			}
		}
	}

	public GameObject imgItemObj0 => _oimgItem0;

	public GameObject imgItemObj1 => _oimgItem1;

	public GameObject imgItemObj2 => _oimgItem2;

	public GameObject imgItemObj3 => _oimgItem3;

	public GameObject imgItem0_Obj1 => _oimgItem0_1;

	public GameObject imgItem1_Obj1 => _oimgItem1_1;

	public GameObject imgItem2_Obj1 => _oimgItem2_1;

	public Button.ButtonClickedEvent btnClicked0
	{
		get
		{
			if (_obtnButton0 != null)
			{
				return _obtnButton0.onClick;
			}
			return null;
		}
		set
		{
			if (btnClicked0 != value && _obtnButton0 != null)
			{
				_obtnButton0.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent btnClicked1
	{
		get
		{
			if (_obtnButton1 != null)
			{
				return _obtnButton1.onClick;
			}
			return null;
		}
		set
		{
			if (btnClicked1 != value && _obtnButton1 != null)
			{
				_obtnButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent btnClicked2
	{
		get
		{
			if (_obtnButton2 != null)
			{
				return _obtnButton2.onClick;
			}
			return null;
		}
		set
		{
			if (btnClicked2 != value && _obtnButton2 != null)
			{
				_obtnButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent btnClicked3
	{
		get
		{
			if (_obtnButton3 != null)
			{
				return _obtnButton3.onClick;
			}
			return null;
		}
		set
		{
			if (btnClicked3 != value && _obtnButton3 != null)
			{
				_obtnButton3.onClick = value;
			}
		}
	}

	public bool btnButtonable0
	{
		get
		{
			if (_obtnButton0 != null)
			{
				return _obtnButton0.interactable;
			}
			return true;
		}
		set
		{
			if (btnButtonable0 != value && _obtnButton0 != null)
			{
				_obtnButton0.interactable = value;
			}
		}
	}

	public bool btnButtonable1
	{
		get
		{
			if (_obtnButton1 != null)
			{
				return _obtnButton1.interactable;
			}
			return true;
		}
		set
		{
			if (btnButtonable1 != value && _obtnButton1 != null)
			{
				_obtnButton1.interactable = value;
			}
		}
	}

	public bool btnButtonable2
	{
		get
		{
			if (_obtnButton2 != null)
			{
				return _obtnButton2.interactable;
			}
			return true;
		}
		set
		{
			if (btnButtonable2 != value && _obtnButton2 != null)
			{
				_obtnButton2.interactable = value;
			}
		}
	}

	public bool btnButtonable3
	{
		get
		{
			if (_obtnButton3 != null)
			{
				return _obtnButton3.interactable;
			}
			return true;
		}
		set
		{
			if (btnButtonable3 != value && _obtnButton3 != null)
			{
				_obtnButton3.interactable = value;
			}
		}
	}

	public bool imgSelectShow
	{
		get
		{
			if (_oimgSelect != null)
			{
				return _oimgSelect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (imgSelectShow != value && _oimgSelect != null)
			{
				_oimgSelect.SetObjectActive(value);
			}
		}
	}

	public Vector3 imgSelectPosition
	{
		get
		{
			if (_oimgSelectRectTransform != null)
			{
				return _oimgSelectRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (imgSelectPosition != value && _oimgSelectRectTransform != null)
			{
				_oimgSelectRectTransform.localPosition = value;
			}
		}
	}

	public Button.ButtonClickedEvent btnSelectSecondClicked
	{
		get
		{
			if (_obtnSelectSecondButton != null)
			{
				return _obtnSelectSecondButton.onClick;
			}
			return null;
		}
		set
		{
			if (btnSelectSecondClicked != value && _obtnSelectSecondButton != null)
			{
				_obtnSelectSecondButton.onClick = value;
			}
		}
	}

	public bool btnSelectSecondButtonable
	{
		get
		{
			if (_obtnSelectSecondButton != null)
			{
				return _obtnSelectSecondButton.interactable;
			}
			return true;
		}
		set
		{
			if (btnSelectSecondButtonable != value && _obtnSelectSecondButton != null)
			{
				_obtnSelectSecondButton.interactable = value;
			}
		}
	}

	public bool conTimeShow
	{
		get
		{
			if (_oconTime != null)
			{
				return _oconTime.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (conTimeShow != value && _oconTime != null)
			{
				_oconTime.SetObjectActive(value);
			}
		}
	}

	public string txtTimeString
	{
		get
		{
			if (_otxtTimeText != null)
			{
				return _otxtTimeText.text;
			}
			return null;
		}
		set
		{
			if (txtTimeString != value && _otxtTimeText != null)
			{
				_otxtTimeText.text = value;
			}
		}
	}

	public bool conBtnShow
	{
		get
		{
			if (_oconBtn != null)
			{
				return _oconBtn.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (conBtnShow != value && _oconBtn != null)
			{
				_oconBtn.SetObjectActive(value);
			}
		}
	}

	public bool conSpecalImgShow
	{
		get
		{
			if (_oconSpecalImg != null)
			{
				return _oconSpecalImg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (conSpecalImgShow != value && _oconSpecalImg != null)
			{
				_oconSpecalImg.SetObjectActive(value);
			}
		}
	}

	public bool txtNameShow1
	{
		get
		{
			if (_otxtName1 != null)
			{
				return _otxtName1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (txtNameShow1 != value && _otxtName1 != null)
			{
				_otxtName1.SetObjectActive(value);
			}
		}
	}

	public bool txtNameShow2
	{
		get
		{
			if (_otxtName2 != null)
			{
				return _otxtName2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (txtNameShow2 != value && _otxtName2 != null)
			{
				_otxtName2.SetObjectActive(value);
			}
		}
	}

	public bool txtNameShow3
	{
		get
		{
			if (_otxtName3 != null)
			{
				return _otxtName3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (txtNameShow3 != value && _otxtName3 != null)
			{
				_otxtName3.SetObjectActive(value);
			}
		}
	}

	public bool txtNameShow4
	{
		get
		{
			if (_otxtName4 != null)
			{
				return _otxtName4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (txtNameShow4 != value && _otxtName4 != null)
			{
				_otxtName4.SetObjectActive(value);
			}
		}
	}

	public string txtNameString1
	{
		get
		{
			if (_otxtNameText1 != null)
			{
				return _otxtNameText1.text;
			}
			return null;
		}
		set
		{
			if (txtNameString1 != value && _otxtNameText1 != null)
			{
				_otxtNameText1.text = value;
			}
		}
	}

	public string txtNameString2
	{
		get
		{
			if (_otxtNameText2 != null)
			{
				return _otxtNameText2.text;
			}
			return null;
		}
		set
		{
			if (txtNameString2 != value && _otxtNameText2 != null)
			{
				_otxtNameText2.text = value;
			}
		}
	}

	public string txtNameString3
	{
		get
		{
			if (_otxtNameText3 != null)
			{
				return _otxtNameText3.text;
			}
			return null;
		}
		set
		{
			if (txtNameString3 != value && _otxtNameText3 != null)
			{
				_otxtNameText3.text = value;
			}
		}
	}

	public string txtNameString4
	{
		get
		{
			if (_otxtNameText4 != null)
			{
				return _otxtNameText4.text;
			}
			return null;
		}
		set
		{
			if (txtNameString4 != value && _otxtNameText4 != null)
			{
				_otxtNameText4.text = value;
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
				_Show = transform.gameObject;
				break;
			case "imgItem0":
				_oimgItem0 = transform.gameObject;
				break;
			case "imgItem1":
				_oimgItem1 = transform.gameObject;
				break;
			case "imgItem2":
				_oimgItem2 = transform.gameObject;
				break;
			case "imgItem3":
				_oimgItem3 = transform.gameObject;
				break;
			case "imgItem0_1":
				_oimgItem0_1 = transform.gameObject;
				break;
			case "imgItem1_1":
				_oimgItem1_1 = transform.gameObject;
				break;
			case "imgItem2_1":
				_oimgItem2_1 = transform.gameObject;
				break;
			case "btn0":
				_obtn0 = transform.gameObject;
				_obtnButton0 = transform.gameObject.GetComponent<Button>();
				break;
			case "btn1":
				_obtn1 = transform.gameObject;
				_obtnButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "btn2":
				_obtn2 = transform.gameObject;
				_obtnButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "btn3":
				_obtn3 = transform.gameObject;
				_obtnButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "imgSelect":
				_oimgSelect = transform.gameObject;
				_oimgSelectRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "btnSelectSecond":
				_obtnSelectSecond = transform.gameObject;
				_obtnSelectSecondButton = transform.gameObject.GetComponent<Button>();
				break;
			case "conTime":
				_oconTime = transform.gameObject;
				break;
			case "txtTime":
				_otxtTime = transform.gameObject;
				_otxtTimeText = transform.gameObject.GetComponent<Text>();
				break;
			case "conBtn":
				_oconBtn = transform.gameObject;
				break;
			case "conSpecalImg":
				_oconSpecalImg = transform.gameObject;
				break;
			case "txtName1":
				_otxtName1 = transform.gameObject;
				_otxtNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "txtName2":
				_otxtName2 = transform.gameObject;
				_otxtNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "txtName3":
				_otxtName3 = transform.gameObject;
				_otxtNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "txtName4":
				_otxtName4 = transform.gameObject;
				_otxtNameText4 = transform.gameObject.GetComponent<Text>();
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

	public GameObject GetimgItemObj(int index)
	{
		return index switch
		{
			0 => imgItemObj0, 
			1 => imgItemObj1, 
			2 => imgItemObj2, 
			3 => imgItemObj3, 
			_ => null, 
		};
	}

	public int GetimgItemCount()
	{
		return 3;
	}

	public GameObject GetimgItem0_Obj(int index)
	{
		if (index == 1)
		{
			return imgItem0_Obj1;
		}
		return null;
	}

	public int GetimgItem0_Count()
	{
		return 1;
	}

	public GameObject GetimgItem1_Obj(int index)
	{
		if (index == 1)
		{
			return imgItem1_Obj1;
		}
		return null;
	}

	public int GetimgItem1_Count()
	{
		return 1;
	}

	public GameObject GetimgItem2_Obj(int index)
	{
		if (index == 1)
		{
			return imgItem2_Obj1;
		}
		return null;
	}

	public int GetimgItem2_Count()
	{
		return 1;
	}

	public int GetimgItem3_Count()
	{
		return 1;
	}

	public Button.ButtonClickedEvent GetbtnClicked(int index)
	{
		return index switch
		{
			0 => btnClicked0, 
			1 => btnClicked1, 
			2 => btnClicked2, 
			3 => btnClicked3, 
			_ => null, 
		};
	}

	public void SetbtnClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 0:
			btnClicked0 = value;
			break;
		case 1:
			btnClicked1 = value;
			break;
		case 2:
			btnClicked2 = value;
			break;
		case 3:
			btnClicked3 = value;
			break;
		}
	}

	public int GetbtnCount()
	{
		return 3;
	}

	public bool GetbtnButtonable(int index)
	{
		return index switch
		{
			0 => btnButtonable0, 
			1 => btnButtonable1, 
			2 => btnButtonable2, 
			3 => btnButtonable3, 
			_ => true, 
		};
	}

	public void SetbtnButtonable(int index, bool value)
	{
		switch (index)
		{
		case 0:
			btnButtonable0 = value;
			break;
		case 1:
			btnButtonable1 = value;
			break;
		case 2:
			btnButtonable2 = value;
			break;
		case 3:
			btnButtonable3 = value;
			break;
		}
	}

	public bool GettxtNameShow(int index)
	{
		return index switch
		{
			1 => txtNameShow1, 
			2 => txtNameShow2, 
			3 => txtNameShow3, 
			4 => txtNameShow4, 
			_ => false, 
		};
	}

	public void SettxtNameShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			txtNameShow1 = value;
			break;
		case 2:
			txtNameShow2 = value;
			break;
		case 3:
			txtNameShow3 = value;
			break;
		case 4:
			txtNameShow4 = value;
			break;
		}
	}

	public int GettxtNameCount()
	{
		return 4;
	}

	public string GettxtNameString(int index)
	{
		return index switch
		{
			1 => txtNameString1, 
			2 => txtNameString2, 
			3 => txtNameString3, 
			4 => txtNameString4, 
			_ => null, 
		};
	}

	public void SettxtNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			txtNameString1 = value;
			break;
		case 2:
			txtNameString2 = value;
			break;
		case 3:
			txtNameString3 = value;
			break;
		case 4:
			txtNameString4 = value;
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
