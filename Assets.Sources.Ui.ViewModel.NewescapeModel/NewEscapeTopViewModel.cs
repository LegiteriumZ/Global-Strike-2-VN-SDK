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

namespace Assets.Sources.Ui.ViewModel.NewescapeModel;

[GameUiTest]
public class NewEscapeTopViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oOthPos1;

	private GameObject _oOthPos2;

	private GameObject _oOthPos3;

	private GameObject _oOthPos4;

	private GameObject _oOthPos5;

	private GameObject _oOthPos6;

	private GameObject _oOthPos7;

	private GameObject _oOthPos8;

	private GameObject _oOthPos9;

	private GameObject _oOthPos10;

	private GameObject _oOthPos11;

	private GameObject _oOthPos12;

	private GameObject _oOthPos13;

	private GameObject _oOthPos14;

	private GameObject _oOthPos15;

	private GameObject _oOthPos16;

	private GameObject _oOthPos17;

	private GameObject _oOthPos18;

	private GameObject _oOthPos19;

	private GameObject _oOthPos20;

	private Image _oOthPosImage1;

	private Image _oOthPosImage2;

	private Image _oOthPosImage3;

	private Image _oOthPosImage4;

	private Image _oOthPosImage5;

	private Image _oOthPosImage6;

	private Image _oOthPosImage7;

	private Image _oOthPosImage8;

	private Image _oOthPosImage9;

	private Image _oOthPosImage10;

	private Image _oOthPosImage11;

	private Image _oOthPosImage12;

	private Image _oOthPosImage13;

	private Image _oOthPosImage14;

	private Image _oOthPosImage15;

	private Image _oOthPosImage16;

	private Image _oOthPosImage17;

	private Image _oOthPosImage18;

	private Image _oOthPosImage19;

	private Image _oOthPosImage20;

	private GameObject _oOthTex1;

	private GameObject _oOthTex2;

	private GameObject _oOthTex3;

	private GameObject _oOthTex4;

	private GameObject _oOthTex5;

	private GameObject _oOthTex6;

	private GameObject _oOthTex7;

	private GameObject _oOthTex8;

	private GameObject _oOthTex9;

	private GameObject _oOthTex10;

	private GameObject _oOthTex11;

	private GameObject _oOthTex12;

	private GameObject _oOthTex13;

	private GameObject _oOthTex14;

	private GameObject _oOthTex15;

	private GameObject _oOthTex16;

	private GameObject _oOthTex17;

	private GameObject _oOthTex18;

	private GameObject _oOthTex19;

	private GameObject _oOthTex20;

	private Text _oOthTexText1;

	private Text _oOthTexText2;

	private Text _oOthTexText3;

	private Text _oOthTexText4;

	private Text _oOthTexText5;

	private Text _oOthTexText6;

	private Text _oOthTexText7;

	private Text _oOthTexText8;

	private Text _oOthTexText9;

	private Text _oOthTexText10;

	private Text _oOthTexText11;

	private Text _oOthTexText12;

	private Text _oOthTexText13;

	private Text _oOthTexText14;

	private Text _oOthTexText15;

	private Text _oOthTexText16;

	private Text _oOthTexText17;

	private Text _oOthTexText18;

	private Text _oOthTexText19;

	private Text _oOthTexText20;

	private GameObject _oOthPosPos1;

	private GameObject _oOthPosPos2;

	private GameObject _oOthPosPos3;

	private GameObject _oOthPosPos4;

	private GameObject _oOthPosPos5;

	private GameObject _oOthPosPos6;

	private GameObject _oOthPosPos7;

	private GameObject _oOthPosPos8;

	private GameObject _oOthPosPos9;

	private GameObject _oOthPosPos10;

	private GameObject _oOthPosPos11;

	private GameObject _oOthPosPos12;

	private GameObject _oOthPosPos13;

	private GameObject _oOthPosPos14;

	private GameObject _oOthPosPos15;

	private GameObject _oOthPosPos16;

	private GameObject _oOthPosPos17;

	private GameObject _oOthPosPos18;

	private GameObject _oOthPosPos19;

	private GameObject _oOthPosPos20;

	private Image _oOthPosPosImage1;

	private Image _oOthPosPosImage2;

	private Image _oOthPosPosImage3;

	private Image _oOthPosPosImage4;

	private Image _oOthPosPosImage5;

	private Image _oOthPosPosImage6;

	private Image _oOthPosPosImage7;

	private Image _oOthPosPosImage8;

	private Image _oOthPosPosImage9;

	private Image _oOthPosPosImage10;

	private Image _oOthPosPosImage11;

	private Image _oOthPosPosImage12;

	private Image _oOthPosPosImage13;

	private Image _oOthPosPosImage14;

	private Image _oOthPosPosImage15;

	private Image _oOthPosPosImage16;

	private Image _oOthPosPosImage17;

	private Image _oOthPosPosImage18;

	private Image _oOthPosPosImage19;

	private Image _oOthPosPosImage20;

	private GameObject _oOthText1;

	private GameObject _oOthText2;

	private GameObject _oOthText3;

	private GameObject _oOthText4;

	private GameObject _oOthText5;

	private GameObject _oOthText6;

	private GameObject _oOthText7;

	private GameObject _oOthText8;

	private GameObject _oOthText9;

	private GameObject _oOthText10;

	private GameObject _oOthText11;

	private GameObject _oOthText12;

	private GameObject _oOthText13;

	private GameObject _oOthText14;

	private GameObject _oOthText15;

	private GameObject _oOthText16;

	private GameObject _oOthText17;

	private GameObject _oOthText18;

	private GameObject _oOthText19;

	private GameObject _oOthText20;

	private Text _oOthTextText1;

	private Text _oOthTextText2;

	private Text _oOthTextText3;

	private Text _oOthTextText4;

	private Text _oOthTextText5;

	private Text _oOthTextText6;

	private Text _oOthTextText7;

	private Text _oOthTextText8;

	private Text _oOthTextText9;

	private Text _oOthTextText10;

	private Text _oOthTextText11;

	private Text _oOthTextText12;

	private Text _oOthTextText13;

	private Text _oOthTextText14;

	private Text _oOthTextText15;

	private Text _oOthTextText16;

	private Text _oOthTextText17;

	private Text _oOthTextText18;

	private Text _oOthTextText19;

	private Text _oOthTextText20;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/newescapemodel";

	private string _resourceAssetName = "newescapetop";

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

	public bool OthPosShow1
	{
		get
		{
			if (_oOthPos1 != null)
			{
				return _oOthPos1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow1 != value && _oOthPos1 != null)
			{
				_oOthPos1.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow2
	{
		get
		{
			if (_oOthPos2 != null)
			{
				return _oOthPos2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow2 != value && _oOthPos2 != null)
			{
				_oOthPos2.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow3
	{
		get
		{
			if (_oOthPos3 != null)
			{
				return _oOthPos3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow3 != value && _oOthPos3 != null)
			{
				_oOthPos3.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow4
	{
		get
		{
			if (_oOthPos4 != null)
			{
				return _oOthPos4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow4 != value && _oOthPos4 != null)
			{
				_oOthPos4.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow5
	{
		get
		{
			if (_oOthPos5 != null)
			{
				return _oOthPos5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow5 != value && _oOthPos5 != null)
			{
				_oOthPos5.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow6
	{
		get
		{
			if (_oOthPos6 != null)
			{
				return _oOthPos6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow6 != value && _oOthPos6 != null)
			{
				_oOthPos6.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow7
	{
		get
		{
			if (_oOthPos7 != null)
			{
				return _oOthPos7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow7 != value && _oOthPos7 != null)
			{
				_oOthPos7.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow8
	{
		get
		{
			if (_oOthPos8 != null)
			{
				return _oOthPos8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow8 != value && _oOthPos8 != null)
			{
				_oOthPos8.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow9
	{
		get
		{
			if (_oOthPos9 != null)
			{
				return _oOthPos9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow9 != value && _oOthPos9 != null)
			{
				_oOthPos9.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow10
	{
		get
		{
			if (_oOthPos10 != null)
			{
				return _oOthPos10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow10 != value && _oOthPos10 != null)
			{
				_oOthPos10.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow11
	{
		get
		{
			if (_oOthPos11 != null)
			{
				return _oOthPos11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow11 != value && _oOthPos11 != null)
			{
				_oOthPos11.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow12
	{
		get
		{
			if (_oOthPos12 != null)
			{
				return _oOthPos12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow12 != value && _oOthPos12 != null)
			{
				_oOthPos12.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow13
	{
		get
		{
			if (_oOthPos13 != null)
			{
				return _oOthPos13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow13 != value && _oOthPos13 != null)
			{
				_oOthPos13.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow14
	{
		get
		{
			if (_oOthPos14 != null)
			{
				return _oOthPos14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow14 != value && _oOthPos14 != null)
			{
				_oOthPos14.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow15
	{
		get
		{
			if (_oOthPos15 != null)
			{
				return _oOthPos15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow15 != value && _oOthPos15 != null)
			{
				_oOthPos15.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow16
	{
		get
		{
			if (_oOthPos16 != null)
			{
				return _oOthPos16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow16 != value && _oOthPos16 != null)
			{
				_oOthPos16.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow17
	{
		get
		{
			if (_oOthPos17 != null)
			{
				return _oOthPos17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow17 != value && _oOthPos17 != null)
			{
				_oOthPos17.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow18
	{
		get
		{
			if (_oOthPos18 != null)
			{
				return _oOthPos18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow18 != value && _oOthPos18 != null)
			{
				_oOthPos18.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow19
	{
		get
		{
			if (_oOthPos19 != null)
			{
				return _oOthPos19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow19 != value && _oOthPos19 != null)
			{
				_oOthPos19.SetObjectActive(value);
			}
		}
	}

	public bool OthPosShow20
	{
		get
		{
			if (_oOthPos20 != null)
			{
				return _oOthPos20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosShow20 != value && _oOthPos20 != null)
			{
				_oOthPos20.SetObjectActive(value);
			}
		}
	}

	public Sprite OthPosSprite1
	{
		get
		{
			if (_oOthPosImage1 != null)
			{
				return _oOthPosImage1.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite1 != value && _oOthPosImage1 != null)
			{
				_oOthPosImage1.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite2
	{
		get
		{
			if (_oOthPosImage2 != null)
			{
				return _oOthPosImage2.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite2 != value && _oOthPosImage2 != null)
			{
				_oOthPosImage2.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite3
	{
		get
		{
			if (_oOthPosImage3 != null)
			{
				return _oOthPosImage3.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite3 != value && _oOthPosImage3 != null)
			{
				_oOthPosImage3.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite4
	{
		get
		{
			if (_oOthPosImage4 != null)
			{
				return _oOthPosImage4.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite4 != value && _oOthPosImage4 != null)
			{
				_oOthPosImage4.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite5
	{
		get
		{
			if (_oOthPosImage5 != null)
			{
				return _oOthPosImage5.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite5 != value && _oOthPosImage5 != null)
			{
				_oOthPosImage5.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite6
	{
		get
		{
			if (_oOthPosImage6 != null)
			{
				return _oOthPosImage6.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite6 != value && _oOthPosImage6 != null)
			{
				_oOthPosImage6.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite7
	{
		get
		{
			if (_oOthPosImage7 != null)
			{
				return _oOthPosImage7.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite7 != value && _oOthPosImage7 != null)
			{
				_oOthPosImage7.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite8
	{
		get
		{
			if (_oOthPosImage8 != null)
			{
				return _oOthPosImage8.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite8 != value && _oOthPosImage8 != null)
			{
				_oOthPosImage8.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite9
	{
		get
		{
			if (_oOthPosImage9 != null)
			{
				return _oOthPosImage9.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite9 != value && _oOthPosImage9 != null)
			{
				_oOthPosImage9.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite10
	{
		get
		{
			if (_oOthPosImage10 != null)
			{
				return _oOthPosImage10.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite10 != value && _oOthPosImage10 != null)
			{
				_oOthPosImage10.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite11
	{
		get
		{
			if (_oOthPosImage11 != null)
			{
				return _oOthPosImage11.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite11 != value && _oOthPosImage11 != null)
			{
				_oOthPosImage11.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite12
	{
		get
		{
			if (_oOthPosImage12 != null)
			{
				return _oOthPosImage12.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite12 != value && _oOthPosImage12 != null)
			{
				_oOthPosImage12.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite13
	{
		get
		{
			if (_oOthPosImage13 != null)
			{
				return _oOthPosImage13.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite13 != value && _oOthPosImage13 != null)
			{
				_oOthPosImage13.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite14
	{
		get
		{
			if (_oOthPosImage14 != null)
			{
				return _oOthPosImage14.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite14 != value && _oOthPosImage14 != null)
			{
				_oOthPosImage14.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite15
	{
		get
		{
			if (_oOthPosImage15 != null)
			{
				return _oOthPosImage15.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite15 != value && _oOthPosImage15 != null)
			{
				_oOthPosImage15.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite16
	{
		get
		{
			if (_oOthPosImage16 != null)
			{
				return _oOthPosImage16.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite16 != value && _oOthPosImage16 != null)
			{
				_oOthPosImage16.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite17
	{
		get
		{
			if (_oOthPosImage17 != null)
			{
				return _oOthPosImage17.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite17 != value && _oOthPosImage17 != null)
			{
				_oOthPosImage17.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite18
	{
		get
		{
			if (_oOthPosImage18 != null)
			{
				return _oOthPosImage18.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite18 != value && _oOthPosImage18 != null)
			{
				_oOthPosImage18.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite19
	{
		get
		{
			if (_oOthPosImage19 != null)
			{
				return _oOthPosImage19.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite19 != value && _oOthPosImage19 != null)
			{
				_oOthPosImage19.sprite = value;
			}
		}
	}

	public Sprite OthPosSprite20
	{
		get
		{
			if (_oOthPosImage20 != null)
			{
				return _oOthPosImage20.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosSprite20 != value && _oOthPosImage20 != null)
			{
				_oOthPosImage20.sprite = value;
			}
		}
	}

	public Image OthPosImage1
	{
		get
		{
			if (_oOthPosImage1 != null)
			{
				return _oOthPosImage1;
			}
			return null;
		}
		set
		{
			if (OthPosImage1 != value && _oOthPosImage1 != null)
			{
				_oOthPosImage1 = value;
			}
		}
	}

	public Image OthPosImage2
	{
		get
		{
			if (_oOthPosImage2 != null)
			{
				return _oOthPosImage2;
			}
			return null;
		}
		set
		{
			if (OthPosImage2 != value && _oOthPosImage2 != null)
			{
				_oOthPosImage2 = value;
			}
		}
	}

	public Image OthPosImage3
	{
		get
		{
			if (_oOthPosImage3 != null)
			{
				return _oOthPosImage3;
			}
			return null;
		}
		set
		{
			if (OthPosImage3 != value && _oOthPosImage3 != null)
			{
				_oOthPosImage3 = value;
			}
		}
	}

	public Image OthPosImage4
	{
		get
		{
			if (_oOthPosImage4 != null)
			{
				return _oOthPosImage4;
			}
			return null;
		}
		set
		{
			if (OthPosImage4 != value && _oOthPosImage4 != null)
			{
				_oOthPosImage4 = value;
			}
		}
	}

	public Image OthPosImage5
	{
		get
		{
			if (_oOthPosImage5 != null)
			{
				return _oOthPosImage5;
			}
			return null;
		}
		set
		{
			if (OthPosImage5 != value && _oOthPosImage5 != null)
			{
				_oOthPosImage5 = value;
			}
		}
	}

	public Image OthPosImage6
	{
		get
		{
			if (_oOthPosImage6 != null)
			{
				return _oOthPosImage6;
			}
			return null;
		}
		set
		{
			if (OthPosImage6 != value && _oOthPosImage6 != null)
			{
				_oOthPosImage6 = value;
			}
		}
	}

	public Image OthPosImage7
	{
		get
		{
			if (_oOthPosImage7 != null)
			{
				return _oOthPosImage7;
			}
			return null;
		}
		set
		{
			if (OthPosImage7 != value && _oOthPosImage7 != null)
			{
				_oOthPosImage7 = value;
			}
		}
	}

	public Image OthPosImage8
	{
		get
		{
			if (_oOthPosImage8 != null)
			{
				return _oOthPosImage8;
			}
			return null;
		}
		set
		{
			if (OthPosImage8 != value && _oOthPosImage8 != null)
			{
				_oOthPosImage8 = value;
			}
		}
	}

	public Image OthPosImage9
	{
		get
		{
			if (_oOthPosImage9 != null)
			{
				return _oOthPosImage9;
			}
			return null;
		}
		set
		{
			if (OthPosImage9 != value && _oOthPosImage9 != null)
			{
				_oOthPosImage9 = value;
			}
		}
	}

	public Image OthPosImage10
	{
		get
		{
			if (_oOthPosImage10 != null)
			{
				return _oOthPosImage10;
			}
			return null;
		}
		set
		{
			if (OthPosImage10 != value && _oOthPosImage10 != null)
			{
				_oOthPosImage10 = value;
			}
		}
	}

	public Image OthPosImage11
	{
		get
		{
			if (_oOthPosImage11 != null)
			{
				return _oOthPosImage11;
			}
			return null;
		}
		set
		{
			if (OthPosImage11 != value && _oOthPosImage11 != null)
			{
				_oOthPosImage11 = value;
			}
		}
	}

	public Image OthPosImage12
	{
		get
		{
			if (_oOthPosImage12 != null)
			{
				return _oOthPosImage12;
			}
			return null;
		}
		set
		{
			if (OthPosImage12 != value && _oOthPosImage12 != null)
			{
				_oOthPosImage12 = value;
			}
		}
	}

	public Image OthPosImage13
	{
		get
		{
			if (_oOthPosImage13 != null)
			{
				return _oOthPosImage13;
			}
			return null;
		}
		set
		{
			if (OthPosImage13 != value && _oOthPosImage13 != null)
			{
				_oOthPosImage13 = value;
			}
		}
	}

	public Image OthPosImage14
	{
		get
		{
			if (_oOthPosImage14 != null)
			{
				return _oOthPosImage14;
			}
			return null;
		}
		set
		{
			if (OthPosImage14 != value && _oOthPosImage14 != null)
			{
				_oOthPosImage14 = value;
			}
		}
	}

	public Image OthPosImage15
	{
		get
		{
			if (_oOthPosImage15 != null)
			{
				return _oOthPosImage15;
			}
			return null;
		}
		set
		{
			if (OthPosImage15 != value && _oOthPosImage15 != null)
			{
				_oOthPosImage15 = value;
			}
		}
	}

	public Image OthPosImage16
	{
		get
		{
			if (_oOthPosImage16 != null)
			{
				return _oOthPosImage16;
			}
			return null;
		}
		set
		{
			if (OthPosImage16 != value && _oOthPosImage16 != null)
			{
				_oOthPosImage16 = value;
			}
		}
	}

	public Image OthPosImage17
	{
		get
		{
			if (_oOthPosImage17 != null)
			{
				return _oOthPosImage17;
			}
			return null;
		}
		set
		{
			if (OthPosImage17 != value && _oOthPosImage17 != null)
			{
				_oOthPosImage17 = value;
			}
		}
	}

	public Image OthPosImage18
	{
		get
		{
			if (_oOthPosImage18 != null)
			{
				return _oOthPosImage18;
			}
			return null;
		}
		set
		{
			if (OthPosImage18 != value && _oOthPosImage18 != null)
			{
				_oOthPosImage18 = value;
			}
		}
	}

	public Image OthPosImage19
	{
		get
		{
			if (_oOthPosImage19 != null)
			{
				return _oOthPosImage19;
			}
			return null;
		}
		set
		{
			if (OthPosImage19 != value && _oOthPosImage19 != null)
			{
				_oOthPosImage19 = value;
			}
		}
	}

	public Image OthPosImage20
	{
		get
		{
			if (_oOthPosImage20 != null)
			{
				return _oOthPosImage20;
			}
			return null;
		}
		set
		{
			if (OthPosImage20 != value && _oOthPosImage20 != null)
			{
				_oOthPosImage20 = value;
			}
		}
	}

	public string OthTexString1
	{
		get
		{
			if (_oOthTexText1 != null)
			{
				return _oOthTexText1.text;
			}
			return null;
		}
		set
		{
			if (OthTexString1 != value && _oOthTexText1 != null)
			{
				_oOthTexText1.text = value;
			}
		}
	}

	public string OthTexString2
	{
		get
		{
			if (_oOthTexText2 != null)
			{
				return _oOthTexText2.text;
			}
			return null;
		}
		set
		{
			if (OthTexString2 != value && _oOthTexText2 != null)
			{
				_oOthTexText2.text = value;
			}
		}
	}

	public string OthTexString3
	{
		get
		{
			if (_oOthTexText3 != null)
			{
				return _oOthTexText3.text;
			}
			return null;
		}
		set
		{
			if (OthTexString3 != value && _oOthTexText3 != null)
			{
				_oOthTexText3.text = value;
			}
		}
	}

	public string OthTexString4
	{
		get
		{
			if (_oOthTexText4 != null)
			{
				return _oOthTexText4.text;
			}
			return null;
		}
		set
		{
			if (OthTexString4 != value && _oOthTexText4 != null)
			{
				_oOthTexText4.text = value;
			}
		}
	}

	public string OthTexString5
	{
		get
		{
			if (_oOthTexText5 != null)
			{
				return _oOthTexText5.text;
			}
			return null;
		}
		set
		{
			if (OthTexString5 != value && _oOthTexText5 != null)
			{
				_oOthTexText5.text = value;
			}
		}
	}

	public string OthTexString6
	{
		get
		{
			if (_oOthTexText6 != null)
			{
				return _oOthTexText6.text;
			}
			return null;
		}
		set
		{
			if (OthTexString6 != value && _oOthTexText6 != null)
			{
				_oOthTexText6.text = value;
			}
		}
	}

	public string OthTexString7
	{
		get
		{
			if (_oOthTexText7 != null)
			{
				return _oOthTexText7.text;
			}
			return null;
		}
		set
		{
			if (OthTexString7 != value && _oOthTexText7 != null)
			{
				_oOthTexText7.text = value;
			}
		}
	}

	public string OthTexString8
	{
		get
		{
			if (_oOthTexText8 != null)
			{
				return _oOthTexText8.text;
			}
			return null;
		}
		set
		{
			if (OthTexString8 != value && _oOthTexText8 != null)
			{
				_oOthTexText8.text = value;
			}
		}
	}

	public string OthTexString9
	{
		get
		{
			if (_oOthTexText9 != null)
			{
				return _oOthTexText9.text;
			}
			return null;
		}
		set
		{
			if (OthTexString9 != value && _oOthTexText9 != null)
			{
				_oOthTexText9.text = value;
			}
		}
	}

	public string OthTexString10
	{
		get
		{
			if (_oOthTexText10 != null)
			{
				return _oOthTexText10.text;
			}
			return null;
		}
		set
		{
			if (OthTexString10 != value && _oOthTexText10 != null)
			{
				_oOthTexText10.text = value;
			}
		}
	}

	public string OthTexString11
	{
		get
		{
			if (_oOthTexText11 != null)
			{
				return _oOthTexText11.text;
			}
			return null;
		}
		set
		{
			if (OthTexString11 != value && _oOthTexText11 != null)
			{
				_oOthTexText11.text = value;
			}
		}
	}

	public string OthTexString12
	{
		get
		{
			if (_oOthTexText12 != null)
			{
				return _oOthTexText12.text;
			}
			return null;
		}
		set
		{
			if (OthTexString12 != value && _oOthTexText12 != null)
			{
				_oOthTexText12.text = value;
			}
		}
	}

	public string OthTexString13
	{
		get
		{
			if (_oOthTexText13 != null)
			{
				return _oOthTexText13.text;
			}
			return null;
		}
		set
		{
			if (OthTexString13 != value && _oOthTexText13 != null)
			{
				_oOthTexText13.text = value;
			}
		}
	}

	public string OthTexString14
	{
		get
		{
			if (_oOthTexText14 != null)
			{
				return _oOthTexText14.text;
			}
			return null;
		}
		set
		{
			if (OthTexString14 != value && _oOthTexText14 != null)
			{
				_oOthTexText14.text = value;
			}
		}
	}

	public string OthTexString15
	{
		get
		{
			if (_oOthTexText15 != null)
			{
				return _oOthTexText15.text;
			}
			return null;
		}
		set
		{
			if (OthTexString15 != value && _oOthTexText15 != null)
			{
				_oOthTexText15.text = value;
			}
		}
	}

	public string OthTexString16
	{
		get
		{
			if (_oOthTexText16 != null)
			{
				return _oOthTexText16.text;
			}
			return null;
		}
		set
		{
			if (OthTexString16 != value && _oOthTexText16 != null)
			{
				_oOthTexText16.text = value;
			}
		}
	}

	public string OthTexString17
	{
		get
		{
			if (_oOthTexText17 != null)
			{
				return _oOthTexText17.text;
			}
			return null;
		}
		set
		{
			if (OthTexString17 != value && _oOthTexText17 != null)
			{
				_oOthTexText17.text = value;
			}
		}
	}

	public string OthTexString18
	{
		get
		{
			if (_oOthTexText18 != null)
			{
				return _oOthTexText18.text;
			}
			return null;
		}
		set
		{
			if (OthTexString18 != value && _oOthTexText18 != null)
			{
				_oOthTexText18.text = value;
			}
		}
	}

	public string OthTexString19
	{
		get
		{
			if (_oOthTexText19 != null)
			{
				return _oOthTexText19.text;
			}
			return null;
		}
		set
		{
			if (OthTexString19 != value && _oOthTexText19 != null)
			{
				_oOthTexText19.text = value;
			}
		}
	}

	public string OthTexString20
	{
		get
		{
			if (_oOthTexText20 != null)
			{
				return _oOthTexText20.text;
			}
			return null;
		}
		set
		{
			if (OthTexString20 != value && _oOthTexText20 != null)
			{
				_oOthTexText20.text = value;
			}
		}
	}

	public bool OthPosPosShow1
	{
		get
		{
			if (_oOthPosPos1 != null)
			{
				return _oOthPosPos1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow1 != value && _oOthPosPos1 != null)
			{
				_oOthPosPos1.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow2
	{
		get
		{
			if (_oOthPosPos2 != null)
			{
				return _oOthPosPos2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow2 != value && _oOthPosPos2 != null)
			{
				_oOthPosPos2.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow3
	{
		get
		{
			if (_oOthPosPos3 != null)
			{
				return _oOthPosPos3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow3 != value && _oOthPosPos3 != null)
			{
				_oOthPosPos3.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow4
	{
		get
		{
			if (_oOthPosPos4 != null)
			{
				return _oOthPosPos4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow4 != value && _oOthPosPos4 != null)
			{
				_oOthPosPos4.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow5
	{
		get
		{
			if (_oOthPosPos5 != null)
			{
				return _oOthPosPos5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow5 != value && _oOthPosPos5 != null)
			{
				_oOthPosPos5.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow6
	{
		get
		{
			if (_oOthPosPos6 != null)
			{
				return _oOthPosPos6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow6 != value && _oOthPosPos6 != null)
			{
				_oOthPosPos6.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow7
	{
		get
		{
			if (_oOthPosPos7 != null)
			{
				return _oOthPosPos7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow7 != value && _oOthPosPos7 != null)
			{
				_oOthPosPos7.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow8
	{
		get
		{
			if (_oOthPosPos8 != null)
			{
				return _oOthPosPos8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow8 != value && _oOthPosPos8 != null)
			{
				_oOthPosPos8.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow9
	{
		get
		{
			if (_oOthPosPos9 != null)
			{
				return _oOthPosPos9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow9 != value && _oOthPosPos9 != null)
			{
				_oOthPosPos9.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow10
	{
		get
		{
			if (_oOthPosPos10 != null)
			{
				return _oOthPosPos10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow10 != value && _oOthPosPos10 != null)
			{
				_oOthPosPos10.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow11
	{
		get
		{
			if (_oOthPosPos11 != null)
			{
				return _oOthPosPos11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow11 != value && _oOthPosPos11 != null)
			{
				_oOthPosPos11.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow12
	{
		get
		{
			if (_oOthPosPos12 != null)
			{
				return _oOthPosPos12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow12 != value && _oOthPosPos12 != null)
			{
				_oOthPosPos12.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow13
	{
		get
		{
			if (_oOthPosPos13 != null)
			{
				return _oOthPosPos13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow13 != value && _oOthPosPos13 != null)
			{
				_oOthPosPos13.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow14
	{
		get
		{
			if (_oOthPosPos14 != null)
			{
				return _oOthPosPos14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow14 != value && _oOthPosPos14 != null)
			{
				_oOthPosPos14.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow15
	{
		get
		{
			if (_oOthPosPos15 != null)
			{
				return _oOthPosPos15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow15 != value && _oOthPosPos15 != null)
			{
				_oOthPosPos15.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow16
	{
		get
		{
			if (_oOthPosPos16 != null)
			{
				return _oOthPosPos16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow16 != value && _oOthPosPos16 != null)
			{
				_oOthPosPos16.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow17
	{
		get
		{
			if (_oOthPosPos17 != null)
			{
				return _oOthPosPos17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow17 != value && _oOthPosPos17 != null)
			{
				_oOthPosPos17.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow18
	{
		get
		{
			if (_oOthPosPos18 != null)
			{
				return _oOthPosPos18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow18 != value && _oOthPosPos18 != null)
			{
				_oOthPosPos18.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow19
	{
		get
		{
			if (_oOthPosPos19 != null)
			{
				return _oOthPosPos19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow19 != value && _oOthPosPos19 != null)
			{
				_oOthPosPos19.SetObjectActive(value);
			}
		}
	}

	public bool OthPosPosShow20
	{
		get
		{
			if (_oOthPosPos20 != null)
			{
				return _oOthPosPos20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (OthPosPosShow20 != value && _oOthPosPos20 != null)
			{
				_oOthPosPos20.SetObjectActive(value);
			}
		}
	}

	public Sprite OthPosPosSprite1
	{
		get
		{
			if (_oOthPosPosImage1 != null)
			{
				return _oOthPosPosImage1.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite1 != value && _oOthPosPosImage1 != null)
			{
				_oOthPosPosImage1.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite2
	{
		get
		{
			if (_oOthPosPosImage2 != null)
			{
				return _oOthPosPosImage2.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite2 != value && _oOthPosPosImage2 != null)
			{
				_oOthPosPosImage2.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite3
	{
		get
		{
			if (_oOthPosPosImage3 != null)
			{
				return _oOthPosPosImage3.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite3 != value && _oOthPosPosImage3 != null)
			{
				_oOthPosPosImage3.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite4
	{
		get
		{
			if (_oOthPosPosImage4 != null)
			{
				return _oOthPosPosImage4.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite4 != value && _oOthPosPosImage4 != null)
			{
				_oOthPosPosImage4.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite5
	{
		get
		{
			if (_oOthPosPosImage5 != null)
			{
				return _oOthPosPosImage5.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite5 != value && _oOthPosPosImage5 != null)
			{
				_oOthPosPosImage5.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite6
	{
		get
		{
			if (_oOthPosPosImage6 != null)
			{
				return _oOthPosPosImage6.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite6 != value && _oOthPosPosImage6 != null)
			{
				_oOthPosPosImage6.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite7
	{
		get
		{
			if (_oOthPosPosImage7 != null)
			{
				return _oOthPosPosImage7.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite7 != value && _oOthPosPosImage7 != null)
			{
				_oOthPosPosImage7.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite8
	{
		get
		{
			if (_oOthPosPosImage8 != null)
			{
				return _oOthPosPosImage8.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite8 != value && _oOthPosPosImage8 != null)
			{
				_oOthPosPosImage8.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite9
	{
		get
		{
			if (_oOthPosPosImage9 != null)
			{
				return _oOthPosPosImage9.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite9 != value && _oOthPosPosImage9 != null)
			{
				_oOthPosPosImage9.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite10
	{
		get
		{
			if (_oOthPosPosImage10 != null)
			{
				return _oOthPosPosImage10.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite10 != value && _oOthPosPosImage10 != null)
			{
				_oOthPosPosImage10.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite11
	{
		get
		{
			if (_oOthPosPosImage11 != null)
			{
				return _oOthPosPosImage11.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite11 != value && _oOthPosPosImage11 != null)
			{
				_oOthPosPosImage11.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite12
	{
		get
		{
			if (_oOthPosPosImage12 != null)
			{
				return _oOthPosPosImage12.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite12 != value && _oOthPosPosImage12 != null)
			{
				_oOthPosPosImage12.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite13
	{
		get
		{
			if (_oOthPosPosImage13 != null)
			{
				return _oOthPosPosImage13.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite13 != value && _oOthPosPosImage13 != null)
			{
				_oOthPosPosImage13.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite14
	{
		get
		{
			if (_oOthPosPosImage14 != null)
			{
				return _oOthPosPosImage14.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite14 != value && _oOthPosPosImage14 != null)
			{
				_oOthPosPosImage14.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite15
	{
		get
		{
			if (_oOthPosPosImage15 != null)
			{
				return _oOthPosPosImage15.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite15 != value && _oOthPosPosImage15 != null)
			{
				_oOthPosPosImage15.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite16
	{
		get
		{
			if (_oOthPosPosImage16 != null)
			{
				return _oOthPosPosImage16.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite16 != value && _oOthPosPosImage16 != null)
			{
				_oOthPosPosImage16.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite17
	{
		get
		{
			if (_oOthPosPosImage17 != null)
			{
				return _oOthPosPosImage17.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite17 != value && _oOthPosPosImage17 != null)
			{
				_oOthPosPosImage17.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite18
	{
		get
		{
			if (_oOthPosPosImage18 != null)
			{
				return _oOthPosPosImage18.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite18 != value && _oOthPosPosImage18 != null)
			{
				_oOthPosPosImage18.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite19
	{
		get
		{
			if (_oOthPosPosImage19 != null)
			{
				return _oOthPosPosImage19.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite19 != value && _oOthPosPosImage19 != null)
			{
				_oOthPosPosImage19.sprite = value;
			}
		}
	}

	public Sprite OthPosPosSprite20
	{
		get
		{
			if (_oOthPosPosImage20 != null)
			{
				return _oOthPosPosImage20.sprite;
			}
			return null;
		}
		set
		{
			if (OthPosPosSprite20 != value && _oOthPosPosImage20 != null)
			{
				_oOthPosPosImage20.sprite = value;
			}
		}
	}

	public Image OthPosPosImage1
	{
		get
		{
			if (_oOthPosPosImage1 != null)
			{
				return _oOthPosPosImage1;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage1 != value && _oOthPosPosImage1 != null)
			{
				_oOthPosPosImage1 = value;
			}
		}
	}

	public Image OthPosPosImage2
	{
		get
		{
			if (_oOthPosPosImage2 != null)
			{
				return _oOthPosPosImage2;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage2 != value && _oOthPosPosImage2 != null)
			{
				_oOthPosPosImage2 = value;
			}
		}
	}

	public Image OthPosPosImage3
	{
		get
		{
			if (_oOthPosPosImage3 != null)
			{
				return _oOthPosPosImage3;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage3 != value && _oOthPosPosImage3 != null)
			{
				_oOthPosPosImage3 = value;
			}
		}
	}

	public Image OthPosPosImage4
	{
		get
		{
			if (_oOthPosPosImage4 != null)
			{
				return _oOthPosPosImage4;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage4 != value && _oOthPosPosImage4 != null)
			{
				_oOthPosPosImage4 = value;
			}
		}
	}

	public Image OthPosPosImage5
	{
		get
		{
			if (_oOthPosPosImage5 != null)
			{
				return _oOthPosPosImage5;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage5 != value && _oOthPosPosImage5 != null)
			{
				_oOthPosPosImage5 = value;
			}
		}
	}

	public Image OthPosPosImage6
	{
		get
		{
			if (_oOthPosPosImage6 != null)
			{
				return _oOthPosPosImage6;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage6 != value && _oOthPosPosImage6 != null)
			{
				_oOthPosPosImage6 = value;
			}
		}
	}

	public Image OthPosPosImage7
	{
		get
		{
			if (_oOthPosPosImage7 != null)
			{
				return _oOthPosPosImage7;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage7 != value && _oOthPosPosImage7 != null)
			{
				_oOthPosPosImage7 = value;
			}
		}
	}

	public Image OthPosPosImage8
	{
		get
		{
			if (_oOthPosPosImage8 != null)
			{
				return _oOthPosPosImage8;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage8 != value && _oOthPosPosImage8 != null)
			{
				_oOthPosPosImage8 = value;
			}
		}
	}

	public Image OthPosPosImage9
	{
		get
		{
			if (_oOthPosPosImage9 != null)
			{
				return _oOthPosPosImage9;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage9 != value && _oOthPosPosImage9 != null)
			{
				_oOthPosPosImage9 = value;
			}
		}
	}

	public Image OthPosPosImage10
	{
		get
		{
			if (_oOthPosPosImage10 != null)
			{
				return _oOthPosPosImage10;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage10 != value && _oOthPosPosImage10 != null)
			{
				_oOthPosPosImage10 = value;
			}
		}
	}

	public Image OthPosPosImage11
	{
		get
		{
			if (_oOthPosPosImage11 != null)
			{
				return _oOthPosPosImage11;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage11 != value && _oOthPosPosImage11 != null)
			{
				_oOthPosPosImage11 = value;
			}
		}
	}

	public Image OthPosPosImage12
	{
		get
		{
			if (_oOthPosPosImage12 != null)
			{
				return _oOthPosPosImage12;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage12 != value && _oOthPosPosImage12 != null)
			{
				_oOthPosPosImage12 = value;
			}
		}
	}

	public Image OthPosPosImage13
	{
		get
		{
			if (_oOthPosPosImage13 != null)
			{
				return _oOthPosPosImage13;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage13 != value && _oOthPosPosImage13 != null)
			{
				_oOthPosPosImage13 = value;
			}
		}
	}

	public Image OthPosPosImage14
	{
		get
		{
			if (_oOthPosPosImage14 != null)
			{
				return _oOthPosPosImage14;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage14 != value && _oOthPosPosImage14 != null)
			{
				_oOthPosPosImage14 = value;
			}
		}
	}

	public Image OthPosPosImage15
	{
		get
		{
			if (_oOthPosPosImage15 != null)
			{
				return _oOthPosPosImage15;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage15 != value && _oOthPosPosImage15 != null)
			{
				_oOthPosPosImage15 = value;
			}
		}
	}

	public Image OthPosPosImage16
	{
		get
		{
			if (_oOthPosPosImage16 != null)
			{
				return _oOthPosPosImage16;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage16 != value && _oOthPosPosImage16 != null)
			{
				_oOthPosPosImage16 = value;
			}
		}
	}

	public Image OthPosPosImage17
	{
		get
		{
			if (_oOthPosPosImage17 != null)
			{
				return _oOthPosPosImage17;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage17 != value && _oOthPosPosImage17 != null)
			{
				_oOthPosPosImage17 = value;
			}
		}
	}

	public Image OthPosPosImage18
	{
		get
		{
			if (_oOthPosPosImage18 != null)
			{
				return _oOthPosPosImage18;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage18 != value && _oOthPosPosImage18 != null)
			{
				_oOthPosPosImage18 = value;
			}
		}
	}

	public Image OthPosPosImage19
	{
		get
		{
			if (_oOthPosPosImage19 != null)
			{
				return _oOthPosPosImage19;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage19 != value && _oOthPosPosImage19 != null)
			{
				_oOthPosPosImage19 = value;
			}
		}
	}

	public Image OthPosPosImage20
	{
		get
		{
			if (_oOthPosPosImage20 != null)
			{
				return _oOthPosPosImage20;
			}
			return null;
		}
		set
		{
			if (OthPosPosImage20 != value && _oOthPosPosImage20 != null)
			{
				_oOthPosPosImage20 = value;
			}
		}
	}

	public string OthTextString1
	{
		get
		{
			if (_oOthTextText1 != null)
			{
				return _oOthTextText1.text;
			}
			return null;
		}
		set
		{
			if (OthTextString1 != value && _oOthTextText1 != null)
			{
				_oOthTextText1.text = value;
			}
		}
	}

	public string OthTextString2
	{
		get
		{
			if (_oOthTextText2 != null)
			{
				return _oOthTextText2.text;
			}
			return null;
		}
		set
		{
			if (OthTextString2 != value && _oOthTextText2 != null)
			{
				_oOthTextText2.text = value;
			}
		}
	}

	public string OthTextString3
	{
		get
		{
			if (_oOthTextText3 != null)
			{
				return _oOthTextText3.text;
			}
			return null;
		}
		set
		{
			if (OthTextString3 != value && _oOthTextText3 != null)
			{
				_oOthTextText3.text = value;
			}
		}
	}

	public string OthTextString4
	{
		get
		{
			if (_oOthTextText4 != null)
			{
				return _oOthTextText4.text;
			}
			return null;
		}
		set
		{
			if (OthTextString4 != value && _oOthTextText4 != null)
			{
				_oOthTextText4.text = value;
			}
		}
	}

	public string OthTextString5
	{
		get
		{
			if (_oOthTextText5 != null)
			{
				return _oOthTextText5.text;
			}
			return null;
		}
		set
		{
			if (OthTextString5 != value && _oOthTextText5 != null)
			{
				_oOthTextText5.text = value;
			}
		}
	}

	public string OthTextString6
	{
		get
		{
			if (_oOthTextText6 != null)
			{
				return _oOthTextText6.text;
			}
			return null;
		}
		set
		{
			if (OthTextString6 != value && _oOthTextText6 != null)
			{
				_oOthTextText6.text = value;
			}
		}
	}

	public string OthTextString7
	{
		get
		{
			if (_oOthTextText7 != null)
			{
				return _oOthTextText7.text;
			}
			return null;
		}
		set
		{
			if (OthTextString7 != value && _oOthTextText7 != null)
			{
				_oOthTextText7.text = value;
			}
		}
	}

	public string OthTextString8
	{
		get
		{
			if (_oOthTextText8 != null)
			{
				return _oOthTextText8.text;
			}
			return null;
		}
		set
		{
			if (OthTextString8 != value && _oOthTextText8 != null)
			{
				_oOthTextText8.text = value;
			}
		}
	}

	public string OthTextString9
	{
		get
		{
			if (_oOthTextText9 != null)
			{
				return _oOthTextText9.text;
			}
			return null;
		}
		set
		{
			if (OthTextString9 != value && _oOthTextText9 != null)
			{
				_oOthTextText9.text = value;
			}
		}
	}

	public string OthTextString10
	{
		get
		{
			if (_oOthTextText10 != null)
			{
				return _oOthTextText10.text;
			}
			return null;
		}
		set
		{
			if (OthTextString10 != value && _oOthTextText10 != null)
			{
				_oOthTextText10.text = value;
			}
		}
	}

	public string OthTextString11
	{
		get
		{
			if (_oOthTextText11 != null)
			{
				return _oOthTextText11.text;
			}
			return null;
		}
		set
		{
			if (OthTextString11 != value && _oOthTextText11 != null)
			{
				_oOthTextText11.text = value;
			}
		}
	}

	public string OthTextString12
	{
		get
		{
			if (_oOthTextText12 != null)
			{
				return _oOthTextText12.text;
			}
			return null;
		}
		set
		{
			if (OthTextString12 != value && _oOthTextText12 != null)
			{
				_oOthTextText12.text = value;
			}
		}
	}

	public string OthTextString13
	{
		get
		{
			if (_oOthTextText13 != null)
			{
				return _oOthTextText13.text;
			}
			return null;
		}
		set
		{
			if (OthTextString13 != value && _oOthTextText13 != null)
			{
				_oOthTextText13.text = value;
			}
		}
	}

	public string OthTextString14
	{
		get
		{
			if (_oOthTextText14 != null)
			{
				return _oOthTextText14.text;
			}
			return null;
		}
		set
		{
			if (OthTextString14 != value && _oOthTextText14 != null)
			{
				_oOthTextText14.text = value;
			}
		}
	}

	public string OthTextString15
	{
		get
		{
			if (_oOthTextText15 != null)
			{
				return _oOthTextText15.text;
			}
			return null;
		}
		set
		{
			if (OthTextString15 != value && _oOthTextText15 != null)
			{
				_oOthTextText15.text = value;
			}
		}
	}

	public string OthTextString16
	{
		get
		{
			if (_oOthTextText16 != null)
			{
				return _oOthTextText16.text;
			}
			return null;
		}
		set
		{
			if (OthTextString16 != value && _oOthTextText16 != null)
			{
				_oOthTextText16.text = value;
			}
		}
	}

	public string OthTextString17
	{
		get
		{
			if (_oOthTextText17 != null)
			{
				return _oOthTextText17.text;
			}
			return null;
		}
		set
		{
			if (OthTextString17 != value && _oOthTextText17 != null)
			{
				_oOthTextText17.text = value;
			}
		}
	}

	public string OthTextString18
	{
		get
		{
			if (_oOthTextText18 != null)
			{
				return _oOthTextText18.text;
			}
			return null;
		}
		set
		{
			if (OthTextString18 != value && _oOthTextText18 != null)
			{
				_oOthTextText18.text = value;
			}
		}
	}

	public string OthTextString19
	{
		get
		{
			if (_oOthTextText19 != null)
			{
				return _oOthTextText19.text;
			}
			return null;
		}
		set
		{
			if (OthTextString19 != value && _oOthTextText19 != null)
			{
				_oOthTextText19.text = value;
			}
		}
	}

	public string OthTextString20
	{
		get
		{
			if (_oOthTextText20 != null)
			{
				return _oOthTextText20.text;
			}
			return null;
		}
		set
		{
			if (OthTextString20 != value && _oOthTextText20 != null)
			{
				_oOthTextText20.text = value;
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
			case "OthPos1":
				_oOthPos1 = transform.gameObject;
				_oOthPosImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos2":
				_oOthPos2 = transform.gameObject;
				_oOthPosImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos3":
				_oOthPos3 = transform.gameObject;
				_oOthPosImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos4":
				_oOthPos4 = transform.gameObject;
				_oOthPosImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos5":
				_oOthPos5 = transform.gameObject;
				_oOthPosImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos6":
				_oOthPos6 = transform.gameObject;
				_oOthPosImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos7":
				_oOthPos7 = transform.gameObject;
				_oOthPosImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos8":
				_oOthPos8 = transform.gameObject;
				_oOthPosImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos9":
				_oOthPos9 = transform.gameObject;
				_oOthPosImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos10":
				_oOthPos10 = transform.gameObject;
				_oOthPosImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos11":
				_oOthPos11 = transform.gameObject;
				_oOthPosImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos12":
				_oOthPos12 = transform.gameObject;
				_oOthPosImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos13":
				_oOthPos13 = transform.gameObject;
				_oOthPosImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos14":
				_oOthPos14 = transform.gameObject;
				_oOthPosImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos15":
				_oOthPos15 = transform.gameObject;
				_oOthPosImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos16":
				_oOthPos16 = transform.gameObject;
				_oOthPosImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos17":
				_oOthPos17 = transform.gameObject;
				_oOthPosImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos18":
				_oOthPos18 = transform.gameObject;
				_oOthPosImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos19":
				_oOthPos19 = transform.gameObject;
				_oOthPosImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPos20":
				_oOthPos20 = transform.gameObject;
				_oOthPosImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthTex1":
				_oOthTex1 = transform.gameObject;
				_oOthTexText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex2":
				_oOthTex2 = transform.gameObject;
				_oOthTexText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex3":
				_oOthTex3 = transform.gameObject;
				_oOthTexText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex4":
				_oOthTex4 = transform.gameObject;
				_oOthTexText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex5":
				_oOthTex5 = transform.gameObject;
				_oOthTexText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex6":
				_oOthTex6 = transform.gameObject;
				_oOthTexText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex7":
				_oOthTex7 = transform.gameObject;
				_oOthTexText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex8":
				_oOthTex8 = transform.gameObject;
				_oOthTexText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex9":
				_oOthTex9 = transform.gameObject;
				_oOthTexText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex10":
				_oOthTex10 = transform.gameObject;
				_oOthTexText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex11":
				_oOthTex11 = transform.gameObject;
				_oOthTexText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex12":
				_oOthTex12 = transform.gameObject;
				_oOthTexText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex13":
				_oOthTex13 = transform.gameObject;
				_oOthTexText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex14":
				_oOthTex14 = transform.gameObject;
				_oOthTexText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex15":
				_oOthTex15 = transform.gameObject;
				_oOthTexText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex16":
				_oOthTex16 = transform.gameObject;
				_oOthTexText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex17":
				_oOthTex17 = transform.gameObject;
				_oOthTexText17 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex18":
				_oOthTex18 = transform.gameObject;
				_oOthTexText18 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex19":
				_oOthTex19 = transform.gameObject;
				_oOthTexText19 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthTex20":
				_oOthTex20 = transform.gameObject;
				_oOthTexText20 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthPosPos1":
				_oOthPosPos1 = transform.gameObject;
				_oOthPosPosImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos2":
				_oOthPosPos2 = transform.gameObject;
				_oOthPosPosImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos3":
				_oOthPosPos3 = transform.gameObject;
				_oOthPosPosImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos4":
				_oOthPosPos4 = transform.gameObject;
				_oOthPosPosImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos5":
				_oOthPosPos5 = transform.gameObject;
				_oOthPosPosImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos6":
				_oOthPosPos6 = transform.gameObject;
				_oOthPosPosImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos7":
				_oOthPosPos7 = transform.gameObject;
				_oOthPosPosImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos8":
				_oOthPosPos8 = transform.gameObject;
				_oOthPosPosImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos9":
				_oOthPosPos9 = transform.gameObject;
				_oOthPosPosImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos10":
				_oOthPosPos10 = transform.gameObject;
				_oOthPosPosImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos11":
				_oOthPosPos11 = transform.gameObject;
				_oOthPosPosImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos12":
				_oOthPosPos12 = transform.gameObject;
				_oOthPosPosImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos13":
				_oOthPosPos13 = transform.gameObject;
				_oOthPosPosImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos14":
				_oOthPosPos14 = transform.gameObject;
				_oOthPosPosImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos15":
				_oOthPosPos15 = transform.gameObject;
				_oOthPosPosImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos16":
				_oOthPosPos16 = transform.gameObject;
				_oOthPosPosImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos17":
				_oOthPosPos17 = transform.gameObject;
				_oOthPosPosImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos18":
				_oOthPosPos18 = transform.gameObject;
				_oOthPosPosImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos19":
				_oOthPosPos19 = transform.gameObject;
				_oOthPosPosImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthPosPos20":
				_oOthPosPos20 = transform.gameObject;
				_oOthPosPosImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "OthText1":
				_oOthText1 = transform.gameObject;
				_oOthTextText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText2":
				_oOthText2 = transform.gameObject;
				_oOthTextText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText3":
				_oOthText3 = transform.gameObject;
				_oOthTextText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText4":
				_oOthText4 = transform.gameObject;
				_oOthTextText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText5":
				_oOthText5 = transform.gameObject;
				_oOthTextText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText6":
				_oOthText6 = transform.gameObject;
				_oOthTextText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText7":
				_oOthText7 = transform.gameObject;
				_oOthTextText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText8":
				_oOthText8 = transform.gameObject;
				_oOthTextText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText9":
				_oOthText9 = transform.gameObject;
				_oOthTextText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText10":
				_oOthText10 = transform.gameObject;
				_oOthTextText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText11":
				_oOthText11 = transform.gameObject;
				_oOthTextText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText12":
				_oOthText12 = transform.gameObject;
				_oOthTextText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText13":
				_oOthText13 = transform.gameObject;
				_oOthTextText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText14":
				_oOthText14 = transform.gameObject;
				_oOthTextText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText15":
				_oOthText15 = transform.gameObject;
				_oOthTextText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText16":
				_oOthText16 = transform.gameObject;
				_oOthTextText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText17":
				_oOthText17 = transform.gameObject;
				_oOthTextText17 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText18":
				_oOthText18 = transform.gameObject;
				_oOthTextText18 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText19":
				_oOthText19 = transform.gameObject;
				_oOthTextText19 = transform.gameObject.GetComponent<Text>();
				break;
			case "OthText20":
				_oOthText20 = transform.gameObject;
				_oOthTextText20 = transform.gameObject.GetComponent<Text>();
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

	public bool GetOthPosShow(int index)
	{
		return index switch
		{
			1 => OthPosShow1, 
			2 => OthPosShow2, 
			3 => OthPosShow3, 
			4 => OthPosShow4, 
			5 => OthPosShow5, 
			6 => OthPosShow6, 
			7 => OthPosShow7, 
			8 => OthPosShow8, 
			9 => OthPosShow9, 
			10 => OthPosShow10, 
			11 => OthPosShow11, 
			12 => OthPosShow12, 
			13 => OthPosShow13, 
			14 => OthPosShow14, 
			15 => OthPosShow15, 
			16 => OthPosShow16, 
			17 => OthPosShow17, 
			18 => OthPosShow18, 
			19 => OthPosShow19, 
			20 => OthPosShow20, 
			_ => false, 
		};
	}

	public void SetOthPosShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			OthPosShow1 = value;
			break;
		case 2:
			OthPosShow2 = value;
			break;
		case 3:
			OthPosShow3 = value;
			break;
		case 4:
			OthPosShow4 = value;
			break;
		case 5:
			OthPosShow5 = value;
			break;
		case 6:
			OthPosShow6 = value;
			break;
		case 7:
			OthPosShow7 = value;
			break;
		case 8:
			OthPosShow8 = value;
			break;
		case 9:
			OthPosShow9 = value;
			break;
		case 10:
			OthPosShow10 = value;
			break;
		case 11:
			OthPosShow11 = value;
			break;
		case 12:
			OthPosShow12 = value;
			break;
		case 13:
			OthPosShow13 = value;
			break;
		case 14:
			OthPosShow14 = value;
			break;
		case 15:
			OthPosShow15 = value;
			break;
		case 16:
			OthPosShow16 = value;
			break;
		case 17:
			OthPosShow17 = value;
			break;
		case 18:
			OthPosShow18 = value;
			break;
		case 19:
			OthPosShow19 = value;
			break;
		case 20:
			OthPosShow20 = value;
			break;
		}
	}

	public int GetOthPosCount()
	{
		return 20;
	}

	public Sprite GetOthPosSprite(int index)
	{
		return index switch
		{
			1 => OthPosSprite1, 
			2 => OthPosSprite2, 
			3 => OthPosSprite3, 
			4 => OthPosSprite4, 
			5 => OthPosSprite5, 
			6 => OthPosSprite6, 
			7 => OthPosSprite7, 
			8 => OthPosSprite8, 
			9 => OthPosSprite9, 
			10 => OthPosSprite10, 
			11 => OthPosSprite11, 
			12 => OthPosSprite12, 
			13 => OthPosSprite13, 
			14 => OthPosSprite14, 
			15 => OthPosSprite15, 
			16 => OthPosSprite16, 
			17 => OthPosSprite17, 
			18 => OthPosSprite18, 
			19 => OthPosSprite19, 
			20 => OthPosSprite20, 
			_ => null, 
		};
	}

	public void SetOthPosSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			OthPosSprite1 = value;
			break;
		case 2:
			OthPosSprite2 = value;
			break;
		case 3:
			OthPosSprite3 = value;
			break;
		case 4:
			OthPosSprite4 = value;
			break;
		case 5:
			OthPosSprite5 = value;
			break;
		case 6:
			OthPosSprite6 = value;
			break;
		case 7:
			OthPosSprite7 = value;
			break;
		case 8:
			OthPosSprite8 = value;
			break;
		case 9:
			OthPosSprite9 = value;
			break;
		case 10:
			OthPosSprite10 = value;
			break;
		case 11:
			OthPosSprite11 = value;
			break;
		case 12:
			OthPosSprite12 = value;
			break;
		case 13:
			OthPosSprite13 = value;
			break;
		case 14:
			OthPosSprite14 = value;
			break;
		case 15:
			OthPosSprite15 = value;
			break;
		case 16:
			OthPosSprite16 = value;
			break;
		case 17:
			OthPosSprite17 = value;
			break;
		case 18:
			OthPosSprite18 = value;
			break;
		case 19:
			OthPosSprite19 = value;
			break;
		case 20:
			OthPosSprite20 = value;
			break;
		}
	}

	public Image GetOthPosImage(int index)
	{
		return index switch
		{
			1 => OthPosImage1, 
			2 => OthPosImage2, 
			3 => OthPosImage3, 
			4 => OthPosImage4, 
			5 => OthPosImage5, 
			6 => OthPosImage6, 
			7 => OthPosImage7, 
			8 => OthPosImage8, 
			9 => OthPosImage9, 
			10 => OthPosImage10, 
			11 => OthPosImage11, 
			12 => OthPosImage12, 
			13 => OthPosImage13, 
			14 => OthPosImage14, 
			15 => OthPosImage15, 
			16 => OthPosImage16, 
			17 => OthPosImage17, 
			18 => OthPosImage18, 
			19 => OthPosImage19, 
			20 => OthPosImage20, 
			_ => null, 
		};
	}

	public void SetOthPosImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			OthPosImage1 = value;
			break;
		case 2:
			OthPosImage2 = value;
			break;
		case 3:
			OthPosImage3 = value;
			break;
		case 4:
			OthPosImage4 = value;
			break;
		case 5:
			OthPosImage5 = value;
			break;
		case 6:
			OthPosImage6 = value;
			break;
		case 7:
			OthPosImage7 = value;
			break;
		case 8:
			OthPosImage8 = value;
			break;
		case 9:
			OthPosImage9 = value;
			break;
		case 10:
			OthPosImage10 = value;
			break;
		case 11:
			OthPosImage11 = value;
			break;
		case 12:
			OthPosImage12 = value;
			break;
		case 13:
			OthPosImage13 = value;
			break;
		case 14:
			OthPosImage14 = value;
			break;
		case 15:
			OthPosImage15 = value;
			break;
		case 16:
			OthPosImage16 = value;
			break;
		case 17:
			OthPosImage17 = value;
			break;
		case 18:
			OthPosImage18 = value;
			break;
		case 19:
			OthPosImage19 = value;
			break;
		case 20:
			OthPosImage20 = value;
			break;
		}
	}

	public string GetOthTexString(int index)
	{
		return index switch
		{
			1 => OthTexString1, 
			2 => OthTexString2, 
			3 => OthTexString3, 
			4 => OthTexString4, 
			5 => OthTexString5, 
			6 => OthTexString6, 
			7 => OthTexString7, 
			8 => OthTexString8, 
			9 => OthTexString9, 
			10 => OthTexString10, 
			11 => OthTexString11, 
			12 => OthTexString12, 
			13 => OthTexString13, 
			14 => OthTexString14, 
			15 => OthTexString15, 
			16 => OthTexString16, 
			17 => OthTexString17, 
			18 => OthTexString18, 
			19 => OthTexString19, 
			20 => OthTexString20, 
			_ => null, 
		};
	}

	public void SetOthTexString(int index, string value)
	{
		switch (index)
		{
		case 1:
			OthTexString1 = value;
			break;
		case 2:
			OthTexString2 = value;
			break;
		case 3:
			OthTexString3 = value;
			break;
		case 4:
			OthTexString4 = value;
			break;
		case 5:
			OthTexString5 = value;
			break;
		case 6:
			OthTexString6 = value;
			break;
		case 7:
			OthTexString7 = value;
			break;
		case 8:
			OthTexString8 = value;
			break;
		case 9:
			OthTexString9 = value;
			break;
		case 10:
			OthTexString10 = value;
			break;
		case 11:
			OthTexString11 = value;
			break;
		case 12:
			OthTexString12 = value;
			break;
		case 13:
			OthTexString13 = value;
			break;
		case 14:
			OthTexString14 = value;
			break;
		case 15:
			OthTexString15 = value;
			break;
		case 16:
			OthTexString16 = value;
			break;
		case 17:
			OthTexString17 = value;
			break;
		case 18:
			OthTexString18 = value;
			break;
		case 19:
			OthTexString19 = value;
			break;
		case 20:
			OthTexString20 = value;
			break;
		}
	}

	public int GetOthTexCount()
	{
		return 20;
	}

	public bool GetOthPosPosShow(int index)
	{
		return index switch
		{
			1 => OthPosPosShow1, 
			2 => OthPosPosShow2, 
			3 => OthPosPosShow3, 
			4 => OthPosPosShow4, 
			5 => OthPosPosShow5, 
			6 => OthPosPosShow6, 
			7 => OthPosPosShow7, 
			8 => OthPosPosShow8, 
			9 => OthPosPosShow9, 
			10 => OthPosPosShow10, 
			11 => OthPosPosShow11, 
			12 => OthPosPosShow12, 
			13 => OthPosPosShow13, 
			14 => OthPosPosShow14, 
			15 => OthPosPosShow15, 
			16 => OthPosPosShow16, 
			17 => OthPosPosShow17, 
			18 => OthPosPosShow18, 
			19 => OthPosPosShow19, 
			20 => OthPosPosShow20, 
			_ => false, 
		};
	}

	public void SetOthPosPosShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			OthPosPosShow1 = value;
			break;
		case 2:
			OthPosPosShow2 = value;
			break;
		case 3:
			OthPosPosShow3 = value;
			break;
		case 4:
			OthPosPosShow4 = value;
			break;
		case 5:
			OthPosPosShow5 = value;
			break;
		case 6:
			OthPosPosShow6 = value;
			break;
		case 7:
			OthPosPosShow7 = value;
			break;
		case 8:
			OthPosPosShow8 = value;
			break;
		case 9:
			OthPosPosShow9 = value;
			break;
		case 10:
			OthPosPosShow10 = value;
			break;
		case 11:
			OthPosPosShow11 = value;
			break;
		case 12:
			OthPosPosShow12 = value;
			break;
		case 13:
			OthPosPosShow13 = value;
			break;
		case 14:
			OthPosPosShow14 = value;
			break;
		case 15:
			OthPosPosShow15 = value;
			break;
		case 16:
			OthPosPosShow16 = value;
			break;
		case 17:
			OthPosPosShow17 = value;
			break;
		case 18:
			OthPosPosShow18 = value;
			break;
		case 19:
			OthPosPosShow19 = value;
			break;
		case 20:
			OthPosPosShow20 = value;
			break;
		}
	}

	public int GetOthPosPosCount()
	{
		return 20;
	}

	public Sprite GetOthPosPosSprite(int index)
	{
		return index switch
		{
			1 => OthPosPosSprite1, 
			2 => OthPosPosSprite2, 
			3 => OthPosPosSprite3, 
			4 => OthPosPosSprite4, 
			5 => OthPosPosSprite5, 
			6 => OthPosPosSprite6, 
			7 => OthPosPosSprite7, 
			8 => OthPosPosSprite8, 
			9 => OthPosPosSprite9, 
			10 => OthPosPosSprite10, 
			11 => OthPosPosSprite11, 
			12 => OthPosPosSprite12, 
			13 => OthPosPosSprite13, 
			14 => OthPosPosSprite14, 
			15 => OthPosPosSprite15, 
			16 => OthPosPosSprite16, 
			17 => OthPosPosSprite17, 
			18 => OthPosPosSprite18, 
			19 => OthPosPosSprite19, 
			20 => OthPosPosSprite20, 
			_ => null, 
		};
	}

	public void SetOthPosPosSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			OthPosPosSprite1 = value;
			break;
		case 2:
			OthPosPosSprite2 = value;
			break;
		case 3:
			OthPosPosSprite3 = value;
			break;
		case 4:
			OthPosPosSprite4 = value;
			break;
		case 5:
			OthPosPosSprite5 = value;
			break;
		case 6:
			OthPosPosSprite6 = value;
			break;
		case 7:
			OthPosPosSprite7 = value;
			break;
		case 8:
			OthPosPosSprite8 = value;
			break;
		case 9:
			OthPosPosSprite9 = value;
			break;
		case 10:
			OthPosPosSprite10 = value;
			break;
		case 11:
			OthPosPosSprite11 = value;
			break;
		case 12:
			OthPosPosSprite12 = value;
			break;
		case 13:
			OthPosPosSprite13 = value;
			break;
		case 14:
			OthPosPosSprite14 = value;
			break;
		case 15:
			OthPosPosSprite15 = value;
			break;
		case 16:
			OthPosPosSprite16 = value;
			break;
		case 17:
			OthPosPosSprite17 = value;
			break;
		case 18:
			OthPosPosSprite18 = value;
			break;
		case 19:
			OthPosPosSprite19 = value;
			break;
		case 20:
			OthPosPosSprite20 = value;
			break;
		}
	}

	public Image GetOthPosPosImage(int index)
	{
		return index switch
		{
			1 => OthPosPosImage1, 
			2 => OthPosPosImage2, 
			3 => OthPosPosImage3, 
			4 => OthPosPosImage4, 
			5 => OthPosPosImage5, 
			6 => OthPosPosImage6, 
			7 => OthPosPosImage7, 
			8 => OthPosPosImage8, 
			9 => OthPosPosImage9, 
			10 => OthPosPosImage10, 
			11 => OthPosPosImage11, 
			12 => OthPosPosImage12, 
			13 => OthPosPosImage13, 
			14 => OthPosPosImage14, 
			15 => OthPosPosImage15, 
			16 => OthPosPosImage16, 
			17 => OthPosPosImage17, 
			18 => OthPosPosImage18, 
			19 => OthPosPosImage19, 
			20 => OthPosPosImage20, 
			_ => null, 
		};
	}

	public void SetOthPosPosImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			OthPosPosImage1 = value;
			break;
		case 2:
			OthPosPosImage2 = value;
			break;
		case 3:
			OthPosPosImage3 = value;
			break;
		case 4:
			OthPosPosImage4 = value;
			break;
		case 5:
			OthPosPosImage5 = value;
			break;
		case 6:
			OthPosPosImage6 = value;
			break;
		case 7:
			OthPosPosImage7 = value;
			break;
		case 8:
			OthPosPosImage8 = value;
			break;
		case 9:
			OthPosPosImage9 = value;
			break;
		case 10:
			OthPosPosImage10 = value;
			break;
		case 11:
			OthPosPosImage11 = value;
			break;
		case 12:
			OthPosPosImage12 = value;
			break;
		case 13:
			OthPosPosImage13 = value;
			break;
		case 14:
			OthPosPosImage14 = value;
			break;
		case 15:
			OthPosPosImage15 = value;
			break;
		case 16:
			OthPosPosImage16 = value;
			break;
		case 17:
			OthPosPosImage17 = value;
			break;
		case 18:
			OthPosPosImage18 = value;
			break;
		case 19:
			OthPosPosImage19 = value;
			break;
		case 20:
			OthPosPosImage20 = value;
			break;
		}
	}

	public string GetOthTextString(int index)
	{
		return index switch
		{
			1 => OthTextString1, 
			2 => OthTextString2, 
			3 => OthTextString3, 
			4 => OthTextString4, 
			5 => OthTextString5, 
			6 => OthTextString6, 
			7 => OthTextString7, 
			8 => OthTextString8, 
			9 => OthTextString9, 
			10 => OthTextString10, 
			11 => OthTextString11, 
			12 => OthTextString12, 
			13 => OthTextString13, 
			14 => OthTextString14, 
			15 => OthTextString15, 
			16 => OthTextString16, 
			17 => OthTextString17, 
			18 => OthTextString18, 
			19 => OthTextString19, 
			20 => OthTextString20, 
			_ => null, 
		};
	}

	public void SetOthTextString(int index, string value)
	{
		switch (index)
		{
		case 1:
			OthTextString1 = value;
			break;
		case 2:
			OthTextString2 = value;
			break;
		case 3:
			OthTextString3 = value;
			break;
		case 4:
			OthTextString4 = value;
			break;
		case 5:
			OthTextString5 = value;
			break;
		case 6:
			OthTextString6 = value;
			break;
		case 7:
			OthTextString7 = value;
			break;
		case 8:
			OthTextString8 = value;
			break;
		case 9:
			OthTextString9 = value;
			break;
		case 10:
			OthTextString10 = value;
			break;
		case 11:
			OthTextString11 = value;
			break;
		case 12:
			OthTextString12 = value;
			break;
		case 13:
			OthTextString13 = value;
			break;
		case 14:
			OthTextString14 = value;
			break;
		case 15:
			OthTextString15 = value;
			break;
		case 16:
			OthTextString16 = value;
			break;
		case 17:
			OthTextString17 = value;
			break;
		case 18:
			OthTextString18 = value;
			break;
		case 19:
			OthTextString19 = value;
			break;
		case 20:
			OthTextString20 = value;
			break;
		}
	}

	public int GetOthTextCount()
	{
		return 20;
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
