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

namespace Assets.Sources.Ui.ViewModel.BioChemical_Z;

[GameUiTest]
public class BioChemical_Z_Shop_WeaponViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _ol_1_weapon1;

	private GameObject _ol_1_weapon2;

	private GameObject _ol_1_weapon3;

	private GameObject _ol_1_weapon4;

	private GameObject _ol_1_weapon5;

	private GameObject _ol_1_weapon6;

	private GameObject _ol_1_weapon7;

	private GameObject _ol_1_weapon8;

	private GameObject _ol_1_weapon9;

	private GameObject _ol_1_weapon10;

	private GameObject _ol_1_weapon11;

	private GameObject _ol_1_weapon12;

	private GameObject _ol_1_weapon13;

	private GameObject _ol_1_weapon14;

	private GameObject _ol_1_weapon15;

	private GameObject _ol_1_weapon16;

	private GameObject _ol_1_weapon17;

	private GameObject _ol_1_weapon18;

	private GameObject _ol_1_weapon19;

	private GameObject _ol_1_weapon20;

	private GameObject _ol_1_weapon21;

	private GameObject _ol_1_weapon22;

	private GameObject _ol_1_weapon23;

	private GameObject _ol_1_weapon24;

	private GameObject _ol_1_weapon25;

	private GameObject _ol_1_weapon26;

	private GameObject _ol_1_weapon27;

	private GameObject _ol_1_weapon28;

	private GameObject _ol_1_weapon29;

	private GameObject _ol_1_weapon30;

	private GameObject _ol_1_weapon31;

	private GameObject _ol_1_weapon32;

	private GameObject _ol_1_weapon33;

	private GameObject _ol_1_weapon34;

	private GameObject _ol_1_weapon35;

	private GameObject _ol_1_weapon36;

	private GameObject _ol_1_weapon37;

	private GameObject _ol_1_weapon38;

	private GameObject _ol_1_weapon39;

	private GameObject _ol_1_weapon40;

	private Button _ol_1_weaponButton1;

	private Button _ol_1_weaponButton2;

	private Button _ol_1_weaponButton3;

	private Button _ol_1_weaponButton4;

	private Button _ol_1_weaponButton5;

	private Button _ol_1_weaponButton6;

	private Button _ol_1_weaponButton7;

	private Button _ol_1_weaponButton8;

	private Button _ol_1_weaponButton9;

	private Button _ol_1_weaponButton10;

	private Button _ol_1_weaponButton11;

	private Button _ol_1_weaponButton12;

	private Button _ol_1_weaponButton13;

	private Button _ol_1_weaponButton14;

	private Button _ol_1_weaponButton15;

	private Button _ol_1_weaponButton16;

	private Button _ol_1_weaponButton17;

	private Button _ol_1_weaponButton18;

	private Button _ol_1_weaponButton19;

	private Button _ol_1_weaponButton20;

	private Button _ol_1_weaponButton21;

	private Button _ol_1_weaponButton22;

	private Button _ol_1_weaponButton23;

	private Button _ol_1_weaponButton24;

	private Button _ol_1_weaponButton25;

	private Button _ol_1_weaponButton26;

	private Button _ol_1_weaponButton27;

	private Button _ol_1_weaponButton28;

	private Button _ol_1_weaponButton29;

	private Button _ol_1_weaponButton30;

	private Button _ol_1_weaponButton31;

	private Button _ol_1_weaponButton32;

	private Button _ol_1_weaponButton33;

	private Button _ol_1_weaponButton34;

	private Button _ol_1_weaponButton35;

	private Button _ol_1_weaponButton36;

	private Button _ol_1_weaponButton37;

	private Button _ol_1_weaponButton38;

	private Button _ol_1_weaponButton39;

	private Button _ol_1_weaponButton40;

	private GameObject _ol_1_Icon1;

	private GameObject _ol_1_Icon2;

	private GameObject _ol_1_Icon3;

	private GameObject _ol_1_Icon4;

	private GameObject _ol_1_Icon5;

	private GameObject _ol_1_Icon6;

	private GameObject _ol_1_Icon7;

	private GameObject _ol_1_Icon8;

	private GameObject _ol_1_Icon9;

	private GameObject _ol_1_Icon10;

	private GameObject _ol_1_Icon11;

	private GameObject _ol_1_Icon12;

	private GameObject _ol_1_Icon13;

	private GameObject _ol_1_Icon14;

	private GameObject _ol_1_Icon15;

	private GameObject _ol_1_Icon16;

	private GameObject _ol_1_Icon17;

	private GameObject _ol_1_Icon18;

	private GameObject _ol_1_Icon19;

	private GameObject _ol_1_Icon20;

	private GameObject _ol_1_Icon21;

	private GameObject _ol_1_Icon22;

	private GameObject _ol_1_Icon23;

	private GameObject _ol_1_Icon24;

	private GameObject _ol_1_Icon25;

	private GameObject _ol_1_Icon26;

	private GameObject _ol_1_Icon27;

	private GameObject _ol_1_Icon28;

	private GameObject _ol_1_Icon29;

	private GameObject _ol_1_Icon30;

	private GameObject _ol_1_Icon31;

	private GameObject _ol_1_Icon32;

	private GameObject _ol_1_Icon33;

	private GameObject _ol_1_Icon34;

	private GameObject _ol_1_Icon35;

	private GameObject _ol_1_Icon36;

	private GameObject _ol_1_Icon37;

	private GameObject _ol_1_Icon38;

	private GameObject _ol_1_Icon39;

	private GameObject _ol_1_Icon40;

	private Image _ol_1_IconImage1;

	private Image _ol_1_IconImage2;

	private Image _ol_1_IconImage3;

	private Image _ol_1_IconImage4;

	private Image _ol_1_IconImage5;

	private Image _ol_1_IconImage6;

	private Image _ol_1_IconImage7;

	private Image _ol_1_IconImage8;

	private Image _ol_1_IconImage9;

	private Image _ol_1_IconImage10;

	private Image _ol_1_IconImage11;

	private Image _ol_1_IconImage12;

	private Image _ol_1_IconImage13;

	private Image _ol_1_IconImage14;

	private Image _ol_1_IconImage15;

	private Image _ol_1_IconImage16;

	private Image _ol_1_IconImage17;

	private Image _ol_1_IconImage18;

	private Image _ol_1_IconImage19;

	private Image _ol_1_IconImage20;

	private Image _ol_1_IconImage21;

	private Image _ol_1_IconImage22;

	private Image _ol_1_IconImage23;

	private Image _ol_1_IconImage24;

	private Image _ol_1_IconImage25;

	private Image _ol_1_IconImage26;

	private Image _ol_1_IconImage27;

	private Image _ol_1_IconImage28;

	private Image _ol_1_IconImage29;

	private Image _ol_1_IconImage30;

	private Image _ol_1_IconImage31;

	private Image _ol_1_IconImage32;

	private Image _ol_1_IconImage33;

	private Image _ol_1_IconImage34;

	private Image _ol_1_IconImage35;

	private Image _ol_1_IconImage36;

	private Image _ol_1_IconImage37;

	private Image _ol_1_IconImage38;

	private Image _ol_1_IconImage39;

	private Image _ol_1_IconImage40;

	private GameObject _ol_1_name1;

	private GameObject _ol_1_name2;

	private GameObject _ol_1_name3;

	private GameObject _ol_1_name4;

	private GameObject _ol_1_name5;

	private GameObject _ol_1_name6;

	private GameObject _ol_1_name7;

	private GameObject _ol_1_name8;

	private GameObject _ol_1_name9;

	private GameObject _ol_1_name10;

	private GameObject _ol_1_name11;

	private GameObject _ol_1_name12;

	private GameObject _ol_1_name13;

	private GameObject _ol_1_name14;

	private GameObject _ol_1_name15;

	private GameObject _ol_1_name16;

	private GameObject _ol_1_name17;

	private GameObject _ol_1_name18;

	private GameObject _ol_1_name19;

	private GameObject _ol_1_name20;

	private GameObject _ol_1_name21;

	private GameObject _ol_1_name22;

	private GameObject _ol_1_name23;

	private GameObject _ol_1_name24;

	private GameObject _ol_1_name25;

	private GameObject _ol_1_name26;

	private GameObject _ol_1_name27;

	private GameObject _ol_1_name28;

	private GameObject _ol_1_name29;

	private GameObject _ol_1_name30;

	private GameObject _ol_1_name31;

	private GameObject _ol_1_name32;

	private GameObject _ol_1_name33;

	private GameObject _ol_1_name34;

	private GameObject _ol_1_name35;

	private GameObject _ol_1_name36;

	private GameObject _ol_1_name37;

	private GameObject _ol_1_name38;

	private GameObject _ol_1_name39;

	private GameObject _ol_1_name40;

	private Text _ol_1_nameText1;

	private Text _ol_1_nameText2;

	private Text _ol_1_nameText3;

	private Text _ol_1_nameText4;

	private Text _ol_1_nameText5;

	private Text _ol_1_nameText6;

	private Text _ol_1_nameText7;

	private Text _ol_1_nameText8;

	private Text _ol_1_nameText9;

	private Text _ol_1_nameText10;

	private Text _ol_1_nameText11;

	private Text _ol_1_nameText12;

	private Text _ol_1_nameText13;

	private Text _ol_1_nameText14;

	private Text _ol_1_nameText15;

	private Text _ol_1_nameText16;

	private Text _ol_1_nameText17;

	private Text _ol_1_nameText18;

	private Text _ol_1_nameText19;

	private Text _ol_1_nameText20;

	private Text _ol_1_nameText21;

	private Text _ol_1_nameText22;

	private Text _ol_1_nameText23;

	private Text _ol_1_nameText24;

	private Text _ol_1_nameText25;

	private Text _ol_1_nameText26;

	private Text _ol_1_nameText27;

	private Text _ol_1_nameText28;

	private Text _ol_1_nameText29;

	private Text _ol_1_nameText30;

	private Text _ol_1_nameText31;

	private Text _ol_1_nameText32;

	private Text _ol_1_nameText33;

	private Text _ol_1_nameText34;

	private Text _ol_1_nameText35;

	private Text _ol_1_nameText36;

	private Text _ol_1_nameText37;

	private Text _ol_1_nameText38;

	private Text _ol_1_nameText39;

	private Text _ol_1_nameText40;

	private GameObject _ol_1_money1;

	private GameObject _ol_1_money2;

	private GameObject _ol_1_money3;

	private GameObject _ol_1_money4;

	private GameObject _ol_1_money5;

	private GameObject _ol_1_money6;

	private GameObject _ol_1_money7;

	private GameObject _ol_1_money8;

	private GameObject _ol_1_money9;

	private GameObject _ol_1_money10;

	private GameObject _ol_1_money11;

	private GameObject _ol_1_money12;

	private GameObject _ol_1_money13;

	private GameObject _ol_1_money14;

	private GameObject _ol_1_money15;

	private GameObject _ol_1_money16;

	private GameObject _ol_1_money17;

	private GameObject _ol_1_money18;

	private GameObject _ol_1_money19;

	private GameObject _ol_1_money20;

	private GameObject _ol_1_money21;

	private GameObject _ol_1_money22;

	private GameObject _ol_1_money23;

	private GameObject _ol_1_money24;

	private GameObject _ol_1_money25;

	private GameObject _ol_1_money26;

	private GameObject _ol_1_money27;

	private GameObject _ol_1_money28;

	private GameObject _ol_1_money29;

	private GameObject _ol_1_money30;

	private GameObject _ol_1_money31;

	private GameObject _ol_1_money32;

	private GameObject _ol_1_money33;

	private GameObject _ol_1_money34;

	private GameObject _ol_1_money35;

	private GameObject _ol_1_money36;

	private GameObject _ol_1_money37;

	private GameObject _ol_1_money38;

	private GameObject _ol_1_money39;

	private GameObject _ol_1_money40;

	private Text _ol_1_moneyText1;

	private Text _ol_1_moneyText2;

	private Text _ol_1_moneyText3;

	private Text _ol_1_moneyText4;

	private Text _ol_1_moneyText5;

	private Text _ol_1_moneyText6;

	private Text _ol_1_moneyText7;

	private Text _ol_1_moneyText8;

	private Text _ol_1_moneyText9;

	private Text _ol_1_moneyText10;

	private Text _ol_1_moneyText11;

	private Text _ol_1_moneyText12;

	private Text _ol_1_moneyText13;

	private Text _ol_1_moneyText14;

	private Text _ol_1_moneyText15;

	private Text _ol_1_moneyText16;

	private Text _ol_1_moneyText17;

	private Text _ol_1_moneyText18;

	private Text _ol_1_moneyText19;

	private Text _ol_1_moneyText20;

	private Text _ol_1_moneyText21;

	private Text _ol_1_moneyText22;

	private Text _ol_1_moneyText23;

	private Text _ol_1_moneyText24;

	private Text _ol_1_moneyText25;

	private Text _ol_1_moneyText26;

	private Text _ol_1_moneyText27;

	private Text _ol_1_moneyText28;

	private Text _ol_1_moneyText29;

	private Text _ol_1_moneyText30;

	private Text _ol_1_moneyText31;

	private Text _ol_1_moneyText32;

	private Text _ol_1_moneyText33;

	private Text _ol_1_moneyText34;

	private Text _ol_1_moneyText35;

	private Text _ol_1_moneyText36;

	private Text _ol_1_moneyText37;

	private Text _ol_1_moneyText38;

	private Text _ol_1_moneyText39;

	private Text _ol_1_moneyText40;

	private GameObject _ol_1_lock1;

	private GameObject _ol_1_lock2;

	private GameObject _ol_1_lock3;

	private GameObject _ol_1_lock4;

	private GameObject _ol_1_lock5;

	private GameObject _ol_1_lock6;

	private GameObject _ol_1_lock7;

	private GameObject _ol_1_lock8;

	private GameObject _ol_1_lock9;

	private GameObject _ol_1_lock10;

	private GameObject _ol_1_lock11;

	private GameObject _ol_1_lock12;

	private GameObject _ol_1_lock13;

	private GameObject _ol_1_lock14;

	private GameObject _ol_1_lock15;

	private GameObject _ol_1_lock16;

	private GameObject _ol_1_lock17;

	private GameObject _ol_1_lock18;

	private GameObject _ol_1_lock19;

	private GameObject _ol_1_lock20;

	private GameObject _ol_1_lock21;

	private GameObject _ol_1_lock22;

	private GameObject _ol_1_lock23;

	private GameObject _ol_1_lock24;

	private GameObject _ol_1_lock25;

	private GameObject _ol_1_lock26;

	private GameObject _ol_1_lock27;

	private GameObject _ol_1_lock28;

	private GameObject _ol_1_lock29;

	private GameObject _ol_1_lock30;

	private GameObject _ol_1_lock31;

	private GameObject _ol_1_lock32;

	private GameObject _ol_1_lock33;

	private GameObject _ol_1_lock34;

	private GameObject _ol_1_lock35;

	private GameObject _ol_1_lock36;

	private GameObject _ol_1_lock37;

	private GameObject _ol_1_lock38;

	private GameObject _ol_1_lock39;

	private GameObject _ol_1_lock40;

	private GameObject _ol_1_lock_lv1;

	private GameObject _ol_1_lock_lv2;

	private GameObject _ol_1_lock_lv3;

	private GameObject _ol_1_lock_lv4;

	private GameObject _ol_1_lock_lv5;

	private GameObject _ol_1_lock_lv6;

	private GameObject _ol_1_lock_lv7;

	private GameObject _ol_1_lock_lv8;

	private GameObject _ol_1_lock_lv9;

	private GameObject _ol_1_lock_lv10;

	private GameObject _ol_1_lock_lv11;

	private GameObject _ol_1_lock_lv12;

	private GameObject _ol_1_lock_lv13;

	private GameObject _ol_1_lock_lv14;

	private GameObject _ol_1_lock_lv15;

	private GameObject _ol_1_lock_lv16;

	private GameObject _ol_1_lock_lv17;

	private GameObject _ol_1_lock_lv18;

	private GameObject _ol_1_lock_lv19;

	private GameObject _ol_1_lock_lv20;

	private GameObject _ol_1_lock_lv21;

	private GameObject _ol_1_lock_lv22;

	private GameObject _ol_1_lock_lv23;

	private GameObject _ol_1_lock_lv24;

	private GameObject _ol_1_lock_lv25;

	private GameObject _ol_1_lock_lv26;

	private GameObject _ol_1_lock_lv27;

	private GameObject _ol_1_lock_lv28;

	private GameObject _ol_1_lock_lv29;

	private GameObject _ol_1_lock_lv30;

	private GameObject _ol_1_lock_lv31;

	private GameObject _ol_1_lock_lv32;

	private GameObject _ol_1_lock_lv33;

	private GameObject _ol_1_lock_lv34;

	private GameObject _ol_1_lock_lv35;

	private GameObject _ol_1_lock_lv36;

	private GameObject _ol_1_lock_lv37;

	private GameObject _ol_1_lock_lv38;

	private GameObject _ol_1_lock_lv39;

	private GameObject _ol_1_lock_lv40;

	private Text _ol_1_lock_lvText1;

	private Text _ol_1_lock_lvText2;

	private Text _ol_1_lock_lvText3;

	private Text _ol_1_lock_lvText4;

	private Text _ol_1_lock_lvText5;

	private Text _ol_1_lock_lvText6;

	private Text _ol_1_lock_lvText7;

	private Text _ol_1_lock_lvText8;

	private Text _ol_1_lock_lvText9;

	private Text _ol_1_lock_lvText10;

	private Text _ol_1_lock_lvText11;

	private Text _ol_1_lock_lvText12;

	private Text _ol_1_lock_lvText13;

	private Text _ol_1_lock_lvText14;

	private Text _ol_1_lock_lvText15;

	private Text _ol_1_lock_lvText16;

	private Text _ol_1_lock_lvText17;

	private Text _ol_1_lock_lvText18;

	private Text _ol_1_lock_lvText19;

	private Text _ol_1_lock_lvText20;

	private Text _ol_1_lock_lvText21;

	private Text _ol_1_lock_lvText22;

	private Text _ol_1_lock_lvText23;

	private Text _ol_1_lock_lvText24;

	private Text _ol_1_lock_lvText25;

	private Text _ol_1_lock_lvText26;

	private Text _ol_1_lock_lvText27;

	private Text _ol_1_lock_lvText28;

	private Text _ol_1_lock_lvText29;

	private Text _ol_1_lock_lvText30;

	private Text _ol_1_lock_lvText31;

	private Text _ol_1_lock_lvText32;

	private Text _ol_1_lock_lvText33;

	private Text _ol_1_lock_lvText34;

	private Text _ol_1_lock_lvText35;

	private Text _ol_1_lock_lvText36;

	private Text _ol_1_lock_lvText37;

	private Text _ol_1_lock_lvText38;

	private Text _ol_1_lock_lvText39;

	private Text _ol_1_lock_lvText40;

	private GameObject _or_weapon1;

	private GameObject _or_weapon2;

	private GameObject _or_weapon3;

	private GameObject _or_weapon4;

	private GameObject _or_weapon5;

	private Button _or_weaponButton1;

	private Button _or_weaponButton2;

	private Button _or_weaponButton3;

	private Button _or_weaponButton4;

	private Button _or_weaponButton5;

	private GameObject _or_weaponIcon1;

	private GameObject _or_weaponIcon2;

	private GameObject _or_weaponIcon3;

	private GameObject _or_weaponIcon4;

	private GameObject _or_weaponIcon5;

	private Image _or_weaponIconImage1;

	private Image _or_weaponIconImage2;

	private Image _or_weaponIconImage3;

	private Image _or_weaponIconImage4;

	private Image _or_weaponIconImage5;

	private GameObject _or_name1;

	private GameObject _or_name2;

	private GameObject _or_name3;

	private GameObject _or_name4;

	private GameObject _or_name5;

	private Text _or_nameText1;

	private Text _or_nameText2;

	private Text _or_nameText3;

	private Text _or_nameText4;

	private Text _or_nameText5;

	private GameObject _oweaponTool1;

	private GameObject _oweaponTool2;

	private GameObject _oweaponTool3;

	private GameObject _oweaponTool4;

	private Toggle _oweaponToolToggle1;

	private Toggle _oweaponToolToggle2;

	private Toggle _oweaponToolToggle3;

	private Toggle _oweaponToolToggle4;

	private GameObject _olevel;

	private Text _olevelText;

	private GameObject _ogold;

	private Text _ogoldText;

	private GameObject _oshop_r;

	private Button _oshop_rButton;

	private GameObject _oshop_s;

	private Button _oshop_sButton;

	private GameObject _oshop_x;

	private Button _oshop_xButton;

	private GameObject _oclose;

	private Text _ocloseText;

	private GameObject _ogold_des;

	private Text _ogold_desText;

	private GameObject _olevel_des;

	private Text _olevel_desText;

	private GameObject _olevel_des_sj;

	private Text _olevel_des_sjText;

	private GameObject _olevel_sj;

	private Text _olevel_sjText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/biochemical_z";

	private string _resourceAssetName = "biochemical_z_shop_weapon";

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

	public bool l_1_weaponShow1
	{
		get
		{
			if (_ol_1_weapon1 != null)
			{
				return _ol_1_weapon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow1 != value && _ol_1_weapon1 != null)
			{
				_ol_1_weapon1.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow2
	{
		get
		{
			if (_ol_1_weapon2 != null)
			{
				return _ol_1_weapon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow2 != value && _ol_1_weapon2 != null)
			{
				_ol_1_weapon2.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow3
	{
		get
		{
			if (_ol_1_weapon3 != null)
			{
				return _ol_1_weapon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow3 != value && _ol_1_weapon3 != null)
			{
				_ol_1_weapon3.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow4
	{
		get
		{
			if (_ol_1_weapon4 != null)
			{
				return _ol_1_weapon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow4 != value && _ol_1_weapon4 != null)
			{
				_ol_1_weapon4.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow5
	{
		get
		{
			if (_ol_1_weapon5 != null)
			{
				return _ol_1_weapon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow5 != value && _ol_1_weapon5 != null)
			{
				_ol_1_weapon5.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow6
	{
		get
		{
			if (_ol_1_weapon6 != null)
			{
				return _ol_1_weapon6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow6 != value && _ol_1_weapon6 != null)
			{
				_ol_1_weapon6.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow7
	{
		get
		{
			if (_ol_1_weapon7 != null)
			{
				return _ol_1_weapon7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow7 != value && _ol_1_weapon7 != null)
			{
				_ol_1_weapon7.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow8
	{
		get
		{
			if (_ol_1_weapon8 != null)
			{
				return _ol_1_weapon8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow8 != value && _ol_1_weapon8 != null)
			{
				_ol_1_weapon8.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow9
	{
		get
		{
			if (_ol_1_weapon9 != null)
			{
				return _ol_1_weapon9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow9 != value && _ol_1_weapon9 != null)
			{
				_ol_1_weapon9.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow10
	{
		get
		{
			if (_ol_1_weapon10 != null)
			{
				return _ol_1_weapon10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow10 != value && _ol_1_weapon10 != null)
			{
				_ol_1_weapon10.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow11
	{
		get
		{
			if (_ol_1_weapon11 != null)
			{
				return _ol_1_weapon11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow11 != value && _ol_1_weapon11 != null)
			{
				_ol_1_weapon11.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow12
	{
		get
		{
			if (_ol_1_weapon12 != null)
			{
				return _ol_1_weapon12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow12 != value && _ol_1_weapon12 != null)
			{
				_ol_1_weapon12.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow13
	{
		get
		{
			if (_ol_1_weapon13 != null)
			{
				return _ol_1_weapon13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow13 != value && _ol_1_weapon13 != null)
			{
				_ol_1_weapon13.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow14
	{
		get
		{
			if (_ol_1_weapon14 != null)
			{
				return _ol_1_weapon14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow14 != value && _ol_1_weapon14 != null)
			{
				_ol_1_weapon14.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow15
	{
		get
		{
			if (_ol_1_weapon15 != null)
			{
				return _ol_1_weapon15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow15 != value && _ol_1_weapon15 != null)
			{
				_ol_1_weapon15.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow16
	{
		get
		{
			if (_ol_1_weapon16 != null)
			{
				return _ol_1_weapon16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow16 != value && _ol_1_weapon16 != null)
			{
				_ol_1_weapon16.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow17
	{
		get
		{
			if (_ol_1_weapon17 != null)
			{
				return _ol_1_weapon17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow17 != value && _ol_1_weapon17 != null)
			{
				_ol_1_weapon17.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow18
	{
		get
		{
			if (_ol_1_weapon18 != null)
			{
				return _ol_1_weapon18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow18 != value && _ol_1_weapon18 != null)
			{
				_ol_1_weapon18.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow19
	{
		get
		{
			if (_ol_1_weapon19 != null)
			{
				return _ol_1_weapon19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow19 != value && _ol_1_weapon19 != null)
			{
				_ol_1_weapon19.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow20
	{
		get
		{
			if (_ol_1_weapon20 != null)
			{
				return _ol_1_weapon20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow20 != value && _ol_1_weapon20 != null)
			{
				_ol_1_weapon20.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow21
	{
		get
		{
			if (_ol_1_weapon21 != null)
			{
				return _ol_1_weapon21.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow21 != value && _ol_1_weapon21 != null)
			{
				_ol_1_weapon21.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow22
	{
		get
		{
			if (_ol_1_weapon22 != null)
			{
				return _ol_1_weapon22.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow22 != value && _ol_1_weapon22 != null)
			{
				_ol_1_weapon22.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow23
	{
		get
		{
			if (_ol_1_weapon23 != null)
			{
				return _ol_1_weapon23.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow23 != value && _ol_1_weapon23 != null)
			{
				_ol_1_weapon23.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow24
	{
		get
		{
			if (_ol_1_weapon24 != null)
			{
				return _ol_1_weapon24.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow24 != value && _ol_1_weapon24 != null)
			{
				_ol_1_weapon24.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow25
	{
		get
		{
			if (_ol_1_weapon25 != null)
			{
				return _ol_1_weapon25.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow25 != value && _ol_1_weapon25 != null)
			{
				_ol_1_weapon25.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow26
	{
		get
		{
			if (_ol_1_weapon26 != null)
			{
				return _ol_1_weapon26.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow26 != value && _ol_1_weapon26 != null)
			{
				_ol_1_weapon26.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow27
	{
		get
		{
			if (_ol_1_weapon27 != null)
			{
				return _ol_1_weapon27.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow27 != value && _ol_1_weapon27 != null)
			{
				_ol_1_weapon27.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow28
	{
		get
		{
			if (_ol_1_weapon28 != null)
			{
				return _ol_1_weapon28.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow28 != value && _ol_1_weapon28 != null)
			{
				_ol_1_weapon28.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow29
	{
		get
		{
			if (_ol_1_weapon29 != null)
			{
				return _ol_1_weapon29.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow29 != value && _ol_1_weapon29 != null)
			{
				_ol_1_weapon29.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow30
	{
		get
		{
			if (_ol_1_weapon30 != null)
			{
				return _ol_1_weapon30.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow30 != value && _ol_1_weapon30 != null)
			{
				_ol_1_weapon30.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow31
	{
		get
		{
			if (_ol_1_weapon31 != null)
			{
				return _ol_1_weapon31.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow31 != value && _ol_1_weapon31 != null)
			{
				_ol_1_weapon31.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow32
	{
		get
		{
			if (_ol_1_weapon32 != null)
			{
				return _ol_1_weapon32.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow32 != value && _ol_1_weapon32 != null)
			{
				_ol_1_weapon32.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow33
	{
		get
		{
			if (_ol_1_weapon33 != null)
			{
				return _ol_1_weapon33.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow33 != value && _ol_1_weapon33 != null)
			{
				_ol_1_weapon33.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow34
	{
		get
		{
			if (_ol_1_weapon34 != null)
			{
				return _ol_1_weapon34.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow34 != value && _ol_1_weapon34 != null)
			{
				_ol_1_weapon34.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow35
	{
		get
		{
			if (_ol_1_weapon35 != null)
			{
				return _ol_1_weapon35.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow35 != value && _ol_1_weapon35 != null)
			{
				_ol_1_weapon35.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow36
	{
		get
		{
			if (_ol_1_weapon36 != null)
			{
				return _ol_1_weapon36.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow36 != value && _ol_1_weapon36 != null)
			{
				_ol_1_weapon36.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow37
	{
		get
		{
			if (_ol_1_weapon37 != null)
			{
				return _ol_1_weapon37.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow37 != value && _ol_1_weapon37 != null)
			{
				_ol_1_weapon37.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow38
	{
		get
		{
			if (_ol_1_weapon38 != null)
			{
				return _ol_1_weapon38.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow38 != value && _ol_1_weapon38 != null)
			{
				_ol_1_weapon38.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow39
	{
		get
		{
			if (_ol_1_weapon39 != null)
			{
				return _ol_1_weapon39.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow39 != value && _ol_1_weapon39 != null)
			{
				_ol_1_weapon39.SetObjectActive(value);
			}
		}
	}

	public bool l_1_weaponShow40
	{
		get
		{
			if (_ol_1_weapon40 != null)
			{
				return _ol_1_weapon40.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_weaponShow40 != value && _ol_1_weapon40 != null)
			{
				_ol_1_weapon40.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked1
	{
		get
		{
			if (_ol_1_weaponButton1 != null)
			{
				return _ol_1_weaponButton1.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked1 != value && _ol_1_weaponButton1 != null)
			{
				_ol_1_weaponButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked2
	{
		get
		{
			if (_ol_1_weaponButton2 != null)
			{
				return _ol_1_weaponButton2.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked2 != value && _ol_1_weaponButton2 != null)
			{
				_ol_1_weaponButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked3
	{
		get
		{
			if (_ol_1_weaponButton3 != null)
			{
				return _ol_1_weaponButton3.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked3 != value && _ol_1_weaponButton3 != null)
			{
				_ol_1_weaponButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked4
	{
		get
		{
			if (_ol_1_weaponButton4 != null)
			{
				return _ol_1_weaponButton4.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked4 != value && _ol_1_weaponButton4 != null)
			{
				_ol_1_weaponButton4.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked5
	{
		get
		{
			if (_ol_1_weaponButton5 != null)
			{
				return _ol_1_weaponButton5.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked5 != value && _ol_1_weaponButton5 != null)
			{
				_ol_1_weaponButton5.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked6
	{
		get
		{
			if (_ol_1_weaponButton6 != null)
			{
				return _ol_1_weaponButton6.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked6 != value && _ol_1_weaponButton6 != null)
			{
				_ol_1_weaponButton6.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked7
	{
		get
		{
			if (_ol_1_weaponButton7 != null)
			{
				return _ol_1_weaponButton7.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked7 != value && _ol_1_weaponButton7 != null)
			{
				_ol_1_weaponButton7.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked8
	{
		get
		{
			if (_ol_1_weaponButton8 != null)
			{
				return _ol_1_weaponButton8.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked8 != value && _ol_1_weaponButton8 != null)
			{
				_ol_1_weaponButton8.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked9
	{
		get
		{
			if (_ol_1_weaponButton9 != null)
			{
				return _ol_1_weaponButton9.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked9 != value && _ol_1_weaponButton9 != null)
			{
				_ol_1_weaponButton9.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked10
	{
		get
		{
			if (_ol_1_weaponButton10 != null)
			{
				return _ol_1_weaponButton10.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked10 != value && _ol_1_weaponButton10 != null)
			{
				_ol_1_weaponButton10.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked11
	{
		get
		{
			if (_ol_1_weaponButton11 != null)
			{
				return _ol_1_weaponButton11.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked11 != value && _ol_1_weaponButton11 != null)
			{
				_ol_1_weaponButton11.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked12
	{
		get
		{
			if (_ol_1_weaponButton12 != null)
			{
				return _ol_1_weaponButton12.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked12 != value && _ol_1_weaponButton12 != null)
			{
				_ol_1_weaponButton12.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked13
	{
		get
		{
			if (_ol_1_weaponButton13 != null)
			{
				return _ol_1_weaponButton13.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked13 != value && _ol_1_weaponButton13 != null)
			{
				_ol_1_weaponButton13.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked14
	{
		get
		{
			if (_ol_1_weaponButton14 != null)
			{
				return _ol_1_weaponButton14.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked14 != value && _ol_1_weaponButton14 != null)
			{
				_ol_1_weaponButton14.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked15
	{
		get
		{
			if (_ol_1_weaponButton15 != null)
			{
				return _ol_1_weaponButton15.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked15 != value && _ol_1_weaponButton15 != null)
			{
				_ol_1_weaponButton15.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked16
	{
		get
		{
			if (_ol_1_weaponButton16 != null)
			{
				return _ol_1_weaponButton16.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked16 != value && _ol_1_weaponButton16 != null)
			{
				_ol_1_weaponButton16.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked17
	{
		get
		{
			if (_ol_1_weaponButton17 != null)
			{
				return _ol_1_weaponButton17.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked17 != value && _ol_1_weaponButton17 != null)
			{
				_ol_1_weaponButton17.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked18
	{
		get
		{
			if (_ol_1_weaponButton18 != null)
			{
				return _ol_1_weaponButton18.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked18 != value && _ol_1_weaponButton18 != null)
			{
				_ol_1_weaponButton18.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked19
	{
		get
		{
			if (_ol_1_weaponButton19 != null)
			{
				return _ol_1_weaponButton19.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked19 != value && _ol_1_weaponButton19 != null)
			{
				_ol_1_weaponButton19.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked20
	{
		get
		{
			if (_ol_1_weaponButton20 != null)
			{
				return _ol_1_weaponButton20.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked20 != value && _ol_1_weaponButton20 != null)
			{
				_ol_1_weaponButton20.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked21
	{
		get
		{
			if (_ol_1_weaponButton21 != null)
			{
				return _ol_1_weaponButton21.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked21 != value && _ol_1_weaponButton21 != null)
			{
				_ol_1_weaponButton21.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked22
	{
		get
		{
			if (_ol_1_weaponButton22 != null)
			{
				return _ol_1_weaponButton22.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked22 != value && _ol_1_weaponButton22 != null)
			{
				_ol_1_weaponButton22.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked23
	{
		get
		{
			if (_ol_1_weaponButton23 != null)
			{
				return _ol_1_weaponButton23.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked23 != value && _ol_1_weaponButton23 != null)
			{
				_ol_1_weaponButton23.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked24
	{
		get
		{
			if (_ol_1_weaponButton24 != null)
			{
				return _ol_1_weaponButton24.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked24 != value && _ol_1_weaponButton24 != null)
			{
				_ol_1_weaponButton24.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked25
	{
		get
		{
			if (_ol_1_weaponButton25 != null)
			{
				return _ol_1_weaponButton25.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked25 != value && _ol_1_weaponButton25 != null)
			{
				_ol_1_weaponButton25.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked26
	{
		get
		{
			if (_ol_1_weaponButton26 != null)
			{
				return _ol_1_weaponButton26.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked26 != value && _ol_1_weaponButton26 != null)
			{
				_ol_1_weaponButton26.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked27
	{
		get
		{
			if (_ol_1_weaponButton27 != null)
			{
				return _ol_1_weaponButton27.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked27 != value && _ol_1_weaponButton27 != null)
			{
				_ol_1_weaponButton27.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked28
	{
		get
		{
			if (_ol_1_weaponButton28 != null)
			{
				return _ol_1_weaponButton28.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked28 != value && _ol_1_weaponButton28 != null)
			{
				_ol_1_weaponButton28.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked29
	{
		get
		{
			if (_ol_1_weaponButton29 != null)
			{
				return _ol_1_weaponButton29.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked29 != value && _ol_1_weaponButton29 != null)
			{
				_ol_1_weaponButton29.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked30
	{
		get
		{
			if (_ol_1_weaponButton30 != null)
			{
				return _ol_1_weaponButton30.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked30 != value && _ol_1_weaponButton30 != null)
			{
				_ol_1_weaponButton30.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked31
	{
		get
		{
			if (_ol_1_weaponButton31 != null)
			{
				return _ol_1_weaponButton31.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked31 != value && _ol_1_weaponButton31 != null)
			{
				_ol_1_weaponButton31.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked32
	{
		get
		{
			if (_ol_1_weaponButton32 != null)
			{
				return _ol_1_weaponButton32.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked32 != value && _ol_1_weaponButton32 != null)
			{
				_ol_1_weaponButton32.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked33
	{
		get
		{
			if (_ol_1_weaponButton33 != null)
			{
				return _ol_1_weaponButton33.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked33 != value && _ol_1_weaponButton33 != null)
			{
				_ol_1_weaponButton33.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked34
	{
		get
		{
			if (_ol_1_weaponButton34 != null)
			{
				return _ol_1_weaponButton34.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked34 != value && _ol_1_weaponButton34 != null)
			{
				_ol_1_weaponButton34.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked35
	{
		get
		{
			if (_ol_1_weaponButton35 != null)
			{
				return _ol_1_weaponButton35.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked35 != value && _ol_1_weaponButton35 != null)
			{
				_ol_1_weaponButton35.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked36
	{
		get
		{
			if (_ol_1_weaponButton36 != null)
			{
				return _ol_1_weaponButton36.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked36 != value && _ol_1_weaponButton36 != null)
			{
				_ol_1_weaponButton36.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked37
	{
		get
		{
			if (_ol_1_weaponButton37 != null)
			{
				return _ol_1_weaponButton37.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked37 != value && _ol_1_weaponButton37 != null)
			{
				_ol_1_weaponButton37.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked38
	{
		get
		{
			if (_ol_1_weaponButton38 != null)
			{
				return _ol_1_weaponButton38.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked38 != value && _ol_1_weaponButton38 != null)
			{
				_ol_1_weaponButton38.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked39
	{
		get
		{
			if (_ol_1_weaponButton39 != null)
			{
				return _ol_1_weaponButton39.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked39 != value && _ol_1_weaponButton39 != null)
			{
				_ol_1_weaponButton39.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent l_1_weaponClicked40
	{
		get
		{
			if (_ol_1_weaponButton40 != null)
			{
				return _ol_1_weaponButton40.onClick;
			}
			return null;
		}
		set
		{
			if (l_1_weaponClicked40 != value && _ol_1_weaponButton40 != null)
			{
				_ol_1_weaponButton40.onClick = value;
			}
		}
	}

	public Sprite l_1_IconSprite1
	{
		get
		{
			if (_ol_1_IconImage1 != null)
			{
				return _ol_1_IconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite1 != value && _ol_1_IconImage1 != null)
			{
				_ol_1_IconImage1.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite2
	{
		get
		{
			if (_ol_1_IconImage2 != null)
			{
				return _ol_1_IconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite2 != value && _ol_1_IconImage2 != null)
			{
				_ol_1_IconImage2.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite3
	{
		get
		{
			if (_ol_1_IconImage3 != null)
			{
				return _ol_1_IconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite3 != value && _ol_1_IconImage3 != null)
			{
				_ol_1_IconImage3.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite4
	{
		get
		{
			if (_ol_1_IconImage4 != null)
			{
				return _ol_1_IconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite4 != value && _ol_1_IconImage4 != null)
			{
				_ol_1_IconImage4.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite5
	{
		get
		{
			if (_ol_1_IconImage5 != null)
			{
				return _ol_1_IconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite5 != value && _ol_1_IconImage5 != null)
			{
				_ol_1_IconImage5.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite6
	{
		get
		{
			if (_ol_1_IconImage6 != null)
			{
				return _ol_1_IconImage6.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite6 != value && _ol_1_IconImage6 != null)
			{
				_ol_1_IconImage6.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite7
	{
		get
		{
			if (_ol_1_IconImage7 != null)
			{
				return _ol_1_IconImage7.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite7 != value && _ol_1_IconImage7 != null)
			{
				_ol_1_IconImage7.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite8
	{
		get
		{
			if (_ol_1_IconImage8 != null)
			{
				return _ol_1_IconImage8.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite8 != value && _ol_1_IconImage8 != null)
			{
				_ol_1_IconImage8.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite9
	{
		get
		{
			if (_ol_1_IconImage9 != null)
			{
				return _ol_1_IconImage9.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite9 != value && _ol_1_IconImage9 != null)
			{
				_ol_1_IconImage9.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite10
	{
		get
		{
			if (_ol_1_IconImage10 != null)
			{
				return _ol_1_IconImage10.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite10 != value && _ol_1_IconImage10 != null)
			{
				_ol_1_IconImage10.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite11
	{
		get
		{
			if (_ol_1_IconImage11 != null)
			{
				return _ol_1_IconImage11.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite11 != value && _ol_1_IconImage11 != null)
			{
				_ol_1_IconImage11.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite12
	{
		get
		{
			if (_ol_1_IconImage12 != null)
			{
				return _ol_1_IconImage12.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite12 != value && _ol_1_IconImage12 != null)
			{
				_ol_1_IconImage12.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite13
	{
		get
		{
			if (_ol_1_IconImage13 != null)
			{
				return _ol_1_IconImage13.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite13 != value && _ol_1_IconImage13 != null)
			{
				_ol_1_IconImage13.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite14
	{
		get
		{
			if (_ol_1_IconImage14 != null)
			{
				return _ol_1_IconImage14.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite14 != value && _ol_1_IconImage14 != null)
			{
				_ol_1_IconImage14.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite15
	{
		get
		{
			if (_ol_1_IconImage15 != null)
			{
				return _ol_1_IconImage15.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite15 != value && _ol_1_IconImage15 != null)
			{
				_ol_1_IconImage15.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite16
	{
		get
		{
			if (_ol_1_IconImage16 != null)
			{
				return _ol_1_IconImage16.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite16 != value && _ol_1_IconImage16 != null)
			{
				_ol_1_IconImage16.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite17
	{
		get
		{
			if (_ol_1_IconImage17 != null)
			{
				return _ol_1_IconImage17.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite17 != value && _ol_1_IconImage17 != null)
			{
				_ol_1_IconImage17.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite18
	{
		get
		{
			if (_ol_1_IconImage18 != null)
			{
				return _ol_1_IconImage18.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite18 != value && _ol_1_IconImage18 != null)
			{
				_ol_1_IconImage18.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite19
	{
		get
		{
			if (_ol_1_IconImage19 != null)
			{
				return _ol_1_IconImage19.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite19 != value && _ol_1_IconImage19 != null)
			{
				_ol_1_IconImage19.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite20
	{
		get
		{
			if (_ol_1_IconImage20 != null)
			{
				return _ol_1_IconImage20.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite20 != value && _ol_1_IconImage20 != null)
			{
				_ol_1_IconImage20.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite21
	{
		get
		{
			if (_ol_1_IconImage21 != null)
			{
				return _ol_1_IconImage21.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite21 != value && _ol_1_IconImage21 != null)
			{
				_ol_1_IconImage21.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite22
	{
		get
		{
			if (_ol_1_IconImage22 != null)
			{
				return _ol_1_IconImage22.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite22 != value && _ol_1_IconImage22 != null)
			{
				_ol_1_IconImage22.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite23
	{
		get
		{
			if (_ol_1_IconImage23 != null)
			{
				return _ol_1_IconImage23.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite23 != value && _ol_1_IconImage23 != null)
			{
				_ol_1_IconImage23.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite24
	{
		get
		{
			if (_ol_1_IconImage24 != null)
			{
				return _ol_1_IconImage24.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite24 != value && _ol_1_IconImage24 != null)
			{
				_ol_1_IconImage24.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite25
	{
		get
		{
			if (_ol_1_IconImage25 != null)
			{
				return _ol_1_IconImage25.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite25 != value && _ol_1_IconImage25 != null)
			{
				_ol_1_IconImage25.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite26
	{
		get
		{
			if (_ol_1_IconImage26 != null)
			{
				return _ol_1_IconImage26.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite26 != value && _ol_1_IconImage26 != null)
			{
				_ol_1_IconImage26.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite27
	{
		get
		{
			if (_ol_1_IconImage27 != null)
			{
				return _ol_1_IconImage27.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite27 != value && _ol_1_IconImage27 != null)
			{
				_ol_1_IconImage27.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite28
	{
		get
		{
			if (_ol_1_IconImage28 != null)
			{
				return _ol_1_IconImage28.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite28 != value && _ol_1_IconImage28 != null)
			{
				_ol_1_IconImage28.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite29
	{
		get
		{
			if (_ol_1_IconImage29 != null)
			{
				return _ol_1_IconImage29.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite29 != value && _ol_1_IconImage29 != null)
			{
				_ol_1_IconImage29.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite30
	{
		get
		{
			if (_ol_1_IconImage30 != null)
			{
				return _ol_1_IconImage30.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite30 != value && _ol_1_IconImage30 != null)
			{
				_ol_1_IconImage30.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite31
	{
		get
		{
			if (_ol_1_IconImage31 != null)
			{
				return _ol_1_IconImage31.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite31 != value && _ol_1_IconImage31 != null)
			{
				_ol_1_IconImage31.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite32
	{
		get
		{
			if (_ol_1_IconImage32 != null)
			{
				return _ol_1_IconImage32.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite32 != value && _ol_1_IconImage32 != null)
			{
				_ol_1_IconImage32.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite33
	{
		get
		{
			if (_ol_1_IconImage33 != null)
			{
				return _ol_1_IconImage33.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite33 != value && _ol_1_IconImage33 != null)
			{
				_ol_1_IconImage33.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite34
	{
		get
		{
			if (_ol_1_IconImage34 != null)
			{
				return _ol_1_IconImage34.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite34 != value && _ol_1_IconImage34 != null)
			{
				_ol_1_IconImage34.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite35
	{
		get
		{
			if (_ol_1_IconImage35 != null)
			{
				return _ol_1_IconImage35.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite35 != value && _ol_1_IconImage35 != null)
			{
				_ol_1_IconImage35.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite36
	{
		get
		{
			if (_ol_1_IconImage36 != null)
			{
				return _ol_1_IconImage36.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite36 != value && _ol_1_IconImage36 != null)
			{
				_ol_1_IconImage36.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite37
	{
		get
		{
			if (_ol_1_IconImage37 != null)
			{
				return _ol_1_IconImage37.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite37 != value && _ol_1_IconImage37 != null)
			{
				_ol_1_IconImage37.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite38
	{
		get
		{
			if (_ol_1_IconImage38 != null)
			{
				return _ol_1_IconImage38.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite38 != value && _ol_1_IconImage38 != null)
			{
				_ol_1_IconImage38.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite39
	{
		get
		{
			if (_ol_1_IconImage39 != null)
			{
				return _ol_1_IconImage39.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite39 != value && _ol_1_IconImage39 != null)
			{
				_ol_1_IconImage39.sprite = value;
			}
		}
	}

	public Sprite l_1_IconSprite40
	{
		get
		{
			if (_ol_1_IconImage40 != null)
			{
				return _ol_1_IconImage40.sprite;
			}
			return null;
		}
		set
		{
			if (l_1_IconSprite40 != value && _ol_1_IconImage40 != null)
			{
				_ol_1_IconImage40.sprite = value;
			}
		}
	}

	public Color l_1_IconColor1
	{
		get
		{
			if (_ol_1_IconImage1 != null)
			{
				return _ol_1_IconImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor1 != value && _ol_1_IconImage1 != null)
			{
				_ol_1_IconImage1.color = value;
			}
		}
	}

	public Color l_1_IconColor2
	{
		get
		{
			if (_ol_1_IconImage2 != null)
			{
				return _ol_1_IconImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor2 != value && _ol_1_IconImage2 != null)
			{
				_ol_1_IconImage2.color = value;
			}
		}
	}

	public Color l_1_IconColor3
	{
		get
		{
			if (_ol_1_IconImage3 != null)
			{
				return _ol_1_IconImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor3 != value && _ol_1_IconImage3 != null)
			{
				_ol_1_IconImage3.color = value;
			}
		}
	}

	public Color l_1_IconColor4
	{
		get
		{
			if (_ol_1_IconImage4 != null)
			{
				return _ol_1_IconImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor4 != value && _ol_1_IconImage4 != null)
			{
				_ol_1_IconImage4.color = value;
			}
		}
	}

	public Color l_1_IconColor5
	{
		get
		{
			if (_ol_1_IconImage5 != null)
			{
				return _ol_1_IconImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor5 != value && _ol_1_IconImage5 != null)
			{
				_ol_1_IconImage5.color = value;
			}
		}
	}

	public Color l_1_IconColor6
	{
		get
		{
			if (_ol_1_IconImage6 != null)
			{
				return _ol_1_IconImage6.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor6 != value && _ol_1_IconImage6 != null)
			{
				_ol_1_IconImage6.color = value;
			}
		}
	}

	public Color l_1_IconColor7
	{
		get
		{
			if (_ol_1_IconImage7 != null)
			{
				return _ol_1_IconImage7.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor7 != value && _ol_1_IconImage7 != null)
			{
				_ol_1_IconImage7.color = value;
			}
		}
	}

	public Color l_1_IconColor8
	{
		get
		{
			if (_ol_1_IconImage8 != null)
			{
				return _ol_1_IconImage8.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor8 != value && _ol_1_IconImage8 != null)
			{
				_ol_1_IconImage8.color = value;
			}
		}
	}

	public Color l_1_IconColor9
	{
		get
		{
			if (_ol_1_IconImage9 != null)
			{
				return _ol_1_IconImage9.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor9 != value && _ol_1_IconImage9 != null)
			{
				_ol_1_IconImage9.color = value;
			}
		}
	}

	public Color l_1_IconColor10
	{
		get
		{
			if (_ol_1_IconImage10 != null)
			{
				return _ol_1_IconImage10.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor10 != value && _ol_1_IconImage10 != null)
			{
				_ol_1_IconImage10.color = value;
			}
		}
	}

	public Color l_1_IconColor11
	{
		get
		{
			if (_ol_1_IconImage11 != null)
			{
				return _ol_1_IconImage11.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor11 != value && _ol_1_IconImage11 != null)
			{
				_ol_1_IconImage11.color = value;
			}
		}
	}

	public Color l_1_IconColor12
	{
		get
		{
			if (_ol_1_IconImage12 != null)
			{
				return _ol_1_IconImage12.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor12 != value && _ol_1_IconImage12 != null)
			{
				_ol_1_IconImage12.color = value;
			}
		}
	}

	public Color l_1_IconColor13
	{
		get
		{
			if (_ol_1_IconImage13 != null)
			{
				return _ol_1_IconImage13.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor13 != value && _ol_1_IconImage13 != null)
			{
				_ol_1_IconImage13.color = value;
			}
		}
	}

	public Color l_1_IconColor14
	{
		get
		{
			if (_ol_1_IconImage14 != null)
			{
				return _ol_1_IconImage14.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor14 != value && _ol_1_IconImage14 != null)
			{
				_ol_1_IconImage14.color = value;
			}
		}
	}

	public Color l_1_IconColor15
	{
		get
		{
			if (_ol_1_IconImage15 != null)
			{
				return _ol_1_IconImage15.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor15 != value && _ol_1_IconImage15 != null)
			{
				_ol_1_IconImage15.color = value;
			}
		}
	}

	public Color l_1_IconColor16
	{
		get
		{
			if (_ol_1_IconImage16 != null)
			{
				return _ol_1_IconImage16.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor16 != value && _ol_1_IconImage16 != null)
			{
				_ol_1_IconImage16.color = value;
			}
		}
	}

	public Color l_1_IconColor17
	{
		get
		{
			if (_ol_1_IconImage17 != null)
			{
				return _ol_1_IconImage17.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor17 != value && _ol_1_IconImage17 != null)
			{
				_ol_1_IconImage17.color = value;
			}
		}
	}

	public Color l_1_IconColor18
	{
		get
		{
			if (_ol_1_IconImage18 != null)
			{
				return _ol_1_IconImage18.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor18 != value && _ol_1_IconImage18 != null)
			{
				_ol_1_IconImage18.color = value;
			}
		}
	}

	public Color l_1_IconColor19
	{
		get
		{
			if (_ol_1_IconImage19 != null)
			{
				return _ol_1_IconImage19.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor19 != value && _ol_1_IconImage19 != null)
			{
				_ol_1_IconImage19.color = value;
			}
		}
	}

	public Color l_1_IconColor20
	{
		get
		{
			if (_ol_1_IconImage20 != null)
			{
				return _ol_1_IconImage20.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor20 != value && _ol_1_IconImage20 != null)
			{
				_ol_1_IconImage20.color = value;
			}
		}
	}

	public Color l_1_IconColor21
	{
		get
		{
			if (_ol_1_IconImage21 != null)
			{
				return _ol_1_IconImage21.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor21 != value && _ol_1_IconImage21 != null)
			{
				_ol_1_IconImage21.color = value;
			}
		}
	}

	public Color l_1_IconColor22
	{
		get
		{
			if (_ol_1_IconImage22 != null)
			{
				return _ol_1_IconImage22.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor22 != value && _ol_1_IconImage22 != null)
			{
				_ol_1_IconImage22.color = value;
			}
		}
	}

	public Color l_1_IconColor23
	{
		get
		{
			if (_ol_1_IconImage23 != null)
			{
				return _ol_1_IconImage23.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor23 != value && _ol_1_IconImage23 != null)
			{
				_ol_1_IconImage23.color = value;
			}
		}
	}

	public Color l_1_IconColor24
	{
		get
		{
			if (_ol_1_IconImage24 != null)
			{
				return _ol_1_IconImage24.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor24 != value && _ol_1_IconImage24 != null)
			{
				_ol_1_IconImage24.color = value;
			}
		}
	}

	public Color l_1_IconColor25
	{
		get
		{
			if (_ol_1_IconImage25 != null)
			{
				return _ol_1_IconImage25.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor25 != value && _ol_1_IconImage25 != null)
			{
				_ol_1_IconImage25.color = value;
			}
		}
	}

	public Color l_1_IconColor26
	{
		get
		{
			if (_ol_1_IconImage26 != null)
			{
				return _ol_1_IconImage26.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor26 != value && _ol_1_IconImage26 != null)
			{
				_ol_1_IconImage26.color = value;
			}
		}
	}

	public Color l_1_IconColor27
	{
		get
		{
			if (_ol_1_IconImage27 != null)
			{
				return _ol_1_IconImage27.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor27 != value && _ol_1_IconImage27 != null)
			{
				_ol_1_IconImage27.color = value;
			}
		}
	}

	public Color l_1_IconColor28
	{
		get
		{
			if (_ol_1_IconImage28 != null)
			{
				return _ol_1_IconImage28.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor28 != value && _ol_1_IconImage28 != null)
			{
				_ol_1_IconImage28.color = value;
			}
		}
	}

	public Color l_1_IconColor29
	{
		get
		{
			if (_ol_1_IconImage29 != null)
			{
				return _ol_1_IconImage29.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor29 != value && _ol_1_IconImage29 != null)
			{
				_ol_1_IconImage29.color = value;
			}
		}
	}

	public Color l_1_IconColor30
	{
		get
		{
			if (_ol_1_IconImage30 != null)
			{
				return _ol_1_IconImage30.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor30 != value && _ol_1_IconImage30 != null)
			{
				_ol_1_IconImage30.color = value;
			}
		}
	}

	public Color l_1_IconColor31
	{
		get
		{
			if (_ol_1_IconImage31 != null)
			{
				return _ol_1_IconImage31.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor31 != value && _ol_1_IconImage31 != null)
			{
				_ol_1_IconImage31.color = value;
			}
		}
	}

	public Color l_1_IconColor32
	{
		get
		{
			if (_ol_1_IconImage32 != null)
			{
				return _ol_1_IconImage32.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor32 != value && _ol_1_IconImage32 != null)
			{
				_ol_1_IconImage32.color = value;
			}
		}
	}

	public Color l_1_IconColor33
	{
		get
		{
			if (_ol_1_IconImage33 != null)
			{
				return _ol_1_IconImage33.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor33 != value && _ol_1_IconImage33 != null)
			{
				_ol_1_IconImage33.color = value;
			}
		}
	}

	public Color l_1_IconColor34
	{
		get
		{
			if (_ol_1_IconImage34 != null)
			{
				return _ol_1_IconImage34.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor34 != value && _ol_1_IconImage34 != null)
			{
				_ol_1_IconImage34.color = value;
			}
		}
	}

	public Color l_1_IconColor35
	{
		get
		{
			if (_ol_1_IconImage35 != null)
			{
				return _ol_1_IconImage35.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor35 != value && _ol_1_IconImage35 != null)
			{
				_ol_1_IconImage35.color = value;
			}
		}
	}

	public Color l_1_IconColor36
	{
		get
		{
			if (_ol_1_IconImage36 != null)
			{
				return _ol_1_IconImage36.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor36 != value && _ol_1_IconImage36 != null)
			{
				_ol_1_IconImage36.color = value;
			}
		}
	}

	public Color l_1_IconColor37
	{
		get
		{
			if (_ol_1_IconImage37 != null)
			{
				return _ol_1_IconImage37.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor37 != value && _ol_1_IconImage37 != null)
			{
				_ol_1_IconImage37.color = value;
			}
		}
	}

	public Color l_1_IconColor38
	{
		get
		{
			if (_ol_1_IconImage38 != null)
			{
				return _ol_1_IconImage38.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor38 != value && _ol_1_IconImage38 != null)
			{
				_ol_1_IconImage38.color = value;
			}
		}
	}

	public Color l_1_IconColor39
	{
		get
		{
			if (_ol_1_IconImage39 != null)
			{
				return _ol_1_IconImage39.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor39 != value && _ol_1_IconImage39 != null)
			{
				_ol_1_IconImage39.color = value;
			}
		}
	}

	public Color l_1_IconColor40
	{
		get
		{
			if (_ol_1_IconImage40 != null)
			{
				return _ol_1_IconImage40.color;
			}
			return Color.white;
		}
		set
		{
			if (l_1_IconColor40 != value && _ol_1_IconImage40 != null)
			{
				_ol_1_IconImage40.color = value;
			}
		}
	}

	public string l_1_nameString1
	{
		get
		{
			if (_ol_1_nameText1 != null)
			{
				return _ol_1_nameText1.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString1 != value && _ol_1_nameText1 != null)
			{
				_ol_1_nameText1.text = value;
			}
		}
	}

	public string l_1_nameString2
	{
		get
		{
			if (_ol_1_nameText2 != null)
			{
				return _ol_1_nameText2.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString2 != value && _ol_1_nameText2 != null)
			{
				_ol_1_nameText2.text = value;
			}
		}
	}

	public string l_1_nameString3
	{
		get
		{
			if (_ol_1_nameText3 != null)
			{
				return _ol_1_nameText3.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString3 != value && _ol_1_nameText3 != null)
			{
				_ol_1_nameText3.text = value;
			}
		}
	}

	public string l_1_nameString4
	{
		get
		{
			if (_ol_1_nameText4 != null)
			{
				return _ol_1_nameText4.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString4 != value && _ol_1_nameText4 != null)
			{
				_ol_1_nameText4.text = value;
			}
		}
	}

	public string l_1_nameString5
	{
		get
		{
			if (_ol_1_nameText5 != null)
			{
				return _ol_1_nameText5.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString5 != value && _ol_1_nameText5 != null)
			{
				_ol_1_nameText5.text = value;
			}
		}
	}

	public string l_1_nameString6
	{
		get
		{
			if (_ol_1_nameText6 != null)
			{
				return _ol_1_nameText6.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString6 != value && _ol_1_nameText6 != null)
			{
				_ol_1_nameText6.text = value;
			}
		}
	}

	public string l_1_nameString7
	{
		get
		{
			if (_ol_1_nameText7 != null)
			{
				return _ol_1_nameText7.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString7 != value && _ol_1_nameText7 != null)
			{
				_ol_1_nameText7.text = value;
			}
		}
	}

	public string l_1_nameString8
	{
		get
		{
			if (_ol_1_nameText8 != null)
			{
				return _ol_1_nameText8.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString8 != value && _ol_1_nameText8 != null)
			{
				_ol_1_nameText8.text = value;
			}
		}
	}

	public string l_1_nameString9
	{
		get
		{
			if (_ol_1_nameText9 != null)
			{
				return _ol_1_nameText9.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString9 != value && _ol_1_nameText9 != null)
			{
				_ol_1_nameText9.text = value;
			}
		}
	}

	public string l_1_nameString10
	{
		get
		{
			if (_ol_1_nameText10 != null)
			{
				return _ol_1_nameText10.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString10 != value && _ol_1_nameText10 != null)
			{
				_ol_1_nameText10.text = value;
			}
		}
	}

	public string l_1_nameString11
	{
		get
		{
			if (_ol_1_nameText11 != null)
			{
				return _ol_1_nameText11.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString11 != value && _ol_1_nameText11 != null)
			{
				_ol_1_nameText11.text = value;
			}
		}
	}

	public string l_1_nameString12
	{
		get
		{
			if (_ol_1_nameText12 != null)
			{
				return _ol_1_nameText12.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString12 != value && _ol_1_nameText12 != null)
			{
				_ol_1_nameText12.text = value;
			}
		}
	}

	public string l_1_nameString13
	{
		get
		{
			if (_ol_1_nameText13 != null)
			{
				return _ol_1_nameText13.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString13 != value && _ol_1_nameText13 != null)
			{
				_ol_1_nameText13.text = value;
			}
		}
	}

	public string l_1_nameString14
	{
		get
		{
			if (_ol_1_nameText14 != null)
			{
				return _ol_1_nameText14.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString14 != value && _ol_1_nameText14 != null)
			{
				_ol_1_nameText14.text = value;
			}
		}
	}

	public string l_1_nameString15
	{
		get
		{
			if (_ol_1_nameText15 != null)
			{
				return _ol_1_nameText15.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString15 != value && _ol_1_nameText15 != null)
			{
				_ol_1_nameText15.text = value;
			}
		}
	}

	public string l_1_nameString16
	{
		get
		{
			if (_ol_1_nameText16 != null)
			{
				return _ol_1_nameText16.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString16 != value && _ol_1_nameText16 != null)
			{
				_ol_1_nameText16.text = value;
			}
		}
	}

	public string l_1_nameString17
	{
		get
		{
			if (_ol_1_nameText17 != null)
			{
				return _ol_1_nameText17.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString17 != value && _ol_1_nameText17 != null)
			{
				_ol_1_nameText17.text = value;
			}
		}
	}

	public string l_1_nameString18
	{
		get
		{
			if (_ol_1_nameText18 != null)
			{
				return _ol_1_nameText18.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString18 != value && _ol_1_nameText18 != null)
			{
				_ol_1_nameText18.text = value;
			}
		}
	}

	public string l_1_nameString19
	{
		get
		{
			if (_ol_1_nameText19 != null)
			{
				return _ol_1_nameText19.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString19 != value && _ol_1_nameText19 != null)
			{
				_ol_1_nameText19.text = value;
			}
		}
	}

	public string l_1_nameString20
	{
		get
		{
			if (_ol_1_nameText20 != null)
			{
				return _ol_1_nameText20.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString20 != value && _ol_1_nameText20 != null)
			{
				_ol_1_nameText20.text = value;
			}
		}
	}

	public string l_1_nameString21
	{
		get
		{
			if (_ol_1_nameText21 != null)
			{
				return _ol_1_nameText21.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString21 != value && _ol_1_nameText21 != null)
			{
				_ol_1_nameText21.text = value;
			}
		}
	}

	public string l_1_nameString22
	{
		get
		{
			if (_ol_1_nameText22 != null)
			{
				return _ol_1_nameText22.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString22 != value && _ol_1_nameText22 != null)
			{
				_ol_1_nameText22.text = value;
			}
		}
	}

	public string l_1_nameString23
	{
		get
		{
			if (_ol_1_nameText23 != null)
			{
				return _ol_1_nameText23.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString23 != value && _ol_1_nameText23 != null)
			{
				_ol_1_nameText23.text = value;
			}
		}
	}

	public string l_1_nameString24
	{
		get
		{
			if (_ol_1_nameText24 != null)
			{
				return _ol_1_nameText24.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString24 != value && _ol_1_nameText24 != null)
			{
				_ol_1_nameText24.text = value;
			}
		}
	}

	public string l_1_nameString25
	{
		get
		{
			if (_ol_1_nameText25 != null)
			{
				return _ol_1_nameText25.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString25 != value && _ol_1_nameText25 != null)
			{
				_ol_1_nameText25.text = value;
			}
		}
	}

	public string l_1_nameString26
	{
		get
		{
			if (_ol_1_nameText26 != null)
			{
				return _ol_1_nameText26.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString26 != value && _ol_1_nameText26 != null)
			{
				_ol_1_nameText26.text = value;
			}
		}
	}

	public string l_1_nameString27
	{
		get
		{
			if (_ol_1_nameText27 != null)
			{
				return _ol_1_nameText27.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString27 != value && _ol_1_nameText27 != null)
			{
				_ol_1_nameText27.text = value;
			}
		}
	}

	public string l_1_nameString28
	{
		get
		{
			if (_ol_1_nameText28 != null)
			{
				return _ol_1_nameText28.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString28 != value && _ol_1_nameText28 != null)
			{
				_ol_1_nameText28.text = value;
			}
		}
	}

	public string l_1_nameString29
	{
		get
		{
			if (_ol_1_nameText29 != null)
			{
				return _ol_1_nameText29.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString29 != value && _ol_1_nameText29 != null)
			{
				_ol_1_nameText29.text = value;
			}
		}
	}

	public string l_1_nameString30
	{
		get
		{
			if (_ol_1_nameText30 != null)
			{
				return _ol_1_nameText30.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString30 != value && _ol_1_nameText30 != null)
			{
				_ol_1_nameText30.text = value;
			}
		}
	}

	public string l_1_nameString31
	{
		get
		{
			if (_ol_1_nameText31 != null)
			{
				return _ol_1_nameText31.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString31 != value && _ol_1_nameText31 != null)
			{
				_ol_1_nameText31.text = value;
			}
		}
	}

	public string l_1_nameString32
	{
		get
		{
			if (_ol_1_nameText32 != null)
			{
				return _ol_1_nameText32.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString32 != value && _ol_1_nameText32 != null)
			{
				_ol_1_nameText32.text = value;
			}
		}
	}

	public string l_1_nameString33
	{
		get
		{
			if (_ol_1_nameText33 != null)
			{
				return _ol_1_nameText33.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString33 != value && _ol_1_nameText33 != null)
			{
				_ol_1_nameText33.text = value;
			}
		}
	}

	public string l_1_nameString34
	{
		get
		{
			if (_ol_1_nameText34 != null)
			{
				return _ol_1_nameText34.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString34 != value && _ol_1_nameText34 != null)
			{
				_ol_1_nameText34.text = value;
			}
		}
	}

	public string l_1_nameString35
	{
		get
		{
			if (_ol_1_nameText35 != null)
			{
				return _ol_1_nameText35.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString35 != value && _ol_1_nameText35 != null)
			{
				_ol_1_nameText35.text = value;
			}
		}
	}

	public string l_1_nameString36
	{
		get
		{
			if (_ol_1_nameText36 != null)
			{
				return _ol_1_nameText36.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString36 != value && _ol_1_nameText36 != null)
			{
				_ol_1_nameText36.text = value;
			}
		}
	}

	public string l_1_nameString37
	{
		get
		{
			if (_ol_1_nameText37 != null)
			{
				return _ol_1_nameText37.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString37 != value && _ol_1_nameText37 != null)
			{
				_ol_1_nameText37.text = value;
			}
		}
	}

	public string l_1_nameString38
	{
		get
		{
			if (_ol_1_nameText38 != null)
			{
				return _ol_1_nameText38.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString38 != value && _ol_1_nameText38 != null)
			{
				_ol_1_nameText38.text = value;
			}
		}
	}

	public string l_1_nameString39
	{
		get
		{
			if (_ol_1_nameText39 != null)
			{
				return _ol_1_nameText39.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString39 != value && _ol_1_nameText39 != null)
			{
				_ol_1_nameText39.text = value;
			}
		}
	}

	public string l_1_nameString40
	{
		get
		{
			if (_ol_1_nameText40 != null)
			{
				return _ol_1_nameText40.text;
			}
			return null;
		}
		set
		{
			if (l_1_nameString40 != value && _ol_1_nameText40 != null)
			{
				_ol_1_nameText40.text = value;
			}
		}
	}

	public string l_1_moneyString1
	{
		get
		{
			if (_ol_1_moneyText1 != null)
			{
				return _ol_1_moneyText1.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString1 != value && _ol_1_moneyText1 != null)
			{
				_ol_1_moneyText1.text = value;
			}
		}
	}

	public string l_1_moneyString2
	{
		get
		{
			if (_ol_1_moneyText2 != null)
			{
				return _ol_1_moneyText2.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString2 != value && _ol_1_moneyText2 != null)
			{
				_ol_1_moneyText2.text = value;
			}
		}
	}

	public string l_1_moneyString3
	{
		get
		{
			if (_ol_1_moneyText3 != null)
			{
				return _ol_1_moneyText3.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString3 != value && _ol_1_moneyText3 != null)
			{
				_ol_1_moneyText3.text = value;
			}
		}
	}

	public string l_1_moneyString4
	{
		get
		{
			if (_ol_1_moneyText4 != null)
			{
				return _ol_1_moneyText4.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString4 != value && _ol_1_moneyText4 != null)
			{
				_ol_1_moneyText4.text = value;
			}
		}
	}

	public string l_1_moneyString5
	{
		get
		{
			if (_ol_1_moneyText5 != null)
			{
				return _ol_1_moneyText5.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString5 != value && _ol_1_moneyText5 != null)
			{
				_ol_1_moneyText5.text = value;
			}
		}
	}

	public string l_1_moneyString6
	{
		get
		{
			if (_ol_1_moneyText6 != null)
			{
				return _ol_1_moneyText6.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString6 != value && _ol_1_moneyText6 != null)
			{
				_ol_1_moneyText6.text = value;
			}
		}
	}

	public string l_1_moneyString7
	{
		get
		{
			if (_ol_1_moneyText7 != null)
			{
				return _ol_1_moneyText7.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString7 != value && _ol_1_moneyText7 != null)
			{
				_ol_1_moneyText7.text = value;
			}
		}
	}

	public string l_1_moneyString8
	{
		get
		{
			if (_ol_1_moneyText8 != null)
			{
				return _ol_1_moneyText8.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString8 != value && _ol_1_moneyText8 != null)
			{
				_ol_1_moneyText8.text = value;
			}
		}
	}

	public string l_1_moneyString9
	{
		get
		{
			if (_ol_1_moneyText9 != null)
			{
				return _ol_1_moneyText9.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString9 != value && _ol_1_moneyText9 != null)
			{
				_ol_1_moneyText9.text = value;
			}
		}
	}

	public string l_1_moneyString10
	{
		get
		{
			if (_ol_1_moneyText10 != null)
			{
				return _ol_1_moneyText10.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString10 != value && _ol_1_moneyText10 != null)
			{
				_ol_1_moneyText10.text = value;
			}
		}
	}

	public string l_1_moneyString11
	{
		get
		{
			if (_ol_1_moneyText11 != null)
			{
				return _ol_1_moneyText11.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString11 != value && _ol_1_moneyText11 != null)
			{
				_ol_1_moneyText11.text = value;
			}
		}
	}

	public string l_1_moneyString12
	{
		get
		{
			if (_ol_1_moneyText12 != null)
			{
				return _ol_1_moneyText12.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString12 != value && _ol_1_moneyText12 != null)
			{
				_ol_1_moneyText12.text = value;
			}
		}
	}

	public string l_1_moneyString13
	{
		get
		{
			if (_ol_1_moneyText13 != null)
			{
				return _ol_1_moneyText13.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString13 != value && _ol_1_moneyText13 != null)
			{
				_ol_1_moneyText13.text = value;
			}
		}
	}

	public string l_1_moneyString14
	{
		get
		{
			if (_ol_1_moneyText14 != null)
			{
				return _ol_1_moneyText14.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString14 != value && _ol_1_moneyText14 != null)
			{
				_ol_1_moneyText14.text = value;
			}
		}
	}

	public string l_1_moneyString15
	{
		get
		{
			if (_ol_1_moneyText15 != null)
			{
				return _ol_1_moneyText15.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString15 != value && _ol_1_moneyText15 != null)
			{
				_ol_1_moneyText15.text = value;
			}
		}
	}

	public string l_1_moneyString16
	{
		get
		{
			if (_ol_1_moneyText16 != null)
			{
				return _ol_1_moneyText16.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString16 != value && _ol_1_moneyText16 != null)
			{
				_ol_1_moneyText16.text = value;
			}
		}
	}

	public string l_1_moneyString17
	{
		get
		{
			if (_ol_1_moneyText17 != null)
			{
				return _ol_1_moneyText17.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString17 != value && _ol_1_moneyText17 != null)
			{
				_ol_1_moneyText17.text = value;
			}
		}
	}

	public string l_1_moneyString18
	{
		get
		{
			if (_ol_1_moneyText18 != null)
			{
				return _ol_1_moneyText18.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString18 != value && _ol_1_moneyText18 != null)
			{
				_ol_1_moneyText18.text = value;
			}
		}
	}

	public string l_1_moneyString19
	{
		get
		{
			if (_ol_1_moneyText19 != null)
			{
				return _ol_1_moneyText19.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString19 != value && _ol_1_moneyText19 != null)
			{
				_ol_1_moneyText19.text = value;
			}
		}
	}

	public string l_1_moneyString20
	{
		get
		{
			if (_ol_1_moneyText20 != null)
			{
				return _ol_1_moneyText20.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString20 != value && _ol_1_moneyText20 != null)
			{
				_ol_1_moneyText20.text = value;
			}
		}
	}

	public string l_1_moneyString21
	{
		get
		{
			if (_ol_1_moneyText21 != null)
			{
				return _ol_1_moneyText21.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString21 != value && _ol_1_moneyText21 != null)
			{
				_ol_1_moneyText21.text = value;
			}
		}
	}

	public string l_1_moneyString22
	{
		get
		{
			if (_ol_1_moneyText22 != null)
			{
				return _ol_1_moneyText22.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString22 != value && _ol_1_moneyText22 != null)
			{
				_ol_1_moneyText22.text = value;
			}
		}
	}

	public string l_1_moneyString23
	{
		get
		{
			if (_ol_1_moneyText23 != null)
			{
				return _ol_1_moneyText23.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString23 != value && _ol_1_moneyText23 != null)
			{
				_ol_1_moneyText23.text = value;
			}
		}
	}

	public string l_1_moneyString24
	{
		get
		{
			if (_ol_1_moneyText24 != null)
			{
				return _ol_1_moneyText24.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString24 != value && _ol_1_moneyText24 != null)
			{
				_ol_1_moneyText24.text = value;
			}
		}
	}

	public string l_1_moneyString25
	{
		get
		{
			if (_ol_1_moneyText25 != null)
			{
				return _ol_1_moneyText25.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString25 != value && _ol_1_moneyText25 != null)
			{
				_ol_1_moneyText25.text = value;
			}
		}
	}

	public string l_1_moneyString26
	{
		get
		{
			if (_ol_1_moneyText26 != null)
			{
				return _ol_1_moneyText26.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString26 != value && _ol_1_moneyText26 != null)
			{
				_ol_1_moneyText26.text = value;
			}
		}
	}

	public string l_1_moneyString27
	{
		get
		{
			if (_ol_1_moneyText27 != null)
			{
				return _ol_1_moneyText27.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString27 != value && _ol_1_moneyText27 != null)
			{
				_ol_1_moneyText27.text = value;
			}
		}
	}

	public string l_1_moneyString28
	{
		get
		{
			if (_ol_1_moneyText28 != null)
			{
				return _ol_1_moneyText28.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString28 != value && _ol_1_moneyText28 != null)
			{
				_ol_1_moneyText28.text = value;
			}
		}
	}

	public string l_1_moneyString29
	{
		get
		{
			if (_ol_1_moneyText29 != null)
			{
				return _ol_1_moneyText29.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString29 != value && _ol_1_moneyText29 != null)
			{
				_ol_1_moneyText29.text = value;
			}
		}
	}

	public string l_1_moneyString30
	{
		get
		{
			if (_ol_1_moneyText30 != null)
			{
				return _ol_1_moneyText30.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString30 != value && _ol_1_moneyText30 != null)
			{
				_ol_1_moneyText30.text = value;
			}
		}
	}

	public string l_1_moneyString31
	{
		get
		{
			if (_ol_1_moneyText31 != null)
			{
				return _ol_1_moneyText31.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString31 != value && _ol_1_moneyText31 != null)
			{
				_ol_1_moneyText31.text = value;
			}
		}
	}

	public string l_1_moneyString32
	{
		get
		{
			if (_ol_1_moneyText32 != null)
			{
				return _ol_1_moneyText32.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString32 != value && _ol_1_moneyText32 != null)
			{
				_ol_1_moneyText32.text = value;
			}
		}
	}

	public string l_1_moneyString33
	{
		get
		{
			if (_ol_1_moneyText33 != null)
			{
				return _ol_1_moneyText33.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString33 != value && _ol_1_moneyText33 != null)
			{
				_ol_1_moneyText33.text = value;
			}
		}
	}

	public string l_1_moneyString34
	{
		get
		{
			if (_ol_1_moneyText34 != null)
			{
				return _ol_1_moneyText34.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString34 != value && _ol_1_moneyText34 != null)
			{
				_ol_1_moneyText34.text = value;
			}
		}
	}

	public string l_1_moneyString35
	{
		get
		{
			if (_ol_1_moneyText35 != null)
			{
				return _ol_1_moneyText35.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString35 != value && _ol_1_moneyText35 != null)
			{
				_ol_1_moneyText35.text = value;
			}
		}
	}

	public string l_1_moneyString36
	{
		get
		{
			if (_ol_1_moneyText36 != null)
			{
				return _ol_1_moneyText36.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString36 != value && _ol_1_moneyText36 != null)
			{
				_ol_1_moneyText36.text = value;
			}
		}
	}

	public string l_1_moneyString37
	{
		get
		{
			if (_ol_1_moneyText37 != null)
			{
				return _ol_1_moneyText37.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString37 != value && _ol_1_moneyText37 != null)
			{
				_ol_1_moneyText37.text = value;
			}
		}
	}

	public string l_1_moneyString38
	{
		get
		{
			if (_ol_1_moneyText38 != null)
			{
				return _ol_1_moneyText38.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString38 != value && _ol_1_moneyText38 != null)
			{
				_ol_1_moneyText38.text = value;
			}
		}
	}

	public string l_1_moneyString39
	{
		get
		{
			if (_ol_1_moneyText39 != null)
			{
				return _ol_1_moneyText39.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString39 != value && _ol_1_moneyText39 != null)
			{
				_ol_1_moneyText39.text = value;
			}
		}
	}

	public string l_1_moneyString40
	{
		get
		{
			if (_ol_1_moneyText40 != null)
			{
				return _ol_1_moneyText40.text;
			}
			return null;
		}
		set
		{
			if (l_1_moneyString40 != value && _ol_1_moneyText40 != null)
			{
				_ol_1_moneyText40.text = value;
			}
		}
	}

	public bool l_1_lockShow1
	{
		get
		{
			if (_ol_1_lock1 != null)
			{
				return _ol_1_lock1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow1 != value && _ol_1_lock1 != null)
			{
				_ol_1_lock1.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow2
	{
		get
		{
			if (_ol_1_lock2 != null)
			{
				return _ol_1_lock2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow2 != value && _ol_1_lock2 != null)
			{
				_ol_1_lock2.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow3
	{
		get
		{
			if (_ol_1_lock3 != null)
			{
				return _ol_1_lock3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow3 != value && _ol_1_lock3 != null)
			{
				_ol_1_lock3.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow4
	{
		get
		{
			if (_ol_1_lock4 != null)
			{
				return _ol_1_lock4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow4 != value && _ol_1_lock4 != null)
			{
				_ol_1_lock4.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow5
	{
		get
		{
			if (_ol_1_lock5 != null)
			{
				return _ol_1_lock5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow5 != value && _ol_1_lock5 != null)
			{
				_ol_1_lock5.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow6
	{
		get
		{
			if (_ol_1_lock6 != null)
			{
				return _ol_1_lock6.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow6 != value && _ol_1_lock6 != null)
			{
				_ol_1_lock6.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow7
	{
		get
		{
			if (_ol_1_lock7 != null)
			{
				return _ol_1_lock7.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow7 != value && _ol_1_lock7 != null)
			{
				_ol_1_lock7.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow8
	{
		get
		{
			if (_ol_1_lock8 != null)
			{
				return _ol_1_lock8.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow8 != value && _ol_1_lock8 != null)
			{
				_ol_1_lock8.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow9
	{
		get
		{
			if (_ol_1_lock9 != null)
			{
				return _ol_1_lock9.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow9 != value && _ol_1_lock9 != null)
			{
				_ol_1_lock9.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow10
	{
		get
		{
			if (_ol_1_lock10 != null)
			{
				return _ol_1_lock10.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow10 != value && _ol_1_lock10 != null)
			{
				_ol_1_lock10.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow11
	{
		get
		{
			if (_ol_1_lock11 != null)
			{
				return _ol_1_lock11.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow11 != value && _ol_1_lock11 != null)
			{
				_ol_1_lock11.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow12
	{
		get
		{
			if (_ol_1_lock12 != null)
			{
				return _ol_1_lock12.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow12 != value && _ol_1_lock12 != null)
			{
				_ol_1_lock12.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow13
	{
		get
		{
			if (_ol_1_lock13 != null)
			{
				return _ol_1_lock13.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow13 != value && _ol_1_lock13 != null)
			{
				_ol_1_lock13.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow14
	{
		get
		{
			if (_ol_1_lock14 != null)
			{
				return _ol_1_lock14.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow14 != value && _ol_1_lock14 != null)
			{
				_ol_1_lock14.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow15
	{
		get
		{
			if (_ol_1_lock15 != null)
			{
				return _ol_1_lock15.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow15 != value && _ol_1_lock15 != null)
			{
				_ol_1_lock15.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow16
	{
		get
		{
			if (_ol_1_lock16 != null)
			{
				return _ol_1_lock16.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow16 != value && _ol_1_lock16 != null)
			{
				_ol_1_lock16.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow17
	{
		get
		{
			if (_ol_1_lock17 != null)
			{
				return _ol_1_lock17.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow17 != value && _ol_1_lock17 != null)
			{
				_ol_1_lock17.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow18
	{
		get
		{
			if (_ol_1_lock18 != null)
			{
				return _ol_1_lock18.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow18 != value && _ol_1_lock18 != null)
			{
				_ol_1_lock18.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow19
	{
		get
		{
			if (_ol_1_lock19 != null)
			{
				return _ol_1_lock19.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow19 != value && _ol_1_lock19 != null)
			{
				_ol_1_lock19.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow20
	{
		get
		{
			if (_ol_1_lock20 != null)
			{
				return _ol_1_lock20.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow20 != value && _ol_1_lock20 != null)
			{
				_ol_1_lock20.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow21
	{
		get
		{
			if (_ol_1_lock21 != null)
			{
				return _ol_1_lock21.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow21 != value && _ol_1_lock21 != null)
			{
				_ol_1_lock21.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow22
	{
		get
		{
			if (_ol_1_lock22 != null)
			{
				return _ol_1_lock22.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow22 != value && _ol_1_lock22 != null)
			{
				_ol_1_lock22.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow23
	{
		get
		{
			if (_ol_1_lock23 != null)
			{
				return _ol_1_lock23.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow23 != value && _ol_1_lock23 != null)
			{
				_ol_1_lock23.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow24
	{
		get
		{
			if (_ol_1_lock24 != null)
			{
				return _ol_1_lock24.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow24 != value && _ol_1_lock24 != null)
			{
				_ol_1_lock24.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow25
	{
		get
		{
			if (_ol_1_lock25 != null)
			{
				return _ol_1_lock25.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow25 != value && _ol_1_lock25 != null)
			{
				_ol_1_lock25.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow26
	{
		get
		{
			if (_ol_1_lock26 != null)
			{
				return _ol_1_lock26.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow26 != value && _ol_1_lock26 != null)
			{
				_ol_1_lock26.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow27
	{
		get
		{
			if (_ol_1_lock27 != null)
			{
				return _ol_1_lock27.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow27 != value && _ol_1_lock27 != null)
			{
				_ol_1_lock27.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow28
	{
		get
		{
			if (_ol_1_lock28 != null)
			{
				return _ol_1_lock28.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow28 != value && _ol_1_lock28 != null)
			{
				_ol_1_lock28.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow29
	{
		get
		{
			if (_ol_1_lock29 != null)
			{
				return _ol_1_lock29.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow29 != value && _ol_1_lock29 != null)
			{
				_ol_1_lock29.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow30
	{
		get
		{
			if (_ol_1_lock30 != null)
			{
				return _ol_1_lock30.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow30 != value && _ol_1_lock30 != null)
			{
				_ol_1_lock30.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow31
	{
		get
		{
			if (_ol_1_lock31 != null)
			{
				return _ol_1_lock31.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow31 != value && _ol_1_lock31 != null)
			{
				_ol_1_lock31.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow32
	{
		get
		{
			if (_ol_1_lock32 != null)
			{
				return _ol_1_lock32.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow32 != value && _ol_1_lock32 != null)
			{
				_ol_1_lock32.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow33
	{
		get
		{
			if (_ol_1_lock33 != null)
			{
				return _ol_1_lock33.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow33 != value && _ol_1_lock33 != null)
			{
				_ol_1_lock33.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow34
	{
		get
		{
			if (_ol_1_lock34 != null)
			{
				return _ol_1_lock34.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow34 != value && _ol_1_lock34 != null)
			{
				_ol_1_lock34.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow35
	{
		get
		{
			if (_ol_1_lock35 != null)
			{
				return _ol_1_lock35.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow35 != value && _ol_1_lock35 != null)
			{
				_ol_1_lock35.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow36
	{
		get
		{
			if (_ol_1_lock36 != null)
			{
				return _ol_1_lock36.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow36 != value && _ol_1_lock36 != null)
			{
				_ol_1_lock36.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow37
	{
		get
		{
			if (_ol_1_lock37 != null)
			{
				return _ol_1_lock37.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow37 != value && _ol_1_lock37 != null)
			{
				_ol_1_lock37.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow38
	{
		get
		{
			if (_ol_1_lock38 != null)
			{
				return _ol_1_lock38.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow38 != value && _ol_1_lock38 != null)
			{
				_ol_1_lock38.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow39
	{
		get
		{
			if (_ol_1_lock39 != null)
			{
				return _ol_1_lock39.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow39 != value && _ol_1_lock39 != null)
			{
				_ol_1_lock39.SetObjectActive(value);
			}
		}
	}

	public bool l_1_lockShow40
	{
		get
		{
			if (_ol_1_lock40 != null)
			{
				return _ol_1_lock40.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (l_1_lockShow40 != value && _ol_1_lock40 != null)
			{
				_ol_1_lock40.SetObjectActive(value);
			}
		}
	}

	public string l_1_lock_lvString1
	{
		get
		{
			if (_ol_1_lock_lvText1 != null)
			{
				return _ol_1_lock_lvText1.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString1 != value && _ol_1_lock_lvText1 != null)
			{
				_ol_1_lock_lvText1.text = value;
			}
		}
	}

	public string l_1_lock_lvString2
	{
		get
		{
			if (_ol_1_lock_lvText2 != null)
			{
				return _ol_1_lock_lvText2.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString2 != value && _ol_1_lock_lvText2 != null)
			{
				_ol_1_lock_lvText2.text = value;
			}
		}
	}

	public string l_1_lock_lvString3
	{
		get
		{
			if (_ol_1_lock_lvText3 != null)
			{
				return _ol_1_lock_lvText3.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString3 != value && _ol_1_lock_lvText3 != null)
			{
				_ol_1_lock_lvText3.text = value;
			}
		}
	}

	public string l_1_lock_lvString4
	{
		get
		{
			if (_ol_1_lock_lvText4 != null)
			{
				return _ol_1_lock_lvText4.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString4 != value && _ol_1_lock_lvText4 != null)
			{
				_ol_1_lock_lvText4.text = value;
			}
		}
	}

	public string l_1_lock_lvString5
	{
		get
		{
			if (_ol_1_lock_lvText5 != null)
			{
				return _ol_1_lock_lvText5.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString5 != value && _ol_1_lock_lvText5 != null)
			{
				_ol_1_lock_lvText5.text = value;
			}
		}
	}

	public string l_1_lock_lvString6
	{
		get
		{
			if (_ol_1_lock_lvText6 != null)
			{
				return _ol_1_lock_lvText6.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString6 != value && _ol_1_lock_lvText6 != null)
			{
				_ol_1_lock_lvText6.text = value;
			}
		}
	}

	public string l_1_lock_lvString7
	{
		get
		{
			if (_ol_1_lock_lvText7 != null)
			{
				return _ol_1_lock_lvText7.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString7 != value && _ol_1_lock_lvText7 != null)
			{
				_ol_1_lock_lvText7.text = value;
			}
		}
	}

	public string l_1_lock_lvString8
	{
		get
		{
			if (_ol_1_lock_lvText8 != null)
			{
				return _ol_1_lock_lvText8.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString8 != value && _ol_1_lock_lvText8 != null)
			{
				_ol_1_lock_lvText8.text = value;
			}
		}
	}

	public string l_1_lock_lvString9
	{
		get
		{
			if (_ol_1_lock_lvText9 != null)
			{
				return _ol_1_lock_lvText9.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString9 != value && _ol_1_lock_lvText9 != null)
			{
				_ol_1_lock_lvText9.text = value;
			}
		}
	}

	public string l_1_lock_lvString10
	{
		get
		{
			if (_ol_1_lock_lvText10 != null)
			{
				return _ol_1_lock_lvText10.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString10 != value && _ol_1_lock_lvText10 != null)
			{
				_ol_1_lock_lvText10.text = value;
			}
		}
	}

	public string l_1_lock_lvString11
	{
		get
		{
			if (_ol_1_lock_lvText11 != null)
			{
				return _ol_1_lock_lvText11.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString11 != value && _ol_1_lock_lvText11 != null)
			{
				_ol_1_lock_lvText11.text = value;
			}
		}
	}

	public string l_1_lock_lvString12
	{
		get
		{
			if (_ol_1_lock_lvText12 != null)
			{
				return _ol_1_lock_lvText12.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString12 != value && _ol_1_lock_lvText12 != null)
			{
				_ol_1_lock_lvText12.text = value;
			}
		}
	}

	public string l_1_lock_lvString13
	{
		get
		{
			if (_ol_1_lock_lvText13 != null)
			{
				return _ol_1_lock_lvText13.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString13 != value && _ol_1_lock_lvText13 != null)
			{
				_ol_1_lock_lvText13.text = value;
			}
		}
	}

	public string l_1_lock_lvString14
	{
		get
		{
			if (_ol_1_lock_lvText14 != null)
			{
				return _ol_1_lock_lvText14.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString14 != value && _ol_1_lock_lvText14 != null)
			{
				_ol_1_lock_lvText14.text = value;
			}
		}
	}

	public string l_1_lock_lvString15
	{
		get
		{
			if (_ol_1_lock_lvText15 != null)
			{
				return _ol_1_lock_lvText15.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString15 != value && _ol_1_lock_lvText15 != null)
			{
				_ol_1_lock_lvText15.text = value;
			}
		}
	}

	public string l_1_lock_lvString16
	{
		get
		{
			if (_ol_1_lock_lvText16 != null)
			{
				return _ol_1_lock_lvText16.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString16 != value && _ol_1_lock_lvText16 != null)
			{
				_ol_1_lock_lvText16.text = value;
			}
		}
	}

	public string l_1_lock_lvString17
	{
		get
		{
			if (_ol_1_lock_lvText17 != null)
			{
				return _ol_1_lock_lvText17.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString17 != value && _ol_1_lock_lvText17 != null)
			{
				_ol_1_lock_lvText17.text = value;
			}
		}
	}

	public string l_1_lock_lvString18
	{
		get
		{
			if (_ol_1_lock_lvText18 != null)
			{
				return _ol_1_lock_lvText18.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString18 != value && _ol_1_lock_lvText18 != null)
			{
				_ol_1_lock_lvText18.text = value;
			}
		}
	}

	public string l_1_lock_lvString19
	{
		get
		{
			if (_ol_1_lock_lvText19 != null)
			{
				return _ol_1_lock_lvText19.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString19 != value && _ol_1_lock_lvText19 != null)
			{
				_ol_1_lock_lvText19.text = value;
			}
		}
	}

	public string l_1_lock_lvString20
	{
		get
		{
			if (_ol_1_lock_lvText20 != null)
			{
				return _ol_1_lock_lvText20.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString20 != value && _ol_1_lock_lvText20 != null)
			{
				_ol_1_lock_lvText20.text = value;
			}
		}
	}

	public string l_1_lock_lvString21
	{
		get
		{
			if (_ol_1_lock_lvText21 != null)
			{
				return _ol_1_lock_lvText21.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString21 != value && _ol_1_lock_lvText21 != null)
			{
				_ol_1_lock_lvText21.text = value;
			}
		}
	}

	public string l_1_lock_lvString22
	{
		get
		{
			if (_ol_1_lock_lvText22 != null)
			{
				return _ol_1_lock_lvText22.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString22 != value && _ol_1_lock_lvText22 != null)
			{
				_ol_1_lock_lvText22.text = value;
			}
		}
	}

	public string l_1_lock_lvString23
	{
		get
		{
			if (_ol_1_lock_lvText23 != null)
			{
				return _ol_1_lock_lvText23.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString23 != value && _ol_1_lock_lvText23 != null)
			{
				_ol_1_lock_lvText23.text = value;
			}
		}
	}

	public string l_1_lock_lvString24
	{
		get
		{
			if (_ol_1_lock_lvText24 != null)
			{
				return _ol_1_lock_lvText24.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString24 != value && _ol_1_lock_lvText24 != null)
			{
				_ol_1_lock_lvText24.text = value;
			}
		}
	}

	public string l_1_lock_lvString25
	{
		get
		{
			if (_ol_1_lock_lvText25 != null)
			{
				return _ol_1_lock_lvText25.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString25 != value && _ol_1_lock_lvText25 != null)
			{
				_ol_1_lock_lvText25.text = value;
			}
		}
	}

	public string l_1_lock_lvString26
	{
		get
		{
			if (_ol_1_lock_lvText26 != null)
			{
				return _ol_1_lock_lvText26.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString26 != value && _ol_1_lock_lvText26 != null)
			{
				_ol_1_lock_lvText26.text = value;
			}
		}
	}

	public string l_1_lock_lvString27
	{
		get
		{
			if (_ol_1_lock_lvText27 != null)
			{
				return _ol_1_lock_lvText27.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString27 != value && _ol_1_lock_lvText27 != null)
			{
				_ol_1_lock_lvText27.text = value;
			}
		}
	}

	public string l_1_lock_lvString28
	{
		get
		{
			if (_ol_1_lock_lvText28 != null)
			{
				return _ol_1_lock_lvText28.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString28 != value && _ol_1_lock_lvText28 != null)
			{
				_ol_1_lock_lvText28.text = value;
			}
		}
	}

	public string l_1_lock_lvString29
	{
		get
		{
			if (_ol_1_lock_lvText29 != null)
			{
				return _ol_1_lock_lvText29.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString29 != value && _ol_1_lock_lvText29 != null)
			{
				_ol_1_lock_lvText29.text = value;
			}
		}
	}

	public string l_1_lock_lvString30
	{
		get
		{
			if (_ol_1_lock_lvText30 != null)
			{
				return _ol_1_lock_lvText30.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString30 != value && _ol_1_lock_lvText30 != null)
			{
				_ol_1_lock_lvText30.text = value;
			}
		}
	}

	public string l_1_lock_lvString31
	{
		get
		{
			if (_ol_1_lock_lvText31 != null)
			{
				return _ol_1_lock_lvText31.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString31 != value && _ol_1_lock_lvText31 != null)
			{
				_ol_1_lock_lvText31.text = value;
			}
		}
	}

	public string l_1_lock_lvString32
	{
		get
		{
			if (_ol_1_lock_lvText32 != null)
			{
				return _ol_1_lock_lvText32.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString32 != value && _ol_1_lock_lvText32 != null)
			{
				_ol_1_lock_lvText32.text = value;
			}
		}
	}

	public string l_1_lock_lvString33
	{
		get
		{
			if (_ol_1_lock_lvText33 != null)
			{
				return _ol_1_lock_lvText33.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString33 != value && _ol_1_lock_lvText33 != null)
			{
				_ol_1_lock_lvText33.text = value;
			}
		}
	}

	public string l_1_lock_lvString34
	{
		get
		{
			if (_ol_1_lock_lvText34 != null)
			{
				return _ol_1_lock_lvText34.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString34 != value && _ol_1_lock_lvText34 != null)
			{
				_ol_1_lock_lvText34.text = value;
			}
		}
	}

	public string l_1_lock_lvString35
	{
		get
		{
			if (_ol_1_lock_lvText35 != null)
			{
				return _ol_1_lock_lvText35.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString35 != value && _ol_1_lock_lvText35 != null)
			{
				_ol_1_lock_lvText35.text = value;
			}
		}
	}

	public string l_1_lock_lvString36
	{
		get
		{
			if (_ol_1_lock_lvText36 != null)
			{
				return _ol_1_lock_lvText36.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString36 != value && _ol_1_lock_lvText36 != null)
			{
				_ol_1_lock_lvText36.text = value;
			}
		}
	}

	public string l_1_lock_lvString37
	{
		get
		{
			if (_ol_1_lock_lvText37 != null)
			{
				return _ol_1_lock_lvText37.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString37 != value && _ol_1_lock_lvText37 != null)
			{
				_ol_1_lock_lvText37.text = value;
			}
		}
	}

	public string l_1_lock_lvString38
	{
		get
		{
			if (_ol_1_lock_lvText38 != null)
			{
				return _ol_1_lock_lvText38.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString38 != value && _ol_1_lock_lvText38 != null)
			{
				_ol_1_lock_lvText38.text = value;
			}
		}
	}

	public string l_1_lock_lvString39
	{
		get
		{
			if (_ol_1_lock_lvText39 != null)
			{
				return _ol_1_lock_lvText39.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString39 != value && _ol_1_lock_lvText39 != null)
			{
				_ol_1_lock_lvText39.text = value;
			}
		}
	}

	public string l_1_lock_lvString40
	{
		get
		{
			if (_ol_1_lock_lvText40 != null)
			{
				return _ol_1_lock_lvText40.text;
			}
			return null;
		}
		set
		{
			if (l_1_lock_lvString40 != value && _ol_1_lock_lvText40 != null)
			{
				_ol_1_lock_lvText40.text = value;
			}
		}
	}

	public bool r_weaponShow1
	{
		get
		{
			if (_or_weapon1 != null)
			{
				return _or_weapon1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (r_weaponShow1 != value && _or_weapon1 != null)
			{
				_or_weapon1.SetObjectActive(value);
			}
		}
	}

	public bool r_weaponShow2
	{
		get
		{
			if (_or_weapon2 != null)
			{
				return _or_weapon2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (r_weaponShow2 != value && _or_weapon2 != null)
			{
				_or_weapon2.SetObjectActive(value);
			}
		}
	}

	public bool r_weaponShow3
	{
		get
		{
			if (_or_weapon3 != null)
			{
				return _or_weapon3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (r_weaponShow3 != value && _or_weapon3 != null)
			{
				_or_weapon3.SetObjectActive(value);
			}
		}
	}

	public bool r_weaponShow4
	{
		get
		{
			if (_or_weapon4 != null)
			{
				return _or_weapon4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (r_weaponShow4 != value && _or_weapon4 != null)
			{
				_or_weapon4.SetObjectActive(value);
			}
		}
	}

	public bool r_weaponShow5
	{
		get
		{
			if (_or_weapon5 != null)
			{
				return _or_weapon5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (r_weaponShow5 != value && _or_weapon5 != null)
			{
				_or_weapon5.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent r_weaponClicked1
	{
		get
		{
			if (_or_weaponButton1 != null)
			{
				return _or_weaponButton1.onClick;
			}
			return null;
		}
		set
		{
			if (r_weaponClicked1 != value && _or_weaponButton1 != null)
			{
				_or_weaponButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent r_weaponClicked2
	{
		get
		{
			if (_or_weaponButton2 != null)
			{
				return _or_weaponButton2.onClick;
			}
			return null;
		}
		set
		{
			if (r_weaponClicked2 != value && _or_weaponButton2 != null)
			{
				_or_weaponButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent r_weaponClicked3
	{
		get
		{
			if (_or_weaponButton3 != null)
			{
				return _or_weaponButton3.onClick;
			}
			return null;
		}
		set
		{
			if (r_weaponClicked3 != value && _or_weaponButton3 != null)
			{
				_or_weaponButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent r_weaponClicked4
	{
		get
		{
			if (_or_weaponButton4 != null)
			{
				return _or_weaponButton4.onClick;
			}
			return null;
		}
		set
		{
			if (r_weaponClicked4 != value && _or_weaponButton4 != null)
			{
				_or_weaponButton4.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent r_weaponClicked5
	{
		get
		{
			if (_or_weaponButton5 != null)
			{
				return _or_weaponButton5.onClick;
			}
			return null;
		}
		set
		{
			if (r_weaponClicked5 != value && _or_weaponButton5 != null)
			{
				_or_weaponButton5.onClick = value;
			}
		}
	}

	public Sprite r_weaponIconSprite1
	{
		get
		{
			if (_or_weaponIconImage1 != null)
			{
				return _or_weaponIconImage1.sprite;
			}
			return null;
		}
		set
		{
			if (r_weaponIconSprite1 != value && _or_weaponIconImage1 != null)
			{
				_or_weaponIconImage1.sprite = value;
			}
		}
	}

	public Sprite r_weaponIconSprite2
	{
		get
		{
			if (_or_weaponIconImage2 != null)
			{
				return _or_weaponIconImage2.sprite;
			}
			return null;
		}
		set
		{
			if (r_weaponIconSprite2 != value && _or_weaponIconImage2 != null)
			{
				_or_weaponIconImage2.sprite = value;
			}
		}
	}

	public Sprite r_weaponIconSprite3
	{
		get
		{
			if (_or_weaponIconImage3 != null)
			{
				return _or_weaponIconImage3.sprite;
			}
			return null;
		}
		set
		{
			if (r_weaponIconSprite3 != value && _or_weaponIconImage3 != null)
			{
				_or_weaponIconImage3.sprite = value;
			}
		}
	}

	public Sprite r_weaponIconSprite4
	{
		get
		{
			if (_or_weaponIconImage4 != null)
			{
				return _or_weaponIconImage4.sprite;
			}
			return null;
		}
		set
		{
			if (r_weaponIconSprite4 != value && _or_weaponIconImage4 != null)
			{
				_or_weaponIconImage4.sprite = value;
			}
		}
	}

	public Sprite r_weaponIconSprite5
	{
		get
		{
			if (_or_weaponIconImage5 != null)
			{
				return _or_weaponIconImage5.sprite;
			}
			return null;
		}
		set
		{
			if (r_weaponIconSprite5 != value && _or_weaponIconImage5 != null)
			{
				_or_weaponIconImage5.sprite = value;
			}
		}
	}

	public Color r_weaponIconColor1
	{
		get
		{
			if (_or_weaponIconImage1 != null)
			{
				return _or_weaponIconImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (r_weaponIconColor1 != value && _or_weaponIconImage1 != null)
			{
				_or_weaponIconImage1.color = value;
			}
		}
	}

	public Color r_weaponIconColor2
	{
		get
		{
			if (_or_weaponIconImage2 != null)
			{
				return _or_weaponIconImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (r_weaponIconColor2 != value && _or_weaponIconImage2 != null)
			{
				_or_weaponIconImage2.color = value;
			}
		}
	}

	public Color r_weaponIconColor3
	{
		get
		{
			if (_or_weaponIconImage3 != null)
			{
				return _or_weaponIconImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (r_weaponIconColor3 != value && _or_weaponIconImage3 != null)
			{
				_or_weaponIconImage3.color = value;
			}
		}
	}

	public Color r_weaponIconColor4
	{
		get
		{
			if (_or_weaponIconImage4 != null)
			{
				return _or_weaponIconImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (r_weaponIconColor4 != value && _or_weaponIconImage4 != null)
			{
				_or_weaponIconImage4.color = value;
			}
		}
	}

	public Color r_weaponIconColor5
	{
		get
		{
			if (_or_weaponIconImage5 != null)
			{
				return _or_weaponIconImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (r_weaponIconColor5 != value && _or_weaponIconImage5 != null)
			{
				_or_weaponIconImage5.color = value;
			}
		}
	}

	public string r_nameString1
	{
		get
		{
			if (_or_nameText1 != null)
			{
				return _or_nameText1.text;
			}
			return null;
		}
		set
		{
			if (r_nameString1 != value && _or_nameText1 != null)
			{
				_or_nameText1.text = value;
			}
		}
	}

	public string r_nameString2
	{
		get
		{
			if (_or_nameText2 != null)
			{
				return _or_nameText2.text;
			}
			return null;
		}
		set
		{
			if (r_nameString2 != value && _or_nameText2 != null)
			{
				_or_nameText2.text = value;
			}
		}
	}

	public string r_nameString3
	{
		get
		{
			if (_or_nameText3 != null)
			{
				return _or_nameText3.text;
			}
			return null;
		}
		set
		{
			if (r_nameString3 != value && _or_nameText3 != null)
			{
				_or_nameText3.text = value;
			}
		}
	}

	public string r_nameString4
	{
		get
		{
			if (_or_nameText4 != null)
			{
				return _or_nameText4.text;
			}
			return null;
		}
		set
		{
			if (r_nameString4 != value && _or_nameText4 != null)
			{
				_or_nameText4.text = value;
			}
		}
	}

	public string r_nameString5
	{
		get
		{
			if (_or_nameText5 != null)
			{
				return _or_nameText5.text;
			}
			return null;
		}
		set
		{
			if (r_nameString5 != value && _or_nameText5 != null)
			{
				_or_nameText5.text = value;
			}
		}
	}

	public Toggle.ToggleEvent weaponToolTogglechanged1
	{
		get
		{
			if (_oweaponToolToggle1 != null)
			{
				return _oweaponToolToggle1.onValueChanged;
			}
			return null;
		}
		set
		{
			if (weaponToolTogglechanged1 != value && _oweaponToolToggle1 != null)
			{
				_oweaponToolToggle1.onValueChanged = value;
			}
		}
	}

	public Toggle.ToggleEvent weaponToolTogglechanged2
	{
		get
		{
			if (_oweaponToolToggle2 != null)
			{
				return _oweaponToolToggle2.onValueChanged;
			}
			return null;
		}
		set
		{
			if (weaponToolTogglechanged2 != value && _oweaponToolToggle2 != null)
			{
				_oweaponToolToggle2.onValueChanged = value;
			}
		}
	}

	public Toggle.ToggleEvent weaponToolTogglechanged3
	{
		get
		{
			if (_oweaponToolToggle3 != null)
			{
				return _oweaponToolToggle3.onValueChanged;
			}
			return null;
		}
		set
		{
			if (weaponToolTogglechanged3 != value && _oweaponToolToggle3 != null)
			{
				_oweaponToolToggle3.onValueChanged = value;
			}
		}
	}

	public Toggle.ToggleEvent weaponToolTogglechanged4
	{
		get
		{
			if (_oweaponToolToggle4 != null)
			{
				return _oweaponToolToggle4.onValueChanged;
			}
			return null;
		}
		set
		{
			if (weaponToolTogglechanged4 != value && _oweaponToolToggle4 != null)
			{
				_oweaponToolToggle4.onValueChanged = value;
			}
		}
	}

	public bool weaponToolOn1
	{
		get
		{
			if (_oweaponToolToggle1 != null)
			{
				return _oweaponToolToggle1.isOn;
			}
			return false;
		}
		set
		{
			if (weaponToolOn1 != value && _oweaponToolToggle1 != null)
			{
				_oweaponToolToggle1.isOn = value;
			}
		}
	}

	public bool weaponToolOn2
	{
		get
		{
			if (_oweaponToolToggle2 != null)
			{
				return _oweaponToolToggle2.isOn;
			}
			return false;
		}
		set
		{
			if (weaponToolOn2 != value && _oweaponToolToggle2 != null)
			{
				_oweaponToolToggle2.isOn = value;
			}
		}
	}

	public bool weaponToolOn3
	{
		get
		{
			if (_oweaponToolToggle3 != null)
			{
				return _oweaponToolToggle3.isOn;
			}
			return false;
		}
		set
		{
			if (weaponToolOn3 != value && _oweaponToolToggle3 != null)
			{
				_oweaponToolToggle3.isOn = value;
			}
		}
	}

	public bool weaponToolOn4
	{
		get
		{
			if (_oweaponToolToggle4 != null)
			{
				return _oweaponToolToggle4.isOn;
			}
			return false;
		}
		set
		{
			if (weaponToolOn4 != value && _oweaponToolToggle4 != null)
			{
				_oweaponToolToggle4.isOn = value;
			}
		}
	}

	public string levelString
	{
		get
		{
			if (_olevelText != null)
			{
				return _olevelText.text;
			}
			return null;
		}
		set
		{
			if (levelString != value && _olevelText != null)
			{
				_olevelText.text = value;
			}
		}
	}

	public string goldString
	{
		get
		{
			if (_ogoldText != null)
			{
				return _ogoldText.text;
			}
			return null;
		}
		set
		{
			if (goldString != value && _ogoldText != null)
			{
				_ogoldText.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent shop_rClicked
	{
		get
		{
			if (_oshop_rButton != null)
			{
				return _oshop_rButton.onClick;
			}
			return null;
		}
		set
		{
			if (shop_rClicked != value && _oshop_rButton != null)
			{
				_oshop_rButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent shop_sClicked
	{
		get
		{
			if (_oshop_sButton != null)
			{
				return _oshop_sButton.onClick;
			}
			return null;
		}
		set
		{
			if (shop_sClicked != value && _oshop_sButton != null)
			{
				_oshop_sButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent shop_xClicked
	{
		get
		{
			if (_oshop_xButton != null)
			{
				return _oshop_xButton.onClick;
			}
			return null;
		}
		set
		{
			if (shop_xClicked != value && _oshop_xButton != null)
			{
				_oshop_xButton.onClick = value;
			}
		}
	}

	public string closeString
	{
		get
		{
			if (_ocloseText != null)
			{
				return _ocloseText.text;
			}
			return null;
		}
		set
		{
			if (closeString != value && _ocloseText != null)
			{
				_ocloseText.text = value;
			}
		}
	}

	public string gold_desString
	{
		get
		{
			if (_ogold_desText != null)
			{
				return _ogold_desText.text;
			}
			return null;
		}
		set
		{
			if (gold_desString != value && _ogold_desText != null)
			{
				_ogold_desText.text = value;
			}
		}
	}

	public string level_desString
	{
		get
		{
			if (_olevel_desText != null)
			{
				return _olevel_desText.text;
			}
			return null;
		}
		set
		{
			if (level_desString != value && _olevel_desText != null)
			{
				_olevel_desText.text = value;
			}
		}
	}

	public string level_des_sjString
	{
		get
		{
			if (_olevel_des_sjText != null)
			{
				return _olevel_des_sjText.text;
			}
			return null;
		}
		set
		{
			if (level_des_sjString != value && _olevel_des_sjText != null)
			{
				_olevel_des_sjText.text = value;
			}
		}
	}

	public string level_sjString
	{
		get
		{
			if (_olevel_sjText != null)
			{
				return _olevel_sjText.text;
			}
			return null;
		}
		set
		{
			if (level_sjString != value && _olevel_sjText != null)
			{
				_olevel_sjText.text = value;
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
			case "l_1_weapon1":
				_ol_1_weapon1 = transform.gameObject;
				_ol_1_weaponButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon2":
				_ol_1_weapon2 = transform.gameObject;
				_ol_1_weaponButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon3":
				_ol_1_weapon3 = transform.gameObject;
				_ol_1_weaponButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon4":
				_ol_1_weapon4 = transform.gameObject;
				_ol_1_weaponButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon5":
				_ol_1_weapon5 = transform.gameObject;
				_ol_1_weaponButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon6":
				_ol_1_weapon6 = transform.gameObject;
				_ol_1_weaponButton6 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon7":
				_ol_1_weapon7 = transform.gameObject;
				_ol_1_weaponButton7 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon8":
				_ol_1_weapon8 = transform.gameObject;
				_ol_1_weaponButton8 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon9":
				_ol_1_weapon9 = transform.gameObject;
				_ol_1_weaponButton9 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon10":
				_ol_1_weapon10 = transform.gameObject;
				_ol_1_weaponButton10 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon11":
				_ol_1_weapon11 = transform.gameObject;
				_ol_1_weaponButton11 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon12":
				_ol_1_weapon12 = transform.gameObject;
				_ol_1_weaponButton12 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon13":
				_ol_1_weapon13 = transform.gameObject;
				_ol_1_weaponButton13 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon14":
				_ol_1_weapon14 = transform.gameObject;
				_ol_1_weaponButton14 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon15":
				_ol_1_weapon15 = transform.gameObject;
				_ol_1_weaponButton15 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon16":
				_ol_1_weapon16 = transform.gameObject;
				_ol_1_weaponButton16 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon17":
				_ol_1_weapon17 = transform.gameObject;
				_ol_1_weaponButton17 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon18":
				_ol_1_weapon18 = transform.gameObject;
				_ol_1_weaponButton18 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon19":
				_ol_1_weapon19 = transform.gameObject;
				_ol_1_weaponButton19 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon20":
				_ol_1_weapon20 = transform.gameObject;
				_ol_1_weaponButton20 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon21":
				_ol_1_weapon21 = transform.gameObject;
				_ol_1_weaponButton21 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon22":
				_ol_1_weapon22 = transform.gameObject;
				_ol_1_weaponButton22 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon23":
				_ol_1_weapon23 = transform.gameObject;
				_ol_1_weaponButton23 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon24":
				_ol_1_weapon24 = transform.gameObject;
				_ol_1_weaponButton24 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon25":
				_ol_1_weapon25 = transform.gameObject;
				_ol_1_weaponButton25 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon26":
				_ol_1_weapon26 = transform.gameObject;
				_ol_1_weaponButton26 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon27":
				_ol_1_weapon27 = transform.gameObject;
				_ol_1_weaponButton27 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon28":
				_ol_1_weapon28 = transform.gameObject;
				_ol_1_weaponButton28 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon29":
				_ol_1_weapon29 = transform.gameObject;
				_ol_1_weaponButton29 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon30":
				_ol_1_weapon30 = transform.gameObject;
				_ol_1_weaponButton30 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon31":
				_ol_1_weapon31 = transform.gameObject;
				_ol_1_weaponButton31 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon32":
				_ol_1_weapon32 = transform.gameObject;
				_ol_1_weaponButton32 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon33":
				_ol_1_weapon33 = transform.gameObject;
				_ol_1_weaponButton33 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon34":
				_ol_1_weapon34 = transform.gameObject;
				_ol_1_weaponButton34 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon35":
				_ol_1_weapon35 = transform.gameObject;
				_ol_1_weaponButton35 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon36":
				_ol_1_weapon36 = transform.gameObject;
				_ol_1_weaponButton36 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon37":
				_ol_1_weapon37 = transform.gameObject;
				_ol_1_weaponButton37 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon38":
				_ol_1_weapon38 = transform.gameObject;
				_ol_1_weaponButton38 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon39":
				_ol_1_weapon39 = transform.gameObject;
				_ol_1_weaponButton39 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_weapon40":
				_ol_1_weapon40 = transform.gameObject;
				_ol_1_weaponButton40 = transform.gameObject.GetComponent<Button>();
				break;
			case "l_1_Icon1":
				_ol_1_Icon1 = transform.gameObject;
				_ol_1_IconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon2":
				_ol_1_Icon2 = transform.gameObject;
				_ol_1_IconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon3":
				_ol_1_Icon3 = transform.gameObject;
				_ol_1_IconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon4":
				_ol_1_Icon4 = transform.gameObject;
				_ol_1_IconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon5":
				_ol_1_Icon5 = transform.gameObject;
				_ol_1_IconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon6":
				_ol_1_Icon6 = transform.gameObject;
				_ol_1_IconImage6 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon7":
				_ol_1_Icon7 = transform.gameObject;
				_ol_1_IconImage7 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon8":
				_ol_1_Icon8 = transform.gameObject;
				_ol_1_IconImage8 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon9":
				_ol_1_Icon9 = transform.gameObject;
				_ol_1_IconImage9 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon10":
				_ol_1_Icon10 = transform.gameObject;
				_ol_1_IconImage10 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon11":
				_ol_1_Icon11 = transform.gameObject;
				_ol_1_IconImage11 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon12":
				_ol_1_Icon12 = transform.gameObject;
				_ol_1_IconImage12 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon13":
				_ol_1_Icon13 = transform.gameObject;
				_ol_1_IconImage13 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon14":
				_ol_1_Icon14 = transform.gameObject;
				_ol_1_IconImage14 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon15":
				_ol_1_Icon15 = transform.gameObject;
				_ol_1_IconImage15 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon16":
				_ol_1_Icon16 = transform.gameObject;
				_ol_1_IconImage16 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon17":
				_ol_1_Icon17 = transform.gameObject;
				_ol_1_IconImage17 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon18":
				_ol_1_Icon18 = transform.gameObject;
				_ol_1_IconImage18 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon19":
				_ol_1_Icon19 = transform.gameObject;
				_ol_1_IconImage19 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon20":
				_ol_1_Icon20 = transform.gameObject;
				_ol_1_IconImage20 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon21":
				_ol_1_Icon21 = transform.gameObject;
				_ol_1_IconImage21 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon22":
				_ol_1_Icon22 = transform.gameObject;
				_ol_1_IconImage22 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon23":
				_ol_1_Icon23 = transform.gameObject;
				_ol_1_IconImage23 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon24":
				_ol_1_Icon24 = transform.gameObject;
				_ol_1_IconImage24 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon25":
				_ol_1_Icon25 = transform.gameObject;
				_ol_1_IconImage25 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon26":
				_ol_1_Icon26 = transform.gameObject;
				_ol_1_IconImage26 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon27":
				_ol_1_Icon27 = transform.gameObject;
				_ol_1_IconImage27 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon28":
				_ol_1_Icon28 = transform.gameObject;
				_ol_1_IconImage28 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon29":
				_ol_1_Icon29 = transform.gameObject;
				_ol_1_IconImage29 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon30":
				_ol_1_Icon30 = transform.gameObject;
				_ol_1_IconImage30 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon31":
				_ol_1_Icon31 = transform.gameObject;
				_ol_1_IconImage31 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon32":
				_ol_1_Icon32 = transform.gameObject;
				_ol_1_IconImage32 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon33":
				_ol_1_Icon33 = transform.gameObject;
				_ol_1_IconImage33 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon34":
				_ol_1_Icon34 = transform.gameObject;
				_ol_1_IconImage34 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon35":
				_ol_1_Icon35 = transform.gameObject;
				_ol_1_IconImage35 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon36":
				_ol_1_Icon36 = transform.gameObject;
				_ol_1_IconImage36 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon37":
				_ol_1_Icon37 = transform.gameObject;
				_ol_1_IconImage37 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon38":
				_ol_1_Icon38 = transform.gameObject;
				_ol_1_IconImage38 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon39":
				_ol_1_Icon39 = transform.gameObject;
				_ol_1_IconImage39 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_Icon40":
				_ol_1_Icon40 = transform.gameObject;
				_ol_1_IconImage40 = transform.gameObject.GetComponent<Image>();
				break;
			case "l_1_name1":
				_ol_1_name1 = transform.gameObject;
				_ol_1_nameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name2":
				_ol_1_name2 = transform.gameObject;
				_ol_1_nameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name3":
				_ol_1_name3 = transform.gameObject;
				_ol_1_nameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name4":
				_ol_1_name4 = transform.gameObject;
				_ol_1_nameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name5":
				_ol_1_name5 = transform.gameObject;
				_ol_1_nameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name6":
				_ol_1_name6 = transform.gameObject;
				_ol_1_nameText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name7":
				_ol_1_name7 = transform.gameObject;
				_ol_1_nameText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name8":
				_ol_1_name8 = transform.gameObject;
				_ol_1_nameText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name9":
				_ol_1_name9 = transform.gameObject;
				_ol_1_nameText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name10":
				_ol_1_name10 = transform.gameObject;
				_ol_1_nameText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name11":
				_ol_1_name11 = transform.gameObject;
				_ol_1_nameText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name12":
				_ol_1_name12 = transform.gameObject;
				_ol_1_nameText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name13":
				_ol_1_name13 = transform.gameObject;
				_ol_1_nameText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name14":
				_ol_1_name14 = transform.gameObject;
				_ol_1_nameText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name15":
				_ol_1_name15 = transform.gameObject;
				_ol_1_nameText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name16":
				_ol_1_name16 = transform.gameObject;
				_ol_1_nameText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name17":
				_ol_1_name17 = transform.gameObject;
				_ol_1_nameText17 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name18":
				_ol_1_name18 = transform.gameObject;
				_ol_1_nameText18 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name19":
				_ol_1_name19 = transform.gameObject;
				_ol_1_nameText19 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name20":
				_ol_1_name20 = transform.gameObject;
				_ol_1_nameText20 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name21":
				_ol_1_name21 = transform.gameObject;
				_ol_1_nameText21 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name22":
				_ol_1_name22 = transform.gameObject;
				_ol_1_nameText22 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name23":
				_ol_1_name23 = transform.gameObject;
				_ol_1_nameText23 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name24":
				_ol_1_name24 = transform.gameObject;
				_ol_1_nameText24 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name25":
				_ol_1_name25 = transform.gameObject;
				_ol_1_nameText25 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name26":
				_ol_1_name26 = transform.gameObject;
				_ol_1_nameText26 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name27":
				_ol_1_name27 = transform.gameObject;
				_ol_1_nameText27 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name28":
				_ol_1_name28 = transform.gameObject;
				_ol_1_nameText28 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name29":
				_ol_1_name29 = transform.gameObject;
				_ol_1_nameText29 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name30":
				_ol_1_name30 = transform.gameObject;
				_ol_1_nameText30 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name31":
				_ol_1_name31 = transform.gameObject;
				_ol_1_nameText31 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name32":
				_ol_1_name32 = transform.gameObject;
				_ol_1_nameText32 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name33":
				_ol_1_name33 = transform.gameObject;
				_ol_1_nameText33 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name34":
				_ol_1_name34 = transform.gameObject;
				_ol_1_nameText34 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name35":
				_ol_1_name35 = transform.gameObject;
				_ol_1_nameText35 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name36":
				_ol_1_name36 = transform.gameObject;
				_ol_1_nameText36 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name37":
				_ol_1_name37 = transform.gameObject;
				_ol_1_nameText37 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name38":
				_ol_1_name38 = transform.gameObject;
				_ol_1_nameText38 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name39":
				_ol_1_name39 = transform.gameObject;
				_ol_1_nameText39 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_name40":
				_ol_1_name40 = transform.gameObject;
				_ol_1_nameText40 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money1":
				_ol_1_money1 = transform.gameObject;
				_ol_1_moneyText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money2":
				_ol_1_money2 = transform.gameObject;
				_ol_1_moneyText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money3":
				_ol_1_money3 = transform.gameObject;
				_ol_1_moneyText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money4":
				_ol_1_money4 = transform.gameObject;
				_ol_1_moneyText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money5":
				_ol_1_money5 = transform.gameObject;
				_ol_1_moneyText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money6":
				_ol_1_money6 = transform.gameObject;
				_ol_1_moneyText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money7":
				_ol_1_money7 = transform.gameObject;
				_ol_1_moneyText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money8":
				_ol_1_money8 = transform.gameObject;
				_ol_1_moneyText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money9":
				_ol_1_money9 = transform.gameObject;
				_ol_1_moneyText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money10":
				_ol_1_money10 = transform.gameObject;
				_ol_1_moneyText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money11":
				_ol_1_money11 = transform.gameObject;
				_ol_1_moneyText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money12":
				_ol_1_money12 = transform.gameObject;
				_ol_1_moneyText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money13":
				_ol_1_money13 = transform.gameObject;
				_ol_1_moneyText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money14":
				_ol_1_money14 = transform.gameObject;
				_ol_1_moneyText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money15":
				_ol_1_money15 = transform.gameObject;
				_ol_1_moneyText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money16":
				_ol_1_money16 = transform.gameObject;
				_ol_1_moneyText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money17":
				_ol_1_money17 = transform.gameObject;
				_ol_1_moneyText17 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money18":
				_ol_1_money18 = transform.gameObject;
				_ol_1_moneyText18 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money19":
				_ol_1_money19 = transform.gameObject;
				_ol_1_moneyText19 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money20":
				_ol_1_money20 = transform.gameObject;
				_ol_1_moneyText20 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money21":
				_ol_1_money21 = transform.gameObject;
				_ol_1_moneyText21 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money22":
				_ol_1_money22 = transform.gameObject;
				_ol_1_moneyText22 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money23":
				_ol_1_money23 = transform.gameObject;
				_ol_1_moneyText23 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money24":
				_ol_1_money24 = transform.gameObject;
				_ol_1_moneyText24 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money25":
				_ol_1_money25 = transform.gameObject;
				_ol_1_moneyText25 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money26":
				_ol_1_money26 = transform.gameObject;
				_ol_1_moneyText26 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money27":
				_ol_1_money27 = transform.gameObject;
				_ol_1_moneyText27 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money28":
				_ol_1_money28 = transform.gameObject;
				_ol_1_moneyText28 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money29":
				_ol_1_money29 = transform.gameObject;
				_ol_1_moneyText29 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money30":
				_ol_1_money30 = transform.gameObject;
				_ol_1_moneyText30 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money31":
				_ol_1_money31 = transform.gameObject;
				_ol_1_moneyText31 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money32":
				_ol_1_money32 = transform.gameObject;
				_ol_1_moneyText32 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money33":
				_ol_1_money33 = transform.gameObject;
				_ol_1_moneyText33 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money34":
				_ol_1_money34 = transform.gameObject;
				_ol_1_moneyText34 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money35":
				_ol_1_money35 = transform.gameObject;
				_ol_1_moneyText35 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money36":
				_ol_1_money36 = transform.gameObject;
				_ol_1_moneyText36 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money37":
				_ol_1_money37 = transform.gameObject;
				_ol_1_moneyText37 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money38":
				_ol_1_money38 = transform.gameObject;
				_ol_1_moneyText38 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money39":
				_ol_1_money39 = transform.gameObject;
				_ol_1_moneyText39 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_money40":
				_ol_1_money40 = transform.gameObject;
				_ol_1_moneyText40 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock1":
				_ol_1_lock1 = transform.gameObject;
				break;
			case "l_1_lock2":
				_ol_1_lock2 = transform.gameObject;
				break;
			case "l_1_lock3":
				_ol_1_lock3 = transform.gameObject;
				break;
			case "l_1_lock4":
				_ol_1_lock4 = transform.gameObject;
				break;
			case "l_1_lock5":
				_ol_1_lock5 = transform.gameObject;
				break;
			case "l_1_lock6":
				_ol_1_lock6 = transform.gameObject;
				break;
			case "l_1_lock7":
				_ol_1_lock7 = transform.gameObject;
				break;
			case "l_1_lock8":
				_ol_1_lock8 = transform.gameObject;
				break;
			case "l_1_lock9":
				_ol_1_lock9 = transform.gameObject;
				break;
			case "l_1_lock10":
				_ol_1_lock10 = transform.gameObject;
				break;
			case "l_1_lock11":
				_ol_1_lock11 = transform.gameObject;
				break;
			case "l_1_lock12":
				_ol_1_lock12 = transform.gameObject;
				break;
			case "l_1_lock13":
				_ol_1_lock13 = transform.gameObject;
				break;
			case "l_1_lock14":
				_ol_1_lock14 = transform.gameObject;
				break;
			case "l_1_lock15":
				_ol_1_lock15 = transform.gameObject;
				break;
			case "l_1_lock16":
				_ol_1_lock16 = transform.gameObject;
				break;
			case "l_1_lock17":
				_ol_1_lock17 = transform.gameObject;
				break;
			case "l_1_lock18":
				_ol_1_lock18 = transform.gameObject;
				break;
			case "l_1_lock19":
				_ol_1_lock19 = transform.gameObject;
				break;
			case "l_1_lock20":
				_ol_1_lock20 = transform.gameObject;
				break;
			case "l_1_lock21":
				_ol_1_lock21 = transform.gameObject;
				break;
			case "l_1_lock22":
				_ol_1_lock22 = transform.gameObject;
				break;
			case "l_1_lock23":
				_ol_1_lock23 = transform.gameObject;
				break;
			case "l_1_lock24":
				_ol_1_lock24 = transform.gameObject;
				break;
			case "l_1_lock25":
				_ol_1_lock25 = transform.gameObject;
				break;
			case "l_1_lock26":
				_ol_1_lock26 = transform.gameObject;
				break;
			case "l_1_lock27":
				_ol_1_lock27 = transform.gameObject;
				break;
			case "l_1_lock28":
				_ol_1_lock28 = transform.gameObject;
				break;
			case "l_1_lock29":
				_ol_1_lock29 = transform.gameObject;
				break;
			case "l_1_lock30":
				_ol_1_lock30 = transform.gameObject;
				break;
			case "l_1_lock31":
				_ol_1_lock31 = transform.gameObject;
				break;
			case "l_1_lock32":
				_ol_1_lock32 = transform.gameObject;
				break;
			case "l_1_lock33":
				_ol_1_lock33 = transform.gameObject;
				break;
			case "l_1_lock34":
				_ol_1_lock34 = transform.gameObject;
				break;
			case "l_1_lock35":
				_ol_1_lock35 = transform.gameObject;
				break;
			case "l_1_lock36":
				_ol_1_lock36 = transform.gameObject;
				break;
			case "l_1_lock37":
				_ol_1_lock37 = transform.gameObject;
				break;
			case "l_1_lock38":
				_ol_1_lock38 = transform.gameObject;
				break;
			case "l_1_lock39":
				_ol_1_lock39 = transform.gameObject;
				break;
			case "l_1_lock40":
				_ol_1_lock40 = transform.gameObject;
				break;
			case "l_1_lock_lv1":
				_ol_1_lock_lv1 = transform.gameObject;
				_ol_1_lock_lvText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv2":
				_ol_1_lock_lv2 = transform.gameObject;
				_ol_1_lock_lvText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv3":
				_ol_1_lock_lv3 = transform.gameObject;
				_ol_1_lock_lvText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv4":
				_ol_1_lock_lv4 = transform.gameObject;
				_ol_1_lock_lvText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv5":
				_ol_1_lock_lv5 = transform.gameObject;
				_ol_1_lock_lvText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv6":
				_ol_1_lock_lv6 = transform.gameObject;
				_ol_1_lock_lvText6 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv7":
				_ol_1_lock_lv7 = transform.gameObject;
				_ol_1_lock_lvText7 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv8":
				_ol_1_lock_lv8 = transform.gameObject;
				_ol_1_lock_lvText8 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv9":
				_ol_1_lock_lv9 = transform.gameObject;
				_ol_1_lock_lvText9 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv10":
				_ol_1_lock_lv10 = transform.gameObject;
				_ol_1_lock_lvText10 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv11":
				_ol_1_lock_lv11 = transform.gameObject;
				_ol_1_lock_lvText11 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv12":
				_ol_1_lock_lv12 = transform.gameObject;
				_ol_1_lock_lvText12 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv13":
				_ol_1_lock_lv13 = transform.gameObject;
				_ol_1_lock_lvText13 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv14":
				_ol_1_lock_lv14 = transform.gameObject;
				_ol_1_lock_lvText14 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv15":
				_ol_1_lock_lv15 = transform.gameObject;
				_ol_1_lock_lvText15 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv16":
				_ol_1_lock_lv16 = transform.gameObject;
				_ol_1_lock_lvText16 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv17":
				_ol_1_lock_lv17 = transform.gameObject;
				_ol_1_lock_lvText17 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv18":
				_ol_1_lock_lv18 = transform.gameObject;
				_ol_1_lock_lvText18 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv19":
				_ol_1_lock_lv19 = transform.gameObject;
				_ol_1_lock_lvText19 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv20":
				_ol_1_lock_lv20 = transform.gameObject;
				_ol_1_lock_lvText20 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv21":
				_ol_1_lock_lv21 = transform.gameObject;
				_ol_1_lock_lvText21 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv22":
				_ol_1_lock_lv22 = transform.gameObject;
				_ol_1_lock_lvText22 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv23":
				_ol_1_lock_lv23 = transform.gameObject;
				_ol_1_lock_lvText23 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv24":
				_ol_1_lock_lv24 = transform.gameObject;
				_ol_1_lock_lvText24 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv25":
				_ol_1_lock_lv25 = transform.gameObject;
				_ol_1_lock_lvText25 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv26":
				_ol_1_lock_lv26 = transform.gameObject;
				_ol_1_lock_lvText26 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv27":
				_ol_1_lock_lv27 = transform.gameObject;
				_ol_1_lock_lvText27 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv28":
				_ol_1_lock_lv28 = transform.gameObject;
				_ol_1_lock_lvText28 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv29":
				_ol_1_lock_lv29 = transform.gameObject;
				_ol_1_lock_lvText29 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv30":
				_ol_1_lock_lv30 = transform.gameObject;
				_ol_1_lock_lvText30 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv31":
				_ol_1_lock_lv31 = transform.gameObject;
				_ol_1_lock_lvText31 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv32":
				_ol_1_lock_lv32 = transform.gameObject;
				_ol_1_lock_lvText32 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv33":
				_ol_1_lock_lv33 = transform.gameObject;
				_ol_1_lock_lvText33 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv34":
				_ol_1_lock_lv34 = transform.gameObject;
				_ol_1_lock_lvText34 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv35":
				_ol_1_lock_lv35 = transform.gameObject;
				_ol_1_lock_lvText35 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv36":
				_ol_1_lock_lv36 = transform.gameObject;
				_ol_1_lock_lvText36 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv37":
				_ol_1_lock_lv37 = transform.gameObject;
				_ol_1_lock_lvText37 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv38":
				_ol_1_lock_lv38 = transform.gameObject;
				_ol_1_lock_lvText38 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv39":
				_ol_1_lock_lv39 = transform.gameObject;
				_ol_1_lock_lvText39 = transform.gameObject.GetComponent<Text>();
				break;
			case "l_1_lock_lv40":
				_ol_1_lock_lv40 = transform.gameObject;
				_ol_1_lock_lvText40 = transform.gameObject.GetComponent<Text>();
				break;
			case "r_weapon1":
				_or_weapon1 = transform.gameObject;
				_or_weaponButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "r_weapon2":
				_or_weapon2 = transform.gameObject;
				_or_weaponButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "r_weapon3":
				_or_weapon3 = transform.gameObject;
				_or_weaponButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "r_weapon4":
				_or_weapon4 = transform.gameObject;
				_or_weaponButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "r_weapon5":
				_or_weapon5 = transform.gameObject;
				_or_weaponButton5 = transform.gameObject.GetComponent<Button>();
				break;
			case "r_weaponIcon1":
				_or_weaponIcon1 = transform.gameObject;
				_or_weaponIconImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "r_weaponIcon2":
				_or_weaponIcon2 = transform.gameObject;
				_or_weaponIconImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "r_weaponIcon3":
				_or_weaponIcon3 = transform.gameObject;
				_or_weaponIconImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "r_weaponIcon4":
				_or_weaponIcon4 = transform.gameObject;
				_or_weaponIconImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "r_weaponIcon5":
				_or_weaponIcon5 = transform.gameObject;
				_or_weaponIconImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "r_name1":
				_or_name1 = transform.gameObject;
				_or_nameText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "r_name2":
				_or_name2 = transform.gameObject;
				_or_nameText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "r_name3":
				_or_name3 = transform.gameObject;
				_or_nameText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "r_name4":
				_or_name4 = transform.gameObject;
				_or_nameText4 = transform.gameObject.GetComponent<Text>();
				break;
			case "r_name5":
				_or_name5 = transform.gameObject;
				_or_nameText5 = transform.gameObject.GetComponent<Text>();
				break;
			case "weaponTool1":
				_oweaponTool1 = transform.gameObject;
				_oweaponToolToggle1 = transform.gameObject.GetComponent<Toggle>();
				break;
			case "weaponTool2":
				_oweaponTool2 = transform.gameObject;
				_oweaponToolToggle2 = transform.gameObject.GetComponent<Toggle>();
				break;
			case "weaponTool3":
				_oweaponTool3 = transform.gameObject;
				_oweaponToolToggle3 = transform.gameObject.GetComponent<Toggle>();
				break;
			case "weaponTool4":
				_oweaponTool4 = transform.gameObject;
				_oweaponToolToggle4 = transform.gameObject.GetComponent<Toggle>();
				break;
			case "level":
				_olevel = transform.gameObject;
				_olevelText = transform.gameObject.GetComponent<Text>();
				break;
			case "gold":
				_ogold = transform.gameObject;
				_ogoldText = transform.gameObject.GetComponent<Text>();
				break;
			case "shop_r":
				_oshop_r = transform.gameObject;
				_oshop_rButton = transform.gameObject.GetComponent<Button>();
				break;
			case "shop_s":
				_oshop_s = transform.gameObject;
				_oshop_sButton = transform.gameObject.GetComponent<Button>();
				break;
			case "shop_x":
				_oshop_x = transform.gameObject;
				_oshop_xButton = transform.gameObject.GetComponent<Button>();
				break;
			case "close":
				_oclose = transform.gameObject;
				_ocloseText = transform.gameObject.GetComponent<Text>();
				break;
			case "gold_des":
				_ogold_des = transform.gameObject;
				_ogold_desText = transform.gameObject.GetComponent<Text>();
				break;
			case "level_des":
				_olevel_des = transform.gameObject;
				_olevel_desText = transform.gameObject.GetComponent<Text>();
				break;
			case "level_des_sj":
				_olevel_des_sj = transform.gameObject;
				_olevel_des_sjText = transform.gameObject.GetComponent<Text>();
				break;
			case "level_sj":
				_olevel_sj = transform.gameObject;
				_olevel_sjText = transform.gameObject.GetComponent<Text>();
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

	public bool Getl_1_weaponShow(int index)
	{
		return index switch
		{
			1 => l_1_weaponShow1, 
			2 => l_1_weaponShow2, 
			3 => l_1_weaponShow3, 
			4 => l_1_weaponShow4, 
			5 => l_1_weaponShow5, 
			6 => l_1_weaponShow6, 
			7 => l_1_weaponShow7, 
			8 => l_1_weaponShow8, 
			9 => l_1_weaponShow9, 
			10 => l_1_weaponShow10, 
			11 => l_1_weaponShow11, 
			12 => l_1_weaponShow12, 
			13 => l_1_weaponShow13, 
			14 => l_1_weaponShow14, 
			15 => l_1_weaponShow15, 
			16 => l_1_weaponShow16, 
			17 => l_1_weaponShow17, 
			18 => l_1_weaponShow18, 
			19 => l_1_weaponShow19, 
			20 => l_1_weaponShow20, 
			21 => l_1_weaponShow21, 
			22 => l_1_weaponShow22, 
			23 => l_1_weaponShow23, 
			24 => l_1_weaponShow24, 
			25 => l_1_weaponShow25, 
			26 => l_1_weaponShow26, 
			27 => l_1_weaponShow27, 
			28 => l_1_weaponShow28, 
			29 => l_1_weaponShow29, 
			30 => l_1_weaponShow30, 
			31 => l_1_weaponShow31, 
			32 => l_1_weaponShow32, 
			33 => l_1_weaponShow33, 
			34 => l_1_weaponShow34, 
			35 => l_1_weaponShow35, 
			36 => l_1_weaponShow36, 
			37 => l_1_weaponShow37, 
			38 => l_1_weaponShow38, 
			39 => l_1_weaponShow39, 
			40 => l_1_weaponShow40, 
			_ => false, 
		};
	}

	public void Setl_1_weaponShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			l_1_weaponShow1 = value;
			break;
		case 2:
			l_1_weaponShow2 = value;
			break;
		case 3:
			l_1_weaponShow3 = value;
			break;
		case 4:
			l_1_weaponShow4 = value;
			break;
		case 5:
			l_1_weaponShow5 = value;
			break;
		case 6:
			l_1_weaponShow6 = value;
			break;
		case 7:
			l_1_weaponShow7 = value;
			break;
		case 8:
			l_1_weaponShow8 = value;
			break;
		case 9:
			l_1_weaponShow9 = value;
			break;
		case 10:
			l_1_weaponShow10 = value;
			break;
		case 11:
			l_1_weaponShow11 = value;
			break;
		case 12:
			l_1_weaponShow12 = value;
			break;
		case 13:
			l_1_weaponShow13 = value;
			break;
		case 14:
			l_1_weaponShow14 = value;
			break;
		case 15:
			l_1_weaponShow15 = value;
			break;
		case 16:
			l_1_weaponShow16 = value;
			break;
		case 17:
			l_1_weaponShow17 = value;
			break;
		case 18:
			l_1_weaponShow18 = value;
			break;
		case 19:
			l_1_weaponShow19 = value;
			break;
		case 20:
			l_1_weaponShow20 = value;
			break;
		case 21:
			l_1_weaponShow21 = value;
			break;
		case 22:
			l_1_weaponShow22 = value;
			break;
		case 23:
			l_1_weaponShow23 = value;
			break;
		case 24:
			l_1_weaponShow24 = value;
			break;
		case 25:
			l_1_weaponShow25 = value;
			break;
		case 26:
			l_1_weaponShow26 = value;
			break;
		case 27:
			l_1_weaponShow27 = value;
			break;
		case 28:
			l_1_weaponShow28 = value;
			break;
		case 29:
			l_1_weaponShow29 = value;
			break;
		case 30:
			l_1_weaponShow30 = value;
			break;
		case 31:
			l_1_weaponShow31 = value;
			break;
		case 32:
			l_1_weaponShow32 = value;
			break;
		case 33:
			l_1_weaponShow33 = value;
			break;
		case 34:
			l_1_weaponShow34 = value;
			break;
		case 35:
			l_1_weaponShow35 = value;
			break;
		case 36:
			l_1_weaponShow36 = value;
			break;
		case 37:
			l_1_weaponShow37 = value;
			break;
		case 38:
			l_1_weaponShow38 = value;
			break;
		case 39:
			l_1_weaponShow39 = value;
			break;
		case 40:
			l_1_weaponShow40 = value;
			break;
		}
	}

	public int Getl_1_weaponCount()
	{
		return 40;
	}

	public Button.ButtonClickedEvent Getl_1_weaponClicked(int index)
	{
		return index switch
		{
			1 => l_1_weaponClicked1, 
			2 => l_1_weaponClicked2, 
			3 => l_1_weaponClicked3, 
			4 => l_1_weaponClicked4, 
			5 => l_1_weaponClicked5, 
			6 => l_1_weaponClicked6, 
			7 => l_1_weaponClicked7, 
			8 => l_1_weaponClicked8, 
			9 => l_1_weaponClicked9, 
			10 => l_1_weaponClicked10, 
			11 => l_1_weaponClicked11, 
			12 => l_1_weaponClicked12, 
			13 => l_1_weaponClicked13, 
			14 => l_1_weaponClicked14, 
			15 => l_1_weaponClicked15, 
			16 => l_1_weaponClicked16, 
			17 => l_1_weaponClicked17, 
			18 => l_1_weaponClicked18, 
			19 => l_1_weaponClicked19, 
			20 => l_1_weaponClicked20, 
			21 => l_1_weaponClicked21, 
			22 => l_1_weaponClicked22, 
			23 => l_1_weaponClicked23, 
			24 => l_1_weaponClicked24, 
			25 => l_1_weaponClicked25, 
			26 => l_1_weaponClicked26, 
			27 => l_1_weaponClicked27, 
			28 => l_1_weaponClicked28, 
			29 => l_1_weaponClicked29, 
			30 => l_1_weaponClicked30, 
			31 => l_1_weaponClicked31, 
			32 => l_1_weaponClicked32, 
			33 => l_1_weaponClicked33, 
			34 => l_1_weaponClicked34, 
			35 => l_1_weaponClicked35, 
			36 => l_1_weaponClicked36, 
			37 => l_1_weaponClicked37, 
			38 => l_1_weaponClicked38, 
			39 => l_1_weaponClicked39, 
			40 => l_1_weaponClicked40, 
			_ => null, 
		};
	}

	public void Setl_1_weaponClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			l_1_weaponClicked1 = value;
			break;
		case 2:
			l_1_weaponClicked2 = value;
			break;
		case 3:
			l_1_weaponClicked3 = value;
			break;
		case 4:
			l_1_weaponClicked4 = value;
			break;
		case 5:
			l_1_weaponClicked5 = value;
			break;
		case 6:
			l_1_weaponClicked6 = value;
			break;
		case 7:
			l_1_weaponClicked7 = value;
			break;
		case 8:
			l_1_weaponClicked8 = value;
			break;
		case 9:
			l_1_weaponClicked9 = value;
			break;
		case 10:
			l_1_weaponClicked10 = value;
			break;
		case 11:
			l_1_weaponClicked11 = value;
			break;
		case 12:
			l_1_weaponClicked12 = value;
			break;
		case 13:
			l_1_weaponClicked13 = value;
			break;
		case 14:
			l_1_weaponClicked14 = value;
			break;
		case 15:
			l_1_weaponClicked15 = value;
			break;
		case 16:
			l_1_weaponClicked16 = value;
			break;
		case 17:
			l_1_weaponClicked17 = value;
			break;
		case 18:
			l_1_weaponClicked18 = value;
			break;
		case 19:
			l_1_weaponClicked19 = value;
			break;
		case 20:
			l_1_weaponClicked20 = value;
			break;
		case 21:
			l_1_weaponClicked21 = value;
			break;
		case 22:
			l_1_weaponClicked22 = value;
			break;
		case 23:
			l_1_weaponClicked23 = value;
			break;
		case 24:
			l_1_weaponClicked24 = value;
			break;
		case 25:
			l_1_weaponClicked25 = value;
			break;
		case 26:
			l_1_weaponClicked26 = value;
			break;
		case 27:
			l_1_weaponClicked27 = value;
			break;
		case 28:
			l_1_weaponClicked28 = value;
			break;
		case 29:
			l_1_weaponClicked29 = value;
			break;
		case 30:
			l_1_weaponClicked30 = value;
			break;
		case 31:
			l_1_weaponClicked31 = value;
			break;
		case 32:
			l_1_weaponClicked32 = value;
			break;
		case 33:
			l_1_weaponClicked33 = value;
			break;
		case 34:
			l_1_weaponClicked34 = value;
			break;
		case 35:
			l_1_weaponClicked35 = value;
			break;
		case 36:
			l_1_weaponClicked36 = value;
			break;
		case 37:
			l_1_weaponClicked37 = value;
			break;
		case 38:
			l_1_weaponClicked38 = value;
			break;
		case 39:
			l_1_weaponClicked39 = value;
			break;
		case 40:
			l_1_weaponClicked40 = value;
			break;
		}
	}

	public Sprite Getl_1_IconSprite(int index)
	{
		return index switch
		{
			1 => l_1_IconSprite1, 
			2 => l_1_IconSprite2, 
			3 => l_1_IconSprite3, 
			4 => l_1_IconSprite4, 
			5 => l_1_IconSprite5, 
			6 => l_1_IconSprite6, 
			7 => l_1_IconSprite7, 
			8 => l_1_IconSprite8, 
			9 => l_1_IconSprite9, 
			10 => l_1_IconSprite10, 
			11 => l_1_IconSprite11, 
			12 => l_1_IconSprite12, 
			13 => l_1_IconSprite13, 
			14 => l_1_IconSprite14, 
			15 => l_1_IconSprite15, 
			16 => l_1_IconSprite16, 
			17 => l_1_IconSprite17, 
			18 => l_1_IconSprite18, 
			19 => l_1_IconSprite19, 
			20 => l_1_IconSprite20, 
			21 => l_1_IconSprite21, 
			22 => l_1_IconSprite22, 
			23 => l_1_IconSprite23, 
			24 => l_1_IconSprite24, 
			25 => l_1_IconSprite25, 
			26 => l_1_IconSprite26, 
			27 => l_1_IconSprite27, 
			28 => l_1_IconSprite28, 
			29 => l_1_IconSprite29, 
			30 => l_1_IconSprite30, 
			31 => l_1_IconSprite31, 
			32 => l_1_IconSprite32, 
			33 => l_1_IconSprite33, 
			34 => l_1_IconSprite34, 
			35 => l_1_IconSprite35, 
			36 => l_1_IconSprite36, 
			37 => l_1_IconSprite37, 
			38 => l_1_IconSprite38, 
			39 => l_1_IconSprite39, 
			40 => l_1_IconSprite40, 
			_ => null, 
		};
	}

	public void Setl_1_IconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			l_1_IconSprite1 = value;
			break;
		case 2:
			l_1_IconSprite2 = value;
			break;
		case 3:
			l_1_IconSprite3 = value;
			break;
		case 4:
			l_1_IconSprite4 = value;
			break;
		case 5:
			l_1_IconSprite5 = value;
			break;
		case 6:
			l_1_IconSprite6 = value;
			break;
		case 7:
			l_1_IconSprite7 = value;
			break;
		case 8:
			l_1_IconSprite8 = value;
			break;
		case 9:
			l_1_IconSprite9 = value;
			break;
		case 10:
			l_1_IconSprite10 = value;
			break;
		case 11:
			l_1_IconSprite11 = value;
			break;
		case 12:
			l_1_IconSprite12 = value;
			break;
		case 13:
			l_1_IconSprite13 = value;
			break;
		case 14:
			l_1_IconSprite14 = value;
			break;
		case 15:
			l_1_IconSprite15 = value;
			break;
		case 16:
			l_1_IconSprite16 = value;
			break;
		case 17:
			l_1_IconSprite17 = value;
			break;
		case 18:
			l_1_IconSprite18 = value;
			break;
		case 19:
			l_1_IconSprite19 = value;
			break;
		case 20:
			l_1_IconSprite20 = value;
			break;
		case 21:
			l_1_IconSprite21 = value;
			break;
		case 22:
			l_1_IconSprite22 = value;
			break;
		case 23:
			l_1_IconSprite23 = value;
			break;
		case 24:
			l_1_IconSprite24 = value;
			break;
		case 25:
			l_1_IconSprite25 = value;
			break;
		case 26:
			l_1_IconSprite26 = value;
			break;
		case 27:
			l_1_IconSprite27 = value;
			break;
		case 28:
			l_1_IconSprite28 = value;
			break;
		case 29:
			l_1_IconSprite29 = value;
			break;
		case 30:
			l_1_IconSprite30 = value;
			break;
		case 31:
			l_1_IconSprite31 = value;
			break;
		case 32:
			l_1_IconSprite32 = value;
			break;
		case 33:
			l_1_IconSprite33 = value;
			break;
		case 34:
			l_1_IconSprite34 = value;
			break;
		case 35:
			l_1_IconSprite35 = value;
			break;
		case 36:
			l_1_IconSprite36 = value;
			break;
		case 37:
			l_1_IconSprite37 = value;
			break;
		case 38:
			l_1_IconSprite38 = value;
			break;
		case 39:
			l_1_IconSprite39 = value;
			break;
		case 40:
			l_1_IconSprite40 = value;
			break;
		}
	}

	public int Getl_1_IconCount()
	{
		return 40;
	}

	public Color Getl_1_IconColor(int index)
	{
		return index switch
		{
			1 => l_1_IconColor1, 
			2 => l_1_IconColor2, 
			3 => l_1_IconColor3, 
			4 => l_1_IconColor4, 
			5 => l_1_IconColor5, 
			6 => l_1_IconColor6, 
			7 => l_1_IconColor7, 
			8 => l_1_IconColor8, 
			9 => l_1_IconColor9, 
			10 => l_1_IconColor10, 
			11 => l_1_IconColor11, 
			12 => l_1_IconColor12, 
			13 => l_1_IconColor13, 
			14 => l_1_IconColor14, 
			15 => l_1_IconColor15, 
			16 => l_1_IconColor16, 
			17 => l_1_IconColor17, 
			18 => l_1_IconColor18, 
			19 => l_1_IconColor19, 
			20 => l_1_IconColor20, 
			21 => l_1_IconColor21, 
			22 => l_1_IconColor22, 
			23 => l_1_IconColor23, 
			24 => l_1_IconColor24, 
			25 => l_1_IconColor25, 
			26 => l_1_IconColor26, 
			27 => l_1_IconColor27, 
			28 => l_1_IconColor28, 
			29 => l_1_IconColor29, 
			30 => l_1_IconColor30, 
			31 => l_1_IconColor31, 
			32 => l_1_IconColor32, 
			33 => l_1_IconColor33, 
			34 => l_1_IconColor34, 
			35 => l_1_IconColor35, 
			36 => l_1_IconColor36, 
			37 => l_1_IconColor37, 
			38 => l_1_IconColor38, 
			39 => l_1_IconColor39, 
			40 => l_1_IconColor40, 
			_ => Color.white, 
		};
	}

	public void Setl_1_IconColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			l_1_IconColor1 = value;
			break;
		case 2:
			l_1_IconColor2 = value;
			break;
		case 3:
			l_1_IconColor3 = value;
			break;
		case 4:
			l_1_IconColor4 = value;
			break;
		case 5:
			l_1_IconColor5 = value;
			break;
		case 6:
			l_1_IconColor6 = value;
			break;
		case 7:
			l_1_IconColor7 = value;
			break;
		case 8:
			l_1_IconColor8 = value;
			break;
		case 9:
			l_1_IconColor9 = value;
			break;
		case 10:
			l_1_IconColor10 = value;
			break;
		case 11:
			l_1_IconColor11 = value;
			break;
		case 12:
			l_1_IconColor12 = value;
			break;
		case 13:
			l_1_IconColor13 = value;
			break;
		case 14:
			l_1_IconColor14 = value;
			break;
		case 15:
			l_1_IconColor15 = value;
			break;
		case 16:
			l_1_IconColor16 = value;
			break;
		case 17:
			l_1_IconColor17 = value;
			break;
		case 18:
			l_1_IconColor18 = value;
			break;
		case 19:
			l_1_IconColor19 = value;
			break;
		case 20:
			l_1_IconColor20 = value;
			break;
		case 21:
			l_1_IconColor21 = value;
			break;
		case 22:
			l_1_IconColor22 = value;
			break;
		case 23:
			l_1_IconColor23 = value;
			break;
		case 24:
			l_1_IconColor24 = value;
			break;
		case 25:
			l_1_IconColor25 = value;
			break;
		case 26:
			l_1_IconColor26 = value;
			break;
		case 27:
			l_1_IconColor27 = value;
			break;
		case 28:
			l_1_IconColor28 = value;
			break;
		case 29:
			l_1_IconColor29 = value;
			break;
		case 30:
			l_1_IconColor30 = value;
			break;
		case 31:
			l_1_IconColor31 = value;
			break;
		case 32:
			l_1_IconColor32 = value;
			break;
		case 33:
			l_1_IconColor33 = value;
			break;
		case 34:
			l_1_IconColor34 = value;
			break;
		case 35:
			l_1_IconColor35 = value;
			break;
		case 36:
			l_1_IconColor36 = value;
			break;
		case 37:
			l_1_IconColor37 = value;
			break;
		case 38:
			l_1_IconColor38 = value;
			break;
		case 39:
			l_1_IconColor39 = value;
			break;
		case 40:
			l_1_IconColor40 = value;
			break;
		}
	}

	public string Getl_1_nameString(int index)
	{
		return index switch
		{
			1 => l_1_nameString1, 
			2 => l_1_nameString2, 
			3 => l_1_nameString3, 
			4 => l_1_nameString4, 
			5 => l_1_nameString5, 
			6 => l_1_nameString6, 
			7 => l_1_nameString7, 
			8 => l_1_nameString8, 
			9 => l_1_nameString9, 
			10 => l_1_nameString10, 
			11 => l_1_nameString11, 
			12 => l_1_nameString12, 
			13 => l_1_nameString13, 
			14 => l_1_nameString14, 
			15 => l_1_nameString15, 
			16 => l_1_nameString16, 
			17 => l_1_nameString17, 
			18 => l_1_nameString18, 
			19 => l_1_nameString19, 
			20 => l_1_nameString20, 
			21 => l_1_nameString21, 
			22 => l_1_nameString22, 
			23 => l_1_nameString23, 
			24 => l_1_nameString24, 
			25 => l_1_nameString25, 
			26 => l_1_nameString26, 
			27 => l_1_nameString27, 
			28 => l_1_nameString28, 
			29 => l_1_nameString29, 
			30 => l_1_nameString30, 
			31 => l_1_nameString31, 
			32 => l_1_nameString32, 
			33 => l_1_nameString33, 
			34 => l_1_nameString34, 
			35 => l_1_nameString35, 
			36 => l_1_nameString36, 
			37 => l_1_nameString37, 
			38 => l_1_nameString38, 
			39 => l_1_nameString39, 
			40 => l_1_nameString40, 
			_ => null, 
		};
	}

	public void Setl_1_nameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			l_1_nameString1 = value;
			break;
		case 2:
			l_1_nameString2 = value;
			break;
		case 3:
			l_1_nameString3 = value;
			break;
		case 4:
			l_1_nameString4 = value;
			break;
		case 5:
			l_1_nameString5 = value;
			break;
		case 6:
			l_1_nameString6 = value;
			break;
		case 7:
			l_1_nameString7 = value;
			break;
		case 8:
			l_1_nameString8 = value;
			break;
		case 9:
			l_1_nameString9 = value;
			break;
		case 10:
			l_1_nameString10 = value;
			break;
		case 11:
			l_1_nameString11 = value;
			break;
		case 12:
			l_1_nameString12 = value;
			break;
		case 13:
			l_1_nameString13 = value;
			break;
		case 14:
			l_1_nameString14 = value;
			break;
		case 15:
			l_1_nameString15 = value;
			break;
		case 16:
			l_1_nameString16 = value;
			break;
		case 17:
			l_1_nameString17 = value;
			break;
		case 18:
			l_1_nameString18 = value;
			break;
		case 19:
			l_1_nameString19 = value;
			break;
		case 20:
			l_1_nameString20 = value;
			break;
		case 21:
			l_1_nameString21 = value;
			break;
		case 22:
			l_1_nameString22 = value;
			break;
		case 23:
			l_1_nameString23 = value;
			break;
		case 24:
			l_1_nameString24 = value;
			break;
		case 25:
			l_1_nameString25 = value;
			break;
		case 26:
			l_1_nameString26 = value;
			break;
		case 27:
			l_1_nameString27 = value;
			break;
		case 28:
			l_1_nameString28 = value;
			break;
		case 29:
			l_1_nameString29 = value;
			break;
		case 30:
			l_1_nameString30 = value;
			break;
		case 31:
			l_1_nameString31 = value;
			break;
		case 32:
			l_1_nameString32 = value;
			break;
		case 33:
			l_1_nameString33 = value;
			break;
		case 34:
			l_1_nameString34 = value;
			break;
		case 35:
			l_1_nameString35 = value;
			break;
		case 36:
			l_1_nameString36 = value;
			break;
		case 37:
			l_1_nameString37 = value;
			break;
		case 38:
			l_1_nameString38 = value;
			break;
		case 39:
			l_1_nameString39 = value;
			break;
		case 40:
			l_1_nameString40 = value;
			break;
		}
	}

	public int Getl_1_nameCount()
	{
		return 40;
	}

	public string Getl_1_moneyString(int index)
	{
		return index switch
		{
			1 => l_1_moneyString1, 
			2 => l_1_moneyString2, 
			3 => l_1_moneyString3, 
			4 => l_1_moneyString4, 
			5 => l_1_moneyString5, 
			6 => l_1_moneyString6, 
			7 => l_1_moneyString7, 
			8 => l_1_moneyString8, 
			9 => l_1_moneyString9, 
			10 => l_1_moneyString10, 
			11 => l_1_moneyString11, 
			12 => l_1_moneyString12, 
			13 => l_1_moneyString13, 
			14 => l_1_moneyString14, 
			15 => l_1_moneyString15, 
			16 => l_1_moneyString16, 
			17 => l_1_moneyString17, 
			18 => l_1_moneyString18, 
			19 => l_1_moneyString19, 
			20 => l_1_moneyString20, 
			21 => l_1_moneyString21, 
			22 => l_1_moneyString22, 
			23 => l_1_moneyString23, 
			24 => l_1_moneyString24, 
			25 => l_1_moneyString25, 
			26 => l_1_moneyString26, 
			27 => l_1_moneyString27, 
			28 => l_1_moneyString28, 
			29 => l_1_moneyString29, 
			30 => l_1_moneyString30, 
			31 => l_1_moneyString31, 
			32 => l_1_moneyString32, 
			33 => l_1_moneyString33, 
			34 => l_1_moneyString34, 
			35 => l_1_moneyString35, 
			36 => l_1_moneyString36, 
			37 => l_1_moneyString37, 
			38 => l_1_moneyString38, 
			39 => l_1_moneyString39, 
			40 => l_1_moneyString40, 
			_ => null, 
		};
	}

	public void Setl_1_moneyString(int index, string value)
	{
		switch (index)
		{
		case 1:
			l_1_moneyString1 = value;
			break;
		case 2:
			l_1_moneyString2 = value;
			break;
		case 3:
			l_1_moneyString3 = value;
			break;
		case 4:
			l_1_moneyString4 = value;
			break;
		case 5:
			l_1_moneyString5 = value;
			break;
		case 6:
			l_1_moneyString6 = value;
			break;
		case 7:
			l_1_moneyString7 = value;
			break;
		case 8:
			l_1_moneyString8 = value;
			break;
		case 9:
			l_1_moneyString9 = value;
			break;
		case 10:
			l_1_moneyString10 = value;
			break;
		case 11:
			l_1_moneyString11 = value;
			break;
		case 12:
			l_1_moneyString12 = value;
			break;
		case 13:
			l_1_moneyString13 = value;
			break;
		case 14:
			l_1_moneyString14 = value;
			break;
		case 15:
			l_1_moneyString15 = value;
			break;
		case 16:
			l_1_moneyString16 = value;
			break;
		case 17:
			l_1_moneyString17 = value;
			break;
		case 18:
			l_1_moneyString18 = value;
			break;
		case 19:
			l_1_moneyString19 = value;
			break;
		case 20:
			l_1_moneyString20 = value;
			break;
		case 21:
			l_1_moneyString21 = value;
			break;
		case 22:
			l_1_moneyString22 = value;
			break;
		case 23:
			l_1_moneyString23 = value;
			break;
		case 24:
			l_1_moneyString24 = value;
			break;
		case 25:
			l_1_moneyString25 = value;
			break;
		case 26:
			l_1_moneyString26 = value;
			break;
		case 27:
			l_1_moneyString27 = value;
			break;
		case 28:
			l_1_moneyString28 = value;
			break;
		case 29:
			l_1_moneyString29 = value;
			break;
		case 30:
			l_1_moneyString30 = value;
			break;
		case 31:
			l_1_moneyString31 = value;
			break;
		case 32:
			l_1_moneyString32 = value;
			break;
		case 33:
			l_1_moneyString33 = value;
			break;
		case 34:
			l_1_moneyString34 = value;
			break;
		case 35:
			l_1_moneyString35 = value;
			break;
		case 36:
			l_1_moneyString36 = value;
			break;
		case 37:
			l_1_moneyString37 = value;
			break;
		case 38:
			l_1_moneyString38 = value;
			break;
		case 39:
			l_1_moneyString39 = value;
			break;
		case 40:
			l_1_moneyString40 = value;
			break;
		}
	}

	public int Getl_1_moneyCount()
	{
		return 40;
	}

	public bool Getl_1_lockShow(int index)
	{
		return index switch
		{
			1 => l_1_lockShow1, 
			2 => l_1_lockShow2, 
			3 => l_1_lockShow3, 
			4 => l_1_lockShow4, 
			5 => l_1_lockShow5, 
			6 => l_1_lockShow6, 
			7 => l_1_lockShow7, 
			8 => l_1_lockShow8, 
			9 => l_1_lockShow9, 
			10 => l_1_lockShow10, 
			11 => l_1_lockShow11, 
			12 => l_1_lockShow12, 
			13 => l_1_lockShow13, 
			14 => l_1_lockShow14, 
			15 => l_1_lockShow15, 
			16 => l_1_lockShow16, 
			17 => l_1_lockShow17, 
			18 => l_1_lockShow18, 
			19 => l_1_lockShow19, 
			20 => l_1_lockShow20, 
			21 => l_1_lockShow21, 
			22 => l_1_lockShow22, 
			23 => l_1_lockShow23, 
			24 => l_1_lockShow24, 
			25 => l_1_lockShow25, 
			26 => l_1_lockShow26, 
			27 => l_1_lockShow27, 
			28 => l_1_lockShow28, 
			29 => l_1_lockShow29, 
			30 => l_1_lockShow30, 
			31 => l_1_lockShow31, 
			32 => l_1_lockShow32, 
			33 => l_1_lockShow33, 
			34 => l_1_lockShow34, 
			35 => l_1_lockShow35, 
			36 => l_1_lockShow36, 
			37 => l_1_lockShow37, 
			38 => l_1_lockShow38, 
			39 => l_1_lockShow39, 
			40 => l_1_lockShow40, 
			_ => false, 
		};
	}

	public void Setl_1_lockShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			l_1_lockShow1 = value;
			break;
		case 2:
			l_1_lockShow2 = value;
			break;
		case 3:
			l_1_lockShow3 = value;
			break;
		case 4:
			l_1_lockShow4 = value;
			break;
		case 5:
			l_1_lockShow5 = value;
			break;
		case 6:
			l_1_lockShow6 = value;
			break;
		case 7:
			l_1_lockShow7 = value;
			break;
		case 8:
			l_1_lockShow8 = value;
			break;
		case 9:
			l_1_lockShow9 = value;
			break;
		case 10:
			l_1_lockShow10 = value;
			break;
		case 11:
			l_1_lockShow11 = value;
			break;
		case 12:
			l_1_lockShow12 = value;
			break;
		case 13:
			l_1_lockShow13 = value;
			break;
		case 14:
			l_1_lockShow14 = value;
			break;
		case 15:
			l_1_lockShow15 = value;
			break;
		case 16:
			l_1_lockShow16 = value;
			break;
		case 17:
			l_1_lockShow17 = value;
			break;
		case 18:
			l_1_lockShow18 = value;
			break;
		case 19:
			l_1_lockShow19 = value;
			break;
		case 20:
			l_1_lockShow20 = value;
			break;
		case 21:
			l_1_lockShow21 = value;
			break;
		case 22:
			l_1_lockShow22 = value;
			break;
		case 23:
			l_1_lockShow23 = value;
			break;
		case 24:
			l_1_lockShow24 = value;
			break;
		case 25:
			l_1_lockShow25 = value;
			break;
		case 26:
			l_1_lockShow26 = value;
			break;
		case 27:
			l_1_lockShow27 = value;
			break;
		case 28:
			l_1_lockShow28 = value;
			break;
		case 29:
			l_1_lockShow29 = value;
			break;
		case 30:
			l_1_lockShow30 = value;
			break;
		case 31:
			l_1_lockShow31 = value;
			break;
		case 32:
			l_1_lockShow32 = value;
			break;
		case 33:
			l_1_lockShow33 = value;
			break;
		case 34:
			l_1_lockShow34 = value;
			break;
		case 35:
			l_1_lockShow35 = value;
			break;
		case 36:
			l_1_lockShow36 = value;
			break;
		case 37:
			l_1_lockShow37 = value;
			break;
		case 38:
			l_1_lockShow38 = value;
			break;
		case 39:
			l_1_lockShow39 = value;
			break;
		case 40:
			l_1_lockShow40 = value;
			break;
		}
	}

	public int Getl_1_lockCount()
	{
		return 40;
	}

	public string Getl_1_lock_lvString(int index)
	{
		return index switch
		{
			1 => l_1_lock_lvString1, 
			2 => l_1_lock_lvString2, 
			3 => l_1_lock_lvString3, 
			4 => l_1_lock_lvString4, 
			5 => l_1_lock_lvString5, 
			6 => l_1_lock_lvString6, 
			7 => l_1_lock_lvString7, 
			8 => l_1_lock_lvString8, 
			9 => l_1_lock_lvString9, 
			10 => l_1_lock_lvString10, 
			11 => l_1_lock_lvString11, 
			12 => l_1_lock_lvString12, 
			13 => l_1_lock_lvString13, 
			14 => l_1_lock_lvString14, 
			15 => l_1_lock_lvString15, 
			16 => l_1_lock_lvString16, 
			17 => l_1_lock_lvString17, 
			18 => l_1_lock_lvString18, 
			19 => l_1_lock_lvString19, 
			20 => l_1_lock_lvString20, 
			21 => l_1_lock_lvString21, 
			22 => l_1_lock_lvString22, 
			23 => l_1_lock_lvString23, 
			24 => l_1_lock_lvString24, 
			25 => l_1_lock_lvString25, 
			26 => l_1_lock_lvString26, 
			27 => l_1_lock_lvString27, 
			28 => l_1_lock_lvString28, 
			29 => l_1_lock_lvString29, 
			30 => l_1_lock_lvString30, 
			31 => l_1_lock_lvString31, 
			32 => l_1_lock_lvString32, 
			33 => l_1_lock_lvString33, 
			34 => l_1_lock_lvString34, 
			35 => l_1_lock_lvString35, 
			36 => l_1_lock_lvString36, 
			37 => l_1_lock_lvString37, 
			38 => l_1_lock_lvString38, 
			39 => l_1_lock_lvString39, 
			40 => l_1_lock_lvString40, 
			_ => null, 
		};
	}

	public void Setl_1_lock_lvString(int index, string value)
	{
		switch (index)
		{
		case 1:
			l_1_lock_lvString1 = value;
			break;
		case 2:
			l_1_lock_lvString2 = value;
			break;
		case 3:
			l_1_lock_lvString3 = value;
			break;
		case 4:
			l_1_lock_lvString4 = value;
			break;
		case 5:
			l_1_lock_lvString5 = value;
			break;
		case 6:
			l_1_lock_lvString6 = value;
			break;
		case 7:
			l_1_lock_lvString7 = value;
			break;
		case 8:
			l_1_lock_lvString8 = value;
			break;
		case 9:
			l_1_lock_lvString9 = value;
			break;
		case 10:
			l_1_lock_lvString10 = value;
			break;
		case 11:
			l_1_lock_lvString11 = value;
			break;
		case 12:
			l_1_lock_lvString12 = value;
			break;
		case 13:
			l_1_lock_lvString13 = value;
			break;
		case 14:
			l_1_lock_lvString14 = value;
			break;
		case 15:
			l_1_lock_lvString15 = value;
			break;
		case 16:
			l_1_lock_lvString16 = value;
			break;
		case 17:
			l_1_lock_lvString17 = value;
			break;
		case 18:
			l_1_lock_lvString18 = value;
			break;
		case 19:
			l_1_lock_lvString19 = value;
			break;
		case 20:
			l_1_lock_lvString20 = value;
			break;
		case 21:
			l_1_lock_lvString21 = value;
			break;
		case 22:
			l_1_lock_lvString22 = value;
			break;
		case 23:
			l_1_lock_lvString23 = value;
			break;
		case 24:
			l_1_lock_lvString24 = value;
			break;
		case 25:
			l_1_lock_lvString25 = value;
			break;
		case 26:
			l_1_lock_lvString26 = value;
			break;
		case 27:
			l_1_lock_lvString27 = value;
			break;
		case 28:
			l_1_lock_lvString28 = value;
			break;
		case 29:
			l_1_lock_lvString29 = value;
			break;
		case 30:
			l_1_lock_lvString30 = value;
			break;
		case 31:
			l_1_lock_lvString31 = value;
			break;
		case 32:
			l_1_lock_lvString32 = value;
			break;
		case 33:
			l_1_lock_lvString33 = value;
			break;
		case 34:
			l_1_lock_lvString34 = value;
			break;
		case 35:
			l_1_lock_lvString35 = value;
			break;
		case 36:
			l_1_lock_lvString36 = value;
			break;
		case 37:
			l_1_lock_lvString37 = value;
			break;
		case 38:
			l_1_lock_lvString38 = value;
			break;
		case 39:
			l_1_lock_lvString39 = value;
			break;
		case 40:
			l_1_lock_lvString40 = value;
			break;
		}
	}

	public int Getl_1_lock_lvCount()
	{
		return 40;
	}

	public bool Getr_weaponShow(int index)
	{
		return index switch
		{
			1 => r_weaponShow1, 
			2 => r_weaponShow2, 
			3 => r_weaponShow3, 
			4 => r_weaponShow4, 
			5 => r_weaponShow5, 
			_ => false, 
		};
	}

	public void Setr_weaponShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			r_weaponShow1 = value;
			break;
		case 2:
			r_weaponShow2 = value;
			break;
		case 3:
			r_weaponShow3 = value;
			break;
		case 4:
			r_weaponShow4 = value;
			break;
		case 5:
			r_weaponShow5 = value;
			break;
		}
	}

	public int Getr_weaponCount()
	{
		return 5;
	}

	public Button.ButtonClickedEvent Getr_weaponClicked(int index)
	{
		return index switch
		{
			1 => r_weaponClicked1, 
			2 => r_weaponClicked2, 
			3 => r_weaponClicked3, 
			4 => r_weaponClicked4, 
			5 => r_weaponClicked5, 
			_ => null, 
		};
	}

	public void Setr_weaponClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			r_weaponClicked1 = value;
			break;
		case 2:
			r_weaponClicked2 = value;
			break;
		case 3:
			r_weaponClicked3 = value;
			break;
		case 4:
			r_weaponClicked4 = value;
			break;
		case 5:
			r_weaponClicked5 = value;
			break;
		}
	}

	public Sprite Getr_weaponIconSprite(int index)
	{
		return index switch
		{
			1 => r_weaponIconSprite1, 
			2 => r_weaponIconSprite2, 
			3 => r_weaponIconSprite3, 
			4 => r_weaponIconSprite4, 
			5 => r_weaponIconSprite5, 
			_ => null, 
		};
	}

	public void Setr_weaponIconSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			r_weaponIconSprite1 = value;
			break;
		case 2:
			r_weaponIconSprite2 = value;
			break;
		case 3:
			r_weaponIconSprite3 = value;
			break;
		case 4:
			r_weaponIconSprite4 = value;
			break;
		case 5:
			r_weaponIconSprite5 = value;
			break;
		}
	}

	public int Getr_weaponIconCount()
	{
		return 5;
	}

	public Color Getr_weaponIconColor(int index)
	{
		return index switch
		{
			1 => r_weaponIconColor1, 
			2 => r_weaponIconColor2, 
			3 => r_weaponIconColor3, 
			4 => r_weaponIconColor4, 
			5 => r_weaponIconColor5, 
			_ => Color.white, 
		};
	}

	public void Setr_weaponIconColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			r_weaponIconColor1 = value;
			break;
		case 2:
			r_weaponIconColor2 = value;
			break;
		case 3:
			r_weaponIconColor3 = value;
			break;
		case 4:
			r_weaponIconColor4 = value;
			break;
		case 5:
			r_weaponIconColor5 = value;
			break;
		}
	}

	public string Getr_nameString(int index)
	{
		return index switch
		{
			1 => r_nameString1, 
			2 => r_nameString2, 
			3 => r_nameString3, 
			4 => r_nameString4, 
			5 => r_nameString5, 
			_ => null, 
		};
	}

	public void Setr_nameString(int index, string value)
	{
		switch (index)
		{
		case 1:
			r_nameString1 = value;
			break;
		case 2:
			r_nameString2 = value;
			break;
		case 3:
			r_nameString3 = value;
			break;
		case 4:
			r_nameString4 = value;
			break;
		case 5:
			r_nameString5 = value;
			break;
		}
	}

	public int Getr_nameCount()
	{
		return 5;
	}

	public Toggle.ToggleEvent GetweaponToolTogglechanged(int index)
	{
		return index switch
		{
			1 => weaponToolTogglechanged1, 
			2 => weaponToolTogglechanged2, 
			3 => weaponToolTogglechanged3, 
			4 => weaponToolTogglechanged4, 
			_ => null, 
		};
	}

	public void SetweaponToolTogglechanged(int index, Toggle.ToggleEvent value)
	{
		switch (index)
		{
		case 1:
			weaponToolTogglechanged1 = value;
			break;
		case 2:
			weaponToolTogglechanged2 = value;
			break;
		case 3:
			weaponToolTogglechanged3 = value;
			break;
		case 4:
			weaponToolTogglechanged4 = value;
			break;
		}
	}

	public int GetweaponToolCount()
	{
		return 4;
	}

	public bool GetweaponToolOn(int index)
	{
		return index switch
		{
			1 => weaponToolOn1, 
			2 => weaponToolOn2, 
			3 => weaponToolOn3, 
			4 => weaponToolOn4, 
			_ => false, 
		};
	}

	public void SetweaponToolOn(int index, bool value)
	{
		switch (index)
		{
		case 1:
			weaponToolOn1 = value;
			break;
		case 2:
			weaponToolOn2 = value;
			break;
		case 3:
			weaponToolOn3 = value;
			break;
		case 4:
			weaponToolOn4 = value;
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
}
