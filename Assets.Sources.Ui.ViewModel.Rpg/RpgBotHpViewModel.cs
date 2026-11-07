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

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgBotHpViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oNameLabel;

	private Text _oNameLabelText;

	private GameObject _oHpPercentEffect;

	private Image _oHpPercentEffectImage;

	private GameObject _oHpPercentBar;

	private Image _oHpPercentBarImage;

	private GameObject _oAttributeImage1;

	private GameObject _oAttributeImage2;

	private GameObject _oAttributeImage3;

	private GameObject _oAttributeImage4;

	private Image _oAttributeImageImage1;

	private Image _oAttributeImageImage2;

	private Image _oAttributeImageImage3;

	private Image _oAttributeImageImage4;

	private GameObject _oLvLabel;

	private Text _oLvLabelText;

	private GameObject _oKulouImage;

	private GameObject _oAttack1;

	private GameObject _oAttack2;

	private GameObject _oAttackType1;

	private GameObject _oAttackType2;

	private Text _oAttackTypeText1;

	private Text _oAttackTypeText2;

	private GameObject _oRace1;

	private GameObject _oRace2;

	private GameObject _oRace3;

	private GameObject _oRace4;

	private GameObject _oRace5;

	private GameObject _oRaceName1;

	private GameObject _oRaceName2;

	private GameObject _oRaceName3;

	private GameObject _oRaceName4;

	private GameObject _oRaceName5;

	private Text _oRaceNameText1;

	private Text _oRaceNameText2;

	private Text _oRaceNameText3;

	private Text _oRaceNameText4;

	private Text _oRaceNameText5;

	private GameObject _oTitle;

	private Image _oTitleImage;

	private GameObject _oAddResis;

	private GameObject _obgYan;

	private GameObject _obgYin;

	private GameObject _oYanHpImage;

	private Image _oYanHpImageImage;

	private GameObject _oYinHpImage;

	private Image _oYinHpImageImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "rpgbothp";

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

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public string NameLabelString
	{
		get
		{
			if (_oNameLabelText != null)
			{
				return _oNameLabelText.text;
			}
			return null;
		}
		set
		{
			if (NameLabelString != value && _oNameLabelText != null)
			{
				_oNameLabelText.text = value;
			}
		}
	}

	public float HpPercentEffectFillamount
	{
		get
		{
			if (_oHpPercentEffectImage != null)
			{
				return _oHpPercentEffectImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HpPercentEffectFillamount != value && _oHpPercentEffectImage != null)
			{
				_oHpPercentEffectImage.fillAmount = value;
			}
		}
	}

	public float HpPercentBarFillamount
	{
		get
		{
			if (_oHpPercentBarImage != null)
			{
				return _oHpPercentBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HpPercentBarFillamount != value && _oHpPercentBarImage != null)
			{
				_oHpPercentBarImage.fillAmount = value;
			}
		}
	}

	public bool AttributeImageShow1
	{
		get
		{
			if (_oAttributeImage1 != null)
			{
				return _oAttributeImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttributeImageShow1 != value && _oAttributeImage1 != null)
			{
				_oAttributeImage1.SetObjectActive(value);
			}
		}
	}

	public bool AttributeImageShow2
	{
		get
		{
			if (_oAttributeImage2 != null)
			{
				return _oAttributeImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttributeImageShow2 != value && _oAttributeImage2 != null)
			{
				_oAttributeImage2.SetObjectActive(value);
			}
		}
	}

	public bool AttributeImageShow3
	{
		get
		{
			if (_oAttributeImage3 != null)
			{
				return _oAttributeImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttributeImageShow3 != value && _oAttributeImage3 != null)
			{
				_oAttributeImage3.SetObjectActive(value);
			}
		}
	}

	public bool AttributeImageShow4
	{
		get
		{
			if (_oAttributeImage4 != null)
			{
				return _oAttributeImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttributeImageShow4 != value && _oAttributeImage4 != null)
			{
				_oAttributeImage4.SetObjectActive(value);
			}
		}
	}

	public Sprite AttributeImageSprite1
	{
		get
		{
			if (_oAttributeImageImage1 != null)
			{
				return _oAttributeImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (AttributeImageSprite1 != value && _oAttributeImageImage1 != null)
			{
				_oAttributeImageImage1.sprite = value;
			}
		}
	}

	public Sprite AttributeImageSprite2
	{
		get
		{
			if (_oAttributeImageImage2 != null)
			{
				return _oAttributeImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (AttributeImageSprite2 != value && _oAttributeImageImage2 != null)
			{
				_oAttributeImageImage2.sprite = value;
			}
		}
	}

	public Sprite AttributeImageSprite3
	{
		get
		{
			if (_oAttributeImageImage3 != null)
			{
				return _oAttributeImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (AttributeImageSprite3 != value && _oAttributeImageImage3 != null)
			{
				_oAttributeImageImage3.sprite = value;
			}
		}
	}

	public Sprite AttributeImageSprite4
	{
		get
		{
			if (_oAttributeImageImage4 != null)
			{
				return _oAttributeImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (AttributeImageSprite4 != value && _oAttributeImageImage4 != null)
			{
				_oAttributeImageImage4.sprite = value;
			}
		}
	}

	public string LvLabelString
	{
		get
		{
			if (_oLvLabelText != null)
			{
				return _oLvLabelText.text;
			}
			return null;
		}
		set
		{
			if (LvLabelString != value && _oLvLabelText != null)
			{
				_oLvLabelText.text = value;
			}
		}
	}

	public Color LvLabelTextcolor
	{
		get
		{
			if (_oLvLabelText != null)
			{
				return _oLvLabelText.color;
			}
			return Color.white;
		}
		set
		{
			if (LvLabelTextcolor != value && _oLvLabelText != null)
			{
				_oLvLabelText.color = value;
			}
		}
	}

	public bool KulouImageShow
	{
		get
		{
			if (_oKulouImage != null)
			{
				return _oKulouImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KulouImageShow != value && _oKulouImage != null)
			{
				_oKulouImage.SetObjectActive(value);
			}
		}
	}

	public bool AttackShow1
	{
		get
		{
			if (_oAttack1 != null)
			{
				return _oAttack1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttackShow1 != value && _oAttack1 != null)
			{
				_oAttack1.SetObjectActive(value);
			}
		}
	}

	public bool AttackShow2
	{
		get
		{
			if (_oAttack2 != null)
			{
				return _oAttack2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AttackShow2 != value && _oAttack2 != null)
			{
				_oAttack2.SetObjectActive(value);
			}
		}
	}

	public string AttackTypeString1
	{
		get
		{
			if (_oAttackTypeText1 != null)
			{
				return _oAttackTypeText1.text;
			}
			return null;
		}
		set
		{
			if (AttackTypeString1 != value && _oAttackTypeText1 != null)
			{
				_oAttackTypeText1.text = value;
			}
		}
	}

	public string AttackTypeString2
	{
		get
		{
			if (_oAttackTypeText2 != null)
			{
				return _oAttackTypeText2.text;
			}
			return null;
		}
		set
		{
			if (AttackTypeString2 != value && _oAttackTypeText2 != null)
			{
				_oAttackTypeText2.text = value;
			}
		}
	}

	public bool RaceShow1
	{
		get
		{
			if (_oRace1 != null)
			{
				return _oRace1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RaceShow1 != value && _oRace1 != null)
			{
				_oRace1.SetObjectActive(value);
			}
		}
	}

	public bool RaceShow2
	{
		get
		{
			if (_oRace2 != null)
			{
				return _oRace2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RaceShow2 != value && _oRace2 != null)
			{
				_oRace2.SetObjectActive(value);
			}
		}
	}

	public bool RaceShow3
	{
		get
		{
			if (_oRace3 != null)
			{
				return _oRace3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RaceShow3 != value && _oRace3 != null)
			{
				_oRace3.SetObjectActive(value);
			}
		}
	}

	public bool RaceShow4
	{
		get
		{
			if (_oRace4 != null)
			{
				return _oRace4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RaceShow4 != value && _oRace4 != null)
			{
				_oRace4.SetObjectActive(value);
			}
		}
	}

	public bool RaceShow5
	{
		get
		{
			if (_oRace5 != null)
			{
				return _oRace5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RaceShow5 != value && _oRace5 != null)
			{
				_oRace5.SetObjectActive(value);
			}
		}
	}

	public string RaceNameString1
	{
		get
		{
			if (_oRaceNameText1 != null)
			{
				return _oRaceNameText1.text;
			}
			return null;
		}
		set
		{
			if (RaceNameString1 != value && _oRaceNameText1 != null)
			{
				_oRaceNameText1.text = value;
			}
		}
	}

	public string RaceNameString2
	{
		get
		{
			if (_oRaceNameText2 != null)
			{
				return _oRaceNameText2.text;
			}
			return null;
		}
		set
		{
			if (RaceNameString2 != value && _oRaceNameText2 != null)
			{
				_oRaceNameText2.text = value;
			}
		}
	}

	public string RaceNameString3
	{
		get
		{
			if (_oRaceNameText3 != null)
			{
				return _oRaceNameText3.text;
			}
			return null;
		}
		set
		{
			if (RaceNameString3 != value && _oRaceNameText3 != null)
			{
				_oRaceNameText3.text = value;
			}
		}
	}

	public string RaceNameString4
	{
		get
		{
			if (_oRaceNameText4 != null)
			{
				return _oRaceNameText4.text;
			}
			return null;
		}
		set
		{
			if (RaceNameString4 != value && _oRaceNameText4 != null)
			{
				_oRaceNameText4.text = value;
			}
		}
	}

	public string RaceNameString5
	{
		get
		{
			if (_oRaceNameText5 != null)
			{
				return _oRaceNameText5.text;
			}
			return null;
		}
		set
		{
			if (RaceNameString5 != value && _oRaceNameText5 != null)
			{
				_oRaceNameText5.text = value;
			}
		}
	}

	public bool TitleShow
	{
		get
		{
			if (_oTitle != null)
			{
				return _oTitle.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TitleShow != value && _oTitle != null)
			{
				_oTitle.SetObjectActive(value);
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

	public bool AddResisShow
	{
		get
		{
			if (_oAddResis != null)
			{
				return _oAddResis.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AddResisShow != value && _oAddResis != null)
			{
				_oAddResis.SetObjectActive(value);
			}
		}
	}

	public bool bgYanShow
	{
		get
		{
			if (_obgYan != null)
			{
				return _obgYan.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgYanShow != value && _obgYan != null)
			{
				_obgYan.SetObjectActive(value);
			}
		}
	}

	public bool bgYinShow
	{
		get
		{
			if (_obgYin != null)
			{
				return _obgYin.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgYinShow != value && _obgYin != null)
			{
				_obgYin.SetObjectActive(value);
			}
		}
	}

	public float YanHpImageFillamount
	{
		get
		{
			if (_oYanHpImageImage != null)
			{
				return _oYanHpImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (YanHpImageFillamount != value && _oYanHpImageImage != null)
			{
				_oYanHpImageImage.fillAmount = value;
			}
		}
	}

	public float YinHpImageFillamount
	{
		get
		{
			if (_oYinHpImageImage != null)
			{
				return _oYinHpImageImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (YinHpImageFillamount != value && _oYinHpImageImage != null)
			{
				_oYinHpImageImage.fillAmount = value;
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
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "NameLabel":
				_oNameLabel = transform.gameObject;
				_oNameLabelText = transform.gameObject.GetComponent<Text>();
				break;
			case "HpPercentEffect":
				_oHpPercentEffect = transform.gameObject;
				_oHpPercentEffectImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HpPercentBar":
				_oHpPercentBar = transform.gameObject;
				_oHpPercentBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "AttributeImage1":
				_oAttributeImage1 = transform.gameObject;
				_oAttributeImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "AttributeImage2":
				_oAttributeImage2 = transform.gameObject;
				_oAttributeImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "AttributeImage3":
				_oAttributeImage3 = transform.gameObject;
				_oAttributeImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "AttributeImage4":
				_oAttributeImage4 = transform.gameObject;
				_oAttributeImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "LvLabel":
				_oLvLabel = transform.gameObject;
				_oLvLabelText = transform.gameObject.GetComponent<Text>();
				break;
			case "KulouImage":
				_oKulouImage = transform.gameObject;
				break;
			case "Attack1":
				_oAttack1 = transform.gameObject;
				break;
			case "Attack2":
				_oAttack2 = transform.gameObject;
				break;
			case "AttackType1":
				_oAttackType1 = transform.gameObject;
				_oAttackTypeText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "AttackType2":
				_oAttackType2 = transform.gameObject;
				_oAttackTypeText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Race1":
				_oRace1 = transform.gameObject;
				break;
			case "Race2":
				_oRace2 = transform.gameObject;
				break;
			case "Race3":
				_oRace3 = transform.gameObject;
				break;
			case "Race4":
				_oRace4 = transform.gameObject;
				break;
			case "Race5":
				_oRace5 = transform.gameObject;
				break;
			case "RaceName1":
				_oRaceName1 = transform.gameObject;
				_oRaceNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "RaceName2":
				_oRaceName2 = transform.gameObject;
				_oRaceNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "RaceName3":
				_oRaceName3 = transform.gameObject;
				_oRaceNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "RaceName4":
				_oRaceName4 = transform.gameObject;
				_oRaceNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "RaceName5":
				_oRaceName5 = transform.gameObject;
				_oRaceNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Title":
				_oTitle = transform.gameObject;
				_oTitleImage = transform.gameObject.GetComponent<Image>();
				break;
			case "AddResis":
				_oAddResis = transform.gameObject;
				break;
			case "bgYan":
				_obgYan = transform.gameObject;
				break;
			case "bgYin":
				_obgYin = transform.gameObject;
				break;
			case "YanHpImage":
				_oYanHpImage = transform.gameObject;
				_oYanHpImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "YinHpImage":
				_oYinHpImage = transform.gameObject;
				_oYinHpImageImage = transform.gameObject.GetComponent<Image>();
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

	public bool GetAttributeImageShow(int index)
	{
		return index switch
		{
			1 => AttributeImageShow1, 
			2 => AttributeImageShow2, 
			3 => AttributeImageShow3, 
			4 => AttributeImageShow4, 
			_ => false, 
		};
	}

	public void SetAttributeImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			AttributeImageShow1 = value;
			break;
		case 2:
			AttributeImageShow2 = value;
			break;
		case 3:
			AttributeImageShow3 = value;
			break;
		case 4:
			AttributeImageShow4 = value;
			break;
		}
	}

	public int GetAttributeImageCount()
	{
		return 4;
	}

	public Sprite GetAttributeImageSprite(int index)
	{
		return index switch
		{
			1 => AttributeImageSprite1, 
			2 => AttributeImageSprite2, 
			3 => AttributeImageSprite3, 
			4 => AttributeImageSprite4, 
			_ => null, 
		};
	}

	public void SetAttributeImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			AttributeImageSprite1 = value;
			break;
		case 2:
			AttributeImageSprite2 = value;
			break;
		case 3:
			AttributeImageSprite3 = value;
			break;
		case 4:
			AttributeImageSprite4 = value;
			break;
		}
	}

	public bool GetAttackShow(int index)
	{
		return index switch
		{
			1 => AttackShow1, 
			2 => AttackShow2, 
			_ => false, 
		};
	}

	public void SetAttackShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			AttackShow1 = value;
			break;
		case 2:
			AttackShow2 = value;
			break;
		}
	}

	public int GetAttackCount()
	{
		return 2;
	}

	public string GetAttackTypeString(int index)
	{
		return index switch
		{
			1 => AttackTypeString1, 
			2 => AttackTypeString2, 
			_ => null, 
		};
	}

	public void SetAttackTypeString(int index, string value)
	{
		switch (index)
		{
		case 1:
			AttackTypeString1 = value;
			break;
		case 2:
			AttackTypeString2 = value;
			break;
		}
	}

	public int GetAttackTypeCount()
	{
		return 2;
	}

	public bool GetRaceShow(int index)
	{
		return index switch
		{
			1 => RaceShow1, 
			2 => RaceShow2, 
			3 => RaceShow3, 
			4 => RaceShow4, 
			5 => RaceShow5, 
			_ => false, 
		};
	}

	public void SetRaceShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			RaceShow1 = value;
			break;
		case 2:
			RaceShow2 = value;
			break;
		case 3:
			RaceShow3 = value;
			break;
		case 4:
			RaceShow4 = value;
			break;
		case 5:
			RaceShow5 = value;
			break;
		}
	}

	public int GetRaceCount()
	{
		return 5;
	}

	public string GetRaceNameString(int index)
	{
		return index switch
		{
			1 => RaceNameString1, 
			2 => RaceNameString2, 
			3 => RaceNameString3, 
			4 => RaceNameString4, 
			5 => RaceNameString5, 
			_ => null, 
		};
	}

	public void SetRaceNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			RaceNameString1 = value;
			break;
		case 2:
			RaceNameString2 = value;
			break;
		case 3:
			RaceNameString3 = value;
			break;
		case 4:
			RaceNameString4 = value;
			break;
		case 5:
			RaceNameString5 = value;
			break;
		}
	}

	public int GetRaceNameCount()
	{
		return 5;
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
