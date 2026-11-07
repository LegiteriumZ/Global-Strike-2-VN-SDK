using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class PveskillstateViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _opveskillstate;

	private GameObject _oBack;

	private Image _oBackImage;

	private GameObject _ompbackRotation;

	private Image _ompbackRotationImage;

	private GameObject _omptxt;

	private Text _omptxtText;

	private GameObject _oskillicon1;

	private GameObject _oskillicon2;

	private GameObject _oskillicon3;

	private GameObject _oskillicon4;

	private Image _oskilliconImage1;

	private Image _oskilliconImage2;

	private Image _oskilliconImage3;

	private Image _oskilliconImage4;

	private GameObject _oLv1;

	private GameObject _oLv2;

	private GameObject _oLv3;

	private GameObject _oLv4;

	private Text _oLvText1;

	private Text _oLvText2;

	private Text _oLvText3;

	private Text _oLvText4;

	private GameObject _oKey1;

	private GameObject _oKey2;

	private GameObject _oKey3;

	private GameObject _oKey4;

	private Image _oKeyImage1;

	private Image _oKeyImage2;

	private Image _oKeyImage3;

	private Image _oKeyImage4;

	private GameObject _owai1;

	private GameObject _owai2;

	private GameObject _owai3;

	private GameObject _owai4;

	private Image _owaiImage1;

	private Image _owaiImage2;

	private Image _owaiImage3;

	private Image _owaiImage4;

	private GameObject _oEffect1;

	private GameObject _oEffect2;

	private GameObject _oEffect3;

	private GameObject _oEffect4;

	private Image _oEffectImage1;

	private Image _oEffectImage2;

	private Image _oEffectImage3;

	private Image _oEffectImage4;

	private GameObject _obound1;

	private GameObject _obound2;

	private GameObject _obound3;

	private GameObject _obound4;

	private Image _oboundImage1;

	private Image _oboundImage2;

	private Image _oboundImage3;

	private Image _oboundImage4;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "Pveskillstate";

	public bool pveskillstateShow
	{
		get
		{
			if (_opveskillstate != null)
			{
				return _opveskillstate.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pveskillstateShow != value && _opveskillstate != null)
			{
				_opveskillstate.SetObjectActive(value);
			}
		}
	}

	public bool BackShow
	{
		get
		{
			if (_oBack != null)
			{
				return _oBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BackShow != value && _oBack != null)
			{
				_oBack.SetObjectActive(value);
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

	public Image BackImage
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage;
			}
			return null;
		}
		set
		{
			if (BackImage != value && _oBackImage != null)
			{
				_oBackImage = value;
			}
		}
	}

	public bool mpbackRotationShow
	{
		get
		{
			if (_ompbackRotation != null)
			{
				return _ompbackRotation.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (mpbackRotationShow != value && _ompbackRotation != null)
			{
				_ompbackRotation.SetObjectActive(value);
			}
		}
	}

	public Sprite mpbackRotationSprite
	{
		get
		{
			if (_ompbackRotationImage != null)
			{
				return _ompbackRotationImage.sprite;
			}
			return null;
		}
		set
		{
			if (mpbackRotationSprite != value && _ompbackRotationImage != null)
			{
				_ompbackRotationImage.sprite = value;
			}
		}
	}

	public int mpbackRotationFillorigin
	{
		get
		{
			if (_ompbackRotationImage != null)
			{
				return _ompbackRotationImage.fillOrigin;
			}
			return 0;
		}
		set
		{
			if (mpbackRotationFillorigin != value && _ompbackRotationImage != null)
			{
				_ompbackRotationImage.fillOrigin = value;
			}
		}
	}

	public float mpbackRotationFillamount
	{
		get
		{
			if (_ompbackRotationImage != null)
			{
				return _ompbackRotationImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (mpbackRotationFillamount != value && _ompbackRotationImage != null)
			{
				_ompbackRotationImage.fillAmount = value;
			}
		}
	}

	public bool mpbackRotationClockwise
	{
		get
		{
			if (_ompbackRotationImage != null)
			{
				return _ompbackRotationImage.fillClockwise;
			}
			return false;
		}
		set
		{
			if (mpbackRotationClockwise != value && _ompbackRotationImage != null)
			{
				_ompbackRotationImage.fillClockwise = value;
			}
		}
	}

	public Image mpbackRotationImage
	{
		get
		{
			if (_ompbackRotationImage != null)
			{
				return _ompbackRotationImage;
			}
			return null;
		}
		set
		{
			if (mpbackRotationImage != value && _ompbackRotationImage != null)
			{
				_ompbackRotationImage = value;
			}
		}
	}

	public bool mptxtShow
	{
		get
		{
			if (_omptxt != null)
			{
				return _omptxt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (mptxtShow != value && _omptxt != null)
			{
				_omptxt.SetObjectActive(value);
			}
		}
	}

	public string mptxtString
	{
		get
		{
			if (_omptxtText != null)
			{
				return _omptxtText.text;
			}
			return null;
		}
		set
		{
			if (mptxtString != value && _omptxtText != null)
			{
				_omptxtText.text = value;
			}
		}
	}

	public Color mptxtTextcolor
	{
		get
		{
			if (_omptxtText != null)
			{
				return _omptxtText.color;
			}
			return Color.white;
		}
		set
		{
			if (mptxtTextcolor != value && _omptxtText != null)
			{
				_omptxtText.color = value;
			}
		}
	}

	public bool skilliconShow1
	{
		get
		{
			if (_oskillicon1 != null)
			{
				return _oskillicon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilliconShow1 != value && _oskillicon1 != null)
			{
				_oskillicon1.SetObjectActive(value);
			}
		}
	}

	public bool skilliconShow2
	{
		get
		{
			if (_oskillicon2 != null)
			{
				return _oskillicon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilliconShow2 != value && _oskillicon2 != null)
			{
				_oskillicon2.SetObjectActive(value);
			}
		}
	}

	public bool skilliconShow3
	{
		get
		{
			if (_oskillicon3 != null)
			{
				return _oskillicon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilliconShow3 != value && _oskillicon3 != null)
			{
				_oskillicon3.SetObjectActive(value);
			}
		}
	}

	public bool skilliconShow4
	{
		get
		{
			if (_oskillicon4 != null)
			{
				return _oskillicon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (skilliconShow4 != value && _oskillicon4 != null)
			{
				_oskillicon4.SetObjectActive(value);
			}
		}
	}

	public Sprite skilliconSprite1
	{
		get
		{
			if (_oskilliconImage1 != null)
			{
				return _oskilliconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (skilliconSprite1 != value && _oskilliconImage1 != null)
			{
				_oskilliconImage1.sprite = value;
			}
		}
	}

	public Sprite skilliconSprite2
	{
		get
		{
			if (_oskilliconImage2 != null)
			{
				return _oskilliconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (skilliconSprite2 != value && _oskilliconImage2 != null)
			{
				_oskilliconImage2.sprite = value;
			}
		}
	}

	public Sprite skilliconSprite3
	{
		get
		{
			if (_oskilliconImage3 != null)
			{
				return _oskilliconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (skilliconSprite3 != value && _oskilliconImage3 != null)
			{
				_oskilliconImage3.sprite = value;
			}
		}
	}

	public Sprite skilliconSprite4
	{
		get
		{
			if (_oskilliconImage4 != null)
			{
				return _oskilliconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (skilliconSprite4 != value && _oskilliconImage4 != null)
			{
				_oskilliconImage4.sprite = value;
			}
		}
	}

	public Color skilliconColor1
	{
		get
		{
			if (_oskilliconImage1 != null)
			{
				return _oskilliconImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (skilliconColor1 != value && _oskilliconImage1 != null)
			{
				_oskilliconImage1.color = value;
			}
		}
	}

	public Color skilliconColor2
	{
		get
		{
			if (_oskilliconImage2 != null)
			{
				return _oskilliconImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (skilliconColor2 != value && _oskilliconImage2 != null)
			{
				_oskilliconImage2.color = value;
			}
		}
	}

	public Color skilliconColor3
	{
		get
		{
			if (_oskilliconImage3 != null)
			{
				return _oskilliconImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (skilliconColor3 != value && _oskilliconImage3 != null)
			{
				_oskilliconImage3.color = value;
			}
		}
	}

	public Color skilliconColor4
	{
		get
		{
			if (_oskilliconImage4 != null)
			{
				return _oskilliconImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (skilliconColor4 != value && _oskilliconImage4 != null)
			{
				_oskilliconImage4.color = value;
			}
		}
	}

	public Image skilliconImage1
	{
		get
		{
			if (_oskilliconImage1 != null)
			{
				return _oskilliconImage1;
			}
			return null;
		}
		set
		{
			if (skilliconImage1 != value && _oskilliconImage1 != null)
			{
				_oskilliconImage1 = value;
			}
		}
	}

	public Image skilliconImage2
	{
		get
		{
			if (_oskilliconImage2 != null)
			{
				return _oskilliconImage2;
			}
			return null;
		}
		set
		{
			if (skilliconImage2 != value && _oskilliconImage2 != null)
			{
				_oskilliconImage2 = value;
			}
		}
	}

	public Image skilliconImage3
	{
		get
		{
			if (_oskilliconImage3 != null)
			{
				return _oskilliconImage3;
			}
			return null;
		}
		set
		{
			if (skilliconImage3 != value && _oskilliconImage3 != null)
			{
				_oskilliconImage3 = value;
			}
		}
	}

	public Image skilliconImage4
	{
		get
		{
			if (_oskilliconImage4 != null)
			{
				return _oskilliconImage4;
			}
			return null;
		}
		set
		{
			if (skilliconImage4 != value && _oskilliconImage4 != null)
			{
				_oskilliconImage4 = value;
			}
		}
	}

	public bool LvShow1
	{
		get
		{
			if (_oLv1 != null)
			{
				return _oLv1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvShow1 != value && _oLv1 != null)
			{
				_oLv1.SetObjectActive(value);
			}
		}
	}

	public bool LvShow2
	{
		get
		{
			if (_oLv2 != null)
			{
				return _oLv2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvShow2 != value && _oLv2 != null)
			{
				_oLv2.SetObjectActive(value);
			}
		}
	}

	public bool LvShow3
	{
		get
		{
			if (_oLv3 != null)
			{
				return _oLv3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvShow3 != value && _oLv3 != null)
			{
				_oLv3.SetObjectActive(value);
			}
		}
	}

	public bool LvShow4
	{
		get
		{
			if (_oLv4 != null)
			{
				return _oLv4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LvShow4 != value && _oLv4 != null)
			{
				_oLv4.SetObjectActive(value);
			}
		}
	}

	public string LvString1
	{
		get
		{
			if (_oLvText1 != null)
			{
				return _oLvText1.text;
			}
			return null;
		}
		set
		{
			if (LvString1 != value && _oLvText1 != null)
			{
				_oLvText1.text = value;
			}
		}
	}

	public string LvString2
	{
		get
		{
			if (_oLvText2 != null)
			{
				return _oLvText2.text;
			}
			return null;
		}
		set
		{
			if (LvString2 != value && _oLvText2 != null)
			{
				_oLvText2.text = value;
			}
		}
	}

	public string LvString3
	{
		get
		{
			if (_oLvText3 != null)
			{
				return _oLvText3.text;
			}
			return null;
		}
		set
		{
			if (LvString3 != value && _oLvText3 != null)
			{
				_oLvText3.text = value;
			}
		}
	}

	public string LvString4
	{
		get
		{
			if (_oLvText4 != null)
			{
				return _oLvText4.text;
			}
			return null;
		}
		set
		{
			if (LvString4 != value && _oLvText4 != null)
			{
				_oLvText4.text = value;
			}
		}
	}

	public Color LvTextcolor1
	{
		get
		{
			if (_oLvText1 != null)
			{
				return _oLvText1.color;
			}
			return Color.white;
		}
		set
		{
			if (LvTextcolor1 != value && _oLvText1 != null)
			{
				_oLvText1.color = value;
			}
		}
	}

	public Color LvTextcolor2
	{
		get
		{
			if (_oLvText2 != null)
			{
				return _oLvText2.color;
			}
			return Color.white;
		}
		set
		{
			if (LvTextcolor2 != value && _oLvText2 != null)
			{
				_oLvText2.color = value;
			}
		}
	}

	public Color LvTextcolor3
	{
		get
		{
			if (_oLvText3 != null)
			{
				return _oLvText3.color;
			}
			return Color.white;
		}
		set
		{
			if (LvTextcolor3 != value && _oLvText3 != null)
			{
				_oLvText3.color = value;
			}
		}
	}

	public Color LvTextcolor4
	{
		get
		{
			if (_oLvText4 != null)
			{
				return _oLvText4.color;
			}
			return Color.white;
		}
		set
		{
			if (LvTextcolor4 != value && _oLvText4 != null)
			{
				_oLvText4.color = value;
			}
		}
	}

	public bool KeyShow1
	{
		get
		{
			if (_oKey1 != null)
			{
				return _oKey1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KeyShow1 != value && _oKey1 != null)
			{
				_oKey1.SetObjectActive(value);
			}
		}
	}

	public bool KeyShow2
	{
		get
		{
			if (_oKey2 != null)
			{
				return _oKey2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KeyShow2 != value && _oKey2 != null)
			{
				_oKey2.SetObjectActive(value);
			}
		}
	}

	public bool KeyShow3
	{
		get
		{
			if (_oKey3 != null)
			{
				return _oKey3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KeyShow3 != value && _oKey3 != null)
			{
				_oKey3.SetObjectActive(value);
			}
		}
	}

	public bool KeyShow4
	{
		get
		{
			if (_oKey4 != null)
			{
				return _oKey4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KeyShow4 != value && _oKey4 != null)
			{
				_oKey4.SetObjectActive(value);
			}
		}
	}

	public Sprite KeySprite1
	{
		get
		{
			if (_oKeyImage1 != null)
			{
				return _oKeyImage1.sprite;
			}
			return null;
		}
		set
		{
			if (KeySprite1 != value && _oKeyImage1 != null)
			{
				_oKeyImage1.sprite = value;
			}
		}
	}

	public Sprite KeySprite2
	{
		get
		{
			if (_oKeyImage2 != null)
			{
				return _oKeyImage2.sprite;
			}
			return null;
		}
		set
		{
			if (KeySprite2 != value && _oKeyImage2 != null)
			{
				_oKeyImage2.sprite = value;
			}
		}
	}

	public Sprite KeySprite3
	{
		get
		{
			if (_oKeyImage3 != null)
			{
				return _oKeyImage3.sprite;
			}
			return null;
		}
		set
		{
			if (KeySprite3 != value && _oKeyImage3 != null)
			{
				_oKeyImage3.sprite = value;
			}
		}
	}

	public Sprite KeySprite4
	{
		get
		{
			if (_oKeyImage4 != null)
			{
				return _oKeyImage4.sprite;
			}
			return null;
		}
		set
		{
			if (KeySprite4 != value && _oKeyImage4 != null)
			{
				_oKeyImage4.sprite = value;
			}
		}
	}

	public Color KeyColor1
	{
		get
		{
			if (_oKeyImage1 != null)
			{
				return _oKeyImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (KeyColor1 != value && _oKeyImage1 != null)
			{
				_oKeyImage1.color = value;
			}
		}
	}

	public Color KeyColor2
	{
		get
		{
			if (_oKeyImage2 != null)
			{
				return _oKeyImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (KeyColor2 != value && _oKeyImage2 != null)
			{
				_oKeyImage2.color = value;
			}
		}
	}

	public Color KeyColor3
	{
		get
		{
			if (_oKeyImage3 != null)
			{
				return _oKeyImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (KeyColor3 != value && _oKeyImage3 != null)
			{
				_oKeyImage3.color = value;
			}
		}
	}

	public Color KeyColor4
	{
		get
		{
			if (_oKeyImage4 != null)
			{
				return _oKeyImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (KeyColor4 != value && _oKeyImage4 != null)
			{
				_oKeyImage4.color = value;
			}
		}
	}

	public Image KeyImage1
	{
		get
		{
			if (_oKeyImage1 != null)
			{
				return _oKeyImage1;
			}
			return null;
		}
		set
		{
			if (KeyImage1 != value && _oKeyImage1 != null)
			{
				_oKeyImage1 = value;
			}
		}
	}

	public Image KeyImage2
	{
		get
		{
			if (_oKeyImage2 != null)
			{
				return _oKeyImage2;
			}
			return null;
		}
		set
		{
			if (KeyImage2 != value && _oKeyImage2 != null)
			{
				_oKeyImage2 = value;
			}
		}
	}

	public Image KeyImage3
	{
		get
		{
			if (_oKeyImage3 != null)
			{
				return _oKeyImage3;
			}
			return null;
		}
		set
		{
			if (KeyImage3 != value && _oKeyImage3 != null)
			{
				_oKeyImage3 = value;
			}
		}
	}

	public Image KeyImage4
	{
		get
		{
			if (_oKeyImage4 != null)
			{
				return _oKeyImage4;
			}
			return null;
		}
		set
		{
			if (KeyImage4 != value && _oKeyImage4 != null)
			{
				_oKeyImage4 = value;
			}
		}
	}

	public bool waiShow1
	{
		get
		{
			if (_owai1 != null)
			{
				return _owai1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (waiShow1 != value && _owai1 != null)
			{
				_owai1.SetObjectActive(value);
			}
		}
	}

	public bool waiShow2
	{
		get
		{
			if (_owai2 != null)
			{
				return _owai2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (waiShow2 != value && _owai2 != null)
			{
				_owai2.SetObjectActive(value);
			}
		}
	}

	public bool waiShow3
	{
		get
		{
			if (_owai3 != null)
			{
				return _owai3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (waiShow3 != value && _owai3 != null)
			{
				_owai3.SetObjectActive(value);
			}
		}
	}

	public bool waiShow4
	{
		get
		{
			if (_owai4 != null)
			{
				return _owai4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (waiShow4 != value && _owai4 != null)
			{
				_owai4.SetObjectActive(value);
			}
		}
	}

	public Sprite waiSprite1
	{
		get
		{
			if (_owaiImage1 != null)
			{
				return _owaiImage1.sprite;
			}
			return null;
		}
		set
		{
			if (waiSprite1 != value && _owaiImage1 != null)
			{
				_owaiImage1.sprite = value;
			}
		}
	}

	public Sprite waiSprite2
	{
		get
		{
			if (_owaiImage2 != null)
			{
				return _owaiImage2.sprite;
			}
			return null;
		}
		set
		{
			if (waiSprite2 != value && _owaiImage2 != null)
			{
				_owaiImage2.sprite = value;
			}
		}
	}

	public Sprite waiSprite3
	{
		get
		{
			if (_owaiImage3 != null)
			{
				return _owaiImage3.sprite;
			}
			return null;
		}
		set
		{
			if (waiSprite3 != value && _owaiImage3 != null)
			{
				_owaiImage3.sprite = value;
			}
		}
	}

	public Sprite waiSprite4
	{
		get
		{
			if (_owaiImage4 != null)
			{
				return _owaiImage4.sprite;
			}
			return null;
		}
		set
		{
			if (waiSprite4 != value && _owaiImage4 != null)
			{
				_owaiImage4.sprite = value;
			}
		}
	}

	public float waiFillamount1
	{
		get
		{
			if (_owaiImage1 != null)
			{
				return _owaiImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (waiFillamount1 != value && _owaiImage1 != null)
			{
				_owaiImage1.fillAmount = value;
			}
		}
	}

	public float waiFillamount2
	{
		get
		{
			if (_owaiImage2 != null)
			{
				return _owaiImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (waiFillamount2 != value && _owaiImage2 != null)
			{
				_owaiImage2.fillAmount = value;
			}
		}
	}

	public float waiFillamount3
	{
		get
		{
			if (_owaiImage3 != null)
			{
				return _owaiImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (waiFillamount3 != value && _owaiImage3 != null)
			{
				_owaiImage3.fillAmount = value;
			}
		}
	}

	public float waiFillamount4
	{
		get
		{
			if (_owaiImage4 != null)
			{
				return _owaiImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (waiFillamount4 != value && _owaiImage4 != null)
			{
				_owaiImage4.fillAmount = value;
			}
		}
	}

	public Image waiImage1
	{
		get
		{
			if (_owaiImage1 != null)
			{
				return _owaiImage1;
			}
			return null;
		}
		set
		{
			if (waiImage1 != value && _owaiImage1 != null)
			{
				_owaiImage1 = value;
			}
		}
	}

	public Image waiImage2
	{
		get
		{
			if (_owaiImage2 != null)
			{
				return _owaiImage2;
			}
			return null;
		}
		set
		{
			if (waiImage2 != value && _owaiImage2 != null)
			{
				_owaiImage2 = value;
			}
		}
	}

	public Image waiImage3
	{
		get
		{
			if (_owaiImage3 != null)
			{
				return _owaiImage3;
			}
			return null;
		}
		set
		{
			if (waiImage3 != value && _owaiImage3 != null)
			{
				_owaiImage3 = value;
			}
		}
	}

	public Image waiImage4
	{
		get
		{
			if (_owaiImage4 != null)
			{
				return _owaiImage4;
			}
			return null;
		}
		set
		{
			if (waiImage4 != value && _owaiImage4 != null)
			{
				_owaiImage4 = value;
			}
		}
	}

	public bool EffectShow1
	{
		get
		{
			if (_oEffect1 != null)
			{
				return _oEffect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow1 != value && _oEffect1 != null)
			{
				_oEffect1.SetObjectActive(value);
			}
		}
	}

	public bool EffectShow2
	{
		get
		{
			if (_oEffect2 != null)
			{
				return _oEffect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow2 != value && _oEffect2 != null)
			{
				_oEffect2.SetObjectActive(value);
			}
		}
	}

	public bool EffectShow3
	{
		get
		{
			if (_oEffect3 != null)
			{
				return _oEffect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow3 != value && _oEffect3 != null)
			{
				_oEffect3.SetObjectActive(value);
			}
		}
	}

	public bool EffectShow4
	{
		get
		{
			if (_oEffect4 != null)
			{
				return _oEffect4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow4 != value && _oEffect4 != null)
			{
				_oEffect4.SetObjectActive(value);
			}
		}
	}

	public Sprite EffectSprite1
	{
		get
		{
			if (_oEffectImage1 != null)
			{
				return _oEffectImage1.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite1 != value && _oEffectImage1 != null)
			{
				_oEffectImage1.sprite = value;
			}
		}
	}

	public Sprite EffectSprite2
	{
		get
		{
			if (_oEffectImage2 != null)
			{
				return _oEffectImage2.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite2 != value && _oEffectImage2 != null)
			{
				_oEffectImage2.sprite = value;
			}
		}
	}

	public Sprite EffectSprite3
	{
		get
		{
			if (_oEffectImage3 != null)
			{
				return _oEffectImage3.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite3 != value && _oEffectImage3 != null)
			{
				_oEffectImage3.sprite = value;
			}
		}
	}

	public Sprite EffectSprite4
	{
		get
		{
			if (_oEffectImage4 != null)
			{
				return _oEffectImage4.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite4 != value && _oEffectImage4 != null)
			{
				_oEffectImage4.sprite = value;
			}
		}
	}

	public Image EffectImage1
	{
		get
		{
			if (_oEffectImage1 != null)
			{
				return _oEffectImage1;
			}
			return null;
		}
		set
		{
			if (EffectImage1 != value && _oEffectImage1 != null)
			{
				_oEffectImage1 = value;
			}
		}
	}

	public Image EffectImage2
	{
		get
		{
			if (_oEffectImage2 != null)
			{
				return _oEffectImage2;
			}
			return null;
		}
		set
		{
			if (EffectImage2 != value && _oEffectImage2 != null)
			{
				_oEffectImage2 = value;
			}
		}
	}

	public Image EffectImage3
	{
		get
		{
			if (_oEffectImage3 != null)
			{
				return _oEffectImage3;
			}
			return null;
		}
		set
		{
			if (EffectImage3 != value && _oEffectImage3 != null)
			{
				_oEffectImage3 = value;
			}
		}
	}

	public Image EffectImage4
	{
		get
		{
			if (_oEffectImage4 != null)
			{
				return _oEffectImage4;
			}
			return null;
		}
		set
		{
			if (EffectImage4 != value && _oEffectImage4 != null)
			{
				_oEffectImage4 = value;
			}
		}
	}

	public bool boundShow1
	{
		get
		{
			if (_obound1 != null)
			{
				return _obound1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (boundShow1 != value && _obound1 != null)
			{
				_obound1.SetObjectActive(value);
			}
		}
	}

	public bool boundShow2
	{
		get
		{
			if (_obound2 != null)
			{
				return _obound2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (boundShow2 != value && _obound2 != null)
			{
				_obound2.SetObjectActive(value);
			}
		}
	}

	public bool boundShow3
	{
		get
		{
			if (_obound3 != null)
			{
				return _obound3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (boundShow3 != value && _obound3 != null)
			{
				_obound3.SetObjectActive(value);
			}
		}
	}

	public bool boundShow4
	{
		get
		{
			if (_obound4 != null)
			{
				return _obound4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (boundShow4 != value && _obound4 != null)
			{
				_obound4.SetObjectActive(value);
			}
		}
	}

	public Sprite boundSprite1
	{
		get
		{
			if (_oboundImage1 != null)
			{
				return _oboundImage1.sprite;
			}
			return null;
		}
		set
		{
			if (boundSprite1 != value && _oboundImage1 != null)
			{
				_oboundImage1.sprite = value;
			}
		}
	}

	public Sprite boundSprite2
	{
		get
		{
			if (_oboundImage2 != null)
			{
				return _oboundImage2.sprite;
			}
			return null;
		}
		set
		{
			if (boundSprite2 != value && _oboundImage2 != null)
			{
				_oboundImage2.sprite = value;
			}
		}
	}

	public Sprite boundSprite3
	{
		get
		{
			if (_oboundImage3 != null)
			{
				return _oboundImage3.sprite;
			}
			return null;
		}
		set
		{
			if (boundSprite3 != value && _oboundImage3 != null)
			{
				_oboundImage3.sprite = value;
			}
		}
	}

	public Sprite boundSprite4
	{
		get
		{
			if (_oboundImage4 != null)
			{
				return _oboundImage4.sprite;
			}
			return null;
		}
		set
		{
			if (boundSprite4 != value && _oboundImage4 != null)
			{
				_oboundImage4.sprite = value;
			}
		}
	}

	public Color boundColor1
	{
		get
		{
			if (_oboundImage1 != null)
			{
				return _oboundImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (boundColor1 != value && _oboundImage1 != null)
			{
				_oboundImage1.color = value;
			}
		}
	}

	public Color boundColor2
	{
		get
		{
			if (_oboundImage2 != null)
			{
				return _oboundImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (boundColor2 != value && _oboundImage2 != null)
			{
				_oboundImage2.color = value;
			}
		}
	}

	public Color boundColor3
	{
		get
		{
			if (_oboundImage3 != null)
			{
				return _oboundImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (boundColor3 != value && _oboundImage3 != null)
			{
				_oboundImage3.color = value;
			}
		}
	}

	public Color boundColor4
	{
		get
		{
			if (_oboundImage4 != null)
			{
				return _oboundImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (boundColor4 != value && _oboundImage4 != null)
			{
				_oboundImage4.color = value;
			}
		}
	}

	public Image boundImage1
	{
		get
		{
			if (_oboundImage1 != null)
			{
				return _oboundImage1;
			}
			return null;
		}
		set
		{
			if (boundImage1 != value && _oboundImage1 != null)
			{
				_oboundImage1 = value;
			}
		}
	}

	public Image boundImage2
	{
		get
		{
			if (_oboundImage2 != null)
			{
				return _oboundImage2;
			}
			return null;
		}
		set
		{
			if (boundImage2 != value && _oboundImage2 != null)
			{
				_oboundImage2 = value;
			}
		}
	}

	public Image boundImage3
	{
		get
		{
			if (_oboundImage3 != null)
			{
				return _oboundImage3;
			}
			return null;
		}
		set
		{
			if (boundImage3 != value && _oboundImage3 != null)
			{
				_oboundImage3 = value;
			}
		}
	}

	public Image boundImage4
	{
		get
		{
			if (_oboundImage4 != null)
			{
				return _oboundImage4;
			}
			return null;
		}
		set
		{
			if (boundImage4 != value && _oboundImage4 != null)
			{
				_oboundImage4 = value;
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
			case "pveskillstate":
				_opveskillstate = transform.gameObject;
				break;
			case "Back":
				_oBack = transform.gameObject;
				_oBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "mpbackRotation":
				_ompbackRotation = transform.gameObject;
				_ompbackRotationImage = transform.gameObject.GetComponent<Image>();
				break;
			case "mptxt":
				_omptxt = transform.gameObject;
				_omptxtText = transform.gameObject.GetComponent<Text>();
				break;
			case "skillicon1":
				_oskillicon1 = transform.gameObject;
				_oskilliconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "skillicon2":
				_oskillicon2 = transform.gameObject;
				_oskilliconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "skillicon3":
				_oskillicon3 = transform.gameObject;
				_oskilliconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "skillicon4":
				_oskillicon4 = transform.gameObject;
				_oskilliconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Lv1":
				_oLv1 = transform.gameObject;
				_oLvText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "Lv2":
				_oLv2 = transform.gameObject;
				_oLvText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "Lv3":
				_oLv3 = transform.gameObject;
				_oLvText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "Lv4":
				_oLv4 = transform.gameObject;
				_oLvText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "Key1":
				_oKey1 = transform.gameObject;
				_oKeyImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Key2":
				_oKey2 = transform.gameObject;
				_oKeyImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Key3":
				_oKey3 = transform.gameObject;
				_oKeyImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Key4":
				_oKey4 = transform.gameObject;
				_oKeyImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "wai1":
				_owai1 = transform.gameObject;
				_owaiImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "wai2":
				_owai2 = transform.gameObject;
				_owaiImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "wai3":
				_owai3 = transform.gameObject;
				_owaiImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "wai4":
				_owai4 = transform.gameObject;
				_owaiImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect1":
				_oEffect1 = transform.gameObject;
				_oEffectImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect2":
				_oEffect2 = transform.gameObject;
				_oEffectImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect3":
				_oEffect3 = transform.gameObject;
				_oEffectImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect4":
				_oEffect4 = transform.gameObject;
				_oEffectImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "bound1":
				_obound1 = transform.gameObject;
				_oboundImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "bound2":
				_obound2 = transform.gameObject;
				_oboundImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "bound3":
				_obound3 = transform.gameObject;
				_oboundImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "bound4":
				_obound4 = transform.gameObject;
				_oboundImage4 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public void mpbackRotationNtvsize()
	{
		if (_ompbackRotationImage != null)
		{
			_ompbackRotationImage.SetNativeSize();
		}
	}

	public bool GetskilliconShow(int index)
	{
		return index switch
		{
			1 => skilliconShow1, 
			2 => skilliconShow2, 
			3 => skilliconShow3, 
			4 => skilliconShow4, 
			_ => false, 
		};
	}

	public void SetskilliconShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			skilliconShow1 = value;
			break;
		case 2:
			skilliconShow2 = value;
			break;
		case 3:
			skilliconShow3 = value;
			break;
		case 4:
			skilliconShow4 = value;
			break;
		}
	}

	public Sprite GetskilliconSprite(int index)
	{
		return index switch
		{
			1 => skilliconSprite1, 
			2 => skilliconSprite2, 
			3 => skilliconSprite3, 
			4 => skilliconSprite4, 
			_ => null, 
		};
	}

	public void SetskilliconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			skilliconSprite1 = value;
			break;
		case 2:
			skilliconSprite2 = value;
			break;
		case 3:
			skilliconSprite3 = value;
			break;
		case 4:
			skilliconSprite4 = value;
			break;
		}
	}

	public Color GetskilliconColor(int index)
	{
		return index switch
		{
			1 => skilliconColor1, 
			2 => skilliconColor2, 
			3 => skilliconColor3, 
			4 => skilliconColor4, 
			_ => Color.white, 
		};
	}

	public void SetskilliconColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			skilliconColor1 = value;
			break;
		case 2:
			skilliconColor2 = value;
			break;
		case 3:
			skilliconColor3 = value;
			break;
		case 4:
			skilliconColor4 = value;
			break;
		}
	}

	public Image GetskilliconImage(int index)
	{
		return index switch
		{
			1 => skilliconImage1, 
			2 => skilliconImage2, 
			3 => skilliconImage3, 
			4 => skilliconImage4, 
			_ => null, 
		};
	}

	public void SetskilliconImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			skilliconImage1 = value;
			break;
		case 2:
			skilliconImage2 = value;
			break;
		case 3:
			skilliconImage3 = value;
			break;
		case 4:
			skilliconImage4 = value;
			break;
		}
	}

	public void skilliconNtvsize1()
	{
		if (_oskilliconImage1 != null)
		{
			_oskilliconImage1.SetNativeSize();
		}
	}

	public void skilliconNtvsize2()
	{
		if (_oskilliconImage2 != null)
		{
			_oskilliconImage2.SetNativeSize();
		}
	}

	public void skilliconNtvsize3()
	{
		if (_oskilliconImage3 != null)
		{
			_oskilliconImage3.SetNativeSize();
		}
	}

	public void skilliconNtvsize4()
	{
		if (_oskilliconImage4 != null)
		{
			_oskilliconImage4.SetNativeSize();
		}
	}

	public void CallskilliconNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			skilliconNtvsize1();
			break;
		case 2:
			skilliconNtvsize2();
			break;
		case 3:
			skilliconNtvsize3();
			break;
		case 4:
			skilliconNtvsize4();
			break;
		}
	}

	public bool GetLvShow(int index)
	{
		return index switch
		{
			1 => LvShow1, 
			2 => LvShow2, 
			3 => LvShow3, 
			4 => LvShow4, 
			_ => false, 
		};
	}

	public void SetLvShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			LvShow1 = value;
			break;
		case 2:
			LvShow2 = value;
			break;
		case 3:
			LvShow3 = value;
			break;
		case 4:
			LvShow4 = value;
			break;
		}
	}

	public string GetLvString(int index)
	{
		return index switch
		{
			1 => LvString1, 
			2 => LvString2, 
			3 => LvString3, 
			4 => LvString4, 
			_ => null, 
		};
	}

	public void SetLvString(int index, string value)
	{
		switch (index)
		{
		case 1:
			LvString1 = value;
			break;
		case 2:
			LvString2 = value;
			break;
		case 3:
			LvString3 = value;
			break;
		case 4:
			LvString4 = value;
			break;
		}
	}

	public Color GetLvTextcolor(int index)
	{
		return index switch
		{
			1 => LvTextcolor1, 
			2 => LvTextcolor2, 
			3 => LvTextcolor3, 
			4 => LvTextcolor4, 
			_ => Color.white, 
		};
	}

	public void SetLvTextcolor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			LvTextcolor1 = value;
			break;
		case 2:
			LvTextcolor2 = value;
			break;
		case 3:
			LvTextcolor3 = value;
			break;
		case 4:
			LvTextcolor4 = value;
			break;
		}
	}

	public bool GetKeyShow(int index)
	{
		return index switch
		{
			1 => KeyShow1, 
			2 => KeyShow2, 
			3 => KeyShow3, 
			4 => KeyShow4, 
			_ => false, 
		};
	}

	public void SetKeyShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			KeyShow1 = value;
			break;
		case 2:
			KeyShow2 = value;
			break;
		case 3:
			KeyShow3 = value;
			break;
		case 4:
			KeyShow4 = value;
			break;
		}
	}

	public Sprite GetKeySprite(int index)
	{
		return index switch
		{
			1 => KeySprite1, 
			2 => KeySprite2, 
			3 => KeySprite3, 
			4 => KeySprite4, 
			_ => null, 
		};
	}

	public void SetKeySprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			KeySprite1 = value;
			break;
		case 2:
			KeySprite2 = value;
			break;
		case 3:
			KeySprite3 = value;
			break;
		case 4:
			KeySprite4 = value;
			break;
		}
	}

	public Color GetKeyColor(int index)
	{
		return index switch
		{
			1 => KeyColor1, 
			2 => KeyColor2, 
			3 => KeyColor3, 
			4 => KeyColor4, 
			_ => Color.white, 
		};
	}

	public void SetKeyColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			KeyColor1 = value;
			break;
		case 2:
			KeyColor2 = value;
			break;
		case 3:
			KeyColor3 = value;
			break;
		case 4:
			KeyColor4 = value;
			break;
		}
	}

	public Image GetKeyImage(int index)
	{
		return index switch
		{
			1 => KeyImage1, 
			2 => KeyImage2, 
			3 => KeyImage3, 
			4 => KeyImage4, 
			_ => null, 
		};
	}

	public void SetKeyImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			KeyImage1 = value;
			break;
		case 2:
			KeyImage2 = value;
			break;
		case 3:
			KeyImage3 = value;
			break;
		case 4:
			KeyImage4 = value;
			break;
		}
	}

	public void KeyNtvsize1()
	{
		if (_oKeyImage1 != null)
		{
			_oKeyImage1.SetNativeSize();
		}
	}

	public void KeyNtvsize2()
	{
		if (_oKeyImage2 != null)
		{
			_oKeyImage2.SetNativeSize();
		}
	}

	public void KeyNtvsize3()
	{
		if (_oKeyImage3 != null)
		{
			_oKeyImage3.SetNativeSize();
		}
	}

	public void KeyNtvsize4()
	{
		if (_oKeyImage4 != null)
		{
			_oKeyImage4.SetNativeSize();
		}
	}

	public void CallKeyNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			KeyNtvsize1();
			break;
		case 2:
			KeyNtvsize2();
			break;
		case 3:
			KeyNtvsize3();
			break;
		case 4:
			KeyNtvsize4();
			break;
		}
	}

	public bool GetwaiShow(int index)
	{
		return index switch
		{
			1 => waiShow1, 
			2 => waiShow2, 
			3 => waiShow3, 
			4 => waiShow4, 
			_ => false, 
		};
	}

	public void SetwaiShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			waiShow1 = value;
			break;
		case 2:
			waiShow2 = value;
			break;
		case 3:
			waiShow3 = value;
			break;
		case 4:
			waiShow4 = value;
			break;
		}
	}

	public Sprite GetwaiSprite(int index)
	{
		return index switch
		{
			1 => waiSprite1, 
			2 => waiSprite2, 
			3 => waiSprite3, 
			4 => waiSprite4, 
			_ => null, 
		};
	}

	public void SetwaiSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			waiSprite1 = value;
			break;
		case 2:
			waiSprite2 = value;
			break;
		case 3:
			waiSprite3 = value;
			break;
		case 4:
			waiSprite4 = value;
			break;
		}
	}

	public float GetwaiFillamount(int index)
	{
		return index switch
		{
			1 => waiFillamount1, 
			2 => waiFillamount2, 
			3 => waiFillamount3, 
			4 => waiFillamount4, 
			_ => 0f, 
		};
	}

	public void SetwaiFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			waiFillamount1 = value;
			break;
		case 2:
			waiFillamount2 = value;
			break;
		case 3:
			waiFillamount3 = value;
			break;
		case 4:
			waiFillamount4 = value;
			break;
		}
	}

	public Image GetwaiImage(int index)
	{
		return index switch
		{
			1 => waiImage1, 
			2 => waiImage2, 
			3 => waiImage3, 
			4 => waiImage4, 
			_ => null, 
		};
	}

	public void SetwaiImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			waiImage1 = value;
			break;
		case 2:
			waiImage2 = value;
			break;
		case 3:
			waiImage3 = value;
			break;
		case 4:
			waiImage4 = value;
			break;
		}
	}

	public void waiNtvsize1()
	{
		if (_owaiImage1 != null)
		{
			_owaiImage1.SetNativeSize();
		}
	}

	public void waiNtvsize2()
	{
		if (_owaiImage2 != null)
		{
			_owaiImage2.SetNativeSize();
		}
	}

	public void waiNtvsize3()
	{
		if (_owaiImage3 != null)
		{
			_owaiImage3.SetNativeSize();
		}
	}

	public void waiNtvsize4()
	{
		if (_owaiImage4 != null)
		{
			_owaiImage4.SetNativeSize();
		}
	}

	public void CallwaiNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			waiNtvsize1();
			break;
		case 2:
			waiNtvsize2();
			break;
		case 3:
			waiNtvsize3();
			break;
		case 4:
			waiNtvsize4();
			break;
		}
	}

	public bool GetEffectShow(int index)
	{
		return index switch
		{
			1 => EffectShow1, 
			2 => EffectShow2, 
			3 => EffectShow3, 
			4 => EffectShow4, 
			_ => false, 
		};
	}

	public void SetEffectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			EffectShow1 = value;
			break;
		case 2:
			EffectShow2 = value;
			break;
		case 3:
			EffectShow3 = value;
			break;
		case 4:
			EffectShow4 = value;
			break;
		}
	}

	public Sprite GetEffectSprite(int index)
	{
		return index switch
		{
			1 => EffectSprite1, 
			2 => EffectSprite2, 
			3 => EffectSprite3, 
			4 => EffectSprite4, 
			_ => null, 
		};
	}

	public void SetEffectSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			EffectSprite1 = value;
			break;
		case 2:
			EffectSprite2 = value;
			break;
		case 3:
			EffectSprite3 = value;
			break;
		case 4:
			EffectSprite4 = value;
			break;
		}
	}

	public Image GetEffectImage(int index)
	{
		return index switch
		{
			1 => EffectImage1, 
			2 => EffectImage2, 
			3 => EffectImage3, 
			4 => EffectImage4, 
			_ => null, 
		};
	}

	public void SetEffectImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			EffectImage1 = value;
			break;
		case 2:
			EffectImage2 = value;
			break;
		case 3:
			EffectImage3 = value;
			break;
		case 4:
			EffectImage4 = value;
			break;
		}
	}

	public void EffectNtvsize1()
	{
		if (_oEffectImage1 != null)
		{
			_oEffectImage1.SetNativeSize();
		}
	}

	public void EffectNtvsize2()
	{
		if (_oEffectImage2 != null)
		{
			_oEffectImage2.SetNativeSize();
		}
	}

	public void EffectNtvsize3()
	{
		if (_oEffectImage3 != null)
		{
			_oEffectImage3.SetNativeSize();
		}
	}

	public void EffectNtvsize4()
	{
		if (_oEffectImage4 != null)
		{
			_oEffectImage4.SetNativeSize();
		}
	}

	public void CallEffectNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			EffectNtvsize1();
			break;
		case 2:
			EffectNtvsize2();
			break;
		case 3:
			EffectNtvsize3();
			break;
		case 4:
			EffectNtvsize4();
			break;
		}
	}

	public bool GetboundShow(int index)
	{
		return index switch
		{
			1 => boundShow1, 
			2 => boundShow2, 
			3 => boundShow3, 
			4 => boundShow4, 
			_ => false, 
		};
	}

	public void SetboundShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			boundShow1 = value;
			break;
		case 2:
			boundShow2 = value;
			break;
		case 3:
			boundShow3 = value;
			break;
		case 4:
			boundShow4 = value;
			break;
		}
	}

	public Sprite GetboundSprite(int index)
	{
		return index switch
		{
			1 => boundSprite1, 
			2 => boundSprite2, 
			3 => boundSprite3, 
			4 => boundSprite4, 
			_ => null, 
		};
	}

	public void SetboundSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			boundSprite1 = value;
			break;
		case 2:
			boundSprite2 = value;
			break;
		case 3:
			boundSprite3 = value;
			break;
		case 4:
			boundSprite4 = value;
			break;
		}
	}

	public Color GetboundColor(int index)
	{
		return index switch
		{
			1 => boundColor1, 
			2 => boundColor2, 
			3 => boundColor3, 
			4 => boundColor4, 
			_ => Color.white, 
		};
	}

	public void SetboundColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			boundColor1 = value;
			break;
		case 2:
			boundColor2 = value;
			break;
		case 3:
			boundColor3 = value;
			break;
		case 4:
			boundColor4 = value;
			break;
		}
	}

	public Image GetboundImage(int index)
	{
		return index switch
		{
			1 => boundImage1, 
			2 => boundImage2, 
			3 => boundImage3, 
			4 => boundImage4, 
			_ => null, 
		};
	}

	public void SetboundImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			boundImage1 = value;
			break;
		case 2:
			boundImage2 = value;
			break;
		case 3:
			boundImage3 = value;
			break;
		case 4:
			boundImage4 = value;
			break;
		}
	}

	public void boundNtvsize1()
	{
		if (_oboundImage1 != null)
		{
			_oboundImage1.SetNativeSize();
		}
	}

	public void boundNtvsize2()
	{
		if (_oboundImage2 != null)
		{
			_oboundImage2.SetNativeSize();
		}
	}

	public void boundNtvsize3()
	{
		if (_oboundImage3 != null)
		{
			_oboundImage3.SetNativeSize();
		}
	}

	public void boundNtvsize4()
	{
		if (_oboundImage4 != null)
		{
			_oboundImage4.SetNativeSize();
		}
	}

	public void CallboundNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			boundNtvsize1();
			break;
		case 2:
			boundNtvsize2();
			break;
		case 3:
			boundNtvsize3();
			break;
		case 4:
			boundNtvsize4();
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
