using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical;

public class BiochemicalNewVariantsGrowUpModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private BiochemicalnewvariantsgrowupViewModel _viewModel = new BiochemicalnewvariantsgrowupViewModel();

	private int _lastLv;

	private int _currentLv;

	private int _lastLvUpHp;

	private int _currentLvUpHp;

	private int _effectTime = 3000;

	private bool _isLvUpDead;

	private bool _checkRaceType;

	private bool _isDoun;

	private bool _isDead;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiRoomData_RaceType, SetRaceType, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiMyPlayer_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsDead, SetIsDead, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_bioNewVariantsGrowUp_Lv, SetLv, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetLastLv, SetLastLv, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetLastLvUpHp, SetLastLvUpHp, null, initinvoke: true);
	}

	private void SetLastLvUpHp(int arg1, int arg2)
	{
		_viewModel.HpTextString = _lastLvUpHp.ToString();
	}

	private int GetLastLvUpHp()
	{
		return _lastLvUpHp;
	}

	private void SetLastLv(int arg1, int arg2)
	{
		_viewModel.LvTextString = _lastLv.ToString();
	}

	private int GetLastLv()
	{
		return _lastLv;
	}

	private void SetRaceType(int ov, int raceType)
	{
		_checkRaceType = _gameRuleContext.currentRule.Rule.IsNewVariantsGrowUp();
		CheckVisible();
	}

	private void SetCareer(string ov, string career)
	{
		_isDoun = PlayerCareerConstantUtility.IsDoun(career);
		CheckVisible();
	}

	private void SetIsDead(bool ov, bool isDead)
	{
		_isDead = isDead;
		CheckVisible();
	}

	private void CheckVisible()
	{
		_viewModel.CenterShow = _checkRaceType && _isDoun && !_isDead;
		if (!_viewModel.CenterShow && !_isDoun)
		{
			_viewModel.HpProgressImageFillamount = 0f;
			_viewModel.LvTextString = "0";
			_viewModel.HpTextString = "0";
			_lastLv = 0;
			_currentLv = 0;
			_lastLvUpHp = 0;
			_currentLvUpHp = 0;
			_effectTime = 3000;
			_isLvUpDead = false;
		}
	}

	private void SetLv(int ov, int lv)
	{
		if (_currentLv != lv)
		{
			_lastLv = _currentLv;
			_currentLv = lv;
			_lastLvUpHp = _currentLvUpHp;
			_currentLvUpHp = UiIEventCondition.Get_bioNewVariantsGrowUp_LvUpHp();
			if (lv > 0)
			{
				_effectTime = 0;
				_viewModel.EffectBackImageAlpha = 1f;
				_viewModel.EffectImageAlpha = 1f;
				_viewModel.EffectImageScale = Vector3.one;
				_viewModel.EffectBackImageShow = true;
				_viewModel.EffectImageShow = true;
			}
			else
			{
				_effectTime = 3000;
				_viewModel.EffectBackImageShow = false;
				_viewModel.EffectImageShow = false;
			}
		}
	}

	public void OnPlayback()
	{
		if (!_viewModel.CenterShow || !_viewModel.EffectImageShow)
		{
			return;
		}
		_effectTime += _timeComponent.FrameInterval;
		if (UiIEventCondition.Get_bioNewVariantsGrowUp_IsLvUpDead() != _isLvUpDead)
		{
			_isLvUpDead = UiIEventCondition.Get_bioNewVariantsGrowUp_IsLvUpDead();
			if (_isLvUpDead)
			{
				_viewModel.EffectImageSprite = base.Loader.RetriveSprite("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/newvariantsgrowup/dead.png", delegate(Sprite sprite)
				{
					_viewModel.EffectImageSprite = sprite;
				});
			}
			else
			{
				_viewModel.EffectImageSprite = base.Loader.RetriveSprite("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/newvariantsgrowup/kill.png", delegate(Sprite sprite)
				{
					_viewModel.EffectImageSprite = sprite;
				});
			}
		}
		if (_effectTime < 200)
		{
			_viewModel.EffectImageScale = Vector3.one * (1f - 0.33333f * (float)_effectTime / 200f);
		}
		else
		{
			_viewModel.EffectImageScale = Vector3.one * 0.66666996f;
		}
		if (_effectTime < 1000)
		{
			_viewModel.EffectImageAlpha = 1f;
		}
		else if (_effectTime >= 1000 && _effectTime <= 1500)
		{
			_viewModel.EffectImageAlpha = 1f - ((float)_effectTime - 1000f) / 500f;
		}
		else
		{
			_viewModel.EffectImageAlpha = 0f;
		}
		if (_effectTime >= 1000 && _effectTime <= 1500)
		{
			_viewModel.HpProgressImageFillamount = ((float)_lastLv + ((float)_effectTime - 1000f) / 500f) / 10f;
		}
		else if (_lastLv == _currentLv)
		{
			_viewModel.HpProgressImageFillamount = (float)_currentLv / 10f;
		}
		_viewModel.EffectBackImageShow = true;
		if (_effectTime < 1600)
		{
			_viewModel.EffectBackImageAlpha = 1f;
		}
		else if (_effectTime >= 1600 && _effectTime <= 1800)
		{
			_viewModel.EffectBackImageAlpha = 1f - ((float)_effectTime - 1600f) / 200f;
		}
		else
		{
			_viewModel.EffectBackImageAlpha = 0f;
		}
		if (_effectTime > 1800)
		{
			_lastLv = UiIEventCondition.Get_bioNewVariantsGrowUp_Lv();
			_lastLvUpHp = UiIEventCondition.Get_bioNewVariantsGrowUp_LvUpHp();
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
