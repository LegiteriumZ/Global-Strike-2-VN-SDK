using Assets.Sources.Components.Message.Common;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class HitMarkDamageModel : AbstractModel, IPlaybackSystem, ISetMessageContext, ISetWeaponContext
{
	private HitMarkDamageViewModel _viewModel;

	private Vector3 _originPos;

	private ActiveChip _showActiveChip = new ActiveChip();

	private MessageContext _messageContext;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new HitMarkDamageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		_originPos = _viewModel.ShowPosition;
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetChanged, SetChanged, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetHasSkill, SetHasSkill, null, initinvoke: true);
	}

	private void SetHasSkill(bool arg1, bool arg2)
	{
		_viewModel.ShowPosition = (arg2 ? _originPos : (_originPos + new Vector3(210f, 0f)));
	}

	private bool GetHasSkill()
	{
		if (_weaponContext.isCurrentWeapon)
		{
			return (_weaponContext.currentWeaponEntity.basicInfo.Data.EffectLevel & 8) > 0;
		}
		return false;
	}

	private void SetChanged(bool arg1, bool arg2)
	{
		if (arg2)
		{
			HitMarkComponent hitMark = _messageContext.hitMark;
			hitMark.Changed = false;
			_viewModel.DamageNumString = hitMark.Damage.ToString();
			for (int i = 0; i < 17; i++)
			{
				_viewModel.SetPartShow(i + 1, (hitMark.HitMark & (1 << i)) > 0);
			}
			_showActiveChip.Time = 1500;
		}
	}

	private bool GetChanged()
	{
		return _messageContext.hitMark.Changed;
	}

	private void InitChips()
	{
		_showActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ShowShow = _showActiveChip.Update(_timeComponent);
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}
