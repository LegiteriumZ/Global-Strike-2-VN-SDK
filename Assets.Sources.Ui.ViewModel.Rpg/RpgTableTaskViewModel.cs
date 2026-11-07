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
public class RpgTableTaskViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oBg;

	private RectTransform _oBgRectTransform;

	private GameObject _oTaskItem1;

	private GameObject _oTaskItem2;

	private GameObject _oTaskItem3;

	private GameObject _oTaskItem4;

	private GameObject _oTaskItem5;

	private GameObject _oTaskItem6;

	private GameObject _oTaskItem7;

	private GameObject _oTaskItem8;

	private GameObject _oTaskItem9;

	private GameObject _oTaskItem10;

	private GameObject _oProgress1;

	private GameObject _oProgress2;

	private GameObject _oProgress3;

	private GameObject _oProgress4;

	private GameObject _oProgress5;

	private GameObject _oProgress6;

	private GameObject _oProgress7;

	private GameObject _oProgress8;

	private GameObject _oProgress9;

	private GameObject _oProgress10;

	private Image _oProgressImage1;

	private Image _oProgressImage2;

	private Image _oProgressImage3;

	private Image _oProgressImage4;

	private Image _oProgressImage5;

	private Image _oProgressImage6;

	private Image _oProgressImage7;

	private Image _oProgressImage8;

	private Image _oProgressImage9;

	private Image _oProgressImage10;

	private GameObject _oCurCount1;

	private GameObject _oCurCount2;

	private GameObject _oCurCount3;

	private GameObject _oCurCount4;

	private GameObject _oCurCount5;

	private GameObject _oCurCount6;

	private GameObject _oCurCount7;

	private GameObject _oCurCount8;

	private GameObject _oCurCount9;

	private GameObject _oCurCount10;

	private Text _oCurCountText1;

	private Text _oCurCountText2;

	private Text _oCurCountText3;

	private Text _oCurCountText4;

	private Text _oCurCountText5;

	private Text _oCurCountText6;

	private Text _oCurCountText7;

	private Text _oCurCountText8;

	private Text _oCurCountText9;

	private Text _oCurCountText10;

	private GameObject _oTotalCount1;

	private GameObject _oTotalCount2;

	private GameObject _oTotalCount3;

	private GameObject _oTotalCount4;

	private GameObject _oTotalCount5;

	private GameObject _oTotalCount6;

	private GameObject _oTotalCount7;

	private GameObject _oTotalCount8;

	private GameObject _oTotalCount9;

	private GameObject _oTotalCount10;

	private Text _oTotalCountText1;

	private Text _oTotalCountText2;

	private Text _oTotalCountText3;

	private Text _oTotalCountText4;

	private Text _oTotalCountText5;

	private Text _oTotalCountText6;

	private Text _oTotalCountText7;

	private Text _oTotalCountText8;

	private Text _oTotalCountText9;

	private Text _oTotalCountText10;

	private GameObject _oTaskName1;

	private GameObject _oTaskName2;

	private GameObject _oTaskName3;

	private GameObject _oTaskName4;

	private GameObject _oTaskName5;

	private GameObject _oTaskName6;

	private GameObject _oTaskName7;

	private GameObject _oTaskName8;

	private GameObject _oTaskName9;

	private GameObject _oTaskName10;

	private Text _oTaskNameText1;

	private Text _oTaskNameText2;

	private Text _oTaskNameText3;

	private Text _oTaskNameText4;

	private Text _oTaskNameText5;

	private Text _oTaskNameText6;

	private Text _oTaskNameText7;

	private Text _oTaskNameText8;

	private Text _oTaskNameText9;

	private Text _oTaskNameText10;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgTableTask";

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

	public Vector3 BgSize
	{
		get
		{
			if (_oBgRectTransform != null)
			{
				return _oBgRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (BgSize != value && _oBgRectTransform != null)
			{
				_oBgRectTransform.sizeDelta = value;
			}
		}
	}

	public bool TaskItemShow1
	{
		get
		{
			if (_oTaskItem1 != null)
			{
				return _oTaskItem1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TaskItemShow1 != value && _oTaskItem1 != null)
			{
				_oTaskItem1.SetObjectActive(value);
			}
		}
	}

	public bool TaskItemShow2
	{
		get
		{
			if (_oTaskItem2 != null)
			{
				return _oTaskItem2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TaskItemShow2 != value && _oTaskItem2 != null)
			{
				_oTaskItem2.SetObjectActive(value);
			}
		}
	}

	public bool TaskItemShow3
	{
		get
		{
			if (_oTaskItem3 != null)
			{
				return _oTaskItem3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TaskItemShow3 != value && _oTaskItem3 != null)
			{
				_oTaskItem3.SetObjectActive(value);
			}
		}
	}

	public bool TaskItemShow4
	{
		get
		{
			if (_oTaskItem4 != null)
			{
				return _oTaskItem4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TaskItemShow4 != value && _oTaskItem4 != null)
			{
				_oTaskItem4.SetObjectActive(value);
			}
		}
	}

	public bool TaskItemShow5
	{
		get
		{
			if (_oTaskItem5 != null)
			{
				return _oTaskItem5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TaskItemShow5 != value && _oTaskItem5 != null)
			{
				_oTaskItem5.SetObjectActive(value);
			}
		}
	}

	public bool TaskItemShow6
	{
		get
		{
			if (_oTaskItem6 != null)
			{
				return _oTaskItem6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TaskItemShow6 != value && _oTaskItem6 != null)
			{
				_oTaskItem6.SetObjectActive(value);
			}
		}
	}

	public bool TaskItemShow7
	{
		get
		{
			if (_oTaskItem7 != null)
			{
				return _oTaskItem7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TaskItemShow7 != value && _oTaskItem7 != null)
			{
				_oTaskItem7.SetObjectActive(value);
			}
		}
	}

	public bool TaskItemShow8
	{
		get
		{
			if (_oTaskItem8 != null)
			{
				return _oTaskItem8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TaskItemShow8 != value && _oTaskItem8 != null)
			{
				_oTaskItem8.SetObjectActive(value);
			}
		}
	}

	public bool TaskItemShow9
	{
		get
		{
			if (_oTaskItem9 != null)
			{
				return _oTaskItem9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TaskItemShow9 != value && _oTaskItem9 != null)
			{
				_oTaskItem9.SetObjectActive(value);
			}
		}
	}

	public bool TaskItemShow10
	{
		get
		{
			if (_oTaskItem10 != null)
			{
				return _oTaskItem10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TaskItemShow10 != value && _oTaskItem10 != null)
			{
				_oTaskItem10.SetObjectActive(value);
			}
		}
	}

	public float ProgressFillamount1
	{
		get
		{
			if (_oProgressImage1 != null)
			{
				return _oProgressImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount1 != value && _oProgressImage1 != null)
			{
				_oProgressImage1.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount2
	{
		get
		{
			if (_oProgressImage2 != null)
			{
				return _oProgressImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount2 != value && _oProgressImage2 != null)
			{
				_oProgressImage2.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount3
	{
		get
		{
			if (_oProgressImage3 != null)
			{
				return _oProgressImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount3 != value && _oProgressImage3 != null)
			{
				_oProgressImage3.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount4
	{
		get
		{
			if (_oProgressImage4 != null)
			{
				return _oProgressImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount4 != value && _oProgressImage4 != null)
			{
				_oProgressImage4.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount5
	{
		get
		{
			if (_oProgressImage5 != null)
			{
				return _oProgressImage5.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount5 != value && _oProgressImage5 != null)
			{
				_oProgressImage5.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount6
	{
		get
		{
			if (_oProgressImage6 != null)
			{
				return _oProgressImage6.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount6 != value && _oProgressImage6 != null)
			{
				_oProgressImage6.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount7
	{
		get
		{
			if (_oProgressImage7 != null)
			{
				return _oProgressImage7.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount7 != value && _oProgressImage7 != null)
			{
				_oProgressImage7.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount8
	{
		get
		{
			if (_oProgressImage8 != null)
			{
				return _oProgressImage8.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount8 != value && _oProgressImage8 != null)
			{
				_oProgressImage8.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount9
	{
		get
		{
			if (_oProgressImage9 != null)
			{
				return _oProgressImage9.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount9 != value && _oProgressImage9 != null)
			{
				_oProgressImage9.fillAmount = value;
			}
		}
	}

	public float ProgressFillamount10
	{
		get
		{
			if (_oProgressImage10 != null)
			{
				return _oProgressImage10.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount10 != value && _oProgressImage10 != null)
			{
				_oProgressImage10.fillAmount = value;
			}
		}
	}

	public string CurCountString1
	{
		get
		{
			if (_oCurCountText1 != null)
			{
				return _oCurCountText1.text;
			}
			return null;
		}
		set
		{
			if (CurCountString1 != value && _oCurCountText1 != null)
			{
				_oCurCountText1.text = value;
			}
		}
	}

	public string CurCountString2
	{
		get
		{
			if (_oCurCountText2 != null)
			{
				return _oCurCountText2.text;
			}
			return null;
		}
		set
		{
			if (CurCountString2 != value && _oCurCountText2 != null)
			{
				_oCurCountText2.text = value;
			}
		}
	}

	public string CurCountString3
	{
		get
		{
			if (_oCurCountText3 != null)
			{
				return _oCurCountText3.text;
			}
			return null;
		}
		set
		{
			if (CurCountString3 != value && _oCurCountText3 != null)
			{
				_oCurCountText3.text = value;
			}
		}
	}

	public string CurCountString4
	{
		get
		{
			if (_oCurCountText4 != null)
			{
				return _oCurCountText4.text;
			}
			return null;
		}
		set
		{
			if (CurCountString4 != value && _oCurCountText4 != null)
			{
				_oCurCountText4.text = value;
			}
		}
	}

	public string CurCountString5
	{
		get
		{
			if (_oCurCountText5 != null)
			{
				return _oCurCountText5.text;
			}
			return null;
		}
		set
		{
			if (CurCountString5 != value && _oCurCountText5 != null)
			{
				_oCurCountText5.text = value;
			}
		}
	}

	public string CurCountString6
	{
		get
		{
			if (_oCurCountText6 != null)
			{
				return _oCurCountText6.text;
			}
			return null;
		}
		set
		{
			if (CurCountString6 != value && _oCurCountText6 != null)
			{
				_oCurCountText6.text = value;
			}
		}
	}

	public string CurCountString7
	{
		get
		{
			if (_oCurCountText7 != null)
			{
				return _oCurCountText7.text;
			}
			return null;
		}
		set
		{
			if (CurCountString7 != value && _oCurCountText7 != null)
			{
				_oCurCountText7.text = value;
			}
		}
	}

	public string CurCountString8
	{
		get
		{
			if (_oCurCountText8 != null)
			{
				return _oCurCountText8.text;
			}
			return null;
		}
		set
		{
			if (CurCountString8 != value && _oCurCountText8 != null)
			{
				_oCurCountText8.text = value;
			}
		}
	}

	public string CurCountString9
	{
		get
		{
			if (_oCurCountText9 != null)
			{
				return _oCurCountText9.text;
			}
			return null;
		}
		set
		{
			if (CurCountString9 != value && _oCurCountText9 != null)
			{
				_oCurCountText9.text = value;
			}
		}
	}

	public string CurCountString10
	{
		get
		{
			if (_oCurCountText10 != null)
			{
				return _oCurCountText10.text;
			}
			return null;
		}
		set
		{
			if (CurCountString10 != value && _oCurCountText10 != null)
			{
				_oCurCountText10.text = value;
			}
		}
	}

	public string TotalCountString1
	{
		get
		{
			if (_oTotalCountText1 != null)
			{
				return _oTotalCountText1.text;
			}
			return null;
		}
		set
		{
			if (TotalCountString1 != value && _oTotalCountText1 != null)
			{
				_oTotalCountText1.text = value;
			}
		}
	}

	public string TotalCountString2
	{
		get
		{
			if (_oTotalCountText2 != null)
			{
				return _oTotalCountText2.text;
			}
			return null;
		}
		set
		{
			if (TotalCountString2 != value && _oTotalCountText2 != null)
			{
				_oTotalCountText2.text = value;
			}
		}
	}

	public string TotalCountString3
	{
		get
		{
			if (_oTotalCountText3 != null)
			{
				return _oTotalCountText3.text;
			}
			return null;
		}
		set
		{
			if (TotalCountString3 != value && _oTotalCountText3 != null)
			{
				_oTotalCountText3.text = value;
			}
		}
	}

	public string TotalCountString4
	{
		get
		{
			if (_oTotalCountText4 != null)
			{
				return _oTotalCountText4.text;
			}
			return null;
		}
		set
		{
			if (TotalCountString4 != value && _oTotalCountText4 != null)
			{
				_oTotalCountText4.text = value;
			}
		}
	}

	public string TotalCountString5
	{
		get
		{
			if (_oTotalCountText5 != null)
			{
				return _oTotalCountText5.text;
			}
			return null;
		}
		set
		{
			if (TotalCountString5 != value && _oTotalCountText5 != null)
			{
				_oTotalCountText5.text = value;
			}
		}
	}

	public string TotalCountString6
	{
		get
		{
			if (_oTotalCountText6 != null)
			{
				return _oTotalCountText6.text;
			}
			return null;
		}
		set
		{
			if (TotalCountString6 != value && _oTotalCountText6 != null)
			{
				_oTotalCountText6.text = value;
			}
		}
	}

	public string TotalCountString7
	{
		get
		{
			if (_oTotalCountText7 != null)
			{
				return _oTotalCountText7.text;
			}
			return null;
		}
		set
		{
			if (TotalCountString7 != value && _oTotalCountText7 != null)
			{
				_oTotalCountText7.text = value;
			}
		}
	}

	public string TotalCountString8
	{
		get
		{
			if (_oTotalCountText8 != null)
			{
				return _oTotalCountText8.text;
			}
			return null;
		}
		set
		{
			if (TotalCountString8 != value && _oTotalCountText8 != null)
			{
				_oTotalCountText8.text = value;
			}
		}
	}

	public string TotalCountString9
	{
		get
		{
			if (_oTotalCountText9 != null)
			{
				return _oTotalCountText9.text;
			}
			return null;
		}
		set
		{
			if (TotalCountString9 != value && _oTotalCountText9 != null)
			{
				_oTotalCountText9.text = value;
			}
		}
	}

	public string TotalCountString10
	{
		get
		{
			if (_oTotalCountText10 != null)
			{
				return _oTotalCountText10.text;
			}
			return null;
		}
		set
		{
			if (TotalCountString10 != value && _oTotalCountText10 != null)
			{
				_oTotalCountText10.text = value;
			}
		}
	}

	public string TaskNameString1
	{
		get
		{
			if (_oTaskNameText1 != null)
			{
				return _oTaskNameText1.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString1 != value && _oTaskNameText1 != null)
			{
				_oTaskNameText1.text = value;
			}
		}
	}

	public string TaskNameString2
	{
		get
		{
			if (_oTaskNameText2 != null)
			{
				return _oTaskNameText2.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString2 != value && _oTaskNameText2 != null)
			{
				_oTaskNameText2.text = value;
			}
		}
	}

	public string TaskNameString3
	{
		get
		{
			if (_oTaskNameText3 != null)
			{
				return _oTaskNameText3.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString3 != value && _oTaskNameText3 != null)
			{
				_oTaskNameText3.text = value;
			}
		}
	}

	public string TaskNameString4
	{
		get
		{
			if (_oTaskNameText4 != null)
			{
				return _oTaskNameText4.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString4 != value && _oTaskNameText4 != null)
			{
				_oTaskNameText4.text = value;
			}
		}
	}

	public string TaskNameString5
	{
		get
		{
			if (_oTaskNameText5 != null)
			{
				return _oTaskNameText5.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString5 != value && _oTaskNameText5 != null)
			{
				_oTaskNameText5.text = value;
			}
		}
	}

	public string TaskNameString6
	{
		get
		{
			if (_oTaskNameText6 != null)
			{
				return _oTaskNameText6.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString6 != value && _oTaskNameText6 != null)
			{
				_oTaskNameText6.text = value;
			}
		}
	}

	public string TaskNameString7
	{
		get
		{
			if (_oTaskNameText7 != null)
			{
				return _oTaskNameText7.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString7 != value && _oTaskNameText7 != null)
			{
				_oTaskNameText7.text = value;
			}
		}
	}

	public string TaskNameString8
	{
		get
		{
			if (_oTaskNameText8 != null)
			{
				return _oTaskNameText8.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString8 != value && _oTaskNameText8 != null)
			{
				_oTaskNameText8.text = value;
			}
		}
	}

	public string TaskNameString9
	{
		get
		{
			if (_oTaskNameText9 != null)
			{
				return _oTaskNameText9.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString9 != value && _oTaskNameText9 != null)
			{
				_oTaskNameText9.text = value;
			}
		}
	}

	public string TaskNameString10
	{
		get
		{
			if (_oTaskNameText10 != null)
			{
				return _oTaskNameText10.text;
			}
			return null;
		}
		set
		{
			if (TaskNameString10 != value && _oTaskNameText10 != null)
			{
				_oTaskNameText10.text = value;
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
			case "Bg":
				_oBg = transform.gameObject;
				_oBgRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "TaskItem1":
				_oTaskItem1 = transform.gameObject;
				break;
			case "TaskItem2":
				_oTaskItem2 = transform.gameObject;
				break;
			case "TaskItem3":
				_oTaskItem3 = transform.gameObject;
				break;
			case "TaskItem4":
				_oTaskItem4 = transform.gameObject;
				break;
			case "TaskItem5":
				_oTaskItem5 = transform.gameObject;
				break;
			case "TaskItem6":
				_oTaskItem6 = transform.gameObject;
				break;
			case "TaskItem7":
				_oTaskItem7 = transform.gameObject;
				break;
			case "TaskItem8":
				_oTaskItem8 = transform.gameObject;
				break;
			case "TaskItem9":
				_oTaskItem9 = transform.gameObject;
				break;
			case "TaskItem10":
				_oTaskItem10 = transform.gameObject;
				break;
			case "Progress1":
				_oProgress1 = transform.gameObject;
				_oProgressImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress2":
				_oProgress2 = transform.gameObject;
				_oProgressImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress3":
				_oProgress3 = transform.gameObject;
				_oProgressImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress4":
				_oProgress4 = transform.gameObject;
				_oProgressImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress5":
				_oProgress5 = transform.gameObject;
				_oProgressImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress6":
				_oProgress6 = transform.gameObject;
				_oProgressImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress7":
				_oProgress7 = transform.gameObject;
				_oProgressImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress8":
				_oProgress8 = transform.gameObject;
				_oProgressImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress9":
				_oProgress9 = transform.gameObject;
				_oProgressImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress10":
				_oProgress10 = transform.gameObject;
				_oProgressImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "CurCount1":
				_oCurCount1 = transform.gameObject;
				_oCurCountText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "CurCount2":
				_oCurCount2 = transform.gameObject;
				_oCurCountText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "CurCount3":
				_oCurCount3 = transform.gameObject;
				_oCurCountText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "CurCount4":
				_oCurCount4 = transform.gameObject;
				_oCurCountText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "CurCount5":
				_oCurCount5 = transform.gameObject;
				_oCurCountText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "CurCount6":
				_oCurCount6 = transform.gameObject;
				_oCurCountText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "CurCount7":
				_oCurCount7 = transform.gameObject;
				_oCurCountText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "CurCount8":
				_oCurCount8 = transform.gameObject;
				_oCurCountText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "CurCount9":
				_oCurCount9 = transform.gameObject;
				_oCurCountText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "CurCount10":
				_oCurCount10 = transform.gameObject;
				_oCurCountText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalCount1":
				_oTotalCount1 = transform.gameObject;
				_oTotalCountText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalCount2":
				_oTotalCount2 = transform.gameObject;
				_oTotalCountText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalCount3":
				_oTotalCount3 = transform.gameObject;
				_oTotalCountText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalCount4":
				_oTotalCount4 = transform.gameObject;
				_oTotalCountText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalCount5":
				_oTotalCount5 = transform.gameObject;
				_oTotalCountText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalCount6":
				_oTotalCount6 = transform.gameObject;
				_oTotalCountText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalCount7":
				_oTotalCount7 = transform.gameObject;
				_oTotalCountText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalCount8":
				_oTotalCount8 = transform.gameObject;
				_oTotalCountText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalCount9":
				_oTotalCount9 = transform.gameObject;
				_oTotalCountText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "TotalCount10":
				_oTotalCount10 = transform.gameObject;
				_oTotalCountText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName1":
				_oTaskName1 = transform.gameObject;
				_oTaskNameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName2":
				_oTaskName2 = transform.gameObject;
				_oTaskNameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName3":
				_oTaskName3 = transform.gameObject;
				_oTaskNameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName4":
				_oTaskName4 = transform.gameObject;
				_oTaskNameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName5":
				_oTaskName5 = transform.gameObject;
				_oTaskNameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName6":
				_oTaskName6 = transform.gameObject;
				_oTaskNameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName7":
				_oTaskName7 = transform.gameObject;
				_oTaskNameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName8":
				_oTaskName8 = transform.gameObject;
				_oTaskNameText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName9":
				_oTaskName9 = transform.gameObject;
				_oTaskNameText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "TaskName10":
				_oTaskName10 = transform.gameObject;
				_oTaskNameText10 = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GetTaskItemShow(int index)
	{
		return index switch
		{
			1 => TaskItemShow1, 
			2 => TaskItemShow2, 
			3 => TaskItemShow3, 
			4 => TaskItemShow4, 
			5 => TaskItemShow5, 
			6 => TaskItemShow6, 
			7 => TaskItemShow7, 
			8 => TaskItemShow8, 
			9 => TaskItemShow9, 
			10 => TaskItemShow10, 
			_ => false, 
		};
	}

	public void SetTaskItemShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			TaskItemShow1 = value;
			break;
		case 2:
			TaskItemShow2 = value;
			break;
		case 3:
			TaskItemShow3 = value;
			break;
		case 4:
			TaskItemShow4 = value;
			break;
		case 5:
			TaskItemShow5 = value;
			break;
		case 6:
			TaskItemShow6 = value;
			break;
		case 7:
			TaskItemShow7 = value;
			break;
		case 8:
			TaskItemShow8 = value;
			break;
		case 9:
			TaskItemShow9 = value;
			break;
		case 10:
			TaskItemShow10 = value;
			break;
		}
	}

	public float GetProgressFillamount(int index)
	{
		return index switch
		{
			1 => ProgressFillamount1, 
			2 => ProgressFillamount2, 
			3 => ProgressFillamount3, 
			4 => ProgressFillamount4, 
			5 => ProgressFillamount5, 
			6 => ProgressFillamount6, 
			7 => ProgressFillamount7, 
			8 => ProgressFillamount8, 
			9 => ProgressFillamount9, 
			10 => ProgressFillamount10, 
			_ => 0f, 
		};
	}

	public void SetProgressFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			ProgressFillamount1 = value;
			break;
		case 2:
			ProgressFillamount2 = value;
			break;
		case 3:
			ProgressFillamount3 = value;
			break;
		case 4:
			ProgressFillamount4 = value;
			break;
		case 5:
			ProgressFillamount5 = value;
			break;
		case 6:
			ProgressFillamount6 = value;
			break;
		case 7:
			ProgressFillamount7 = value;
			break;
		case 8:
			ProgressFillamount8 = value;
			break;
		case 9:
			ProgressFillamount9 = value;
			break;
		case 10:
			ProgressFillamount10 = value;
			break;
		}
	}

	public string GetCurCountString(int index)
	{
		return index switch
		{
			1 => CurCountString1, 
			2 => CurCountString2, 
			3 => CurCountString3, 
			4 => CurCountString4, 
			5 => CurCountString5, 
			6 => CurCountString6, 
			7 => CurCountString7, 
			8 => CurCountString8, 
			9 => CurCountString9, 
			10 => CurCountString10, 
			_ => null, 
		};
	}

	public void SetCurCountString(int index, string value)
	{
		switch (index)
		{
		case 1:
			CurCountString1 = value;
			break;
		case 2:
			CurCountString2 = value;
			break;
		case 3:
			CurCountString3 = value;
			break;
		case 4:
			CurCountString4 = value;
			break;
		case 5:
			CurCountString5 = value;
			break;
		case 6:
			CurCountString6 = value;
			break;
		case 7:
			CurCountString7 = value;
			break;
		case 8:
			CurCountString8 = value;
			break;
		case 9:
			CurCountString9 = value;
			break;
		case 10:
			CurCountString10 = value;
			break;
		}
	}

	public string GetTotalCountString(int index)
	{
		return index switch
		{
			1 => TotalCountString1, 
			2 => TotalCountString2, 
			3 => TotalCountString3, 
			4 => TotalCountString4, 
			5 => TotalCountString5, 
			6 => TotalCountString6, 
			7 => TotalCountString7, 
			8 => TotalCountString8, 
			9 => TotalCountString9, 
			10 => TotalCountString10, 
			_ => null, 
		};
	}

	public void SetTotalCountString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TotalCountString1 = value;
			break;
		case 2:
			TotalCountString2 = value;
			break;
		case 3:
			TotalCountString3 = value;
			break;
		case 4:
			TotalCountString4 = value;
			break;
		case 5:
			TotalCountString5 = value;
			break;
		case 6:
			TotalCountString6 = value;
			break;
		case 7:
			TotalCountString7 = value;
			break;
		case 8:
			TotalCountString8 = value;
			break;
		case 9:
			TotalCountString9 = value;
			break;
		case 10:
			TotalCountString10 = value;
			break;
		}
	}

	public string GetTaskNameString(int index)
	{
		return index switch
		{
			1 => TaskNameString1, 
			2 => TaskNameString2, 
			3 => TaskNameString3, 
			4 => TaskNameString4, 
			5 => TaskNameString5, 
			6 => TaskNameString6, 
			7 => TaskNameString7, 
			8 => TaskNameString8, 
			9 => TaskNameString9, 
			10 => TaskNameString10, 
			_ => null, 
		};
	}

	public void SetTaskNameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			TaskNameString1 = value;
			break;
		case 2:
			TaskNameString2 = value;
			break;
		case 3:
			TaskNameString3 = value;
			break;
		case 4:
			TaskNameString4 = value;
			break;
		case 5:
			TaskNameString5 = value;
			break;
		case 6:
			TaskNameString6 = value;
			break;
		case 7:
			TaskNameString7 = value;
			break;
		case 8:
			TaskNameString8 = value;
			break;
		case 9:
			TaskNameString9 = value;
			break;
		case 10:
			TaskNameString10 = value;
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
