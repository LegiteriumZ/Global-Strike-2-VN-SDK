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

namespace Assets.Sources.Ui.ViewModel.HulaoguanModel;

[GameUiTest]
public class HuLaoGuanNewYearLeftViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPlayer1;

	private GameObject _oPlayer2;

	private GameObject _oPlayer3;

	private GameObject _oIcon1;

	private GameObject _oIcon2;

	private GameObject _oIcon3;

	private Image _oIconImage1;

	private Image _oIconImage2;

	private Image _oIconImage3;

	private GameObject _oName1;

	private GameObject _oName2;

	private GameObject _oName3;

	private Text _oNameText1;

	private Text _oNameText2;

	private Text _oNameText3;

	private GameObject _oHpProgressBar1;

	private GameObject _oHpProgressBar2;

	private GameObject _oHpProgressBar3;

	private Image _oHpProgressBarImage1;

	private Image _oHpProgressBarImage2;

	private Image _oHpProgressBarImage3;

	private GameObject _oHpWarnning1;

	private GameObject _oHpWarnning2;

	private GameObject _oHpWarnning3;

	private RectTransform[] _oHpCount1s;

	private RectTransform[] _oHpCount2s;

	private RectTransform[] _oHpCount3s;

	private Text[] _oHpCount1Texts;

	private Text[] _oHpCount2Texts;

	private Text[] _oHpCount3Texts;

	private GameObject _oAcProgressBar1;

	private GameObject _oAcProgressBar2;

	private GameObject _oAcProgressBar3;

	private Image _oAcProgressBarImage1;

	private Image _oAcProgressBarImage2;

	private Image _oAcProgressBarImage3;

	private GameObject _oAcWarnning1;

	private GameObject _oAcWarnning2;

	private GameObject _oAcWarnning3;

	private RectTransform[] _oAcCount1s;

	private RectTransform[] _oAcCount2s;

	private RectTransform[] _oAcCount3s;

	private Text[] _oAcCount1Texts;

	private Text[] _oAcCount2Texts;

	private Text[] _oAcCount3Texts;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/hulaoguanmodel";

	private string _resourceAssetName = "hulaoguannewyearleft";

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

	public float HpProgressBarFillamount1
	{
		get
		{
			if (_oHpProgressBarImage1 != null)
			{
				return _oHpProgressBarImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HpProgressBarFillamount1 != value && _oHpProgressBarImage1 != null)
			{
				_oHpProgressBarImage1.fillAmount = value;
			}
		}
	}

	public float HpProgressBarFillamount2
	{
		get
		{
			if (_oHpProgressBarImage2 != null)
			{
				return _oHpProgressBarImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HpProgressBarFillamount2 != value && _oHpProgressBarImage2 != null)
			{
				_oHpProgressBarImage2.fillAmount = value;
			}
		}
	}

	public float HpProgressBarFillamount3
	{
		get
		{
			if (_oHpProgressBarImage3 != null)
			{
				return _oHpProgressBarImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HpProgressBarFillamount3 != value && _oHpProgressBarImage3 != null)
			{
				_oHpProgressBarImage3.fillAmount = value;
			}
		}
	}

	public bool HpWarnningShow1
	{
		get
		{
			if (_oHpWarnning1 != null)
			{
				return _oHpWarnning1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HpWarnningShow1 != value && _oHpWarnning1 != null)
			{
				_oHpWarnning1.SetObjectActive(value);
			}
		}
	}

	public bool HpWarnningShow2
	{
		get
		{
			if (_oHpWarnning2 != null)
			{
				return _oHpWarnning2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HpWarnningShow2 != value && _oHpWarnning2 != null)
			{
				_oHpWarnning2.SetObjectActive(value);
			}
		}
	}

	public bool HpWarnningShow3
	{
		get
		{
			if (_oHpWarnning3 != null)
			{
				return _oHpWarnning3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HpWarnningShow3 != value && _oHpWarnning3 != null)
			{
				_oHpWarnning3.SetObjectActive(value);
			}
		}
	}

	public float AcProgressBarFillamount1
	{
		get
		{
			if (_oAcProgressBarImage1 != null)
			{
				return _oAcProgressBarImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (AcProgressBarFillamount1 != value && _oAcProgressBarImage1 != null)
			{
				_oAcProgressBarImage1.fillAmount = value;
			}
		}
	}

	public float AcProgressBarFillamount2
	{
		get
		{
			if (_oAcProgressBarImage2 != null)
			{
				return _oAcProgressBarImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (AcProgressBarFillamount2 != value && _oAcProgressBarImage2 != null)
			{
				_oAcProgressBarImage2.fillAmount = value;
			}
		}
	}

	public float AcProgressBarFillamount3
	{
		get
		{
			if (_oAcProgressBarImage3 != null)
			{
				return _oAcProgressBarImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (AcProgressBarFillamount3 != value && _oAcProgressBarImage3 != null)
			{
				_oAcProgressBarImage3.fillAmount = value;
			}
		}
	}

	public bool AcWarnningShow1
	{
		get
		{
			if (_oAcWarnning1 != null)
			{
				return _oAcWarnning1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AcWarnningShow1 != value && _oAcWarnning1 != null)
			{
				_oAcWarnning1.SetObjectActive(value);
			}
		}
	}

	public bool AcWarnningShow2
	{
		get
		{
			if (_oAcWarnning2 != null)
			{
				return _oAcWarnning2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AcWarnningShow2 != value && _oAcWarnning2 != null)
			{
				_oAcWarnning2.SetObjectActive(value);
			}
		}
	}

	public bool AcWarnningShow3
	{
		get
		{
			if (_oAcWarnning3 != null)
			{
				return _oAcWarnning3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AcWarnningShow3 != value && _oAcWarnning3 != null)
			{
				_oAcWarnning3.SetObjectActive(value);
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
			case "Player1":
				_oPlayer1 = transform.gameObject;
				break;
			case "Player2":
				_oPlayer2 = transform.gameObject;
				break;
			case "Player3":
				_oPlayer3 = transform.gameObject;
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
			case "HpProgressBar1":
				_oHpProgressBar1 = transform.gameObject;
				_oHpProgressBarImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "HpProgressBar2":
				_oHpProgressBar2 = transform.gameObject;
				_oHpProgressBarImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "HpProgressBar3":
				_oHpProgressBar3 = transform.gameObject;
				_oHpProgressBarImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "HpWarnning1":
				_oHpWarnning1 = transform.gameObject;
				break;
			case "HpWarnning2":
				_oHpWarnning2 = transform.gameObject;
				break;
			case "HpWarnning3":
				_oHpWarnning3 = transform.gameObject;
				break;
			case "HpCount1":
				_oHpCount1s = transform.GetComponentsInChildren<RectTransform>();
				_oHpCount1Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "HpCount2":
				_oHpCount2s = transform.GetComponentsInChildren<RectTransform>();
				_oHpCount2Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "HpCount3":
				_oHpCount3s = transform.GetComponentsInChildren<RectTransform>();
				_oHpCount3Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "AcProgressBar1":
				_oAcProgressBar1 = transform.gameObject;
				_oAcProgressBarImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "AcProgressBar2":
				_oAcProgressBar2 = transform.gameObject;
				_oAcProgressBarImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "AcProgressBar3":
				_oAcProgressBar3 = transform.gameObject;
				_oAcProgressBarImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "AcWarnning1":
				_oAcWarnning1 = transform.gameObject;
				break;
			case "AcWarnning2":
				_oAcWarnning2 = transform.gameObject;
				break;
			case "AcWarnning3":
				_oAcWarnning3 = transform.gameObject;
				break;
			case "AcCount1":
				_oAcCount1s = transform.GetComponentsInChildren<RectTransform>();
				_oAcCount1Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "AcCount2":
				_oAcCount2s = transform.GetComponentsInChildren<RectTransform>();
				_oAcCount2Texts = transform.GetComponentsInChildren<Text>();
				break;
			case "AcCount3":
				_oAcCount3s = transform.GetComponentsInChildren<RectTransform>();
				_oAcCount3Texts = transform.GetComponentsInChildren<Text>();
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

	public bool GetPlayerShow(int index)
	{
		return index switch
		{
			1 => PlayerShow1, 
			2 => PlayerShow2, 
			3 => PlayerShow3, 
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
		}
	}

	public int GetPlayerCount()
	{
		return 3;
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

	public int GetIconCount()
	{
		return 3;
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

	public string GetNameString(int index)
	{
		return index switch
		{
			1 => NameString1, 
			2 => NameString2, 
			3 => NameString3, 
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
		}
	}

	public int GetNameCount()
	{
		return 3;
	}

	public float GetHpProgressBarFillamount(int index)
	{
		return index switch
		{
			1 => HpProgressBarFillamount1, 
			2 => HpProgressBarFillamount2, 
			3 => HpProgressBarFillamount3, 
			_ => 0f, 
		};
	}

	public void SetHpProgressBarFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			HpProgressBarFillamount1 = value;
			break;
		case 2:
			HpProgressBarFillamount2 = value;
			break;
		case 3:
			HpProgressBarFillamount3 = value;
			break;
		}
	}

	public int GetHpProgressBarCount()
	{
		return 3;
	}

	public bool GetHpWarnningShow(int index)
	{
		return index switch
		{
			1 => HpWarnningShow1, 
			2 => HpWarnningShow2, 
			3 => HpWarnningShow3, 
			_ => false, 
		};
	}

	public void SetHpWarnningShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			HpWarnningShow1 = value;
			break;
		case 2:
			HpWarnningShow2 = value;
			break;
		case 3:
			HpWarnningShow3 = value;
			break;
		}
	}

	public int GetHpWarnningCount()
	{
		return 3;
	}

	public void SetHpCount1ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 4 || _oHpCount1s.Length == 5)
		{
			for (int i = 1; i < _oHpCount1s.Length; i++)
			{
				_oHpCount1s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetHpCount1PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oHpCount1s.Length == 5)
		{
			for (int i = 0; i < _oHpCount1s.Length; i++)
			{
				_oHpCount1s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetHpCount1TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oHpCount1Texts.Length == 2)
		{
			_oHpCount1Texts[0].text = wholeStr;
			_oHpCount1Texts[1].text = decimalStr;
		}
	}

	public void SetHpCount2ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 4 || _oHpCount2s.Length == 5)
		{
			for (int i = 1; i < _oHpCount2s.Length; i++)
			{
				_oHpCount2s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetHpCount2PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oHpCount2s.Length == 5)
		{
			for (int i = 0; i < _oHpCount2s.Length; i++)
			{
				_oHpCount2s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetHpCount2TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oHpCount2Texts.Length == 2)
		{
			_oHpCount2Texts[0].text = wholeStr;
			_oHpCount2Texts[1].text = decimalStr;
		}
	}

	public void SetHpCount3ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 4 || _oHpCount3s.Length == 5)
		{
			for (int i = 1; i < _oHpCount3s.Length; i++)
			{
				_oHpCount3s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetHpCount3PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oHpCount3s.Length == 5)
		{
			for (int i = 0; i < _oHpCount3s.Length; i++)
			{
				_oHpCount3s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetHpCount3TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oHpCount3Texts.Length == 2)
		{
			_oHpCount3Texts[0].text = wholeStr;
			_oHpCount3Texts[1].text = decimalStr;
		}
	}

	public float GetAcProgressBarFillamount(int index)
	{
		return index switch
		{
			1 => AcProgressBarFillamount1, 
			2 => AcProgressBarFillamount2, 
			3 => AcProgressBarFillamount3, 
			_ => 0f, 
		};
	}

	public void SetAcProgressBarFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			AcProgressBarFillamount1 = value;
			break;
		case 2:
			AcProgressBarFillamount2 = value;
			break;
		case 3:
			AcProgressBarFillamount3 = value;
			break;
		}
	}

	public int GetAcProgressBarCount()
	{
		return 3;
	}

	public bool GetAcWarnningShow(int index)
	{
		return index switch
		{
			1 => AcWarnningShow1, 
			2 => AcWarnningShow2, 
			3 => AcWarnningShow3, 
			_ => false, 
		};
	}

	public void SetAcWarnningShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			AcWarnningShow1 = value;
			break;
		case 2:
			AcWarnningShow2 = value;
			break;
		case 3:
			AcWarnningShow3 = value;
			break;
		}
	}

	public int GetAcWarnningCount()
	{
		return 3;
	}

	public void SetAcCount1ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 4 || _oAcCount1s.Length == 5)
		{
			for (int i = 1; i < _oAcCount1s.Length; i++)
			{
				_oAcCount1s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetAcCount1PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oAcCount1s.Length == 5)
		{
			for (int i = 0; i < _oAcCount1s.Length; i++)
			{
				_oAcCount1s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetAcCount1TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oAcCount1Texts.Length == 2)
		{
			_oAcCount1Texts[0].text = wholeStr;
			_oAcCount1Texts[1].text = decimalStr;
		}
	}

	public void SetAcCount2ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 4 || _oAcCount2s.Length == 5)
		{
			for (int i = 1; i < _oAcCount2s.Length; i++)
			{
				_oAcCount2s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetAcCount2PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oAcCount2s.Length == 5)
		{
			for (int i = 0; i < _oAcCount2s.Length; i++)
			{
				_oAcCount2s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetAcCount2TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oAcCount2Texts.Length == 2)
		{
			_oAcCount2Texts[0].text = wholeStr;
			_oAcCount2Texts[1].text = decimalStr;
		}
	}

	public void SetAcCount3ShowLargenumber(bool[] shows)
	{
		if (shows.Length == 4 || _oAcCount3s.Length == 5)
		{
			for (int i = 1; i < _oAcCount3s.Length; i++)
			{
				_oAcCount3s[i].gameObject.SetActive(shows[i - 1]);
			}
		}
	}

	public void SetAcCount3PosiLargenumber(Vector3[] positions)
	{
		if (positions.Length == 5 || _oAcCount3s.Length == 5)
		{
			for (int i = 0; i < _oAcCount3s.Length; i++)
			{
				_oAcCount3s[i].anchoredPosition = positions[i];
			}
		}
	}

	public void SetAcCount3TextLargenumber(string wholeStr, string decimalStr)
	{
		if (_oAcCount3Texts.Length == 2)
		{
			_oAcCount3Texts[0].text = wholeStr;
			_oAcCount3Texts[1].text = decimalStr;
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
