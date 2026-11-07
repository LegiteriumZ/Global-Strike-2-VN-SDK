using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Pve;

public class EnergydevicetowardModel : AbstractModel, IPlaybackSystem, ISetMessageContext
{
	private EnergydevicetowardViewModel _viewModel;

	private float EFFECT_SPEED = 500f;

	private int _effectTine;

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new EnergydevicetowardViewModel();
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
		base.DoSubscribe();
		_viewModel.energydevicetowardShow = false;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveUIMessage_Distance, EnergyDistanceUpdate, _viewModel.energydevicetowardObj);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveUIMessage_Visiable, EnergyVisible, _viewModel.energydevicetowardObj);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveUIMessage_Rotation, EnergyRotationUpdate, _viewModel.energydevicetowardObj);
		base.Loader.RetriveSprite("ui/titanlaboratorymodel", "Assets/Res/Assets/ui/GameGUIRes/titanlaboratoryModel/energydevicehint/energydevicehint.png", delegate(Sprite sprite)
		{
			_viewModel.energyDeviceHintImageSprite = sprite;
		});
		base.Loader.RetriveSprite("ui/titanlaboratorymodel", "Assets/Res/Assets/ui/GameGUIRes/titanlaboratoryModel/energydevicehint/energydeviceicon.png", delegate(Sprite sprite)
		{
			_viewModel.energyDeviceIconImageSprite = sprite;
		});
		base.Loader.RetriveSprite("ui/titanlaboratorymodel", "Assets/Res/Assets/ui/GameGUIRes/titanlaboratoryModel/energydevicehint/energydevicetoward.png", delegate(Sprite sprite)
		{
			_viewModel.energyDeviceTowardImageSprite = sprite;
		});
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		NotifyManager.Remove(_viewModel.energydevicetowardObj);
	}

	private void EnergyVisible(bool old, bool newval)
	{
		_viewModel.energydevicetowardShow = newval;
	}

	private void EnergyDistanceUpdate(int old, int val)
	{
		if (_messageContext.pveUIMessage.Visiable)
		{
			_viewModel.energyDeviceDistancetxtString = val.ToString();
		}
	}

	private void EnergyRotationUpdate(float old, float angle)
	{
		if (_messageContext.pveUIMessage.Visiable)
		{
			_viewModel.towardRotation = Quaternion.Euler(0f, 0f, 180f - angle);
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		if ((float)_effectTine < EFFECT_SPEED)
		{
			Color energyDeviceIconImageColor = _viewModel.energyDeviceIconImageColor;
			energyDeviceIconImageColor.a = (float)_effectTine / EFFECT_SPEED * 0.7f + 0.3f;
			_viewModel.energyDeviceIconImageColor = energyDeviceIconImageColor;
		}
		else if ((float)_effectTine < 2f * EFFECT_SPEED)
		{
			Color energyDeviceIconImageColor2 = _viewModel.energyDeviceIconImageColor;
			energyDeviceIconImageColor2.a = (2f * EFFECT_SPEED - (float)_effectTine) / EFFECT_SPEED * 0.7f + 0.3f;
			_viewModel.energyDeviceIconImageColor = energyDeviceIconImageColor2;
		}
		else
		{
			_effectTine = 0;
		}
		_effectTine += _timeComponent.FrameInterval;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
