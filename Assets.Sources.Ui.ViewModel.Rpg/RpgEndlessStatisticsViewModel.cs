using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgEndlessStatisticsViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oStatistic1;

	private GameObject _oStatistic2;

	private GameObject _oStatistic3;

	private GameObject _oStatistic4;

	private GameObject _oStatistic5;

	private GameObject _oStatistic6;

	private GameObject _oDesc1;

	private GameObject _oDesc2;

	private GameObject _oDesc3;

	private GameObject _oDesc4;

	private GameObject _oDesc5;

	private GameObject _oDesc6;

	private GameObject _oRankIcon1;

	private GameObject _oRankIcon2;

	private GameObject _oRankIcon3;

	private GameObject _oRankIcon4;

	private GameObject _oRankIcon5;

	private GameObject _oRankIcon6;

	private GameObject _oRelieveBg1;

	private GameObject _oRelieveBg2;

	private GameObject _oRelieveBg3;

	private GameObject _oRelieveBg4;

	private GameObject _oRelieveBg5;

	private GameObject _oRelieveBg6;

	private GameObject _oRelieveProgressBar1;

	private GameObject _oRelieveProgressBar2;

	private GameObject _oRelieveProgressBar3;

	private GameObject _oRelieveProgressBar4;

	private GameObject _oRelieveProgressBar5;

	private GameObject _oRelieveProgressBar6;

	private Image _oRelieveProgressBarImage1;

	private Image _oRelieveProgressBarImage2;

	private Image _oRelieveProgressBarImage3;

	private Image _oRelieveProgressBarImage4;

	private Image _oRelieveProgressBarImage5;

	private Image _oRelieveProgressBarImage6;

	private GameObject _oPlayerName1;

	private GameObject _oPlayerName2;

	private GameObject _oPlayerName3;

	private GameObject _oPlayerName4;

	private GameObject _oPlayerName5;

	private GameObject _oPlayerName6;

	private Text _oPlayerNameText1;

	private Text _oPlayerNameText2;

	private Text _oPlayerNameText3;

	private Text _oPlayerNameText4;

	private Text _oPlayerNameText5;

	private Text _oPlayerNameText6;

	private GameObject _oIntegralRatio1;

	private GameObject _oIntegralRatio2;

	private GameObject _oIntegralRatio3;

	private GameObject _oIntegralRatio4;

	private GameObject _oIntegralRatio5;

	private GameObject _oIntegralRatio6;

	private Text _oIntegralRatioText1;

	private Text _oIntegralRatioText2;

	private Text _oIntegralRatioText3;

	private Text _oIntegralRatioText4;

	private Text _oIntegralRatioText5;

	private Text _oIntegralRatioText6;

	private GameObject _oScore1;

	private GameObject _oScore2;

	private GameObject _oScore3;

	private GameObject _oScore4;

	private GameObject _oScore5;

	private GameObject _oScore6;

	private Text _oScoreText1;

	private Text _oScoreText2;

	private Text _oScoreText3;

	private Text _oScoreText4;

	private Text _oScoreText5;

	private Text _oScoreText6;

	private GameObject _oReleiveImage1;

	private GameObject _oReleiveImage2;

	private GameObject _oReleiveImage3;

	private GameObject _oReleiveImage4;

	private GameObject _oReleiveImage5;

	private GameObject _oReleiveImage6;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgEndlessStatistics";

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

	public bool StatisticShow1
	{
		get
		{
			if (_oStatistic1 != null)
			{
				return _oStatistic1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StatisticShow1 != value && _oStatistic1 != null)
			{
				_oStatistic1.SetObjectActive(value);
			}
		}
	}

	public bool StatisticShow2
	{
		get
		{
			if (_oStatistic2 != null)
			{
				return _oStatistic2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StatisticShow2 != value && _oStatistic2 != null)
			{
				_oStatistic2.SetObjectActive(value);
			}
		}
	}

	public bool StatisticShow3
	{
		get
		{
			if (_oStatistic3 != null)
			{
				return _oStatistic3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StatisticShow3 != value && _oStatistic3 != null)
			{
				_oStatistic3.SetObjectActive(value);
			}
		}
	}

	public bool StatisticShow4
	{
		get
		{
			if (_oStatistic4 != null)
			{
				return _oStatistic4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StatisticShow4 != value && _oStatistic4 != null)
			{
				_oStatistic4.SetObjectActive(value);
			}
		}
	}

	public bool StatisticShow5
	{
		get
		{
			if (_oStatistic5 != null)
			{
				return _oStatistic5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StatisticShow5 != value && _oStatistic5 != null)
			{
				_oStatistic5.SetObjectActive(value);
			}
		}
	}

	public bool StatisticShow6
	{
		get
		{
			if (_oStatistic6 != null)
			{
				return _oStatistic6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (StatisticShow6 != value && _oStatistic6 != null)
			{
				_oStatistic6.SetObjectActive(value);
			}
		}
	}

	public bool DescShow1
	{
		get
		{
			if (_oDesc1 != null)
			{
				return _oDesc1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DescShow1 != value && _oDesc1 != null)
			{
				_oDesc1.SetObjectActive(value);
			}
		}
	}

	public bool DescShow2
	{
		get
		{
			if (_oDesc2 != null)
			{
				return _oDesc2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DescShow2 != value && _oDesc2 != null)
			{
				_oDesc2.SetObjectActive(value);
			}
		}
	}

	public bool DescShow3
	{
		get
		{
			if (_oDesc3 != null)
			{
				return _oDesc3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DescShow3 != value && _oDesc3 != null)
			{
				_oDesc3.SetObjectActive(value);
			}
		}
	}

	public bool DescShow4
	{
		get
		{
			if (_oDesc4 != null)
			{
				return _oDesc4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DescShow4 != value && _oDesc4 != null)
			{
				_oDesc4.SetObjectActive(value);
			}
		}
	}

	public bool DescShow5
	{
		get
		{
			if (_oDesc5 != null)
			{
				return _oDesc5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DescShow5 != value && _oDesc5 != null)
			{
				_oDesc5.SetObjectActive(value);
			}
		}
	}

	public bool DescShow6
	{
		get
		{
			if (_oDesc6 != null)
			{
				return _oDesc6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DescShow6 != value && _oDesc6 != null)
			{
				_oDesc6.SetObjectActive(value);
			}
		}
	}

	public bool RankIconShow1
	{
		get
		{
			if (_oRankIcon1 != null)
			{
				return _oRankIcon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RankIconShow1 != value && _oRankIcon1 != null)
			{
				_oRankIcon1.SetObjectActive(value);
			}
		}
	}

	public bool RankIconShow2
	{
		get
		{
			if (_oRankIcon2 != null)
			{
				return _oRankIcon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RankIconShow2 != value && _oRankIcon2 != null)
			{
				_oRankIcon2.SetObjectActive(value);
			}
		}
	}

	public bool RankIconShow3
	{
		get
		{
			if (_oRankIcon3 != null)
			{
				return _oRankIcon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RankIconShow3 != value && _oRankIcon3 != null)
			{
				_oRankIcon3.SetObjectActive(value);
			}
		}
	}

	public bool RankIconShow4
	{
		get
		{
			if (_oRankIcon4 != null)
			{
				return _oRankIcon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RankIconShow4 != value && _oRankIcon4 != null)
			{
				_oRankIcon4.SetObjectActive(value);
			}
		}
	}

	public bool RankIconShow5
	{
		get
		{
			if (_oRankIcon5 != null)
			{
				return _oRankIcon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RankIconShow5 != value && _oRankIcon5 != null)
			{
				_oRankIcon5.SetObjectActive(value);
			}
		}
	}

	public bool RankIconShow6
	{
		get
		{
			if (_oRankIcon6 != null)
			{
				return _oRankIcon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RankIconShow6 != value && _oRankIcon6 != null)
			{
				_oRankIcon6.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow1
	{
		get
		{
			if (_oRelieveBg1 != null)
			{
				return _oRelieveBg1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow1 != value && _oRelieveBg1 != null)
			{
				_oRelieveBg1.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow2
	{
		get
		{
			if (_oRelieveBg2 != null)
			{
				return _oRelieveBg2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow2 != value && _oRelieveBg2 != null)
			{
				_oRelieveBg2.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow3
	{
		get
		{
			if (_oRelieveBg3 != null)
			{
				return _oRelieveBg3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow3 != value && _oRelieveBg3 != null)
			{
				_oRelieveBg3.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow4
	{
		get
		{
			if (_oRelieveBg4 != null)
			{
				return _oRelieveBg4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow4 != value && _oRelieveBg4 != null)
			{
				_oRelieveBg4.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow5
	{
		get
		{
			if (_oRelieveBg5 != null)
			{
				return _oRelieveBg5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow5 != value && _oRelieveBg5 != null)
			{
				_oRelieveBg5.SetObjectActive(value);
			}
		}
	}

	public bool RelieveBgShow6
	{
		get
		{
			if (_oRelieveBg6 != null)
			{
				return _oRelieveBg6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RelieveBgShow6 != value && _oRelieveBg6 != null)
			{
				_oRelieveBg6.SetObjectActive(value);
			}
		}
	}

	public float RelieveProgressBarFillamount1
	{
		get
		{
			if (_oRelieveProgressBarImage1 != null)
			{
				return _oRelieveProgressBarImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (RelieveProgressBarFillamount1 != value && _oRelieveProgressBarImage1 != null)
			{
				_oRelieveProgressBarImage1.fillAmount = value;
			}
		}
	}

	public float RelieveProgressBarFillamount2
	{
		get
		{
			if (_oRelieveProgressBarImage2 != null)
			{
				return _oRelieveProgressBarImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (RelieveProgressBarFillamount2 != value && _oRelieveProgressBarImage2 != null)
			{
				_oRelieveProgressBarImage2.fillAmount = value;
			}
		}
	}

	public float RelieveProgressBarFillamount3
	{
		get
		{
			if (_oRelieveProgressBarImage3 != null)
			{
				return _oRelieveProgressBarImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (RelieveProgressBarFillamount3 != value && _oRelieveProgressBarImage3 != null)
			{
				_oRelieveProgressBarImage3.fillAmount = value;
			}
		}
	}

	public float RelieveProgressBarFillamount4
	{
		get
		{
			if (_oRelieveProgressBarImage4 != null)
			{
				return _oRelieveProgressBarImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (RelieveProgressBarFillamount4 != value && _oRelieveProgressBarImage4 != null)
			{
				_oRelieveProgressBarImage4.fillAmount = value;
			}
		}
	}

	public float RelieveProgressBarFillamount5
	{
		get
		{
			if (_oRelieveProgressBarImage5 != null)
			{
				return _oRelieveProgressBarImage5.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (RelieveProgressBarFillamount5 != value && _oRelieveProgressBarImage5 != null)
			{
				_oRelieveProgressBarImage5.fillAmount = value;
			}
		}
	}

	public float RelieveProgressBarFillamount6
	{
		get
		{
			if (_oRelieveProgressBarImage6 != null)
			{
				return _oRelieveProgressBarImage6.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (RelieveProgressBarFillamount6 != value && _oRelieveProgressBarImage6 != null)
			{
				_oRelieveProgressBarImage6.fillAmount = value;
			}
		}
	}

	public string PlayerNameString1
	{
		get
		{
			if (_oPlayerNameText1 != null)
			{
				return _oPlayerNameText1.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString1 != value && _oPlayerNameText1 != null)
			{
				_oPlayerNameText1.text = value;
			}
		}
	}

	public string PlayerNameString2
	{
		get
		{
			if (_oPlayerNameText2 != null)
			{
				return _oPlayerNameText2.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString2 != value && _oPlayerNameText2 != null)
			{
				_oPlayerNameText2.text = value;
			}
		}
	}

	public string PlayerNameString3
	{
		get
		{
			if (_oPlayerNameText3 != null)
			{
				return _oPlayerNameText3.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString3 != value && _oPlayerNameText3 != null)
			{
				_oPlayerNameText3.text = value;
			}
		}
	}

	public string PlayerNameString4
	{
		get
		{
			if (_oPlayerNameText4 != null)
			{
				return _oPlayerNameText4.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString4 != value && _oPlayerNameText4 != null)
			{
				_oPlayerNameText4.text = value;
			}
		}
	}

	public string PlayerNameString5
	{
		get
		{
			if (_oPlayerNameText5 != null)
			{
				return _oPlayerNameText5.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString5 != value && _oPlayerNameText5 != null)
			{
				_oPlayerNameText5.text = value;
			}
		}
	}

	public string PlayerNameString6
	{
		get
		{
			if (_oPlayerNameText6 != null)
			{
				return _oPlayerNameText6.text;
			}
			return null;
		}
		set
		{
			if (PlayerNameString6 != value && _oPlayerNameText6 != null)
			{
				_oPlayerNameText6.text = value;
			}
		}
	}

	public Color PlayerNameTextcolor1
	{
		get
		{
			if (_oPlayerNameText1 != null)
			{
				return _oPlayerNameText1.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor1 != value && _oPlayerNameText1 != null)
			{
				_oPlayerNameText1.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor2
	{
		get
		{
			if (_oPlayerNameText2 != null)
			{
				return _oPlayerNameText2.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor2 != value && _oPlayerNameText2 != null)
			{
				_oPlayerNameText2.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor3
	{
		get
		{
			if (_oPlayerNameText3 != null)
			{
				return _oPlayerNameText3.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor3 != value && _oPlayerNameText3 != null)
			{
				_oPlayerNameText3.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor4
	{
		get
		{
			if (_oPlayerNameText4 != null)
			{
				return _oPlayerNameText4.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor4 != value && _oPlayerNameText4 != null)
			{
				_oPlayerNameText4.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor5
	{
		get
		{
			if (_oPlayerNameText5 != null)
			{
				return _oPlayerNameText5.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor5 != value && _oPlayerNameText5 != null)
			{
				_oPlayerNameText5.color = value;
			}
		}
	}

	public Color PlayerNameTextcolor6
	{
		get
		{
			if (_oPlayerNameText6 != null)
			{
				return _oPlayerNameText6.color;
			}
			return Color.white;
		}
		set
		{
			if (PlayerNameTextcolor6 != value && _oPlayerNameText6 != null)
			{
				_oPlayerNameText6.color = value;
			}
		}
	}

	public string IntegralRatioString1
	{
		get
		{
			if (_oIntegralRatioText1 != null)
			{
				return _oIntegralRatioText1.text;
			}
			return null;
		}
		set
		{
			if (IntegralRatioString1 != value && _oIntegralRatioText1 != null)
			{
				_oIntegralRatioText1.text = value;
			}
		}
	}

	public string IntegralRatioString2
	{
		get
		{
			if (_oIntegralRatioText2 != null)
			{
				return _oIntegralRatioText2.text;
			}
			return null;
		}
		set
		{
			if (IntegralRatioString2 != value && _oIntegralRatioText2 != null)
			{
				_oIntegralRatioText2.text = value;
			}
		}
	}

	public string IntegralRatioString3
	{
		get
		{
			if (_oIntegralRatioText3 != null)
			{
				return _oIntegralRatioText3.text;
			}
			return null;
		}
		set
		{
			if (IntegralRatioString3 != value && _oIntegralRatioText3 != null)
			{
				_oIntegralRatioText3.text = value;
			}
		}
	}

	public string IntegralRatioString4
	{
		get
		{
			if (_oIntegralRatioText4 != null)
			{
				return _oIntegralRatioText4.text;
			}
			return null;
		}
		set
		{
			if (IntegralRatioString4 != value && _oIntegralRatioText4 != null)
			{
				_oIntegralRatioText4.text = value;
			}
		}
	}

	public string IntegralRatioString5
	{
		get
		{
			if (_oIntegralRatioText5 != null)
			{
				return _oIntegralRatioText5.text;
			}
			return null;
		}
		set
		{
			if (IntegralRatioString5 != value && _oIntegralRatioText5 != null)
			{
				_oIntegralRatioText5.text = value;
			}
		}
	}

	public string IntegralRatioString6
	{
		get
		{
			if (_oIntegralRatioText6 != null)
			{
				return _oIntegralRatioText6.text;
			}
			return null;
		}
		set
		{
			if (IntegralRatioString6 != value && _oIntegralRatioText6 != null)
			{
				_oIntegralRatioText6.text = value;
			}
		}
	}

	public Color IntegralRatioTextcolor1
	{
		get
		{
			if (_oIntegralRatioText1 != null)
			{
				return _oIntegralRatioText1.color;
			}
			return Color.white;
		}
		set
		{
			if (IntegralRatioTextcolor1 != value && _oIntegralRatioText1 != null)
			{
				_oIntegralRatioText1.color = value;
			}
		}
	}

	public Color IntegralRatioTextcolor2
	{
		get
		{
			if (_oIntegralRatioText2 != null)
			{
				return _oIntegralRatioText2.color;
			}
			return Color.white;
		}
		set
		{
			if (IntegralRatioTextcolor2 != value && _oIntegralRatioText2 != null)
			{
				_oIntegralRatioText2.color = value;
			}
		}
	}

	public Color IntegralRatioTextcolor3
	{
		get
		{
			if (_oIntegralRatioText3 != null)
			{
				return _oIntegralRatioText3.color;
			}
			return Color.white;
		}
		set
		{
			if (IntegralRatioTextcolor3 != value && _oIntegralRatioText3 != null)
			{
				_oIntegralRatioText3.color = value;
			}
		}
	}

	public Color IntegralRatioTextcolor4
	{
		get
		{
			if (_oIntegralRatioText4 != null)
			{
				return _oIntegralRatioText4.color;
			}
			return Color.white;
		}
		set
		{
			if (IntegralRatioTextcolor4 != value && _oIntegralRatioText4 != null)
			{
				_oIntegralRatioText4.color = value;
			}
		}
	}

	public Color IntegralRatioTextcolor5
	{
		get
		{
			if (_oIntegralRatioText5 != null)
			{
				return _oIntegralRatioText5.color;
			}
			return Color.white;
		}
		set
		{
			if (IntegralRatioTextcolor5 != value && _oIntegralRatioText5 != null)
			{
				_oIntegralRatioText5.color = value;
			}
		}
	}

	public Color IntegralRatioTextcolor6
	{
		get
		{
			if (_oIntegralRatioText6 != null)
			{
				return _oIntegralRatioText6.color;
			}
			return Color.white;
		}
		set
		{
			if (IntegralRatioTextcolor6 != value && _oIntegralRatioText6 != null)
			{
				_oIntegralRatioText6.color = value;
			}
		}
	}

	public string ScoreString1
	{
		get
		{
			if (_oScoreText1 != null)
			{
				return _oScoreText1.text;
			}
			return null;
		}
		set
		{
			if (ScoreString1 != value && _oScoreText1 != null)
			{
				_oScoreText1.text = value;
			}
		}
	}

	public string ScoreString2
	{
		get
		{
			if (_oScoreText2 != null)
			{
				return _oScoreText2.text;
			}
			return null;
		}
		set
		{
			if (ScoreString2 != value && _oScoreText2 != null)
			{
				_oScoreText2.text = value;
			}
		}
	}

	public string ScoreString3
	{
		get
		{
			if (_oScoreText3 != null)
			{
				return _oScoreText3.text;
			}
			return null;
		}
		set
		{
			if (ScoreString3 != value && _oScoreText3 != null)
			{
				_oScoreText3.text = value;
			}
		}
	}

	public string ScoreString4
	{
		get
		{
			if (_oScoreText4 != null)
			{
				return _oScoreText4.text;
			}
			return null;
		}
		set
		{
			if (ScoreString4 != value && _oScoreText4 != null)
			{
				_oScoreText4.text = value;
			}
		}
	}

	public string ScoreString5
	{
		get
		{
			if (_oScoreText5 != null)
			{
				return _oScoreText5.text;
			}
			return null;
		}
		set
		{
			if (ScoreString5 != value && _oScoreText5 != null)
			{
				_oScoreText5.text = value;
			}
		}
	}

	public string ScoreString6
	{
		get
		{
			if (_oScoreText6 != null)
			{
				return _oScoreText6.text;
			}
			return null;
		}
		set
		{
			if (ScoreString6 != value && _oScoreText6 != null)
			{
				_oScoreText6.text = value;
			}
		}
	}

	public bool ReleiveImageShow1
	{
		get
		{
			if (_oReleiveImage1 != null)
			{
				return _oReleiveImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReleiveImageShow1 != value && _oReleiveImage1 != null)
			{
				_oReleiveImage1.SetObjectActive(value);
			}
		}
	}

	public bool ReleiveImageShow2
	{
		get
		{
			if (_oReleiveImage2 != null)
			{
				return _oReleiveImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReleiveImageShow2 != value && _oReleiveImage2 != null)
			{
				_oReleiveImage2.SetObjectActive(value);
			}
		}
	}

	public bool ReleiveImageShow3
	{
		get
		{
			if (_oReleiveImage3 != null)
			{
				return _oReleiveImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReleiveImageShow3 != value && _oReleiveImage3 != null)
			{
				_oReleiveImage3.SetObjectActive(value);
			}
		}
	}

	public bool ReleiveImageShow4
	{
		get
		{
			if (_oReleiveImage4 != null)
			{
				return _oReleiveImage4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReleiveImageShow4 != value && _oReleiveImage4 != null)
			{
				_oReleiveImage4.SetObjectActive(value);
			}
		}
	}

	public bool ReleiveImageShow5
	{
		get
		{
			if (_oReleiveImage5 != null)
			{
				return _oReleiveImage5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReleiveImageShow5 != value && _oReleiveImage5 != null)
			{
				_oReleiveImage5.SetObjectActive(value);
			}
		}
	}

	public bool ReleiveImageShow6
	{
		get
		{
			if (_oReleiveImage6 != null)
			{
				return _oReleiveImage6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ReleiveImageShow6 != value && _oReleiveImage6 != null)
			{
				_oReleiveImage6.SetObjectActive(value);
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
			case "Statistic1":
				_oStatistic1 = transform.gameObject;
				break;
			case "Statistic2":
				_oStatistic2 = transform.gameObject;
				break;
			case "Statistic3":
				_oStatistic3 = transform.gameObject;
				break;
			case "Statistic4":
				_oStatistic4 = transform.gameObject;
				break;
			case "Statistic5":
				_oStatistic5 = transform.gameObject;
				break;
			case "Statistic6":
				_oStatistic6 = transform.gameObject;
				break;
			case "Desc1":
				_oDesc1 = transform.gameObject;
				break;
			case "Desc2":
				_oDesc2 = transform.gameObject;
				break;
			case "Desc3":
				_oDesc3 = transform.gameObject;
				break;
			case "Desc4":
				_oDesc4 = transform.gameObject;
				break;
			case "Desc5":
				_oDesc5 = transform.gameObject;
				break;
			case "Desc6":
				_oDesc6 = transform.gameObject;
				break;
			case "RankIcon1":
				_oRankIcon1 = transform.gameObject;
				break;
			case "RankIcon2":
				_oRankIcon2 = transform.gameObject;
				break;
			case "RankIcon3":
				_oRankIcon3 = transform.gameObject;
				break;
			case "RankIcon4":
				_oRankIcon4 = transform.gameObject;
				break;
			case "RankIcon5":
				_oRankIcon5 = transform.gameObject;
				break;
			case "RankIcon6":
				_oRankIcon6 = transform.gameObject;
				break;
			case "RelieveBg1":
				_oRelieveBg1 = transform.gameObject;
				break;
			case "RelieveBg2":
				_oRelieveBg2 = transform.gameObject;
				break;
			case "RelieveBg3":
				_oRelieveBg3 = transform.gameObject;
				break;
			case "RelieveBg4":
				_oRelieveBg4 = transform.gameObject;
				break;
			case "RelieveBg5":
				_oRelieveBg5 = transform.gameObject;
				break;
			case "RelieveBg6":
				_oRelieveBg6 = transform.gameObject;
				break;
			case "RelieveProgressBar1":
				_oRelieveProgressBar1 = transform.gameObject;
				_oRelieveProgressBarImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "RelieveProgressBar2":
				_oRelieveProgressBar2 = transform.gameObject;
				_oRelieveProgressBarImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "RelieveProgressBar3":
				_oRelieveProgressBar3 = transform.gameObject;
				_oRelieveProgressBarImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "RelieveProgressBar4":
				_oRelieveProgressBar4 = transform.gameObject;
				_oRelieveProgressBarImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "RelieveProgressBar5":
				_oRelieveProgressBar5 = transform.gameObject;
				_oRelieveProgressBarImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "RelieveProgressBar6":
				_oRelieveProgressBar6 = transform.gameObject;
				_oRelieveProgressBarImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "PlayerName1":
				_oPlayerName1 = transform.gameObject;
				_oPlayerNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName2":
				_oPlayerName2 = transform.gameObject;
				_oPlayerNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName3":
				_oPlayerName3 = transform.gameObject;
				_oPlayerNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName4":
				_oPlayerName4 = transform.gameObject;
				_oPlayerNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName5":
				_oPlayerName5 = transform.gameObject;
				_oPlayerNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "PlayerName6":
				_oPlayerName6 = transform.gameObject;
				_oPlayerNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "IntegralRatio1":
				_oIntegralRatio1 = transform.gameObject;
				_oIntegralRatioText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "IntegralRatio2":
				_oIntegralRatio2 = transform.gameObject;
				_oIntegralRatioText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "IntegralRatio3":
				_oIntegralRatio3 = transform.gameObject;
				_oIntegralRatioText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "IntegralRatio4":
				_oIntegralRatio4 = transform.gameObject;
				_oIntegralRatioText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "IntegralRatio5":
				_oIntegralRatio5 = transform.gameObject;
				_oIntegralRatioText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "IntegralRatio6":
				_oIntegralRatio6 = transform.gameObject;
				_oIntegralRatioText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score1":
				_oScore1 = transform.gameObject;
				_oScoreText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score2":
				_oScore2 = transform.gameObject;
				_oScoreText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score3":
				_oScore3 = transform.gameObject;
				_oScoreText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score4":
				_oScore4 = transform.gameObject;
				_oScoreText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score5":
				_oScore5 = transform.gameObject;
				_oScoreText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "Score6":
				_oScore6 = transform.gameObject;
				_oScoreText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "ReleiveImage1":
				_oReleiveImage1 = transform.gameObject;
				break;
			case "ReleiveImage2":
				_oReleiveImage2 = transform.gameObject;
				break;
			case "ReleiveImage3":
				_oReleiveImage3 = transform.gameObject;
				break;
			case "ReleiveImage4":
				_oReleiveImage4 = transform.gameObject;
				break;
			case "ReleiveImage5":
				_oReleiveImage5 = transform.gameObject;
				break;
			case "ReleiveImage6":
				_oReleiveImage6 = transform.gameObject;
				break;
			}
		}
	}

	public bool GetStatisticShow(int index)
	{
		return index switch
		{
			1 => StatisticShow1, 
			2 => StatisticShow2, 
			3 => StatisticShow3, 
			4 => StatisticShow4, 
			5 => StatisticShow5, 
			6 => StatisticShow6, 
			_ => false, 
		};
	}

	public void SetStatisticShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			StatisticShow1 = value;
			break;
		case 2:
			StatisticShow2 = value;
			break;
		case 3:
			StatisticShow3 = value;
			break;
		case 4:
			StatisticShow4 = value;
			break;
		case 5:
			StatisticShow5 = value;
			break;
		case 6:
			StatisticShow6 = value;
			break;
		}
	}

	public bool GetDescShow(int index)
	{
		return index switch
		{
			1 => DescShow1, 
			2 => DescShow2, 
			3 => DescShow3, 
			4 => DescShow4, 
			5 => DescShow5, 
			6 => DescShow6, 
			_ => false, 
		};
	}

	public void SetDescShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			DescShow1 = value;
			break;
		case 2:
			DescShow2 = value;
			break;
		case 3:
			DescShow3 = value;
			break;
		case 4:
			DescShow4 = value;
			break;
		case 5:
			DescShow5 = value;
			break;
		case 6:
			DescShow6 = value;
			break;
		}
	}

	public bool GetRankIconShow(int index)
	{
		return index switch
		{
			1 => RankIconShow1, 
			2 => RankIconShow2, 
			3 => RankIconShow3, 
			4 => RankIconShow4, 
			5 => RankIconShow5, 
			6 => RankIconShow6, 
			_ => false, 
		};
	}

	public void SetRankIconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			RankIconShow1 = value;
			break;
		case 2:
			RankIconShow2 = value;
			break;
		case 3:
			RankIconShow3 = value;
			break;
		case 4:
			RankIconShow4 = value;
			break;
		case 5:
			RankIconShow5 = value;
			break;
		case 6:
			RankIconShow6 = value;
			break;
		}
	}

	public bool GetRelieveBgShow(int index)
	{
		return index switch
		{
			1 => RelieveBgShow1, 
			2 => RelieveBgShow2, 
			3 => RelieveBgShow3, 
			4 => RelieveBgShow4, 
			5 => RelieveBgShow5, 
			6 => RelieveBgShow6, 
			_ => false, 
		};
	}

	public void SetRelieveBgShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			RelieveBgShow1 = value;
			break;
		case 2:
			RelieveBgShow2 = value;
			break;
		case 3:
			RelieveBgShow3 = value;
			break;
		case 4:
			RelieveBgShow4 = value;
			break;
		case 5:
			RelieveBgShow5 = value;
			break;
		case 6:
			RelieveBgShow6 = value;
			break;
		}
	}

	public float GetRelieveProgressBarFillamount(int index)
	{
		return index switch
		{
			1 => RelieveProgressBarFillamount1, 
			2 => RelieveProgressBarFillamount2, 
			3 => RelieveProgressBarFillamount3, 
			4 => RelieveProgressBarFillamount4, 
			5 => RelieveProgressBarFillamount5, 
			6 => RelieveProgressBarFillamount6, 
			_ => 0f, 
		};
	}

	public void SetRelieveProgressBarFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			RelieveProgressBarFillamount1 = value;
			break;
		case 2:
			RelieveProgressBarFillamount2 = value;
			break;
		case 3:
			RelieveProgressBarFillamount3 = value;
			break;
		case 4:
			RelieveProgressBarFillamount4 = value;
			break;
		case 5:
			RelieveProgressBarFillamount5 = value;
			break;
		case 6:
			RelieveProgressBarFillamount6 = value;
			break;
		}
	}

	public string GetPlayerNameString(int index)
	{
		return index switch
		{
			1 => PlayerNameString1, 
			2 => PlayerNameString2, 
			3 => PlayerNameString3, 
			4 => PlayerNameString4, 
			5 => PlayerNameString5, 
			6 => PlayerNameString6, 
			_ => null, 
		};
	}

	public void SetPlayerNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			PlayerNameString1 = value;
			break;
		case 2:
			PlayerNameString2 = value;
			break;
		case 3:
			PlayerNameString3 = value;
			break;
		case 4:
			PlayerNameString4 = value;
			break;
		case 5:
			PlayerNameString5 = value;
			break;
		case 6:
			PlayerNameString6 = value;
			break;
		}
	}

	public Color GetPlayerNameTextcolor(int index)
	{
		return index switch
		{
			1 => PlayerNameTextcolor1, 
			2 => PlayerNameTextcolor2, 
			3 => PlayerNameTextcolor3, 
			4 => PlayerNameTextcolor4, 
			5 => PlayerNameTextcolor5, 
			6 => PlayerNameTextcolor6, 
			_ => Color.white, 
		};
	}

	public void SetPlayerNameTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			PlayerNameTextcolor1 = value;
			break;
		case 2:
			PlayerNameTextcolor2 = value;
			break;
		case 3:
			PlayerNameTextcolor3 = value;
			break;
		case 4:
			PlayerNameTextcolor4 = value;
			break;
		case 5:
			PlayerNameTextcolor5 = value;
			break;
		case 6:
			PlayerNameTextcolor6 = value;
			break;
		}
	}

	public string GetIntegralRatioString(int index)
	{
		return index switch
		{
			1 => IntegralRatioString1, 
			2 => IntegralRatioString2, 
			3 => IntegralRatioString3, 
			4 => IntegralRatioString4, 
			5 => IntegralRatioString5, 
			6 => IntegralRatioString6, 
			_ => null, 
		};
	}

	public void SetIntegralRatioString(int index, string value)
	{
		switch (index)
		{
		case 1:
			IntegralRatioString1 = value;
			break;
		case 2:
			IntegralRatioString2 = value;
			break;
		case 3:
			IntegralRatioString3 = value;
			break;
		case 4:
			IntegralRatioString4 = value;
			break;
		case 5:
			IntegralRatioString5 = value;
			break;
		case 6:
			IntegralRatioString6 = value;
			break;
		}
	}

	public Color GetIntegralRatioTextcolor(int index)
	{
		return index switch
		{
			1 => IntegralRatioTextcolor1, 
			2 => IntegralRatioTextcolor2, 
			3 => IntegralRatioTextcolor3, 
			4 => IntegralRatioTextcolor4, 
			5 => IntegralRatioTextcolor5, 
			6 => IntegralRatioTextcolor6, 
			_ => Color.white, 
		};
	}

	public void SetIntegralRatioTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			IntegralRatioTextcolor1 = value;
			break;
		case 2:
			IntegralRatioTextcolor2 = value;
			break;
		case 3:
			IntegralRatioTextcolor3 = value;
			break;
		case 4:
			IntegralRatioTextcolor4 = value;
			break;
		case 5:
			IntegralRatioTextcolor5 = value;
			break;
		case 6:
			IntegralRatioTextcolor6 = value;
			break;
		}
	}

	public string GetScoreString(int index)
	{
		return index switch
		{
			1 => ScoreString1, 
			2 => ScoreString2, 
			3 => ScoreString3, 
			4 => ScoreString4, 
			5 => ScoreString5, 
			6 => ScoreString6, 
			_ => null, 
		};
	}

	public void SetScoreString(int index, string value)
	{
		switch (index)
		{
		case 1:
			ScoreString1 = value;
			break;
		case 2:
			ScoreString2 = value;
			break;
		case 3:
			ScoreString3 = value;
			break;
		case 4:
			ScoreString4 = value;
			break;
		case 5:
			ScoreString5 = value;
			break;
		case 6:
			ScoreString6 = value;
			break;
		}
	}

	public bool GetReleiveImageShow(int index)
	{
		return index switch
		{
			1 => ReleiveImageShow1, 
			2 => ReleiveImageShow2, 
			3 => ReleiveImageShow3, 
			4 => ReleiveImageShow4, 
			5 => ReleiveImageShow5, 
			6 => ReleiveImageShow6, 
			_ => false, 
		};
	}

	public void SetReleiveImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ReleiveImageShow1 = value;
			break;
		case 2:
			ReleiveImageShow2 = value;
			break;
		case 3:
			ReleiveImageShow3 = value;
			break;
		case 4:
			ReleiveImageShow4 = value;
			break;
		case 5:
			ReleiveImageShow5 = value;
			break;
		case 6:
			ReleiveImageShow6 = value;
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
