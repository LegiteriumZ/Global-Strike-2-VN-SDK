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

namespace Assets.Sources.Ui.ViewModel.Blast;

[GameUiTest]
public class BlastTacticsSoundViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oTitle;

	private Text _oTitleText;

	private GameObject _oSound1;

	private GameObject _oSound2;

	private GameObject _oSound3;

	private GameObject _oSound4;

	private GameObject _oSound5;

	private GameObject _oSound6;

	private GameObject _oSound7;

	private Text _oSoundText1;

	private Text _oSoundText2;

	private Text _oSoundText3;

	private Text _oSoundText4;

	private Text _oSoundText5;

	private Text _oSoundText6;

	private Text _oSoundText7;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/blast";

	private string _resourceAssetName = "BlastTacticsSound";

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

	public string TitleString
	{
		get
		{
			if (_oTitleText != null)
			{
				return _oTitleText.text;
			}
			return null;
		}
		set
		{
			if (TitleString != value && _oTitleText != null)
			{
				_oTitleText.text = value;
			}
		}
	}

	public bool SoundShow1
	{
		get
		{
			if (_oSound1 != null)
			{
				return _oSound1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SoundShow1 != value && _oSound1 != null)
			{
				_oSound1.SetObjectActive(value);
			}
		}
	}

	public bool SoundShow2
	{
		get
		{
			if (_oSound2 != null)
			{
				return _oSound2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SoundShow2 != value && _oSound2 != null)
			{
				_oSound2.SetObjectActive(value);
			}
		}
	}

	public bool SoundShow3
	{
		get
		{
			if (_oSound3 != null)
			{
				return _oSound3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SoundShow3 != value && _oSound3 != null)
			{
				_oSound3.SetObjectActive(value);
			}
		}
	}

	public bool SoundShow4
	{
		get
		{
			if (_oSound4 != null)
			{
				return _oSound4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SoundShow4 != value && _oSound4 != null)
			{
				_oSound4.SetObjectActive(value);
			}
		}
	}

	public bool SoundShow5
	{
		get
		{
			if (_oSound5 != null)
			{
				return _oSound5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SoundShow5 != value && _oSound5 != null)
			{
				_oSound5.SetObjectActive(value);
			}
		}
	}

	public bool SoundShow6
	{
		get
		{
			if (_oSound6 != null)
			{
				return _oSound6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SoundShow6 != value && _oSound6 != null)
			{
				_oSound6.SetObjectActive(value);
			}
		}
	}

	public bool SoundShow7
	{
		get
		{
			if (_oSound7 != null)
			{
				return _oSound7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SoundShow7 != value && _oSound7 != null)
			{
				_oSound7.SetObjectActive(value);
			}
		}
	}

	public string SoundString1
	{
		get
		{
			if (_oSoundText1 != null)
			{
				return _oSoundText1.text;
			}
			return null;
		}
		set
		{
			if (SoundString1 != value && _oSoundText1 != null)
			{
				_oSoundText1.text = value;
			}
		}
	}

	public string SoundString2
	{
		get
		{
			if (_oSoundText2 != null)
			{
				return _oSoundText2.text;
			}
			return null;
		}
		set
		{
			if (SoundString2 != value && _oSoundText2 != null)
			{
				_oSoundText2.text = value;
			}
		}
	}

	public string SoundString3
	{
		get
		{
			if (_oSoundText3 != null)
			{
				return _oSoundText3.text;
			}
			return null;
		}
		set
		{
			if (SoundString3 != value && _oSoundText3 != null)
			{
				_oSoundText3.text = value;
			}
		}
	}

	public string SoundString4
	{
		get
		{
			if (_oSoundText4 != null)
			{
				return _oSoundText4.text;
			}
			return null;
		}
		set
		{
			if (SoundString4 != value && _oSoundText4 != null)
			{
				_oSoundText4.text = value;
			}
		}
	}

	public string SoundString5
	{
		get
		{
			if (_oSoundText5 != null)
			{
				return _oSoundText5.text;
			}
			return null;
		}
		set
		{
			if (SoundString5 != value && _oSoundText5 != null)
			{
				_oSoundText5.text = value;
			}
		}
	}

	public string SoundString6
	{
		get
		{
			if (_oSoundText6 != null)
			{
				return _oSoundText6.text;
			}
			return null;
		}
		set
		{
			if (SoundString6 != value && _oSoundText6 != null)
			{
				_oSoundText6.text = value;
			}
		}
	}

	public string SoundString7
	{
		get
		{
			if (_oSoundText7 != null)
			{
				return _oSoundText7.text;
			}
			return null;
		}
		set
		{
			if (SoundString7 != value && _oSoundText7 != null)
			{
				_oSoundText7.text = value;
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
			case "Title":
				_oTitle = transform.gameObject;
				_oTitleText = transform.gameObject.GetComponent<Text>();
				break;
			case "Sound1":
				_oSound1 = transform.gameObject;
				_oSoundText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Sound2":
				_oSound2 = transform.gameObject;
				_oSoundText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Sound3":
				_oSound3 = transform.gameObject;
				_oSoundText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Sound4":
				_oSound4 = transform.gameObject;
				_oSoundText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Sound5":
				_oSound5 = transform.gameObject;
				_oSoundText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Sound6":
				_oSound6 = transform.gameObject;
				_oSoundText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Sound7":
				_oSound7 = transform.gameObject;
				_oSoundText7 = transform.gameObject.GetComponent<Text>();
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

	public bool GetSoundShow(int index)
	{
		return index switch
		{
			1 => SoundShow1, 
			2 => SoundShow2, 
			3 => SoundShow3, 
			4 => SoundShow4, 
			5 => SoundShow5, 
			6 => SoundShow6, 
			7 => SoundShow7, 
			_ => false, 
		};
	}

	public void SetSoundShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SoundShow1 = value;
			break;
		case 2:
			SoundShow2 = value;
			break;
		case 3:
			SoundShow3 = value;
			break;
		case 4:
			SoundShow4 = value;
			break;
		case 5:
			SoundShow5 = value;
			break;
		case 6:
			SoundShow6 = value;
			break;
		case 7:
			SoundShow7 = value;
			break;
		}
	}

	public string GetSoundString(int index)
	{
		return index switch
		{
			1 => SoundString1, 
			2 => SoundString2, 
			3 => SoundString3, 
			4 => SoundString4, 
			5 => SoundString5, 
			6 => SoundString6, 
			7 => SoundString7, 
			_ => null, 
		};
	}

	public void SetSoundString(int index, string value)
	{
		switch (index)
		{
		case 1:
			SoundString1 = value;
			break;
		case 2:
			SoundString2 = value;
			break;
		case 3:
			SoundString3 = value;
			break;
		case 4:
			SoundString4 = value;
			break;
		case 5:
			SoundString5 = value;
			break;
		case 6:
			SoundString6 = value;
			break;
		case 7:
			SoundString7 = value;
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
