using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Interface;
using SSJJBase.String;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerRpgLootBufferRender : AbstractPlayerEffectRender
{
	private TextMesh _text;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_text = effectGameObject.transform.Find("Suggest").Find("Suggest").Find("FlagCount")
			.GetComponent<TextMesh>();
		_text.text = "0";
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return new Vector3(0f, 0f, GetHeight(targetPlayer));
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		_text.text = StringCache.IntToString(GetFlagCount(targetPlayer));
	}

	private int GetFlagCount(PlayerEntity targetPlayer)
	{
		if (targetPlayer.hasSkill)
		{
			IMyDictionary<int, PlayerInfoComponent.StatusDes> status = targetPlayer.skill.Status;
			if (status.ContainsKey(PlayerInfoStatusConstant.RpgLootFlagCount.ID))
			{
				return status[PlayerInfoStatusConstant.RpgLootFlagCount.ID].Number;
			}
		}
		return 0;
	}
}
