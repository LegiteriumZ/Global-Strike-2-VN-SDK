using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Biochemical;

[GameUiTest]
public class BiochemicalserumViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oHemicalSerumImage;

	private GameObject _oClipImage;

	private GameObject _oItemBack;

	private GameObject _oItem1;

	private GameObject _oItem2;

	private GameObject _oItem3;

	private GameObject _oItemEffect1;

	private GameObject _oItemEffect2;

	private GameObject _oItemEffect3;

	private CanvasGroup _oItemEffectCanvasGroup1;

	private CanvasGroup _oItemEffectCanvasGroup2;

	private CanvasGroup _oItemEffectCanvasGroup3;

	private GameObject _oItemImage1;

	private GameObject _oItemImage2;

	private GameObject _oItemImage3;

	private Image _oItemImageImage1;

	private Image _oItemImageImage2;

	private Image _oItemImageImage3;

	private GameObject _oItemDisable1;

	private GameObject _oItemDisable2;

	private GameObject _oItemDisable3;

	private GameObject _oItemCount1;

	private GameObject _oItemCount2;

	private GameObject _oItemCount3;

	private Text _oItemCountText1;

	private Text _oItemCountText2;

	private Text _oItemCountText3;

	private GameObject _oItemNeed1;

	private GameObject _oItemNeed2;

	private GameObject _oItemNeed3;

	private Text _oItemNeedText1;

	private Text _oItemNeedText2;

	private Text _oItemNeedText3;

	private GameObject _oItemKey1;

	private GameObject _oItemKey2;

	private GameObject _oItemKey3;

	private Text _oItemKeyText1;

	private Text _oItemKeyText2;

	private Text _oItemKeyText3;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/biochemical";

	private string _resourceAssetName = "Biochemicalserum";

	public bool HemicalSerumImageShow
	{
		get
		{
			if (_oHemicalSerumImage != null)
			{
				return _oHemicalSerumImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HemicalSerumImageShow != value && _oHemicalSerumImage != null)
			{
				_oHemicalSerumImage.SetObjectActive(value);
			}
		}
	}

	public bool ClipImageShow
	{
		get
		{
			if (_oClipImage != null)
			{
				return _oClipImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ClipImageShow != value && _oClipImage != null)
			{
				_oClipImage.SetObjectActive(value);
			}
		}
	}

	public bool ItemBackShow
	{
		get
		{
			if (_oItemBack != null)
			{
				return _oItemBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemBackShow != value && _oItemBack != null)
			{
				_oItemBack.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow1
	{
		get
		{
			if (_oItem1 != null)
			{
				return _oItem1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow1 != value && _oItem1 != null)
			{
				_oItem1.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow2
	{
		get
		{
			if (_oItem2 != null)
			{
				return _oItem2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow2 != value && _oItem2 != null)
			{
				_oItem2.SetObjectActive(value);
			}
		}
	}

	public bool ItemShow3
	{
		get
		{
			if (_oItem3 != null)
			{
				return _oItem3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemShow3 != value && _oItem3 != null)
			{
				_oItem3.SetObjectActive(value);
			}
		}
	}

	public bool ItemEffectShow1
	{
		get
		{
			if (_oItemEffect1 != null)
			{
				return _oItemEffect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemEffectShow1 != value && _oItemEffect1 != null)
			{
				_oItemEffect1.SetObjectActive(value);
			}
		}
	}

	public bool ItemEffectShow2
	{
		get
		{
			if (_oItemEffect2 != null)
			{
				return _oItemEffect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemEffectShow2 != value && _oItemEffect2 != null)
			{
				_oItemEffect2.SetObjectActive(value);
			}
		}
	}

	public bool ItemEffectShow3
	{
		get
		{
			if (_oItemEffect3 != null)
			{
				return _oItemEffect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemEffectShow3 != value && _oItemEffect3 != null)
			{
				_oItemEffect3.SetObjectActive(value);
			}
		}
	}

	public float ItemEffectAlpha1
	{
		get
		{
			if (_oItemEffectCanvasGroup1 != null)
			{
				return _oItemEffectCanvasGroup1.alpha;
			}
			return 0f;
		}
		set
		{
			if (ItemEffectAlpha1 != value && _oItemEffectCanvasGroup1 != null)
			{
				_oItemEffectCanvasGroup1.alpha = value;
			}
		}
	}

	public float ItemEffectAlpha2
	{
		get
		{
			if (_oItemEffectCanvasGroup2 != null)
			{
				return _oItemEffectCanvasGroup2.alpha;
			}
			return 0f;
		}
		set
		{
			if (ItemEffectAlpha2 != value && _oItemEffectCanvasGroup2 != null)
			{
				_oItemEffectCanvasGroup2.alpha = value;
			}
		}
	}

	public float ItemEffectAlpha3
	{
		get
		{
			if (_oItemEffectCanvasGroup3 != null)
			{
				return _oItemEffectCanvasGroup3.alpha;
			}
			return 0f;
		}
		set
		{
			if (ItemEffectAlpha3 != value && _oItemEffectCanvasGroup3 != null)
			{
				_oItemEffectCanvasGroup3.alpha = value;
			}
		}
	}

	public Sprite ItemImageSprite1
	{
		get
		{
			if (_oItemImageImage1 != null)
			{
				return _oItemImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (ItemImageSprite1 != value && _oItemImageImage1 != null)
			{
				_oItemImageImage1.sprite = value;
			}
		}
	}

	public Sprite ItemImageSprite2
	{
		get
		{
			if (_oItemImageImage2 != null)
			{
				return _oItemImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (ItemImageSprite2 != value && _oItemImageImage2 != null)
			{
				_oItemImageImage2.sprite = value;
			}
		}
	}

	public Sprite ItemImageSprite3
	{
		get
		{
			if (_oItemImageImage3 != null)
			{
				return _oItemImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (ItemImageSprite3 != value && _oItemImageImage3 != null)
			{
				_oItemImageImage3.sprite = value;
			}
		}
	}

	public bool ItemDisableShow1
	{
		get
		{
			if (_oItemDisable1 != null)
			{
				return _oItemDisable1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemDisableShow1 != value && _oItemDisable1 != null)
			{
				_oItemDisable1.SetObjectActive(value);
			}
		}
	}

	public bool ItemDisableShow2
	{
		get
		{
			if (_oItemDisable2 != null)
			{
				return _oItemDisable2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemDisableShow2 != value && _oItemDisable2 != null)
			{
				_oItemDisable2.SetObjectActive(value);
			}
		}
	}

	public bool ItemDisableShow3
	{
		get
		{
			if (_oItemDisable3 != null)
			{
				return _oItemDisable3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ItemDisableShow3 != value && _oItemDisable3 != null)
			{
				_oItemDisable3.SetObjectActive(value);
			}
		}
	}

	public string ItemCountString1
	{
		get
		{
			if (_oItemCountText1 != null)
			{
				return _oItemCountText1.text;
			}
			return null;
		}
		set
		{
			if (ItemCountString1 != value && _oItemCountText1 != null)
			{
				_oItemCountText1.text = value;
			}
		}
	}

	public string ItemCountString2
	{
		get
		{
			if (_oItemCountText2 != null)
			{
				return _oItemCountText2.text;
			}
			return null;
		}
		set
		{
			if (ItemCountString2 != value && _oItemCountText2 != null)
			{
				_oItemCountText2.text = value;
			}
		}
	}

	public string ItemCountString3
	{
		get
		{
			if (_oItemCountText3 != null)
			{
				return _oItemCountText3.text;
			}
			return null;
		}
		set
		{
			if (ItemCountString3 != value && _oItemCountText3 != null)
			{
				_oItemCountText3.text = value;
			}
		}
	}

	public Font ItemCountTextfont1
	{
		get
		{
			if (_oItemCountText1 != null)
			{
				return _oItemCountText1.font;
			}
			return null;
		}
		set
		{
			if (ItemCountTextfont1 != value && _oItemCountText1 != null)
			{
				_oItemCountText1.font = value;
			}
		}
	}

	public Font ItemCountTextfont2
	{
		get
		{
			if (_oItemCountText2 != null)
			{
				return _oItemCountText2.font;
			}
			return null;
		}
		set
		{
			if (ItemCountTextfont2 != value && _oItemCountText2 != null)
			{
				_oItemCountText2.font = value;
			}
		}
	}

	public Font ItemCountTextfont3
	{
		get
		{
			if (_oItemCountText3 != null)
			{
				return _oItemCountText3.font;
			}
			return null;
		}
		set
		{
			if (ItemCountTextfont3 != value && _oItemCountText3 != null)
			{
				_oItemCountText3.font = value;
			}
		}
	}

	public string ItemNeedString1
	{
		get
		{
			if (_oItemNeedText1 != null)
			{
				return _oItemNeedText1.text;
			}
			return null;
		}
		set
		{
			if (ItemNeedString1 != value && _oItemNeedText1 != null)
			{
				_oItemNeedText1.text = value;
			}
		}
	}

	public string ItemNeedString2
	{
		get
		{
			if (_oItemNeedText2 != null)
			{
				return _oItemNeedText2.text;
			}
			return null;
		}
		set
		{
			if (ItemNeedString2 != value && _oItemNeedText2 != null)
			{
				_oItemNeedText2.text = value;
			}
		}
	}

	public string ItemNeedString3
	{
		get
		{
			if (_oItemNeedText3 != null)
			{
				return _oItemNeedText3.text;
			}
			return null;
		}
		set
		{
			if (ItemNeedString3 != value && _oItemNeedText3 != null)
			{
				_oItemNeedText3.text = value;
			}
		}
	}

	public Font ItemNeedTextfont1
	{
		get
		{
			if (_oItemNeedText1 != null)
			{
				return _oItemNeedText1.font;
			}
			return null;
		}
		set
		{
			if (ItemNeedTextfont1 != value && _oItemNeedText1 != null)
			{
				_oItemNeedText1.font = value;
			}
		}
	}

	public Font ItemNeedTextfont2
	{
		get
		{
			if (_oItemNeedText2 != null)
			{
				return _oItemNeedText2.font;
			}
			return null;
		}
		set
		{
			if (ItemNeedTextfont2 != value && _oItemNeedText2 != null)
			{
				_oItemNeedText2.font = value;
			}
		}
	}

	public Font ItemNeedTextfont3
	{
		get
		{
			if (_oItemNeedText3 != null)
			{
				return _oItemNeedText3.font;
			}
			return null;
		}
		set
		{
			if (ItemNeedTextfont3 != value && _oItemNeedText3 != null)
			{
				_oItemNeedText3.font = value;
			}
		}
	}

	public string ItemKeyString1
	{
		get
		{
			if (_oItemKeyText1 != null)
			{
				return _oItemKeyText1.text;
			}
			return null;
		}
		set
		{
			if (ItemKeyString1 != value && _oItemKeyText1 != null)
			{
				_oItemKeyText1.text = value;
			}
		}
	}

	public string ItemKeyString2
	{
		get
		{
			if (_oItemKeyText2 != null)
			{
				return _oItemKeyText2.text;
			}
			return null;
		}
		set
		{
			if (ItemKeyString2 != value && _oItemKeyText2 != null)
			{
				_oItemKeyText2.text = value;
			}
		}
	}

	public string ItemKeyString3
	{
		get
		{
			if (_oItemKeyText3 != null)
			{
				return _oItemKeyText3.text;
			}
			return null;
		}
		set
		{
			if (ItemKeyString3 != value && _oItemKeyText3 != null)
			{
				_oItemKeyText3.text = value;
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
			case "HemicalSerumImage":
				_oHemicalSerumImage = transform.gameObject;
				break;
			case "ClipImage":
				_oClipImage = transform.gameObject;
				break;
			case "ItemBack":
				_oItemBack = transform.gameObject;
				break;
			case "Item1":
				_oItem1 = transform.gameObject;
				break;
			case "Item2":
				_oItem2 = transform.gameObject;
				break;
			case "Item3":
				_oItem3 = transform.gameObject;
				break;
			case "ItemEffect1":
				_oItemEffect1 = transform.gameObject;
				_oItemEffectCanvasGroup1 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "ItemEffect2":
				_oItemEffect2 = transform.gameObject;
				_oItemEffectCanvasGroup2 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "ItemEffect3":
				_oItemEffect3 = transform.gameObject;
				_oItemEffectCanvasGroup3 = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "ItemImage1":
				_oItemImage1 = transform.gameObject;
				_oItemImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "ItemImage2":
				_oItemImage2 = transform.gameObject;
				_oItemImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "ItemImage3":
				_oItemImage3 = transform.gameObject;
				_oItemImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "ItemDisable1":
				_oItemDisable1 = transform.gameObject;
				break;
			case "ItemDisable2":
				_oItemDisable2 = transform.gameObject;
				break;
			case "ItemDisable3":
				_oItemDisable3 = transform.gameObject;
				break;
			case "ItemCount1":
				_oItemCount1 = transform.gameObject;
				_oItemCountText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "ItemCount2":
				_oItemCount2 = transform.gameObject;
				_oItemCountText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "ItemCount3":
				_oItemCount3 = transform.gameObject;
				_oItemCountText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "ItemNeed1":
				_oItemNeed1 = transform.gameObject;
				_oItemNeedText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "ItemNeed2":
				_oItemNeed2 = transform.gameObject;
				_oItemNeedText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "ItemNeed3":
				_oItemNeed3 = transform.gameObject;
				_oItemNeedText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "ItemKey1":
				_oItemKey1 = transform.gameObject;
				_oItemKeyText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "ItemKey2":
				_oItemKey2 = transform.gameObject;
				_oItemKeyText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "ItemKey3":
				_oItemKey3 = transform.gameObject;
				_oItemKeyText3 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetItemShow(int index)
	{
		return index switch
		{
			1 => ItemShow1, 
			2 => ItemShow2, 
			3 => ItemShow3, 
			_ => false, 
		};
	}

	public void SetItemShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ItemShow1 = value;
			break;
		case 2:
			ItemShow2 = value;
			break;
		case 3:
			ItemShow3 = value;
			break;
		}
	}

	public bool GetItemEffectShow(int index)
	{
		return index switch
		{
			1 => ItemEffectShow1, 
			2 => ItemEffectShow2, 
			3 => ItemEffectShow3, 
			_ => false, 
		};
	}

	public void SetItemEffectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ItemEffectShow1 = value;
			break;
		case 2:
			ItemEffectShow2 = value;
			break;
		case 3:
			ItemEffectShow3 = value;
			break;
		}
	}

	public float GetItemEffectAlpha(int index)
	{
		return index switch
		{
			1 => ItemEffectAlpha1, 
			2 => ItemEffectAlpha2, 
			3 => ItemEffectAlpha3, 
			_ => 0f, 
		};
	}

	public void SetItemEffectAlpha(int index, float value)
	{
		switch (index)
		{
		case 1:
			ItemEffectAlpha1 = value;
			break;
		case 2:
			ItemEffectAlpha2 = value;
			break;
		case 3:
			ItemEffectAlpha3 = value;
			break;
		}
	}

	public Sprite GetItemImageSprite(int index)
	{
		return index switch
		{
			1 => ItemImageSprite1, 
			2 => ItemImageSprite2, 
			3 => ItemImageSprite3, 
			_ => null, 
		};
	}

	public void SetItemImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			ItemImageSprite1 = value;
			break;
		case 2:
			ItemImageSprite2 = value;
			break;
		case 3:
			ItemImageSprite3 = value;
			break;
		}
	}

	public bool GetItemDisableShow(int index)
	{
		return index switch
		{
			1 => ItemDisableShow1, 
			2 => ItemDisableShow2, 
			3 => ItemDisableShow3, 
			_ => false, 
		};
	}

	public void SetItemDisableShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ItemDisableShow1 = value;
			break;
		case 2:
			ItemDisableShow2 = value;
			break;
		case 3:
			ItemDisableShow3 = value;
			break;
		}
	}

	public string GetItemCountString(int index)
	{
		return index switch
		{
			1 => ItemCountString1, 
			2 => ItemCountString2, 
			3 => ItemCountString3, 
			_ => null, 
		};
	}

	public void SetItemCountString(int index, string value)
	{
		switch (index)
		{
		case 1:
			ItemCountString1 = value;
			break;
		case 2:
			ItemCountString2 = value;
			break;
		case 3:
			ItemCountString3 = value;
			break;
		}
	}

	public Font GetItemCountTextfont(int index)
	{
		return index switch
		{
			1 => ItemCountTextfont1, 
			2 => ItemCountTextfont2, 
			3 => ItemCountTextfont3, 
			_ => null, 
		};
	}

	public void SetItemCountTextfont(int index, Font value)
	{
		switch (index)
		{
		case 1:
			ItemCountTextfont1 = value;
			break;
		case 2:
			ItemCountTextfont2 = value;
			break;
		case 3:
			ItemCountTextfont3 = value;
			break;
		}
	}

	public string GetItemNeedString(int index)
	{
		return index switch
		{
			1 => ItemNeedString1, 
			2 => ItemNeedString2, 
			3 => ItemNeedString3, 
			_ => null, 
		};
	}

	public void SetItemNeedString(int index, string value)
	{
		switch (index)
		{
		case 1:
			ItemNeedString1 = value;
			break;
		case 2:
			ItemNeedString2 = value;
			break;
		case 3:
			ItemNeedString3 = value;
			break;
		}
	}

	public Font GetItemNeedTextfont(int index)
	{
		return index switch
		{
			1 => ItemNeedTextfont1, 
			2 => ItemNeedTextfont2, 
			3 => ItemNeedTextfont3, 
			_ => null, 
		};
	}

	public void SetItemNeedTextfont(int index, Font value)
	{
		switch (index)
		{
		case 1:
			ItemNeedTextfont1 = value;
			break;
		case 2:
			ItemNeedTextfont2 = value;
			break;
		case 3:
			ItemNeedTextfont3 = value;
			break;
		}
	}

	public string GetItemKeyString(int index)
	{
		return index switch
		{
			1 => ItemKeyString1, 
			2 => ItemKeyString2, 
			3 => ItemKeyString3, 
			_ => null, 
		};
	}

	public void SetItemKeyString(int index, string value)
	{
		switch (index)
		{
		case 1:
			ItemKeyString1 = value;
			break;
		case 2:
			ItemKeyString2 = value;
			break;
		case 3:
			ItemKeyString3 = value;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
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
}
