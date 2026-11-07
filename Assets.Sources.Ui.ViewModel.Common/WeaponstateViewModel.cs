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

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class WeaponstateViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oBack;

	private Image _oBackImage;

	private GameObject _oWeapon;

	private Image _oWeaponImage;

	private GameObject _oWeaponName;

	private Text _oWeaponNameText;

	private GameObject _oWeaponClip1;

	private GameObject _oWeaponClip2;

	private GameObject _oCurrentClip1;

	private GameObject _oCurrentClip2;

	private Text _oCurrentClipText1;

	private Text _oCurrentClipText2;

	private GameObject _oSlashImage1;

	private GameObject _oSlashImage2;

	private GameObject _oCarryClip1;

	private GameObject _oCarryClip2;

	private Text _oCarryClipText1;

	private Text _oCarryClipText2;

	private GameObject _oGrenade1;

	private GameObject _oGrenade2;

	private GameObject _oGrenade3;

	private Image _oGrenadeImage1;

	private Image _oGrenadeImage2;

	private Image _oGrenadeImage3;

	private GameObject _oGrenadeClip1;

	private GameObject _oGrenadeClip2;

	private GameObject _oGrenadeClip3;

	private Text _oGrenadeClipText1;

	private Text _oGrenadeClipText2;

	private Text _oGrenadeClipText3;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Weaponstate";

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

	public string WeaponNameString
	{
		get
		{
			if (_oWeaponNameText != null)
			{
				return _oWeaponNameText.text;
			}
			return null;
		}
		set
		{
			if (WeaponNameString != value && _oWeaponNameText != null)
			{
				_oWeaponNameText.text = value;
			}
		}
	}

	public bool WeaponClipShow1
	{
		get
		{
			if (_oWeaponClip1 != null)
			{
				return _oWeaponClip1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponClipShow1 != value && _oWeaponClip1 != null)
			{
				_oWeaponClip1.SetObjectActive(value);
			}
		}
	}

	public bool WeaponClipShow2
	{
		get
		{
			if (_oWeaponClip2 != null)
			{
				return _oWeaponClip2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponClipShow2 != value && _oWeaponClip2 != null)
			{
				_oWeaponClip2.SetObjectActive(value);
			}
		}
	}

	public string CurrentClipString1
	{
		get
		{
			if (_oCurrentClipText1 != null)
			{
				return _oCurrentClipText1.text;
			}
			return null;
		}
		set
		{
			if (CurrentClipString1 != value && _oCurrentClipText1 != null)
			{
				_oCurrentClipText1.text = value;
			}
		}
	}

	public string CurrentClipString2
	{
		get
		{
			if (_oCurrentClipText2 != null)
			{
				return _oCurrentClipText2.text;
			}
			return null;
		}
		set
		{
			if (CurrentClipString2 != value && _oCurrentClipText2 != null)
			{
				_oCurrentClipText2.text = value;
			}
		}
	}

	public Font CurrentClipTextfont1
	{
		get
		{
			if (_oCurrentClipText1 != null)
			{
				return _oCurrentClipText1.font;
			}
			return null;
		}
		set
		{
			if (CurrentClipTextfont1 != value && _oCurrentClipText1 != null)
			{
				_oCurrentClipText1.font = value;
			}
		}
	}

	public Font CurrentClipTextfont2
	{
		get
		{
			if (_oCurrentClipText2 != null)
			{
				return _oCurrentClipText2.font;
			}
			return null;
		}
		set
		{
			if (CurrentClipTextfont2 != value && _oCurrentClipText2 != null)
			{
				_oCurrentClipText2.font = value;
			}
		}
	}

	public bool SlashImageShow1
	{
		get
		{
			if (_oSlashImage1 != null)
			{
				return _oSlashImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlashImageShow1 != value && _oSlashImage1 != null)
			{
				_oSlashImage1.SetObjectActive(value);
			}
		}
	}

	public bool SlashImageShow2
	{
		get
		{
			if (_oSlashImage2 != null)
			{
				return _oSlashImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SlashImageShow2 != value && _oSlashImage2 != null)
			{
				_oSlashImage2.SetObjectActive(value);
			}
		}
	}

	public string CarryClipString1
	{
		get
		{
			if (_oCarryClipText1 != null)
			{
				return _oCarryClipText1.text;
			}
			return null;
		}
		set
		{
			if (CarryClipString1 != value && _oCarryClipText1 != null)
			{
				_oCarryClipText1.text = value;
			}
		}
	}

	public string CarryClipString2
	{
		get
		{
			if (_oCarryClipText2 != null)
			{
				return _oCarryClipText2.text;
			}
			return null;
		}
		set
		{
			if (CarryClipString2 != value && _oCarryClipText2 != null)
			{
				_oCarryClipText2.text = value;
			}
		}
	}

	public Font CarryClipTextfont1
	{
		get
		{
			if (_oCarryClipText1 != null)
			{
				return _oCarryClipText1.font;
			}
			return null;
		}
		set
		{
			if (CarryClipTextfont1 != value && _oCarryClipText1 != null)
			{
				_oCarryClipText1.font = value;
			}
		}
	}

	public Font CarryClipTextfont2
	{
		get
		{
			if (_oCarryClipText2 != null)
			{
				return _oCarryClipText2.font;
			}
			return null;
		}
		set
		{
			if (CarryClipTextfont2 != value && _oCarryClipText2 != null)
			{
				_oCarryClipText2.font = value;
			}
		}
	}

	public bool GrenadeShow1
	{
		get
		{
			if (_oGrenade1 != null)
			{
				return _oGrenade1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GrenadeShow1 != value && _oGrenade1 != null)
			{
				_oGrenade1.SetObjectActive(value);
			}
		}
	}

	public bool GrenadeShow2
	{
		get
		{
			if (_oGrenade2 != null)
			{
				return _oGrenade2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GrenadeShow2 != value && _oGrenade2 != null)
			{
				_oGrenade2.SetObjectActive(value);
			}
		}
	}

	public bool GrenadeShow3
	{
		get
		{
			if (_oGrenade3 != null)
			{
				return _oGrenade3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GrenadeShow3 != value && _oGrenade3 != null)
			{
				_oGrenade3.SetObjectActive(value);
			}
		}
	}

	public Sprite GrenadeSprite1
	{
		get
		{
			if (_oGrenadeImage1 != null)
			{
				return _oGrenadeImage1.sprite;
			}
			return null;
		}
		set
		{
			if (GrenadeSprite1 != value && _oGrenadeImage1 != null)
			{
				_oGrenadeImage1.sprite = value;
			}
		}
	}

	public Sprite GrenadeSprite2
	{
		get
		{
			if (_oGrenadeImage2 != null)
			{
				return _oGrenadeImage2.sprite;
			}
			return null;
		}
		set
		{
			if (GrenadeSprite2 != value && _oGrenadeImage2 != null)
			{
				_oGrenadeImage2.sprite = value;
			}
		}
	}

	public Sprite GrenadeSprite3
	{
		get
		{
			if (_oGrenadeImage3 != null)
			{
				return _oGrenadeImage3.sprite;
			}
			return null;
		}
		set
		{
			if (GrenadeSprite3 != value && _oGrenadeImage3 != null)
			{
				_oGrenadeImage3.sprite = value;
			}
		}
	}

	public bool GrenadeClipShow1
	{
		get
		{
			if (_oGrenadeClip1 != null)
			{
				return _oGrenadeClip1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GrenadeClipShow1 != value && _oGrenadeClip1 != null)
			{
				_oGrenadeClip1.SetObjectActive(value);
			}
		}
	}

	public bool GrenadeClipShow2
	{
		get
		{
			if (_oGrenadeClip2 != null)
			{
				return _oGrenadeClip2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GrenadeClipShow2 != value && _oGrenadeClip2 != null)
			{
				_oGrenadeClip2.SetObjectActive(value);
			}
		}
	}

	public bool GrenadeClipShow3
	{
		get
		{
			if (_oGrenadeClip3 != null)
			{
				return _oGrenadeClip3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GrenadeClipShow3 != value && _oGrenadeClip3 != null)
			{
				_oGrenadeClip3.SetObjectActive(value);
			}
		}
	}

	public string GrenadeClipString1
	{
		get
		{
			if (_oGrenadeClipText1 != null)
			{
				return _oGrenadeClipText1.text;
			}
			return null;
		}
		set
		{
			if (GrenadeClipString1 != value && _oGrenadeClipText1 != null)
			{
				_oGrenadeClipText1.text = value;
			}
		}
	}

	public string GrenadeClipString2
	{
		get
		{
			if (_oGrenadeClipText2 != null)
			{
				return _oGrenadeClipText2.text;
			}
			return null;
		}
		set
		{
			if (GrenadeClipString2 != value && _oGrenadeClipText2 != null)
			{
				_oGrenadeClipText2.text = value;
			}
		}
	}

	public string GrenadeClipString3
	{
		get
		{
			if (_oGrenadeClipText3 != null)
			{
				return _oGrenadeClipText3.text;
			}
			return null;
		}
		set
		{
			if (GrenadeClipString3 != value && _oGrenadeClipText3 != null)
			{
				_oGrenadeClipText3.text = value;
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
			case "Back":
				_oBack = transform.gameObject;
				_oBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Weapon":
				_oWeapon = transform.gameObject;
				_oWeaponImage = transform.gameObject.GetComponent<Image>();
				break;
			case "WeaponName":
				_oWeaponName = transform.gameObject;
				_oWeaponNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "WeaponClip1":
				_oWeaponClip1 = transform.gameObject;
				break;
			case "WeaponClip2":
				_oWeaponClip2 = transform.gameObject;
				break;
			case "CurrentClip1":
				_oCurrentClip1 = transform.gameObject;
				_oCurrentClipText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CurrentClip2":
				_oCurrentClip2 = transform.gameObject;
				_oCurrentClipText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "SlashImage1":
				_oSlashImage1 = transform.gameObject;
				break;
			case "SlashImage2":
				_oSlashImage2 = transform.gameObject;
				break;
			case "CarryClip1":
				_oCarryClip1 = transform.gameObject;
				_oCarryClipText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CarryClip2":
				_oCarryClip2 = transform.gameObject;
				_oCarryClipText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Grenade1":
				_oGrenade1 = transform.gameObject;
				_oGrenadeImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Grenade2":
				_oGrenade2 = transform.gameObject;
				_oGrenadeImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Grenade3":
				_oGrenade3 = transform.gameObject;
				_oGrenadeImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "GrenadeClip1":
				_oGrenadeClip1 = transform.gameObject;
				_oGrenadeClipText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "GrenadeClip2":
				_oGrenadeClip2 = transform.gameObject;
				_oGrenadeClipText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "GrenadeClip3":
				_oGrenadeClip3 = transform.gameObject;
				_oGrenadeClipText3 = transform.gameObject.GetComponent<Text>();
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

	public void BackNtvsize()
	{
		if (_oBackImage != null)
		{
			_oBackImage.SetNativeSize();
		}
	}

	public void WeaponNtvsize()
	{
		if (_oWeaponImage != null)
		{
			_oWeaponImage.SetNativeSize();
		}
	}

	public bool GetWeaponClipShow(int index)
	{
		return index switch
		{
			1 => WeaponClipShow1, 
			2 => WeaponClipShow2, 
			_ => false, 
		};
	}

	public void SetWeaponClipShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			WeaponClipShow1 = value;
			break;
		case 2:
			WeaponClipShow2 = value;
			break;
		}
	}

	public string GetCurrentClipString(int index)
	{
		return index switch
		{
			1 => CurrentClipString1, 
			2 => CurrentClipString2, 
			_ => null, 
		};
	}

	public void SetCurrentClipString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CurrentClipString1 = value;
			break;
		case 2:
			CurrentClipString2 = value;
			break;
		}
	}

	public Font GetCurrentClipTextfont(int index)
	{
		return index switch
		{
			1 => CurrentClipTextfont1, 
			2 => CurrentClipTextfont2, 
			_ => null, 
		};
	}

	public void SetCurrentClipTextfont(int index, Font value)
	{
		switch (index)
		{
		case 1:
			CurrentClipTextfont1 = value;
			break;
		case 2:
			CurrentClipTextfont2 = value;
			break;
		}
	}

	public bool GetSlashImageShow(int index)
	{
		return index switch
		{
			1 => SlashImageShow1, 
			2 => SlashImageShow2, 
			_ => false, 
		};
	}

	public void SetSlashImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SlashImageShow1 = value;
			break;
		case 2:
			SlashImageShow2 = value;
			break;
		}
	}

	public string GetCarryClipString(int index)
	{
		return index switch
		{
			1 => CarryClipString1, 
			2 => CarryClipString2, 
			_ => null, 
		};
	}

	public void SetCarryClipString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CarryClipString1 = value;
			break;
		case 2:
			CarryClipString2 = value;
			break;
		}
	}

	public Font GetCarryClipTextfont(int index)
	{
		return index switch
		{
			1 => CarryClipTextfont1, 
			2 => CarryClipTextfont2, 
			_ => null, 
		};
	}

	public void SetCarryClipTextfont(int index, Font value)
	{
		switch (index)
		{
		case 1:
			CarryClipTextfont1 = value;
			break;
		case 2:
			CarryClipTextfont2 = value;
			break;
		}
	}

	public bool GetGrenadeShow(int index)
	{
		return index switch
		{
			1 => GrenadeShow1, 
			2 => GrenadeShow2, 
			3 => GrenadeShow3, 
			_ => false, 
		};
	}

	public void SetGrenadeShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			GrenadeShow1 = value;
			break;
		case 2:
			GrenadeShow2 = value;
			break;
		case 3:
			GrenadeShow3 = value;
			break;
		}
	}

	public Sprite GetGrenadeSprite(int index)
	{
		return index switch
		{
			1 => GrenadeSprite1, 
			2 => GrenadeSprite2, 
			3 => GrenadeSprite3, 
			_ => null, 
		};
	}

	public void SetGrenadeSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			GrenadeSprite1 = value;
			break;
		case 2:
			GrenadeSprite2 = value;
			break;
		case 3:
			GrenadeSprite3 = value;
			break;
		}
	}

	public bool GetGrenadeClipShow(int index)
	{
		return index switch
		{
			1 => GrenadeClipShow1, 
			2 => GrenadeClipShow2, 
			3 => GrenadeClipShow3, 
			_ => false, 
		};
	}

	public void SetGrenadeClipShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			GrenadeClipShow1 = value;
			break;
		case 2:
			GrenadeClipShow2 = value;
			break;
		case 3:
			GrenadeClipShow3 = value;
			break;
		}
	}

	public string GetGrenadeClipString(int index)
	{
		return index switch
		{
			1 => GrenadeClipString1, 
			2 => GrenadeClipString2, 
			3 => GrenadeClipString3, 
			_ => null, 
		};
	}

	public void SetGrenadeClipString(int index, string value)
	{
		switch (index)
		{
		case 1:
			GrenadeClipString1 = value;
			break;
		case 2:
			GrenadeClipString2 = value;
			break;
		case 3:
			GrenadeClipString3 = value;
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
