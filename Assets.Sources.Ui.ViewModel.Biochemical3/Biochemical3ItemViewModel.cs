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

namespace Assets.Sources.Ui.ViewModel.Biochemical3;

[GameUiTest]
public class Biochemical3ItemViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oLeft;

	private GameObject _oItem1;

	private GameObject _oItem2;

	private GameObject _oItem3;

	private GameObject _oIcon1;

	private GameObject _oIcon2;

	private GameObject _oIcon3;

	private Image _oIconImage1;

	private Image _oIconImage2;

	private Image _oIconImage3;

	private GameObject _oNeed1;

	private GameObject _oNeed2;

	private GameObject _oNeed3;

	private Text _oNeedText1;

	private Text _oNeedText2;

	private Text _oNeedText3;

	private GameObject _oOwn1;

	private GameObject _oOwn2;

	private GameObject _oOwn3;

	private Text _oOwnText1;

	private Text _oOwnText2;

	private Text _oOwnText3;

	private GameObject _oKey1;

	private GameObject _oKey2;

	private GameObject _oKey3;

	private Text _oKeyText1;

	private Text _oKeyText2;

	private Text _oKeyText3;

	private GameObject _oActive1;

	private GameObject _oActive2;

	private GameObject _oActive3;

	private GameObject _oMask1;

	private GameObject _oMask2;

	private GameObject _oMask3;

	private Image _oMaskImage1;

	private Image _oMaskImage2;

	private Image _oMaskImage3;

	private GameObject _oEffect1;

	private GameObject _oEffect2;

	private GameObject _oEffect3;

	private Image _oEffectImage1;

	private Image _oEffectImage2;

	private Image _oEffectImage3;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical3";

	private string _resourceAssetName = "Biochemical3Item";

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

	public bool LeftShow
	{
		get
		{
			if (_oLeft != null)
			{
				return _oLeft.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LeftShow != value && _oLeft != null)
			{
				_oLeft.SetObjectActive(value);
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

	public bool IconShow1
	{
		get
		{
			if (_oIcon1 != null)
			{
				return _oIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow1 != value && _oIcon1 != null)
			{
				_oIcon1.SetObjectActive(value);
			}
		}
	}

	public bool IconShow2
	{
		get
		{
			if (_oIcon2 != null)
			{
				return _oIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow2 != value && _oIcon2 != null)
			{
				_oIcon2.SetObjectActive(value);
			}
		}
	}

	public bool IconShow3
	{
		get
		{
			if (_oIcon3 != null)
			{
				return _oIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (IconShow3 != value && _oIcon3 != null)
			{
				_oIcon3.SetObjectActive(value);
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

	public Sprite IconSprite3
	{
		get
		{
			if (_oIconImage3 != null)
			{
				return _oIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite3 != value && _oIconImage3 != null)
			{
				_oIconImage3.sprite = value;
			}
		}
	}

	public string NeedString1
	{
		get
		{
			if (_oNeedText1 != null)
			{
				return _oNeedText1.text;
			}
			return null;
		}
		set
		{
			if (NeedString1 != value && _oNeedText1 != null)
			{
				_oNeedText1.text = value;
			}
		}
	}

	public string NeedString2
	{
		get
		{
			if (_oNeedText2 != null)
			{
				return _oNeedText2.text;
			}
			return null;
		}
		set
		{
			if (NeedString2 != value && _oNeedText2 != null)
			{
				_oNeedText2.text = value;
			}
		}
	}

	public string NeedString3
	{
		get
		{
			if (_oNeedText3 != null)
			{
				return _oNeedText3.text;
			}
			return null;
		}
		set
		{
			if (NeedString3 != value && _oNeedText3 != null)
			{
				_oNeedText3.text = value;
			}
		}
	}

	public string OwnString1
	{
		get
		{
			if (_oOwnText1 != null)
			{
				return _oOwnText1.text;
			}
			return null;
		}
		set
		{
			if (OwnString1 != value && _oOwnText1 != null)
			{
				_oOwnText1.text = value;
			}
		}
	}

	public string OwnString2
	{
		get
		{
			if (_oOwnText2 != null)
			{
				return _oOwnText2.text;
			}
			return null;
		}
		set
		{
			if (OwnString2 != value && _oOwnText2 != null)
			{
				_oOwnText2.text = value;
			}
		}
	}

	public string OwnString3
	{
		get
		{
			if (_oOwnText3 != null)
			{
				return _oOwnText3.text;
			}
			return null;
		}
		set
		{
			if (OwnString3 != value && _oOwnText3 != null)
			{
				_oOwnText3.text = value;
			}
		}
	}

	public string KeyString1
	{
		get
		{
			if (_oKeyText1 != null)
			{
				return _oKeyText1.text;
			}
			return null;
		}
		set
		{
			if (KeyString1 != value && _oKeyText1 != null)
			{
				_oKeyText1.text = value;
			}
		}
	}

	public string KeyString2
	{
		get
		{
			if (_oKeyText2 != null)
			{
				return _oKeyText2.text;
			}
			return null;
		}
		set
		{
			if (KeyString2 != value && _oKeyText2 != null)
			{
				_oKeyText2.text = value;
			}
		}
	}

	public string KeyString3
	{
		get
		{
			if (_oKeyText3 != null)
			{
				return _oKeyText3.text;
			}
			return null;
		}
		set
		{
			if (KeyString3 != value && _oKeyText3 != null)
			{
				_oKeyText3.text = value;
			}
		}
	}

	public bool ActiveShow1
	{
		get
		{
			if (_oActive1 != null)
			{
				return _oActive1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ActiveShow1 != value && _oActive1 != null)
			{
				_oActive1.SetObjectActive(value);
			}
		}
	}

	public bool ActiveShow2
	{
		get
		{
			if (_oActive2 != null)
			{
				return _oActive2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ActiveShow2 != value && _oActive2 != null)
			{
				_oActive2.SetObjectActive(value);
			}
		}
	}

	public bool ActiveShow3
	{
		get
		{
			if (_oActive3 != null)
			{
				return _oActive3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ActiveShow3 != value && _oActive3 != null)
			{
				_oActive3.SetObjectActive(value);
			}
		}
	}

	public bool MaskShow1
	{
		get
		{
			if (_oMask1 != null)
			{
				return _oMask1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MaskShow1 != value && _oMask1 != null)
			{
				_oMask1.SetObjectActive(value);
			}
		}
	}

	public bool MaskShow2
	{
		get
		{
			if (_oMask2 != null)
			{
				return _oMask2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MaskShow2 != value && _oMask2 != null)
			{
				_oMask2.SetObjectActive(value);
			}
		}
	}

	public bool MaskShow3
	{
		get
		{
			if (_oMask3 != null)
			{
				return _oMask3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MaskShow3 != value && _oMask3 != null)
			{
				_oMask3.SetObjectActive(value);
			}
		}
	}

	public float MaskFillamount1
	{
		get
		{
			if (_oMaskImage1 != null)
			{
				return _oMaskImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskFillamount1 != value && _oMaskImage1 != null)
			{
				_oMaskImage1.fillAmount = value;
			}
		}
	}

	public float MaskFillamount2
	{
		get
		{
			if (_oMaskImage2 != null)
			{
				return _oMaskImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskFillamount2 != value && _oMaskImage2 != null)
			{
				_oMaskImage2.fillAmount = value;
			}
		}
	}

	public float MaskFillamount3
	{
		get
		{
			if (_oMaskImage3 != null)
			{
				return _oMaskImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (MaskFillamount3 != value && _oMaskImage3 != null)
			{
				_oMaskImage3.fillAmount = value;
			}
		}
	}

	public bool EffectShow1
	{
		get
		{
			if (_oEffect1 != null)
			{
				return _oEffect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow1 != value && _oEffect1 != null)
			{
				_oEffect1.SetObjectActive(value);
			}
		}
	}

	public bool EffectShow2
	{
		get
		{
			if (_oEffect2 != null)
			{
				return _oEffect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow2 != value && _oEffect2 != null)
			{
				_oEffect2.SetObjectActive(value);
			}
		}
	}

	public bool EffectShow3
	{
		get
		{
			if (_oEffect3 != null)
			{
				return _oEffect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow3 != value && _oEffect3 != null)
			{
				_oEffect3.SetObjectActive(value);
			}
		}
	}

	public Sprite EffectSprite1
	{
		get
		{
			if (_oEffectImage1 != null)
			{
				return _oEffectImage1.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite1 != value && _oEffectImage1 != null)
			{
				_oEffectImage1.sprite = value;
			}
		}
	}

	public Sprite EffectSprite2
	{
		get
		{
			if (_oEffectImage2 != null)
			{
				return _oEffectImage2.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite2 != value && _oEffectImage2 != null)
			{
				_oEffectImage2.sprite = value;
			}
		}
	}

	public Sprite EffectSprite3
	{
		get
		{
			if (_oEffectImage3 != null)
			{
				return _oEffectImage3.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite3 != value && _oEffectImage3 != null)
			{
				_oEffectImage3.sprite = value;
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
			case "Left":
				_oLeft = transform.gameObject;
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
			case "Icon1":
				_oIcon1 = transform.gameObject;
				_oIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon2":
				_oIcon2 = transform.gameObject;
				_oIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Icon3":
				_oIcon3 = transform.gameObject;
				_oIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Need1":
				_oNeed1 = transform.gameObject;
				_oNeedText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Need2":
				_oNeed2 = transform.gameObject;
				_oNeedText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Need3":
				_oNeed3 = transform.gameObject;
				_oNeedText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Own1":
				_oOwn1 = transform.gameObject;
				_oOwnText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Own2":
				_oOwn2 = transform.gameObject;
				_oOwnText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Own3":
				_oOwn3 = transform.gameObject;
				_oOwnText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Key1":
				_oKey1 = transform.gameObject;
				_oKeyText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Key2":
				_oKey2 = transform.gameObject;
				_oKeyText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Key3":
				_oKey3 = transform.gameObject;
				_oKeyText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Active1":
				_oActive1 = transform.gameObject;
				break;
			case "Active2":
				_oActive2 = transform.gameObject;
				break;
			case "Active3":
				_oActive3 = transform.gameObject;
				break;
			case "Mask1":
				_oMask1 = transform.gameObject;
				_oMaskImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Mask2":
				_oMask2 = transform.gameObject;
				_oMaskImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Mask3":
				_oMask3 = transform.gameObject;
				_oMaskImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect1":
				_oEffect1 = transform.gameObject;
				_oEffectImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect2":
				_oEffect2 = transform.gameObject;
				_oEffectImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect3":
				_oEffect3 = transform.gameObject;
				_oEffectImage3 = transform.gameObject.GetComponent<Image>();
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

	public bool GetIconShow(int index)
	{
		return index switch
		{
			1 => IconShow1, 
			2 => IconShow2, 
			3 => IconShow3, 
			_ => false, 
		};
	}

	public void SetIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			IconShow1 = value;
			break;
		case 2:
			IconShow2 = value;
			break;
		case 3:
			IconShow3 = value;
			break;
		}
	}

	public Sprite GetIconSprite(int index)
	{
		return index switch
		{
			1 => IconSprite1, 
			2 => IconSprite2, 
			3 => IconSprite3, 
			_ => null, 
		};
	}

	public void SetIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			IconSprite1 = value;
			break;
		case 2:
			IconSprite2 = value;
			break;
		case 3:
			IconSprite3 = value;
			break;
		}
	}

	public string GetNeedString(int index)
	{
		return index switch
		{
			1 => NeedString1, 
			2 => NeedString2, 
			3 => NeedString3, 
			_ => null, 
		};
	}

	public void SetNeedString(int index, string value)
	{
		switch (index)
		{
		case 1:
			NeedString1 = value;
			break;
		case 2:
			NeedString2 = value;
			break;
		case 3:
			NeedString3 = value;
			break;
		}
	}

	public string GetOwnString(int index)
	{
		return index switch
		{
			1 => OwnString1, 
			2 => OwnString2, 
			3 => OwnString3, 
			_ => null, 
		};
	}

	public void SetOwnString(int index, string value)
	{
		switch (index)
		{
		case 1:
			OwnString1 = value;
			break;
		case 2:
			OwnString2 = value;
			break;
		case 3:
			OwnString3 = value;
			break;
		}
	}

	public string GetKeyString(int index)
	{
		return index switch
		{
			1 => KeyString1, 
			2 => KeyString2, 
			3 => KeyString3, 
			_ => null, 
		};
	}

	public void SetKeyString(int index, string value)
	{
		switch (index)
		{
		case 1:
			KeyString1 = value;
			break;
		case 2:
			KeyString2 = value;
			break;
		case 3:
			KeyString3 = value;
			break;
		}
	}

	public bool GetActiveShow(int index)
	{
		return index switch
		{
			1 => ActiveShow1, 
			2 => ActiveShow2, 
			3 => ActiveShow3, 
			_ => false, 
		};
	}

	public void SetActiveShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ActiveShow1 = value;
			break;
		case 2:
			ActiveShow2 = value;
			break;
		case 3:
			ActiveShow3 = value;
			break;
		}
	}

	public bool GetMaskShow(int index)
	{
		return index switch
		{
			1 => MaskShow1, 
			2 => MaskShow2, 
			3 => MaskShow3, 
			_ => false, 
		};
	}

	public void SetMaskShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			MaskShow1 = value;
			break;
		case 2:
			MaskShow2 = value;
			break;
		case 3:
			MaskShow3 = value;
			break;
		}
	}

	public float GetMaskFillamount(int index)
	{
		return index switch
		{
			1 => MaskFillamount1, 
			2 => MaskFillamount2, 
			3 => MaskFillamount3, 
			_ => 0f, 
		};
	}

	public void SetMaskFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			MaskFillamount1 = value;
			break;
		case 2:
			MaskFillamount2 = value;
			break;
		case 3:
			MaskFillamount3 = value;
			break;
		}
	}

	public bool GetEffectShow(int index)
	{
		return index switch
		{
			1 => EffectShow1, 
			2 => EffectShow2, 
			3 => EffectShow3, 
			_ => false, 
		};
	}

	public void SetEffectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			EffectShow1 = value;
			break;
		case 2:
			EffectShow2 = value;
			break;
		case 3:
			EffectShow3 = value;
			break;
		}
	}

	public Sprite GetEffectSprite(int index)
	{
		return index switch
		{
			1 => EffectSprite1, 
			2 => EffectSprite2, 
			3 => EffectSprite3, 
			_ => null, 
		};
	}

	public void SetEffectSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			EffectSprite1 = value;
			break;
		case 2:
			EffectSprite2 = value;
			break;
		case 3:
			EffectSprite3 = value;
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
