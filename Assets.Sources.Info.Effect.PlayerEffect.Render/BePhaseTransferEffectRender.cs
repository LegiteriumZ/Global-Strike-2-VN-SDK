using Assets.Sources.Components.Interface;
using SSJJBase.Extensions;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class BePhaseTransferEffectRender : AbstractPlayerEffectRender
{
	private const int StartTime1 = 0;

	private const int StartTime2 = 900;

	private const int KeepTime1 = 1000;

	private const int KeepTime2 = 200;

	protected int CreateTimer;

	private Transform _bottom;

	private Transform _top;

	private Transform _center;

	private MeshRenderer _centerRender;

	private int _lastRenderTime;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_bottom = effectGameObject.transform.GetChild(0);
		_top = effectGameObject.transform.GetChild(1);
		_center = effectGameObject.transform.GetChild(2);
		_centerRender = _center.GetComponentInChildren<MeshRenderer>();
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		UpdateCreateTime(frameTime, battleRoom.GetRenderTime());
		UpdateVisible();
		UpdateOrg();
		UpdateScale();
		UpdateAlpha();
	}

	private void UpdateAlpha()
	{
		_centerRender.SetAlpha((float)(1100 - CreateTimer) / 200f * 0.7f + 0.3f);
	}

	private void UpdateScale()
	{
		float value = (float)(CreateTimer - 900) / 200f + 0.5f;
		_center.SetSsjjScaleX(value);
		_center.SetSsjjScaleY(value);
	}

	private void UpdateCreateTime(int frameTime, int renderTime)
	{
		if (renderTime > frameTime + _lastRenderTime + 1000)
		{
			CreateTimer = 0;
		}
		_lastRenderTime = renderTime;
		CreateTimer += frameTime;
	}

	private void UpdateOrg()
	{
		_bottom.SetSsjjz((float)CreateTimer * 0.11f);
		_top.SetSsjjz((float)(-CreateTimer) * 0.11f);
	}

	private void UpdateVisible()
	{
		if (CreateTimer < 0)
		{
			_bottom.gameObject.SetObjectActive(isactive: false);
			_top.gameObject.SetObjectActive(isactive: false);
		}
		else if (CreateTimer < 1000)
		{
			_bottom.gameObject.SetObjectActive(isactive: true);
			_top.gameObject.SetObjectActive(isactive: true);
		}
		else
		{
			_bottom.gameObject.SetObjectActive(isactive: false);
			_top.gameObject.SetObjectActive(isactive: false);
		}
		if (CreateTimer < 900)
		{
			_center.gameObject.SetObjectActive(isactive: false);
		}
		else if (CreateTimer < 1800)
		{
			_center.gameObject.SetObjectActive(isactive: true);
		}
		else
		{
			_center.gameObject.SetObjectActive(isactive: false);
		}
	}
}
