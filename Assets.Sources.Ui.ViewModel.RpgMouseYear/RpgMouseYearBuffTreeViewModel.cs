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
public class RpgMouseYearBuffTreeViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oPanel;

	private GameObject _oskillBackImage1;

	private GameObject _oBuffParent;

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

	private string _resourceAssetName = "RpgMouseYearBuffTree";

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

	public bool BuffParentShow
	{
		get
		{
			if (_oBuffParent != null)
			{
				return _oBuffParent.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffParentShow != value && _oBuffParent != null)
			{
				_oBuffParent.SetObjectActive(value);
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
			case "BuffParent":
				_oBuffParent = transform.gameObject;
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
		if (index == 1)
		{
			return skillBackImageShow1;
		}
		return false;
	}

	public void SetskillBackImageShow(int index, bool value)
	{
		if (index == 1)
		{
			skillBackImageShow1 = value;
		}
	}

	public int GetskillBackImageCount()
	{
		return 1;
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
		return null;
	}
}
