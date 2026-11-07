using Assets.Sources.Components.Interface;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class HelpReliveSuggestRender : AbstractPlayerEffectRender
{
	private TextMesh _reliveText;

	private SpriteRenderer _helpReliveSprite;

	private SpriteRenderer _waitHelpReliveSprite;

	private SpriteRenderer _container;

	private bool _waitHelpRelive;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_reliveText = effectGameObject.transform.Find("HelpRelive/4/sprite/container/Count").GetComponent<TextMesh>();
		_container = effectGameObject.transform.Find("HelpRelive/4/sprite/container").GetComponent<SpriteRenderer>();
		_container.SetAlpha(0f);
		_helpReliveSprite = effectGameObject.transform.Find("HelpRelive/4/sprite").GetComponent<SpriteRenderer>();
		_waitHelpReliveSprite = effectGameObject.transform.Find("HelpRelive/4/wait").GetComponent<SpriteRenderer>();
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		_reliveText.text = StringCache.IntToString(targetPlayer.GetCanReliveTime() / 1000);
		_waitHelpRelive = targetPlayer.HasState(1048576) && targetPlayer.GetCanReliveTime() > 0;
		if (battleRoom.GetRaceType() >= 110003 && battleRoom.GetRaceType() <= 110012)
		{
			_reliveText.SetObjectActive(isactive: false);
		}
		UpdateHelpReliveSprite3DAlpha(targetPlayer);
	}

	private void UpdateHelpReliveSprite3DAlpha(PlayerEntity targetPlayer)
	{
		if (_waitHelpRelive)
		{
			_helpReliveSprite.SetAlpha(0f);
			_waitHelpReliveSprite.SetAlpha(1f);
			_reliveText.text = "";
			return;
		}
		_waitHelpReliveSprite.SetAlpha(0f);
		if (!InAlphaRange(targetPlayer))
		{
			_helpReliveSprite.SetAlpha(1f);
		}
		else
		{
			_helpReliveSprite.SetAlpha(0.4f);
		}
	}

	private bool InAlphaRange(IPlayerEntity targetPlayer)
	{
		return GetDistance(targetPlayer) <= 12000000f;
	}

	private float GetDistance(IPlayerEntity targetPlayer)
	{
		PlayerContext player = Contexts.sharedInstance.player;
		if (!player.isMyPlayer)
		{
			return float.MaxValue;
		}
		PlayerEntity myPlayerEntity = player.myPlayerEntity;
		if (targetPlayer.GetId() == myPlayerEntity.GetId())
		{
			return float.MaxValue;
		}
		Vector3 compenstatePos = myPlayerEntity.GetCompenstatePos(myPlayerEntity.fpos.Change.GetPosIndex());
		Vector3 compenstatePos2 = targetPlayer.GetCompenstatePos((targetPlayer as PlayerEntity).fpos.Change.GetPosIndex());
		float num = compenstatePos.x - compenstatePos2.x;
		float num2 = compenstatePos.y - compenstatePos2.y;
		float num3 = compenstatePos.z - compenstatePos2.z;
		return num * num + num2 * num2 + num3 * num3;
	}

	private bool InHelpRange(IPlayerEntity targetPlayer)
	{
		return GetDistance(targetPlayer) <= 86700f;
	}

	public override void Update(int frameTime, PlayerEntity player, SceneObjectEntity effectEntity, IBattleRoom room)
	{
		base.Update(frameTime, player, effectEntity, room);
		if (!_waitHelpRelive && InHelpRange(player) && Contexts.sharedInstance.player.myPlayerEntity != null && !Contexts.sharedInstance.player.myPlayerEntity.IsDead())
		{
			Contexts.sharedInstance.message.deathMatchMessage.MessageType = 0;
			NotifyManager.ForceInvoke(29);
		}
	}
}
