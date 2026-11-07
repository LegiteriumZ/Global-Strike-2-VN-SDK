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

namespace Assets.Sources.Ui.ViewModel.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearSkillTreeViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oskillBackImage1;

	private GameObject _oskillBackImage2;

	private GameObject _oskillBackImage3;

	private GameObject _oskills;

	private GameObject _oSkill1;

	private GameObject _oSkill2;

	private GameObject _oSkill3;

	private GameObject _oSkill4;

	private GameObject _oSkill5;

	private GameObject _oSkill6;

	private GameObject _oSkill7;

	private GameObject _oSkill8;

	private GameObject _oSkill9;

	private GameObject _oSkill10;

	private GameObject _oSkill11;

	private GameObject _oSkill12;

	private GameObject _oSkill13;

	private GameObject _oSkill14;

	private GameObject _oSkill15;

	private GameObject _oSkill16;

	private GameObject _oSkill17;

	private GameObject _oSkill18;

	private GameObject _oSkill19;

	private GameObject _oSkill20;

	private GameObject _oSkill21;

	private GameObject _oSkill22;

	private RectTransform _oSkillRectTransform1;

	private RectTransform _oSkillRectTransform2;

	private RectTransform _oSkillRectTransform3;

	private RectTransform _oSkillRectTransform4;

	private RectTransform _oSkillRectTransform5;

	private RectTransform _oSkillRectTransform6;

	private RectTransform _oSkillRectTransform7;

	private RectTransform _oSkillRectTransform8;

	private RectTransform _oSkillRectTransform9;

	private RectTransform _oSkillRectTransform10;

	private RectTransform _oSkillRectTransform11;

	private RectTransform _oSkillRectTransform12;

	private RectTransform _oSkillRectTransform13;

	private RectTransform _oSkillRectTransform14;

	private RectTransform _oSkillRectTransform15;

	private RectTransform _oSkillRectTransform16;

	private RectTransform _oSkillRectTransform17;

	private RectTransform _oSkillRectTransform18;

	private RectTransform _oSkillRectTransform19;

	private RectTransform _oSkillRectTransform20;

	private RectTransform _oSkillRectTransform21;

	private RectTransform _oSkillRectTransform22;

	private Image _oSkillImage1;

	private Image _oSkillImage2;

	private Image _oSkillImage3;

	private Image _oSkillImage4;

	private Image _oSkillImage5;

	private Image _oSkillImage6;

	private Image _oSkillImage7;

	private Image _oSkillImage8;

	private Image _oSkillImage9;

	private Image _oSkillImage10;

	private Image _oSkillImage11;

	private Image _oSkillImage12;

	private Image _oSkillImage13;

	private Image _oSkillImage14;

	private Image _oSkillImage15;

	private Image _oSkillImage16;

	private Image _oSkillImage17;

	private Image _oSkillImage18;

	private Image _oSkillImage19;

	private Image _oSkillImage20;

	private Image _oSkillImage21;

	private Image _oSkillImage22;

	private EventTrigger _oSkillEventTrigger1;

	private EventTrigger _oSkillEventTrigger2;

	private EventTrigger _oSkillEventTrigger3;

	private EventTrigger _oSkillEventTrigger4;

	private EventTrigger _oSkillEventTrigger5;

	private EventTrigger _oSkillEventTrigger6;

	private EventTrigger _oSkillEventTrigger7;

	private EventTrigger _oSkillEventTrigger8;

	private EventTrigger _oSkillEventTrigger9;

	private EventTrigger _oSkillEventTrigger10;

	private EventTrigger _oSkillEventTrigger11;

	private EventTrigger _oSkillEventTrigger12;

	private EventTrigger _oSkillEventTrigger13;

	private EventTrigger _oSkillEventTrigger14;

	private EventTrigger _oSkillEventTrigger15;

	private EventTrigger _oSkillEventTrigger16;

	private EventTrigger _oSkillEventTrigger17;

	private EventTrigger _oSkillEventTrigger18;

	private EventTrigger _oSkillEventTrigger19;

	private EventTrigger _oSkillEventTrigger20;

	private EventTrigger _oSkillEventTrigger21;

	private EventTrigger _oSkillEventTrigger22;

	private Button _oSkillButton1;

	private Button _oSkillButton2;

	private Button _oSkillButton3;

	private Button _oSkillButton4;

	private Button _oSkillButton5;

	private Button _oSkillButton6;

	private Button _oSkillButton7;

	private Button _oSkillButton8;

	private Button _oSkillButton9;

	private Button _oSkillButton10;

	private Button _oSkillButton11;

	private Button _oSkillButton12;

	private Button _oSkillButton13;

	private Button _oSkillButton14;

	private Button _oSkillButton15;

	private Button _oSkillButton16;

	private Button _oSkillButton17;

	private Button _oSkillButton18;

	private Button _oSkillButton19;

	private Button _oSkillButton20;

	private Button _oSkillButton21;

	private Button _oSkillButton22;

	private GameObject _oSkillParent1;

	private GameObject _oSkillParent2;

	private GameObject _oSkillParent3;

	private RectTransform _oSkillParentRectTransform1;

	private RectTransform _oSkillParentRectTransform2;

	private RectTransform _oSkillParentRectTransform3;

	private GameObject _oBuff1;

	private GameObject _oBuff2;

	private GameObject _oBuff3;

	private GameObject _oBuff4;

	private GameObject _oBuff5;

	private GameObject _oBuff6;

	private GameObject _oBuff7;

	private GameObject _oBuff8;

	private GameObject _oBuff9;

	private GameObject _oBuff10;

	private GameObject _oBuff11;

	private GameObject _oBuff12;

	private RectTransform _oBuffRectTransform1;

	private RectTransform _oBuffRectTransform2;

	private RectTransform _oBuffRectTransform3;

	private RectTransform _oBuffRectTransform4;

	private RectTransform _oBuffRectTransform5;

	private RectTransform _oBuffRectTransform6;

	private RectTransform _oBuffRectTransform7;

	private RectTransform _oBuffRectTransform8;

	private RectTransform _oBuffRectTransform9;

	private RectTransform _oBuffRectTransform10;

	private RectTransform _oBuffRectTransform11;

	private RectTransform _oBuffRectTransform12;

	private Image _oBuffImage1;

	private Image _oBuffImage2;

	private Image _oBuffImage3;

	private Image _oBuffImage4;

	private Image _oBuffImage5;

	private Image _oBuffImage6;

	private Image _oBuffImage7;

	private Image _oBuffImage8;

	private Image _oBuffImage9;

	private Image _oBuffImage10;

	private Image _oBuffImage11;

	private Image _oBuffImage12;

	private EventTrigger _oBuffEventTrigger1;

	private EventTrigger _oBuffEventTrigger2;

	private EventTrigger _oBuffEventTrigger3;

	private EventTrigger _oBuffEventTrigger4;

	private EventTrigger _oBuffEventTrigger5;

	private EventTrigger _oBuffEventTrigger6;

	private EventTrigger _oBuffEventTrigger7;

	private EventTrigger _oBuffEventTrigger8;

	private EventTrigger _oBuffEventTrigger9;

	private EventTrigger _oBuffEventTrigger10;

	private EventTrigger _oBuffEventTrigger11;

	private EventTrigger _oBuffEventTrigger12;

	private Button _oBuffButton1;

	private Button _oBuffButton2;

	private Button _oBuffButton3;

	private Button _oBuffButton4;

	private Button _oBuffButton5;

	private Button _oBuffButton6;

	private Button _oBuffButton7;

	private Button _oBuffButton8;

	private Button _oBuffButton9;

	private Button _oBuffButton10;

	private Button _oBuffButton11;

	private Button _oBuffButton12;

	private GameObject _oSkillCount;

	private Text _oSkillCountText;

	private GameObject _oDes;

	private RectTransform _oDesRectTransform;

	private GameObject _oParent;

	private RectTransform _oParentRectTransform;

	private GameObject _oDesName;

	private Text _oDesNameText;

	private GameObject _oDesContent;

	private Text _oDesContentText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/rpgmouseyear";

	private string _resourceAssetName = "RpgMouseYearSkillTree";

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

	public bool skillBackImageShow1
	{
		get
		{
			if (_oskillBackImage1 != null)
			{
				return _oskillBackImage1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBackImageShow1 != value && _oskillBackImage1 != null)
			{
				_oskillBackImage1.SetObjectActive(value);
			}
		}
	}

	public bool skillBackImageShow2
	{
		get
		{
			if (_oskillBackImage2 != null)
			{
				return _oskillBackImage2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBackImageShow2 != value && _oskillBackImage2 != null)
			{
				_oskillBackImage2.SetObjectActive(value);
			}
		}
	}

	public bool skillBackImageShow3
	{
		get
		{
			if (_oskillBackImage3 != null)
			{
				return _oskillBackImage3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillBackImageShow3 != value && _oskillBackImage3 != null)
			{
				_oskillBackImage3.SetObjectActive(value);
			}
		}
	}

	public bool skillsShow
	{
		get
		{
			if (_oskills != null)
			{
				return _oskills.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skillsShow != value && _oskills != null)
			{
				_oskills.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow1
	{
		get
		{
			if (_oSkill1 != null)
			{
				return _oSkill1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow1 != value && _oSkill1 != null)
			{
				_oSkill1.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow2
	{
		get
		{
			if (_oSkill2 != null)
			{
				return _oSkill2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow2 != value && _oSkill2 != null)
			{
				_oSkill2.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow3
	{
		get
		{
			if (_oSkill3 != null)
			{
				return _oSkill3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow3 != value && _oSkill3 != null)
			{
				_oSkill3.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow4
	{
		get
		{
			if (_oSkill4 != null)
			{
				return _oSkill4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow4 != value && _oSkill4 != null)
			{
				_oSkill4.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow5
	{
		get
		{
			if (_oSkill5 != null)
			{
				return _oSkill5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow5 != value && _oSkill5 != null)
			{
				_oSkill5.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow6
	{
		get
		{
			if (_oSkill6 != null)
			{
				return _oSkill6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow6 != value && _oSkill6 != null)
			{
				_oSkill6.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow7
	{
		get
		{
			if (_oSkill7 != null)
			{
				return _oSkill7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow7 != value && _oSkill7 != null)
			{
				_oSkill7.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow8
	{
		get
		{
			if (_oSkill8 != null)
			{
				return _oSkill8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow8 != value && _oSkill8 != null)
			{
				_oSkill8.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow9
	{
		get
		{
			if (_oSkill9 != null)
			{
				return _oSkill9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow9 != value && _oSkill9 != null)
			{
				_oSkill9.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow10
	{
		get
		{
			if (_oSkill10 != null)
			{
				return _oSkill10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow10 != value && _oSkill10 != null)
			{
				_oSkill10.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow11
	{
		get
		{
			if (_oSkill11 != null)
			{
				return _oSkill11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow11 != value && _oSkill11 != null)
			{
				_oSkill11.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow12
	{
		get
		{
			if (_oSkill12 != null)
			{
				return _oSkill12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow12 != value && _oSkill12 != null)
			{
				_oSkill12.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow13
	{
		get
		{
			if (_oSkill13 != null)
			{
				return _oSkill13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow13 != value && _oSkill13 != null)
			{
				_oSkill13.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow14
	{
		get
		{
			if (_oSkill14 != null)
			{
				return _oSkill14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow14 != value && _oSkill14 != null)
			{
				_oSkill14.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow15
	{
		get
		{
			if (_oSkill15 != null)
			{
				return _oSkill15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow15 != value && _oSkill15 != null)
			{
				_oSkill15.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow16
	{
		get
		{
			if (_oSkill16 != null)
			{
				return _oSkill16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow16 != value && _oSkill16 != null)
			{
				_oSkill16.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow17
	{
		get
		{
			if (_oSkill17 != null)
			{
				return _oSkill17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow17 != value && _oSkill17 != null)
			{
				_oSkill17.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow18
	{
		get
		{
			if (_oSkill18 != null)
			{
				return _oSkill18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow18 != value && _oSkill18 != null)
			{
				_oSkill18.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow19
	{
		get
		{
			if (_oSkill19 != null)
			{
				return _oSkill19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow19 != value && _oSkill19 != null)
			{
				_oSkill19.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow20
	{
		get
		{
			if (_oSkill20 != null)
			{
				return _oSkill20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow20 != value && _oSkill20 != null)
			{
				_oSkill20.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow21
	{
		get
		{
			if (_oSkill21 != null)
			{
				return _oSkill21.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow21 != value && _oSkill21 != null)
			{
				_oSkill21.SetObjectActive(value);
			}
		}
	}

	public bool SkillShow22
	{
		get
		{
			if (_oSkill22 != null)
			{
				return _oSkill22.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillShow22 != value && _oSkill22 != null)
			{
				_oSkill22.SetObjectActive(value);
			}
		}
	}

	public Vector3 SkillPosition1
	{
		get
		{
			if (_oSkillRectTransform1 != null)
			{
				return _oSkillRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition1 != value && _oSkillRectTransform1 != null)
			{
				_oSkillRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition2
	{
		get
		{
			if (_oSkillRectTransform2 != null)
			{
				return _oSkillRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition2 != value && _oSkillRectTransform2 != null)
			{
				_oSkillRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition3
	{
		get
		{
			if (_oSkillRectTransform3 != null)
			{
				return _oSkillRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition3 != value && _oSkillRectTransform3 != null)
			{
				_oSkillRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition4
	{
		get
		{
			if (_oSkillRectTransform4 != null)
			{
				return _oSkillRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition4 != value && _oSkillRectTransform4 != null)
			{
				_oSkillRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition5
	{
		get
		{
			if (_oSkillRectTransform5 != null)
			{
				return _oSkillRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition5 != value && _oSkillRectTransform5 != null)
			{
				_oSkillRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition6
	{
		get
		{
			if (_oSkillRectTransform6 != null)
			{
				return _oSkillRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition6 != value && _oSkillRectTransform6 != null)
			{
				_oSkillRectTransform6.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition7
	{
		get
		{
			if (_oSkillRectTransform7 != null)
			{
				return _oSkillRectTransform7.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition7 != value && _oSkillRectTransform7 != null)
			{
				_oSkillRectTransform7.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition8
	{
		get
		{
			if (_oSkillRectTransform8 != null)
			{
				return _oSkillRectTransform8.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition8 != value && _oSkillRectTransform8 != null)
			{
				_oSkillRectTransform8.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition9
	{
		get
		{
			if (_oSkillRectTransform9 != null)
			{
				return _oSkillRectTransform9.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition9 != value && _oSkillRectTransform9 != null)
			{
				_oSkillRectTransform9.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition10
	{
		get
		{
			if (_oSkillRectTransform10 != null)
			{
				return _oSkillRectTransform10.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition10 != value && _oSkillRectTransform10 != null)
			{
				_oSkillRectTransform10.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition11
	{
		get
		{
			if (_oSkillRectTransform11 != null)
			{
				return _oSkillRectTransform11.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition11 != value && _oSkillRectTransform11 != null)
			{
				_oSkillRectTransform11.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition12
	{
		get
		{
			if (_oSkillRectTransform12 != null)
			{
				return _oSkillRectTransform12.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition12 != value && _oSkillRectTransform12 != null)
			{
				_oSkillRectTransform12.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition13
	{
		get
		{
			if (_oSkillRectTransform13 != null)
			{
				return _oSkillRectTransform13.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition13 != value && _oSkillRectTransform13 != null)
			{
				_oSkillRectTransform13.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition14
	{
		get
		{
			if (_oSkillRectTransform14 != null)
			{
				return _oSkillRectTransform14.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition14 != value && _oSkillRectTransform14 != null)
			{
				_oSkillRectTransform14.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition15
	{
		get
		{
			if (_oSkillRectTransform15 != null)
			{
				return _oSkillRectTransform15.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition15 != value && _oSkillRectTransform15 != null)
			{
				_oSkillRectTransform15.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition16
	{
		get
		{
			if (_oSkillRectTransform16 != null)
			{
				return _oSkillRectTransform16.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition16 != value && _oSkillRectTransform16 != null)
			{
				_oSkillRectTransform16.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition17
	{
		get
		{
			if (_oSkillRectTransform17 != null)
			{
				return _oSkillRectTransform17.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition17 != value && _oSkillRectTransform17 != null)
			{
				_oSkillRectTransform17.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition18
	{
		get
		{
			if (_oSkillRectTransform18 != null)
			{
				return _oSkillRectTransform18.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition18 != value && _oSkillRectTransform18 != null)
			{
				_oSkillRectTransform18.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition19
	{
		get
		{
			if (_oSkillRectTransform19 != null)
			{
				return _oSkillRectTransform19.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition19 != value && _oSkillRectTransform19 != null)
			{
				_oSkillRectTransform19.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition20
	{
		get
		{
			if (_oSkillRectTransform20 != null)
			{
				return _oSkillRectTransform20.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition20 != value && _oSkillRectTransform20 != null)
			{
				_oSkillRectTransform20.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition21
	{
		get
		{
			if (_oSkillRectTransform21 != null)
			{
				return _oSkillRectTransform21.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition21 != value && _oSkillRectTransform21 != null)
			{
				_oSkillRectTransform21.localPosition = value;
			}
		}
	}

	public Vector3 SkillPosition22
	{
		get
		{
			if (_oSkillRectTransform22 != null)
			{
				return _oSkillRectTransform22.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillPosition22 != value && _oSkillRectTransform22 != null)
			{
				_oSkillRectTransform22.localPosition = value;
			}
		}
	}

	public bool SkillEnabled1
	{
		get
		{
			if (_oSkillImage1 != null)
			{
				return _oSkillImage1.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled1 != value && _oSkillImage1 != null)
			{
				_oSkillImage1.enabled = value;
			}
		}
	}

	public bool SkillEnabled2
	{
		get
		{
			if (_oSkillImage2 != null)
			{
				return _oSkillImage2.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled2 != value && _oSkillImage2 != null)
			{
				_oSkillImage2.enabled = value;
			}
		}
	}

	public bool SkillEnabled3
	{
		get
		{
			if (_oSkillImage3 != null)
			{
				return _oSkillImage3.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled3 != value && _oSkillImage3 != null)
			{
				_oSkillImage3.enabled = value;
			}
		}
	}

	public bool SkillEnabled4
	{
		get
		{
			if (_oSkillImage4 != null)
			{
				return _oSkillImage4.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled4 != value && _oSkillImage4 != null)
			{
				_oSkillImage4.enabled = value;
			}
		}
	}

	public bool SkillEnabled5
	{
		get
		{
			if (_oSkillImage5 != null)
			{
				return _oSkillImage5.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled5 != value && _oSkillImage5 != null)
			{
				_oSkillImage5.enabled = value;
			}
		}
	}

	public bool SkillEnabled6
	{
		get
		{
			if (_oSkillImage6 != null)
			{
				return _oSkillImage6.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled6 != value && _oSkillImage6 != null)
			{
				_oSkillImage6.enabled = value;
			}
		}
	}

	public bool SkillEnabled7
	{
		get
		{
			if (_oSkillImage7 != null)
			{
				return _oSkillImage7.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled7 != value && _oSkillImage7 != null)
			{
				_oSkillImage7.enabled = value;
			}
		}
	}

	public bool SkillEnabled8
	{
		get
		{
			if (_oSkillImage8 != null)
			{
				return _oSkillImage8.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled8 != value && _oSkillImage8 != null)
			{
				_oSkillImage8.enabled = value;
			}
		}
	}

	public bool SkillEnabled9
	{
		get
		{
			if (_oSkillImage9 != null)
			{
				return _oSkillImage9.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled9 != value && _oSkillImage9 != null)
			{
				_oSkillImage9.enabled = value;
			}
		}
	}

	public bool SkillEnabled10
	{
		get
		{
			if (_oSkillImage10 != null)
			{
				return _oSkillImage10.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled10 != value && _oSkillImage10 != null)
			{
				_oSkillImage10.enabled = value;
			}
		}
	}

	public bool SkillEnabled11
	{
		get
		{
			if (_oSkillImage11 != null)
			{
				return _oSkillImage11.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled11 != value && _oSkillImage11 != null)
			{
				_oSkillImage11.enabled = value;
			}
		}
	}

	public bool SkillEnabled12
	{
		get
		{
			if (_oSkillImage12 != null)
			{
				return _oSkillImage12.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled12 != value && _oSkillImage12 != null)
			{
				_oSkillImage12.enabled = value;
			}
		}
	}

	public bool SkillEnabled13
	{
		get
		{
			if (_oSkillImage13 != null)
			{
				return _oSkillImage13.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled13 != value && _oSkillImage13 != null)
			{
				_oSkillImage13.enabled = value;
			}
		}
	}

	public bool SkillEnabled14
	{
		get
		{
			if (_oSkillImage14 != null)
			{
				return _oSkillImage14.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled14 != value && _oSkillImage14 != null)
			{
				_oSkillImage14.enabled = value;
			}
		}
	}

	public bool SkillEnabled15
	{
		get
		{
			if (_oSkillImage15 != null)
			{
				return _oSkillImage15.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled15 != value && _oSkillImage15 != null)
			{
				_oSkillImage15.enabled = value;
			}
		}
	}

	public bool SkillEnabled16
	{
		get
		{
			if (_oSkillImage16 != null)
			{
				return _oSkillImage16.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled16 != value && _oSkillImage16 != null)
			{
				_oSkillImage16.enabled = value;
			}
		}
	}

	public bool SkillEnabled17
	{
		get
		{
			if (_oSkillImage17 != null)
			{
				return _oSkillImage17.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled17 != value && _oSkillImage17 != null)
			{
				_oSkillImage17.enabled = value;
			}
		}
	}

	public bool SkillEnabled18
	{
		get
		{
			if (_oSkillImage18 != null)
			{
				return _oSkillImage18.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled18 != value && _oSkillImage18 != null)
			{
				_oSkillImage18.enabled = value;
			}
		}
	}

	public bool SkillEnabled19
	{
		get
		{
			if (_oSkillImage19 != null)
			{
				return _oSkillImage19.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled19 != value && _oSkillImage19 != null)
			{
				_oSkillImage19.enabled = value;
			}
		}
	}

	public bool SkillEnabled20
	{
		get
		{
			if (_oSkillImage20 != null)
			{
				return _oSkillImage20.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled20 != value && _oSkillImage20 != null)
			{
				_oSkillImage20.enabled = value;
			}
		}
	}

	public bool SkillEnabled21
	{
		get
		{
			if (_oSkillImage21 != null)
			{
				return _oSkillImage21.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled21 != value && _oSkillImage21 != null)
			{
				_oSkillImage21.enabled = value;
			}
		}
	}

	public bool SkillEnabled22
	{
		get
		{
			if (_oSkillImage22 != null)
			{
				return _oSkillImage22.enabled;
			}
			return false;
		}
		set
		{
			if (SkillEnabled22 != value && _oSkillImage22 != null)
			{
				_oSkillImage22.enabled = value;
			}
		}
	}

	public Color SkillColor1
	{
		get
		{
			if (_oSkillImage1 != null)
			{
				return _oSkillImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor1 != value && _oSkillImage1 != null)
			{
				_oSkillImage1.color = value;
			}
		}
	}

	public Color SkillColor2
	{
		get
		{
			if (_oSkillImage2 != null)
			{
				return _oSkillImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor2 != value && _oSkillImage2 != null)
			{
				_oSkillImage2.color = value;
			}
		}
	}

	public Color SkillColor3
	{
		get
		{
			if (_oSkillImage3 != null)
			{
				return _oSkillImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor3 != value && _oSkillImage3 != null)
			{
				_oSkillImage3.color = value;
			}
		}
	}

	public Color SkillColor4
	{
		get
		{
			if (_oSkillImage4 != null)
			{
				return _oSkillImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor4 != value && _oSkillImage4 != null)
			{
				_oSkillImage4.color = value;
			}
		}
	}

	public Color SkillColor5
	{
		get
		{
			if (_oSkillImage5 != null)
			{
				return _oSkillImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor5 != value && _oSkillImage5 != null)
			{
				_oSkillImage5.color = value;
			}
		}
	}

	public Color SkillColor6
	{
		get
		{
			if (_oSkillImage6 != null)
			{
				return _oSkillImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor6 != value && _oSkillImage6 != null)
			{
				_oSkillImage6.color = value;
			}
		}
	}

	public Color SkillColor7
	{
		get
		{
			if (_oSkillImage7 != null)
			{
				return _oSkillImage7.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor7 != value && _oSkillImage7 != null)
			{
				_oSkillImage7.color = value;
			}
		}
	}

	public Color SkillColor8
	{
		get
		{
			if (_oSkillImage8 != null)
			{
				return _oSkillImage8.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor8 != value && _oSkillImage8 != null)
			{
				_oSkillImage8.color = value;
			}
		}
	}

	public Color SkillColor9
	{
		get
		{
			if (_oSkillImage9 != null)
			{
				return _oSkillImage9.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor9 != value && _oSkillImage9 != null)
			{
				_oSkillImage9.color = value;
			}
		}
	}

	public Color SkillColor10
	{
		get
		{
			if (_oSkillImage10 != null)
			{
				return _oSkillImage10.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor10 != value && _oSkillImage10 != null)
			{
				_oSkillImage10.color = value;
			}
		}
	}

	public Color SkillColor11
	{
		get
		{
			if (_oSkillImage11 != null)
			{
				return _oSkillImage11.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor11 != value && _oSkillImage11 != null)
			{
				_oSkillImage11.color = value;
			}
		}
	}

	public Color SkillColor12
	{
		get
		{
			if (_oSkillImage12 != null)
			{
				return _oSkillImage12.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor12 != value && _oSkillImage12 != null)
			{
				_oSkillImage12.color = value;
			}
		}
	}

	public Color SkillColor13
	{
		get
		{
			if (_oSkillImage13 != null)
			{
				return _oSkillImage13.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor13 != value && _oSkillImage13 != null)
			{
				_oSkillImage13.color = value;
			}
		}
	}

	public Color SkillColor14
	{
		get
		{
			if (_oSkillImage14 != null)
			{
				return _oSkillImage14.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor14 != value && _oSkillImage14 != null)
			{
				_oSkillImage14.color = value;
			}
		}
	}

	public Color SkillColor15
	{
		get
		{
			if (_oSkillImage15 != null)
			{
				return _oSkillImage15.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor15 != value && _oSkillImage15 != null)
			{
				_oSkillImage15.color = value;
			}
		}
	}

	public Color SkillColor16
	{
		get
		{
			if (_oSkillImage16 != null)
			{
				return _oSkillImage16.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor16 != value && _oSkillImage16 != null)
			{
				_oSkillImage16.color = value;
			}
		}
	}

	public Color SkillColor17
	{
		get
		{
			if (_oSkillImage17 != null)
			{
				return _oSkillImage17.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor17 != value && _oSkillImage17 != null)
			{
				_oSkillImage17.color = value;
			}
		}
	}

	public Color SkillColor18
	{
		get
		{
			if (_oSkillImage18 != null)
			{
				return _oSkillImage18.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor18 != value && _oSkillImage18 != null)
			{
				_oSkillImage18.color = value;
			}
		}
	}

	public Color SkillColor19
	{
		get
		{
			if (_oSkillImage19 != null)
			{
				return _oSkillImage19.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor19 != value && _oSkillImage19 != null)
			{
				_oSkillImage19.color = value;
			}
		}
	}

	public Color SkillColor20
	{
		get
		{
			if (_oSkillImage20 != null)
			{
				return _oSkillImage20.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor20 != value && _oSkillImage20 != null)
			{
				_oSkillImage20.color = value;
			}
		}
	}

	public Color SkillColor21
	{
		get
		{
			if (_oSkillImage21 != null)
			{
				return _oSkillImage21.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor21 != value && _oSkillImage21 != null)
			{
				_oSkillImage21.color = value;
			}
		}
	}

	public Color SkillColor22
	{
		get
		{
			if (_oSkillImage22 != null)
			{
				return _oSkillImage22.color;
			}
			return Color.white;
		}
		set
		{
			if (SkillColor22 != value && _oSkillImage22 != null)
			{
				_oSkillImage22.color = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers1
	{
		get
		{
			if (_oSkillEventTrigger1 != null)
			{
				return _oSkillEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers1 != value && _oSkillEventTrigger1 != null)
			{
				_oSkillEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers2
	{
		get
		{
			if (_oSkillEventTrigger2 != null)
			{
				return _oSkillEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers2 != value && _oSkillEventTrigger2 != null)
			{
				_oSkillEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers3
	{
		get
		{
			if (_oSkillEventTrigger3 != null)
			{
				return _oSkillEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers3 != value && _oSkillEventTrigger3 != null)
			{
				_oSkillEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers4
	{
		get
		{
			if (_oSkillEventTrigger4 != null)
			{
				return _oSkillEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers4 != value && _oSkillEventTrigger4 != null)
			{
				_oSkillEventTrigger4.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers5
	{
		get
		{
			if (_oSkillEventTrigger5 != null)
			{
				return _oSkillEventTrigger5.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers5 != value && _oSkillEventTrigger5 != null)
			{
				_oSkillEventTrigger5.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers6
	{
		get
		{
			if (_oSkillEventTrigger6 != null)
			{
				return _oSkillEventTrigger6.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers6 != value && _oSkillEventTrigger6 != null)
			{
				_oSkillEventTrigger6.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers7
	{
		get
		{
			if (_oSkillEventTrigger7 != null)
			{
				return _oSkillEventTrigger7.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers7 != value && _oSkillEventTrigger7 != null)
			{
				_oSkillEventTrigger7.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers8
	{
		get
		{
			if (_oSkillEventTrigger8 != null)
			{
				return _oSkillEventTrigger8.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers8 != value && _oSkillEventTrigger8 != null)
			{
				_oSkillEventTrigger8.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers9
	{
		get
		{
			if (_oSkillEventTrigger9 != null)
			{
				return _oSkillEventTrigger9.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers9 != value && _oSkillEventTrigger9 != null)
			{
				_oSkillEventTrigger9.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers10
	{
		get
		{
			if (_oSkillEventTrigger10 != null)
			{
				return _oSkillEventTrigger10.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers10 != value && _oSkillEventTrigger10 != null)
			{
				_oSkillEventTrigger10.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers11
	{
		get
		{
			if (_oSkillEventTrigger11 != null)
			{
				return _oSkillEventTrigger11.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers11 != value && _oSkillEventTrigger11 != null)
			{
				_oSkillEventTrigger11.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers12
	{
		get
		{
			if (_oSkillEventTrigger12 != null)
			{
				return _oSkillEventTrigger12.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers12 != value && _oSkillEventTrigger12 != null)
			{
				_oSkillEventTrigger12.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers13
	{
		get
		{
			if (_oSkillEventTrigger13 != null)
			{
				return _oSkillEventTrigger13.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers13 != value && _oSkillEventTrigger13 != null)
			{
				_oSkillEventTrigger13.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers14
	{
		get
		{
			if (_oSkillEventTrigger14 != null)
			{
				return _oSkillEventTrigger14.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers14 != value && _oSkillEventTrigger14 != null)
			{
				_oSkillEventTrigger14.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers15
	{
		get
		{
			if (_oSkillEventTrigger15 != null)
			{
				return _oSkillEventTrigger15.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers15 != value && _oSkillEventTrigger15 != null)
			{
				_oSkillEventTrigger15.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers16
	{
		get
		{
			if (_oSkillEventTrigger16 != null)
			{
				return _oSkillEventTrigger16.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers16 != value && _oSkillEventTrigger16 != null)
			{
				_oSkillEventTrigger16.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers17
	{
		get
		{
			if (_oSkillEventTrigger17 != null)
			{
				return _oSkillEventTrigger17.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers17 != value && _oSkillEventTrigger17 != null)
			{
				_oSkillEventTrigger17.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers18
	{
		get
		{
			if (_oSkillEventTrigger18 != null)
			{
				return _oSkillEventTrigger18.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers18 != value && _oSkillEventTrigger18 != null)
			{
				_oSkillEventTrigger18.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers19
	{
		get
		{
			if (_oSkillEventTrigger19 != null)
			{
				return _oSkillEventTrigger19.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers19 != value && _oSkillEventTrigger19 != null)
			{
				_oSkillEventTrigger19.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers20
	{
		get
		{
			if (_oSkillEventTrigger20 != null)
			{
				return _oSkillEventTrigger20.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers20 != value && _oSkillEventTrigger20 != null)
			{
				_oSkillEventTrigger20.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers21
	{
		get
		{
			if (_oSkillEventTrigger21 != null)
			{
				return _oSkillEventTrigger21.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers21 != value && _oSkillEventTrigger21 != null)
			{
				_oSkillEventTrigger21.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> SkillTriggers22
	{
		get
		{
			if (_oSkillEventTrigger22 != null)
			{
				return _oSkillEventTrigger22.triggers;
			}
			return null;
		}
		set
		{
			if (SkillTriggers22 != value && _oSkillEventTrigger22 != null)
			{
				_oSkillEventTrigger22.triggers = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked1
	{
		get
		{
			if (_oSkillButton1 != null)
			{
				return _oSkillButton1.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked1 != value && _oSkillButton1 != null)
			{
				_oSkillButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked2
	{
		get
		{
			if (_oSkillButton2 != null)
			{
				return _oSkillButton2.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked2 != value && _oSkillButton2 != null)
			{
				_oSkillButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked3
	{
		get
		{
			if (_oSkillButton3 != null)
			{
				return _oSkillButton3.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked3 != value && _oSkillButton3 != null)
			{
				_oSkillButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked4
	{
		get
		{
			if (_oSkillButton4 != null)
			{
				return _oSkillButton4.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked4 != value && _oSkillButton4 != null)
			{
				_oSkillButton4.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked5
	{
		get
		{
			if (_oSkillButton5 != null)
			{
				return _oSkillButton5.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked5 != value && _oSkillButton5 != null)
			{
				_oSkillButton5.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked6
	{
		get
		{
			if (_oSkillButton6 != null)
			{
				return _oSkillButton6.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked6 != value && _oSkillButton6 != null)
			{
				_oSkillButton6.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked7
	{
		get
		{
			if (_oSkillButton7 != null)
			{
				return _oSkillButton7.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked7 != value && _oSkillButton7 != null)
			{
				_oSkillButton7.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked8
	{
		get
		{
			if (_oSkillButton8 != null)
			{
				return _oSkillButton8.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked8 != value && _oSkillButton8 != null)
			{
				_oSkillButton8.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked9
	{
		get
		{
			if (_oSkillButton9 != null)
			{
				return _oSkillButton9.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked9 != value && _oSkillButton9 != null)
			{
				_oSkillButton9.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked10
	{
		get
		{
			if (_oSkillButton10 != null)
			{
				return _oSkillButton10.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked10 != value && _oSkillButton10 != null)
			{
				_oSkillButton10.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked11
	{
		get
		{
			if (_oSkillButton11 != null)
			{
				return _oSkillButton11.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked11 != value && _oSkillButton11 != null)
			{
				_oSkillButton11.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked12
	{
		get
		{
			if (_oSkillButton12 != null)
			{
				return _oSkillButton12.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked12 != value && _oSkillButton12 != null)
			{
				_oSkillButton12.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked13
	{
		get
		{
			if (_oSkillButton13 != null)
			{
				return _oSkillButton13.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked13 != value && _oSkillButton13 != null)
			{
				_oSkillButton13.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked14
	{
		get
		{
			if (_oSkillButton14 != null)
			{
				return _oSkillButton14.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked14 != value && _oSkillButton14 != null)
			{
				_oSkillButton14.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked15
	{
		get
		{
			if (_oSkillButton15 != null)
			{
				return _oSkillButton15.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked15 != value && _oSkillButton15 != null)
			{
				_oSkillButton15.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked16
	{
		get
		{
			if (_oSkillButton16 != null)
			{
				return _oSkillButton16.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked16 != value && _oSkillButton16 != null)
			{
				_oSkillButton16.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked17
	{
		get
		{
			if (_oSkillButton17 != null)
			{
				return _oSkillButton17.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked17 != value && _oSkillButton17 != null)
			{
				_oSkillButton17.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked18
	{
		get
		{
			if (_oSkillButton18 != null)
			{
				return _oSkillButton18.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked18 != value && _oSkillButton18 != null)
			{
				_oSkillButton18.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked19
	{
		get
		{
			if (_oSkillButton19 != null)
			{
				return _oSkillButton19.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked19 != value && _oSkillButton19 != null)
			{
				_oSkillButton19.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked20
	{
		get
		{
			if (_oSkillButton20 != null)
			{
				return _oSkillButton20.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked20 != value && _oSkillButton20 != null)
			{
				_oSkillButton20.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked21
	{
		get
		{
			if (_oSkillButton21 != null)
			{
				return _oSkillButton21.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked21 != value && _oSkillButton21 != null)
			{
				_oSkillButton21.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent SkillClicked22
	{
		get
		{
			if (_oSkillButton22 != null)
			{
				return _oSkillButton22.onClick;
			}
			return null;
		}
		set
		{
			if (SkillClicked22 != value && _oSkillButton22 != null)
			{
				_oSkillButton22.onClick = value;
			}
		}
	}

	public bool SkillButtonable1
	{
		get
		{
			if (_oSkillButton1 != null)
			{
				return _oSkillButton1.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable1 != value && _oSkillButton1 != null)
			{
				_oSkillButton1.interactable = value;
			}
		}
	}

	public bool SkillButtonable2
	{
		get
		{
			if (_oSkillButton2 != null)
			{
				return _oSkillButton2.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable2 != value && _oSkillButton2 != null)
			{
				_oSkillButton2.interactable = value;
			}
		}
	}

	public bool SkillButtonable3
	{
		get
		{
			if (_oSkillButton3 != null)
			{
				return _oSkillButton3.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable3 != value && _oSkillButton3 != null)
			{
				_oSkillButton3.interactable = value;
			}
		}
	}

	public bool SkillButtonable4
	{
		get
		{
			if (_oSkillButton4 != null)
			{
				return _oSkillButton4.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable4 != value && _oSkillButton4 != null)
			{
				_oSkillButton4.interactable = value;
			}
		}
	}

	public bool SkillButtonable5
	{
		get
		{
			if (_oSkillButton5 != null)
			{
				return _oSkillButton5.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable5 != value && _oSkillButton5 != null)
			{
				_oSkillButton5.interactable = value;
			}
		}
	}

	public bool SkillButtonable6
	{
		get
		{
			if (_oSkillButton6 != null)
			{
				return _oSkillButton6.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable6 != value && _oSkillButton6 != null)
			{
				_oSkillButton6.interactable = value;
			}
		}
	}

	public bool SkillButtonable7
	{
		get
		{
			if (_oSkillButton7 != null)
			{
				return _oSkillButton7.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable7 != value && _oSkillButton7 != null)
			{
				_oSkillButton7.interactable = value;
			}
		}
	}

	public bool SkillButtonable8
	{
		get
		{
			if (_oSkillButton8 != null)
			{
				return _oSkillButton8.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable8 != value && _oSkillButton8 != null)
			{
				_oSkillButton8.interactable = value;
			}
		}
	}

	public bool SkillButtonable9
	{
		get
		{
			if (_oSkillButton9 != null)
			{
				return _oSkillButton9.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable9 != value && _oSkillButton9 != null)
			{
				_oSkillButton9.interactable = value;
			}
		}
	}

	public bool SkillButtonable10
	{
		get
		{
			if (_oSkillButton10 != null)
			{
				return _oSkillButton10.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable10 != value && _oSkillButton10 != null)
			{
				_oSkillButton10.interactable = value;
			}
		}
	}

	public bool SkillButtonable11
	{
		get
		{
			if (_oSkillButton11 != null)
			{
				return _oSkillButton11.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable11 != value && _oSkillButton11 != null)
			{
				_oSkillButton11.interactable = value;
			}
		}
	}

	public bool SkillButtonable12
	{
		get
		{
			if (_oSkillButton12 != null)
			{
				return _oSkillButton12.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable12 != value && _oSkillButton12 != null)
			{
				_oSkillButton12.interactable = value;
			}
		}
	}

	public bool SkillButtonable13
	{
		get
		{
			if (_oSkillButton13 != null)
			{
				return _oSkillButton13.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable13 != value && _oSkillButton13 != null)
			{
				_oSkillButton13.interactable = value;
			}
		}
	}

	public bool SkillButtonable14
	{
		get
		{
			if (_oSkillButton14 != null)
			{
				return _oSkillButton14.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable14 != value && _oSkillButton14 != null)
			{
				_oSkillButton14.interactable = value;
			}
		}
	}

	public bool SkillButtonable15
	{
		get
		{
			if (_oSkillButton15 != null)
			{
				return _oSkillButton15.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable15 != value && _oSkillButton15 != null)
			{
				_oSkillButton15.interactable = value;
			}
		}
	}

	public bool SkillButtonable16
	{
		get
		{
			if (_oSkillButton16 != null)
			{
				return _oSkillButton16.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable16 != value && _oSkillButton16 != null)
			{
				_oSkillButton16.interactable = value;
			}
		}
	}

	public bool SkillButtonable17
	{
		get
		{
			if (_oSkillButton17 != null)
			{
				return _oSkillButton17.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable17 != value && _oSkillButton17 != null)
			{
				_oSkillButton17.interactable = value;
			}
		}
	}

	public bool SkillButtonable18
	{
		get
		{
			if (_oSkillButton18 != null)
			{
				return _oSkillButton18.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable18 != value && _oSkillButton18 != null)
			{
				_oSkillButton18.interactable = value;
			}
		}
	}

	public bool SkillButtonable19
	{
		get
		{
			if (_oSkillButton19 != null)
			{
				return _oSkillButton19.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable19 != value && _oSkillButton19 != null)
			{
				_oSkillButton19.interactable = value;
			}
		}
	}

	public bool SkillButtonable20
	{
		get
		{
			if (_oSkillButton20 != null)
			{
				return _oSkillButton20.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable20 != value && _oSkillButton20 != null)
			{
				_oSkillButton20.interactable = value;
			}
		}
	}

	public bool SkillButtonable21
	{
		get
		{
			if (_oSkillButton21 != null)
			{
				return _oSkillButton21.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable21 != value && _oSkillButton21 != null)
			{
				_oSkillButton21.interactable = value;
			}
		}
	}

	public bool SkillButtonable22
	{
		get
		{
			if (_oSkillButton22 != null)
			{
				return _oSkillButton22.interactable;
			}
			return true;
		}
		set
		{
			if (SkillButtonable22 != value && _oSkillButton22 != null)
			{
				_oSkillButton22.interactable = value;
			}
		}
	}

	public GameObject SkillParentObj1 => _oSkillParent1;

	public GameObject SkillParentObj2 => _oSkillParent2;

	public GameObject SkillParentObj3 => _oSkillParent3;

	public bool SkillParentShow1
	{
		get
		{
			if (_oSkillParent1 != null)
			{
				return _oSkillParent1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillParentShow1 != value && _oSkillParent1 != null)
			{
				_oSkillParent1.SetObjectActive(value);
			}
		}
	}

	public bool SkillParentShow2
	{
		get
		{
			if (_oSkillParent2 != null)
			{
				return _oSkillParent2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillParentShow2 != value && _oSkillParent2 != null)
			{
				_oSkillParent2.SetObjectActive(value);
			}
		}
	}

	public bool SkillParentShow3
	{
		get
		{
			if (_oSkillParent3 != null)
			{
				return _oSkillParent3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillParentShow3 != value && _oSkillParent3 != null)
			{
				_oSkillParent3.SetObjectActive(value);
			}
		}
	}

	public Vector3 SkillParentPosition1
	{
		get
		{
			if (_oSkillParentRectTransform1 != null)
			{
				return _oSkillParentRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillParentPosition1 != value && _oSkillParentRectTransform1 != null)
			{
				_oSkillParentRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 SkillParentPosition2
	{
		get
		{
			if (_oSkillParentRectTransform2 != null)
			{
				return _oSkillParentRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillParentPosition2 != value && _oSkillParentRectTransform2 != null)
			{
				_oSkillParentRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 SkillParentPosition3
	{
		get
		{
			if (_oSkillParentRectTransform3 != null)
			{
				return _oSkillParentRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SkillParentPosition3 != value && _oSkillParentRectTransform3 != null)
			{
				_oSkillParentRectTransform3.localPosition = value;
			}
		}
	}

	public bool BuffShow1
	{
		get
		{
			if (_oBuff1 != null)
			{
				return _oBuff1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow1 != value && _oBuff1 != null)
			{
				_oBuff1.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow2
	{
		get
		{
			if (_oBuff2 != null)
			{
				return _oBuff2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow2 != value && _oBuff2 != null)
			{
				_oBuff2.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow3
	{
		get
		{
			if (_oBuff3 != null)
			{
				return _oBuff3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow3 != value && _oBuff3 != null)
			{
				_oBuff3.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow4
	{
		get
		{
			if (_oBuff4 != null)
			{
				return _oBuff4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow4 != value && _oBuff4 != null)
			{
				_oBuff4.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow5
	{
		get
		{
			if (_oBuff5 != null)
			{
				return _oBuff5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow5 != value && _oBuff5 != null)
			{
				_oBuff5.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow6
	{
		get
		{
			if (_oBuff6 != null)
			{
				return _oBuff6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow6 != value && _oBuff6 != null)
			{
				_oBuff6.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow7
	{
		get
		{
			if (_oBuff7 != null)
			{
				return _oBuff7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow7 != value && _oBuff7 != null)
			{
				_oBuff7.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow8
	{
		get
		{
			if (_oBuff8 != null)
			{
				return _oBuff8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow8 != value && _oBuff8 != null)
			{
				_oBuff8.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow9
	{
		get
		{
			if (_oBuff9 != null)
			{
				return _oBuff9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow9 != value && _oBuff9 != null)
			{
				_oBuff9.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow10
	{
		get
		{
			if (_oBuff10 != null)
			{
				return _oBuff10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow10 != value && _oBuff10 != null)
			{
				_oBuff10.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow11
	{
		get
		{
			if (_oBuff11 != null)
			{
				return _oBuff11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow11 != value && _oBuff11 != null)
			{
				_oBuff11.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow12
	{
		get
		{
			if (_oBuff12 != null)
			{
				return _oBuff12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow12 != value && _oBuff12 != null)
			{
				_oBuff12.SetObjectActive(value);
			}
		}
	}

	public Vector3 BuffPosition1
	{
		get
		{
			if (_oBuffRectTransform1 != null)
			{
				return _oBuffRectTransform1.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition1 != value && _oBuffRectTransform1 != null)
			{
				_oBuffRectTransform1.localPosition = value;
			}
		}
	}

	public Vector3 BuffPosition2
	{
		get
		{
			if (_oBuffRectTransform2 != null)
			{
				return _oBuffRectTransform2.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition2 != value && _oBuffRectTransform2 != null)
			{
				_oBuffRectTransform2.localPosition = value;
			}
		}
	}

	public Vector3 BuffPosition3
	{
		get
		{
			if (_oBuffRectTransform3 != null)
			{
				return _oBuffRectTransform3.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition3 != value && _oBuffRectTransform3 != null)
			{
				_oBuffRectTransform3.localPosition = value;
			}
		}
	}

	public Vector3 BuffPosition4
	{
		get
		{
			if (_oBuffRectTransform4 != null)
			{
				return _oBuffRectTransform4.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition4 != value && _oBuffRectTransform4 != null)
			{
				_oBuffRectTransform4.localPosition = value;
			}
		}
	}

	public Vector3 BuffPosition5
	{
		get
		{
			if (_oBuffRectTransform5 != null)
			{
				return _oBuffRectTransform5.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition5 != value && _oBuffRectTransform5 != null)
			{
				_oBuffRectTransform5.localPosition = value;
			}
		}
	}

	public Vector3 BuffPosition6
	{
		get
		{
			if (_oBuffRectTransform6 != null)
			{
				return _oBuffRectTransform6.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition6 != value && _oBuffRectTransform6 != null)
			{
				_oBuffRectTransform6.localPosition = value;
			}
		}
	}

	public Vector3 BuffPosition7
	{
		get
		{
			if (_oBuffRectTransform7 != null)
			{
				return _oBuffRectTransform7.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition7 != value && _oBuffRectTransform7 != null)
			{
				_oBuffRectTransform7.localPosition = value;
			}
		}
	}

	public Vector3 BuffPosition8
	{
		get
		{
			if (_oBuffRectTransform8 != null)
			{
				return _oBuffRectTransform8.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition8 != value && _oBuffRectTransform8 != null)
			{
				_oBuffRectTransform8.localPosition = value;
			}
		}
	}

	public Vector3 BuffPosition9
	{
		get
		{
			if (_oBuffRectTransform9 != null)
			{
				return _oBuffRectTransform9.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition9 != value && _oBuffRectTransform9 != null)
			{
				_oBuffRectTransform9.localPosition = value;
			}
		}
	}

	public Vector3 BuffPosition10
	{
		get
		{
			if (_oBuffRectTransform10 != null)
			{
				return _oBuffRectTransform10.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition10 != value && _oBuffRectTransform10 != null)
			{
				_oBuffRectTransform10.localPosition = value;
			}
		}
	}

	public Vector3 BuffPosition11
	{
		get
		{
			if (_oBuffRectTransform11 != null)
			{
				return _oBuffRectTransform11.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition11 != value && _oBuffRectTransform11 != null)
			{
				_oBuffRectTransform11.localPosition = value;
			}
		}
	}

	public Vector3 BuffPosition12
	{
		get
		{
			if (_oBuffRectTransform12 != null)
			{
				return _oBuffRectTransform12.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition12 != value && _oBuffRectTransform12 != null)
			{
				_oBuffRectTransform12.localPosition = value;
			}
		}
	}

	public bool BuffEnabled1
	{
		get
		{
			if (_oBuffImage1 != null)
			{
				return _oBuffImage1.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled1 != value && _oBuffImage1 != null)
			{
				_oBuffImage1.enabled = value;
			}
		}
	}

	public bool BuffEnabled2
	{
		get
		{
			if (_oBuffImage2 != null)
			{
				return _oBuffImage2.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled2 != value && _oBuffImage2 != null)
			{
				_oBuffImage2.enabled = value;
			}
		}
	}

	public bool BuffEnabled3
	{
		get
		{
			if (_oBuffImage3 != null)
			{
				return _oBuffImage3.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled3 != value && _oBuffImage3 != null)
			{
				_oBuffImage3.enabled = value;
			}
		}
	}

	public bool BuffEnabled4
	{
		get
		{
			if (_oBuffImage4 != null)
			{
				return _oBuffImage4.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled4 != value && _oBuffImage4 != null)
			{
				_oBuffImage4.enabled = value;
			}
		}
	}

	public bool BuffEnabled5
	{
		get
		{
			if (_oBuffImage5 != null)
			{
				return _oBuffImage5.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled5 != value && _oBuffImage5 != null)
			{
				_oBuffImage5.enabled = value;
			}
		}
	}

	public bool BuffEnabled6
	{
		get
		{
			if (_oBuffImage6 != null)
			{
				return _oBuffImage6.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled6 != value && _oBuffImage6 != null)
			{
				_oBuffImage6.enabled = value;
			}
		}
	}

	public bool BuffEnabled7
	{
		get
		{
			if (_oBuffImage7 != null)
			{
				return _oBuffImage7.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled7 != value && _oBuffImage7 != null)
			{
				_oBuffImage7.enabled = value;
			}
		}
	}

	public bool BuffEnabled8
	{
		get
		{
			if (_oBuffImage8 != null)
			{
				return _oBuffImage8.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled8 != value && _oBuffImage8 != null)
			{
				_oBuffImage8.enabled = value;
			}
		}
	}

	public bool BuffEnabled9
	{
		get
		{
			if (_oBuffImage9 != null)
			{
				return _oBuffImage9.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled9 != value && _oBuffImage9 != null)
			{
				_oBuffImage9.enabled = value;
			}
		}
	}

	public bool BuffEnabled10
	{
		get
		{
			if (_oBuffImage10 != null)
			{
				return _oBuffImage10.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled10 != value && _oBuffImage10 != null)
			{
				_oBuffImage10.enabled = value;
			}
		}
	}

	public bool BuffEnabled11
	{
		get
		{
			if (_oBuffImage11 != null)
			{
				return _oBuffImage11.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled11 != value && _oBuffImage11 != null)
			{
				_oBuffImage11.enabled = value;
			}
		}
	}

	public bool BuffEnabled12
	{
		get
		{
			if (_oBuffImage12 != null)
			{
				return _oBuffImage12.enabled;
			}
			return false;
		}
		set
		{
			if (BuffEnabled12 != value && _oBuffImage12 != null)
			{
				_oBuffImage12.enabled = value;
			}
		}
	}

	public Color BuffColor1
	{
		get
		{
			if (_oBuffImage1 != null)
			{
				return _oBuffImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor1 != value && _oBuffImage1 != null)
			{
				_oBuffImage1.color = value;
			}
		}
	}

	public Color BuffColor2
	{
		get
		{
			if (_oBuffImage2 != null)
			{
				return _oBuffImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor2 != value && _oBuffImage2 != null)
			{
				_oBuffImage2.color = value;
			}
		}
	}

	public Color BuffColor3
	{
		get
		{
			if (_oBuffImage3 != null)
			{
				return _oBuffImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor3 != value && _oBuffImage3 != null)
			{
				_oBuffImage3.color = value;
			}
		}
	}

	public Color BuffColor4
	{
		get
		{
			if (_oBuffImage4 != null)
			{
				return _oBuffImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor4 != value && _oBuffImage4 != null)
			{
				_oBuffImage4.color = value;
			}
		}
	}

	public Color BuffColor5
	{
		get
		{
			if (_oBuffImage5 != null)
			{
				return _oBuffImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor5 != value && _oBuffImage5 != null)
			{
				_oBuffImage5.color = value;
			}
		}
	}

	public Color BuffColor6
	{
		get
		{
			if (_oBuffImage6 != null)
			{
				return _oBuffImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor6 != value && _oBuffImage6 != null)
			{
				_oBuffImage6.color = value;
			}
		}
	}

	public Color BuffColor7
	{
		get
		{
			if (_oBuffImage7 != null)
			{
				return _oBuffImage7.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor7 != value && _oBuffImage7 != null)
			{
				_oBuffImage7.color = value;
			}
		}
	}

	public Color BuffColor8
	{
		get
		{
			if (_oBuffImage8 != null)
			{
				return _oBuffImage8.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor8 != value && _oBuffImage8 != null)
			{
				_oBuffImage8.color = value;
			}
		}
	}

	public Color BuffColor9
	{
		get
		{
			if (_oBuffImage9 != null)
			{
				return _oBuffImage9.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor9 != value && _oBuffImage9 != null)
			{
				_oBuffImage9.color = value;
			}
		}
	}

	public Color BuffColor10
	{
		get
		{
			if (_oBuffImage10 != null)
			{
				return _oBuffImage10.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor10 != value && _oBuffImage10 != null)
			{
				_oBuffImage10.color = value;
			}
		}
	}

	public Color BuffColor11
	{
		get
		{
			if (_oBuffImage11 != null)
			{
				return _oBuffImage11.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor11 != value && _oBuffImage11 != null)
			{
				_oBuffImage11.color = value;
			}
		}
	}

	public Color BuffColor12
	{
		get
		{
			if (_oBuffImage12 != null)
			{
				return _oBuffImage12.color;
			}
			return Color.white;
		}
		set
		{
			if (BuffColor12 != value && _oBuffImage12 != null)
			{
				_oBuffImage12.color = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers1
	{
		get
		{
			if (_oBuffEventTrigger1 != null)
			{
				return _oBuffEventTrigger1.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers1 != value && _oBuffEventTrigger1 != null)
			{
				_oBuffEventTrigger1.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers2
	{
		get
		{
			if (_oBuffEventTrigger2 != null)
			{
				return _oBuffEventTrigger2.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers2 != value && _oBuffEventTrigger2 != null)
			{
				_oBuffEventTrigger2.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers3
	{
		get
		{
			if (_oBuffEventTrigger3 != null)
			{
				return _oBuffEventTrigger3.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers3 != value && _oBuffEventTrigger3 != null)
			{
				_oBuffEventTrigger3.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers4
	{
		get
		{
			if (_oBuffEventTrigger4 != null)
			{
				return _oBuffEventTrigger4.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers4 != value && _oBuffEventTrigger4 != null)
			{
				_oBuffEventTrigger4.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers5
	{
		get
		{
			if (_oBuffEventTrigger5 != null)
			{
				return _oBuffEventTrigger5.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers5 != value && _oBuffEventTrigger5 != null)
			{
				_oBuffEventTrigger5.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers6
	{
		get
		{
			if (_oBuffEventTrigger6 != null)
			{
				return _oBuffEventTrigger6.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers6 != value && _oBuffEventTrigger6 != null)
			{
				_oBuffEventTrigger6.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers7
	{
		get
		{
			if (_oBuffEventTrigger7 != null)
			{
				return _oBuffEventTrigger7.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers7 != value && _oBuffEventTrigger7 != null)
			{
				_oBuffEventTrigger7.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers8
	{
		get
		{
			if (_oBuffEventTrigger8 != null)
			{
				return _oBuffEventTrigger8.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers8 != value && _oBuffEventTrigger8 != null)
			{
				_oBuffEventTrigger8.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers9
	{
		get
		{
			if (_oBuffEventTrigger9 != null)
			{
				return _oBuffEventTrigger9.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers9 != value && _oBuffEventTrigger9 != null)
			{
				_oBuffEventTrigger9.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers10
	{
		get
		{
			if (_oBuffEventTrigger10 != null)
			{
				return _oBuffEventTrigger10.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers10 != value && _oBuffEventTrigger10 != null)
			{
				_oBuffEventTrigger10.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers11
	{
		get
		{
			if (_oBuffEventTrigger11 != null)
			{
				return _oBuffEventTrigger11.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers11 != value && _oBuffEventTrigger11 != null)
			{
				_oBuffEventTrigger11.triggers = value;
			}
		}
	}

	public List<EventTrigger.Entry> BuffTriggers12
	{
		get
		{
			if (_oBuffEventTrigger12 != null)
			{
				return _oBuffEventTrigger12.triggers;
			}
			return null;
		}
		set
		{
			if (BuffTriggers12 != value && _oBuffEventTrigger12 != null)
			{
				_oBuffEventTrigger12.triggers = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked1
	{
		get
		{
			if (_oBuffButton1 != null)
			{
				return _oBuffButton1.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked1 != value && _oBuffButton1 != null)
			{
				_oBuffButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked2
	{
		get
		{
			if (_oBuffButton2 != null)
			{
				return _oBuffButton2.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked2 != value && _oBuffButton2 != null)
			{
				_oBuffButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked3
	{
		get
		{
			if (_oBuffButton3 != null)
			{
				return _oBuffButton3.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked3 != value && _oBuffButton3 != null)
			{
				_oBuffButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked4
	{
		get
		{
			if (_oBuffButton4 != null)
			{
				return _oBuffButton4.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked4 != value && _oBuffButton4 != null)
			{
				_oBuffButton4.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked5
	{
		get
		{
			if (_oBuffButton5 != null)
			{
				return _oBuffButton5.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked5 != value && _oBuffButton5 != null)
			{
				_oBuffButton5.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked6
	{
		get
		{
			if (_oBuffButton6 != null)
			{
				return _oBuffButton6.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked6 != value && _oBuffButton6 != null)
			{
				_oBuffButton6.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked7
	{
		get
		{
			if (_oBuffButton7 != null)
			{
				return _oBuffButton7.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked7 != value && _oBuffButton7 != null)
			{
				_oBuffButton7.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked8
	{
		get
		{
			if (_oBuffButton8 != null)
			{
				return _oBuffButton8.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked8 != value && _oBuffButton8 != null)
			{
				_oBuffButton8.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked9
	{
		get
		{
			if (_oBuffButton9 != null)
			{
				return _oBuffButton9.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked9 != value && _oBuffButton9 != null)
			{
				_oBuffButton9.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked10
	{
		get
		{
			if (_oBuffButton10 != null)
			{
				return _oBuffButton10.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked10 != value && _oBuffButton10 != null)
			{
				_oBuffButton10.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked11
	{
		get
		{
			if (_oBuffButton11 != null)
			{
				return _oBuffButton11.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked11 != value && _oBuffButton11 != null)
			{
				_oBuffButton11.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent BuffClicked12
	{
		get
		{
			if (_oBuffButton12 != null)
			{
				return _oBuffButton12.onClick;
			}
			return null;
		}
		set
		{
			if (BuffClicked12 != value && _oBuffButton12 != null)
			{
				_oBuffButton12.onClick = value;
			}
		}
	}

	public bool BuffButtonable1
	{
		get
		{
			if (_oBuffButton1 != null)
			{
				return _oBuffButton1.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable1 != value && _oBuffButton1 != null)
			{
				_oBuffButton1.interactable = value;
			}
		}
	}

	public bool BuffButtonable2
	{
		get
		{
			if (_oBuffButton2 != null)
			{
				return _oBuffButton2.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable2 != value && _oBuffButton2 != null)
			{
				_oBuffButton2.interactable = value;
			}
		}
	}

	public bool BuffButtonable3
	{
		get
		{
			if (_oBuffButton3 != null)
			{
				return _oBuffButton3.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable3 != value && _oBuffButton3 != null)
			{
				_oBuffButton3.interactable = value;
			}
		}
	}

	public bool BuffButtonable4
	{
		get
		{
			if (_oBuffButton4 != null)
			{
				return _oBuffButton4.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable4 != value && _oBuffButton4 != null)
			{
				_oBuffButton4.interactable = value;
			}
		}
	}

	public bool BuffButtonable5
	{
		get
		{
			if (_oBuffButton5 != null)
			{
				return _oBuffButton5.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable5 != value && _oBuffButton5 != null)
			{
				_oBuffButton5.interactable = value;
			}
		}
	}

	public bool BuffButtonable6
	{
		get
		{
			if (_oBuffButton6 != null)
			{
				return _oBuffButton6.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable6 != value && _oBuffButton6 != null)
			{
				_oBuffButton6.interactable = value;
			}
		}
	}

	public bool BuffButtonable7
	{
		get
		{
			if (_oBuffButton7 != null)
			{
				return _oBuffButton7.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable7 != value && _oBuffButton7 != null)
			{
				_oBuffButton7.interactable = value;
			}
		}
	}

	public bool BuffButtonable8
	{
		get
		{
			if (_oBuffButton8 != null)
			{
				return _oBuffButton8.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable8 != value && _oBuffButton8 != null)
			{
				_oBuffButton8.interactable = value;
			}
		}
	}

	public bool BuffButtonable9
	{
		get
		{
			if (_oBuffButton9 != null)
			{
				return _oBuffButton9.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable9 != value && _oBuffButton9 != null)
			{
				_oBuffButton9.interactable = value;
			}
		}
	}

	public bool BuffButtonable10
	{
		get
		{
			if (_oBuffButton10 != null)
			{
				return _oBuffButton10.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable10 != value && _oBuffButton10 != null)
			{
				_oBuffButton10.interactable = value;
			}
		}
	}

	public bool BuffButtonable11
	{
		get
		{
			if (_oBuffButton11 != null)
			{
				return _oBuffButton11.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable11 != value && _oBuffButton11 != null)
			{
				_oBuffButton11.interactable = value;
			}
		}
	}

	public bool BuffButtonable12
	{
		get
		{
			if (_oBuffButton12 != null)
			{
				return _oBuffButton12.interactable;
			}
			return true;
		}
		set
		{
			if (BuffButtonable12 != value && _oBuffButton12 != null)
			{
				_oBuffButton12.interactable = value;
			}
		}
	}

	public string SkillCountString
	{
		get
		{
			if (_oSkillCountText != null)
			{
				return _oSkillCountText.text;
			}
			return null;
		}
		set
		{
			if (SkillCountString != value && _oSkillCountText != null)
			{
				_oSkillCountText.text = value;
			}
		}
	}

	public bool DesShow
	{
		get
		{
			if (_oDes != null)
			{
				return _oDes.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DesShow != value && _oDes != null)
			{
				_oDes.SetObjectActive(value);
			}
		}
	}

	public Vector3 DesPosition
	{
		get
		{
			if (_oDesRectTransform != null)
			{
				return _oDesRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DesPosition != value && _oDesRectTransform != null)
			{
				_oDesRectTransform.localPosition = value;
			}
		}
	}

	public bool ParentShow
	{
		get
		{
			if (_oParent != null)
			{
				return _oParent.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ParentShow != value && _oParent != null)
			{
				_oParent.SetObjectActive(value);
			}
		}
	}

	public Vector3 ParentPosition
	{
		get
		{
			if (_oParentRectTransform != null)
			{
				return _oParentRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (ParentPosition != value && _oParentRectTransform != null)
			{
				_oParentRectTransform.localPosition = value;
			}
		}
	}

	public string DesNameString
	{
		get
		{
			if (_oDesNameText != null)
			{
				return _oDesNameText.text;
			}
			return null;
		}
		set
		{
			if (DesNameString != value && _oDesNameText != null)
			{
				_oDesNameText.text = value;
			}
		}
	}

	public string DesContentString
	{
		get
		{
			if (_oDesContentText != null)
			{
				return _oDesContentText.text;
			}
			return null;
		}
		set
		{
			if (DesContentString != value && _oDesContentText != null)
			{
				_oDesContentText.text = value;
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
			case "skillBackImage1":
				_oskillBackImage1 = transform.gameObject;
				break;
			case "skillBackImage2":
				_oskillBackImage2 = transform.gameObject;
				break;
			case "skillBackImage3":
				_oskillBackImage3 = transform.gameObject;
				break;
			case "skills":
				_oskills = transform.gameObject;
				break;
			case "Skill1":
				_oSkill1 = transform.gameObject;
				_oSkillRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage1 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill2":
				_oSkill2 = transform.gameObject;
				_oSkillRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage2 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill3":
				_oSkill3 = transform.gameObject;
				_oSkillRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage3 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill4":
				_oSkill4 = transform.gameObject;
				_oSkillRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage4 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill5":
				_oSkill5 = transform.gameObject;
				_oSkillRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage5 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger5 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill6":
				_oSkill6 = transform.gameObject;
				_oSkillRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage6 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger6 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton6 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill7":
				_oSkill7 = transform.gameObject;
				_oSkillRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage7 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger7 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton7 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill8":
				_oSkill8 = transform.gameObject;
				_oSkillRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage8 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger8 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton8 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill9":
				_oSkill9 = transform.gameObject;
				_oSkillRectTransform9 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage9 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger9 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton9 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill10":
				_oSkill10 = transform.gameObject;
				_oSkillRectTransform10 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage10 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger10 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton10 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill11":
				_oSkill11 = transform.gameObject;
				_oSkillRectTransform11 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage11 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger11 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton11 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill12":
				_oSkill12 = transform.gameObject;
				_oSkillRectTransform12 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage12 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger12 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton12 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill13":
				_oSkill13 = transform.gameObject;
				_oSkillRectTransform13 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage13 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger13 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton13 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill14":
				_oSkill14 = transform.gameObject;
				_oSkillRectTransform14 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage14 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger14 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton14 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill15":
				_oSkill15 = transform.gameObject;
				_oSkillRectTransform15 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage15 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger15 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton15 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill16":
				_oSkill16 = transform.gameObject;
				_oSkillRectTransform16 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage16 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger16 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton16 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill17":
				_oSkill17 = transform.gameObject;
				_oSkillRectTransform17 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage17 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger17 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton17 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill18":
				_oSkill18 = transform.gameObject;
				_oSkillRectTransform18 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage18 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger18 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton18 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill19":
				_oSkill19 = transform.gameObject;
				_oSkillRectTransform19 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage19 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger19 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton19 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill20":
				_oSkill20 = transform.gameObject;
				_oSkillRectTransform20 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage20 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger20 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton20 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill21":
				_oSkill21 = transform.gameObject;
				_oSkillRectTransform21 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage21 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger21 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton21 = transform.gameObject.GetComponent<Button>();
				break;
			case "Skill22":
				_oSkill22 = transform.gameObject;
				_oSkillRectTransform22 = transform.gameObject.GetComponent<RectTransform>();
				_oSkillImage22 = transform.gameObject.GetComponent<Image>();
				_oSkillEventTrigger22 = transform.gameObject.GetComponent<EventTrigger>();
				_oSkillButton22 = transform.gameObject.GetComponent<Button>();
				break;
			case "SkillParent1":
				_oSkillParent1 = transform.gameObject;
				_oSkillParentRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "SkillParent2":
				_oSkillParent2 = transform.gameObject;
				_oSkillParentRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "SkillParent3":
				_oSkillParent3 = transform.gameObject;
				_oSkillParentRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Buff1":
				_oBuff1 = transform.gameObject;
				_oBuffRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage1 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger1 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "Buff2":
				_oBuff2 = transform.gameObject;
				_oBuffRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage2 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger2 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "Buff3":
				_oBuff3 = transform.gameObject;
				_oBuffRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage3 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger3 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "Buff4":
				_oBuff4 = transform.gameObject;
				_oBuffRectTransform4 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage4 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger4 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "Buff5":
				_oBuff5 = transform.gameObject;
				_oBuffRectTransform5 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage5 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger5 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "Buff6":
				_oBuff6 = transform.gameObject;
				_oBuffRectTransform6 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage6 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger6 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton6 = transform.gameObject.GetComponent<Button>();
				break;
			case "Buff7":
				_oBuff7 = transform.gameObject;
				_oBuffRectTransform7 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage7 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger7 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton7 = transform.gameObject.GetComponent<Button>();
				break;
			case "Buff8":
				_oBuff8 = transform.gameObject;
				_oBuffRectTransform8 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage8 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger8 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton8 = transform.gameObject.GetComponent<Button>();
				break;
			case "Buff9":
				_oBuff9 = transform.gameObject;
				_oBuffRectTransform9 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage9 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger9 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton9 = transform.gameObject.GetComponent<Button>();
				break;
			case "Buff10":
				_oBuff10 = transform.gameObject;
				_oBuffRectTransform10 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage10 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger10 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton10 = transform.gameObject.GetComponent<Button>();
				break;
			case "Buff11":
				_oBuff11 = transform.gameObject;
				_oBuffRectTransform11 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage11 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger11 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton11 = transform.gameObject.GetComponent<Button>();
				break;
			case "Buff12":
				_oBuff12 = transform.gameObject;
				_oBuffRectTransform12 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage12 = transform.gameObject.GetComponent<Image>();
				_oBuffEventTrigger12 = transform.gameObject.GetComponent<EventTrigger>();
				_oBuffButton12 = transform.gameObject.GetComponent<Button>();
				break;
			case "SkillCount":
				_oSkillCount = transform.gameObject;
				_oSkillCountText = transform.gameObject.GetComponent<Text>();
				break;
			case "Des":
				_oDes = transform.gameObject;
				_oDesRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Parent":
				_oParent = transform.gameObject;
				_oParentRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "DesName":
				_oDesName = transform.gameObject;
				_oDesNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "DesContent":
				_oDesContent = transform.gameObject;
				_oDesContentText = transform.gameObject.GetComponent<Text>();
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

	public bool GetskillBackImageShow(int index)
	{
		return index switch
		{
			1 => skillBackImageShow1, 
			2 => skillBackImageShow2, 
			3 => skillBackImageShow3, 
			_ => false, 
		};
	}

	public void SetskillBackImageShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			skillBackImageShow1 = value;
			break;
		case 2:
			skillBackImageShow2 = value;
			break;
		case 3:
			skillBackImageShow3 = value;
			break;
		}
	}

	public int GetskillBackImageCount()
	{
		return 3;
	}

	public bool GetSkillShow(int index)
	{
		return index switch
		{
			1 => SkillShow1, 
			2 => SkillShow2, 
			3 => SkillShow3, 
			4 => SkillShow4, 
			5 => SkillShow5, 
			6 => SkillShow6, 
			7 => SkillShow7, 
			8 => SkillShow8, 
			9 => SkillShow9, 
			10 => SkillShow10, 
			11 => SkillShow11, 
			12 => SkillShow12, 
			13 => SkillShow13, 
			14 => SkillShow14, 
			15 => SkillShow15, 
			16 => SkillShow16, 
			17 => SkillShow17, 
			18 => SkillShow18, 
			19 => SkillShow19, 
			20 => SkillShow20, 
			21 => SkillShow21, 
			22 => SkillShow22, 
			_ => false, 
		};
	}

	public void SetSkillShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillShow1 = value;
			break;
		case 2:
			SkillShow2 = value;
			break;
		case 3:
			SkillShow3 = value;
			break;
		case 4:
			SkillShow4 = value;
			break;
		case 5:
			SkillShow5 = value;
			break;
		case 6:
			SkillShow6 = value;
			break;
		case 7:
			SkillShow7 = value;
			break;
		case 8:
			SkillShow8 = value;
			break;
		case 9:
			SkillShow9 = value;
			break;
		case 10:
			SkillShow10 = value;
			break;
		case 11:
			SkillShow11 = value;
			break;
		case 12:
			SkillShow12 = value;
			break;
		case 13:
			SkillShow13 = value;
			break;
		case 14:
			SkillShow14 = value;
			break;
		case 15:
			SkillShow15 = value;
			break;
		case 16:
			SkillShow16 = value;
			break;
		case 17:
			SkillShow17 = value;
			break;
		case 18:
			SkillShow18 = value;
			break;
		case 19:
			SkillShow19 = value;
			break;
		case 20:
			SkillShow20 = value;
			break;
		case 21:
			SkillShow21 = value;
			break;
		case 22:
			SkillShow22 = value;
			break;
		}
	}

	public int GetSkillCount()
	{
		return 22;
	}

	public Vector3 GetSkillPosition(int index)
	{
		return index switch
		{
			1 => SkillPosition1, 
			2 => SkillPosition2, 
			3 => SkillPosition3, 
			4 => SkillPosition4, 
			5 => SkillPosition5, 
			6 => SkillPosition6, 
			7 => SkillPosition7, 
			8 => SkillPosition8, 
			9 => SkillPosition9, 
			10 => SkillPosition10, 
			11 => SkillPosition11, 
			12 => SkillPosition12, 
			13 => SkillPosition13, 
			14 => SkillPosition14, 
			15 => SkillPosition15, 
			16 => SkillPosition16, 
			17 => SkillPosition17, 
			18 => SkillPosition18, 
			19 => SkillPosition19, 
			20 => SkillPosition20, 
			21 => SkillPosition21, 
			22 => SkillPosition22, 
			_ => Vector3.zero, 
		};
	}

	public void SetSkillPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			SkillPosition1 = value;
			break;
		case 2:
			SkillPosition2 = value;
			break;
		case 3:
			SkillPosition3 = value;
			break;
		case 4:
			SkillPosition4 = value;
			break;
		case 5:
			SkillPosition5 = value;
			break;
		case 6:
			SkillPosition6 = value;
			break;
		case 7:
			SkillPosition7 = value;
			break;
		case 8:
			SkillPosition8 = value;
			break;
		case 9:
			SkillPosition9 = value;
			break;
		case 10:
			SkillPosition10 = value;
			break;
		case 11:
			SkillPosition11 = value;
			break;
		case 12:
			SkillPosition12 = value;
			break;
		case 13:
			SkillPosition13 = value;
			break;
		case 14:
			SkillPosition14 = value;
			break;
		case 15:
			SkillPosition15 = value;
			break;
		case 16:
			SkillPosition16 = value;
			break;
		case 17:
			SkillPosition17 = value;
			break;
		case 18:
			SkillPosition18 = value;
			break;
		case 19:
			SkillPosition19 = value;
			break;
		case 20:
			SkillPosition20 = value;
			break;
		case 21:
			SkillPosition21 = value;
			break;
		case 22:
			SkillPosition22 = value;
			break;
		}
	}

	public bool GetSkillEnabled(int index)
	{
		return index switch
		{
			1 => SkillEnabled1, 
			2 => SkillEnabled2, 
			3 => SkillEnabled3, 
			4 => SkillEnabled4, 
			5 => SkillEnabled5, 
			6 => SkillEnabled6, 
			7 => SkillEnabled7, 
			8 => SkillEnabled8, 
			9 => SkillEnabled9, 
			10 => SkillEnabled10, 
			11 => SkillEnabled11, 
			12 => SkillEnabled12, 
			13 => SkillEnabled13, 
			14 => SkillEnabled14, 
			15 => SkillEnabled15, 
			16 => SkillEnabled16, 
			17 => SkillEnabled17, 
			18 => SkillEnabled18, 
			19 => SkillEnabled19, 
			20 => SkillEnabled20, 
			21 => SkillEnabled21, 
			22 => SkillEnabled22, 
			_ => false, 
		};
	}

	public void SetSkillEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillEnabled1 = value;
			break;
		case 2:
			SkillEnabled2 = value;
			break;
		case 3:
			SkillEnabled3 = value;
			break;
		case 4:
			SkillEnabled4 = value;
			break;
		case 5:
			SkillEnabled5 = value;
			break;
		case 6:
			SkillEnabled6 = value;
			break;
		case 7:
			SkillEnabled7 = value;
			break;
		case 8:
			SkillEnabled8 = value;
			break;
		case 9:
			SkillEnabled9 = value;
			break;
		case 10:
			SkillEnabled10 = value;
			break;
		case 11:
			SkillEnabled11 = value;
			break;
		case 12:
			SkillEnabled12 = value;
			break;
		case 13:
			SkillEnabled13 = value;
			break;
		case 14:
			SkillEnabled14 = value;
			break;
		case 15:
			SkillEnabled15 = value;
			break;
		case 16:
			SkillEnabled16 = value;
			break;
		case 17:
			SkillEnabled17 = value;
			break;
		case 18:
			SkillEnabled18 = value;
			break;
		case 19:
			SkillEnabled19 = value;
			break;
		case 20:
			SkillEnabled20 = value;
			break;
		case 21:
			SkillEnabled21 = value;
			break;
		case 22:
			SkillEnabled22 = value;
			break;
		}
	}

	public Color GetSkillColor(int index)
	{
		return index switch
		{
			1 => SkillColor1, 
			2 => SkillColor2, 
			3 => SkillColor3, 
			4 => SkillColor4, 
			5 => SkillColor5, 
			6 => SkillColor6, 
			7 => SkillColor7, 
			8 => SkillColor8, 
			9 => SkillColor9, 
			10 => SkillColor10, 
			11 => SkillColor11, 
			12 => SkillColor12, 
			13 => SkillColor13, 
			14 => SkillColor14, 
			15 => SkillColor15, 
			16 => SkillColor16, 
			17 => SkillColor17, 
			18 => SkillColor18, 
			19 => SkillColor19, 
			20 => SkillColor20, 
			21 => SkillColor21, 
			22 => SkillColor22, 
			_ => Color.white, 
		};
	}

	public void SetSkillColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			SkillColor1 = value;
			break;
		case 2:
			SkillColor2 = value;
			break;
		case 3:
			SkillColor3 = value;
			break;
		case 4:
			SkillColor4 = value;
			break;
		case 5:
			SkillColor5 = value;
			break;
		case 6:
			SkillColor6 = value;
			break;
		case 7:
			SkillColor7 = value;
			break;
		case 8:
			SkillColor8 = value;
			break;
		case 9:
			SkillColor9 = value;
			break;
		case 10:
			SkillColor10 = value;
			break;
		case 11:
			SkillColor11 = value;
			break;
		case 12:
			SkillColor12 = value;
			break;
		case 13:
			SkillColor13 = value;
			break;
		case 14:
			SkillColor14 = value;
			break;
		case 15:
			SkillColor15 = value;
			break;
		case 16:
			SkillColor16 = value;
			break;
		case 17:
			SkillColor17 = value;
			break;
		case 18:
			SkillColor18 = value;
			break;
		case 19:
			SkillColor19 = value;
			break;
		case 20:
			SkillColor20 = value;
			break;
		case 21:
			SkillColor21 = value;
			break;
		case 22:
			SkillColor22 = value;
			break;
		}
	}

	private void CreateSkillTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers1, eventId, callback);
	}

	private void RemoveSkillTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers1, eventId);
	}

	private void CreateSkillTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers2, eventId, callback);
	}

	private void RemoveSkillTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers2, eventId);
	}

	private void CreateSkillTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers3, eventId, callback);
	}

	private void RemoveSkillTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers3, eventId);
	}

	private void CreateSkillTriggers4Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers4, eventId, callback);
	}

	private void RemoveSkillTriggers4Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers4, eventId);
	}

	private void CreateSkillTriggers5Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers5, eventId, callback);
	}

	private void RemoveSkillTriggers5Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers5, eventId);
	}

	private void CreateSkillTriggers6Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers6, eventId, callback);
	}

	private void RemoveSkillTriggers6Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers6, eventId);
	}

	private void CreateSkillTriggers7Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers7, eventId, callback);
	}

	private void RemoveSkillTriggers7Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers7, eventId);
	}

	private void CreateSkillTriggers8Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers8, eventId, callback);
	}

	private void RemoveSkillTriggers8Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers8, eventId);
	}

	private void CreateSkillTriggers9Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers9, eventId, callback);
	}

	private void RemoveSkillTriggers9Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers9, eventId);
	}

	private void CreateSkillTriggers10Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers10, eventId, callback);
	}

	private void RemoveSkillTriggers10Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers10, eventId);
	}

	private void CreateSkillTriggers11Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers11, eventId, callback);
	}

	private void RemoveSkillTriggers11Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers11, eventId);
	}

	private void CreateSkillTriggers12Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers12, eventId, callback);
	}

	private void RemoveSkillTriggers12Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers12, eventId);
	}

	private void CreateSkillTriggers13Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers13, eventId, callback);
	}

	private void RemoveSkillTriggers13Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers13, eventId);
	}

	private void CreateSkillTriggers14Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers14, eventId, callback);
	}

	private void RemoveSkillTriggers14Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers14, eventId);
	}

	private void CreateSkillTriggers15Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers15, eventId, callback);
	}

	private void RemoveSkillTriggers15Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers15, eventId);
	}

	private void CreateSkillTriggers16Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers16, eventId, callback);
	}

	private void RemoveSkillTriggers16Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers16, eventId);
	}

	private void CreateSkillTriggers17Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers17, eventId, callback);
	}

	private void RemoveSkillTriggers17Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers17, eventId);
	}

	private void CreateSkillTriggers18Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers18, eventId, callback);
	}

	private void RemoveSkillTriggers18Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers18, eventId);
	}

	private void CreateSkillTriggers19Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers19, eventId, callback);
	}

	private void RemoveSkillTriggers19Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers19, eventId);
	}

	private void CreateSkillTriggers20Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers20, eventId, callback);
	}

	private void RemoveSkillTriggers20Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers20, eventId);
	}

	private void CreateSkillTriggers21Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers21, eventId, callback);
	}

	private void RemoveSkillTriggers21Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers21, eventId);
	}

	private void CreateSkillTriggers22Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(SkillTriggers22, eventId, callback);
	}

	private void RemoveSkillTriggers22Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(SkillTriggers22, eventId);
	}

	public List<EventTrigger.Entry> GetSkillTriggers(int index)
	{
		return index switch
		{
			1 => SkillTriggers1, 
			2 => SkillTriggers2, 
			3 => SkillTriggers3, 
			4 => SkillTriggers4, 
			5 => SkillTriggers5, 
			6 => SkillTriggers6, 
			7 => SkillTriggers7, 
			8 => SkillTriggers8, 
			9 => SkillTriggers9, 
			10 => SkillTriggers10, 
			11 => SkillTriggers11, 
			12 => SkillTriggers12, 
			13 => SkillTriggers13, 
			14 => SkillTriggers14, 
			15 => SkillTriggers15, 
			16 => SkillTriggers16, 
			17 => SkillTriggers17, 
			18 => SkillTriggers18, 
			19 => SkillTriggers19, 
			20 => SkillTriggers20, 
			21 => SkillTriggers21, 
			22 => SkillTriggers22, 
			_ => null, 
		};
	}

	public void SetSkillTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			SkillTriggers1 = value;
			break;
		case 2:
			SkillTriggers2 = value;
			break;
		case 3:
			SkillTriggers3 = value;
			break;
		case 4:
			SkillTriggers4 = value;
			break;
		case 5:
			SkillTriggers5 = value;
			break;
		case 6:
			SkillTriggers6 = value;
			break;
		case 7:
			SkillTriggers7 = value;
			break;
		case 8:
			SkillTriggers8 = value;
			break;
		case 9:
			SkillTriggers9 = value;
			break;
		case 10:
			SkillTriggers10 = value;
			break;
		case 11:
			SkillTriggers11 = value;
			break;
		case 12:
			SkillTriggers12 = value;
			break;
		case 13:
			SkillTriggers13 = value;
			break;
		case 14:
			SkillTriggers14 = value;
			break;
		case 15:
			SkillTriggers15 = value;
			break;
		case 16:
			SkillTriggers16 = value;
			break;
		case 17:
			SkillTriggers17 = value;
			break;
		case 18:
			SkillTriggers18 = value;
			break;
		case 19:
			SkillTriggers19 = value;
			break;
		case 20:
			SkillTriggers20 = value;
			break;
		case 21:
			SkillTriggers21 = value;
			break;
		case 22:
			SkillTriggers22 = value;
			break;
		}
	}

	private void CreateSkillTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetSkillTriggers(index), eventId, callback);
	}

	private void RemoveSkillTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetSkillTriggers(index), eventId);
	}

	public Button.ButtonClickedEvent GetSkillClicked(int index)
	{
		return index switch
		{
			1 => SkillClicked1, 
			2 => SkillClicked2, 
			3 => SkillClicked3, 
			4 => SkillClicked4, 
			5 => SkillClicked5, 
			6 => SkillClicked6, 
			7 => SkillClicked7, 
			8 => SkillClicked8, 
			9 => SkillClicked9, 
			10 => SkillClicked10, 
			11 => SkillClicked11, 
			12 => SkillClicked12, 
			13 => SkillClicked13, 
			14 => SkillClicked14, 
			15 => SkillClicked15, 
			16 => SkillClicked16, 
			17 => SkillClicked17, 
			18 => SkillClicked18, 
			19 => SkillClicked19, 
			20 => SkillClicked20, 
			21 => SkillClicked21, 
			22 => SkillClicked22, 
			_ => null, 
		};
	}

	public void SetSkillClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			SkillClicked1 = value;
			break;
		case 2:
			SkillClicked2 = value;
			break;
		case 3:
			SkillClicked3 = value;
			break;
		case 4:
			SkillClicked4 = value;
			break;
		case 5:
			SkillClicked5 = value;
			break;
		case 6:
			SkillClicked6 = value;
			break;
		case 7:
			SkillClicked7 = value;
			break;
		case 8:
			SkillClicked8 = value;
			break;
		case 9:
			SkillClicked9 = value;
			break;
		case 10:
			SkillClicked10 = value;
			break;
		case 11:
			SkillClicked11 = value;
			break;
		case 12:
			SkillClicked12 = value;
			break;
		case 13:
			SkillClicked13 = value;
			break;
		case 14:
			SkillClicked14 = value;
			break;
		case 15:
			SkillClicked15 = value;
			break;
		case 16:
			SkillClicked16 = value;
			break;
		case 17:
			SkillClicked17 = value;
			break;
		case 18:
			SkillClicked18 = value;
			break;
		case 19:
			SkillClicked19 = value;
			break;
		case 20:
			SkillClicked20 = value;
			break;
		case 21:
			SkillClicked21 = value;
			break;
		case 22:
			SkillClicked22 = value;
			break;
		}
	}

	public bool GetSkillButtonable(int index)
	{
		return index switch
		{
			1 => SkillButtonable1, 
			2 => SkillButtonable2, 
			3 => SkillButtonable3, 
			4 => SkillButtonable4, 
			5 => SkillButtonable5, 
			6 => SkillButtonable6, 
			7 => SkillButtonable7, 
			8 => SkillButtonable8, 
			9 => SkillButtonable9, 
			10 => SkillButtonable10, 
			11 => SkillButtonable11, 
			12 => SkillButtonable12, 
			13 => SkillButtonable13, 
			14 => SkillButtonable14, 
			15 => SkillButtonable15, 
			16 => SkillButtonable16, 
			17 => SkillButtonable17, 
			18 => SkillButtonable18, 
			19 => SkillButtonable19, 
			20 => SkillButtonable20, 
			21 => SkillButtonable21, 
			22 => SkillButtonable22, 
			_ => true, 
		};
	}

	public void SetSkillButtonable(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillButtonable1 = value;
			break;
		case 2:
			SkillButtonable2 = value;
			break;
		case 3:
			SkillButtonable3 = value;
			break;
		case 4:
			SkillButtonable4 = value;
			break;
		case 5:
			SkillButtonable5 = value;
			break;
		case 6:
			SkillButtonable6 = value;
			break;
		case 7:
			SkillButtonable7 = value;
			break;
		case 8:
			SkillButtonable8 = value;
			break;
		case 9:
			SkillButtonable9 = value;
			break;
		case 10:
			SkillButtonable10 = value;
			break;
		case 11:
			SkillButtonable11 = value;
			break;
		case 12:
			SkillButtonable12 = value;
			break;
		case 13:
			SkillButtonable13 = value;
			break;
		case 14:
			SkillButtonable14 = value;
			break;
		case 15:
			SkillButtonable15 = value;
			break;
		case 16:
			SkillButtonable16 = value;
			break;
		case 17:
			SkillButtonable17 = value;
			break;
		case 18:
			SkillButtonable18 = value;
			break;
		case 19:
			SkillButtonable19 = value;
			break;
		case 20:
			SkillButtonable20 = value;
			break;
		case 21:
			SkillButtonable21 = value;
			break;
		case 22:
			SkillButtonable22 = value;
			break;
		}
	}

	public GameObject GetSkillParentObj(int index)
	{
		return index switch
		{
			1 => SkillParentObj1, 
			2 => SkillParentObj2, 
			3 => SkillParentObj3, 
			_ => null, 
		};
	}

	public int GetSkillParentCount()
	{
		return 3;
	}

	public bool GetSkillParentShow(int index)
	{
		return index switch
		{
			1 => SkillParentShow1, 
			2 => SkillParentShow2, 
			3 => SkillParentShow3, 
			_ => false, 
		};
	}

	public void SetSkillParentShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			SkillParentShow1 = value;
			break;
		case 2:
			SkillParentShow2 = value;
			break;
		case 3:
			SkillParentShow3 = value;
			break;
		}
	}

	public Vector3 GetSkillParentPosition(int index)
	{
		return index switch
		{
			1 => SkillParentPosition1, 
			2 => SkillParentPosition2, 
			3 => SkillParentPosition3, 
			_ => Vector3.zero, 
		};
	}

	public void SetSkillParentPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			SkillParentPosition1 = value;
			break;
		case 2:
			SkillParentPosition2 = value;
			break;
		case 3:
			SkillParentPosition3 = value;
			break;
		}
	}

	public bool GetBuffShow(int index)
	{
		return index switch
		{
			1 => BuffShow1, 
			2 => BuffShow2, 
			3 => BuffShow3, 
			4 => BuffShow4, 
			5 => BuffShow5, 
			6 => BuffShow6, 
			7 => BuffShow7, 
			8 => BuffShow8, 
			9 => BuffShow9, 
			10 => BuffShow10, 
			11 => BuffShow11, 
			12 => BuffShow12, 
			_ => false, 
		};
	}

	public void SetBuffShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			BuffShow1 = value;
			break;
		case 2:
			BuffShow2 = value;
			break;
		case 3:
			BuffShow3 = value;
			break;
		case 4:
			BuffShow4 = value;
			break;
		case 5:
			BuffShow5 = value;
			break;
		case 6:
			BuffShow6 = value;
			break;
		case 7:
			BuffShow7 = value;
			break;
		case 8:
			BuffShow8 = value;
			break;
		case 9:
			BuffShow9 = value;
			break;
		case 10:
			BuffShow10 = value;
			break;
		case 11:
			BuffShow11 = value;
			break;
		case 12:
			BuffShow12 = value;
			break;
		}
	}

	public int GetBuffCount()
	{
		return 12;
	}

	public Vector3 GetBuffPosition(int index)
	{
		return index switch
		{
			1 => BuffPosition1, 
			2 => BuffPosition2, 
			3 => BuffPosition3, 
			4 => BuffPosition4, 
			5 => BuffPosition5, 
			6 => BuffPosition6, 
			7 => BuffPosition7, 
			8 => BuffPosition8, 
			9 => BuffPosition9, 
			10 => BuffPosition10, 
			11 => BuffPosition11, 
			12 => BuffPosition12, 
			_ => Vector3.zero, 
		};
	}

	public void SetBuffPosition(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			BuffPosition1 = value;
			break;
		case 2:
			BuffPosition2 = value;
			break;
		case 3:
			BuffPosition3 = value;
			break;
		case 4:
			BuffPosition4 = value;
			break;
		case 5:
			BuffPosition5 = value;
			break;
		case 6:
			BuffPosition6 = value;
			break;
		case 7:
			BuffPosition7 = value;
			break;
		case 8:
			BuffPosition8 = value;
			break;
		case 9:
			BuffPosition9 = value;
			break;
		case 10:
			BuffPosition10 = value;
			break;
		case 11:
			BuffPosition11 = value;
			break;
		case 12:
			BuffPosition12 = value;
			break;
		}
	}

	public bool GetBuffEnabled(int index)
	{
		return index switch
		{
			1 => BuffEnabled1, 
			2 => BuffEnabled2, 
			3 => BuffEnabled3, 
			4 => BuffEnabled4, 
			5 => BuffEnabled5, 
			6 => BuffEnabled6, 
			7 => BuffEnabled7, 
			8 => BuffEnabled8, 
			9 => BuffEnabled9, 
			10 => BuffEnabled10, 
			11 => BuffEnabled11, 
			12 => BuffEnabled12, 
			_ => false, 
		};
	}

	public void SetBuffEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			BuffEnabled1 = value;
			break;
		case 2:
			BuffEnabled2 = value;
			break;
		case 3:
			BuffEnabled3 = value;
			break;
		case 4:
			BuffEnabled4 = value;
			break;
		case 5:
			BuffEnabled5 = value;
			break;
		case 6:
			BuffEnabled6 = value;
			break;
		case 7:
			BuffEnabled7 = value;
			break;
		case 8:
			BuffEnabled8 = value;
			break;
		case 9:
			BuffEnabled9 = value;
			break;
		case 10:
			BuffEnabled10 = value;
			break;
		case 11:
			BuffEnabled11 = value;
			break;
		case 12:
			BuffEnabled12 = value;
			break;
		}
	}

	public Color GetBuffColor(int index)
	{
		return index switch
		{
			1 => BuffColor1, 
			2 => BuffColor2, 
			3 => BuffColor3, 
			4 => BuffColor4, 
			5 => BuffColor5, 
			6 => BuffColor6, 
			7 => BuffColor7, 
			8 => BuffColor8, 
			9 => BuffColor9, 
			10 => BuffColor10, 
			11 => BuffColor11, 
			12 => BuffColor12, 
			_ => Color.white, 
		};
	}

	public void SetBuffColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			BuffColor1 = value;
			break;
		case 2:
			BuffColor2 = value;
			break;
		case 3:
			BuffColor3 = value;
			break;
		case 4:
			BuffColor4 = value;
			break;
		case 5:
			BuffColor5 = value;
			break;
		case 6:
			BuffColor6 = value;
			break;
		case 7:
			BuffColor7 = value;
			break;
		case 8:
			BuffColor8 = value;
			break;
		case 9:
			BuffColor9 = value;
			break;
		case 10:
			BuffColor10 = value;
			break;
		case 11:
			BuffColor11 = value;
			break;
		case 12:
			BuffColor12 = value;
			break;
		}
	}

	private void CreateBuffTriggers1Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers1, eventId, callback);
	}

	private void RemoveBuffTriggers1Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers1, eventId);
	}

	private void CreateBuffTriggers2Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers2, eventId, callback);
	}

	private void RemoveBuffTriggers2Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers2, eventId);
	}

	private void CreateBuffTriggers3Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers3, eventId, callback);
	}

	private void RemoveBuffTriggers3Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers3, eventId);
	}

	private void CreateBuffTriggers4Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers4, eventId, callback);
	}

	private void RemoveBuffTriggers4Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers4, eventId);
	}

	private void CreateBuffTriggers5Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers5, eventId, callback);
	}

	private void RemoveBuffTriggers5Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers5, eventId);
	}

	private void CreateBuffTriggers6Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers6, eventId, callback);
	}

	private void RemoveBuffTriggers6Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers6, eventId);
	}

	private void CreateBuffTriggers7Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers7, eventId, callback);
	}

	private void RemoveBuffTriggers7Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers7, eventId);
	}

	private void CreateBuffTriggers8Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers8, eventId, callback);
	}

	private void RemoveBuffTriggers8Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers8, eventId);
	}

	private void CreateBuffTriggers9Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers9, eventId, callback);
	}

	private void RemoveBuffTriggers9Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers9, eventId);
	}

	private void CreateBuffTriggers10Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers10, eventId, callback);
	}

	private void RemoveBuffTriggers10Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers10, eventId);
	}

	private void CreateBuffTriggers11Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers11, eventId, callback);
	}

	private void RemoveBuffTriggers11Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers11, eventId);
	}

	private void CreateBuffTriggers12Entry(EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(BuffTriggers12, eventId, callback);
	}

	private void RemoveBuffTriggers12Entry(EventTriggerType eventId)
	{
		RemoveTriggerEntry(BuffTriggers12, eventId);
	}

	public List<EventTrigger.Entry> GetBuffTriggers(int index)
	{
		return index switch
		{
			1 => BuffTriggers1, 
			2 => BuffTriggers2, 
			3 => BuffTriggers3, 
			4 => BuffTriggers4, 
			5 => BuffTriggers5, 
			6 => BuffTriggers6, 
			7 => BuffTriggers7, 
			8 => BuffTriggers8, 
			9 => BuffTriggers9, 
			10 => BuffTriggers10, 
			11 => BuffTriggers11, 
			12 => BuffTriggers12, 
			_ => null, 
		};
	}

	public void SetBuffTriggers(int index, List<EventTrigger.Entry> value)
	{
		switch (index)
		{
		case 1:
			BuffTriggers1 = value;
			break;
		case 2:
			BuffTriggers2 = value;
			break;
		case 3:
			BuffTriggers3 = value;
			break;
		case 4:
			BuffTriggers4 = value;
			break;
		case 5:
			BuffTriggers5 = value;
			break;
		case 6:
			BuffTriggers6 = value;
			break;
		case 7:
			BuffTriggers7 = value;
			break;
		case 8:
			BuffTriggers8 = value;
			break;
		case 9:
			BuffTriggers9 = value;
			break;
		case 10:
			BuffTriggers10 = value;
			break;
		case 11:
			BuffTriggers11 = value;
			break;
		case 12:
			BuffTriggers12 = value;
			break;
		}
	}

	private void CreateBuffTriggersEntry(int index, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		CreateTriggerEntry(GetBuffTriggers(index), eventId, callback);
	}

	private void RemoveBuffTriggersEntry(int index, EventTriggerType eventId)
	{
		RemoveTriggerEntry(GetBuffTriggers(index), eventId);
	}

	public Button.ButtonClickedEvent GetBuffClicked(int index)
	{
		return index switch
		{
			1 => BuffClicked1, 
			2 => BuffClicked2, 
			3 => BuffClicked3, 
			4 => BuffClicked4, 
			5 => BuffClicked5, 
			6 => BuffClicked6, 
			7 => BuffClicked7, 
			8 => BuffClicked8, 
			9 => BuffClicked9, 
			10 => BuffClicked10, 
			11 => BuffClicked11, 
			12 => BuffClicked12, 
			_ => null, 
		};
	}

	public void SetBuffClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			BuffClicked1 = value;
			break;
		case 2:
			BuffClicked2 = value;
			break;
		case 3:
			BuffClicked3 = value;
			break;
		case 4:
			BuffClicked4 = value;
			break;
		case 5:
			BuffClicked5 = value;
			break;
		case 6:
			BuffClicked6 = value;
			break;
		case 7:
			BuffClicked7 = value;
			break;
		case 8:
			BuffClicked8 = value;
			break;
		case 9:
			BuffClicked9 = value;
			break;
		case 10:
			BuffClicked10 = value;
			break;
		case 11:
			BuffClicked11 = value;
			break;
		case 12:
			BuffClicked12 = value;
			break;
		}
	}

	public bool GetBuffButtonable(int index)
	{
		return index switch
		{
			1 => BuffButtonable1, 
			2 => BuffButtonable2, 
			3 => BuffButtonable3, 
			4 => BuffButtonable4, 
			5 => BuffButtonable5, 
			6 => BuffButtonable6, 
			7 => BuffButtonable7, 
			8 => BuffButtonable8, 
			9 => BuffButtonable9, 
			10 => BuffButtonable10, 
			11 => BuffButtonable11, 
			12 => BuffButtonable12, 
			_ => true, 
		};
	}

	public void SetBuffButtonable(int index, bool value)
	{
		switch (index)
		{
		case 1:
			BuffButtonable1 = value;
			break;
		case 2:
			BuffButtonable2 = value;
			break;
		case 3:
			BuffButtonable3 = value;
			break;
		case 4:
			BuffButtonable4 = value;
			break;
		case 5:
			BuffButtonable5 = value;
			break;
		case 6:
			BuffButtonable6 = value;
			break;
		case 7:
			BuffButtonable7 = value;
			break;
		case 8:
			BuffButtonable8 = value;
			break;
		case 9:
			BuffButtonable9 = value;
			break;
		case 10:
			BuffButtonable10 = value;
			break;
		case 11:
			BuffButtonable11 = value;
			break;
		case 12:
			BuffButtonable12 = value;
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
		if (_oSkillCountText != null)
		{
			_holdPosTrans.Add(_oSkillCountText.GetComponent<RectTransform>());
		}
		if (_oDesNameText != null)
		{
			_holdPosTrans.Add(_oDesNameText.GetComponent<RectTransform>());
		}
		if (_oDesContentText != null)
		{
			_holdPosTrans.Add(_oDesContentText.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
