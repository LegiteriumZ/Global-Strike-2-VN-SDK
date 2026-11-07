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
public class CommonIndividualScoreCellViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oSelfBack;

	private GameObject _oSelfTeamBack;

	private GameObject _oUnityFlag;

	private GameObject _oRankText;

	private Text _oRankTextText;

	private GameObject _oCareerImage;

	private Image _oCareerImageImage;

	private GameObject _oPlayerDead;

	private GameObject _oPlayerRankHonor;

	private Image _oPlayerRankHonorImage;

	private GameObject _oPlayerRankHonorDes;

	private Text _oPlayerRankHonorDesText;

	private GameObject _oHeroImage;

	private GameObject _oPlayerHonor1;

	private GameObject _oPlayerHonor2;

	private GameObject _oPlayerHonor3;

	private Image _oPlayerHonorImage1;

	private Image _oPlayerHonorImage2;

	private Image _oPlayerHonorImage3;

	private GameObject _oPlayerName;

	private Text _oPlayerNameText;

	private GameObject _oPlayerTeam;

	private Text _oPlayerTeamText;

	private GameObject _oPlayerPing;

	private Text _oPlayerPingText;

	private GameObject _oVip;

	private Image _oVipImage;

	private GameObject _oPlayerScore1;

	private GameObject _oPlayerScore2;

	private GameObject _oPlayerScore3;

	private GameObject _oPlayerScore4;

	private GameObject _oPlayerScore5;

	private GameObject _oPlayerScore6;

	private Text _oPlayerScoreText1;

	private Text _oPlayerScoreText2;

	private Text _oPlayerScoreText3;

	private Text _oPlayerScoreText4;

	private Text _oPlayerScoreText5;

	private Text _oPlayerScoreText6;

	private GameObject _oWeapon;

	private Text _oWeaponText;

	private GameObject _oPlayerDuiwu;

	private Text _oPlayerDuiwuText;

	private GameObject _oPlayerLevel;

	private Text _oPlayerLevelText;

	private GameObject _bigHeadImage;

	private Image _bigHeadImageImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "CommonIndividualScoreCell";

	private List<RectTransform> _holdPosTrans;

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

	public bool SelfBackShow
	{
		get
		{
			if (_oSelfBack != null)
			{
				return _oSelfBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfBackShow != value && _oSelfBack != null)
			{
				_oSelfBack.SetObjectActive(value);
			}
		}
	}

	public bool SelfTeamBackShow
	{
		get
		{
			if (_oSelfTeamBack != null)
			{
				return _oSelfTeamBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfTeamBackShow != value && _oSelfTeamBack != null)
			{
				_oSelfTeamBack.SetObjectActive(value);
			}
		}
	}

	public bool UnityFlagShow
	{
		get
		{
			if (_oUnityFlag != null)
			{
				return _oUnityFlag.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (UnityFlagShow != value && _oUnityFlag != null)
			{
				_oUnityFlag.SetObjectActive(value);
			}
		}
	}

	public string RankTextString
	{
		get
		{
			if (_oRankTextText != null)
			{
				return _oRankTextText.text;
			}
			return null;
		}
		set
		{
			if (RankTextString != value && _oRankTextText != null)
			{
				_oRankTextText.text = value;
			}
		}
	}

	public bool CareerImageShow
	{
		get
		{
			if (_oCareerImage != null)
			{
				return _oCareerImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CareerImageShow != value && _oCareerImage != null)
			{
				_oCareerImage.SetObjectActive(value);
			}
		}
	}

	public Sprite CareerImageSprite
	{
		get
		{
			if (_oCareerImageImage != null)
			{
				return _oCareerImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (CareerImageSprite != value && _oCareerImageImage != null)
			{
				_oCareerImageImage.sprite = value;
			}
		}
	}

	public bool BigHeadImageShow
	{
		get
		{
			if (_bigHeadImage != null)
			{
				return _bigHeadImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BigHeadImageShow != value && _bigHeadImage != null)
			{
				_bigHeadImage.SetObjectActive(value);
			}
		}
	}

	public Sprite BigHeadImageSprite
	{
		get
		{
			if (_bigHeadImageImage != null)
			{
				return _bigHeadImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (BigHeadImageSprite != value && _bigHeadImageImage != null)
			{
				_bigHeadImageImage.sprite = value;
			}
		}
	}

	public bool PlayerDeadShow
	{
		get
		{
			if (_oPlayerDead != null)
			{
				return _oPlayerDead.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerDeadShow != value && _oPlayerDead != null)
			{
				_oPlayerDead.SetObjectActive(value);
			}
		}
	}

	public bool PlayerRankHonorShow
	{
		get
		{
			if (_oPlayerRankHonor != null)
			{
				return _oPlayerRankHonor.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerRankHonorShow != value && _oPlayerRankHonor != null)
			{
				_oPlayerRankHonor.SetObjectActive(value);
			}
		}
	}

	public Sprite PlayerRankHonorSprite
	{
		get
		{
			if (_oPlayerRankHonorImage != null)
			{
				return _oPlayerRankHonorImage.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerRankHonorSprite != value && _oPlayerRankHonorImage != null)
			{
				_oPlayerRankHonorImage.sprite = value;
			}
		}
	}

	public bool PlayerRankHonorDesShow
	{
		get
		{
			if (_oPlayerRankHonorDes != null)
			{
				return _oPlayerRankHonorDes.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerRankHonorDesShow != value && _oPlayerRankHonorDes != null)
			{
				_oPlayerRankHonorDes.SetObjectActive(value);
			}
		}
	}

	public string PlayerRankHonorDesString
	{
		get
		{
			if (_oPlayerRankHonorDesText != null)
			{
				return _oPlayerRankHonorDesText.text;
			}
			return null;
		}
		set
		{
			if (PlayerRankHonorDesString != value && _oPlayerRankHonorDesText != null)
			{
				_oPlayerRankHonorDesText.text = value;
			}
		}
	}

	public bool HeroImageShow
	{
		get
		{
			if (_oHeroImage != null)
			{
				return _oHeroImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HeroImageShow != value && _oHeroImage != null)
			{
				_oHeroImage.SetObjectActive(value);
			}
		}
	}

	public bool PlayerHonorShow1
	{
		get
		{
			if (_oPlayerHonor1 != null)
			{
				return _oPlayerHonor1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerHonorShow1 != value && _oPlayerHonor1 != null)
			{
				_oPlayerHonor1.SetObjectActive(value);
			}
		}
	}

	public bool PlayerHonorShow2
	{
		get
		{
			if (_oPlayerHonor2 != null)
			{
				return _oPlayerHonor2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerHonorShow2 != value && _oPlayerHonor2 != null)
			{
				_oPlayerHonor2.SetObjectActive(value);
			}
		}
	}

	public bool PlayerHonorShow3
	{
		get
		{
			if (_oPlayerHonor3 != null)
			{
				return _oPlayerHonor3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerHonorShow3 != value && _oPlayerHonor3 != null)
			{
				_oPlayerHonor3.SetObjectActive(value);
			}
		}
	}

	public Sprite PlayerHonorSprite1
	{
		get
		{
			if (_oPlayerHonorImage1 != null)
			{
				return _oPlayerHonorImage1.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerHonorSprite1 != value && _oPlayerHonorImage1 != null)
			{
				_oPlayerHonorImage1.sprite = value;
			}
		}
	}

	public Sprite PlayerHonorSprite2
	{
		get
		{
			if (_oPlayerHonorImage2 != null)
			{
				return _oPlayerHonorImage2.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerHonorSprite2 != value && _oPlayerHonorImage2 != null)
			{
				_oPlayerHonorImage2.sprite = value;
			}
		}
	}

	public Sprite PlayerHonorSprite3
	{
		get
		{
			if (_oPlayerHonorImage3 != null)
			{
				return _oPlayerHonorImage3.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerHonorSprite3 != value && _oPlayerHonorImage3 != null)
			{
				_oPlayerHonorImage3.sprite = value;
			}
		}
	}

	public GameObject oPlayerName => _oPlayerName;

	public string PlayerNameString
	{
		get
		{
			if (_oPlayerNameText != null)
			{
				return _oPlayerNameText.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString != value && _oPlayerNameText != null)
			{
				_oPlayerNameText.text = value;
			}
		}
	}

	public bool PlayerTeamShow
	{
		get
		{
			if (_oPlayerTeam != null)
			{
				return _oPlayerTeam.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerTeamShow != value && _oPlayerTeam != null)
			{
				_oPlayerTeam.SetObjectActive(value);
			}
		}
	}

	public string PlayerTeamString
	{
		get
		{
			if (_oPlayerTeamText != null)
			{
				return _oPlayerTeamText.text;
			}
			return null;
		}
		set
		{
			if (PlayerTeamString != value && _oPlayerTeamText != null)
			{
				_oPlayerTeamText.text = value;
			}
		}
	}

	public bool PlayerPingShow
	{
		get
		{
			if (_oPlayerPing != null)
			{
				return _oPlayerPing.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerPingShow != value && _oPlayerPing != null)
			{
				_oPlayerPing.SetObjectActive(value);
			}
		}
	}

	public string PlayerPingString
	{
		get
		{
			if (_oPlayerPingText != null)
			{
				return _oPlayerPingText.text;
			}
			return null;
		}
		set
		{
			if (PlayerPingString != value && _oPlayerPingText != null)
			{
				_oPlayerPingText.text = value;
			}
		}
	}

	public bool VipShow
	{
		get
		{
			if (_oVip != null)
			{
				return _oVip.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (VipShow != value && _oVip != null)
			{
				_oVip.SetObjectActive(value);
			}
		}
	}

	public Sprite VipSprite
	{
		get
		{
			if (_oVipImage != null)
			{
				return _oVipImage.sprite;
			}
			return null;
		}
		set
		{
			if (VipSprite != value && _oVipImage != null)
			{
				_oVipImage.sprite = value;
			}
		}
	}

	public bool PlayerScoreShow1
	{
		get
		{
			if (_oPlayerScore1 != null)
			{
				return _oPlayerScore1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerScoreShow1 != value && _oPlayerScore1 != null)
			{
				_oPlayerScore1.SetObjectActive(value);
			}
		}
	}

	public bool PlayerScoreShow2
	{
		get
		{
			if (_oPlayerScore2 != null)
			{
				return _oPlayerScore2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerScoreShow2 != value && _oPlayerScore2 != null)
			{
				_oPlayerScore2.SetObjectActive(value);
			}
		}
	}

	public bool PlayerScoreShow3
	{
		get
		{
			if (_oPlayerScore3 != null)
			{
				return _oPlayerScore3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerScoreShow3 != value && _oPlayerScore3 != null)
			{
				_oPlayerScore3.SetObjectActive(value);
			}
		}
	}

	public bool PlayerScoreShow4
	{
		get
		{
			if (_oPlayerScore4 != null)
			{
				return _oPlayerScore4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerScoreShow4 != value && _oPlayerScore4 != null)
			{
				_oPlayerScore4.SetObjectActive(value);
			}
		}
	}

	public bool PlayerScoreShow5
	{
		get
		{
			if (_oPlayerScore5 != null)
			{
				return _oPlayerScore5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerScoreShow5 != value && _oPlayerScore5 != null)
			{
				_oPlayerScore5.SetObjectActive(value);
			}
		}
	}

	public bool PlayerScoreShow6
	{
		get
		{
			if (_oPlayerScore6 != null)
			{
				return _oPlayerScore6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PlayerScoreShow6 != value && _oPlayerScore6 != null)
			{
				_oPlayerScore6.SetObjectActive(value);
			}
		}
	}

	public string PlayerScoreString1
	{
		get
		{
			if (_oPlayerScoreText1 != null)
			{
				return _oPlayerScoreText1.text;
			}
			return null;
		}
		set
		{
			if (PlayerScoreString1 != value && _oPlayerScoreText1 != null)
			{
				_oPlayerScoreText1.text = value;
			}
		}
	}

	public string PlayerScoreString2
	{
		get
		{
			if (_oPlayerScoreText2 != null)
			{
				return _oPlayerScoreText2.text;
			}
			return null;
		}
		set
		{
			if (PlayerScoreString2 != value && _oPlayerScoreText2 != null)
			{
				_oPlayerScoreText2.text = value;
			}
		}
	}

	public string PlayerScoreString3
	{
		get
		{
			if (_oPlayerScoreText3 != null)
			{
				return _oPlayerScoreText3.text;
			}
			return null;
		}
		set
		{
			if (PlayerScoreString3 != value && _oPlayerScoreText3 != null)
			{
				_oPlayerScoreText3.text = value;
			}
		}
	}

	public string PlayerScoreString4
	{
		get
		{
			if (_oPlayerScoreText4 != null)
			{
				return _oPlayerScoreText4.text;
			}
			return null;
		}
		set
		{
			if (PlayerScoreString4 != value && _oPlayerScoreText4 != null)
			{
				_oPlayerScoreText4.text = value;
			}
		}
	}

	public string PlayerScoreString5
	{
		get
		{
			if (_oPlayerScoreText5 != null)
			{
				return _oPlayerScoreText5.text;
			}
			return null;
		}
		set
		{
			if (PlayerScoreString5 != value && _oPlayerScoreText5 != null)
			{
				_oPlayerScoreText5.text = value;
			}
		}
	}

	public string PlayerScoreString6
	{
		get
		{
			if (_oPlayerScoreText6 != null)
			{
				return _oPlayerScoreText6.text;
			}
			return null;
		}
		set
		{
			if (PlayerScoreString6 != value && _oPlayerScoreText6 != null)
			{
				_oPlayerScoreText6.text = value;
			}
		}
	}

	public bool WeaponShow
	{
		get
		{
			if (_oWeapon != null)
			{
				return _oWeapon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (WeaponShow != value && _oWeapon != null)
			{
				_oWeapon.SetObjectActive(value);
			}
		}
	}

	public string WeaponString
	{
		get
		{
			if (_oWeaponText != null)
			{
				return _oWeaponText.text;
			}
			return null;
		}
		set
		{
			if (WeaponString != value && _oWeaponText != null)
			{
				_oWeaponText.text = value;
			}
		}
	}

	public string PlayerDuiwuString
	{
		get
		{
			if (_oPlayerDuiwuText != null)
			{
				return _oPlayerDuiwuText.text;
			}
			return null;
		}
		set
		{
			if (PlayerDuiwuString != value && _oPlayerDuiwuText != null)
			{
				_oPlayerDuiwuText.text = value;
			}
		}
	}

	public string PlayerLevelString
	{
		get
		{
			if (_oPlayerLevelText != null)
			{
				return _oPlayerLevelText.text;
			}
			return null;
		}
		set
		{
			if (PlayerLevelString != value && _oPlayerLevelText != null)
			{
				_oPlayerLevelText.text = value;
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
			case "SelfBack":
				_oSelfBack = transform.gameObject;
				break;
			case "SelfTeamBack":
				_oSelfTeamBack = transform.gameObject;
				break;
			case "UnityFlag":
				_oUnityFlag = transform.gameObject;
				break;
			case "RankText":
				_oRankText = transform.gameObject;
				_oRankTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "CareerImage":
				_oCareerImage = transform.gameObject;
				_oCareerImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerDead":
				_oPlayerDead = transform.gameObject;
				break;
			case "PlayerRankHonor":
				_oPlayerRankHonor = transform.gameObject;
				_oPlayerRankHonorImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerRankHonorDes":
				_oPlayerRankHonorDes = transform.gameObject;
				_oPlayerRankHonorDesText = transform.gameObject.GetComponent<Text>();
				break;
			case "HeroImage":
				_oHeroImage = transform.gameObject;
				break;
			case "PlayerHonor1":
				_oPlayerHonor1 = transform.gameObject;
				_oPlayerHonorImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerHonor2":
				_oPlayerHonor2 = transform.gameObject;
				_oPlayerHonorImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerHonor3":
				_oPlayerHonor3 = transform.gameObject;
				_oPlayerHonorImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerName":
				_oPlayerName = transform.gameObject;
				_oPlayerNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerTeam":
				_oPlayerTeam = transform.gameObject;
				_oPlayerTeamText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerPing":
				_oPlayerPing = transform.gameObject;
				_oPlayerPingText = transform.gameObject.GetComponent<Text>();
				break;
			case "Vip":
				_oVip = transform.gameObject;
				_oVipImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerScore1":
				_oPlayerScore1 = transform.gameObject;
				_oPlayerScoreText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore2":
				_oPlayerScore2 = transform.gameObject;
				_oPlayerScoreText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore3":
				_oPlayerScore3 = transform.gameObject;
				_oPlayerScoreText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore4":
				_oPlayerScore4 = transform.gameObject;
				_oPlayerScoreText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore5":
				_oPlayerScore5 = transform.gameObject;
				_oPlayerScoreText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerScore6":
				_oPlayerScore6 = transform.gameObject;
				_oPlayerScoreText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Weapon":
				_oWeapon = transform.gameObject;
				_oWeaponText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerDuiwu":
				_oPlayerDuiwu = transform.gameObject;
				_oPlayerDuiwuText = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerLevel":
				_oPlayerLevel = transform.gameObject;
				_oPlayerLevelText = transform.gameObject.GetComponent<Text>();
				break;
			case "BigHeadImage":
				_bigHeadImage = transform.gameObject;
				_bigHeadImageImage = transform.gameObject.GetComponent<Image>();
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

	public void PlayerRankHonorNtvsize()
	{
		if (_oPlayerRankHonorImage != null)
		{
			_oPlayerRankHonorImage.SetNativeSize();
		}
	}

	public bool GetPlayerHonorShow(int index)
	{
		return index switch
		{
			1 => PlayerHonorShow1, 
			2 => PlayerHonorShow2, 
			3 => PlayerHonorShow3, 
			_ => false, 
		};
	}

	public void SetPlayerHonorShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			PlayerHonorShow1 = value;
			break;
		case 2:
			PlayerHonorShow2 = value;
			break;
		case 3:
			PlayerHonorShow3 = value;
			break;
		}
	}

	public int GetPlayerHonorCount()
	{
		return 3;
	}

	public Sprite GetPlayerHonorSprite(int index)
	{
		return index switch
		{
			1 => PlayerHonorSprite1, 
			2 => PlayerHonorSprite2, 
			3 => PlayerHonorSprite3, 
			_ => null, 
		};
	}

	public void SetPlayerHonorSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			PlayerHonorSprite1 = value;
			break;
		case 2:
			PlayerHonorSprite2 = value;
			break;
		case 3:
			PlayerHonorSprite3 = value;
			break;
		}
	}

	public bool GetPlayerScoreShow(int index)
	{
		return index switch
		{
			1 => PlayerScoreShow1, 
			2 => PlayerScoreShow2, 
			3 => PlayerScoreShow3, 
			4 => PlayerScoreShow4, 
			5 => PlayerScoreShow5, 
			6 => PlayerScoreShow6, 
			_ => false, 
		};
	}

	public void SetPlayerScoreShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			PlayerScoreShow1 = value;
			break;
		case 2:
			PlayerScoreShow2 = value;
			break;
		case 3:
			PlayerScoreShow3 = value;
			break;
		case 4:
			PlayerScoreShow4 = value;
			break;
		case 5:
			PlayerScoreShow5 = value;
			break;
		case 6:
			PlayerScoreShow6 = value;
			break;
		}
	}

	public int GetPlayerScoreCount()
	{
		return 6;
	}

	public string GetPlayerScoreString(int index)
	{
		return index switch
		{
			1 => PlayerScoreString1, 
			2 => PlayerScoreString2, 
			3 => PlayerScoreString3, 
			4 => PlayerScoreString4, 
			5 => PlayerScoreString5, 
			6 => PlayerScoreString6, 
			_ => null, 
		};
	}

	public void SetPlayerScoreString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PlayerScoreString1 = value;
			break;
		case 2:
			PlayerScoreString2 = value;
			break;
		case 3:
			PlayerScoreString3 = value;
			break;
		case 4:
			PlayerScoreString4 = value;
			break;
		case 5:
			PlayerScoreString5 = value;
			break;
		case 6:
			PlayerScoreString6 = value;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		if (_oRankTextText != null)
		{
			_holdPosTrans.Add(_oRankTextText.GetComponent<RectTransform>());
		}
		if (_oPlayerNameText != null)
		{
			_holdPosTrans.Add(_oPlayerNameText.GetComponent<RectTransform>());
		}
		if (_oPlayerTeamText != null)
		{
			_holdPosTrans.Add(_oPlayerTeamText.GetComponent<RectTransform>());
		}
		if (_oPlayerPingText != null)
		{
			_holdPosTrans.Add(_oPlayerPingText.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText1 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText1.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText2 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText2.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText3 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText3.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText4 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText4.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText5 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText5.GetComponent<RectTransform>());
		}
		if (_oPlayerScoreText6 != null)
		{
			_holdPosTrans.Add(_oPlayerScoreText6.GetComponent<RectTransform>());
		}
		if (_oWeaponText != null)
		{
			_holdPosTrans.Add(_oWeaponText.GetComponent<RectTransform>());
		}
		if (_oPlayerDuiwuText != null)
		{
			_holdPosTrans.Add(_oPlayerDuiwuText.GetComponent<RectTransform>());
		}
		if (_oPlayerLevelText != null)
		{
			_holdPosTrans.Add(_oPlayerLevelText.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
