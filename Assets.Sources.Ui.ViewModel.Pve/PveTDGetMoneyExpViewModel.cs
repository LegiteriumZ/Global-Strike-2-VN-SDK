using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class PveTDGetMoneyExpViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _opveTDGetMoneyExp;

	private GameObject _oBack;

	private Image _oBackImage;

	private GameObject _ocell1;

	private GameObject _ocell2;

	private GameObject _ocell3;

	private GameObject _ocell4;

	private Image _ocellImage1;

	private Image _ocellImage2;

	private Image _ocellImage3;

	private Image _ocellImage4;

	private GameObject _onumtxt1;

	private GameObject _onumtxt2;

	private GameObject _onumtxt3;

	private GameObject _onumtxt4;

	private Text _onumtxtText1;

	private Text _onumtxtText2;

	private Text _onumtxtText3;

	private Text _onumtxtText4;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "PveTDGetMoneyExp";

	public bool pveTDGetMoneyExpShow
	{
		get
		{
			if (_opveTDGetMoneyExp != null)
			{
				return _opveTDGetMoneyExp.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pveTDGetMoneyExpShow != value && _opveTDGetMoneyExp != null)
			{
				_opveTDGetMoneyExp.SetObjectActive(value);
			}
		}
	}

	public bool BackShow
	{
		get
		{
			if (_oBack != null)
			{
				return _oBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackShow != value && _oBack != null)
			{
				_oBack.SetObjectActive(value);
			}
		}
	}

	public Sprite BackSprite
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite != value && _oBackImage != null)
			{
				_oBackImage.sprite = value;
			}
		}
	}

	public Image BackImage
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage;
			}
			return null;
		}
		set
		{
			if (BackImage != value && _oBackImage != null)
			{
				_oBackImage = value;
			}
		}
	}

	public bool cellShow1
	{
		get
		{
			if (_ocell1 != null)
			{
				return _ocell1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (cellShow1 != value && _ocell1 != null)
			{
				_ocell1.SetObjectActive(value);
			}
		}
	}

	public bool cellShow2
	{
		get
		{
			if (_ocell2 != null)
			{
				return _ocell2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (cellShow2 != value && _ocell2 != null)
			{
				_ocell2.SetObjectActive(value);
			}
		}
	}

	public bool cellShow3
	{
		get
		{
			if (_ocell3 != null)
			{
				return _ocell3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (cellShow3 != value && _ocell3 != null)
			{
				_ocell3.SetObjectActive(value);
			}
		}
	}

	public bool cellShow4
	{
		get
		{
			if (_ocell4 != null)
			{
				return _ocell4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (cellShow4 != value && _ocell4 != null)
			{
				_ocell4.SetObjectActive(value);
			}
		}
	}

	public Sprite cellSprite1
	{
		get
		{
			if (_ocellImage1 != null)
			{
				return _ocellImage1.sprite;
			}
			return null;
		}
		set
		{
			if (cellSprite1 != value && _ocellImage1 != null)
			{
				_ocellImage1.sprite = value;
			}
		}
	}

	public Sprite cellSprite2
	{
		get
		{
			if (_ocellImage2 != null)
			{
				return _ocellImage2.sprite;
			}
			return null;
		}
		set
		{
			if (cellSprite2 != value && _ocellImage2 != null)
			{
				_ocellImage2.sprite = value;
			}
		}
	}

	public Sprite cellSprite3
	{
		get
		{
			if (_ocellImage3 != null)
			{
				return _ocellImage3.sprite;
			}
			return null;
		}
		set
		{
			if (cellSprite3 != value && _ocellImage3 != null)
			{
				_ocellImage3.sprite = value;
			}
		}
	}

	public Sprite cellSprite4
	{
		get
		{
			if (_ocellImage4 != null)
			{
				return _ocellImage4.sprite;
			}
			return null;
		}
		set
		{
			if (cellSprite4 != value && _ocellImage4 != null)
			{
				_ocellImage4.sprite = value;
			}
		}
	}

	public Color cellColor1
	{
		get
		{
			if (_ocellImage1 != null)
			{
				return _ocellImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (cellColor1 != value && _ocellImage1 != null)
			{
				_ocellImage1.color = value;
			}
		}
	}

	public Color cellColor2
	{
		get
		{
			if (_ocellImage2 != null)
			{
				return _ocellImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (cellColor2 != value && _ocellImage2 != null)
			{
				_ocellImage2.color = value;
			}
		}
	}

	public Color cellColor3
	{
		get
		{
			if (_ocellImage3 != null)
			{
				return _ocellImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (cellColor3 != value && _ocellImage3 != null)
			{
				_ocellImage3.color = value;
			}
		}
	}

	public Color cellColor4
	{
		get
		{
			if (_ocellImage4 != null)
			{
				return _ocellImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (cellColor4 != value && _ocellImage4 != null)
			{
				_ocellImage4.color = value;
			}
		}
	}

	public Image cellImage1
	{
		get
		{
			if (_ocellImage1 != null)
			{
				return _ocellImage1;
			}
			return null;
		}
		set
		{
			if (cellImage1 != value && _ocellImage1 != null)
			{
				_ocellImage1 = value;
			}
		}
	}

	public Image cellImage2
	{
		get
		{
			if (_ocellImage2 != null)
			{
				return _ocellImage2;
			}
			return null;
		}
		set
		{
			if (cellImage2 != value && _ocellImage2 != null)
			{
				_ocellImage2 = value;
			}
		}
	}

	public Image cellImage3
	{
		get
		{
			if (_ocellImage3 != null)
			{
				return _ocellImage3;
			}
			return null;
		}
		set
		{
			if (cellImage3 != value && _ocellImage3 != null)
			{
				_ocellImage3 = value;
			}
		}
	}

	public Image cellImage4
	{
		get
		{
			if (_ocellImage4 != null)
			{
				return _ocellImage4;
			}
			return null;
		}
		set
		{
			if (cellImage4 != value && _ocellImage4 != null)
			{
				_ocellImage4 = value;
			}
		}
	}

	public bool numtxtShow1
	{
		get
		{
			if (_onumtxt1 != null)
			{
				return _onumtxt1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (numtxtShow1 != value && _onumtxt1 != null)
			{
				_onumtxt1.SetObjectActive(value);
			}
		}
	}

	public bool numtxtShow2
	{
		get
		{
			if (_onumtxt2 != null)
			{
				return _onumtxt2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (numtxtShow2 != value && _onumtxt2 != null)
			{
				_onumtxt2.SetObjectActive(value);
			}
		}
	}

	public bool numtxtShow3
	{
		get
		{
			if (_onumtxt3 != null)
			{
				return _onumtxt3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (numtxtShow3 != value && _onumtxt3 != null)
			{
				_onumtxt3.SetObjectActive(value);
			}
		}
	}

	public bool numtxtShow4
	{
		get
		{
			if (_onumtxt4 != null)
			{
				return _onumtxt4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (numtxtShow4 != value && _onumtxt4 != null)
			{
				_onumtxt4.SetObjectActive(value);
			}
		}
	}

	public string numtxtString1
	{
		get
		{
			if (_onumtxtText1 != null)
			{
				return _onumtxtText1.text;
			}
			return null;
		}
		set
		{
			if (numtxtString1 != value && _onumtxtText1 != null)
			{
				_onumtxtText1.text = value;
			}
		}
	}

	public string numtxtString2
	{
		get
		{
			if (_onumtxtText2 != null)
			{
				return _onumtxtText2.text;
			}
			return null;
		}
		set
		{
			if (numtxtString2 != value && _onumtxtText2 != null)
			{
				_onumtxtText2.text = value;
			}
		}
	}

	public string numtxtString3
	{
		get
		{
			if (_onumtxtText3 != null)
			{
				return _onumtxtText3.text;
			}
			return null;
		}
		set
		{
			if (numtxtString3 != value && _onumtxtText3 != null)
			{
				_onumtxtText3.text = value;
			}
		}
	}

	public string numtxtString4
	{
		get
		{
			if (_onumtxtText4 != null)
			{
				return _onumtxtText4.text;
			}
			return null;
		}
		set
		{
			if (numtxtString4 != value && _onumtxtText4 != null)
			{
				_onumtxtText4.text = value;
			}
		}
	}

	public Color numtxtTextcolor1
	{
		get
		{
			if (_onumtxtText1 != null)
			{
				return _onumtxtText1.color;
			}
			return Color.white;
		}
		set
		{
			if (numtxtTextcolor1 != value && _onumtxtText1 != null)
			{
				_onumtxtText1.color = value;
			}
		}
	}

	public Color numtxtTextcolor2
	{
		get
		{
			if (_onumtxtText2 != null)
			{
				return _onumtxtText2.color;
			}
			return Color.white;
		}
		set
		{
			if (numtxtTextcolor2 != value && _onumtxtText2 != null)
			{
				_onumtxtText2.color = value;
			}
		}
	}

	public Color numtxtTextcolor3
	{
		get
		{
			if (_onumtxtText3 != null)
			{
				return _onumtxtText3.color;
			}
			return Color.white;
		}
		set
		{
			if (numtxtTextcolor3 != value && _onumtxtText3 != null)
			{
				_onumtxtText3.color = value;
			}
		}
	}

	public Color numtxtTextcolor4
	{
		get
		{
			if (_onumtxtText4 != null)
			{
				return _onumtxtText4.color;
			}
			return Color.white;
		}
		set
		{
			if (numtxtTextcolor4 != value && _onumtxtText4 != null)
			{
				_onumtxtText4.color = value;
			}
		}
	}

	public Font numtxtTextfont1
	{
		get
		{
			if (_onumtxtText1 != null)
			{
				return _onumtxtText1.font;
			}
			return null;
		}
		set
		{
			if (numtxtTextfont1 != value && _onumtxtText1 != null)
			{
				_onumtxtText1.font = value;
			}
		}
	}

	public Font numtxtTextfont2
	{
		get
		{
			if (_onumtxtText2 != null)
			{
				return _onumtxtText2.font;
			}
			return null;
		}
		set
		{
			if (numtxtTextfont2 != value && _onumtxtText2 != null)
			{
				_onumtxtText2.font = value;
			}
		}
	}

	public Font numtxtTextfont3
	{
		get
		{
			if (_onumtxtText3 != null)
			{
				return _onumtxtText3.font;
			}
			return null;
		}
		set
		{
			if (numtxtTextfont3 != value && _onumtxtText3 != null)
			{
				_onumtxtText3.font = value;
			}
		}
	}

	public Font numtxtTextfont4
	{
		get
		{
			if (_onumtxtText4 != null)
			{
				return _onumtxtText4.font;
			}
			return null;
		}
		set
		{
			if (numtxtTextfont4 != value && _onumtxtText4 != null)
			{
				_onumtxtText4.font = value;
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
			case "pveTDGetMoneyExp":
				_opveTDGetMoneyExp = transform.gameObject;
				break;
			case "Back":
				_oBack = transform.gameObject;
				_oBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "cell1":
				_ocell1 = transform.gameObject;
				_ocellImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "cell2":
				_ocell2 = transform.gameObject;
				_ocellImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "cell3":
				_ocell3 = transform.gameObject;
				_ocellImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "cell4":
				_ocell4 = transform.gameObject;
				_ocellImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "numtxt1":
				_onumtxt1 = transform.gameObject;
				_onumtxtText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "numtxt2":
				_onumtxt2 = transform.gameObject;
				_onumtxtText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "numtxt3":
				_onumtxt3 = transform.gameObject;
				_onumtxtText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "numtxt4":
				_onumtxt4 = transform.gameObject;
				_onumtxtText4 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetcellShow(int index)
	{
		return index switch
		{
			1 => cellShow1, 
			2 => cellShow2, 
			3 => cellShow3, 
			4 => cellShow4, 
			_ => false, 
		};
	}

	public void SetcellShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			cellShow1 = value;
			break;
		case 2:
			cellShow2 = value;
			break;
		case 3:
			cellShow3 = value;
			break;
		case 4:
			cellShow4 = value;
			break;
		}
	}

	public Sprite GetcellSprite(int index)
	{
		return index switch
		{
			1 => cellSprite1, 
			2 => cellSprite2, 
			3 => cellSprite3, 
			4 => cellSprite4, 
			_ => null, 
		};
	}

	public void SetcellSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			cellSprite1 = value;
			break;
		case 2:
			cellSprite2 = value;
			break;
		case 3:
			cellSprite3 = value;
			break;
		case 4:
			cellSprite4 = value;
			break;
		}
	}

	public Color GetcellColor(int index)
	{
		return index switch
		{
			1 => cellColor1, 
			2 => cellColor2, 
			3 => cellColor3, 
			4 => cellColor4, 
			_ => Color.white, 
		};
	}

	public void SetcellColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			cellColor1 = value;
			break;
		case 2:
			cellColor2 = value;
			break;
		case 3:
			cellColor3 = value;
			break;
		case 4:
			cellColor4 = value;
			break;
		}
	}

	public Image GetcellImage(int index)
	{
		return index switch
		{
			1 => cellImage1, 
			2 => cellImage2, 
			3 => cellImage3, 
			4 => cellImage4, 
			_ => null, 
		};
	}

	public void SetcellImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			cellImage1 = value;
			break;
		case 2:
			cellImage2 = value;
			break;
		case 3:
			cellImage3 = value;
			break;
		case 4:
			cellImage4 = value;
			break;
		}
	}

	public bool GetnumtxtShow(int index)
	{
		return index switch
		{
			1 => numtxtShow1, 
			2 => numtxtShow2, 
			3 => numtxtShow3, 
			4 => numtxtShow4, 
			_ => false, 
		};
	}

	public void SetnumtxtShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			numtxtShow1 = value;
			break;
		case 2:
			numtxtShow2 = value;
			break;
		case 3:
			numtxtShow3 = value;
			break;
		case 4:
			numtxtShow4 = value;
			break;
		}
	}

	public string GetnumtxtString(int index)
	{
		return index switch
		{
			1 => numtxtString1, 
			2 => numtxtString2, 
			3 => numtxtString3, 
			4 => numtxtString4, 
			_ => null, 
		};
	}

	public void SetnumtxtString(int index, string value)
	{
		switch (index)
		{
		case 1:
			numtxtString1 = value;
			break;
		case 2:
			numtxtString2 = value;
			break;
		case 3:
			numtxtString3 = value;
			break;
		case 4:
			numtxtString4 = value;
			break;
		}
	}

	public Color GetnumtxtTextcolor(int index)
	{
		return index switch
		{
			1 => numtxtTextcolor1, 
			2 => numtxtTextcolor2, 
			3 => numtxtTextcolor3, 
			4 => numtxtTextcolor4, 
			_ => Color.white, 
		};
	}

	public void SetnumtxtTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			numtxtTextcolor1 = value;
			break;
		case 2:
			numtxtTextcolor2 = value;
			break;
		case 3:
			numtxtTextcolor3 = value;
			break;
		case 4:
			numtxtTextcolor4 = value;
			break;
		}
	}

	public Font GetnumtxtTextfont(int index)
	{
		return index switch
		{
			1 => numtxtTextfont1, 
			2 => numtxtTextfont2, 
			3 => numtxtTextfont3, 
			4 => numtxtTextfont4, 
			_ => null, 
		};
	}

	public void SetnumtxtTextfont(int index, Font value)
	{
		switch (index)
		{
		case 1:
			numtxtTextfont1 = value;
			break;
		case 2:
			numtxtTextfont2 = value;
			break;
		case 3:
			numtxtTextfont3 = value;
			break;
		case 4:
			numtxtTextfont4 = value;
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
