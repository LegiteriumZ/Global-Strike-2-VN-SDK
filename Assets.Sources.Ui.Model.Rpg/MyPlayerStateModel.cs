using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class MyPlayerStateModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private RpgPlayerStateViewModel _viewModel;

	private PlayerEntity MyPlayerEntity;

	private string _currCarrer;

	private PingPongChip _hpWarnningPingPongChip = new PingPongChip();

	private PingPongChip _mpWarnningPingPongChip = new PingPongChip();

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgPlayerStateViewModel();
		_viewModel.PlayerTitleShow = false;
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			UpdateWarnning();
		}
	}

	private void UpdateWarnning()
	{
		if (_viewModel.HpWarnningShow)
		{
			_viewModel.HpWarnningAlpha = _hpWarnningPingPongChip.Update(_timeComponent);
		}
		if (_viewModel.MpWarnningShow)
		{
			_viewModel.MpWarnningAlpha = _mpWarnningPingPongChip.Update(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		MyPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(Get_cameraOwnerData_Hp, UpdateHp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(Get_cameraOwnerData_MaxHp, UpdateHp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(Get_cameraOwnerData_ShieldHp, UpdateMp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(Get_cameraOwnerData_ShieldMaxHp, UpdateMp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(Get_cameraOwnerData_SuperShieldHp, UpdateMp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(Get_cameraOwnerData_SuperShieldMaxHp, UpdateMp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(Get_cameraOwnerData_Career, UpdateCareer, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(Get_cameraOwnerData_SkinName, UpdateCareer, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(Get_cameraOwnerData_TitleId, Settitle, null, initinvoke: true, isFrameSeparation: true);
	}

	private void Settitle(float arg1, float arg2)
	{
		if (!Mathf.Approximately(arg2, 0f))
		{
			_viewModel.PlayerTitleShow = true;
			base.Loader.RetriveSprite("ui/halfLoadedRes/playerHononary", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerHononary/{arg2}.png", delegate(Sprite sprite)
			{
				_viewModel.PlayerTitleSprite = sprite;
			});
		}
	}

	private void UpdateCareer(string ov, string nv)
	{
		string cameraOwnerData_SkinName = Get_cameraOwnerData_SkinName();
		string career = Get_cameraOwnerData_Career();
		if (string.IsNullOrEmpty(cameraOwnerData_SkinName) && string.IsNullOrEmpty(career))
		{
			return;
		}
		career = (_currCarrer = ((!string.IsNullOrEmpty(cameraOwnerData_SkinName)) ? cameraOwnerData_SkinName : career));
		string bundleName = (_gameRuleContext.currentRule.Rule.IsRpg() ? "ui/halfloadedres/pveplayerstate" : "ui/halfloadedres/pvpplayerstate");
		_viewModel.PlayerCareerSprite = base.Loader.RetriveSprite(bundleName, string.Format("Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/{1}/{0}.png", ConvertHeadIcon(), _gameRuleContext.currentRule.Rule.IsRpg() ? "pveplayerstate" : "pvpplayerstate"), delegate(Sprite sprite)
		{
			if (_currCarrer == career)
			{
				_viewModel.PlayerCareerSprite = sprite;
				_viewModel.PlayerCareerNtvsize();
			}
		});
	}

	private string ConvertHeadIcon()
	{
		switch (_currCarrer)
		{
		case "rpg_10004108":
		case "rpg_10004109":
		case "rpg_10004110":
			return "rpg_default_career";
		default:
			return _currCarrer;
		}
	}

	private void UpdateHp(long ov, long value)
	{
		long cameraOwnerData_Hp = Get_cameraOwnerData_Hp();
		long cameraOwnerData_MaxHp = Get_cameraOwnerData_MaxHp();
		if (cameraOwnerData_MaxHp > 0)
		{
			float num = (float)cameraOwnerData_Hp / (float)cameraOwnerData_MaxHp;
			_viewModel.HpProgressBarFillamount = num;
			_viewModel.HpWarnningShow = num < 0.5f;
		}
		bool[] shows = new bool[4];
		ConvertLargeNummber(cameraOwnerData_Hp, ref shows, out var wholeStr, out var decimalStr);
		LargeNumberPosition(shows[0], cameraOwnerData_Hp >= 10000, wholeStr, decimalStr, out var positions, new Vector2(0f, -22f));
		_viewModel.SetHpCountShowLargenumber(shows);
		_viewModel.SetHpCountPosiLargenumber(positions);
		_viewModel.SetHpCountTextLargenumber(wholeStr, decimalStr);
	}

	private void UpdateMp(long ov, long value)
	{
		long cameraOwnerData_ShieldHp = Get_cameraOwnerData_ShieldHp();
		long cameraOwnerData_ShieldMaxHp = Get_cameraOwnerData_ShieldMaxHp();
		_viewModel.MpProgressBarFillamount = (float)((cameraOwnerData_ShieldMaxHp > 0) ? ((double)cameraOwnerData_ShieldHp / (double)cameraOwnerData_ShieldMaxHp) : 0.0);
		_viewModel.MpWarnningShow = _viewModel.MpProgressBarFillamount < 0.5f;
		long cameraOwnerData_SuperShieldHp = Get_cameraOwnerData_SuperShieldHp();
		long cameraOwnerData_SuperShieldMaxHp = Get_cameraOwnerData_SuperShieldMaxHp();
		_viewModel.SuperMpProgressBarFillamount = (float)((cameraOwnerData_SuperShieldHp > 0) ? ((double)cameraOwnerData_SuperShieldHp / (double)cameraOwnerData_SuperShieldMaxHp) : 0.0);
		bool[] shows = new bool[4];
		ConvertLargeNummber(cameraOwnerData_SuperShieldHp + cameraOwnerData_ShieldHp, ref shows, out var wholeStr, out var decimalStr);
		LargeNumberPosition(shows[0], cameraOwnerData_SuperShieldHp + cameraOwnerData_ShieldHp >= 10000, wholeStr, decimalStr, out var positions, Vector2.zero);
		_viewModel.SetMpCountShowLargenumber(shows);
		_viewModel.SetMpCountPosiLargenumber(positions);
		_viewModel.SetMpCountTextLargenumber(wholeStr, decimalStr);
	}

	protected override void LargeNumberPosition(bool usingDot, bool usingSuffix, string wholeStr, string decimalStr, out Vector3[] positions, Vector2 offset)
	{
		float num = 3.51f;
		float num2 = (usingDot ? 199f : (usingSuffix ? 205f : 210f));
		float num3 = (usingDot ? 22f : 10f);
		int num4 = wholeStr.Length - 1;
		positions = new Vector3[5]
		{
			new Vector3(num2 + offset.x, 41f + offset.y),
			new Vector3(5.5f + (float)num4 * num, -3.5f),
			new Vector3(12f + (float)num4 * num, 0f),
			new Vector3(num3 + (float)num4 * num, 0.5f),
			new Vector3(num3 + (float)num4 * num, 0.5f)
		};
	}

	private void InitChips()
	{
		_hpWarnningPingPongChip.From = 0.2f;
		_hpWarnningPingPongChip.To = 1f;
		_hpWarnningPingPongChip.Time = 500;
		_mpWarnningPingPongChip.From = 0.2f;
		_mpWarnningPingPongChip.To = 1f;
		_mpWarnningPingPongChip.Time = 500;
	}

	private void UpdateChips()
	{
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public long Get_cameraOwnerData_Hp()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.basicInfo.Current.Hp;
		}
		return 0L;
	}

	public long Get_cameraOwnerData_MaxHp()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.basicInfo.Current.MaxHp;
		}
		return 0L;
	}

	public string Get_cameraOwnerData_Career()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.basicInfo.Current.Career;
		}
		return "";
	}

	public float Get_cameraOwnerData_TitleId()
	{
		if (MyPlayerEntity != null)
		{
			return MyPlayerEntity.basicInfo.Current.TitleId;
		}
		return 0f;
	}

	public long Get_cameraOwnerData_ShieldHp()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasBasicInfo)
		{
			return MyPlayerEntity.basicInfo.Current.ShieldHp;
		}
		return 0L;
	}

	public long Get_cameraOwnerData_ShieldMaxHp()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasBasicInfo)
		{
			return MyPlayerEntity.basicInfo.Current.ShieldMaxHp;
		}
		return 0L;
	}

	public long Get_cameraOwnerData_SuperShieldHp()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasBasicInfo)
		{
			return MyPlayerEntity.basicInfo.Current.SuperShieldHp;
		}
		return 0L;
	}

	public long Get_cameraOwnerData_SuperShieldMaxHp()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasBasicInfo)
		{
			return MyPlayerEntity.basicInfo.Current.SuperShieldMaxHp;
		}
		return 0L;
	}

	public string Get_cameraOwnerData_SkinName()
	{
		if (MyPlayerEntity != null && MyPlayerEntity.hasBasicInfo)
		{
			return MyPlayerEntity.basicInfo.SkinName;
		}
		return "";
	}
}
